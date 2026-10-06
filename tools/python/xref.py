"""List which decompiled functions mention each literal string. usage: xref.py file.c needle [needle...]"""
import sys, re, collections
src = open(sys.argv[1], encoding='utf-8', errors='replace').read().split('\n')
fn = None
hits = collections.defaultdict(collections.Counter)
for line in src:
    m = re.match(r'^/\* (\S+) @ ([0-9a-f]+) \*/$', line)
    if m: fn = m.group(1); continue
    for n in sys.argv[2:]:
        if re.search(n, line): hits[n][fn] += 1
for n in sys.argv[2:]:
    print('==', n, dict(hits[n].most_common(12)))
