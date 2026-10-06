# Razer Basilisk V3 Firmware Updater v1.02.00: full decompilation

This repository is a complete decompilation of `BasiliskV3_0099_FirmwareUpdater_v1.02.00_r1.exe`
(SHA-256 `eaa3dd23cc0aaa9920d42ab19fd77bc8a196ca769522e14410f7314dfcb8948e`). It covers every layer: the WinRAR
self-extractor, the .NET updater application and its Razer libraries, the native USB/HID helper DLL, and the
mouse firmware image the updater flashes.

## Layout

| Path | Content | How |
|---|---|---|
| [`docs/`](docs) | Write-ups: [package](docs/package.md), [updater app](docs/updater-app.md), [native DLL](docs/native-dll.md), [**HID/DFU protocol**](docs/protocol.md), [**firmware**](docs/firmware.md) | manual analysis |
| [`dotnet/`](dotnet) | C# source of `CustomerFWU2Point5.exe` and the 5 Razer assemblies it ships with, as one solution that **compiles** (`dotnet build`) | ILSpy 9.1 + SmartAssembly string decoding |
| [`native/FWUpdaterDLL/`](native/FWUpdaterDLL) | `FWUpdaterDLL_razer.c` (the 48 Razer-written functions, named) and `FWUpdaterDLL.dll.c` (all 10,691 functions incl. static MFC/CRT), plus types, symbols, strings | Ghidra 11.4.2 |
| [`firmware/`](firmware) | Basilisk V3 application firmware **v1.02.00** as `.hex`/`.bin` (load address `0x20000000`), the recovered initial RAM image, and `decompiled/` (all 437 functions as C, with annotations) | Ghidra 11.4.2, ARM Cortex-M0+ Thumb |
| [`resources/`](resources) | `DeviceUpdater.resources` config, 123 product images, localized UI strings (10 languages), decoded SmartAssembly string tables | custom extractors |
| [`sfx/`](sfx) | SFX script and the decompiled WinRAR SFX stub | Ghidra |
| [`drivers/`](drivers) | `rzrbtldr.inf` (WinUSB INF for the legacy `1532:110D` bootloader) | copied |
| [`tools/`](tools) | Ghidra scripts, Python and C# helpers, and `decompile.sh`, which reproduces everything | |

## Key findings

* **Package**: a signed WinRAR SFX that silently extracts to a temp folder and runs `CustomerFWU2Point5.exe`, Razer's
  generic "Customer FW Updater 2.5". All product specifics come from the data file `DeviceUpdater.resources`:
  VID/PID `1532:0099`, bootloader `1532:110E`, `BLVER 2.0`, and the firmware.
* **Firmware**: stored in plain text as 3,944 Intel HEX lines. It is a 63,048-byte image linked at `0x20000000`
  for an ARMv6-M (Cortex-M0+) MCU with 32 KB SRAM at `0x04000000`, built with Keil MDK, running at 96 MHz.
  It is **not encrypted or signed**. The exact MCU part is not identified.
* **Protocol**: the standard Razer 90-byte HID feature report (status, transaction ID, size, class, ID, 80 argument
  bytes, XOR CRC). Updating uses:
  * `00/04 [1]`: the firmware writes `0xAAAAAAAA` to `0x04007FFC` and resets into the bootloader.
  * `10/80`: identify the target product.
  * `10/01`: erase.
  * `10/02`: program in 64-byte chunks.
  * `10/83`: read back.
  * `10/05`: exit.

  See [docs/protocol.md](docs/protocol.md).
* **Firmware internals**: `razer_cmd_dispatch` handles command classes 0x00, 0x02, 0x04, 0x05, 0x06, 0x0B, 0x0F and
  0xFE. Version `00/87` returns `1.02.00`. The USB descriptors were recovered from the compressed `.data` section.
  See [docs/firmware.md](docs/firmware.md).
* **Obfuscation**: three of the Synapse support libraries (AccountManagerClient/Common, ActionServiceCommon) are protected
  with SmartAssembly 6.11 string encoding. This was removed statically (`tools/dotnet/sastrings`) before
  decompiling, so the C# contains the real string literals.

## Not decompiled (and why)

* Microsoft redistributables (`winusb.dll`, `DPInst_*.exe`, `WdfCoInstaller01009.dll`, `WinUSBCoInstaller.dll`): stock,
  Microsoft-signed WDK binaries.
* `log4net.dll` 1.2.10: Apache open source. The rebuilt projects pull it from NuGet.
* The mouse **bootloader** is not in the package, because the updater only talks to it. Its command set is documented
  from the host side.

Hashes, versions and signers of every file are listed in [docs/package.md](docs/package.md).

## Caveats

Decompiled output is machine-generated. Names such as `FUN_2000xxxx`, `DAT_0400xxxx`, and `param_1` are Ghidra
defaults. Only the symbols in `firmware/symbols.tsv` and `native/symbols.tsv` were named by hand, and each was checked
against the code. The C# is ILSpy output. It compiles, but it is not byte-identical to Razer's original source.

This repository is for interoperability and research. The original binaries and firmware are © Razer Inc.
