# CustomerFWU2Point5.exe: the updater front-end

| | |
|---|---|
| Assembly | `CustomerFWU2Point5` 1.0.2.17732, .NET Framework 4.5, x86, WinForms |
| Signed | Razer USA Ltd. (DigiCert, 2022) |
| Source | `dotnet/CustomerFWU2Point5/` (ILSpy 9.1, C# 7.3). Builds with `dotnet build` |
| Original project path (PDB) | `D:\FW-Code\2017_fwu\CustomerFirmwareUpdater\1_CustomerFWU\1_CustomerFWU2.5\CustomerFWU2Point5\…` |

This is Razer's generic "Customer FW Updater 2.5" shell. It contains code paths for many products (Blade laptops,
Huntsman, BlackWidow, Raiju/Panthera controllers, Nordic and STM dongles, and others). The product is chosen entirely
by the data file **`DeviceUpdater.resources`** placed next to the exe, a .NET binary `ResourceSet` read by
`UpdateInfo` (`Common.resfile`).

## DeviceUpdater.resources for this package

`resources/DeviceUpdater/config.tsv` holds every key except the firmware lines:

| Key | Value | Meaning |
|---|---|---|
| `ProductName` / `DevName` | `Basilisk V3` / `巴塞利斯蛇 V3` | UI strings |
| `VID`, `PID` | `1532`, `0099` | application-mode USB IDs |
| `BLVID`, `BLPID`, `BCDPID_BL` | `1532`, `110E`, `0099` | bootloader USB IDs plus the product ID it reports |
| `BLVER` | `2.0` | HID bootloader. Selects the `DFU*` command path |
| `DevType` | `1` | mouse |
| `FWType` | `2` | Intel HEX (1 = S19) |
| `DevFWVer` | `1.02.00` | version contained in this package |
| `DevFWLineNum` / `DevFWLine0..3943` | `3944` / `:020000042000DA` … | the firmware (see [firmware.md](firmware.md)) |
| `ReportType`, `FeatureReportLen`, `InputReportLen`, `OutputReportLen` | `4`, `91`, `0`, `0` | HID access parameters for `OpenDevice` |
| `FlashFWUpdate`, `FlashFWType`, `FlashFWVer` | `0`, `5`, `1.12.00` | secondary flash image (disabled) |
| `VerifyChecksum` | `0` | skip WinUSB checksum request |
| `Internal`, `LogFile`, `DummyUpdater` | `0`, `0`, `False` | engineering switches |

## Start-up

1. The WinRAR SFX extracts everything to a temp folder (`TempMode`, `Silent=1`) and runs `CustomerFWU2Point5.exe`.
2. `Program.Main`: loads `UpdateInfo`, then takes a named mutex `Razer<ProductName>DeviceUpdater` so only one instance runs.
3. `appContextDevice`: picks the UI language (`CLocalize`, or Synapse's language via `AccountManagerClient` when run from
   Synapse). If `BLVER != 2.0`, it installs the WinUSB bootloader driver silently with `DPInst` (`InstallBLDriver`).
   It then builds the page list and shows `FormGuide`.
4. Pages: `FormGuide` → `FormFWUStep1` → `FormCongratulation`. `FormRaijuEnterBL` and `FormPantheraEnterBL` exist for
   controllers, and `ShowModelNo` for laptops. `PromptExitSynapse` is built, but no page in this build navigates to it.

## FormFWUStep1: the flashing state machine

`FormFWUStep1` (≈4,400 lines) chains `BackgroundWorker`s. For the Basilisk V3 (`BLVER 2.0`, `FWType 2`):

| Step | Worker / timer | Action |
|---|---|---|
| detect | `DeviceListener` (WM_DEVICECHANGE) + `backgroundWorkerCheckVer` | `OpenDevice(1532:0099)`, `GetFWVersion` (`00/87`), compare with `DevFWVer` |
| enter BL | `buttonUpdate_Click` | `EnterDeviceMode(h, 1)` (`00/04`), start `timerbllistener` / `timerblentersuccess` |
| wait BL | `timerbllistener_Tick` | poll `OpenDevice(1532:110E, bcd 0x0099, BL 2.0, 12, 91)` |
| process | `backgroundWorkerProcessFWData` | parse the HEX lines, write `FW.bin` next to the exe in 512-byte pages (0xFF fill), set `Common.StartAddr = 0x20000000` and `Common.EndAddr = 0x2000F648` |
| erase | `backgroundWorkerEraseFlash` | `DFUErase(StartAddr, EndAddr)` (`10/01`) |
| program | `backgroundWorkerProgramFW` | 64-byte `DFUProgram` (`10/02`) chunks, up to `Common.MAX_RETRY = 10` per chunk |
| verify | `backgroundWorkerVerify` | 64-byte `DFUVerify` (`10/83`) read-back, compared with `FW.bin` |
| exit | `ExitBL(h, 2.0)` | `DFUExit` (`10/05`) → application restarts |
| done | `FormCongratulation` | |

Failures go to `processupdatefail()`, which shows the retry/reconnect UI. States are listed in `eState.cs`.

The other bootloader generations follow the same chain over different transports:
* **BL 1.0/1.1**: WinUSB vendor control requests: 0x82 erase page, 0x81 write, 0x87 verify, 0x8F status, 0x84 exit.
* **BL 3.0**: WinUSB bulk pipes.
* **Nordic and STM dongles**: region-list based flashing (`backgroundWorkerNordic*`, `…FlashRegion…`).

## Other notes

* Logging goes to `DeviceUpdater_<date>.log` when `LogFile = 1`.
* `Common.CRC16` and the "Patricia" calibration code belong to other products.
* Strings are localised through `Resources/ResourceStr` plus 9 satellite assemblies (de-DE, es-ES, fr-FR, ja-JP, ko-KR,
  pt-BR, ru-RU, zh-CHT, zh-CN). Decoded tables are in `resources/dotnet/satellite/`.
* About 12 MB of the exe is product artwork for every supported device (`Properties/Resources.resx`). All 123 PNGs were
  extracted to `resources/dotnet/CustomerFWU2Point5/CustomerFWU2Point5.Properties.Resources/`.

## Supporting Razer assemblies

| Assembly | Purpose | Decompilation notes |
|---|---|---|
| `RcClientBase` 7.2.86 | named-pipe client base for Razer Synapse services | clean |
| `ActionServiceCommon` 7.2.86 | shared Synapse types, settings manager, system tray, process launcher | **SmartAssembly 6.11** string encoding, removed with `tools/dotnet/sastrings` |
| `AccountManagerCommon` 7.2.86 | Razer ID / account data model | same |
| `AccountManagerClient` 7.2.86 | Razer ID client (login, settings sync, warranty, licences) | same |
| `CustomProgressBar` 1.0.1 | progress-bar control (.NET 2.0) | clean |

The three SmartAssembly-protected assemblies keep their type and member names. Only strings were encoded: they were
stored DES-encrypted and deflate-compressed in a `{guid}` resource and fetched through per-class `GetString` delegate
proxies ("HouseOfCards"). `tools/dotnet/sastrings` decodes the blob statically, replaces each proxy call with an
`ldstr`, and removes the SmartAssembly runtime. ILSpy then also recovers the lambdas and `async` state machines that the
injected fields had broken. Decoded string tables: `resources/smartassembly-strings/`.
