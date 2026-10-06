"""Read or change the Basilisk V3 (1532:0099, firmware v1.02.00) button debounce timings over USB, using the
firmware's own commands: 02/82 reads them, 02/02 writes them, and the mouse saves them to flash itself.
Needs `pip install hidapi`. Quit Razer Synapse first.

  basilisk_debounce.py                      show the current timings
  basilisk_debounce.py set --lockout 10     press and release lockout -> 10 ms, everything else unchanged
  basilisk_debounce.py restore              back to the factory 8/28/8/28
  basilisk_debounce.py --list               list the mouse's HID interfaces (troubleshooting)

Where the numbers come from (firmware/decompiled/BasiliskV3_FW_v1.02.00.c):
  4 bytes at 0x04000D68: press confirm, press lockout, release confirm, release lockout (ms).
  The lockouts are what FUN_2000b924 uses on the desk; values above 30 are treated as 28.
  The confirm delays only apply while the mouse is lifted, where the lockout becomes lockout - confirm.
  02/02 calls settings_mark_dirty(2), which writes the block to flash 0x28100 about 100 ms later.
  The 90-byte feature report lives on interface 3 (HID handler at 0x200036CC, report descriptor at 0x2000EA01).

Linux needs access to /dev/hidraw*: run with sudo, or add /etc/udev/rules.d/70-basilisk-v3.rules containing
  SUBSYSTEM=="hidraw", ATTRS{idVendor}=="1532", ATTRS{idProduct}=="0099", TAG+="uaccess"
and replug the mouse.
"""
import argparse, sys, time

try:
    import hid
except ImportError:
    sys.exit('Python package "hidapi" is missing: pip install hidapi')
if not hasattr(hid, 'device'):
    sys.exit('This is the "hid" package, not "hidapi": pip uninstall hid && pip install hidapi')

VID, PID = 0x1532, 0x0099
IFACE = 3                  # the firmware only answers the 90-byte feature report on interface 3
LEN = 90                   # payload; 91 bytes on the wire with report ID 0
TXN = 0x3F                 # the firmware ignores it, we use it to recognise our own reply
FACTORY = (8, 28, 8, 28)   # defaults table at 0x2000EA9A
NAMES = ('press confirm (lifted only)', 'press lockout', 'release confirm (lifted only)', 'release lockout')
STATUS = {0: 'new', 1: 'busy', 2: 'ok', 3: 'CRC error', 4: 'timeout', 5: 'not supported'}


class DeviceError(Exception):
    pass


def xor(data):
    c = 0
    for b in data:
        c ^= b
    return c


def build(cls, cmd, args=b''):
    """90-byte Razer report: status, txn, remaining(2), protocol, size, class, id, args[80], crc, reserved."""
    r = bytearray(LEN)
    r[1], r[5], r[6], r[7] = TXN, len(args) or 4, cls, cmd
    r[8:8 + len(args)] = args
    r[88] = xor(r[2:88])
    return bytes(r)


def transact(dev, cls, cmd, args=b''):
    """Same pattern as the updater's razer_feature_transact: set, then poll get until our echo shows status OK."""
    req = build(cls, cmd, args)
    for _ in range(3):
        try:
            sent = dev.send_feature_report(b'\0' + req)
        except OSError:
            sent = -1
        if sent < 0:
            time.sleep(0.02)
            continue
        for _ in range(10):
            time.sleep(0.02)
            try:
                raw = bytes(dev.get_feature_report(0, LEN + 1))
            except OSError:
                continue
            rsp = raw[1:LEN + 1] if len(raw) > LEN else raw
            # Not our echo yet: the firmware drops a new command while it is still busy with the last one.
            if len(rsp) != LEN or (rsp[1], rsp[6], rsp[7]) != (TXN, cls, cmd) or rsp[0] in (0, 1):
                continue
            if rsp[0] != 2:
                raise DeviceError(f'command {cls:02X}/{cmd:02X}: the mouse answered status 0x{rsp[0]:02X} '
                                  f'({STATUS.get(rsp[0], "unknown")})')
            if xor(rsp[2:89]) == 0:
                return rsp
    raise DeviceError(f'no reply to command {cls:02X}/{cmd:02X}. Quit Razer Synapse and try again')


def read_timings(dev):
    return tuple(transact(dev, 0x02, 0x82)[8:12])


def open_mouse():
    found = hid.enumerate(VID, PID)
    if not found:
        raise DeviceError('no Basilisk V3 (1532:0099) found. Is it plugged in, and not in bootloader mode?')
    cands = [d for d in found if d['interface_number'] == IFACE] or found
    # Windows lists one entry per top-level collection; the report sits in Consumer Control (0x0C/0x01).
    cands.sort(key=lambda d: (d['usage_page'], d['usage']) != (0x0C, 0x01))
    errors, open_failed = [], False
    for d in cands:
        dev = hid.device()
        try:
            dev.open_path(d['path'])
        except OSError as e:
            errors.append(f'{d["path"]!r}: could not open ({e})')
            open_failed = True
            continue
        try:
            return dev, read_timings(dev)
        except DeviceError as e:
            errors.append(f'{d["path"]!r}: {e}')
            dev.close()
    hint = ''
    if open_failed and sys.platform.startswith('linux'):
        hint = '\nOn Linux, run with sudo or add a udev rule for 1532:0099 (see the comment at the top).'
    raise DeviceError('could not talk to the mouse:\n  ' + '\n  '.join(errors) + hint)


def effective(lockout, confirm=0):
    v = (lockout - confirm) & 0xFF
    return 28 if v > 30 else v


def show(vals, title):
    pc, pl, rc, rl = vals
    print(title)
    for name, v in zip(NAMES, vals):
        print(f'  {name:31s}{v:4d} ms')
    print(f'  -> lockout on the desk: press {effective(pl)} ms, release {effective(rl)} ms; '
          f'when lifted: press {effective(pl, pc)} ms, release {effective(rl, rc)} ms')


def lockout_ms(s):
    v = int(s)
    if not 1 <= v <= 30:
        raise argparse.ArgumentTypeError('must be 1-30 ms (the firmware treats anything above 30 as 28)')
    return v


def main():
    ap = argparse.ArgumentParser(description=__doc__.split('\n\n')[0])
    ap.add_argument('--list', action='store_true', help="list the mouse's HID interfaces and exit")
    sub = ap.add_subparsers(dest='action')
    s = sub.add_parser('set', help='change the lockout, keeping everything else')
    s.add_argument('--lockout', type=lockout_ms, help='press and release lockout (ms)')
    s.add_argument('--press-lockout', type=lockout_ms)
    s.add_argument('--release-lockout', type=lockout_ms)
    s.add_argument('--dry-run', action='store_true', help='show the command without sending it')
    r = sub.add_parser('restore', help='factory timings 8/28/8/28')
    r.add_argument('--dry-run', action='store_true', help='show the command without sending it')
    a = ap.parse_args()

    if a.list:
        for d in hid.enumerate(VID, PID):
            print(f'interface {d["interface_number"]}  usage {d["usage_page"]:04X}:{d["usage"]:04X}  {d["path"]!r}')
        return 0
    if a.action == 'set' and a.lockout is None and a.press_lockout is None and a.release_lockout is None:
        ap.error('set needs --lockout, --press-lockout or --release-lockout')

    try:
        dev, cur = open_mouse()
    except DeviceError as e:
        print(e, file=sys.stderr)
        return 1
    try:
        show(cur, 'Current timings:')
        if a.action is None:
            return 0
        if a.action == 'restore':
            new = FACTORY
        else:
            pl = a.press_lockout if a.press_lockout is not None else a.lockout
            rl = a.release_lockout if a.release_lockout is not None else a.lockout
            new = (cur[0], cur[1] if pl is None else pl, cur[2], cur[3] if rl is None else rl)
        if new == cur:
            print('Nothing to change.')
            return 0
        for lock, conf, edge in ((new[1], new[0], 'press'), (new[3], new[2], 'release')):
            if lock <= conf:
                print(f'Note: {edge} lockout {lock} <= confirm {conf}, so the lifted-mode {edge} lockout becomes '
                      f'{effective(lock, conf)} ms.')
        print()
        show(new, 'New timings:')
        if a.dry_run:
            print('\nDry run, would send 02/02:', build(0x02, 0x02, bytes(new)).hex(' '))
            return 0
        transact(dev, 0x02, 0x02, bytes(new))
        back = read_timings(dev)
        if back != new:
            print(f'\nRead back {back}, expected {new}. Not changed as asked.', file=sys.stderr)
            return 1
        time.sleep(0.3)   # the firmware writes flash ~100 ms after the command
        print('\nDone. The mouse writes this to its own flash about 0.1 s after the command, so it should survive\n'
              'unplugging. To check, replug the mouse and run this script again with no arguments.')
        return 0
    except DeviceError as e:
        print(e, file=sys.stderr)
        return 1
    finally:
        dev.close()


if __name__ == '__main__':
    sys.exit(main())
