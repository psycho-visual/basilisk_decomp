# Tools

Everything in the repository was produced by these scripts. `decompile.sh` runs the whole pipeline end to end.

| Path | What it does |
|---|---|
| `decompile.sh` | Full pipeline: unrar → resources → firmware → .NET (deobfuscate + ILSpy) → Ghidra (DLL, firmware, SFX stub) |
| `ghidra/ExportDecomp.java` | Headless post-script. Decompiles every function into one `.c`, and writes `.h` (data types), `.functions.tsv`, `.symbols.txt` (exports/imports), `.strings.tsv` |
| `ghidra/CortexMSetup.java` | Headless pre-script for a raw Cortex-M image. Adds SRAM (optionally initialised from a RAM image), peripheral, and SCS blocks, makes flash read-only so literal pools fold to constants, walks the vector table, and names/creates handlers |
| `ghidra/ApplySymbols.java` | Applies a `kind/address/name/comment` TSV (`firmware/symbols.tsv`, `native/symbols.tsv`) and defines `razer_report_t` |
| `python/hex_from_res.py` | Rebuilds the Intel HEX stored as `DevFWLine*` strings, validates checksums, emits `.hex/.bin/.map.txt` |
| `python/keil_scatter.py` | Replays Keil `__scatterload` (incl. `__decompress1`) to recover initial RAM contents |
| `python/extract_range.py` | Cuts an address range of functions out of an `ExportDecomp` listing (`FWUpdaterDLL_razer.c`) |
| `python/make_buildable.py` | Rewrites ILSpy `.csproj` files: project references between the decompiled assemblies, NuGet for log4net/Newtonsoft.Json, no machine paths |
| `python/sigs.py` | Lists Authenticode signer CNs of PE files (needs `openssl`) |
| `python/xref.py` | Quick "which decompiled functions mention X" grep over a listing |
| `dotnet/resdump` | Dumps a binary `.resources` file (`DeviceUpdater.resources`) to TSV + blobs |
| `dotnet/asmres` | Extracts manifest resources from an assembly and explodes `.resources` (strings → TSV, images → PNG/ICO) |
| `dotnet/asmrefs` | Prints assembly references and target framework |
| `dotnet/sastrings` | Static SmartAssembly string-encoding remover (Mono.Cecil). Decodes the `{guid}` string blob (DES + deflate), replaces `GetString` proxy calls with literals, and strips the SmartAssembly runtime. No code from the target is executed |

## Building the decompiled C#

```
cd dotnet
dotnet build BasiliskV3FirmwareUpdater.sln -c Release
```

This works on Linux, macOS, and Windows with the .NET 8 SDK. `Directory.Build.props` pulls the .NET Framework reference
assemblies from NuGet. `CustomerFWU2Point5` is retargeted from net45 to net462 because the SDK needs
`System.Resources.Extensions` to embed its serialized WinForms resources. The output only runs on Windows, and it needs
the original `FWUpdaterDLL.dll`, `DeviceUpdater.resources`, and (for the old bootloaders) `BootLoader/` next to it.
