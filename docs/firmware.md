# Basilisk V3 application firmware v1.02.00

## Where it comes from

`DeviceUpdater.resources` (a .NET binary `ResourceSet` next to the exe) stores the image as 3,944 Intel HEX lines
(`DevFWLine0` … `DevFWLine3943`, `DevFWLineNum = 3944`). `tools/python/hex_from_res.py` rebuilds the file and checks
every record checksum:

| File | Description |
|---|---|
| `firmware/BasiliskV3_FW_v1.02.00.hex` | byte-identical concatenation of the stored HEX lines |
| `firmware/BasiliskV3_FW_v1.02.00.bin` | flat image, load address `0x20000000`, 63,048 bytes (`0x20000000–0x2000F647`) |
| `firmware/BasiliskV3_FW_v1.02.00.map.txt` | segment map (one contiguous segment; start-linear-address record `0x200000C1`) |
| `firmware/BasiliskV3_FW_v1.02.00.ram_init.bin` | RAM contents after `__scatterload` (`0x04000000–0x04004A3F`), produced by `tools/python/keil_scatter.py` |

The image is **not encrypted or signed**. It is plain ARMv6-M Thumb code. The only integrity data is the per-record HEX
checksum. `VerifyChecksum = 0` in the config, and the updater relies on read-back verification (`10/83`) instead.

The config also declares a second, external-flash image (`FlashFWType = 5`, `FlashFWVer = 1.12.00`), but
`FlashFWUpdate = 0` and there are no `FlashFWLine*` entries, so this package does not update it.

## Toolchain and CPU

* **Keil MDK / ARMCC**: `__main` → `__scatterload` with a compressed `Region$$Table`, `__decompress1` (LZ77 + zero-run),
  `__aeabi_*` helpers, and the `__ARM_common_switch8` jump-table idiom.
* **Cortex-M0+**: ARMv6-M instruction set only. The vector table has 16 + 32 entries, and `SystemInit` writes
  `SCB->VTOR = 0x20000000`, which a plain M0 does not have.
* **Clocks**: `SystemCoreClock` starts at 12 MHz (`0x00B71B00` in the RW image), and `clock_init` (0x200003D0) switches
  to 96 MHz.

The MCU part number is **not identified**. The memory map below does not match common STM32/NXP/Nordic parts. Peripheral
blocks sit at `0x40000000–0x400FFFFF` (e.g. watchdog-like block at `0x4000C000`, GPIO-like blocks at `0x40001000`,
`0x40080000–0x40098000`).

## Memory map used for the analysis

| Range | Ghidra block | Contents |
|---|---|---|
| `0x20000000–0x2000F647` | `FLASH_IMAGE` (r-x, read-only) | application image. A bootloader lives elsewhere and is not part of this package |
| `0x04000000–0x04004A3F` | `SRAM` (rw, initialised) | `.data` (0x604 bytes, decompressed) + `.bss` (0x443C bytes) |
| `0x04004A40–0x04007FFF` | `SRAM_FREE` | heap/stack, initial SP = `0x04007FFC` |
| `0x04007FFC` | – | `g_bootloader_magic`: `0xAAAAAAAA` = "stay in bootloader after reset" |
| `0x40000000–0x400FFFFF` | `PERIPH` (volatile) | on-chip peripherals |
| `0xE0000000–0xE00FFFFF` | `SCS` (volatile) | SysTick, NVIC, SCB |

## Startup

```
vector[0]  SP     = 0x04007FFC
vector[1]  Reset  = 0x200000D5 → Reset_Handler: SystemInit(); __main()
vector[7]  = 0xFBFF658D   (reserved slot holds a non-zero constant, probably checked by the bootloader; algorithm not identified)
IRQ n      → 4-byte stubs "ldr r0,[pc,#…]; bx r0" that load the real handler from a table at 0x20000170
__main (0x200000C0): SP reset → __scatterload (0x20000354) → main (0x20007F38)
__scatterload Region$$Table @ 0x2000F468:
   { src 0x2000F48C, dst 0x04000000, len 0x604,  __decompress1 @ 0x20000378 }   444 packed bytes
   { src 0x2000F648, dst 0x04000604, len 0x443C, __scatterload_zeroinit @ 0x2000521C }
```

The RW image includes the USB descriptors, so they were recovered statically:

* device descriptor @ `0x04000040`: USB 2.0, EP0 64, **VID 0x1532 PID 0x0099 bcdDevice 0x0200**, 1 configuration
* configuration descriptor @ `0x04000080`: 109 bytes, 4 HID interfaces (EP 0x81, 0x82, 0x83, 0x84)
* strings: `0x0409` langid, "Razer", "Razer Basilisk V3"

## Main loop

`main` (0x20007F38) runs the init calls, then loops: feed the watchdog (`wdt_feed`), run the input/lighting work, and step
a state machine at `FUN_20004d84` (not identified yet). Timer flags in `0x04000D65` drive `periodic_tasks` (0x2000AD88).
When bit 1 is set, it calls `razer_cmd_dispatch` to service the HID feature-report buffer.

## Command dispatcher

`razer_cmd_dispatch` (0x2000AE00) checks the CRC, sets `status = 0x01`, and switches on `command_class`:

| Class | Handler | Command IDs seen in the decompiled handler |
|---|---|---|
| 0x00 | `razer_cmd_class00_device` 0x20009804 | 02 04 05 06 0B 0D 0E 33 3D 81 82 84 85 86 87 8D 8E B3 BD |
| 0x02 | `razer_cmd_class02_keymap` 0x20008814 | 02 0C 14 16 17 18 82 84 8C 8E 94 96 97 98 |
| 0x04 | `razer_cmd_class04_sensor` 0x20009B70 | 00–06 (jump table at 0x20009C30), 80, 82–86 |
| 0x05 | `razer_cmd_class05` 0x2000AEE8 | 02 03 04 08 80 81 84 88 8A |
| 0x06 | `razer_cmd_class06_storage` 0x2000A85C | 02 03 04 05 07 08 09 0A 0C 80 81 84–8E |
| 0x0B | `razer_cmd_class0B` 0x2000AFF8 | 01–06 09 0B 0C 0D 80 83 85 8B–8E |
| 0x0F | `razer_cmd_class0F_led` 0x200093E0 | 02 03 04 05 80 81 82 84 85 |
| 0xFE | `razer_cmd_classFE` 0x2000B52C | 32 B1 |
| other | – | status 0x05 (not supported) |

Afterwards the CRC is recomputed and `status` becomes `0x02` unless the handler set a failure code.

Notable handlers:

* **`00/04` set device mode**: `mode == 1` writes `g_bootloader_magic = 0xAAAAAAAA` and calls `NVIC_SystemReset()`
  (`AIRCR = 0x05FA0004`). This is how the updater reaches the bootloader.
* **`00/87` firmware version**: returns `01 02 00 00`.
* **`00/0B` reset**: `[0]` reboots, `[1]` restores defaults (copies `0x2000EA9A…` into the live tables, re-applies DPI
  and lighting, and schedules a flash save via `settings_mark_dirty`).
* **`button_action_execute`** (0x20008BF4): runs a button's binding (mouse button, key, DPI ±100 clamped to 50…26000,
  profile cycling, and so on).

## Reading the decompilation

* `firmware/decompiled/BasiliskV3_FW_v1.02.00.c`: all 437 functions, Ghidra 11.4.2, with the curated names from
  `firmware/symbols.tsv` applied (runtime, startup, dispatcher, class handlers, data labels, `razer_report_t`).
  Everything else keeps Ghidra's `FUN_<addr>` / `DAT_<addr>` names.
* `….functions.tsv`: address, name, size, and signature of every function.
* `….h`: types used by the listing (incl. `razer_report_t`).

To reproduce or extend it, see `tools/README.md`. After editing `symbols.tsv`, re-run only the
`ApplySymbols.java` + `ExportDecomp.java` pass.
