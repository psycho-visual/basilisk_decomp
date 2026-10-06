# FWUpdaterDLL.dll

| | |
|---|---|
| Type | PE32 DLL, x86, MSVC 14.x (linker 14.0), MFC/ATL/UCRT **statically linked** |
| Version resource | 1.0.0.21 (company/product strings still say `TODO: <…>`) |
| Build time | 2021-02-18 |
| PDB path | `C:\Users\<user>\Desktop\2017_FWU\Other\3_FWUpdaterDLL\Release\FWUpdaterDLL.pdb` |
| Signed | no |
| Imports | `HID.DLL` (HidD_*, HidP_GetCaps), `WINUSB.DLL`, `SETUPAPI.dll`, `bthprops.cpl`, `ADVAPI32` (SCM, token privileges) + MFC dependencies |

Ghidra found 10,691 functions. Its Function-ID databases named 4,864 of them (MFC/CRT). The Razer-written part is
contiguous at `0x10002500–0x10005AFF`, and `native/FWUpdaterDLL/FWUpdaterDLL_razer.c` contains just those 48 functions.
`FWUpdaterDLL.dll.c` is the full 11 MB decompilation.

## Exports

All are `cdecl`. The C# signatures come from `DeviceInterface.cs`. The "wire" column uses `class/id` from
[protocol.md](protocol.md).

| Export | RVA | C# signature | What it does |
|---|---|---|---|
| `OpenDevice` | 0x2F60 | `IntPtr (uint vid, uint pid, ushort bcdpid, float blver, int reporttype, int featurelen, int inputlen, int outputlen)` | Formats VID/PID as `%04X` and calls `open_hid_device`. That enumerates `HidD_GetHidGuid` interfaces (or the WinUSB GUID `{C9348766-D27C-41EE-B2BE-EA9412F72B52}` for BL 1.x/3.0), matches `VID_`/`PID_`/`MI_`/`COL01`/`REV_` in the device path depending on the report-type flags, opens it, and for BL 2.0 checks `GetDevPIDInBootloader == bcdpid` |
| `GetBootloaderHandle` | 0x2C20 | `IntPtr (uint vid, uint pid, ushort bcdpid, float blver)` | WinUSB-GUID enumeration plus PID check (BL 1.x/3.0) |
| `CloseDevice` | 0x3000 | `void (IntPtr)` | `CloseHandle` |
| `GetDevPIDInBootloader` | 0x2900 | `ushort (IntPtr, float blver)` | BL 1.x/3.0: `bcdDevice` from the USB device descriptor. BL 2.0: `10/80` |
| `GetFWVersion` | 0x2B70 | `int (IntPtr, byte[] fwver, byte devtype)` | `00/87` (or `00/93` if devtype 4), copies 80 arg bytes |
| `EnterDeviceMode` | 0x2AF0 | `int (IntPtr, byte mode)` | `00/04 [mode,0]`. Mode 1 reboots into the bootloader |
| `GetBLFWVERInBootloader` | 0x37F0 | `int (IntPtr, float blver, byte[] ver)` | BL 1.x/3.0: string descriptor 3. BL 2.0: returns zeros |
| `DFUErase` | 0x3910 | `int (IntPtr, uint start, uint end)` | `10/01` |
| `DFUProgram` | 0x3A70 | `int (IntPtr, byte len, uint addr, int delay, byte[] data)` | `10/02` |
| `DFUVerify` | 0x3B80 | `int (IntPtr, byte len, uint addr, int delay, byte[] out)` | `10/83` |
| `DFUExit` | 0x3CA0 | `int (IntPtr)` | `10/05` |
| `BackToDefult` | 0x3D00 | `bool (IntPtr)` | `00/0B [1]` factory reset |
| `SendCmd` | 0x3D80 | `int (IntPtr, byte reportid, byte cls, byte id, byte pktmsb, byte pktlsb, byte len, int retries, int delay, byte[] param, byte[] ret)` | Generic Razer feature-report transaction |
| `SetFeatureRpt` / `GetFeatureRpt` | 0x4B30 / 0x4C50 | see C# | One-way set or get of a Razer report |
| `SetActiveProfile` | 0x45A0 | `int (IntPtr, byte profile)` | `05/04 [profile]` |
| `GetEditionID` | 0x5330 | `bool (IntPtr, ref byte edition, ref byte layout)` | `00/86` |
| `ControlIn` / `ControlOut` | 0x4040 / 0x40D0 | `bool (IntPtr, byte req, ushort value, uint index, ushort len, byte[] buf)` | `WinUsb_ControlTransfer`, vendor request (BL 1.x) |
| `CheckPipeID` / `OutData` / `ReadData` | 0x4610 / 0x4750 / 0x47A0 | | WinUSB bulk pipes (BL 3.0) |
| `GetPS4FWVerion` / `EnterPS4Bootloader` | 0x3E50 / 0x4160 | | Raiju/PS4 controller variants (DevType 7) |
| `ReadInputRptData` | 0x5A40 | | Overlapped `ReadFile` on an input report |
| `HaveBT` | 0x47F0 | `void (ref bool havebt, ref bool bton, ref bool ble)` | Bluetooth radio presence via `bthprops.cpl` |
| `DevExist` | 0x4D90 | `bool (uint vid, uint pid, bool usbOrHid)` | SetupAPI enumeration |
| `DoStopSvc` | 0x5680 | `bool (string service)` | Stops a service and its dependents (used to stop Synapse services) |
| `InstallBLDriver` | 0x4300 | `void (string path)` | `ShellExecuteA(path, " /s")`, i.e. silent `DPInst` |
| `RebootSystem` | 0x44F0 | `bool ()` | Enables `SeShutdownPrivilege`, then `ExitWindowsEx(EWX_REBOOT)` |
| `IsWindows10OrGreater` / `IsWindows8BLUEOrGreater` / `GetOSVersion` | 0x44B0 / 0x44D0 / 0x4410 | | via `RtlGetVersion` |
| `ExistMonitor` | 0x5920 | | Enumerates display devices (laptop SKUs) |
| `GetDevRegionList` | 0x3E40 | | stub |
| `delay` | 0x2500 | `void (float ms)` | `QueryPerformanceCounter` busy-wait |

## Internal helpers (named in `native/symbols.tsv`)

| Address | Name | |
|---|---|---|
| 0x100025D0 | `razer_report_crc` | XOR bytes 3..88 → byte 89 |
| 0x10002630 | `razer_feature_transact` | send, then poll until the response echoes the command (see protocol.md) |
| 0x10002840 | `hid_get_caps` | `HidD_GetPreparsedData` + `HidP_GetCaps` |
| 0x10003020 | `open_hid_device` | device-path matcher behind `OpenDevice` |
| 0x10004330 | `rtl_get_version` | `ntdll!RtlGetVersion` |
| 0x100053C0 | `stop_dependent_services` | used by `DoStopSvc` |
