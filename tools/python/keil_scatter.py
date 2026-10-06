"""Replay the ARM/Keil scatter-load step of a Cortex-M image: walk Region$$Table, run __decompress1
(LZ77 + zero-run, as implemented at the routine referenced by the table) or zero-init, and write the
resulting RAM image. Usage: keil_scatter.py image.bin load_base table_start table_end decompress_fn zeroinit_fn out.bin"""
import struct, sys
img = open(sys.argv[1], 'rb').read()
base, t0, t1, fn_dec, fn_zero = (int(x, 0) for x in sys.argv[2:7])
out = sys.argv[7]

def decompress1(src, n):
    """Byte-exact port of the image's __decompress routine."""
    o = bytearray()
    while len(o) < n:
        tok = img[src]; src += 1
        lit = tok & 7
        if lit == 0: lit = img[src]; src += 1
        run = tok >> 4
        if run == 0: run = img[src]; src += 1
        for _ in range(lit - 1): o.append(img[src]); src += 1
        if tok & 8:
            off = img[src]; src += 1
            for _ in range(run + 2): o.append(o[-off])
        else:
            o.extend(b'\0' * run)
    return bytes(o[:n]), src

ram = {}
lo = None
report = []
for a in range(t0, t1, 16):
    s, d, n, f = struct.unpack_from('<4I', img, a - base)
    if f == fn_dec:
        data, end = decompress1(s - base, n)
        report.append(f'0x{d:08X} len 0x{n:X}: decompress from 0x{s:08X} (packed {end - (s - base)} bytes)')
    elif f == fn_zero:
        data = b'\0' * n
        report.append(f'0x{d:08X} len 0x{n:X}: zero-init')
    else:
        raise SystemExit(f'unknown region handler 0x{f:08X}')
    ram[d] = data
start = min(ram); end = max(k + len(v) for k, v in ram.items())
buf = bytearray(end - start)
for k, v in ram.items(): buf[k - start:k - start + len(v)] = v
open(out, 'wb').write(buf)
print(f'RAM image 0x{start:08X}-0x{end:08X} -> {out}')
print('\n'.join(report))
