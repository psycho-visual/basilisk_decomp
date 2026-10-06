"""Print Authenticode signer subject/issuer for PE files (reads the WIN_CERTIFICATE blob, uses openssl)."""
import sys, subprocess, pefile, os, tempfile, re
for path in sys.argv[1:]:
    try:
        pe = pefile.PE(path, fast_load=True)
        sec = pe.OPTIONAL_HEADER.DATA_DIRECTORY[pefile.DIRECTORY_ENTRY['IMAGE_DIRECTORY_ENTRY_SECURITY']]
        if sec.VirtualAddress == 0:
            print(f'{path}\tunsigned'); continue
        raw = open(path, 'rb').read()[sec.VirtualAddress + 8: sec.VirtualAddress + sec.Size]
        with tempfile.NamedTemporaryFile(delete=False) as t: t.write(raw); tn = t.name
        out = subprocess.run(['openssl', 'pkcs7', '-inform', 'DER', '-in', tn, '-print_certs', '-noout'], capture_output=True, text=True).stdout
        os.unlink(tn)
        subs = re.findall(r'subject=(.*)', out)
        leaf = [s for s in subs if 'CN' in s and 'Root' not in s and 'CA' not in s.split('CN')[-1]]
        cn = [re.search(r'CN\s*=\s*([^,]+)', s).group(1) for s in subs if re.search(r'CN\s*=\s*([^,]+)', s)]
        print(f'{path}\tsigned\t' + ' | '.join(dict.fromkeys(cn)))
    except Exception as e:
        print(f'{path}\terror {e}')
