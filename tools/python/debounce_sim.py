#!/usr/bin/env python3
"""Cycle-level model of the Basilisk V3 v1.02.00 click debounce (FUN_2000b924 + FUN_200054e0).

Ported instruction by instruction from the firmware (see docs/click-debounce.md). Per button:

    flags  (0x04000A18 + 6*i)  bit0 = edge seen, bit1 = lockout active
    rep    (0x04000A19 + 6*i)  state last reported to the host (1 = pressed)
    cnt    (0x04000A1A + 6*i)  lockout / pending counter
    dis    (0x04000A1B + 6*i)  consecutive ms the switch disagreed with `rep` during a lockout
    lifted (0x04000A1D + 6*i)  "slow path" marker, set while the sensor reports lift

Timing inside one 1 ms USB frame (SOF at t=0, CTIMER1 split into 20 x 50 us phases):

    t = 0        SOF IRQ: tick()            (uses the raw bitmap saved by the last scan)
    t = 700 us   phase 13: scan() enabled, main loop calls it repeatedly until ...
    t = 850 us   phase 16: scan() disabled
    t = 900 us   phase 17: HID input report built from `rep`

Usage:
    debounce_sim.py                    # sweep 1..80 ms clicks with factory settings 8/28/8/28
    debounce_sim.py --sweep 0.5 60 0.5 --params 8 28 8 28
    debounce_sim.py --clicks 0:10 40:10 # press@0ms for 10ms, press@40ms for 10ms
"""
import argparse

# the main loop calls the scan many times inside the 700..850 us window; model it as every 5 us
SCAN_TIMES = tuple(0.70 + i * 0.005 for i in range(30))
REPORT_TIME = 0.90


class Button:
    def __init__(self):
        self.flags = 0
        self.rep = 0
        self.cnt = 0
        self.dis = 0
        self.lifted = 0


class Debounce:
    """One primary button (index 0 or 1, which gets the immediate-press fast path)."""

    def __init__(self, d68=8, d69=28, d6a=8, d6b=28, primary=True):
        self.d68, self.d69, self.d6a, self.d6b = d68, d69, d6a, d6b
        self.primary = primary
        self.b = Button()
        self.raw = 1             # 0x04000330 bit: GPIO, active low (1 = released)
        self.was_lifted = 0      # 0x0400032D
        self.events = []         # (time_ms, 'press'|'release')

    # FUN_200054e0, called from the USB SOF interrupt (FUN_20001ef0) once per 1 ms frame
    def tick(self):
        b, raw = self.b, self.raw
        if (b.flags & 2) and b.cnt != 0:
            if b.rep == raw:          # switch disagrees with reported state (active low)
                b.dis = (b.dis + 1) & 0xFF
            else:                     # switch agrees with reported state
                b.cnt = (b.cnt - 1) & 0xFF
        elif raw == 0:                # physically pressed
            if b.rep != 1 and (b.flags & 1):
                b.cnt = (b.cnt + 1) & 0xFF
        else:                         # physically released
            if b.rep != 0 and not (b.flags & 1):
                b.cnt = (b.cnt + 1) & 0xFF

    # FUN_2000b924, called from periodic_tasks() while bit 2 of 0x04000D65 is set
    def scan(self, t, pressed, lifted=0):
        b = self.b
        press_lock, release_lock = self.d69, self.d6b
        if lifted:
            press_lock = (self.d69 - self.d68) & 0xFF
            release_lock = (self.d6b - self.d6a) & 0xFF
            b.lifted = 1
            self.was_lifted = 1
        elif self.was_lifted:
            b.flags |= 2
            b.cnt = release_lock
            b.lifted = 0
            self.was_lifted = 0
        if press_lock > 30:
            press_lock = 28
        if release_lock > 30:
            release_lock = 28

        raw = 0 if pressed else 1
        self.raw = raw

        if b.flags & 2:
            if b.cnt != 0:
                if b.rep == raw:              # disagree
                    if b.dis >= press_lock:   # firmware compares against d69 for both edges
                        b.flags &= ~2
                else:                         # agree
                    b.dis = 0
                return
            b.flags &= ~2

        if raw == 0:  # pressed
            if b.rep == 1:
                b.cnt = 0
                return
            if not (b.flags & 1):
                b.flags |= 1
                b.cnt = 1
                if b.lifted != 0 or not self.primary:
                    return
                self._commit_press(t, press_lock)
                return
            thr = self.d68 if b.lifted == 1 else 0
            if b.cnt > thr:
                self._commit_press(t, press_lock)
        else:         # released
            if b.rep == 0:
                b.cnt = 0
                return
            if b.flags & 1:
                b.flags = 0
                b.cnt = 1
                return
            thr = self.d6a if b.lifted == 1 else 0
            if b.cnt > thr:
                self.events.append((t, 'release'))
                b.rep = 0
                b.flags |= 2
                b.cnt = release_lock
                b.lifted = 0

    def _commit_press(self, t, press_lock):
        b = self.b
        self.events.append((t, 'press'))
        b.rep = 1
        b.flags |= 2
        b.cnt = press_lock
        b.lifted = 0


def run(clicks, params, frames=None, lifted=0, phase=0.0):
    """clicks: list of (press_time_ms, duration_ms). Returns list of (frame, rep) host reports."""
    d = Debounce(*params)
    end = max(p + l for p, l in clicks) + 200 if frames is None else frames
    reports = []

    def pressed_at(t):
        return any(p + phase <= t < p + phase + l for p, l in clicks)

    for n in range(int(end)):
        d.tick()
        for s in SCAN_TIMES:
            d.scan(n + s, pressed_at(n + s), lifted)
        reports.append(d.b.rep)
    return reports, d.events


def reported_clicks(reports):
    out, start = [], None
    for n, r in enumerate(reports):
        if r and start is None:
            start = n
        elif not r and start is not None:
            out.append((start, n - start))
            start = None
    return out


def main():
    ap = argparse.ArgumentParser()
    ap.add_argument('--params', nargs=4, type=int, default=[8, 28, 8, 28],
                    metavar=('D68', 'D69', 'D6A', 'D6B'), help='02/02 args (factory 8 28 8 28)')
    ap.add_argument('--sweep', nargs=3, type=float, metavar=('FROM', 'TO', 'STEP'))
    ap.add_argument('--clicks', nargs='+', help='press:duration pairs in ms')
    ap.add_argument('--lifted', action='store_true', help='sensor reports lift (slow path)')
    ap.add_argument('--csv', action='store_true')
    a = ap.parse_args()

    if a.clicks:
        clicks = [tuple(float(x) for x in c.split(':')) for c in a.clicks]
        reports, _ = run(clicks, a.params, lifted=int(a.lifted))
        for p, l in clicks:
            print(f'physical press @{p:7.2f} ms  held {l:6.2f} ms')
        for s, l in reported_clicks(reports):
            print(f'reported press @frame {s:4d}  held {l:3d} ms')
        return

    lo, hi, st = a.sweep if a.sweep else (1, 80, 1)
    if a.csv:
        print('physical_ms,reported_min_ms,reported_max_ms')
    else:
        print(f'params d68..d6b = {a.params}' + ('  (lifted)' if a.lifted else ''))
        print(' physical  reported (min..max over sub-ms press phase)')
    x = lo
    while x <= hi + 1e-9:
        got = []
        for k in range(20):  # press phase within the frame, 50 us steps
            reports, _ = run([(10.0, x)], a.params, lifted=int(a.lifted), phase=k / 20)
            rc = reported_clicks(reports)
            got.append(rc[0][1] if rc else 0)
        if a.csv:
            print(f'{x:g},{min(got)},{max(got)}')
        else:
            print(f'{x:8.2f}  {min(got):3d}..{max(got):3d}')
        x += st


if __name__ == '__main__':
    main()
