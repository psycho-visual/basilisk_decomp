# Razer HID command protocol and the BL 2.0 (HID DFU) update path

Everything below was reconstructed from three sides that agree with each other:

* the host DLL `FWUpdaterDLL.dll` (`native/FWUpdaterDLL/FWUpdaterDLL_razer.c`),
* the .NET front-end `CustomerFWU2Point5.exe` (`dotnet/CustomerFWU2Point5/…/FormFWUStep1.cs`, `DeviceInterface.cs`),
* the mouse firmware's command dispatcher (`firmware/decompiled/BasiliskV3_FW_v1.02.00.c`, `razer_cmd_dispatch`).

## Transport

| | Application mode | Bootloader mode |
|---|---|---|
| USB VID:PID | `1532:0099` (Basilisk V3) | `1532:110E` (Razer HID bootloader), bcdDevice/"BCD PID" `0x0099` |
| Interface | HID, feature report, report ID 0 | HID, feature report, report ID 0 |
| Report length | 91 bytes on the wire (1 report-ID byte + 90 payload) | same |
| Host API | `HidD_SetFeature` / `HidD_GetFeature` | same |

`DeviceUpdater.resources` holds these values (`VID`, `PID`, `BLVID`, `BLPID`, `BCDPID_BL`, `BLVER=2.0`,
`ReportType=4`, `FeatureReportLen=91`). With `BLVER = 2.0` the app opens the bootloader as a HID device
(`OpenDevice(…, reporttype 12, featurelen 91, 0, 0)`). Bootloader versions 1.0, 1.1 and 3.0 use the WinUSB
driver from `drivers/` instead (vendor control requests 0x81/0x82/0x84/0x87/0x8F, or bulk pipes). The
Basilisk V3 does not use them.

## Report layout (90-byte payload)

Offsets are into the 91-byte buffer passed to `HidD_SetFeature` (byte 0 is the report ID).
In the firmware, the same 90 bytes live at `g_razer_report` (`0x04000CE4`, type `razer_report_t`).

| Buf off | Payload off | Field | Notes |
|---:|---:|---|---|
| 0 | – | report ID | always 0 |
| 1 | 0 | `status` | host sends 0x00. Device answers 0x01 busy, 0x02 OK, 0x03 fail/CRC error, 0x04 timeout, 0x05 not supported |
| 2 | 1 | `transaction_id` | the updater leaves it 0 |
| 3–4 | 2–3 | `remaining_packets` | big-endian, 0 |
| 5 | 4 | `protocol_type` | 0 |
| 6 | 5 | `data_size` | number of meaningful argument bytes |
| 7 | 6 | `command_class` | |
| 8 | 7 | `command_id` | bit 7 set = "get" (read) variant |
| 9–88 | 8–87 | `args[80]` | |
| 89 | 88 | `crc` | XOR of payload bytes 2..87 (buffer bytes 3..88) |
| 90 | 89 | reserved | 0 |

Host side: `razer_report_crc()` (0x100025D0). Device side: the first and last loops of `razer_cmd_dispatch()` (0x2000AE00).
If the CRC check fails, the firmware sets status 0x03 and does not dispatch.

### Transaction (`razer_feature_transact`, 0x10002630)

```
repeat up to 3 times:
    delay(d)
    set CRC; HidD_SetFeature(buf, 91)          (up to 3 tries)
    repeat up to N times:                         N = "retries" argument (2…20)
        delay(d)
        HidD_GetFeature(rsp, 91)
        if rsp.transaction_id == req.transaction_id && rsp.class == req.class && rsp.id == req.id
           && rsp.status not in (0x00 new, 0x01 busy):
              if rsp.status == 0x02: copy rsp into caller buffer; return 0x02
              break
return last status
```

Callers treat a return value of `2` as success.

## Commands used by the updater

### Class 0x00: device / general (firmware `razer_cmd_class00_device`, 0x20009804)

| Cmd | Size | Args (request) | Response | Host function | Purpose |
|---|---:|---|---|---|---|
| `00/04` | 2 | `[mode, 0]` | – | `EnterDeviceMode(h, mode)` | `mode = 1`: **enter bootloader**. The firmware stores `0xAAAAAAAA` at RAM `0x04007FFC` (`g_bootloader_magic`) and calls `NVIC_SystemReset()`; the bootloader keeps control and re-enumerates as `1532:110E`. `mode = 0/2/3` switch normal/driver modes. The app sends `mode = 7` in `ForceEnterUSBMode()`. |
| `00/87` | 8 | – | `args[0..2] = major, minor, patch` | `GetFWVersion(h, buf, devtype)` | Firmware version. v1.02.00 replies `01 02 00 00`. (`devtype == 4` uses `00/93` instead.) |
| `00/86` | 3 | – | `args[1] = edition, args[2] = layout` | `GetEditionID` | Edition/layout (used for other products) |
| `00/0B` | 1 | `[1]` | – | `BackToDefult` (sic) | `[1]`: factory reset (copies the default profile/keymap/lighting tables from flash `0x2000EA9A…` and schedules a settings save). `[0]`: immediate `NVIC_SystemReset()` |
| `05/04` | 1 | `[profile]` | – | `SetActiveProfile` | (class 0x05) select on-board profile |

The firmware handles more class 0x00 IDs than the updater uses: `02/82` serial number set/get (22 bytes at
`0x040014B2`), `05/85` and `0E/8E` profile bookkeeping, `0D/8D`, `33/B3`, `3D/BD`, `81`, `84`, `86`.

### Class 0x10: bootloader DFU (BL 2.0, handled by the bootloader, not by the application image)

| Cmd | Size | Args | Response | Host function | C# caller |
|---|---:|---|---|---|---|
| `10/80` | 9 | – | `args[…]` incl. target product ID | `GetDevPIDInBootloader(h, 2.0f)` | `OpenDevice`/`GetBootloaderHandle` use it to check that the bootloader belongs to PID `0x0099` |
| `10/01` | 8 | `start_addr (BE32), end_addr (BE32)` | – | `DFUErase(h, start, end)` | `backgroundWorkerEraseFlash`, called with `0x20000000 .. 0x2000F648` |
| `10/02` | 8 † | `len (u8), addr (BE32), data[len]` | – | `DFUProgram(h, len, addr, delay, data)` | `backgroundWorkerProgramFW`, 64-byte chunks (`Common.PACKLEN`), up to 10 retries each |
| `10/83` | 5 | `len (u8), addr (BE32)` | `args[5..5+len)` = flash contents | `DFUVerify(h, len, addr, delay, out)` | `backgroundWorkerVerify`, compared against `FW.bin` |
| `10/05` | 0 | – | – | `DFUExit(h)` | `ExitBL(h, 2.0f)`. The bootloader starts the application |

† `data_size` is always 8 in `DFUProgram`, even though it sends `5 + len` meaningful argument bytes.

## End-to-end BL 2.0 sequence (Basilisk V3)

```
host (CustomerFWU2Point5 + FWUpdaterDLL)                 mouse
---------------------------------------------------------------------------------------------
OpenDevice(1532:0099, HID feature, 91)
00/87 get firmware version            ───────────────►  01 02 00 xx  (compare with DevFWVer "1.02.00")
[user clicks Update]
00/04 set device mode, mode=1         ───────────────►  RAM[0x04007FFC] = 0xAAAAAAAA; SYSRESETREQ
                                                         … re-enumerates as 1532:110E (bootloader)
timerbllistener polls OpenDevice(1532:110E, bcd 0x0099, BL 2.0)
10/80 get target PID                  ───────────────►  0x0099
ProcessFWData: Intel HEX lines from DeviceUpdater.resources → FW.bin
              (StartAddr = 0x20000000, EndAddr = 0x2000F648)
10/01 erase 0x20000000..0x2000F648    ───────────────►
for off in 0..len step 64:
   10/02 program len=64 addr=0x20000000+off data ───►
for off in 0..len step 64:
   10/83 verify len=64 addr=…         ───────────────►  data ─► compare
10/05 exit bootloader                 ───────────────►  jumps to application @0x20000000
FormCongratulation
```

`VerifyChecksum = 0` in the config, so the optional WinUSB checksum control request is skipped. No signature
or encryption is applied to the image: the bootloader receives plain Thumb code.
