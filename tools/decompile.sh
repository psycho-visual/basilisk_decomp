#!/usr/bin/env bash
# Reproduce this repository's decompilation from the original updater.
#
#   tools/decompile.sh <BasiliskV3_..._FirmwareUpdater_v1.02.00_r1.exe> <work-dir>
#
# Requirements (versions used): unrar 7.00, Ghidra 11.4.2 (GHIDRA_HOME), JDK 21, .NET SDK 8,
# ilspycmd 9.1.0.7988 (dotnet tool), python3 + pefile.
# Outputs are written into <work-dir>; copy them over the repo directories to refresh.
set -euo pipefail
IN=$(realpath "$1"); W=$(realpath -m "$2"); REPO=$(cd "$(dirname "$0")/.." && pwd)
: "${GHIDRA_HOME:?set GHIDRA_HOME to the Ghidra install dir}"
ILSPY=${ILSPY:-ilspycmd}
REFASM=${REFASM:-$HOME/.nuget/packages/microsoft.netframework.referenceassemblies.net45/1.0.3/build/.NETFramework/v4.5}
mkdir -p "$W"/{sfx,tools,devres,fw,res,dotnet,clean,ghidra}

echo "== 1. unpack the WinRAR SFX"
(cd "$W/sfx" && unrar x -o+ -inul "$IN")
head -c $((0x62800)) "$IN" > "$W/sfx_stub.exe"

echo "== 2. build helper tools"
for t in resdump asmres sastrings; do
  dotnet build -c Release -o "$W/tools/$t" "$REPO/tools/dotnet/$t/$t.csproj" >/dev/null
done

echo "== 3. DeviceUpdater.resources -> config + firmware HEX/BIN + scatter-loaded RAM image"
dotnet "$W/tools/resdump/resdump.dll" "$W/sfx/DeviceUpdater.resources" "$W/devres"
python3 -I "$REPO/tools/python/hex_from_res.py" "$W/devres/entries.tsv" "$W/fw" DevFW BasiliskV3_FW_v1.02.00
python3 -I "$REPO/tools/python/keil_scatter.py" "$W/fw/BasiliskV3_FW_v1.02.00.bin" 0x20000000 \
  0x2000F468 0x2000F488 0x20000378 0x2000521C "$W/fw/BasiliskV3_FW_v1.02.00.ram_init.bin"

echo "== 4. .NET: strip SmartAssembly string encoding, then ILSpy"
cp "$W"/sfx/*.dll "$W"/sfx/*.exe "$W/clean/"
for a in AccountManagerClient AccountManagerCommon ActionServiceCommon; do
  dotnet "$W/tools/sastrings/sastrings.dll" "$W/sfx/$a.dll" "$W/clean/$a.dll"
done
for a in CustomerFWU2Point5.exe RcClientBase.dll AccountManagerClient.dll AccountManagerCommon.dll \
         ActionServiceCommon.dll CustomProgressBar.dll; do
  "$ILSPY" -p -o "$W/dotnet/${a%.*}" -r "$W/clean" -r "$REFASM" -r "$REFASM/Facades" \
           --nested-directories -lv CSharp7_3 "$W/clean/$a"
done
cp "$REPO/dotnet/Directory.Build.props" "$W/dotnet/"
python3 -I "$REPO/tools/python/make_buildable.py" "$W/dotnet"
for a in "$W"/sfx/CustomerFWU2Point5.exe "$W"/sfx/*.dll "$W"/sfx/*/CustomerFWU2Point5.resources.dll; do
  n=$(realpath --relative-to="$W/sfx" "$a" | tr '/' '_'); n=${n%.*}
  dotnet "$W/tools/asmres/asmres.dll" "$a" "$W/res/$n" >/dev/null 2>&1 || true
done

echo "== 5. Ghidra: FWUpdaterDLL.dll, firmware, SFX stub"
GS="$REPO/tools/ghidra"; AH="$GHIDRA_HOME/support/analyzeHeadless"
"$AH" "$W/ghidra" FWU -import "$W/sfx/FWUpdaterDLL.dll" -overwrite -scriptPath "$GS" \
  -postScript ApplySymbols.java "$REPO/native/symbols.tsv" \
  -postScript ExportDecomp.java "$W/native"
"$AH" "$W/ghidra" FW -import "$W/fw/BasiliskV3_FW_v1.02.00.bin" -overwrite \
  -processor ARM:LE:32:Cortex -cspec default -loader BinaryLoader \
  -loader-baseAddr 0x20000000 -loader-blockName FLASH_IMAGE -scriptPath "$GS" \
  -preScript CortexMSetup.java 0x04000000 0x8000 32 0x200000C1 "$W/fw/BasiliskV3_FW_v1.02.00.ram_init.bin" \
  -postScript ApplySymbols.java "$REPO/firmware/symbols.tsv" \
  -postScript ExportDecomp.java "$W/firmware"
"$AH" "$W/ghidra" SFX -import "$W/sfx_stub.exe" -overwrite -scriptPath "$GS" \
  -postScript ExportDecomp.java "$W/sfx_stub"
python3 -I "$REPO/tools/python/extract_range.py" "$W/native/FWUpdaterDLL.dll.c" 10002500 10005b00 \
  "$W/native/FWUpdaterDLL_razer.c" "FWUpdaterDLL.dll - Razer-authored functions only (0x10002500-0x10005AFF)"
echo "done -> $W"
