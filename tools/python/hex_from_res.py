"""Rebuild the Intel HEX firmware stored line-by-line in DeviceUpdater.resources (dumped entries.tsv),
validate every record checksum, and emit .hex + flat .bin + a segment map."""
import sys, os
tsv, outdir, prefix = sys.argv[1], sys.argv[2], sys.argv[3]   # prefix e.g. DevFW
rows = {}
num = None
for line in open(tsv, encoding='utf-8'):
    name, typ, val = line.rstrip('\n').split('\t', 2)
    if name == prefix + 'LineNum':
        num = int(val)
    elif name.startswith(prefix + 'Line'):
        rows[int(name[len(prefix) + 4:])] = val
assert num == len(rows), (num, len(rows))
lines = [rows[i] for i in range(num)]
os.makedirs(outdir, exist_ok=True)
base = 0
mem = {}
start = None
for ln in lines:
    assert ln[0] == ':'
    raw = bytes.fromhex(ln[1:])
    assert sum(raw) & 0xff == 0, 'checksum ' + ln
    cnt, addr, typ = raw[0], int.from_bytes(raw[1:3], 'big'), raw[3]
    data = raw[4:4 + cnt]
    if typ == 0:
        for i, b in enumerate(data): mem[base + addr + i] = b
    elif typ == 4: base = int.from_bytes(data, 'big') << 16
    elif typ == 2: base = int.from_bytes(data, 'big') << 4
    elif typ == 5: start = int.from_bytes(data, 'big')
    elif typ == 1: break
lo, hi = min(mem), max(mem) + 1
blob = bytes(mem.get(a, 0xff) for a in range(lo, hi))
name = os.path.join(outdir, sys.argv[4])
open(name + '.hex', 'w', newline='\r\n').write('\n'.join(lines) + '\n')
open(name + '.bin', 'wb').write(blob)
# segments
segs = []
a = lo
while a < hi:
    if a in mem:
        s = a
        while a < hi and a in mem: a += 1
        segs.append((s, a))
    else: a += 1
with open(name + '.map.txt', 'w') as f:
    f.write(f'records: {num}\nload range: 0x{lo:08X}-0x{hi:08X} ({hi-lo} bytes)\nstart linear address: ' + (f'0x{start:08X}' if start is not None else 'none') + '\n')
    for s, e in segs: f.write(f'segment 0x{s:08X}-0x{e:08X} len {e-s}\n')
print(open(name + '.map.txt').read())
