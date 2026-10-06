# Package structure

## Outer file

| | |
|---|---|
| File | `BasiliskV3_0099_FirmwareUpdater_v1.02.00_r1.exe` |
| Size | 22,607,792 bytes |
| SHA-256 | `eaa3dd23cc0aaa9920d42ab19fd77bc8a196ca769522e14410f7314dfcb8948e` |
| Format | WinRAR 6.x GUI self-extracting archive. The PE stub is 0x62800 bytes (PE timestamp 2022-03-03), followed by a RAR5 archive at offset `0x62800` and an Authenticode signature |
| Signed | Razer USA Ltd. (DigiCert Trusted G4 Code Signing RSA4096 SHA384 2021 CA1), DigiCert-timestamped |

The RAR archive comment holds the SFX script (`sfx/sfx_script.txt`):

```
Setup=CustomerFWU2Point5.exe
TempMode
Silent=1
```

So the stub silently extracts the 55 entries below to a temporary folder, runs `CustomerFWU2Point5.exe`, and deletes the
folder when it exits. `sfx/stub/` holds the Ghidra decompilation of the stub (1,409 functions). It is RARLAB's stock
SFX module and contains no Razer logic.

## Archive contents

| File | Size | Type | Version | Signer | SHA-256 |
|---|---:|---|---|---|---|
| `AccountManagerClient.dll` | 87,432 | .NET x86 | 7.2.86.3428 | Razer USA Ltd. | `2cd0f79eb0336567430694378719f14e0592c0a220d33255f231a8eeb1e3b2f1` |
| `AccountManagerCommon.dll` | 149,384 | .NET x86 | 7.2.86.3428 | Razer USA Ltd. | `a3abce1cf68f068df4987d9afcfa66135df19ab5579abf1959df4ec2e5408b74` |
| `ActionServiceCommon.dll` | 104,824 | .NET x86 | 7.2.86.3428 | Razer USA Ltd. | `3a6771f7184886605d49e9f2919ccdc9e1262d9bb4cf47710eea9497942fd7d9` |
| `CustomProgressBar.dll` | 10,752 | .NET x86 | 1.0.1.0 | unsigned | `5b5f6e2f139e4d484e0ade33630af6c123246646ee526c5d58549ce72f77fe19` |
| `CustomerFWU2Point5.exe` | 13,321,992 | .NET x86 | 1.0.2.17732 | Razer USA Ltd. | `5675cc57d5b6cd0c60bb18c467a5bc5ef4b4750b7b79b8eac6f9a92151de56c7` |
| `DeviceUpdater.resources` | 330,006 |  |  |  | `375d1457b1f78f62524efc9c46e8288065eb57ce1e830c6fb76d1c1c6cddda54` |
| `FWUpdaterDLL.dll` | 1,940,480 | native x86 | 1.0.0.21 | unsigned | `7dccfd96b16bc5ff172087487a8c724ef597b812a22b94651179f988c40bdb50` |
| `RcClientBase.dll` | 21,880 | .NET x86 | 7.2.86.3428 | Razer USA Ltd. | `a194735a2ae6a76df56236ace5d316734a632f7caaf47932ce37ca760603d177` |
| `log4net.dll` | 277,872 | .NET x86 | 1.2.10.0 | Razer USA Ltd. | `a82fb12ab0def7ef608ebbd60d552bc571379f4acf820db9968d767fe690f087` |
| `winusb.dll` | 24,136 | native x86 | 6.0.6000.16386 (vista_rtm.061101-2205) | Microsoft | `e31ce32dd66ef9e2ecc4ec4e5e94a5bb50ebbd4fa7fb698d754d057a245f8a6a` |
| `BootLoader/Win10/amd64/DPInst_amd64.exe` | 1,047,632 | native x64 | 2.1 | Microsoft | `c20a5d3f5be543a8e73cd25f9dbf14aa0fc4ba1fdc249ee4ff91d159d174d0ea` |
| `BootLoader/Win10/amd64/WdfCoInstaller01009.dll` | 1,730,320 | native x64 | 1.9.7600.16385 (win7_rtm.090713-1255) | Microsoft | `89a0ffadb3d6deb3bbf9a7bec754f0f3b492b63e94a705a428a50bcb652c8fb0` |
| `BootLoader/Win10/amd64/WinUSBCoInstaller.dll` | 716,920 | native x64 | 6.0.5841.16388 (winmain(wmbla).060817-1752) | Microsoft | `b6c6274a0939e2cfc09f18a2b66681d2c2079c4470c157861716a165b0bb6703` |
| `BootLoader/Win10/amd64/rzrbtldr.inf` | 2,497 |  |  |  | `5dc6b7136c5004d4fa6365259a7493bb01f139d46c3bdd0bd1b41f8a12e8eac0` |
| `BootLoader/Win10/amd64/rzrbtldr_64.cat` | 44,510 |  |  |  | `6a61c29c5bb82743ac75a156f1343328f4d106a2b286ce523341a05ba2a3401c` |
| `BootLoader/Win10/i386/DPInst_x86.exe` | 922,176 | native x86 | 2.1 | Microsoft | `4478f6fcfd2fc9be012668592bfbf6838a115d983f9d30171669b20cafe529b9` |
| `BootLoader/Win10/i386/WdfCoInstaller01009.dll` | 1,470,744 | native x86 | 1.9.7600.16385 (win7_rtm.090713-1255) | Microsoft | `1dcc317257fba275f5884a701848a061c13348a670d43bcbc24228bcc529e358` |
| `BootLoader/Win10/i386/WinUSBCoInstaller.dll` | 589,936 | native x86 | 6.0.5841.16388 (winmain(wmbla).061102-0655) | Microsoft | `e86ca60177956526531313bdd9f5f9957739b0268c60dc9d60d7c9fe96d8b057` |
| `BootLoader/Win10/i386/rzrbtldr.cat` | 44,392 |  |  |  | `7b1568f8d149a5a0e09c28ac136c7a0e51dc7acb1561ba862c0ccd41c259ae77` |
| `BootLoader/Win10/i386/rzrbtldr.inf` | 2,497 |  |  |  | `5dc6b7136c5004d4fa6365259a7493bb01f139d46c3bdd0bd1b41f8a12e8eac0` |
| `BootLoader/Win81below/amd64/DPInst_amd64.exe` | 1,047,632 | native x64 | 2.1 | Microsoft | `c20a5d3f5be543a8e73cd25f9dbf14aa0fc4ba1fdc249ee4ff91d159d174d0ea` |
| `BootLoader/Win81below/amd64/WdfCoInstaller01009.dll` | 1,730,328 | native x64 | 1.9.7600.16385 (win7_rtm.090713-1255) | Microsoft | `a5d39be9c9f2b3d6c7ea1910792e5447131c141c7d8f4b49f0a33c72c03f2970` |
| `BootLoader/Win81below/amd64/WinUSBCoInstaller.dll` | 716,920 | native x64 | 6.0.5841.16388 (winmain(wmbla).060817-1752) | Microsoft | `cc9a7976dc27a76dbd3ffb26bf0a3e9fcac3c796872bbfc96dae249cd25f03b5` |
| `BootLoader/Win81below/amd64/rzrbtldr.inf` | 2,497 |  |  |  | `b7efd9d4aefbd0d0cceb384b322dedfe2c87379efac8c8684ec983ad8d88c93e` |
| `BootLoader/Win81below/amd64/rzrbtldr_64.cat` | 42,645 |  |  |  | `a8e26fa99486de90100a2708d5fba9da88f29e3ef0deb56b6f820c49f27af9bc` |
| `BootLoader/Win81below/i386/DPInst_x86.exe` | 922,176 | native x86 | 2.1 | Microsoft | `4478f6fcfd2fc9be012668592bfbf6838a115d983f9d30171669b20cafe529b9` |
| `BootLoader/Win81below/i386/WdfCoInstaller01009.dll` | 1,470,744 | native x86 | 1.9.7600.16385 (win7_rtm.090713-1255) | Microsoft | `0f1f5c1b8969e648822e41b3811a6db35529e22e0e172c1a2670b9e296a6b41d` |
| `BootLoader/Win81below/i386/WinUSBCoInstaller.dll` | 589,944 | native x86 | 6.0.5841.16388 (winmain(wmbla).061102-0655) | Microsoft | `cc3faf5235dc3b760235eb201a88b4d1a86bd9763f523e26b484c1b3bae30a91` |
| `BootLoader/Win81below/i386/rzrbtldr.cat` | 42,528 |  |  |  | `ced4d01a9c8b389eafea581ed8650f20e4838fdce8775c5426388e8371c5bfe8` |
| `BootLoader/Win81below/i386/rzrbtldr.inf` | 2,497 |  |  |  | `b7efd9d4aefbd0d0cceb384b322dedfe2c87379efac8c8684ec983ad8d88c93e` |
| `de-DE/CustomerFWU2Point5.resources.dll` | 11,776 | .NET x86 | 1.0.2.17732 | unsigned | `ffafdf23377e9832b8f6c2b2551a40d298f89a501767ee3270493dcb71eb6ed7` |
| `es-ES/CustomerFWU2Point5.resources.dll` | 11,776 | .NET x86 | 1.0.2.17732 | unsigned | `66ead10fadb8ccb11c7b7358a90a925f89d7b429ad73b26263c973bb172c195b` |
| `fr-FR/CustomerFWU2Point5.resources.dll` | 12,288 | .NET x86 | 1.0.2.17732 | unsigned | `9c0bc33008bd4cff195c4262d82cffa39f4a1738e9e33258de2b0ea33ad8a1be` |
| `ja-JP/CustomerFWU2Point5.resources.dll` | 13,312 | .NET x86 | 1.0.2.17732 | unsigned | `bcd493c3099462fcdd8f64c45ac9a06cc133f645b0632725224a726747c9f0f1` |
| `ko-KR/CustomerFWU2Point5.resources.dll` | 12,288 | .NET x86 | 1.0.2.17732 | unsigned | `b057c42ac5653b24ffacc48186a7be9d18009b96011703787d55f0364c47430a` |
| `pt-BR/CustomerFWU2Point5.resources.dll` | 11,264 | .NET x86 | 1.0.2.17732 | unsigned | `fcc1136be8b6d99b816010aee83a7327d7831ca147081f5710ee3ddfd2b0a3ae` |
| `ru-RU/CustomerFWU2Point5.resources.dll` | 14,848 | .NET x86 | 1.0.2.17732 | unsigned | `8c310a96ae2de027e2cc69f047e2e9c8831e915b72dda4d9d4fde917ade1c9fe` |
| `zh-CHT/CustomerFWU2Point5.resources.dll` | 10,752 | .NET x86 | 1.0.2.17732 | unsigned | `273b5fdf28cb279c677905925318a9c639b70d7cd896cd78e39ecb4576ef075d` |
| `zh-CN/CustomerFWU2Point5.resources.dll` | 10,752 | .NET x86 | 1.0.2.17732 | unsigned | `c50c28517a2fdb60bb2392447186d1db453793acabb172830cff6fae7c782781` |

## What was done with each component

| Component | Origin | Treatment |
|---|---|---|
| `CustomerFWU2Point5.exe` + 9 satellite `*.resources.dll` | Razer | ILSpy → `dotnet/CustomerFWU2Point5/`. Resources extracted to `resources/dotnet/` |
| `RcClientBase`, `ActionServiceCommon`, `AccountManagerCommon`, `AccountManagerClient`, `CustomProgressBar` | Razer | ILSpy → `dotnet/<name>/`. SmartAssembly string encoding removed first (see updater-app.md) |
| `DeviceUpdater.resources` | Razer | decoded → `resources/DeviceUpdater/config.tsv`. Firmware → `firmware/` |
| firmware image inside `DeviceUpdater.resources` | Razer | Intel HEX/BIN rebuilt, Ghidra → `firmware/decompiled/` |
| `FWUpdaterDLL.dll` | Razer | Ghidra → `native/FWUpdaterDLL/` |
| `BootLoader/*/rzrbtldr.inf` | Razer | copied to `drivers/`. WinUSB INF for the **older** `1532:110D` bootloader. Not used by the Basilisk V3 (BL 2.0 = HID, `1532:110E`) |
| `BootLoader/*/rzrbtldr*.cat` | Razer/Microsoft | driver catalog signatures, not decompiled |
| `log4net.dll` 1.2.10 | Apache (re-signed by Razer) | not decompiled: open source, referenced from NuGet in the rebuilt projects |
| `winusb.dll`, `DPInst_*.exe`, `WdfCoInstaller01009.dll`, `WinUSBCoInstaller.dll` | Microsoft redistributables | not decompiled. Signed Microsoft WDK binaries, listed above with hashes |
| SFX stub | RARLAB | Ghidra → `sfx/stub/` |

`DriverVer` differs only in the last digit between the `Win10` and `Win81below` INF variants (`…16385` vs `…16384`).
