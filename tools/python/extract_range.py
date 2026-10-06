"""Pull the functions whose entry point lies in [lo, hi) out of an ExportDecomp.java C file.
usage: extract_range.py full.c lo hi out.c "banner text" """
import re, sys
src, lo, hi, out, banner = sys.argv[1], int(sys.argv[2], 16), int(sys.argv[3], 16), sys.argv[4], sys.argv[5]
text = open(src, encoding='utf-8', errors='replace').read()
sep = '/* ---------------------------------------------------------------------- */\n'
head, *chunks = text.split(sep)
keep = []
for c in chunks:
    m = re.match(r'/\* (\S+) @ ([0-9a-f]+) \*/', c)
    if m and lo <= int(m.group(2), 16) < hi:
        keep.append(c)
with open(out, 'w', encoding='utf-8') as f:
    f.write('/*\n * ' + banner.replace('\n', '\n * ') + '\n */\n\n')
    f.write(re.sub(r'#include "[^"]+"', '#include "FWUpdaterDLL.dll.h"', head.split('*/', 1)[1].strip()) + '\n\n')
    f.write(sep.join([''] + keep))
print(f'{len(keep)} functions -> {out}')
