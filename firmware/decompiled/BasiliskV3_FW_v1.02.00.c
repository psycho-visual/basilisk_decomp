/*
 * Ghidra 11.4.2 decompilation of BasiliskV3_FW_v1.02.00.bin
 * Image base: 00000000  Language: ARM:LE:32:Cortex
 * Compiler: default
 */

#include "BasiliskV3_FW_v1.02.00.h"

/* ---------------------------------------------------------------------- */
/* __main @ 200000c0 */


/* WARNING: This function may have set the stack pointer */
/* Keil ARMCC entry: set SP, __scatterload, branch to main */

void __main(void)

{
  __scatterload();
  main();
  return;
}


/* ---------------------------------------------------------------------- */
/* Reset_Handler @ 200000d4 */


/* WARNING: This function may have set the stack pointer */

void Reset_Handler(void)

{
  SystemInit();
  __scatterload();
  main();
  return;
}


/* ---------------------------------------------------------------------- */
/* NMI_Handler @ 200000dc */


void NMI_Handler(void)

{
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* SVC_Handler @ 200000e0 */


void SVC_Handler(void)

{
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* PendSV_Handler @ 200000e2 */


void PendSV_Handler(void)

{
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* SysTick_Handler @ 200000e4 */


void SysTick_Handler(void)

{
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* IRQ15_Handler @ 20000122 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ15_Handler(void)

{
  uint uVar1;
  int iVar2;
  
  uVar1 = (uint)_DAT_31580000;
  if (DAT_0400315c != (code *)0x0) {
    (*DAT_0400315c)(&DAT_40087000,DAT_0400317c);
    return;
  }
  _DAT_31580000 = (undefined1 *)((uint)_DAT_31580000 & 0xffffff00);
  if (DAT_04003160 != (code *)0x0) {
    (*DAT_04003160)(&DAT_40088000,DAT_04003180);
    return;
  }
  _DAT_31580000 = (undefined1 *)(uVar1 & 0xffff0000);
  if (DAT_04003164 != (code *)0x0) {
    (*DAT_04003164)(&DAT_40089000,DAT_04003184);
    return;
  }
  if (DAT_04003168 == (code *)0x0) {
    if (DAT_0400316c != (code *)0x0) {
      (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
      return;
    }
    _DAT_31580000 = &DAT_31580000;
    if (DAT_04003170 == (code *)0x0) {
      _DAT_31580000 = &DAT_31580000;
      if (DAT_04003174 != (code *)0x0) {
        (*DAT_04003174)(&DAT_40098000,DAT_04003194);
        return;
      }
      _DAT_31580000 = &DAT_31580000;
      iVar2 = 0;
      do {
        if ((undefined1 *)(&DAT_2000f358)[iVar2] == &DAT_31580000) {
          return;
        }
        iVar2 = iVar2 + 1;
      } while (iVar2 < 8);
      return;
    }
    (*DAT_04003170)(&DAT_40097000,DAT_04003190);
    return;
  }
  (*DAT_04003168)(&DAT_4008a000,DAT_04003188);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ16_Handler @ 20000126 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ16_Handler(void)

{
  int iVar1;
  
  if (DAT_04003160 != (code *)0x0) {
    (*DAT_04003160)(&DAT_40088000,DAT_04003180);
    return;
  }
  _DAT_31580000 = (undefined1 *)((uint)_DAT_31580000 & 0xffff0000);
  if (DAT_04003164 != (code *)0x0) {
    (*DAT_04003164)(&DAT_40089000,DAT_04003184);
    return;
  }
  if (DAT_04003168 != (code *)0x0) {
    (*DAT_04003168)(&DAT_4008a000,DAT_04003188);
    return;
  }
  if (DAT_0400316c == (code *)0x0) {
    _DAT_31580000 = &DAT_31580000;
    if (DAT_04003170 != (code *)0x0) {
      (*DAT_04003170)(&DAT_40097000,DAT_04003190);
      return;
    }
    _DAT_31580000 = &DAT_31580000;
    if (DAT_04003174 == (code *)0x0) {
      _DAT_31580000 = &DAT_31580000;
      iVar1 = 0;
      do {
        if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
          return;
        }
        iVar1 = iVar1 + 1;
      } while (iVar1 < 8);
      return;
    }
    (*DAT_04003174)(&DAT_40098000,DAT_04003194);
    return;
  }
  (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ17_Handler @ 2000012a */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ17_Handler(void)

{
  int iVar1;
  
  if (DAT_04003164 != (code *)0x0) {
    (*DAT_04003164)(&DAT_40089000,DAT_04003184);
    return;
  }
  if (DAT_04003168 != (code *)0x0) {
    (*DAT_04003168)(&DAT_4008a000,DAT_04003188);
    return;
  }
  if (DAT_0400316c != (code *)0x0) {
    (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003170 == (code *)0x0) {
    _DAT_31580000 = &DAT_31580000;
    if (DAT_04003174 != (code *)0x0) {
      (*DAT_04003174)(&DAT_40098000,DAT_04003194);
      return;
    }
    _DAT_31580000 = &DAT_31580000;
    iVar1 = 0;
    do {
      if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
        return;
      }
      iVar1 = iVar1 + 1;
    } while (iVar1 < 8);
    return;
  }
  (*DAT_04003170)(&DAT_40097000,DAT_04003190);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ18_Handler @ 2000012e */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ18_Handler(void)

{
  int iVar1;
  
  if (DAT_04003168 != (code *)0x0) {
    (*DAT_04003168)(&DAT_4008a000,DAT_04003188);
    return;
  }
  if (DAT_0400316c != (code *)0x0) {
    (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003170 != (code *)0x0) {
    (*DAT_04003170)(&DAT_40097000,DAT_04003190);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003174 == (code *)0x0) {
    _DAT_31580000 = &DAT_31580000;
    iVar1 = 0;
    do {
      if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
        return;
      }
      iVar1 = iVar1 + 1;
    } while (iVar1 < 8);
    return;
  }
  (*DAT_04003174)(&DAT_40098000,DAT_04003194);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ19_Handler @ 20000132 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ19_Handler(void)

{
  int iVar1;
  
  if (DAT_0400316c != (code *)0x0) {
    (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003170 == (code *)0x0) {
    _DAT_31580000 = &DAT_31580000;
    if (DAT_04003174 != (code *)0x0) {
      (*DAT_04003174)(&DAT_40098000,DAT_04003194);
      return;
    }
    _DAT_31580000 = &DAT_31580000;
    iVar1 = 0;
    do {
      if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
        return;
      }
      iVar1 = iVar1 + 1;
    } while (iVar1 < 8);
    return;
  }
  (*DAT_04003170)(&DAT_40097000,DAT_04003190);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ20_Handler @ 20000136 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ20_Handler(void)

{
  int iVar1;
  
  if (DAT_04003170 != (code *)0x0) {
    (*DAT_04003170)(&DAT_40097000,DAT_04003190);
    return;
  }
  _DAT_31580000 = _DAT_31580000 & 0xff00;
  if (DAT_04003174 == (code *)0x0) {
    _DAT_31580000 = 0;
    iVar1 = 0;
    do {
      if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
        _DAT_31580000 = 0;
        return;
      }
      iVar1 = iVar1 + 1;
    } while (iVar1 < 8);
    return;
  }
  (*DAT_04003174)(&DAT_40098000,DAT_04003194);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ21_Handler @ 2000013a */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void IRQ21_Handler(void)

{
  int iVar1;
  
  if (DAT_04003174 != (code *)0x0) {
    (*DAT_04003174)(&DAT_40098000,DAT_04003194);
    return;
  }
  _DAT_31580000 = 0;
  iVar1 = 0;
  do {
    if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
      _DAT_31580000 = 0;
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 < 8);
  return;
}


/* ---------------------------------------------------------------------- */
/* __default_irq_spin @ 20000166 */


/* Unused IRQ trap (infinite loop) */

void __default_irq_spin(void)

{
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* __aeabi_uidiv @ 200001f0 */


/* unsigned 32-bit divide */

int __aeabi_uidiv(uint param_1,uint param_2)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  
  iVar1 = 0;
  uVar2 = 0x20;
  while (uVar3 = uVar2 - 1, 0 < (int)uVar2) {
    uVar2 = uVar3;
    if (param_2 <= param_1 >> (uVar3 & 0xff)) {
      param_1 = param_1 - (param_2 << (uVar3 & 0xff));
      iVar1 = iVar1 + (1 << (uVar3 & 0xff));
    }
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* __aeabi_idiv @ 2000021c */


/* signed 32-bit divide */

int __aeabi_idiv(int param_1,int param_2)

{
  int iVar1;
  bool bVar2;
  bool bVar3;
  
  bVar2 = param_1 < 0;
  if (bVar2) {
    param_1 = -param_1;
  }
  bVar3 = param_2 < 0;
  if (bVar3) {
    param_2 = -param_2;
  }
  iVar1 = __aeabi_uidiv(param_1,param_2);
  if (bVar2 != bVar3) {
    iVar1 = -iVar1;
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* __aeabi_uldivmod @ 20000244 */


/* unsigned 64-bit divide */

longlong __aeabi_uldivmod(uint param_1,int param_2,uint param_3,uint param_4)

{
  longlong lVar1;
  uint uVar2;
  int iVar3;
  int iVar4;
  bool bVar5;
  undefined8 uVar6;
  longlong lVar7;
  int local_2c;
  
  lVar1 = 0;
  iVar3 = 0x40;
  local_2c = param_2;
  while (iVar4 = iVar3 + -1, 0 < iVar3) {
    uVar6 = __aeabi_llsr(param_1,local_2c,iVar4);
    uVar2 = (uint)((ulonglong)uVar6 >> 0x20);
    iVar3 = iVar4;
    if (param_4 < uVar2 || uVar2 - param_4 < (uint)(param_3 <= (uint)uVar6)) {
      uVar6 = __aeabi_llsl(param_3,param_4,iVar4);
      bVar5 = param_1 < (uint)uVar6;
      param_1 = param_1 - (uint)uVar6;
      local_2c = (local_2c - (int)((ulonglong)uVar6 >> 0x20)) - (uint)bVar5;
      lVar7 = __aeabi_llsl(1,0,iVar4);
      lVar1 = lVar7 + lVar1;
    }
  }
  return lVar1;
}


/* ---------------------------------------------------------------------- */
/* __aeabi_llsr @ 200002a4 */


/* 64-bit logical shift right */

ulonglong __aeabi_llsr(uint param_1,uint param_2,uint param_3)

{
  if (0x1f < (int)param_3) {
    return (ulonglong)(param_2 >> (param_3 - 0x20 & 0xff));
  }
  return CONCAT44(param_2 >> (param_3 & 0xff),
                  param_1 >> (param_3 & 0xff) | param_2 << (0x20 - param_3 & 0xff));
}


/* ---------------------------------------------------------------------- */
/* memcpy @ 200002c6 */


/* __aeabi_memcpy (word-aligned fast path) */

void memcpy(undefined4 *param_1,undefined4 *param_2,uint param_3)

{
  undefined4 uVar1;
  bool bVar2;
  
  if ((((uint)param_1 | (uint)param_2) & 3) == 0) {
    for (; 3 < param_3; param_3 = param_3 - 4) {
      uVar1 = *param_2;
      param_2 = param_2 + 1;
      *param_1 = uVar1;
      param_1 = param_1 + 1;
    }
  }
  while (bVar2 = param_3 != 0, param_3 = param_3 - 1, bVar2) {
    *(undefined1 *)param_1 = *(undefined1 *)param_2;
    param_1 = (undefined4 *)((int)param_1 + 1);
    param_2 = (undefined4 *)((int)param_2 + 1);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* _memset_byte @ 200002ea */


/* fill n bytes */

void _memset_byte(undefined1 *param_1,int param_2,undefined1 param_3)

{
  bool bVar1;
  
  while (bVar1 = param_2 != 0, param_2 = param_2 + -1, bVar1) {
    *param_1 = param_3;
    param_1 = param_1 + 1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* __aeabi_memclr @ 200002f8 */


/* zero n bytes */

void __aeabi_memclr(undefined4 param_1,undefined4 param_2)

{
  _memset_byte(param_1,param_2,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* memset @ 200002fc */


/* memset(dst, value, n) */

undefined4 memset(undefined4 param_1,undefined4 param_2,undefined4 param_3)

{
  _memset_byte(param_1,param_3,param_2);
  return param_1;
}


/* ---------------------------------------------------------------------- */
/* read_u32_le @ 2000030e */


/* load 4 bytes little-endian from unaligned pointer */

uint read_u32_le(int param_1,undefined4 param_2,uint param_3)

{
  byte *pbVar1;
  int iVar2;
  
  iVar2 = 3;
  pbVar1 = (byte *)(param_1 + 4);
  do {
    pbVar1 = pbVar1 + -1;
    param_3 = param_3 << 8 | (uint)*pbVar1;
    iVar2 = iVar2 + -1;
  } while (-1 < iVar2);
  return param_3;
}


/* ---------------------------------------------------------------------- */
/* write_u32_le @ 20000322 */


/* store 4 bytes little-endian to unaligned pointer */

uint write_u32_le(uint param_1,undefined1 *param_2)

{
  uint uVar1;
  int iVar2;
  
  iVar2 = 3;
  uVar1 = param_1;
  do {
    *param_2 = (char)uVar1;
    uVar1 = uVar1 >> 8;
    param_2 = param_2 + 1;
    iVar2 = iVar2 + -1;
  } while (-1 < iVar2);
  return param_1;
}


/* ---------------------------------------------------------------------- */
/* __aeabi_llsl @ 20000334 */


/* 64-bit shift left */

longlong __aeabi_llsl(uint param_1,int param_2,uint param_3)

{
  if (0x1f < (int)param_3) {
    return (ulonglong)(param_1 << (param_3 - 0x20 & 0xff)) << 0x20;
  }
  return CONCAT44(param_2 << (param_3 & 0xff) | param_1 >> (0x20 - param_3 & 0xff),
                  param_1 << (param_3 & 0xff));
}


/* ---------------------------------------------------------------------- */
/* __scatterload @ 20000354 */


/* walks Region$$Table at 0x2000F468: RW decompress to 0x04000000, ZI 0x04000604..0x04004A40 */

void __scatterload(void)

{
  byte bVar1;
  byte *pbVar2;
  byte *extraout_r1;
  uint extraout_r2;
  uint uVar3;
  uint uVar4;
  byte *pbVar5;
  byte *pbVar6;
  byte *pbVar7;
  uint uVar8;
  uint unaff_r8;
  
  for (pbVar6 = Region__Table; pbVar6 < &DAT_2000f488; pbVar6 = pbVar6 + 0x10) {
    (**(code **)(pbVar6 + 0xc))
              (*(undefined4 *)pbVar6,*(undefined4 *)(pbVar6 + 4),*(undefined4 *)(pbVar6 + 8));
  }
  main();
  pbVar6 = extraout_r1;
  uVar3 = extraout_r2;
  do {
    pbVar2 = (byte *)(unaff_r8 ^ 0x80000);
    pbVar7 = pbVar6 + uVar3;
    do {
      uVar8 = (uint)*pbVar2;
      uVar4 = uVar8 & 7;
      pbVar5 = pbVar2 + 1;
      if ((*pbVar2 & 7) == 0) {
        uVar4 = (uint)pbVar2[1];
        pbVar5 = pbVar2 + 2;
      }
      pbVar2 = pbVar5;
      uVar3 = (int)uVar8 >> 4;
      if (uVar3 == 0) {
        uVar3 = (uint)*pbVar2;
        pbVar2 = pbVar2 + 1;
      }
      while (uVar4 = uVar4 - 1, uVar4 != 0) {
        *pbVar6 = *pbVar2;
        pbVar2 = pbVar2 + 1;
        pbVar6 = pbVar6 + 1;
      }
      if ((int)(uVar8 << 0x1c) < 0) {
        bVar1 = *pbVar2;
        pbVar2 = pbVar2 + 1;
        pbVar5 = pbVar6 + -(uint)bVar1;
        uVar3 = uVar3 + 2;
        while (uVar3 = uVar3 - 1, -1 < (int)uVar3) {
          *pbVar6 = *pbVar5;
          pbVar6 = pbVar6 + 1;
          pbVar5 = pbVar5 + 1;
        }
      }
      else {
        while (uVar3 = uVar3 - 1, -1 < (int)uVar3) {
          *pbVar6 = 0;
          pbVar6 = pbVar6 + 1;
        }
      }
    } while (pbVar6 < pbVar7);
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* __decompress1 @ 20000378 */


/* Keil RW-data LZ decompressor (ported in tools/keil_scatter.py) */

void __decompress1(byte *param_1,byte *param_2,int param_3)

{
  byte bVar1;
  uint uVar2;
  int iVar3;
  uint uVar4;
  byte *pbVar5;
  byte *pbVar6;
  uint uVar7;
  code *UNRECOVERED_JUMPTABLE;
  
  pbVar6 = param_2 + param_3;
  do {
    uVar7 = (uint)*param_1;
    uVar4 = uVar7 & 7;
    pbVar5 = param_1 + 1;
    if ((*param_1 & 7) == 0) {
      uVar4 = (uint)param_1[1];
      pbVar5 = param_1 + 2;
    }
    param_1 = pbVar5;
    uVar2 = (int)uVar7 >> 4;
    if (uVar2 == 0) {
      uVar2 = (uint)*param_1;
      param_1 = param_1 + 1;
    }
    while (uVar4 = uVar4 - 1, uVar4 != 0) {
      *param_2 = *param_1;
      param_1 = param_1 + 1;
      param_2 = param_2 + 1;
    }
    if ((int)(uVar7 << 0x1c) < 0) {
      bVar1 = *param_1;
      param_1 = param_1 + 1;
      pbVar5 = param_2 + -(uint)bVar1;
      iVar3 = uVar2 + 2;
      while (iVar3 = iVar3 + -1, -1 < iVar3) {
        *param_2 = *pbVar5;
        param_2 = param_2 + 1;
        pbVar5 = pbVar5 + 1;
      }
    }
    else {
      while (uVar2 = uVar2 - 1, -1 < (int)uVar2) {
        *param_2 = 0;
        param_2 = param_2 + 1;
      }
    }
  } while (param_2 < pbVar6);
                    /* WARNING: Could not recover jumptable at 0x200003cc. Too many branches */
                    /* WARNING: Treating indirect jump as call */
  (*UNRECOVERED_JUMPTABLE)(0);
  return;
}


/* ---------------------------------------------------------------------- */
/* clock_init @ 200003d0 */


/* core/bus clocks -> 96 MHz; stores SystemCoreClock */

void clock_init(void)

{
  DAT_40000630 = 0x10;
  FUN_2000044c(0x101100);
  FUN_200018b8(96000000);
  FUN_200007d4(96000000);
  FUN_20000818(96000000);
  FUN_20000798(0x20,1,0);
  FUN_20000798(0,0,1);
  FUN_20000798(0,1);
  FUN_2000044c(0x101400);
  SystemCoreClock = 96000000;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000430 @ 20000430 */


void FUN_20000430(void)

{
  DAT_40000220 = 0x2000;
  DAT_40001098 = 0x187;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000044c @ 2000044c */


void FUN_2000044c(uint param_1)

{
  bool bVar1;
  uint uVar2;
  uint uVar3;
  
  bVar1 = false;
  uVar2 = 0;
  do {
    param_1 = param_1 >> (uVar2 * 0xc & 0xff);
    if (param_1 == 0) {
      bVar1 = true;
    }
    else {
      uVar3 = ((param_1 << 0x14) >> 0x1c) - 1 & 0xff;
      if ((param_1 & 0xff) == 0x1c) {
        DAT_40040020 = uVar3;
      }
      else {
        (&DAT_40000280)[param_1 & 0xff] = uVar3;
      }
    }
    uVar2 = uVar2 + 1;
  } while ((uVar2 < 3) && (!bVar1));
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000490 @ 20000490 */


void FUN_20000490(uint param_1)

{
  int iVar1;
  
  iVar1 = 1 << (param_1 & 0xff);
  if (param_1 >> 8 < 2) {
    (&DAT_40000220)[param_1 >> 8] = iVar1;
    return;
  }
  DAT_40040014 = iVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200004b4 @ 200004b4 */


undefined4 FUN_200004b4(int param_1,int param_2)

{
  uint uVar1;
  undefined4 uVar2;
  undefined4 uVar3;
  
  uVar3 = 1;
  DAT_40000244 = 0x2000000;
  if (param_1 != 2) {
    uVar3 = 0;
    goto LAB_200004c4;
  }
  if (param_2 == 48000000) {
    uVar2 = 1;
LAB_200004fa:
    FUN_20000798(0x26,uVar2,0);
  }
  else {
    if (param_2 == 96000000) {
      uVar2 = 2;
      goto LAB_200004fa;
    }
    uVar3 = 0;
  }
  uVar1 = DAT_40000500;
  DAT_40000500 = uVar1 & 0xc3ff7fff | 0x41000000;
  FUN_2000044c(0x10a);
LAB_200004c4:
  DAT_40000224 = 0x2000000;
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000514 @ 20000514 */


undefined4 FUN_20000514(void)

{
  uint uVar1;
  undefined4 uVar2;
  
  uVar1 = DAT_40040020;
  if ((uVar1 & 3) == 0) {
    uVar2 = FUN_2000053c();
    return uVar2;
  }
  if ((uVar1 & 3) != 1) {
    return 0;
  }
  return 12000000;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000053c @ 2000053c */


undefined4 FUN_2000053c(void)

{
  int iVar1;
  undefined4 uVar2;
  
  iVar1 = DAT_40000284;
  if ((iVar1 == 0) && (iVar1 = DAT_40000280, iVar1 == 0)) {
    uVar2 = FUN_2000070c();
    return uVar2;
  }
  iVar1 = DAT_40000284;
  if ((iVar1 != 0) || (iVar1 = DAT_40000280, iVar1 != 1)) {
    iVar1 = DAT_40000284;
    if ((iVar1 == 0) && (iVar1 = DAT_40000280, iVar1 == 2)) {
      uVar2 = FUN_20000758();
      return uVar2;
    }
    iVar1 = DAT_40000284;
    if ((iVar1 == 0) && (iVar1 = DAT_40000280, iVar1 == 3)) {
      uVar2 = FUN_20000724();
      return uVar2;
    }
    iVar1 = DAT_40000284;
    if (iVar1 == 2) {
      return DAT_04000598;
    }
    iVar1 = DAT_40000284;
    if (iVar1 == 3) {
      return 0x8000;
    }
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200005ac @ 200005ac */


undefined4 FUN_200005ac(void)

{
  int iVar1;
  undefined4 uVar2;
  
  iVar1 = DAT_400002e8;
  if (iVar1 == 0) {
    uVar2 = FUN_2000053c();
    return uVar2;
  }
  iVar1 = DAT_400002e8;
  if (iVar1 == 1) {
    return DAT_04000598;
  }
  iVar1 = DAT_400002e8;
  if (iVar1 == 2) {
    uVar2 = FUN_2000070c();
    return uVar2;
  }
  iVar1 = DAT_400002e8;
  if (iVar1 != 3) {
    return 0;
  }
  uVar2 = FUN_20000724();
  return uVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_200005ec @ 200005ec */


undefined4 FUN_200005ec(int param_1)

{
  undefined4 uVar1;
  
  param_1 = param_1 * 4;
  if (*(int *)(&DAT_400002b0 + param_1) == 0) {
    uVar1 = FUN_2000070c();
    return uVar1;
  }
  if (*(int *)(&DAT_400002b0 + param_1) == 1) {
    uVar1 = FUN_20000724();
    return uVar1;
  }
  if (*(int *)(&DAT_400002b0 + param_1) == 2) {
    return DAT_04000598;
  }
  if (*(int *)(&DAT_400002b0 + param_1) != 3) {
    if (*(int *)(&DAT_400002b0 + param_1) != 4) {
      return 0;
    }
    uVar1 = FUN_2000063c(8);
    return uVar1;
  }
  return DAT_04000590;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000063c @ 2000063c */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20000646) */
/* WARNING: Removing unreachable block (ram,0x20000646) */

undefined4 FUN_2000063c(undefined4 param_1)

{
  int iVar1;
  undefined4 uVar2;
  uint uVar3;
  undefined4 uVar4;
  byte bVar5;
  
  switch(param_1) {
  case 0:
    uVar4 = FUN_2000053c();
    return uVar4;
  case 1:
    uVar4 = FUN_2000053c();
    uVar2 = DAT_40000380;
    bVar5 = (byte)uVar2;
    goto LAB_20000690;
  case 2:
    uVar4 = FUN_20000724();
    return uVar4;
  case 3:
    uVar4 = FUN_2000070c();
    return uVar4;
  default:
    return 0;
  case 5:
    return DAT_04000598;
  case 6:
    iVar1 = DAT_400002a8;
    if (iVar1 == 0) {
      uVar4 = FUN_20000724();
    }
    else {
      iVar1 = DAT_400002a8;
      uVar4 = DAT_04000598;
      if (iVar1 != 1) {
        uVar4 = 0;
      }
    }
    uVar2 = DAT_40000398;
    bVar5 = (byte)uVar2;
LAB_20000690:
    uVar4 = __aeabi_uidiv(uVar4,bVar5 + 1);
    return uVar4;
  case 7:
    uVar4 = FUN_20000758();
    return uVar4;
  case 8:
    uVar3 = DAT_400003a0;
    if ((~uVar3 & 0xff) != 0) {
      return 0;
    }
    uVar3 = FUN_200005ac();
    iVar1 = DAT_400003a0;
    uVar4 = __aeabi_uldivmod(uVar3 << 8,uVar3 >> 0x18,((uint)(iVar1 << 0x10) >> 0x18) + 0x100,0);
    return uVar4;
  case 9:
    uVar4 = FUN_20000514();
    return uVar4;
  case 10:
    return DAT_04000590;
  case 0xb:
    uVar4 = 0;
    break;
  case 0xc:
    uVar4 = 1;
    break;
  case 0xd:
    uVar4 = 2;
    break;
  case 0xe:
    uVar4 = 3;
    break;
  case 0xf:
    uVar4 = 4;
    break;
  case 0x10:
    uVar4 = 5;
    break;
  case 0x11:
    uVar4 = 6;
    break;
  case 0x12:
    uVar4 = 7;
  }
  uVar4 = FUN_200005ec(uVar4);
  return uVar4;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000070c @ 2000070c */


undefined4 FUN_2000070c(void)

{
  int iVar1;
  
  iVar1 = DAT_40000610;
  if (iVar1 << 0x1b < 0) {
    return 0;
  }
  return 12000000;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000724 @ 20000724 */


undefined4 FUN_20000724(void)

{
  int iVar1;
  
  iVar1 = DAT_40000610;
  if ((-1 < iVar1 << 0x1b) && (iVar1 = DAT_40000500, iVar1 << 1 < 0)) {
    iVar1 = DAT_40000500;
    if (iVar1 << 0x11 < 0) {
      return 96000000;
    }
    return 48000000;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000758 @ 20000758 */


undefined4 FUN_20000758(void)

{
  uint uVar1;
  int iVar2;
  undefined4 uVar3;
  
  iVar2 = DAT_40000610;
  if (iVar2 << 0xb < 0) {
    return 0;
  }
  uVar1 = DAT_40000508;
  iVar2 = DAT_40000508;
  uVar3 = __aeabi_uidiv((uint)(byte)(&DAT_2000f338)[(uint)(iVar2 << 0x16) >> 0x1b] * 50000,
                        ((uVar1 & 0x1f) + 1) * 2);
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000798 @ 20000798 */


void FUN_20000798(int param_1,int param_2,int param_3)

{
  if (param_3 != 0) {
    *(undefined4 *)(&DAT_40000300 + param_1 * 4) = 0x20000000;
  }
  if (param_2 == 0) {
    param_2 = 0x40000000;
  }
  else {
    param_2 = param_2 + -1;
  }
  *(int *)(&DAT_40000300 + param_1 * 4) = param_2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200007bc @ 200007bc */


void FUN_200007bc(int param_1)

{
  uint uVar1;
  
  uVar1 = DAT_40000400;
  DAT_40000400 = param_1 << 0xc | uVar1 & 0xffff0fff;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200007d4 @ 200007d4 */


void FUN_200007d4(uint param_1)

{
  undefined4 uVar1;
  
  if (param_1 < 0xb71b01) {
    uVar1 = 0;
  }
  else if (param_1 < 0x1c9c381) {
    uVar1 = 1;
  }
  else if (param_1 < 0x3938701) {
    uVar1 = 2;
  }
  else if (param_1 < 0x510ff41) {
    uVar1 = 3;
  }
  else {
    uVar1 = 4;
  }
  FUN_200007bc(uVar1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000818 @ 20000818 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

undefined4 FUN_20000818(uint param_1)

{
  int iVar1;
  uint uVar2;
  
  if (((param_1 != 12000000) && (param_1 != 48000000)) && (param_1 != 96000000)) {
    return 1;
  }
  FUN_200018a4(4);
  iVar1 = DAT_40000500;
  uVar2 = (uint)(iVar1 << 7) >> 0x1f;
  if (param_1 < 0xb71b01) {
    uVar2 = DAT_40000500;
    uVar2 = uVar2 & 0xbfffffff;
  }
  else {
    if (param_1 == 96000000) {
      DAT_40000500 = _DAT_01000430 & 0xff3fff | uVar2 << 0x18 | 0xc0004000;
      return 0;
    }
    uVar2 = (_DAT_01000444 & 0xff3fff | uVar2 << 0x18) + 0x80000000 | 0x40000000;
  }
  DAT_40000500 = uVar2;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000894 @ 20000894 */


void FUN_20000894(void)

{
  FUN_20000a50(0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000924 @ 20000924 */


void FUN_20000924(void)

{
  FUN_20000a50(1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200009dc @ 200009dc */


void FUN_200009dc(void)

{
  FUN_20000a50(3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200009e8 @ 200009e8 */


void FUN_200009e8(int param_1)

{
  ushort uVar1;
  int iVar2;
  uint uVar3;
  
  iVar2 = FUN_20000ab8();
  *(uint *)(param_1 + 4) = *(uint *)(param_1 + 4) & 0xfffffffe;
  uVar1 = *(ushort *)(&DAT_2000f3c0 + iVar2 * 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000240)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
  }
  else {
    DAT_40040018 = 1 << (uVar1 & 0xff);
  }
  uVar3 = (uint)(char)(&DAT_2000f3bc)[iVar2];
  if ((uVar3 != 0xffffff80) && (-1 < (int)uVar3)) {
    DAT_e000e180 = 1 << (uVar3 & 0x1f);
    DataSynchronizationBarrier(0xf);
    InstructionSynchronizationBarrier(0xf);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000a50 @ 20000a50 */


void FUN_20000a50(int param_1)

{
  code *pcVar1;
  uint uVar2;
  uint uVar3;
  
  uVar3 = *(uint *)(&DAT_2000f3c8)[param_1];
  *(uint *)(&DAT_2000f3c8)[param_1] = uVar3;
  if ((&DAT_040005b4)[param_1] == '\0') {
    if ((code *)**(undefined4 **)(&DAT_040031a8 + param_1 * 4) != (code *)0x0) {
      (*(code *)**(undefined4 **)(&DAT_040031a8 + param_1 * 4))(uVar3);
      return;
    }
  }
  else {
    uVar2 = 0;
    do {
      if (((uVar3 & 1 << (uVar2 & 0xff)) != 0) &&
         (pcVar1 = *(code **)(*(int *)(&DAT_040031a8 + param_1 * 4) + uVar2 * 4),
         pcVar1 != (code *)0x0)) {
        (*pcVar1)(uVar3);
      }
      uVar2 = uVar2 + 1;
    } while (uVar2 < 7);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000aa4 @ 20000aa4 */


void FUN_20000aa4(undefined1 *param_1)

{
  uint uVar1;
  
  if (param_1 != (undefined1 *)0x0) {
    *param_1 = 0;
    param_1[1] = 0;
    *(undefined4 *)(param_1 + 4) = 0;
    return;
  }
  uVar1 = 0;
  do {
    if ((&DAT_2000f3c8)[uVar1] == 0) {
      return;
    }
    uVar1 = uVar1 + 1;
  } while (uVar1 < 3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000ab8 @ 20000ab8 */


void FUN_20000ab8(int param_1)

{
  uint uVar1;
  
  uVar1 = 0;
  do {
    if ((&DAT_2000f3c8)[uVar1] == param_1) {
      return;
    }
    uVar1 = uVar1 + 1;
  } while (uVar1 < 3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000ae0 @ 20000ae0 */


void FUN_20000ae0(int param_1,byte *param_2)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  
  if (param_2 == (byte *)0x0) {
    uVar2 = 0;
    iVar1 = param_1;
  }
  else {
    iVar1 = FUN_20000ab8();
    uVar2 = (uint)*(ushort *)(&DAT_2000f3c0 + iVar1 * 2);
    uVar3 = (uint)(*(ushort *)(&DAT_2000f3c0 + iVar1 * 2) >> 8);
    iVar1 = 1;
    if (uVar3 < 2) {
      (&DAT_40000220)[uVar3] = 1 << (uVar2 & 0xff);
      goto LAB_20000b10;
    }
  }
  DAT_40040014 = iVar1 << (uVar2 & 0xff);
LAB_20000b10:
  iVar1 = FUN_20000ab8(param_1);
  FUN_20001a38(*(undefined4 *)(&DAT_2000f3d4 + iVar1 * 4));
  *(uint *)(param_1 + 0x70) = *param_2 & 3 | ((uint)param_2[1] << 0x1e) >> 0x1c;
  *(undefined4 *)(param_1 + 0xc) = *(undefined4 *)(param_2 + 4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000b44 @ 20000b44 */


void FUN_20000b44(undefined4 param_1,undefined4 param_2,undefined1 param_3)

{
  int iVar1;
  
  iVar1 = FUN_20000ab8();
  *(undefined4 *)(&DAT_040031a8 + iVar1 * 4) = param_2;
  (&DAT_040005b4)[iVar1] = param_3;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000b64 @ 20000b64 */


void FUN_20000b64(uint *param_1,uint param_2,uint *param_3)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = FUN_20000ab8();
  uVar2 = param_2 * 3;
  param_1[5] = (uint)(byte)param_3[2] << (uVar2 & 0xff) |
               (uint)*(byte *)((int)param_3 + 5) << (uVar2 + 2 & 0xff) |
               (uint)(byte)param_3[1] << (uVar2 + 1 & 0xff) | param_1[5] & ~(7 << (uVar2 & 0xff));
  uVar2 = 1 << (param_2 & 0xff);
  param_1[0xf] = (uint)*(byte *)((int)param_3 + 7) << (param_2 & 0xff) |
                 ((uint)*(byte *)((int)param_3 + 6) << (param_2 * 2 + 4 & 0xff) |
                 param_1[0xf] & ~(0x30 << (param_2 * 2 & 0xff))) & ~uVar2;
  param_1[param_2 + 6] = *param_3;
  *param_1 = uVar2;
  if ((char)param_3[2] != '\0') {
    FUN_20000f30((int)(char)(&DAT_2000f3bc)[iVar1]);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000bd4 @ 20000bd4 */


void FUN_20000bd4(void)

{
  undefined4 uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar1 = __aeabi_uidiv(DAT_040005e8,10);
  DAT_040005e4 = __aeabi_uidiv(*(int *)(DAT_040005ec + 8) * 0x12c0,uVar1);
  if (DAT_040005e4 < 0xbbb1) {
    if (0xbb4f < DAT_040005e4) {
      return;
    }
    uVar3 = DAT_40000500;
    uVar2 = DAT_40000500;
    uVar2 = (uVar2 & 0xff0000) + 0x10000;
  }
  else {
    uVar3 = DAT_40000500;
    uVar2 = DAT_40000500;
    uVar2 = (uVar2 & 0xff0000) - 0x10000;
  }
  DAT_40000500 = uVar3 & 0xff00ffff | uVar2 & 0xffffff | 0x80000000;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000c3c @ 20000c3c */


void FUN_20000c3c(void)

{
  uint uVar1;
  int iVar2;
  
  delay_ms(0x32);
  FUN_200073a8(1,7,0);
  delay_ms(0x32);
  uVar1 = FUN_20007358(0,0x1d);
  iVar2 = FUN_20007358(0,0x1e);
  FUN_20007358(0,8);
  FUN_20007358(0,0x16);
  FUN_20007358(0);
  FUN_20007358(0,0x15);
  FUN_20007358(0,0x12);
  FUN_20007358(0,0x13);
  FUN_20007358(0,1);
  FUN_20007358(1,3);
  FUN_20007358(1,8);
  if (-1 < (int)((uVar1 | iVar2 << 1) << 0x1e)) {
    delay_ms(100);
    uVar1 = FUN_20007358(0,0x1d);
    iVar2 = FUN_20007358(0,0x1e);
    FUN_20007358(0,8);
    FUN_20007358(0,0x16);
    FUN_20007358(0);
    FUN_20007358(0,0x15);
    FUN_20007358(0,0x12);
    FUN_20007358(0,0x13);
    FUN_20007358(0,1);
    FUN_20007358(1,3);
    FUN_20007358(1,8);
    FUN_200073a8(1,7);
    if (-1 < (int)((uVar1 | iVar2 << 1) << 0x1e)) {
      if (DAT_04000d6d == '\0') {
        DAT_04000d6d = '\x01';
      }
      else if (DAT_04000d6d == '\x01') {
        DAT_04000d6d = '\0';
      }
      settings_mark_dirty(2,0);
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000d94 @ 20000d94 */


undefined4 FUN_20000d94(undefined4 param_1,undefined4 param_2)

{
  DAT_040005e8 = param_2;
  DAT_040005ec = param_1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000da4 @ 20000da4 */


void FUN_20000da4(void)

{
  FUN_20000df0(&DAT_40082000);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000db4 @ 20000db4 */


void FUN_20000db4(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f40c)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000dd8 @ 20000dd8 */


int FUN_20000dd8(void)

{
  uint uVar1;
  uint uVar2;
  int iVar3;
  
  iVar3 = 0;
  uVar1 = FUN_20000db4();
  for (uVar2 = 0; uVar2 < uVar1; uVar2 = uVar2 + 1) {
    iVar3 = iVar3 + 0x12;
  }
  return iVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000df0 @ 20000df0 */


void FUN_20000df0(void)

{
  int iVar1;
  int iVar2;
  undefined4 in_r3;
  undefined4 *puVar3;
  uint uVar4;
  uint uVar5;
  
  iVar1 = FUN_20000dd8();
  uVar5 = 0;
  do {
    puVar3 = *(undefined4 **)(&DAT_04003320 + (uVar5 + iVar1) * 4);
    if (puVar3 != (undefined4 *)0x0) {
      iVar2 = (uint)(*(byte *)(puVar3 + 3) >> 5) * 0x5c;
      uVar4 = 1 << (*(byte *)(puVar3 + 3) & 0x1f);
      if ((*(uint *)(puVar3[2] + iVar2 + 0x58) & uVar4) != 0) {
        *(uint *)(puVar3[2] + iVar2 + 0x58) = uVar4;
        if ((code *)*puVar3 != (code *)0x0) {
          (*(code *)*puVar3)(puVar3,puVar3[1],1,0,iVar2,iVar1,in_r3);
        }
      }
      if ((*(uint *)(puVar3[2] + iVar2 + 0x60) & uVar4) != 0) {
        *(uint *)(puVar3[2] + iVar2 + 0x60) = uVar4;
        if ((code *)*puVar3 != (code *)0x0) {
          (*(code *)*puVar3)(puVar3,puVar3[1],1);
        }
      }
      if ((*(uint *)(puVar3[2] + iVar2 + 0x40) & uVar4) != 0) {
        *(uint *)(puVar3[2] + iVar2 + 0x40) = uVar4;
        if ((code *)*puVar3 != (code *)0x0) {
          (*(code *)*puVar3)(puVar3,puVar3[1],0,2);
        }
      }
    }
    uVar5 = uVar5 + 1;
  } while (uVar5 < 0x12);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000e80 @ 20000e80 */


void FUN_20000e80(uint param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  uint uVar2;
  ushort uVar3;
  uint uVar4;
  int iVar5;
  
  uVar4 = *(uint *)(&DAT_4008530c + param_2 * 8);
  iVar5 = *(int *)(&DAT_40085100 + ((uint)(*(int *)(&DAT_40085304 + param_2 * 8) << 0x1c) >> 0x1a));
  uVar3 = __aeabi_uidiv(param_1 * iVar5,100,param_3,param_4,param_4);
  if (99 < param_1) {
    uVar3 = (short)iVar5 + 2;
  }
  uVar1 = DAT_40085000;
  uVar2 = DAT_40085004;
  DAT_40085004 = uVar2 | 4;
  iVar5 = (uVar4 & 0xf) * 4;
  *(uint *)(&DAT_40085100 + iVar5) = (uint)uVar3;
  *(uint *)(&DAT_40085200 + iVar5) = (uint)uVar3;
  uVar1 = DAT_40085000;
  uVar4 = DAT_40085004;
  DAT_40085004 = uVar4 & 0xfffffffb;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000ee0 @ 20000ee0 */


undefined4 FUN_20000ee0(int param_1)

{
  if (param_1 != -0x80) {
    FUN_2000518c();
    return 0;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000ef4 @ 20000ef4 */


void FUN_20000ef4(uint param_1)

{
  uint uVar1;
  int iVar2;
  
  iVar2 = 0;
  for (uVar1 = param_1; 0x1f < uVar1; uVar1 = uVar1 - 0x20) {
    iVar2 = iVar2 + 1;
  }
  (&DAT_400006a0)[iVar2] = 1 << (uVar1 & 0xff);
  if ((param_1 != 0xffffff80) && (-1 < (int)param_1)) {
    DAT_e000e100 = 1 << (param_1 & 0x1f);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000f30 @ 20000f30 */


undefined4 FUN_20000f30(uint param_1)

{
  if (param_1 != 0xffffff80) {
    if (-1 < (int)param_1) {
      DAT_e000e100 = 1 << (param_1 & 0x1f);
    }
    return 0;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000f54 @ 20000f54 */


undefined4 FUN_20000f54(uint param_1)

{
  if (param_1 != 0xffffff80) {
    if (-1 < (int)param_1) {
      DAT_e000e100 = 1 << (param_1 & 0x1f);
    }
    return 0;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20000f78 @ 20000f78 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20000f78(void)

{
  int iVar1;
  
  if (DAT_04003158 != (code *)0x0) {
    (*DAT_04003158)(&DAT_40086000,DAT_04003178);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_0400315c != (code *)0x0) {
    (*DAT_0400315c)(&DAT_40087000,DAT_0400317c);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003160 != (code *)0x0) {
    (*DAT_04003160)(&DAT_40088000,DAT_04003180);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003164 != (code *)0x0) {
    (*DAT_04003164)(&DAT_40089000,DAT_04003184);
    return;
  }
  if (DAT_04003168 != (code *)0x0) {
    (*DAT_04003168)(&DAT_4008a000,DAT_04003188);
    return;
  }
  if (DAT_0400316c != (code *)0x0) {
    (*DAT_0400316c)(&DAT_40096000,DAT_0400318c);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003170 != (code *)0x0) {
    (*DAT_04003170)(&DAT_40097000,DAT_04003190);
    return;
  }
  _DAT_31580000 = &DAT_31580000;
  if (DAT_04003174 == (code *)0x0) {
    _DAT_31580000 = &DAT_31580000;
    iVar1 = 0;
    do {
      if ((undefined1 *)(&DAT_2000f358)[iVar1] == &DAT_31580000) {
        return;
      }
      iVar1 = iVar1 + 1;
    } while (iVar1 < 8);
    return;
  }
  (*DAT_04003174)(&DAT_40098000,DAT_04003194);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001078 @ 20001078 */


void FUN_20001078(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f358)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 < 8);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001098 @ 20001098 */


undefined4 FUN_20001098(undefined4 param_1,undefined4 param_2)

{
  ushort uVar1;
  int iVar2;
  undefined4 uVar3;
  
  iVar2 = FUN_20001078();
  if (iVar2 < 0) {
    return 4;
  }
  uVar1 = *(ushort *)(&DAT_2000f378 + iVar2 * 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000220)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
  }
  else {
    DAT_40040014 = 1 << (uVar1 & 0xff);
  }
  uVar3 = FUN_20001100(param_1,param_2,0);
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_200010e4 @ 200010e4 */


void FUN_200010e4(undefined4 param_1,undefined4 param_2,undefined4 param_3)

{
  int iVar1;
  
  iVar1 = FUN_20001078();
  (&DAT_04003178)[iVar1] = param_3;
  (&DAT_04003158)[iVar1] = param_2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001100 @ 20001100 */


undefined4 FUN_20001100(int param_1,uint param_2,int param_3)

{
  uint uVar1;
  
  if (param_2 != 0) {
    if (param_2 - 1 < 4) {
      if ((*(uint *)(param_1 + 0xff8) & 1 << (param_2 + 3 & 0xff)) == 0) {
        uVar1 = 0;
      }
      else {
        uVar1 = 1;
      }
    }
    else {
      if (param_2 != 5) {
        return 3;
      }
      uVar1 = (uint)(*(int *)(param_1 + 0xff8) << 0x18) >> 0x1f;
    }
    if (uVar1 == 0) {
      return 3;
    }
  }
  if ((*(int *)(param_1 + 0xff8) << 0x1c < 0) && ((*(uint *)(param_1 + 0xff8) & 7) != param_2)) {
    return 1;
  }
  if (param_3 != 0) {
    param_2 = param_2 | 8;
  }
  *(uint *)(param_1 + 0xff8) = param_2;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000115c @ 2000115c */


void FUN_2000115c(void)

{
  uint uVar1;
  
  uVar1 = DAT_40002000;
  DAT_40002000 = uVar1 | 1;
  if (DAT_040005b8 != (code *)0x0) {
                    /* WARNING: Could not recover jumptable at 0x2000116e. Too many branches */
                    /* WARNING: Treating indirect jump as call */
    (*DAT_040005b8)();
    return;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000117c @ 2000117c */


void FUN_2000117c(void)

{
  uint uVar1;
  
  uVar1 = DAT_40003000;
  DAT_40003000 = uVar1 | 1;
  if (DAT_040005bc != (code *)0x0) {
                    /* WARNING: Could not recover jumptable at 0x2000118e. Too many branches */
                    /* WARNING: Treating indirect jump as call */
    (*DAT_040005bc)();
    return;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000119c @ 2000119c */


void FUN_2000119c(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  param_1 = param_2 * 4 + param_1;
  *(undefined4 *)(param_1 + 0x20) = param_3;
  *(undefined4 *)(param_1 + 0x40) = param_4;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200011a8 @ 200011a8 */


void FUN_200011a8(undefined4 param_1)

{
  ushort uVar1;
  int iVar2;
  
  iVar2 = FUN_2000127c();
  FUN_200011fc(param_1);
  (&DAT_040005b8)[iVar2] = 0;
  FUN_20001a38(*(undefined4 *)(&DAT_2000f420 + iVar2 * 4));
  uVar1 = *(ushort *)((int)&DAT_2000f410 + iVar2 * 2 + 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000240)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
    return;
  }
  DAT_40040018 = 1 << (uVar1 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200011fc @ 200011fc */


void FUN_200011fc(uint *param_1)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = FUN_2000127c();
  uVar2 = (uint)*(char *)((int)&DAT_2000f410 + iVar1);
  if ((uVar2 != 0xffffff80) && (-1 < (int)uVar2)) {
    DAT_e000e180 = 1 << (uVar2 & 0x1f);
    DataSynchronizationBarrier(0xf);
    InstructionSynchronizationBarrier(0xf);
  }
  *param_1 = *param_1 | 1;
  FUN_2000515c((int)*(char *)((int)&DAT_2000f410 + iVar1));
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001240 @ 20001240 */


void FUN_20001240(uint *param_1)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = FUN_2000127c();
  *param_1 = *param_1 | 1;
  FUN_2000515c((int)*(char *)((int)&DAT_2000f410 + iVar1));
  uVar2 = (uint)*(char *)((int)&DAT_2000f410 + iVar1);
  if ((uVar2 != 0xffffff80) && (-1 < (int)uVar2)) {
    DAT_e000e100 = 1 << (uVar2 & 0x1f);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000127c @ 2000127c */


void FUN_2000127c(int param_1)

{
  uint uVar1;
  
  uVar1 = 0;
  do {
    if ((&DAT_2000f418)[uVar1] == param_1) {
      return;
    }
    uVar1 = uVar1 + 1;
  } while (uVar1 < 2);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200012a4 @ 200012a4 */


void FUN_200012a4(void)

{
  ushort uVar1;
  int iVar2;
  
  iVar2 = FUN_2000127c();
  (&DAT_040005b8)[iVar2] = 0;
  uVar1 = *(ushort *)((int)&DAT_2000f410 + iVar2 * 2 + 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000220)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
    return;
  }
  DAT_40040014 = 1 << (uVar1 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200012e4 @ 200012e4 */


void FUN_200012e4(uint *param_1,int param_2,int param_3,undefined4 param_4)

{
  int iVar1;
  
  iVar1 = FUN_2000127c();
  *param_1 = (uint)(param_2 << 0x1f) >> 0x1e | (uint)(param_3 << 0x1f) >> 0x1d;
  (&DAT_040005b8)[iVar1] = param_4;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000130c @ 2000130c */


undefined4 FUN_2000130c(undefined4 param_1,undefined4 param_2,uint param_3)

{
  int iVar1;
  
  if (0x59 < param_3) {
    return 0;
  }
  iVar1 = FUN_2000b7e8();
  if (iVar1 != 0) {
    return 1;
  }
  return 2;
}


/* ---------------------------------------------------------------------- */
/* HardFault_Handler @ 20001328 */


void HardFault_Handler(void)

{
  DAT_e000ed0c = 0x5fa0004;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001338 @ 20001338 */


void FUN_20001338(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f3e8)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 < 8);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001358 @ 20001358 */


undefined4 FUN_20001358(undefined4 param_1,undefined1 *param_2,int param_3)

{
  undefined1 uVar1;
  int iVar2;
  uint uVar3;
  
  memcpy(param_2 + 0x18,param_3);
  *(undefined4 *)(param_2 + 4) = 0;
  *(int *)(param_2 + 8) = *(int *)(param_2 + 0x2c);
  *(undefined4 *)(param_2 + 0x10) = 0;
  *(undefined4 *)(param_2 + 0xc) = *(undefined4 *)(param_2 + 0x28);
  if ((param_2[0x18] & 1) == 0) {
    if (*(uint *)(param_2 + 0x24) != 0) {
      if (4 < *(uint *)(param_2 + 0x24)) {
        return 0xa2b;
      }
      uVar3 = *(uint *)(param_3 + 8);
      iVar2 = *(int *)(param_3 + 0xc);
      while (-1 < iVar2 + -1) {
        param_2[iVar2 + 0x13] = (char)uVar3;
        uVar3 = uVar3 >> 8;
        iVar2 = iVar2 + -1;
      }
      *(undefined4 *)(param_2 + 0x10) = *(undefined4 *)(param_2 + 0x24);
    }
    uVar1 = 5;
  }
  else if (*(int *)(param_2 + 0x2c) == 0) {
    uVar1 = 6;
  }
  else if (param_2[0x1e] == '\0') {
    uVar1 = 2;
  }
  else {
    if (param_2[0x1e] != '\x01') {
      return 0xa2b;
    }
    uVar1 = 3;
  }
  *param_2 = uVar1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200013cc @ 200013cc */


void FUN_200013cc(int param_1,int param_2)

{
  uint uVar1;
  
  uVar1 = *(uint *)(param_1 + 0x800);
  if (param_2 == 0) {
    uVar1 = uVar1 & 0x1e;
  }
  else {
    uVar1 = uVar1 & 0x1f | 1;
  }
  *(uint *)(param_1 + 0x800) = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200013ec @ 200013ec */


void FUN_200013ec(undefined1 *param_1)

{
  *param_1 = 1;
  *(undefined4 *)(param_1 + 4) = 100000;
  param_1[8] = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001400 @ 20001400 */


void FUN_20001400(undefined4 param_1,undefined1 *param_2,undefined4 param_3)

{
  FUN_20001098(param_1,3);
  FUN_200013cc(param_1,*param_2);
  FUN_20001422(param_1,*(undefined4 *)(param_2 + 4),param_3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001422 @ 20001422 */


void FUN_20001422(int param_1,int param_2,int param_3)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  uint uVar4;
  uint unaff_r7;
  undefined4 local_28;
  
  uVar4 = 0;
  uVar3 = 9;
  do {
    uVar1 = __aeabi_uidiv(param_3,uVar3 * param_2 * 2);
    if (0x10000 < uVar1) {
      uVar1 = 0x10000;
    }
    uVar2 = param_3 + uVar1 * uVar3 * param_2 * -2;
    if ((uVar2 < uVar4) || (uVar4 == 0)) {
      uVar4 = uVar2;
      unaff_r7 = uVar3;
      local_28 = uVar1;
    }
  } while (((uVar2 != 0) && (uVar1 < 0x10000)) && (uVar3 = uVar3 - 1, 1 < uVar3));
  *(uint *)(param_1 + 0x814) = local_28 - 1 & 0xffff;
  *(uint *)(param_1 + 0x824) = unaff_r7 * 0x10 - 0x20 & 0x7f | unaff_r7 - 2 & 7;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000148c @ 2000148c */


/* WARNING: Control flow encountered bad instruction data */

void FUN_2000148c(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  
  if (param_2 != 0) {
    __aeabi_memclr(param_2,0x38,param_3,param_4,param_4);
    iVar1 = FUN_20001338(param_1);
    *(undefined4 *)(param_2 + 0x30) = param_3;
    *(undefined4 *)(param_2 + 0x34) = param_4;
    FUN_200010e4(param_1,&LAB_200014d8_1,param_2);
    *(undefined4 *)(param_1 + 0x80c) = 0x51;
    FUN_20000f54((int)(char)(&DAT_2000f3e0)[iVar1]);
    return;
  }
                    /* WARNING: Bad instruction - Truncating control flow here */
  halt_baddata();
}


/* ---------------------------------------------------------------------- */
/* FUN_2000150c @ 2000150c */


undefined4 FUN_2000150c(int param_1,char *param_2)

{
  undefined4 uVar1;
  
  if (*param_2 != '\0') {
    return 0xa28;
  }
  *(undefined4 *)(param_1 + 0x80c) = 0x51;
  uVar1 = FUN_20001358();
  *(undefined4 *)(param_1 + 0x804) = 0x50;
  *(undefined4 *)(param_1 + 0x808) = 0x51;
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001548 @ 20001548 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000158e) */
/* WARNING: Removing unreachable block (ram,0x2000158e) */

longlong FUN_20001548(uint param_1,undefined1 *param_2,undefined1 *param_3)

{
  uint uVar1;
  undefined1 uVar2;
  byte *pbVar3;
  undefined1 *puVar4;
  int iVar5;
  undefined4 uVar6;
  
  *param_3 = 0;
  uVar1 = *(uint *)(param_1 + 0x804);
  if ((int)(uVar1 << 0x1b) < 0) {
    *(undefined4 *)(param_1 + 0x804) = 0x10;
    return CONCAT44(param_1,0xa2d);
  }
  if ((int)(uVar1 << 0x19) < 0) {
    *(undefined4 *)(param_1 + 0x804) = 0x40;
    return CONCAT44(param_1,0xa30);
  }
  if ((uVar1 & 1) == 0) {
    return CONCAT44(param_1,0xa28);
  }
  uVar1 = (uVar1 << 0x1c) >> 0x1d;
  if ((uVar1 == 3) || (uVar1 == 4)) {
    *(undefined4 *)(param_1 + 0x820) = 4;
    *param_2 = 7;
    return CONCAT44(param_1,0xa2a);
  }
  switch(*param_2) {
  default:
switchD_2000158e_caseD_0:
    return CONCAT44(param_1,0xa31);
  case 1:
    if (uVar1 != 2) goto switchD_2000158e_caseD_0;
    *(uint *)(param_1 + 0x828) =
         (uint)(byte)param_2[(*(int *)(param_2 + 0x24) - *(int *)(param_2 + 0x10)) + 0x14];
    *(undefined4 *)(param_1 + 0x820) = 1;
    iVar5 = *(int *)(param_2 + 0x10);
    *(int *)(param_2 + 0x10) = iVar5 + -1;
    if (iVar5 + -1 == 0) {
      if (*(int *)(param_2 + 8) == 0) {
        uVar2 = 6;
      }
      else if (param_2[0x1e] == '\x01') {
        uVar2 = 5;
      }
      else {
        uVar2 = 2;
      }
      goto LAB_20001682;
    }
    goto LAB_200015ea;
  case 2:
    if (uVar1 != 2) goto switchD_2000158e_caseD_0;
    pbVar3 = *(byte **)(param_2 + 0xc);
    *(byte **)(param_2 + 0xc) = pbVar3 + 1;
    *(uint *)(param_1 + 0x828) = (uint)*pbVar3;
    *(undefined4 *)(param_1 + 0x820) = 1;
    iVar5 = *(int *)(param_2 + 8);
    *(int *)(param_2 + 8) = iVar5 + -1;
    if (iVar5 + -1 != 0) goto LAB_20001666;
    uVar2 = 6;
    break;
  case 3:
    if (uVar1 != 1) goto switchD_2000158e_caseD_0;
    uVar6 = *(undefined4 *)(param_1 + 0x828);
    puVar4 = *(undefined1 **)(param_2 + 0xc);
    *(undefined1 **)(param_2 + 0xc) = puVar4 + 1;
    *puVar4 = (char)uVar6;
    iVar5 = *(int *)(param_2 + 8);
    *(int *)(param_2 + 8) = iVar5 + -1;
    if (iVar5 + -1 != 0) {
      *(undefined4 *)(param_1 + 0x820) = 1;
      goto LAB_20001666;
    }
    *(undefined4 *)(param_1 + 0x820) = 4;
    uVar2 = 7;
    break;
  case 5:
    if (*(int *)(param_2 + 0x10) == 0) {
      if (param_2[0x1e] == '\0') {
        *(uint *)(param_1 + 0x828) = (uint)*(ushort *)(param_2 + 0x1c) << 1;
        if (*(int *)(param_2 + 8) == 0) goto LAB_200015ec;
        uVar2 = 2;
      }
      else {
        *(uint *)(param_1 + 0x828) = (uint)*(ushort *)(param_2 + 0x1c) * 2 + 1;
        if (*(int *)(param_2 + 8) == 0) {
LAB_200015ec:
          uVar2 = 6;
        }
        else {
          uVar2 = 3;
        }
      }
      *param_2 = uVar2;
    }
    else {
      *(uint *)(param_1 + 0x828) = (uint)*(ushort *)(param_2 + 0x1c) << 1;
      *param_2 = 1;
    }
    *(undefined4 *)(param_1 + 0x820) = 2;
LAB_200015ea:
    return (ulonglong)param_1 << 0x20;
  case 6:
    if (-1 < (int)((uint)(byte)param_2[0x18] << 0x1d)) {
      *(undefined4 *)(param_1 + 0x820) = 4;
      uVar2 = 7;
      goto LAB_20001682;
    }
  case 7:
    *param_3 = 1;
    uVar2 = 0;
LAB_20001682:
    *param_2 = uVar2;
    return (ulonglong)param_1 << 0x20;
  }
  *param_2 = uVar2;
LAB_20001666:
  *(int *)(param_2 + 4) = *(int *)(param_2 + 4) + 1;
  return (ulonglong)param_1 << 0x20;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000168c @ 2000168c */


void FUN_2000168c(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 local_30;
  undefined4 local_2c;
  undefined4 uStack_28;
  undefined4 uStack_24;
  undefined4 local_20;
  undefined1 auStack_1c [20];
  
  local_30 = 0x33;
  local_2c = param_1;
  uStack_28 = param_2;
  uStack_24 = param_3;
  local_20 = __aeabi_uidiv(param_4,1000);
  FUN_2000692c(&local_30,auStack_1c);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200016b0 @ 200016b0 */


void FUN_200016b0(undefined4 param_1,undefined4 param_2,undefined4 param_3)

{
  undefined4 local_30;
  undefined4 local_2c;
  undefined4 local_28;
  undefined4 local_24;
  undefined1 auStack_1c [24];
  
  local_30 = 0x3b;
  local_2c = param_1;
  local_28 = param_2;
  local_24 = __aeabi_uidiv(param_3,1000);
  FUN_200069ac(&local_30,auStack_1c);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200016d4 @ 200016d4 */


void FUN_200016d4(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 local_30;
  undefined4 local_2c;
  undefined4 uStack_28;
  undefined4 uStack_24;
  undefined4 local_20;
  undefined4 local_1c [5];
  
  local_30 = 0x33;
  local_2c = param_1;
  uStack_28 = param_2;
  uStack_24 = param_3;
  local_20 = __aeabi_uidiv(param_4,1000);
  FUN_2000e7e4(&local_30,local_1c);
  FUN_2000e2d0(local_1c[0]);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200016fe @ 200016fe */


void FUN_200016fe(undefined4 param_1,undefined4 param_2,undefined4 param_3)

{
  undefined4 local_30;
  undefined4 local_2c;
  undefined4 local_28;
  undefined4 local_24;
  undefined4 local_1c [6];
  
  local_30 = 0x3b;
  local_2c = param_1;
  local_28 = param_2;
  local_24 = __aeabi_uidiv(param_3,1000);
  FUN_2000e7e4(&local_30,local_1c);
  FUN_2000e2d0(local_1c[0]);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001728 @ 20001728 */


void FUN_20001728(undefined4 param_1,undefined4 param_2)

{
  undefined4 local_30;
  undefined4 local_2c;
  undefined4 local_28;
  undefined4 local_1c [6];
  
  local_30 = 0x32;
  local_2c = param_1;
  local_28 = param_2;
  FUN_20007574(&local_30,local_1c);
  FUN_2000e2d0(local_1c[0]);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001746 @ 20001746 */


void FUN_20001746(int param_1,int param_2,int param_3,undefined4 param_4)

{
  *(undefined4 *)(param_2 * 0x80 + param_1 + param_3 * 4) = param_4;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001750 @ 20001750 */


void FUN_20001750(int param_1,int param_2,int param_3,undefined4 param_4)

{
  *(undefined4 *)(param_2 * 0x80 + param_1 + param_3 * 4) = param_4;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000175c @ 2000175c */


/* WARNING: Removing unreachable block (ram,0x2000179a) */
/* WARNING: Removing unreachable block (ram,0x200017a0) */
/* WARNING: Removing unreachable block (ram,0x200017a8) */
/* WARNING: Removing unreachable block (ram,0x200017ac) */
/* WARNING: Removing unreachable block (ram,0x200017c0) */
/* WARNING: Removing unreachable block (ram,0x200017d2) */

undefined4 * FUN_2000175c(int param_1,uint param_2,uint param_3,int param_4)

{
  uint uVar1;
  uint uVar2;
  uint *puVar3;
  uint *unaff_r4;
  uint unaff_r7;
  uint unaff_r8;
  uint in_r12;
  uint unaff_lr;
  
  if (param_1 == 0) {
    puVar3 = (uint *)(unaff_r8 & 0xfff7ffff);
    param_2 = param_3 & 0xf | param_2;
    if (((*puVar3 & 1) - 1 & unaff_lr) == 0) {
      puVar3[param_3 + 0x40] = unaff_r7;
      puVar3[param_3 + 0x80] = unaff_r7;
    }
    else {
      param_2 = param_2 | in_r12;
      puVar3[param_3 + 0x40] = param_4 + 0x68U;
      puVar3[param_3 + 0x80] = param_4 + 0x68U;
    }
    unaff_r4[1] = param_2;
    DAT_040005d0 = param_3 + 1;
    *unaff_r4 = 1 << (sbyte)DAT_040005cc;
    *unaff_r4 = unaff_lr;
    DAT_040005c8 = unaff_lr + 1;
    return (undefined4 *)0x0;
  }
  FUN_20001794();
  uVar1 = 0;
  do {
    uVar2 = uVar1 + 1;
    (&DAT_04003368)[uVar1] = 0;
    uVar1 = uVar2;
  } while (uVar2 < 4);
  FUN_20001a38(0x12);
  DAT_40000240 = 0x40000;
  return &DAT_40000200;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001794 @ 20001794 */


undefined4 FUN_20001794(int param_1,uint param_2,uint param_3,uint param_4,uint *param_5)

{
  uint uVar1;
  undefined4 uVar2;
  uint *puVar3;
  int *unaff_r4;
  uint uVar4;
  uint unaff_r7;
  uint unaff_r8;
  uint in_r12;
  uint unaff_lr;
  
  if (param_1 != 0) {
    uVar4 = 0;
    do {
      uVar1 = (uint)(char)(&DAT_2000f428)[uVar4];
      if ((uVar1 != 0xffffff80) && (-1 < (int)uVar1)) {
        DAT_e000e180 = 1 << (uVar1 & 0x1f);
        DataSynchronizationBarrier(0xf);
        InstructionSynchronizationBarrier(0xf);
      }
      *(int *)(param_1 + 0x24) = 1 << (uVar4 & 0xff);
      uVar2 = FUN_20005174((int)(char)(&DAT_2000f428)[uVar4]);
      uVar4 = uVar4 + 1;
    } while (uVar4 < 4);
    return uVar2;
  }
  puVar3 = (uint *)(unaff_r8 & 0xfff7ffff);
  param_2 = param_3 & 0xf | param_2;
  if (((*puVar3 & 1) - 1 & unaff_lr) == 0) {
    puVar3[param_3 + 0x40] = unaff_r7;
    puVar3[param_3 + 0x80] = unaff_r7;
  }
  else {
    param_2 = param_2 | in_r12;
    puVar3[param_3 + 0x40] = param_4;
    puVar3[param_3 + 0x80] = param_4;
  }
  unaff_r4[1] = param_2;
  DAT_040005d0 = param_3 + 1;
  *unaff_r4 = 1 << (sbyte)DAT_040005cc;
  *param_5 = unaff_lr;
  DAT_040005c8 = unaff_lr + 1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200017e0 @ 200017e0 */


void FUN_200017e0(int param_1)

{
  uint uVar1;
  
  uVar1 = DAT_40004028;
  if (uVar1 >> 0x18 != 0) {
    *(undefined4 *)(param_1 + 0x2c) = *(undefined4 *)(param_1 + 0x2c);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200017f4 @ 200017f4 */


void FUN_200017f4(void)

{
  uint uVar1;
  undefined4 uVar2;
  
  uVar2 = FUN_200017e0(&DAT_40004000);
  if (DAT_04003368 != (code *)0x0) {
    (*DAT_04003368)(0,uVar2);
  }
  uVar1 = DAT_40004000;
  if ((uVar1 & 1) == 0) {
    DAT_40004024 = 1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001820 @ 20001820 */


void FUN_20001820(void)

{
  int iVar1;
  undefined4 uVar2;
  
  uVar2 = FUN_200017e0(&DAT_40004000);
  if (DAT_0400336c != (code *)0x0) {
    (*DAT_0400336c)(1,uVar2);
  }
  iVar1 = DAT_40004000;
  if (-1 < iVar1 << 0x1e) {
    DAT_40004024 = 2;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000184c @ 2000184c */


void FUN_2000184c(void)

{
  int iVar1;
  undefined4 uVar2;
  
  uVar2 = FUN_200017e0(&DAT_40004000);
  if (DAT_04003370 != (code *)0x0) {
    (*DAT_04003370)(2,uVar2);
  }
  iVar1 = DAT_40004000;
  if (-1 < iVar1 << 0x1d) {
    DAT_40004024 = 4;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001878 @ 20001878 */


void FUN_20001878(void)

{
  int iVar1;
  undefined4 uVar2;
  
  uVar2 = FUN_200017e0(&DAT_40004000);
  if (DAT_04003374 != (code *)0x0) {
    (*DAT_04003374)(3,uVar2);
  }
  iVar1 = DAT_40004000;
  if (-1 < iVar1 << 0x1c) {
    DAT_40004024 = 8;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200018a4 @ 200018a4 */


void FUN_200018a4(uint param_1)

{
  (&DAT_40000630)[param_1 >> 8] = 1 << (param_1 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200018b8 @ 200018b8 */


void FUN_200018b8(uint param_1)

{
  DAT_40000630 = 0x38000004;
  FUN_200019e4(1,0xb);
  FUN_200019e4(2,0xb);
  FUN_200019e4(4,0xb);
  if (param_1 < 0xb71b01) {
    FUN_200019e4(0,6);
    FUN_200019e4(3,6);
  }
  else if (param_1 < 0x16e3601) {
    FUN_200019e4(0,7);
    FUN_200019e4(3,7);
  }
  else if (param_1 < 0x2255101) {
    FUN_200019e4(0,8);
    FUN_200019e4(3,8);
  }
  else if (param_1 < 0x2dc6c01) {
    FUN_200019e4(0,9);
    FUN_200019e4(3,9);
  }
  else if (param_1 < 0x3938701) {
    FUN_200019e4(0,10);
    FUN_200019e4(3,10);
  }
  else if (param_1 < 0x44aa201) {
    FUN_200019e4(0,0xb);
    FUN_200019e4(3,0xb);
  }
  else if (param_1 < 0x501bd01) {
    FUN_200019e4(0,0xb);
    FUN_200019e4(3,0xb);
  }
  else if (param_1 < 0x5b8d801) {
    FUN_200019e4(0,0xc);
    FUN_200019e4(2,0xc);
    FUN_200019e4(3,0xc);
  }
  else {
    FUN_200019e4(0,0xd);
    FUN_200019e4(2,0xd);
    FUN_200019e4(3,0xd);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200019e4 @ 200019e4 */


void FUN_200019e4(int param_1,uint param_2)

{
  *(uint *)(&DAT_40020000 + param_1 * 4) = param_2 & 0xf;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200019f8 @ 200019f8 */


void FUN_200019f8(uint param_1)

{
  uint uVar1;
  uint uVar2;
  int iVar3;
  
  uVar2 = 1 << (param_1 & 0xff);
  if (1 < param_1 >> 0x10) {
    DAT_40040008 = uVar2;
    do {
      uVar1 = DAT_40040000;
    } while ((uVar2 & ~uVar1) == 0);
    return;
  }
  iVar3 = (param_1 >> 0x10) * 4;
  *(uint *)(&DAT_40000140 + iVar3) = uVar2;
  do {
  } while ((uVar2 & ~*(uint *)(&DAT_40000100 + iVar3)) == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001a38 @ 20001a38 */


void FUN_20001a38(undefined4 param_1)

{
  FUN_20001a48();
  FUN_200019f8(param_1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001a48 @ 20001a48 */


void FUN_20001a48(uint param_1)

{
  uint uVar1;
  uint uVar2;
  int iVar3;
  
  uVar2 = 1 << (param_1 & 0xff);
  if (1 < param_1 >> 0x10) {
    DAT_40040004 = uVar2;
    do {
      uVar1 = DAT_40040000;
    } while ((uVar1 & uVar2) == 0);
    return;
  }
  iVar3 = (param_1 >> 0x10) * 4;
  *(uint *)(&DAT_40000120 + iVar3) = uVar2;
  do {
  } while ((*(uint *)(&DAT_40000100 + iVar3) & uVar2) == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ12_Handler @ 20001a84 */


void IRQ12_Handler(void)

{
                    /* WARNING: Could not recover jumptable at 0x20001a8a. Too many branches */
                    /* WARNING: Treating indirect jump as call */
  (*DAT_040005d4)(&DAT_40085000);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001a94 @ 20001a94 */


undefined4
FUN_20001a94(uint *param_1,uint param_2,ushort param_3,int param_4,uint param_5,uint *param_6)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  uint uVar4;
  uint uVar5;
  
  uVar3 = (param_2 << 0x12) >> 0x1e;
  if (9 < DAT_040005c8) {
    return 1;
  }
  uVar4 = (uint)(param_4 << 0x1c) >> 0x16;
  if (uVar3 == 2) {
    param_1[DAT_040005c8 * 2 + 0xc1] = uVar4 | param_2;
  }
  else {
    uVar5 = (uint)param_3;
    uVar1 = (param_5 << 0x1f) >> 0x1b;
    uVar2 = (uint)param_3 << 0x10;
    if (uVar3 == 1) {
      if (9 < DAT_040005d0) {
        return 1;
      }
      param_2 = DAT_040005d0 & 0xf | param_2;
      if (((*param_1 & 1) - 1 & param_5) == 0) {
        param_1[DAT_040005d0 + 0x40] = uVar5;
        param_1[DAT_040005d0 + 0x80] = uVar5;
      }
      else {
        param_2 = param_2 | uVar1;
        param_1[DAT_040005d0 + 0x40] = uVar2;
        param_1[DAT_040005d0 + 0x80] = uVar2;
      }
      param_1[DAT_040005c8 * 2 + 0xc1] = param_2;
    }
    else {
      if (9 < DAT_040005d0) {
        return 1;
      }
      param_2 = param_2 | DAT_040005d0 & 0xf | uVar4;
      if (((*param_1 & 1) - 1 & param_5) == 0) {
        param_1[DAT_040005d0 + 0x40] = uVar5;
        param_1[DAT_040005d0 + 0x80] = uVar5;
      }
      else {
        param_2 = param_2 | uVar1;
        param_1[DAT_040005d0 + 0x40] = uVar2;
        param_1[DAT_040005d0 + 0x80] = uVar2;
      }
      param_1[DAT_040005c8 * 2 + 0xc1] = param_2;
    }
    DAT_040005d0 = DAT_040005d0 + 1;
  }
  param_1[DAT_040005c8 * 2 + 0xc0] = 1 << (sbyte)DAT_040005cc;
  *param_6 = DAT_040005c8;
  DAT_040005c8 = DAT_040005c8 + 1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001bc4 @ 20001bc4 */


void FUN_20001bc4(undefined1 *param_1)

{
  int iVar1;
  
  if (param_1 != (undefined1 *)0x0) {
    __aeabi_memclr(param_1,8);
    *param_1 = 1;
    param_1[1] = 0;
    param_1[2] = 0;
    param_1[3] = 0;
    param_1[4] = 0;
    param_1[5] = 0;
    param_1[6] = 0;
    param_1[7] = 0;
    return;
  }
  iVar1 = 0;
  do {
    if ((&DAT_2000f438)[iVar1] == 0) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001bec @ 20001bec */


void FUN_20001bec(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f438)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001c14 @ 20001c14 */


undefined4 FUN_20001c14(uint *param_1,byte *param_2,int param_3)

{
  ushort uVar1;
  int iVar2;
  uint *puVar3;
  uint uVar4;
  uint uVar5;
  
  puVar3 = param_1;
  if (param_2 != (byte *)0x0) {
    iVar2 = FUN_20001bec();
    uVar1 = *(ushort *)((int)&DAT_2000f434 + iVar2 * 2);
    param_3 = 1;
    puVar3 = (uint *)(uint)uVar1;
    if (uVar1 >> 8 < 2) {
      (&DAT_40000220)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
      goto LAB_20001c44;
    }
  }
  DAT_40040014 = param_3 << ((uint)puVar3 & 0xff);
LAB_20001c44:
  iVar2 = FUN_20001bec(param_1);
  FUN_20001a38((&DAT_2000f43c)[iVar2]);
  *param_1 = ((uint)param_2[2] << 0x1c) >> 0x19 | ((uint)param_2[1] << 0x1e) >> 0x1d | *param_2 & 1;
  param_1[1] = (((uint)param_2[3] << 0x1f) >> 0x1b | (uint)param_2[5] << 5) + 0xc;
  if (*param_2 == 0) {
    param_1[1] = param_1[1] | ((uint)param_2[4] << 0x1f) >> 0xb | (uint)param_2[6] << 0x15 | 0xc0000
    ;
  }
  param_1[0x14] = (uint)param_2[7];
  DAT_040005c8 = 0;
  DAT_040005cc = 0;
  DAT_040005d0 = 0;
  uVar4 = 0;
  do {
    uVar5 = uVar4 + 1;
    (&DAT_04003378)[uVar4] = 0;
    uVar4 = uVar5;
  } while (uVar5 < 10);
  DAT_040005d4 = &LAB_20001b8c_1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001cd8 @ 20001cd8 */


void FUN_20001cd8(int param_1,int param_2,uint param_3)

{
  param_1 = param_2 * 8 + param_1;
  *(uint *)(param_1 + 0x504) = *(uint *)(param_1 + 0x504) | 1 << (param_3 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001cf8 @ 20001cf8 */


void FUN_20001cf8(int param_1,int param_2,uint param_3)

{
  uint *puVar1;
  
  puVar1 = (uint *)(param_2 * 8 + param_1 + 0x500);
  *puVar1 = *puVar1 | 1 << (param_3 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001d18 @ 20001d18 */


undefined4
FUN_20001d18(uint *param_1,byte *param_2,int param_3,int param_4,undefined4 param_5,uint *param_6)

{
  undefined4 uVar1;
  int iVar2;
  uint uVar3;
  uint local_20;
  undefined4 local_1c;
  int local_18;
  
  uVar1 = __aeabi_uidiv(param_5,((param_1[1] << 0x13) >> 0x18) + 1);
  local_20 = 0;
  local_1c = 0;
  if ((10 < DAT_040005c8 + 2U) || (param_2[2] == 0)) {
    return 1;
  }
  *param_1 = *param_1 | 1;
  if (param_3 == 1) {
    param_1[1] = param_1[1] | 0x10;
  }
  else if (param_3 == 0) {
    iVar2 = __aeabi_uidiv(uVar1,param_4);
    iVar2 = iVar2 + -1;
    goto LAB_20001d82;
  }
  iVar2 = __aeabi_uidiv(uVar1,param_4 << 1);
LAB_20001d82:
  uVar3 = (uint)param_2[2];
  local_18 = __aeabi_uidiv(iVar2 * uVar3,100);
  if (99 < uVar3) {
    local_18 = iVar2 + 2;
  }
  FUN_20001a94(param_1,0x1000,iVar2,0,0,&local_20);
  FUN_20001a94(param_1,0x1000,local_18,0,0,&local_1c);
  param_1[2] = param_1[2] | 1 << (local_20 & 0xff) & 0xffffU;
  *param_6 = local_20;
  if (param_2[1] == 1) {
    param_1[0x14] = param_1[0x14] & ~(1 << *param_2);
    if (param_3 == 0) {
      FUN_20001cf8(param_1,*param_2,local_20);
      FUN_20001cd8(param_1,*param_2,local_1c);
      return 0;
    }
    FUN_20001cd8(param_1,*param_2,local_1c);
  }
  else {
    param_1[0x14] = param_1[0x14] | 1 << *param_2;
    if (param_3 == 0) {
      FUN_20001cd8(param_1,*param_2,local_20);
      FUN_20001cf8(param_1,*param_2,local_1c);
      return 0;
    }
    FUN_20001cf8(param_1,*param_2,local_1c);
  }
  param_1[0x15] =
       1 << ((uint)*param_2 << 1 & 0xff) | param_1[0x15] & ~(3 << ((uint)*param_2 << 1 & 0xff));
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001e60 @ 20001e60 */


void FUN_20001e60(void)

{
  undefined4 uVar1;
  undefined1 local_20;
  undefined1 local_1f;
  undefined1 local_1e;
  undefined1 auStack_1c [8];
  
  DAT_40000224 = 4;
  FUN_20001a38(0x10002);
  uVar1 = FUN_2000063c(1);
  FUN_20001bc4(auStack_1c);
  FUN_20001c14(&DAT_40085000,auStack_1c);
  local_1f = 1;
  local_1e = 100;
  local_20 = 4;
  FUN_20001d18(&DAT_40085000,&local_20,0,20000,uVar1,&DAT_040003f8);
  local_20 = 5;
  FUN_20001d18(&DAT_40085000,&local_20,0,20000,uVar1,&DAT_040003fc);
  FUN_20000e80(0,DAT_040003f8);
  FUN_20000e80(0,DAT_040003fc);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001ef0 @ 20001ef0 */


void FUN_20001ef0(void)

{
  uint uVar1;
  int iVar2;
  
  if ((DAT_04000d48 & 1) != 0) {
    iVar2 = FUN_2000e154();
    DAT_40009008 = 0;
    DAT_40009000 = 1;
    uVar1 = DAT_40009004;
    DAT_40009004 = uVar1 | 1;
    if (iVar2 != 0) {
      DAT_04000394 = 0;
      DAT_04000d65 = 2;
      DAT_04000398 = DAT_04000398 + 1;
      FUN_20007964();
      FUN_200054e0();
      FUN_200081b4();
      DAT_04000d62 = DAT_04000d62 + '\x01';
      if (((byte)DAT_04000330 & 7) == 0) {
        DAT_04000360 = DAT_04000360 + 1;
      }
      if (CONCAT11(DAT_04000d44,DAT_04000d43) != 0) {
        iVar2 = CONCAT11(DAT_04000d44,DAT_04000d43) - 1;
        DAT_04000d43 = (undefined1)iVar2;
        DAT_04000d44 = (undefined1)((uint)iVar2 >> 8);
      }
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001f74 @ 20001f74 */


void FUN_20001f74(int param_1,int param_2)

{
  uint uVar1;
  
  uVar1 = *(uint *)(param_1 + 0x400);
  if (param_2 == 0) {
    uVar1 = uVar1 & 0xfffffffe;
  }
  else {
    uVar1 = uVar1 | 1;
  }
  *(uint *)(param_1 + 0x400) = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001f90 @ 20001f90 */


void FUN_20001f90(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f390)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 < 8);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001fb0 @ 20001fb0 */


/* WARNING: Removing unreachable block (ram,0x20001ff2) */
/* WARNING: Removing unreachable block (ram,0x20001ff6) */
/* WARNING: Removing unreachable block (ram,0x20001ffa) */
/* WARNING: Removing unreachable block (ram,0x20002004) */
/* WARNING: Removing unreachable block (ram,0x20002012) */
/* WARNING: Removing unreachable block (ram,0x2000201c) */
/* WARNING: Removing unreachable block (ram,0x2000209e) */
/* WARNING: Removing unreachable block (ram,0x200020d0) */

undefined1 * FUN_20001fb0(undefined1 *param_1)

{
  uint uVar1;
  int iVar2;
  uint uVar3;
  int extraout_r2;
  undefined8 uVar4;
  
  if (param_1 != (undefined1 *)0x0) {
    *param_1 = 0;
    param_1[1] = 1;
    param_1[2] = 1;
    param_1[3] = 1;
    param_1[4] = 0;
    *(undefined4 *)(param_1 + 8) = 4000000;
    param_1[0xc] = 7;
    param_1[0xd] = 0;
    param_1[0x10] = 0;
    param_1[0x11] = 0;
    *(undefined2 *)(param_1 + 0xe) = 0;
    param_1[0x12] = 0;
    param_1[0x13] = 0;
    param_1[0x14] = 0;
    param_1[0x15] = 0;
    return param_1;
  }
  uVar4 = func_0x200450da();
  uVar4 = func_0x201020c4((int)uVar4 << 0x10,(int)((ulonglong)uVar4 >> 0x20) + 0x98);
  uVar1 = (uint)uVar4;
  uVar3 = uVar1;
  if (((uVar1 != 0) && ((int)((ulonglong)uVar4 >> 0x20) != 0)) && (extraout_r2 != 0)) {
    iVar2 = __aeabi_uidiv(extraout_r2);
    uVar3 = iVar2 - 1U;
    if (0xffff < iVar2 - 1U) {
      return (undefined1 *)0x15e3;
    }
  }
  *(uint *)(uVar1 + 0x424) = *(uint *)(uVar1 + 0x424) & 0xffff0000;
  *(uint *)(uVar1 + 0x424) = *(uint *)(uVar1 + 0x424) | uVar3 & 0xffff;
  return (undefined1 *)0x0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20001fe8 @ 20001fe8 */


int FUN_20001fe8(int param_1,byte *param_2,int param_3,undefined4 param_4)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  uint *puVar4;
  int extraout_r2;
  undefined8 uVar5;
  
  if ((((param_1 != 0) && (param_2 != (byte *)0x0)) && (param_3 != 0)) &&
     (iVar1 = FUN_20001098(param_1,2,param_3,param_4,param_4), iVar1 == 0)) {
    iVar1 = FUN_200020e4(param_1,*(undefined4 *)(param_2 + 8),param_3);
    if (iVar1 != 0) {
      return iVar1;
    }
    iVar1 = FUN_20001f90(param_1);
    if (-1 < iVar1) {
      *(uint *)(param_1 + 0x400) =
           *(ushort *)(param_2 + 0xe) & 0xf00 |
           ((uint)*param_2 << 0x1f) >> 0x18 |
           ((uint)param_2[4] << 0x1f) >> 0x1c |
           ((uint)param_2[2] << 0x1f) >> 0x1a |
           ((uint)param_2[3] << 0x1f) >> 0x1b | *(uint *)(param_1 + 0x400) & 0xfffff042 | 4;
      (&DAT_04003198)[iVar1 * 2] = param_2[0xc];
      (&DAT_04003199)[iVar1 * 2] = param_2[0xd];
      puVar4 = (uint *)(param_1 + 0xe00);
      *puVar4 = *puVar4 | 0x30000;
      *puVar4 = *puVar4 | 3;
      *(uint *)(param_1 + 0xe08) =
           ((uint)param_2[0x10] << 0x1c) >> 0x14 | ((uint)param_2[0x11] << 0x1c) >> 0xc |
           *(uint *)(param_1 + 0xe08) & 0xfff0f0ff | 3;
      if (param_2 + 0x12 != (byte *)0x0) {
        *(uint *)(param_1 + 0x404) =
             param_2[0x12] & 0xf | ((uint)param_2[0x13] << 0x1c) >> 0x18 |
             ((uint)param_2[0x14] << 0x1c) >> 0x14 | ((uint)param_2[0x15] << 0x1c) >> 0x10;
        FUN_20002344(param_1,0xff);
        FUN_20001f74(param_1,param_2[1]);
        return 0;
      }
    }
  }
  uVar5 = func_0x200450da();
  uVar5 = func_0x201020c4((int)uVar5 << 0x10,(int)((ulonglong)uVar5 >> 0x20) + 0x98);
  uVar2 = (uint)uVar5;
  uVar3 = uVar2;
  if (((uVar2 != 0) && ((int)((ulonglong)uVar5 >> 0x20) != 0)) && (extraout_r2 != 0)) {
    iVar1 = __aeabi_uidiv(extraout_r2);
    uVar3 = iVar1 - 1U;
    if (0xffff < iVar1 - 1U) {
      return 0x15e3;
    }
  }
  *(uint *)(uVar2 + 0x424) = *(uint *)(uVar2 + 0x424) & 0xffff0000;
  *(uint *)(uVar2 + 0x424) = *(uint *)(uVar2 + 0x424) | uVar3 & 0xffff;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200020e4 @ 200020e4 */


undefined4 FUN_200020e4(uint param_1,int param_2,int param_3)

{
  int iVar1;
  uint uVar2;
  
  uVar2 = param_1;
  if (((param_1 != 0) && (param_2 != 0)) && (param_3 != 0)) {
    iVar1 = __aeabi_uidiv(param_3);
    uVar2 = iVar1 - 1U;
    if (0xffff < iVar1 - 1U) {
      return 0x15e3;
    }
  }
  *(uint *)(param_1 + 0x424) = *(uint *)(param_1 + 0x424) & 0xffff0000;
  *(uint *)(param_1 + 0x424) = *(uint *)(param_1 + 0x424) | uVar2 & 0xffff;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000212c @ 2000212c */


undefined4 FUN_2000212c(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  undefined1 *puVar2;
  int unaff_r5;
  
  if ((param_1 != 0) && (param_2 != 0)) {
    unaff_r5 = FUN_20001f90();
  }
  __aeabi_memclr(param_2,0x30);
  if (*(int *)(param_1 + 0x400) << 0x1d < 0) {
    puVar2 = (undefined1 *)0x200021cd;
  }
  else {
    puVar2 = &LAB_20002358_1;
  }
  FUN_200010e4(param_1,puVar2,param_2);
  *(undefined *)(param_2 + 0x24) = (&DAT_04003198)[unaff_r5 * 2];
  *(undefined *)(param_2 + 0x25) = (&DAT_04003199)[unaff_r5 * 2];
  *(byte *)(param_2 + 0x2c) = (byte)((uint)(*(int *)(param_1 + 0xe08) << 0x14) >> 0x1c);
  *(byte *)(param_2 + 0x2d) = (byte)((uint)(*(int *)(param_1 + 0xe08) << 0xc) >> 0x1c);
  *(undefined4 *)(param_2 + 0x1c) = param_3;
  *(undefined4 *)(param_2 + 0x20) = param_4;
  uVar1 = (uint)(char)(&DAT_2000f388)[unaff_r5];
  if ((uVar1 != 0xffffff80) && (-1 < (int)uVar1)) {
    DAT_e000e100 = 1 << (uVar1 & 0x1f);
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200021cc @ 200021cc */


void FUN_200021cc(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  int unaff_r5;
  int unaff_r6;
  uint unaff_r7;
  
  if ((param_1 != 0) && (param_2 != 0)) {
    unaff_r7 = 0xf0000;
    unaff_r6 = param_2 + 0x20;
    unaff_r5 = param_1 + 0xe00;
    if (*(int *)(param_2 + 8) != 0) goto LAB_200021fe;
  }
  if ((*(int *)(param_2 + 0xc) == 0) && (*(int *)(param_2 + 0x10) == 0)) {
    *(undefined4 *)(unaff_r5 + 0x14) = 0xc;
    *(uint *)(unaff_r5 + 8) =
         *(uint *)(unaff_r5 + 8) & ~unaff_r7 | ((uint)*(byte *)(unaff_r6 + 0xd) << 0x1c) >> 0xc |
         ((uint)*(byte *)(unaff_r6 + 0xc) << 0x1c) >> 0x14;
    *(undefined4 *)(param_2 + 0x18) = 0x15e1;
    if (*(code **)(param_2 + 0x1c) == (code *)0x0) {
      return;
    }
    (**(code **)(param_2 + 0x1c))
              (param_1,param_2,*(undefined4 *)(param_2 + 0x18),*(undefined4 *)(param_2 + 0x20),
               param_4);
    return;
  }
LAB_200021fe:
  FUN_20002360(param_1,param_2);
  if (((*(int *)(param_2 + 8) == 0) && (*(int *)(param_2 + 0xc) == 0)) &&
     (*(int *)(param_2 + 0x10) == 0)) {
    *(uint *)(unaff_r5 + 8) = *(uint *)(unaff_r5 + 8) & 0xfffff0ff;
    *(uint *)(unaff_r5 + 0x10) = *(uint *)(unaff_r5 + 0x10) | 4;
    return;
  }
  uVar1 = *(uint *)(param_2 + 0xc) >> (uint)(*(byte *)(unaff_r6 + 4) >> 3);
  if ((*(int *)(param_2 + 8) == 0) && (uVar1 <= *(uint *)(param_2 + 0x10))) {
    *(undefined4 *)(unaff_r5 + 0x14) = 4;
  }
  if (uVar1 == 0) {
    if (((*(int *)(param_2 + 8) == 0) && (*(int *)(param_2 + 0x10) != 0)) &&
       (*(uint *)(param_2 + 0x10) < ((uint)(*(int *)(unaff_r5 + 8) << 0xc) >> 0x1c) + 1)) {
      *(uint *)(unaff_r5 + 8) =
           *(uint *)(unaff_r5 + 8) & ~unaff_r7 |
           (uint)((*(int *)(param_2 + 0x10) + -1) * 0x10000000) >> 0xc;
      return;
    }
  }
  else {
    if (((uint)(*(int *)(unaff_r5 + 8) << 0xc) >> 0x1c) + 1 <= uVar1) {
      return;
    }
    *(uint *)(unaff_r5 + 8) = *(uint *)(unaff_r5 + 8) & ~unaff_r7 | (uVar1 - 1) * 0x10000000 >> 0xc;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200022c0 @ 200022c0 */


undefined4 FUN_200022c0(int param_1,int *param_2,int *param_3,int param_4)

{
  undefined4 uVar1;
  int iVar2;
  
  if (((param_1 != 0) && (param_2 != (int *)0x0)) && (param_3 != (int *)0x0)) {
    param_4 = *param_3;
  }
  uVar1 = 0x15e0;
  if (param_2[6] != 0x15e0) {
    *param_2 = param_4;
    param_2[1] = param_3[1];
    iVar2 = *param_3;
    if (iVar2 != 0) {
      iVar2 = param_3[3];
    }
    param_2[2] = iVar2;
    iVar2 = param_3[1];
    if (iVar2 != 0) {
      iVar2 = param_3[3];
    }
    param_2[3] = iVar2;
    param_2[5] = param_3[3];
    param_2[4] = 0;
    param_2[10] = param_3[2];
    param_2[6] = 0x15e0;
    *(uint *)(param_1 + 0xe00) = *(uint *)(param_1 + 0xe00) | 0x30000;
    *(uint *)(param_1 + 0xe04) = *(uint *)(param_1 + 0xe04) | 3;
    *(uint *)(param_1 + 0xe10) = *(uint *)(param_1 + 0xe10) | 0xc;
    uVar1 = 0;
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002344 @ 20002344 */


void FUN_20002344(undefined4 param_1,undefined1 param_2)

{
  int iVar1;
  
  iVar1 = FUN_20001f90();
  (&DAT_040005ac)[iVar1] = param_2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002360 @ 20002360 */


void FUN_20002360(int param_1,int *param_2)

{
  byte bVar1;
  int iVar2;
  int *extraout_r2;
  int *piVar3;
  uint *extraout_r3;
  uint *puVar4;
  uint uVar5;
  int unaff_r6;
  undefined1 *puVar6;
  byte *pbVar7;
  uint uVar8;
  uint uVar9;
  undefined8 uVar10;
  
  uVar9 = 0x2000236b;
  uVar10 = FUN_20001f90();
  iVar2 = (int)uVar10;
  piVar3 = extraout_r2;
  puVar4 = extraout_r3;
  if (param_1 == 0) goto LAB_2000240e;
  if (param_2 == (int *)0x0) goto LAB_2000240e;
  if ((*param_2 == 0) &&
     (uVar10 = CONCAT44((int)((ulonglong)uVar10 >> 0x20),param_2[1]), param_2[1] == 0))
  goto LAB_2000240e;
  puVar4 = (uint *)(param_1 + 0xe00);
  uVar9 = *puVar4 >> 1 & 0x18;
  piVar3 = param_2 + 8;
  uVar10 = CONCAT44(((uint)(param_2[10] << 10) >> 0x1f) << 0x15 |
                    ((uint)*(byte *)(param_2 + 9) << 0x1c) >> 4 |
                    ~(1 << (*(byte *)((int)param_2 + 0x25) + 0x10 & 0xff)) & 0xf0000U,
                    ((uint)(param_2[10] << 0xb) >> 0x1f) << 0x14);
  do {
    while( true ) {
      unaff_r6 = 0;
      if ((int)(puVar4[1] << 0x19) < 0) {
        uVar5 = puVar4[0xc];
        if (param_2[3] != 0) {
          puVar6 = (undefined1 *)param_2[1];
          param_2[1] = (int)(puVar6 + 1);
          *puVar6 = (char)uVar5;
          param_2[3] = param_2[3] + -1;
          if (7 < *(byte *)(piVar3 + 1)) {
            puVar6 = (undefined1 *)param_2[1];
            param_2[1] = (int)(puVar6 + 1);
            *puVar6 = (char)(uVar5 >> 8);
            param_2[3] = param_2[3] + -1;
          }
        }
        param_2[4] = param_2[4] + -1;
        unaff_r6 = 1;
      }
      if (((int)(puVar4[1] << 0x1a) < 0) && ((uint)param_2[4] < uVar9)) break;
LAB_20002480:
      if (unaff_r6 == 0) {
        return;
      }
    }
    if (param_2[2] == 0) {
LAB_2000240e:
      if ((uint)param_2[3] < (uint)(param_2[4] + 1 << (uint)(*(byte *)(piVar3 + 1) >> 3)))
      goto LAB_20002480;
    }
    uVar5 = (uint)((ulonglong)uVar10 >> 0x20);
    if (param_2[2] == 0) {
      uVar8 = (uint)CONCAT11((&DAT_040005ac)[iVar2],(&DAT_040005ac)[iVar2]);
      if (param_2[4] + 1 << (uint)(*(byte *)(piVar3 + 1) >> 3) == param_2[3]) goto LAB_20002470;
    }
    else {
      pbVar7 = (byte *)*param_2;
      *param_2 = (int)(pbVar7 + 1);
      bVar1 = *pbVar7;
      uVar8 = (uint)bVar1;
      param_2[2] = param_2[2] + -1;
      if (7 < *(byte *)(piVar3 + 1)) {
        puVar6 = (undefined1 *)*param_2;
        *param_2 = (int)(puVar6 + 1);
        uVar8 = (uint)CONCAT11(*puVar6,bVar1);
        param_2[2] = param_2[2] + -1;
      }
      if (param_2[2] == 0) {
LAB_20002470:
        uVar5 = uVar5 | (uint)uVar10;
      }
    }
    uVar10 = CONCAT44(uVar5,(uint)uVar10);
    puVar4[8] = uVar5 | uVar8;
    param_2[4] = param_2[4] + 1;
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* SystemInit @ 2000248c */


/* VTOR = 0x20000000 (application vector table) */

void SystemInit(void)

{
  DAT_e000ed08 = 0x20000000;
  return;
}


/* ---------------------------------------------------------------------- */
/* delay_ms @ 2000249c */


/* busy wait n ms, feeds watchdog each ms */

void delay_ms(short param_1)

{
  while (param_1 != 0) {
    wdt_feed();
    delay_us(1000);
    param_1 = param_1 + -1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* delay_us @ 200024bc */


/* SysTick polled delay */

void delay_us(int param_1)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = __aeabi_uidiv(SystemCoreClock,1000000);
  uVar2 = param_1 * iVar1 - 1;
  while( true ) {
    if (uVar2 == 0) {
      return;
    }
    if (uVar2 < 0xffffff) break;
    DAT_e000e018 = 0xffffff;
    DAT_e000e014 = 0xffffff;
    DAT_e000e010 = 5;
    do {
      iVar1 = DAT_e000e010;
    } while (-1 < iVar1 << 0xf);
    DAT_e000e010 = 0;
    uVar2 = uVar2 - 0xffffff;
  }
  DAT_e000e018 = uVar2;
  DAT_e000e014 = uVar2;
  DAT_e000e010 = 5;
  do {
    iVar1 = DAT_e000e010;
  } while (-1 < iVar1 << 0xf);
  DAT_e000e010 = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ28_Handler @ 20002514 */


void IRQ28_Handler(void)

{
  uint uVar1;
  
  FUN_2000475c(DAT_040009e0);
  uVar1 = DAT_40084024;
  DAT_40084024 = uVar1 | 0x40000000;
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ27_Handler @ 20002534 */


void IRQ27_Handler(void)

{
  FUN_20005144(0x1b);
  DAT_04000d45 = DAT_04000d45 | 0x40;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000254c @ 2000254c */


void FUN_2000254c(void)

{
  uint uVar1;
  
  while (uVar1 = DAT_40000410, (uVar1 & 1) != 0) {
    wdt_feed();
  }
  uVar1 = DAT_4000040c;
  DAT_4000040c = uVar1 | 2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000256c @ 2000256c */


undefined4 FUN_2000256c(uint param_1,undefined4 *param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 local_10;
  
  local_10 = param_4;
  FUN_20004c30(&local_10);
  iVar1 = 0;
  while( true ) {
    if (((&DAT_040033d0)[iVar1 * 0x26] != 0) && ((byte)(&DAT_04003455)[iVar1 * 0x98] == param_1))
    break;
    iVar1 = iVar1 + 1;
    if (iVar1 != 0) {
      iVar1 = 0;
      do {
        if ((&DAT_040033d0)[iVar1 * 0x26] == 0) {
          (&DAT_04003455)[iVar1 * 0x98] = (char)param_1;
          *param_2 = &DAT_040033c8 + iVar1 * 0x98;
          FUN_20004c3c(local_10);
          return 0;
        }
        iVar1 = iVar1 + 1;
      } while (iVar1 == 0);
      FUN_20004c3c(local_10);
      return 2;
    }
  }
  FUN_20004c3c(local_10);
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_200025d4 @ 200025d4 */


void FUN_200025d4(void)

{
  int iVar1;
  
  FUN_2000e348();
  FUN_20002e10();
  DAT_040009f4 = 0;
  DAT_040009f5 = 0;
  DAT_040009e4 = 0;
  DAT_040009e8 = 0;
  DAT_040009ec = 0;
  DAT_040009f0 = 0;
  DAT_040009e0 = 0;
  iVar1 = FUN_20002d60(4,&DAT_0400030c,&DAT_040009e0);
  if (iVar1 == 0) {
    DAT_040009e4 = *(undefined4 *)(DAT_0400030c + 4);
    DAT_040009e8 = *(undefined4 *)(DAT_0400030c + 0x10);
    DAT_040009ec = *(undefined4 *)(DAT_0400030c + 0x1c);
    DAT_040009f0 = *(undefined4 *)(DAT_0400030c + 0x28);
    DAT_040002fc = &DAT_040009e0;
    DAT_04000300 = &DAT_040009e0;
    DAT_04000304 = &DAT_040009e0;
    DAT_04000308 = &DAT_040009e0;
    FUN_200038cc();
    FUN_20004afa(DAT_040009e0);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002b80 @ 20002b80 */


undefined4 FUN_20002b80(uint param_1,undefined4 *param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 local_10;
  
  local_10 = param_4;
  FUN_20004c30(&local_10);
  iVar1 = 0;
  while( true ) {
    if (((&DAT_040049c0)[iVar1 * 4] != 0) && ((byte)(&DAT_040049ce)[iVar1 * 0x10] == param_1))
    break;
    iVar1 = iVar1 + 1;
    if (iVar1 != 0) {
      iVar1 = 0;
      do {
        if ((&DAT_040049c0)[iVar1 * 4] == 0) {
          (&DAT_040049ce)[iVar1 * 0x10] = (char)param_1;
          *(undefined **)(iVar1 * 0x10 + 0x40049c8) = &DAT_04004a00 + iVar1 * 0x40;
          *param_2 = &DAT_040049c0 + iVar1 * 4;
          FUN_20004c3c(local_10);
          return 0;
        }
        iVar1 = iVar1 + 1;
      } while (iVar1 == 0);
      FUN_20004c3c(local_10);
      return 2;
    }
  }
  FUN_20004c3c(local_10);
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002be8 @ 20002be8 */


void FUN_20002be8(undefined4 param_1,int param_2,undefined4 param_3,int param_4)

{
  int iVar1;
  int local_18;
  
  local_18 = param_4;
  iVar1 = FUN_20002d24(param_1,&local_18);
  if (iVar1 == 0) {
    if (param_2 == 1) {
      FUN_20003048(param_1,local_18);
      FUN_20002c20(param_1,2,local_18);
    }
    (**(code **)(*(int *)(local_18 + 4) + 4))(param_1,param_2,param_3);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002c20 @ 20002c20 */


undefined4 FUN_20002c20(undefined4 param_1,undefined4 param_2,int param_3)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  undefined4 uVar4;
  int local_28 [2];
  undefined4 uStack_20;
  undefined4 local_1c;
  int local_18;
  
  uVar4 = 1;
  if ((param_3 == 0) ||
     (uStack_20 = param_1, local_1c = param_2, local_18 = param_3,
     iVar1 = FUN_20002d24(param_1,local_28), iVar1 != 0)) {
    uVar4 = 4;
  }
  else {
    for (uVar3 = 0; uVar3 < *(byte *)(*(int **)(local_28[0] + 4) + 2); uVar3 = uVar3 + 1 & 0xff) {
      uVar2 = 0;
      iVar1 = **(int **)(local_28[0] + 4);
      do {
        if (*(char *)(*(int *)(iVar1 + uVar3 * 0xc + 8) + 4) == (&DAT_2000ea2c)[uVar2 * 0x10]) {
          iVar1 = (*(code *)(&DAT_2000ea28)[uVar2 * 4])
                            (*(undefined4 *)(iVar1 + uVar3 * 0xc + 4),local_1c,local_18);
          if (iVar1 == 5) {
            return 5;
          }
          if (iVar1 == 0) {
            uVar4 = 0;
          }
          break;
        }
        uVar2 = uVar2 + 1 & 0xff;
      } while (uVar2 < 2);
    }
  }
  return uVar4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002c98 @ 20002c98 */


undefined4 FUN_20002c98(uint param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 local_10;
  
  iVar1 = 0;
  local_10 = param_4;
  FUN_20004c30(&local_10);
  while( true ) {
    if (((&DAT_040049c0)[iVar1 * 4] != 0) && ((byte)(&DAT_040049ce)[iVar1 * 0x10] == param_1))
    break;
    iVar1 = iVar1 + 1;
    if (iVar1 != 0) {
      FUN_20004c3c(local_10);
      return 4;
    }
  }
  (&DAT_040049c0)[iVar1 * 4] = 0;
  (&DAT_040049c4)[iVar1 * 4] = 0;
  (&DAT_040049ce)[iVar1 * 0x10] = 0;
  FUN_20004c3c(local_10);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002ce0 @ 20002ce0 */


undefined4 FUN_20002ce0(uint param_1,undefined4 *param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 local_18;
  
  iVar1 = 0;
  local_18 = param_4;
  FUN_20004c30(&local_18);
  while( true ) {
    if (((&DAT_040049c0)[iVar1 * 4] != 0) && ((byte)(&DAT_040049ce)[iVar1 * 0x10] == param_1))
    break;
    iVar1 = iVar1 + 1;
    if (iVar1 != 0) {
      FUN_20004c3c(local_18);
      return 4;
    }
  }
  *param_2 = (&DAT_040049c0)[iVar1 * 4];
  FUN_20004c3c(local_18);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002d24 @ 20002d24 */


undefined4 FUN_20002d24(int param_1,undefined4 *param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 local_18;
  
  iVar1 = 0;
  local_18 = param_4;
  FUN_20004c30(&local_18);
  do {
    if ((&DAT_040049c0)[iVar1 * 4] == param_1) {
      *param_2 = &DAT_040049c0 + iVar1 * 4;
      FUN_20004c3c(local_18);
      return 0;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  FUN_20004c3c(local_18);
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002d60 @ 20002d60 */


int FUN_20002d60(undefined4 param_1,int param_2,undefined4 *param_3)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  undefined4 *local_30;
  int local_2c;
  int local_28;
  int local_24;
  undefined4 local_20;
  int iStack_1c;
  undefined4 *local_18;
  
  if (((param_3 == (undefined4 *)0x0) || (param_2 == 0)) || (*(int *)(param_2 + 4) == 0)) {
    local_2c = 4;
  }
  else {
    local_20 = param_1;
    iStack_1c = param_2;
    local_18 = param_3;
    local_2c = FUN_20002b80(param_1,&local_30);
    if (local_2c == 0) {
      local_30[1] = param_2;
      local_2c = FUN_200037a4(local_20,0x20002be9);
      if (local_2c == 0) {
        for (uVar3 = 0; uVar3 < *(byte *)(local_30[1] + 8); uVar3 = uVar3 + 1 & 0xff) {
          iVar4 = uVar3 * 0xc;
          local_24 = iVar4 + 8;
          uVar2 = 0;
          local_28 = iVar4 + 4;
          do {
            iVar1 = *(int *)local_30[1];
            if (*(char *)(*(int *)(iVar1 + local_24) + 4) == (&DAT_2000ea2c)[uVar2 * 0x10]) {
              (*(code *)(&PTR_FUN_20003538_1_2000ea20)[uVar2 * 4])
                        (local_20,iVar1 + iVar4,iVar1 + local_28);
            }
            uVar2 = uVar2 + 1 & 0xff;
          } while (uVar2 < 2);
        }
        *local_18 = *local_30;
      }
      else {
        FUN_2000309c(*local_30);
        FUN_20002c98(local_20);
      }
    }
  }
  return local_2c;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002e10 @ 20002e10 */


void FUN_20002e10(void)

{
  uint uVar1;
  undefined4 uVar2;
  
  uVar2 = FUN_2000063c(2);
  FUN_200004b4(2,uVar2);
  uVar1 = DAT_40000500;
  DAT_40000500 = uVar1 & 0xfeffffff;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002e34 @ 20002e34 */


undefined4 FUN_20002e34(int param_1)

{
  undefined4 uVar1;
  
  if (param_1 == 0) {
    return 3;
  }
  if (*(int *)(param_1 + 0xc) != 0) {
                    /* WARNING: Could not recover jumptable at 0x20002e42. Too many branches */
                    /* WARNING: Treating indirect jump as call */
    uVar1 = (**(code **)(*(int *)(param_1 + 0xc) + 0x14))(*(undefined4 *)(param_1 + 8));
    return uVar1;
  }
  return 6;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002e4c @ 20002e4c */


undefined4 FUN_20002e4c(undefined4 param_1,undefined4 *param_2,int param_3)

{
  byte bVar1;
  short sVar2;
  byte *pbVar3;
  uint uVar4;
  undefined4 uVar5;
  int extraout_r2;
  byte *pbVar6;
  int iVar7;
  bool bVar8;
  int iVar9;
  undefined4 local_40;
  uint local_3c;
  char local_38 [4];
  byte *local_34;
  undefined4 local_30;
  uint local_2c;
  undefined1 local_28;
  undefined4 local_20;
  undefined4 *puStack_1c;
  int iStack_18;
  
  local_40 = 0;
  local_3c = 0;
  iVar7 = 5;
  bVar8 = param_2[1] == -1;
  local_20 = param_1;
  puStack_1c = param_2;
  iStack_18 = param_3;
  do {
    do {
      if (bVar8) {
        return 5;
      }
      bVar8 = param_3 == 0;
    } while (bVar8);
    pbVar6 = *(byte **)(param_3 + 8);
    iVar9 = param_3;
    FUN_200031a4(local_20,6,local_38);
    if (*(char *)(param_2 + 2) == '\0') {
      if (local_38[0] == '\x03') {
        uVar5 = (*(code *)(&PTR_LAB_20002924_1_2000e800)[pbVar6[1]])
                          (iVar9,pbVar6,&local_40,&local_3c);
        return uVar5;
      }
      if (param_2[1] == 0) {
        return 5;
      }
      if (*(short *)(pbVar6 + 6) == 0) {
        return 5;
      }
      uVar4 = (uint)*pbVar6;
      if ((int)(uVar4 << 0x18) < 0) {
        return 5;
      }
      if ((int)(uVar4 << 0x1a) < 0) {
        local_30 = *param_2;
        local_28 = 0;
        local_2c = param_2[1];
        local_34 = pbVar6;
        iVar7 = FUN_20002c20(local_20,1,&local_34);
      }
      else if ((int)(uVar4 << 0x19) < 0) {
        local_30 = *param_2;
        local_28 = 0;
        local_2c = param_2[1];
        local_34 = pbVar6;
        iVar7 = FUN_20002be8(local_20,0x13,&local_34);
      }
      uVar5 = 1;
      goto LAB_20002fd4;
    }
    if (param_2[1] != 8) {
      return 5;
    }
    pbVar3 = (byte *)*param_2;
    bVar8 = pbVar3 == (byte *)0x0;
    param_3 = extraout_r2;
  } while (bVar8);
  *(undefined2 *)(pbVar6 + 2) = *(undefined2 *)(pbVar3 + 2);
  *(undefined2 *)(pbVar6 + 4) = *(undefined2 *)(pbVar3 + 4);
  sVar2 = *(short *)(pbVar3 + 6);
  *(short *)(pbVar6 + 6) = sVar2;
  bVar1 = pbVar3[1];
  pbVar6[1] = bVar1;
  uVar4 = (uint)*pbVar3;
  *pbVar6 = *pbVar3;
  if ((uVar4 << 0x19) >> 0x1e == 0) {
    if ((code *)(&PTR_LAB_20002924_1_2000e800)[bVar1] != (code *)0x0) {
      iVar7 = (*(code *)(&PTR_LAB_20002924_1_2000e800)[bVar1])(iVar9,pbVar6,&local_40,&local_3c);
    }
  }
  else if ((sVar2 == 0) || ((int)(uVar4 << 0x18) < 0)) {
    if ((int)(uVar4 << 0x1a) < 0) {
      local_30 = 0;
      local_28 = 1;
      local_2c = (uint)*(ushort *)(pbVar6 + 6);
      local_34 = pbVar6;
      iVar7 = FUN_20002c20(local_20,1,&local_34);
    }
    else {
      if (-1 < (int)(uVar4 << 0x19)) goto LAB_20002f50;
      local_30 = 0;
      local_28 = 1;
      local_2c = (uint)*(ushort *)(pbVar6 + 6);
      local_34 = pbVar6;
      iVar7 = FUN_20002be8(local_20,0x13,&local_34);
    }
    local_3c = local_2c;
    local_40 = local_30;
  }
  else {
    if ((int)(uVar4 << 0x1a) < 0) {
      local_30 = 0;
      local_28 = 1;
      local_2c = (uint)*(ushort *)(pbVar6 + 6);
      local_34 = pbVar6;
      iVar7 = FUN_20002c20(local_20,1,&local_34);
    }
    else {
      if (-1 < (int)(uVar4 << 0x19)) goto LAB_20002f50;
      local_30 = 0;
      local_28 = 1;
      local_2c = (uint)*(ushort *)(pbVar6 + 6);
      local_34 = pbVar6;
      iVar7 = FUN_20002be8(local_20,0x13,&local_34);
    }
    local_3c = local_2c;
    local_40 = local_30;
    if (iVar7 == 0) {
      uVar5 = FUN_20004aee(local_20,0,local_30,*(undefined2 *)(pbVar6 + 6));
      return uVar5;
    }
  }
LAB_20002f50:
  uVar5 = 0;
LAB_20002fd4:
  uVar5 = FUN_20002fe8(local_20,pbVar6,iVar7,uVar5,&local_40,&local_3c);
  return uVar5;
}


/* ---------------------------------------------------------------------- */
/* FUN_20002fe8 @ 20002fe8 */


void FUN_20002fe8(undefined4 param_1,byte *param_2,int param_3,int param_4,undefined4 *param_5,
                 uint *param_6)

{
  int iVar1;
  
  iVar1 = 1;
  if (param_3 != 5) {
    if ((uint)*(ushort *)(param_2 + 6) < *param_6) {
      *param_6 = (uint)*(ushort *)(param_2 + 6);
    }
    iVar1 = FUN_20004b06(param_1,0,*param_5,*param_6);
    if ((iVar1 == 0) && ((char)*param_2 < '\0')) {
      FUN_20004aee(param_1,0,0);
    }
    return;
  }
  if ((((((uint)*param_2 << 0x19) >> 0x1e != 0) && (-1 < (int)((uint)*param_2 << 0x18))) &&
      (*(short *)(param_2 + 6) != 0)) && (param_4 == 0)) {
    iVar1 = 0;
  }
  FUN_20004b82(param_1,iVar1 << 7);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003048 @ 20003048 */


int FUN_20003048(undefined4 param_1,undefined4 param_2)

{
  int iVar1;
  undefined2 local_20;
  undefined1 local_1e;
  undefined1 local_1d;
  undefined1 local_1c;
  undefined4 local_18;
  undefined4 local_14;
  
  local_18 = 0x20002e4d;
  local_1c = 1;
  local_1d = 0;
  local_1e = 0x80;
  local_20 = 0x40;
  local_14 = param_2;
  iVar1 = FUN_20003888(param_1,&local_20,&local_18);
  if (iVar1 == 0) {
    local_1e = 0;
    iVar1 = FUN_20003888(param_1,&local_20,&local_18);
    if (iVar1 == 0) {
      iVar1 = 0;
    }
    else {
      FUN_200030c2(param_1,0x80);
    }
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000309c @ 2000309c */


undefined4 FUN_2000309c(int param_1)

{
  if (param_1 != 0) {
    if (*(int *)(param_1 + 0xc) != 0) {
      (**(code **)(*(int *)(param_1 + 0xc) + 4))(*(undefined4 *)(param_1 + 8));
      *(undefined4 *)(param_1 + 0xc) = 0;
    }
    FUN_200030fc(param_1);
    return 0;
  }
  return 3;
}


/* ---------------------------------------------------------------------- */
/* FUN_200030c2 @ 200030c2 */


undefined4 FUN_200030c2(int param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  uint local_14;
  
  if (param_1 == 0) {
    return 3;
  }
  local_14 = param_2;
  uVar1 = FUN_20002e34(param_1,3,&local_14,param_4,param_1);
  if ((param_2 & 0xf) < 5) {
    param_1 = ((param_2 & 0xf) << 1 | param_2 >> 7 & 1) * 0xc + param_1;
    *(undefined4 *)(param_1 + 0x14) = 0;
    *(undefined4 *)(param_1 + 0x18) = 0;
    *(undefined1 *)(param_1 + 0x1c) = 0;
    return uVar1;
  }
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_200030fc @ 200030fc */


undefined4 FUN_200030fc(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 local_10;
  
  local_10 = param_4;
  FUN_20004c30(&local_10);
  *(undefined4 *)(param_1 + 8) = 0;
  *(undefined1 *)(param_1 + 0x8d) = 0;
  FUN_20004c3c(local_10);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200031a4 @ 200031a4 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x200031b6) */
/* WARNING: Removing unreachable block (ram,0x200031b6) */

undefined4 FUN_200031a4(int param_1,undefined4 param_2,undefined1 *param_3)

{
  undefined4 uVar1;
  undefined1 uVar2;
  
  if (param_3 == (undefined1 *)0x0) {
    uVar1 = 4;
switchD_200031b6_caseD_9:
    return uVar1;
  }
  uVar1 = 1;
  switch(param_2) {
  case 2:
    uVar1 = 0xf;
    break;
  case 3:
    uVar1 = 0x10;
    break;
  case 4:
    uVar1 = 6;
    break;
  case 5:
    uVar1 = 7;
    break;
  case 6:
    uVar2 = *(undefined1 *)(param_1 + 0x8e);
    goto LAB_200031f6;
  case 7:
    uVar2 = *(undefined1 *)(param_1 + 0x8c);
    goto LAB_200031f6;
  case 8:
    uVar1 = 9;
    break;
  default:
    goto switchD_200031b6_caseD_9;
  case 0xd:
    uVar2 = *(undefined1 *)(param_1 + 0x8f);
LAB_200031f6:
    *param_3 = uVar2;
    return 0;
  }
  uVar1 = FUN_20002e34(param_1,uVar1);
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003276 @ 20003276 */


undefined4 FUN_20003276(undefined4 *param_1)

{
  undefined4 uVar1;
  int iVar2;
  
  uVar1 = 1;
  if (param_1[2] != 0) {
    iVar2 = 0;
    while( true ) {
      if ((int)(uint)*(byte *)(param_1[2] + 4) <= iVar2) break;
      uVar1 = FUN_200030c2(*param_1,*(undefined1 *)(*(int *)(param_1[2] + 8) + iVar2 * 4));
      iVar2 = iVar2 + 1;
    }
    param_1[2] = 0;
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_200032a8 @ 200032a8 */


undefined4 FUN_200032a8(undefined4 *param_1)

{
  uint uVar1;
  int iVar2;
  undefined4 uVar3;
  int iVar4;
  int iVar5;
  int iVar6;
  byte *pbVar7;
  undefined2 local_28;
  char local_26;
  undefined1 local_25;
  undefined1 local_24;
  undefined1 *local_20;
  undefined4 *local_1c;
  
  uVar1 = (uint)*(byte *)(param_1 + 3);
  iVar6 = 0;
  uVar3 = 1;
  if (uVar1 == 0) {
    return 1;
  }
  if (*(byte *)((int)*(int **)(param_1[1] + 8) + 5) < uVar1) {
    return 1;
  }
  iVar4 = **(int **)(param_1[1] + 8);
  if (iVar4 == 0) {
    return 1;
  }
  pbVar7 = (byte *)(iVar4 + uVar1 * 8 + -8);
  for (iVar4 = 0; iVar4 < (int)(uint)*pbVar7; iVar4 = iVar4 + 1) {
    iVar2 = *(int *)(pbVar7 + 4);
    iVar5 = iVar4 * 0xc;
    if (*(char *)(iVar2 + iVar5) == '\x03') {
      iVar4 = 0;
      goto LAB_2000331c;
    }
  }
LAB_200032ea:
  if (iVar6 != 0) {
    param_1[2] = iVar6;
    for (iVar4 = 0; iVar4 < (int)(uint)*(byte *)(iVar6 + 4); iVar4 = iVar4 + 1) {
      local_24 = 0;
      iVar2 = iVar4 * 4;
      local_26 = *(char *)(*(int *)(iVar6 + 8) + iVar2);
      local_28 = *(undefined2 *)(*(int *)(iVar6 + 8) + iVar2 + 2);
      local_25 = *(undefined1 *)(*(int *)(iVar6 + 8) + iVar2 + 1);
      if (local_26 < '\0') {
        local_20 = &LAB_20003590_1;
      }
      else {
        local_20 = &LAB_200035ba_1;
      }
      local_1c = param_1;
      uVar3 = FUN_20003888(*param_1,&local_28,&local_20);
    }
  }
  return uVar3;
LAB_2000331c:
  if ((int)(uint)*(byte *)(iVar2 + iVar5 + 8) <= iVar4) goto LAB_20003320;
  if (*(char *)(*(int *)(iVar2 + iVar5 + 4) + iVar4 * 0x10) == *(char *)((int)param_1 + 0xe)) {
    iVar6 = *(int *)(iVar2 + iVar5 + 4) + iVar4 * 0x10;
    goto LAB_20003320;
  }
  iVar4 = iVar4 + 1;
  goto LAB_2000331c;
LAB_20003320:
  *(undefined1 *)((int)param_1 + 0xd) = *(undefined1 *)(iVar2 + iVar5 + 3);
  goto LAB_200032ea;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003378 @ 20003378 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000338a) */
/* WARNING (jumptable): Removing unreachable block (ram,0x20003470) */
/* WARNING: Removing unreachable block (ram,0x2000338a) */
/* WARNING: Removing unreachable block (ram,0x20003470) */

undefined8 FUN_20003378(undefined4 *param_1,uint param_2,ushort *param_3,undefined4 param_4)

{
  char cVar1;
  undefined4 uVar2;
  byte *pbVar3;
  uint *puVar4;
  uint *puVar5;
  code *pcVar6;
  int iVar7;
  uint local_20;
  ushort *local_1c;
  undefined4 local_18;
  
  puVar5 = &local_20;
  if ((param_3 == (ushort *)0x0) || (param_1 == (undefined4 *)0x0)) {
    uVar2 = 3;
switchD_2000338a_caseD_0:
    return CONCAT44(param_2,uVar2);
  }
  uVar2 = 1;
  local_20 = param_2;
  local_1c = param_3;
  local_18 = param_4;
  switch(param_2) {
  default:
    goto switchD_2000338a_caseD_0;
  case 1:
    pbVar3 = *(byte **)param_3;
    if (((*pbVar3 & 0x1f) != 1) || (pbVar3[4] != *(byte *)((int)param_1 + 0xd))) goto LAB_2000344e;
    puVar4 = (uint *)((int)param_1 + 0xf);
    local_18._3_1_ = (undefined1)((uint)param_4 >> 0x18);
    switch(pbVar3[1]) {
    default:
      return CONCAT44(param_2,5);
    case 1:
      local_18._0_2_ =
           CONCAT11(*(undefined1 *)(*(int *)param_3 + 2),
                    (char)((ushort)*(undefined2 *)(pbVar3 + 2) >> 8));
      local_18._0_3_ = CONCAT12(*(undefined1 *)(*(int *)param_3 + 4),(undefined2)local_18);
      local_1c = *(ushort **)(param_3 + 4);
      uVar2 = 3;
      pcVar6 = *(code **)param_1[1];
LAB_200034e4:
      uVar2 = (*pcVar6)(param_1,uVar2,puVar5);
      *(uint *)(param_3 + 2) = local_20;
      *(ushort **)(param_3 + 4) = local_1c;
      return CONCAT44(local_20,uVar2);
    case 2:
      pcVar6 = *(code **)param_1[1];
      goto LAB_200034b4;
    case 3:
      pcVar6 = *(code **)param_1[1];
      puVar4 = param_1 + 4;
LAB_200034b4:
      uVar2 = (*pcVar6)(param_1,4,puVar4);
      *(uint **)(param_3 + 2) = puVar4;
      return CONCAT44(local_20,uVar2);
    case 9:
      local_18._0_2_ =
           CONCAT11(*(undefined1 *)(*(int *)param_3 + 2),
                    (char)((ushort)*(undefined2 *)(pbVar3 + 2) >> 8));
      local_18._0_3_ = CONCAT12(*(undefined1 *)(*(int *)param_3 + 4),(undefined2)local_18);
      if ((char)param_3[6] != '\0') {
        local_1c = *(ushort **)(param_3 + 4);
        pcVar6 = *(code **)param_1[1];
        uVar2 = 9;
        goto LAB_200034e4;
      }
      local_20 = *(uint *)(param_3 + 2);
      local_1c = *(ushort **)(param_3 + 4);
      pcVar6 = *(code **)param_1[1];
      uVar2 = 6;
      break;
    case 10:
      *(char *)((int)param_1 + 0xf) = (char)((ushort)*(undefined2 *)(pbVar3 + 2) >> 8);
      uVar2 = (**(code **)param_1[1])(param_1,7);
      if (*(short *)(*(int *)param_3 + 4) != 0) {
        return CONCAT44(local_20,uVar2);
      }
      goto LAB_20003506;
    case 0xb:
      *(byte *)(param_1 + 4) = pbVar3[2];
      pcVar6 = *(code **)param_1[1];
      uVar2 = 8;
      puVar5 = param_1 + 4;
    }
    uVar2 = (*pcVar6)(param_1,uVar2,puVar5);
LAB_20003506:
    return CONCAT44(local_20,uVar2);
  case 2:
    *(undefined1 *)(param_1 + 3) = 0;
    *(undefined1 *)((int)param_1 + 0x11) = 0;
    *(undefined1 *)((int)param_1 + 0x12) = 0;
    param_1[2] = 0;
LAB_200033a4:
    return CONCAT44(param_2,1);
  case 3:
    if ((param_1[1] == 0) || ((char)*param_3 == *(char *)(param_1 + 3))) goto LAB_200033a4;
    if (*(char *)(param_1 + 3) != '\0') {
      FUN_20003276(param_1);
    }
    *(char *)(param_1 + 3) = (char)*param_3;
    *(undefined1 *)((int)param_1 + 0xe) = 0;
    break;
  case 4:
    if (((param_1[1] == 0) ||
        (cVar1 = (char)*param_3, (ushort)*(byte *)((int)param_1 + 0xd) != *param_3 >> 8)) ||
       (*(char *)((int)param_1 + 0xe) == cVar1)) goto LAB_200033a4;
    FUN_20003276(param_1);
    *(char *)((int)param_1 + 0xe) = cVar1;
    break;
  case 5:
    if ((param_1[1] != 0) && (param_1[2] != 0)) {
      for (iVar7 = 0; iVar7 < (int)(uint)*(byte *)(param_1[2] + 4); iVar7 = iVar7 + 1) {
        if (*(char *)(*(int *)(param_1[2] + 8) + iVar7 * 4) == (char)*param_3) {
          uVar2 = FUN_20004b82(*param_1);
        }
      }
LAB_2000341e:
      return CONCAT44(local_20,uVar2);
    }
    goto LAB_200033ee;
  case 6:
    if ((param_1[1] == 0) || (param_1[2] == 0)) goto LAB_2000341e;
    for (iVar7 = 0; iVar7 < (int)(uint)*(byte *)(param_1[2] + 4); iVar7 = iVar7 + 1) {
      if (*(char *)(*(int *)(param_1[2] + 8) + iVar7 * 4) == (char)*param_3) {
        uVar2 = FUN_20004c14(*param_1);
      }
    }
LAB_2000344e:
    return CONCAT44(local_20,uVar2);
  }
  uVar2 = FUN_200032a8(param_1);
LAB_200033ee:
  return CONCAT44(local_20,uVar2);
}


/* ---------------------------------------------------------------------- */
/* FUN_20003538 @ 20003538 */


int FUN_20003538(undefined4 param_1,int param_2,undefined4 *param_3,undefined4 param_4)

{
  uint uVar1;
  int *unaff_r4;
  int iVar2;
  
  uVar1 = 0;
  iVar2 = 0;
  do {
    if ((&DAT_04003480)[uVar1 * 5] == 0) {
      unaff_r4 = &DAT_04003480 + uVar1 * 5;
      goto LAB_20003558;
    }
    uVar1 = uVar1 + 1;
  } while (uVar1 < 4);
  iVar2 = 2;
LAB_20003558:
  if ((iVar2 == 0) &&
     (iVar2 = FUN_20002ce0(param_1,unaff_r4,param_1,&DAT_04003480,param_4), iVar2 == 0)) {
    if (*unaff_r4 == 0) {
      return 3;
    }
    unaff_r4[1] = param_2;
    *(undefined1 *)(unaff_r4 + 3) = 0;
    *(undefined1 *)((int)unaff_r4 + 0xe) = 0xff;
    iVar2 = 0;
    *param_3 = unaff_r4;
  }
  return iVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003778 @ 20003778 */


int FUN_20003778(undefined4 *param_1)

{
  int iVar1;
  
  if (param_1 == (undefined4 *)0x0) {
    iVar1 = 3;
  }
  else {
    if (*(char *)((int)param_1 + 0x11) != '\0') {
      *(undefined1 *)((int)param_1 + 0x11) = 0;
      return 2;
    }
    iVar1 = FUN_20004b06(*param_1);
    if (iVar1 != 0) {
      return iVar1;
    }
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_200037a4 @ 200037a4 */


int FUN_200037a4(int param_1,undefined4 param_2,int *param_3)

{
  int iVar1;
  int *piVar2;
  uint uVar3;
  int local_18;
  
  local_18 = 0;
  if (param_3 == (int *)0x0) {
    iVar1 = 3;
  }
  else {
    iVar1 = FUN_2000256c(param_1,&local_18);
    if (iVar1 == 0) {
      *(undefined4 *)(local_18 + 0x10) = param_2;
      *(char *)(local_18 + 0x8d) = (char)param_1;
      *(undefined1 *)(local_18 + 0x8c) = 0;
      *(undefined1 *)(local_18 + 0x90) = 0;
      uVar3 = 0;
      do {
        iVar1 = uVar3 * 0xc;
        uVar3 = uVar3 + 1;
        *(undefined4 *)(iVar1 + local_18 + 0x14) = 0;
        *(undefined4 *)(iVar1 + local_18 + 0x18) = 0;
        *(undefined1 *)(iVar1 + local_18 + 0x1c) = 0;
      } while (uVar3 < 10);
      iVar1 = 6;
      if ((((param_1 == 4) || (param_1 == 5)) || (param_1 == 6)) || (param_1 == 7)) {
        iVar1 = 0;
        *(undefined ***)(local_18 + 0xc) = &PTR_LAB_200041dc_1_2000e834;
      }
      if (iVar1 != 0) {
        FUN_200030fc(local_18);
        return iVar1;
      }
      piVar2 = *(int **)(local_18 + 0xc);
      if (piVar2 == (int *)0x0) {
        FUN_200030fc(local_18);
        return 6;
      }
      if ((((*piVar2 != 0) && (piVar2[1] != 0)) &&
          ((piVar2[2] != 0 && ((piVar2[3] != 0 && (piVar2[4] != 0)))))) && (piVar2[5] != 0)) {
        *param_3 = local_18;
        iVar1 = (*(code *)**(undefined4 **)(local_18 + 0xc))(param_1,local_18,local_18 + 8);
        if (iVar1 == 0) {
          *(undefined1 *)(local_18 + 0x8e) = 2;
        }
        else {
          FUN_2000309c(local_18);
          *param_3 = 0;
        }
        return iVar1;
      }
      FUN_200030fc(local_18);
      return 7;
    }
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003888 @ 20003888 */


undefined4 FUN_20003888(int param_1,int param_2,undefined4 *param_3)

{
  undefined4 uVar1;
  uint uVar2;
  int iVar3;
  
  if (param_1 == 0) {
    return 3;
  }
  if ((param_2 != 0) && (param_3 != (undefined4 *)0x0)) {
    uVar2 = *(byte *)(param_2 + 2) & 0xf;
    if (uVar2 < 5) {
      iVar3 = (uVar2 << 1 | (uint)(*(byte *)(param_2 + 2) >> 7)) * 0xc + param_1;
      *(undefined4 *)(iVar3 + 0x14) = *param_3;
      *(undefined4 *)(iVar3 + 0x18) = param_3[1];
      *(undefined1 *)(iVar3 + 0x1c) = 0;
      uVar1 = FUN_20002e34(param_1,2,param_2);
      return uVar1;
    }
  }
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_200038cc @ 200038cc */


/* WARNING: Removing unreachable block (ram,0x200038fc) */

void FUN_200038cc(void)

{
  uint uVar1;
  
  uVar1 = DAT_e000e41c;
  DAT_e000e41c = uVar1 & 0xffffff00;
  DAT_e000e100 = 0x10000000;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003944 @ 20003944 */


undefined4 FUN_20003944(int param_1,uint param_2)

{
  undefined4 *puVar1;
  int iVar2;
  undefined4 local_2c;
  undefined4 local_28;
  undefined1 local_24;
  undefined1 local_23;
  int local_20;
  int local_1c;
  uint uStack_18;
  
  iVar2 = ((param_2 << 0x1c) >> 0x1b) + ((param_2 & 0x80) >> 7);
  local_1c = param_1;
  uStack_18 = param_2;
  puVar1 = (undefined4 *)FUN_200041c4(param_1,iVar2);
  if ((int)((uint)*(ushort *)(puVar1 + 5) << 0x13) < 0) {
    local_20 = 0;
    if ((*(uint *)(*(int *)(param_1 + 0x128) + 0x24) & 1 << iVar2) != 0) {
      local_20 = 1;
      *(uint *)(*(int *)(param_1 + 0x128) + 0x24) =
           *(uint *)(*(int *)(param_1 + 0x128) + 0x24) & ~(1 << iVar2);
    }
    do {
      if ((uint)(puVar1[5] << 9) >> 0x1e == 2) {
        puVar1[5] = (puVar1[5] & 0xff9fffff) + 0x200000;
      }
      else {
        puVar1[5] = puVar1[5] & 0xff9fffff;
      }
      *(uint *)(*(int *)(param_1 + 0x128) + 0x14) =
           *(uint *)(*(int *)(param_1 + 0x128) + 0x14) | 1 << iVar2;
      do {
      } while ((*(uint *)(*(int *)(param_1 + 0x128) + 0x14) & 1 << iVar2) != 0);
      if ((uint)(puVar1[5] << 9) >> 0x1e != 0) {
        puVar1[5] = puVar1[5] & 0xff7fffff |
                    ((*(uint *)(*(int *)(param_1 + 0x128) + 0x18) & 1 << iVar2) >> iVar2 & 1) <<
                    0x17;
        puVar1[5] = puVar1[5] & 0xff7fffff | ((uint)(puVar1[5] << 8) >> 0x1f ^ 1) << 0x17;
        *(uint *)(*(int *)(param_1 + 0x128) + 0x18) =
             *(uint *)(*(int *)(param_1 + 0x128) + 0x18) | ((uint)(puVar1[5] << 8) >> 0x1f) << iVar2
        ;
      }
    } while ((uint)(puVar1[5] << 9) >> 0x1e != 0);
    if (local_20 != 0) {
      *(int *)(*(int *)(param_1 + 0x128) + 0x20) = 1 << iVar2;
      *(uint *)(*(int *)(param_1 + 0x128) + 0x24) =
           *(uint *)(*(int *)(param_1 + 0x128) + 0x24) | 1 << iVar2;
    }
    local_28 = 0xffffffff;
    local_2c = *puVar1;
    local_24 = (undefined1)param_2;
    local_23 = 0;
    puVar1[5] = puVar1[5] & 0xffffefff;
    puVar1[5] = puVar1[5] & 0xff7fffff |
                ((*(uint *)(*(int *)(param_1 + 0x128) + 0x18) & 1 << iVar2) >> iVar2 & 1) << 0x17;
    puVar1[5] = puVar1[5] & 0xfeffffff |
                ((*(uint *)(*(int *)(param_1 + 0x128) + 0x18) & 1 << iVar2) >> iVar2 & 1) << 0x18;
    FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),&local_2c);
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003af8 @ 20003af8 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20003b1c) */
/* WARNING: Removing unreachable block (ram,0x20003b1c) */

uint FUN_20003af8(int param_1,undefined4 param_2,byte *param_3)

{
  int iVar1;
  uint uVar2;
  uint local_24;
  
  local_24 = 1;
  if (param_1 == 0) {
    local_24 = 3;
  }
  else {
    switch(param_2) {
    case 0:
      **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) | 0x10000;
      break;
    case 1:
      **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) & 0xfffeffff;
      break;
    case 2:
      if (param_3 != (byte *)0x0) {
        local_24 = FUN_20003db2(param_1,param_3);
      }
      break;
    case 3:
      if (param_3 != (byte *)0x0) {
        local_24 = FUN_20003d3c(param_1,*param_3);
      }
      break;
    case 4:
      if (param_3 != (byte *)0x0) {
        local_24 = FUN_20003fae(param_1,*param_3);
      }
      break;
    case 5:
      if (param_3 != (byte *)0x0) {
        local_24 = FUN_2000402a(param_1,*param_3);
      }
      break;
    case 6:
      if (param_3 != (byte *)0x0) {
        *(ushort *)param_3 = (ushort)*(byte *)(*(int *)(param_1 + 0x124) + 0x8f) << 1;
      }
      local_24 = (uint)(param_3 == (byte *)0x0);
      break;
    case 7:
      if ((param_3 != (byte *)0x0) && ((*param_3 & 0xf) < 5)) {
        iVar1 = FUN_200041c4(param_1,(((uint)*param_3 << 0x1c) >> 0x1b) + (uint)(*param_3 >> 7));
        *(ushort *)(param_3 + 2) = (ushort)(((uint)*(ushort *)(iVar1 + 0x14) << 0x14) >> 0x1f);
        local_24 = 0;
      }
      break;
    case 8:
      if (param_3 != (byte *)0x0) {
        **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) & 0xffffff80 | *param_3 & 0x7f;
      }
      local_24 = (uint)(param_3 == (byte *)0x0);
      break;
    case 9:
      break;
    case 10:
      **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) | 0x200;
      **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) & 0xfffdffff;
      do {
      } while ((**(uint **)(param_1 + 0x128) & 0x20000) != 0);
      **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) & 0xf0fffdff;
      local_24 = 0;
      break;
    case 0xe:
      for (uVar2 = 0; uVar2 < 5; uVar2 = uVar2 + 1) {
        FUN_20003d3c(param_1,uVar2 & 0xff | 0x80);
        FUN_20003d3c(param_1,uVar2 & 0xff);
      }
      FUN_20004588(param_1);
      local_24 = 0;
      break;
    case 0xf:
      if (param_3 != (byte *)0x0) {
        *param_3 = *(byte *)(param_1 + 0x132);
      }
      local_24 = (uint)(param_3 == (byte *)0x0);
      break;
    case 0x10:
      break;
    case 0x11:
      break;
    case 0x13:
      *param_3 = (byte)((**(uint **)(param_1 + 0x128) & 0x100000) >> 0x14);
    }
  }
  return local_24;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003d3c @ 20003d3c */


undefined4 FUN_20003d3c(int param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  int iVar2;
  
  iVar2 = ((param_2 << 0x1c) >> 0x1b) + ((param_2 & 0x80) >> 7);
  iVar1 = FUN_200041c4(param_1,iVar2,param_3,param_4,param_4);
  FUN_20003944(param_1,param_2);
  if (iVar2 >> 1 != 0) {
    FUN_2000499e(param_1,*(undefined4 *)(iVar1 + 0x10),*(ushort *)(iVar1 + 0x14) & 0x7ff);
  }
  *(undefined4 *)(iVar1 + 0x10) = 0;
  *(uint *)(*(int *)(param_1 + 0x128) + 0x18) =
       *(uint *)(*(int *)(param_1 + 0x128) + 0x18) & ~(1 << iVar2);
  *(undefined4 *)(*(uint *)(param_1 + 300) | iVar2 * 8) = 0x40000000;
  *(uint *)(iVar1 + 0x14) = *(uint *)(iVar1 + 0x14) & 0xfffff800;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003db2 @ 20003db2 */


undefined8 FUN_20003db2(undefined4 *param_1,ushort *param_2)

{
  ushort uVar1;
  int iVar2;
  undefined4 uVar3;
  int iVar4;
  ushort *local_20;
  
  iVar4 = (((uint)(byte)param_2[1] << 0x1c) >> 0x1b) + (uint)(byte)((byte)param_2[1] >> 7);
  iVar2 = FUN_200041c4(param_1,iVar4);
  uVar1 = *param_2;
  *(undefined4 *)(iVar2 + 0x14) = 0;
  *(uint *)(param_1[0x4a] + 0x18) = *(uint *)(param_1[0x4a] + 0x18) & ~(1 << iVar4);
  *(uint *)(iVar2 + 0x14) = *(uint *)(iVar2 + 0x14) & 0xfffff800 | uVar1 & 0x7ff;
  *(uint *)(iVar2 + 0x14) = *(uint *)(iVar2 + 0x14) & 0xffffdfff | ((byte)param_2[2] & 1) << 0xd;
  *(uint *)(iVar2 + 0x14) =
       *(uint *)(iVar2 + 0x14) & 0xf9ffffff | (*(byte *)((int)param_2 + 3) & 3) << 0x19;
  if (*(char *)((int)param_2 + 3) == '\x01') {
    *(uint *)(iVar2 + 0x14) = (*(uint *)(iVar2 + 0x14) & 0xffe0ffff) + 0x10000;
  }
  else {
    *(uint *)(iVar2 + 0x14) = *(uint *)(iVar2 + 0x14) & 0xffe0ffff;
  }
  *(uint *)(param_1[0x4b] | iVar4 * 8) = ((uint)(*(int *)(iVar2 + 0x14) << 0xb) >> 0x1b) << 0x1a;
  if ((param_2[1] & 0xf) == 0) {
    if ((param_2[1] & 0x80) == 0) {
      *(uint *)(param_1[0x4b] | 4) = (uint)(param_1[1] << 10) >> 0x10;
    }
  }
  else {
    *(uint *)(param_1[0x4b] | iVar4 * 8 | 4) =
         ((uint)(*(int *)(iVar2 + 0x14) << 0xb) >> 0x1b) << 0x1a;
  }
  if (iVar4 >> 1 != 0) {
    *(uint *)(iVar2 + 0x14) =
         *(uint *)(iVar2 + 0x14) & 0xffe0ffff |
         ((uint)(*(int *)(iVar2 + 0x14) << 0xb) >> 0x1b | 4) << 0x10;
  }
  *(undefined4 *)(iVar2 + 0x10) = 0;
  if (iVar4 >> 1 == 0) {
    *(undefined4 *)(iVar2 + 0x10) = *param_1;
    local_20 = param_2;
  }
  else {
    local_20 = (ushort *)FUN_200048f0(param_1,(uint)uVar1);
    if (local_20 == (ushort *)0x0) {
      uVar3 = 0xc;
      goto LAB_20003ef0;
    }
    *(ushort **)(iVar2 + 0x10) = local_20;
  }
  uVar3 = 0;
LAB_20003ef0:
  return CONCAT44(local_20,uVar3);
}


/* ---------------------------------------------------------------------- */
/* FUN_20003efc @ 20003efc */


undefined4 FUN_20003efc(int param_1,int param_2,int param_3,int param_4,int param_5)

{
  undefined4 local_2c;
  undefined4 local_28;
  int iStack_24;
  int iStack_20;
  int local_1c;
  int iStack_18;
  
  iStack_24 = param_1;
  iStack_20 = param_2;
  local_1c = param_3;
  iStack_18 = param_4;
  FUN_20004c30(&local_2c);
  *(uint *)(param_2 + 0x14) = (*(uint *)(param_2 + 0x14) & 0xffffefff) + 0x1000;
  *(int *)(param_2 + 0xc) = *(int *)(param_2 + 0xc) + param_5;
  local_28 = 0;
  *(ushort *)(param_2 + 0x18) = *(ushort *)(param_2 + 0x18) & 0xf800 | (ushort)param_5 & 0x7ff;
  if (param_4 == 0) {
    param_4 = *(int *)(param_1 + 8);
  }
  *(uint *)(*(uint *)(param_1 + 300) | local_1c << 3) =
       (uint)(param_4 << 10) >> 0x10 |
       ((uint)(*(int *)(param_2 + 0x14) << 0xb) >> 0x1b) * 0x4000000 + 0x80000000 | param_5 << 0x10;
  if (((uint)(*(int *)(param_2 + 0x14) << 0xb) >> 0x1b & 4) != 0) {
    *(uint *)(param_2 + 0x14) =
         *(uint *)(param_2 + 0x14) & 0xffe0ffff |
         ((uint)(*(int *)(param_2 + 0x14) << 0xb) >> 0x1b & 0xfffffffb) << 0x10;
  }
  FUN_20004c3c(local_2c);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20003fae @ 20003fae */


undefined4 FUN_20003fae(int param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  int iVar2;
  
  iVar2 = ((param_2 << 0x1c) >> 0x1b) + ((param_2 & 0x80) >> 7);
  iVar1 = FUN_200041c4(param_1,iVar2,param_3,param_4,param_4);
  *(uint *)(iVar1 + 0x14) = (*(uint *)(iVar1 + 0x14) & 0xfffff7ff) + 0x800;
  *(undefined4 *)(*(uint *)(param_1 + 300) | iVar2 * 8) = 0x20000000;
  if ((param_2 & 0xf) != 0) {
    *(uint *)(iVar1 + 0x14) =
         *(uint *)(iVar1 + 0x14) & 0xffe0ffff |
         ((uint)(*(int *)(iVar1 + 0x14) << 0xb) >> 0x1b | 4) << 0x10;
    *(undefined4 *)(*(uint *)(param_1 + 300) | iVar2 * 8 | 4) = 0x20000000;
  }
  FUN_20003944(param_1,param_2);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000402a @ 2000402a */


undefined4 FUN_2000402a(int param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  int iVar2;
  
  iVar2 = ((param_2 << 0x1c) >> 0x1b) + ((param_2 & 0x80) >> 7);
  iVar1 = FUN_200041c4(param_1,iVar2,param_3,param_4,param_4);
  *(uint *)(iVar1 + 0x14) = *(uint *)(iVar1 + 0x14) & 0xfffff7ff;
  *(uint *)(*(uint *)(param_1 + 300) | iVar2 * 8) =
       *(uint *)(*(uint *)(param_1 + 300) | iVar2 * 8) & 0xdfffffff;
  if ((param_2 & 0xf) != 0) {
    *(uint *)(*(uint *)(param_1 + 300) | iVar2 * 8 | 4) =
         *(uint *)(*(uint *)(param_1 + 300) | iVar2 * 8 | 4) & 0xdfffffff;
    *(uint *)(iVar1 + 0x14) =
         *(uint *)(iVar1 + 0x14) & 0xffe0ffff |
         ((uint)(*(int *)(iVar1 + 0x14) << 0xb) >> 0x1b | 4) << 0x10;
  }
  if ((int)((uint)*(ushort *)(iVar1 + 0x14) << 0x11) < 0) {
    *(uint *)(iVar1 + 0x14) = *(uint *)(iVar1 + 0x14) & 0xffffbfff;
    FUN_200046f8(param_1,iVar1,iVar2);
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200040da @ 200040da */


undefined4 FUN_200040da(int param_1,int *param_2,uint param_3)

{
  uint uVar1;
  undefined4 uVar2;
  uint uVar3;
  uint uVar4;
  uint uVar5;
  
  uVar4 = *param_2 + param_2[3];
  uVar5 = param_2[1] - param_2[3];
  if ((*(ushort *)(param_2 + 5) & 0x7ff) < uVar5) {
    uVar5 = *(ushort *)(param_2 + 5) & 0x7ff;
  }
  *(ushort *)(param_2 + 6) = *(ushort *)(param_2 + 6) & 0xf7ff;
  uVar1 = uVar4;
  if ((uVar5 != 0) &&
     (((uVar4 & 0x3f) != 0 ||
      ((uVar4 & 0xffc00000) != (*(uint *)(*(int *)(param_1 + 0x128) + 0xc) & 0xffc00000))))) {
    *(ushort *)(param_2 + 6) = (*(ushort *)(param_2 + 6) & 0xf7ff) + 0x800;
    uVar1 = param_2[4];
    if ((param_3 & 1) == 0) {
      uVar5 = *(ushort *)(param_2 + 5) & 0x7ff;
    }
    else if ((uVar4 & 3) == 0) {
      for (uVar3 = 0; uVar3 < uVar5 + 3 >> 2; uVar3 = uVar3 + 1) {
        *(undefined4 *)(uVar1 + uVar3 * 4) = *(undefined4 *)(uVar4 + uVar3 * 4);
      }
    }
    else {
      for (uVar3 = 0; uVar3 < uVar5; uVar3 = uVar3 + 1) {
        *(undefined1 *)(uVar1 + uVar3) = *(undefined1 *)(uVar4 + uVar3);
      }
    }
  }
  if (*(char *)(param_1 + 0x131) == '\0') {
    uVar2 = FUN_20003efc(param_1,param_2,param_3,uVar1,uVar5);
  }
  else {
    uVar2 = 1;
  }
  return uVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_200041c4 @ 200041c4 */


int FUN_200041c4(int param_1,uint param_2)

{
  int iVar1;
  
  if (param_2 < 0xb) {
    iVar1 = param_2 * 0x1c + param_1 + 0xc;
  }
  else {
    iVar1 = 0;
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_200042d8 @ 200042d8 */


void FUN_200042d8(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 local_18;
  undefined4 local_14;
  undefined2 local_10;
  undefined2 uStack_e;
  
  *(undefined1 *)(param_1 + 0x131) = 1;
  *(undefined1 *)(param_1 + 0x132) = 0;
  local_18 = 0;
  local_14 = 0;
  _local_10 = CONCAT22((short)((uint)param_4 >> 0x10),0x10);
  FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),&local_18);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000430c @ 2000430c */


longlong FUN_2000430c(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  uint local_18 [2];
  undefined2 local_10;
  undefined2 uStack_e;
  
  local_18[0] = 0;
  local_18[1] = 0;
  _local_10 = CONCAT22((short)((uint)param_4 >> 0x10),0x12);
  FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),local_18);
  return (ulonglong)local_18[0] << 0x20;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004334 @ 20004334 */


longlong FUN_20004334(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  uint local_18 [2];
  undefined2 local_10;
  undefined2 uStack_e;
  
  local_18[0] = 0;
  local_18[1] = 0;
  _local_10 = CONCAT22((short)((uint)param_4 >> 0x10),0x11);
  FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),local_18);
  return (ulonglong)local_18[0] << 0x20;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000435c @ 2000435c */


void FUN_2000435c(int param_1,uint param_2,int param_3)

{
  undefined4 *puVar1;
  int iVar2;
  int iVar3;
  int iVar4;
  int extraout_r1;
  int extraout_r1_00;
  undefined4 local_20;
  undefined4 local_1c;
  byte local_18;
  undefined1 local_17;
  
  puVar1 = (undefined4 *)FUN_200041c4(param_1,param_2);
  if ((param_3 == 0) && (-1 < (int)((uint)*(ushort *)(puVar1 + 5) << 0x13))) {
    return;
  }
  if (param_3 == 0) {
    if ((*(uint *)(*(int *)(param_1 + 300) + param_2 * 8) & 0x80000000) != 0) {
      return;
    }
    iVar2 = FUN_20004644(param_1,puVar1,param_2,0);
    iVar4 = puVar1[2];
    iVar3 = puVar1[1];
    if (((iVar2 != 0) && (__aeabi_uidiv(iVar2,*(ushort *)(puVar1 + 5) & 0x7ff), extraout_r1 == 0))
       && (iVar3 != iVar4)) {
      FUN_200046f8(param_1,puVar1,param_2);
      return;
    }
    puVar1[5] = puVar1[5] & 0xffffefff;
    local_1c = puVar1[2];
    local_20 = *puVar1;
    if ((((param_2 & 1) != 0) && (iVar2 != 0)) &&
       (__aeabi_uidiv(iVar2,*(ushort *)(puVar1 + 5) & 0x7ff), extraout_r1_00 == 0)) {
      if ((int)param_2 >> 1 == 0) {
        if ((uint)puVar1[1] < (uint)*(ushort *)(*(int *)(param_1 + 4) + 6)) {
          FUN_20003efc(param_1,puVar1,1,0,0);
          return;
        }
      }
      else if ((int)((uint)*(ushort *)(puVar1 + 5) << 0x12) < 0) {
        FUN_20003efc(param_1,puVar1,param_2,0,0);
        return;
      }
    }
  }
  else {
    local_1c = 8;
    local_20 = *(undefined4 *)(param_1 + 4);
    if (((int)((uint)*(ushort *)(puVar1 + 5) << 0x13) < 0) &&
       (puVar1[5] = puVar1[5] & 0xffffefff, (**(uint **)(param_1 + 300) & 0x80000000) != 0)) {
      FUN_20003944(param_1,0);
    }
    if (((int)((uint)*(ushort *)(param_1 + 0x3c) << 0x13) < 0) &&
       (*(uint *)(param_1 + 0x3c) = *(uint *)(param_1 + 0x3c) & 0xffffefff,
       (*(uint *)(*(int *)(param_1 + 300) + 8) & 0x80000000) != 0)) {
      FUN_20003944(param_1,0x80);
    }
    **(uint **)(param_1 + 300) = **(uint **)(param_1 + 300) & 0x5fffffff;
    *(uint *)(*(uint *)(param_1 + 300) | 8) = *(uint *)(*(uint *)(param_1 + 300) | 8) & 0x5fffffff;
    *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x20) = 3;
    **(uint **)(param_1 + 0x128) = **(uint **)(param_1 + 0x128) | 0x100;
  }
  local_17 = (undefined1)param_3;
  local_18 = (byte)((int)param_2 >> 1) | (byte)((param_2 << 0x1f) >> 0x18);
  FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),&local_20);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004522 @ 20004522 */


void FUN_20004522(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  FUN_2000453a(param_1,param_2,param_3,param_4,param_4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000453a @ 2000453a */


undefined4 FUN_2000453a(undefined4 param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  undefined4 *puVar2;
  undefined4 uVar3;
  
  iVar1 = ((param_2 << 0x1c) >> 0x1b) + ((param_2 & 0x80) >> 7);
  puVar2 = (undefined4 *)FUN_200041c4(param_1,iVar1);
  if ((int)((uint)*(ushort *)(puVar2 + 5) << 0x13) < 0) {
    uVar3 = 1;
  }
  else {
    puVar2[2] = 0;
    *puVar2 = param_3;
    puVar2[1] = param_4;
    puVar2[3] = 0;
    uVar3 = FUN_200046f8(param_1,puVar2,iVar1);
  }
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004588 @ 20004588 */


void FUN_20004588(int param_1)

{
  uint uVar1;
  undefined4 local_10;
  
  for (uVar1 = 0; uVar1 < 4; uVar1 = uVar1 + 1) {
    *(undefined4 *)(*(int *)(param_1 + 300) + uVar1 * 4) = 0;
  }
  for (uVar1 = 4; uVar1 < 0x14; uVar1 = uVar1 + 1) {
    *(undefined4 *)(*(int *)(param_1 + 300) + uVar1 * 4) = 0x40000000;
  }
  local_10 = 0;
  FUN_20003af8(param_1,8,&local_10);
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 8) = *(undefined4 *)(param_1 + 300);
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0xc) = *(undefined4 *)(param_1 + 4);
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x18) = 0;
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x14) = 0;
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x1c) = 0;
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x20) = 0xc000ffff;
  *(undefined4 *)(*(int *)(param_1 + 0x128) + 0x24) = 0xc000ffff;
  *(undefined1 *)(param_1 + 0x131) = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000461c @ 2000461c */


void FUN_2000461c(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 local_18;
  undefined4 local_14;
  undefined2 local_10;
  undefined2 uStack_e;
  
  local_18 = 0;
  local_14 = 0;
  _local_10 = CONCAT22((short)((uint)param_4 >> 0x10),0x18);
  FUN_20004ad0(*(undefined4 *)(param_1 + 0x124),&local_18);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004644 @ 20004644 */


void FUN_20004644(int param_1,int *param_2,uint param_3)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  
  if ((param_3 & 1) == 0) {
    uVar1 = (*(ushort *)(param_2 + 6) & 0x7ff) -
            ((*(uint *)(*(int *)(*(int *)(param_1 + 0x128) + 8) + param_3 * 8) & 0x3ff0000) >> 0x10)
    ;
  }
  else {
    uVar1 = *(ushort *)(param_2 + 6) & 0x7ff;
  }
  if ((((int)((uint)*(ushort *)(param_2 + 6) << 0x14) < 0) && (uVar1 != 0)) && ((param_3 & 1) == 0))
  {
    uVar3 = *param_2 + param_2[2];
    iVar4 = param_2[4];
    if ((uVar3 & 3) == 0) {
      for (uVar2 = 0; uVar2 < uVar1 >> 2; uVar2 = uVar2 + 1) {
        *(undefined4 *)(uVar3 + uVar2 * 4) = *(undefined4 *)(iVar4 + uVar2 * 4);
      }
      for (uVar2 = uVar2 << 2; uVar2 < uVar1; uVar2 = uVar2 + 1) {
        *(undefined1 *)(uVar3 + uVar2) = *(undefined1 *)(iVar4 + uVar2);
      }
    }
    else {
      for (uVar2 = 0; uVar2 < uVar1; uVar2 = uVar2 + 1) {
        *(undefined1 *)(uVar3 + uVar2) = *(undefined1 *)(iVar4 + uVar2);
      }
    }
  }
  param_2[2] = param_2[2] + uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200046f8 @ 200046f8 */


undefined4 FUN_200046f8(undefined4 param_1,int param_2,int param_3,undefined4 param_4)

{
  undefined4 uVar1;
  undefined4 local_18;
  
  local_18 = param_4;
  FUN_20004c30(&local_18);
  if ((int)((uint)*(ushort *)(param_2 + 0x14) << 0x14) < 0) {
    if (param_3 >> 1 != 0) {
      *(uint *)(param_2 + 0x14) = (*(uint *)(param_2 + 0x14) & 0xffffbfff) + 0x4000;
    }
    FUN_20004c3c(local_18);
    uVar1 = 1;
  }
  else {
    FUN_20004c3c(local_18);
    if ((*(uint *)(param_2 + 0xc) < *(uint *)(param_2 + 4)) || (*(int *)(param_2 + 4) == 0)) {
      uVar1 = FUN_200040da(param_1,param_2,param_3,0);
    }
    else {
      uVar1 = 0;
    }
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000475c @ 2000475c */


void FUN_2000475c(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  int iVar2;
  uint uVar3;
  uint uVar4;
  
  if (param_1 != 0) {
    iVar2 = *(int *)(param_1 + 8);
    uVar4 = *(uint *)(*(int *)(iVar2 + 0x128) + 0x20);
    *(uint *)(*(int *)(iVar2 + 0x128) + 0x20) = uVar4;
    uVar4 = uVar4 & *(uint *)(*(int *)(iVar2 + 0x128) + 0x24);
    uVar1 = *(uint *)(*(int *)(iVar2 + 0x128) + 4) & 0x7800;
    if ((uVar4 & 0x80000000) != 0) {
      uVar3 = **(uint **)(iVar2 + 0x128);
      **(uint **)(iVar2 + 0x128) = uVar3 & 0xfffffeff | 0xf000000;
      if ((uVar3 & 0x4000000) != 0) {
        FUN_200042d8(iVar2);
      }
      if ((uVar3 & 0x2000000) != 0) {
        if ((**(uint **)(iVar2 + 0x128) & 0x20000) == 0) {
          FUN_2000430c(iVar2);
        }
        else {
          FUN_20004334(iVar2);
        }
      }
    }
    if ((uVar4 & 0xffff) != 0) {
      uVar3 = 0;
      if (((uVar4 & 1) != 0) && ((**(uint **)(iVar2 + 0x128) & 0x100) != 0)) {
        uVar3 = 2;
        if (((int)((uint)*(ushort *)(iVar2 + 0x20) << 0x14) < 0) ||
           ((int)((uint)*(ushort *)(iVar2 + 0x3c) << 0x14) < 0)) {
          **(uint **)(iVar2 + 300) = **(uint **)(iVar2 + 300) & 0x5fffffff;
          *(uint *)(*(uint *)(iVar2 + 300) | 8) = *(uint *)(*(uint *)(iVar2 + 300) | 8) & 0x5fffffff
          ;
          *(uint *)(iVar2 + 0x20) = *(uint *)(iVar2 + 0x20) & 0xfffff7ff;
          *(uint *)(iVar2 + 0x3c) = *(uint *)(iVar2 + 0x3c) & 0xfffff7ff;
        }
        FUN_2000435c(iVar2,0,1,uVar1,uVar1,param_1,param_4);
      }
      for (; uVar3 < 10; uVar3 = uVar3 + 1) {
        if ((1 << (uVar3 & 0xff) & uVar4) != 0) {
          FUN_2000435c(iVar2,uVar3 & 0xff,0,uVar1,uVar1,param_1,param_4);
        }
      }
    }
    if ((uVar4 & 0x40000000) != 0) {
      FUN_2000461c(iVar2);
      FUN_20001ef0();
      for (uVar1 = 1; uVar1 < 4; uVar1 = uVar1 + 1 & 0xff) {
        if ((&DAT_0400037a)[uVar1] == '\0') {
          if ((&DAT_0400037e)[uVar1] != '\0') {
            (&DAT_0400037e)[uVar1] = 0;
            (&DAT_0400037a)[uVar1] = 0;
          }
        }
        else {
          (&DAT_0400037a)[uVar1] = (&DAT_0400037a)[uVar1] + -1;
        }
      }
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200048f0 @ 200048f0 */


int FUN_200048f0(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  uint uVar4;
  undefined4 local_18;
  
  uVar2 = param_2 + 0x3fU >> 6;
  uVar3 = 0;
  local_18 = param_4;
  FUN_20004c30(&local_18);
  do {
    for (uVar4 = 0; uVar4 < uVar2; uVar4 = uVar4 + 1 & 0xff) {
      if (0x4f < uVar3) {
        FUN_20004c3c(local_18);
        return 0;
      }
      if (((uint)*(byte *)(param_1 + 0x138 + (uVar3 >> 3)) & 1 << (uVar3 & 7)) != 0) {
        uVar3 = uVar3 + 1;
        break;
      }
      uVar3 = uVar3 + 1;
    }
    if (uVar2 <= uVar4) {
      if (uVar4 < uVar2) {
        FUN_20004c3c(local_18);
        iVar1 = 0;
      }
      else {
        for (uVar4 = 0; uVar4 < uVar2; uVar4 = uVar4 + 1 & 0xff) {
          *(byte *)(param_1 + 0x138 + ((uVar3 - uVar2) + uVar4 >> 3)) =
               *(byte *)(param_1 + 0x138 + ((uVar3 - uVar2) + uVar4 >> 3)) |
               (byte)(1 << ((uVar3 - uVar2) + uVar4 & 7));
        }
        FUN_20004c3c(local_18);
        iVar1 = *(int *)(param_1 + 0x134) + (uVar3 - uVar2) * 0x40;
      }
      return iVar1;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_2000499e @ 2000499e */


void FUN_2000499e(int param_1,uint param_2,int param_3)

{
  int iVar1;
  uint uVar2;
  undefined4 local_24;
  int iStack_20;
  uint uStack_1c;
  int local_18;
  
  if ((*(uint *)(param_1 + 0x134) <= param_2) && (param_2 < *(int *)(param_1 + 0x134) + 0x1400U)) {
    iVar1 = param_2 - *(int *)(param_1 + 0x134);
    iVar1 = (int)(((uint)(iVar1 >> 0x1f) >> 0x1a) + iVar1) >> 6;
    iStack_20 = param_1;
    uStack_1c = param_2;
    local_18 = param_3;
    FUN_20004c30(&local_24);
    for (uVar2 = 0; uVar2 < local_18 + 0x3fU >> 6; uVar2 = uVar2 + 1 & 0xff) {
      *(byte *)(param_1 + 0x138 + (iVar1 + uVar2 >> 3)) =
           *(byte *)(param_1 + 0x138 + (iVar1 + uVar2 >> 3)) & ~(byte)(1 << (iVar1 + uVar2 & 7));
    }
    FUN_20004c3c(local_24);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004a1a @ 20004a1a */


undefined8 FUN_20004a1a(int param_1,int *param_2,int param_3,undefined4 param_4)

{
  int **ppiVar1;
  undefined4 uVar2;
  uint uVar3;
  int iVar4;
  code *pcVar5;
  int *local_20;
  int local_1c;
  undefined4 local_18;
  
  ppiVar1 = &local_20;
  uVar3 = (uint)*(byte *)(param_2 + 2);
  uVar2 = 1;
  local_20 = param_2;
  local_1c = param_3;
  local_18 = param_4;
  if (uVar3 == 0x10) {
    *(undefined1 *)(param_1 + 0x90) = 1;
    *(undefined1 *)(param_1 + 0x8f) = 0;
    FUN_20002e34(param_1,0xe,0);
    *(undefined1 *)(param_1 + 0x8e) = 2;
    *(undefined1 *)(param_1 + 0x8c) = 0;
    uVar3 = 0;
    do {
      iVar4 = uVar3 * 0xc + param_1;
      *(undefined4 *)(iVar4 + 0x14) = 0;
      *(undefined4 *)(iVar4 + 0x18) = 0;
      uVar3 = uVar3 + 1;
      *(undefined1 *)(iVar4 + 0x1c) = 0;
    } while (uVar3 < 10);
    (**(code **)(param_1 + 0x10))(param_1,1,0);
    uVar2 = 0;
    *(undefined1 *)(param_1 + 0x90) = 0;
  }
  else {
    if (uVar3 == 0x11) {
      uVar2 = 0;
      ppiVar1 = (int **)0x2;
      pcVar5 = *(code **)(param_1 + 0x10);
    }
    else if (uVar3 == 0x12) {
      uVar2 = 0;
      ppiVar1 = (int **)0x3;
      pcVar5 = *(code **)(param_1 + 0x10);
    }
    else if (uVar3 == 0x18) {
      uVar2 = 0;
      ppiVar1 = (int **)&UsageFault;
      pcVar5 = *(code **)(param_1 + 0x10);
    }
    else {
      if ((4 < (uVar3 & 0xf)) ||
         (iVar4 = ((uVar3 & 0xf) << 1 | (uint)(*(byte *)(param_2 + 2) >> 7)) * 0xc + param_1,
         *(int *)(iVar4 + 0x14) == 0)) goto LAB_20004acc;
      local_20 = (int *)*param_2;
      local_1c = param_2[1];
      local_18 = CONCAT31((int3)((uint)param_4 >> 8),*(undefined1 *)((int)param_2 + 9));
      if (*(char *)((int)param_2 + 9) == '\0') {
        *(undefined1 *)(iVar4 + 0x1c) = 0;
      }
      else {
        *(undefined1 *)(param_1 + 0x1c) = 0;
        *(undefined1 *)(param_1 + 0x28) = 0;
      }
      uVar2 = *(undefined4 *)(iVar4 + 0x18);
      pcVar5 = *(code **)(iVar4 + 0x14);
    }
    uVar2 = (*pcVar5)(param_1,ppiVar1,uVar2);
  }
LAB_20004acc:
  return CONCAT44(local_20,uVar2);
}


/* ---------------------------------------------------------------------- */
/* FUN_20004ad0 @ 20004ad0 */


undefined4 FUN_20004ad0(int param_1,int param_2)

{
  undefined4 uVar1;
  
  if ((param_2 != 0) && (param_1 != 0)) {
    if (*(int *)(param_1 + 0x10) != 0) {
      uVar1 = FUN_20004a1a();
      return uVar1;
    }
    return 1;
  }
  return 3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004aee @ 20004aee */


void FUN_20004aee(undefined4 param_1,uint param_2)

{
  FUN_20004b9e(param_1,param_2 & 0xf);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004afa @ 20004afa */


void FUN_20004afa(undefined4 param_1)

{
  FUN_20002e34(param_1,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004b06 @ 20004b06 */


void FUN_20004b06(undefined4 param_1,uint param_2)

{
  FUN_20004b9e(param_1,(param_2 & 0xf) + 0x80);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004b14 @ 20004b14 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20004b22) */
/* WARNING: Removing unreachable block (ram,0x20004b22) */

undefined4 FUN_20004b14(int param_1,undefined4 param_2,undefined1 *param_3)

{
  undefined4 uVar1;
  undefined1 uVar2;
  
  uVar1 = 1;
  switch(param_2) {
  case 3:
    uVar1 = 0x11;
    break;
  default:
    goto switchD_20004b22_caseD_4;
  case 6:
    if (param_3 == (undefined1 *)0x0) {
      return 1;
    }
    uVar2 = *param_3;
    goto LAB_20004b54;
  case 7:
    if (*(char *)(param_1 + 0x8e) == '\x03') {
      param_3 = (undefined1 *)(param_1 + 0x8c);
      uVar1 = 8;
      break;
    }
    if (param_3 == (undefined1 *)0x0) {
      return 1;
    }
    *(undefined1 *)(param_1 + 0x8c) = *param_3;
    uVar2 = 3;
LAB_20004b54:
    uVar1 = 0;
    *(undefined1 *)(param_1 + 0x8e) = uVar2;
switchD_20004b22_caseD_4:
    return uVar1;
  case 10:
    uVar1 = 0xc;
    break;
  case 0xb:
    uVar1 = 0xd;
    break;
  case 0xc:
    uVar1 = 10;
    break;
  case 0xd:
    if (param_3 == (undefined1 *)0x0) {
      return 1;
    }
    *(undefined1 *)(param_1 + 0x8f) = *param_3;
    return 0;
  case 0xe:
    uVar1 = 0xb;
  }
  uVar1 = FUN_20002e34(param_1,uVar1,param_3);
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004b82 @ 20004b82 */


undefined4 FUN_20004b82(undefined4 param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  uint local_c;
  
  if ((param_2 & 0xf) < 5) {
    local_c = param_2;
    uVar1 = FUN_20002e34(param_1,4,&local_c,param_4,param_1);
    return uVar1;
  }
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004b9e @ 20004b9e */


int FUN_20004b9e(int param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  code *pcVar2;
  int iVar3;
  undefined4 local_28;
  int iStack_24;
  uint uStack_20;
  undefined4 local_1c;
  undefined4 uStack_18;
  
  if (param_1 == 0) {
    iVar1 = 3;
  }
  else if (*(int *)(param_1 + 0xc) == 0) {
    iVar1 = 6;
  }
  else {
    iVar3 = ((param_2 & 0xf) << 1 | param_2 >> 7) * 0xc + param_1;
    if (*(char *)(iVar3 + 0x1c) == '\0') {
      iStack_24 = param_1;
      uStack_20 = param_2;
      local_1c = param_3;
      uStack_18 = param_4;
      FUN_20004c30(&local_28);
      *(undefined1 *)(iVar3 + 0x1c) = 1;
      FUN_20004c3c(local_28);
      if ((int)(param_2 << 0x18) < 0) {
        pcVar2 = *(code **)(*(int *)(param_1 + 0xc) + 8);
      }
      else {
        pcVar2 = *(code **)(*(int *)(param_1 + 0xc) + 0xc);
      }
      iVar1 = (*pcVar2)(*(undefined4 *)(param_1 + 8),param_2,local_1c,param_4);
      if (iVar1 != 0) {
        FUN_20004c30(&local_28);
        *(undefined1 *)(iVar3 + 0x1c) = 0;
        FUN_20004c3c(local_28);
      }
    }
    else {
      iVar1 = 2;
    }
  }
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004c14 @ 20004c14 */


undefined4 FUN_20004c14(undefined4 param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  uint local_c;
  
  if ((param_2 & 0xf) < 5) {
    local_c = param_2;
    uVar1 = FUN_20002e34(param_1,5,&local_c,param_4,param_1);
    return uVar1;
  }
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004c30 @ 20004c30 */


void FUN_20004c30(undefined4 *param_1)

{
  bool bVar1;
  undefined4 uVar2;
  
  uVar2 = 0;
  bVar1 = (bool)isCurrentModePrivileged();
  if (bVar1) {
    uVar2 = isIRQinterruptsEnabled();
  }
  disableIRQinterrupts();
  *param_1 = uVar2;
  disableIRQinterrupts();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004c3c @ 20004c3c */


void FUN_20004c3c(uint param_1)

{
  bool bVar1;
  
  bVar1 = (bool)isCurrentModePrivileged();
  if (bVar1) {
    enableIRQinterrupts((param_1 & 1) == 1);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004c44 @ 20004c44 */


void FUN_20004c44(void)

{
  uint uVar1;
  
  disableIRQinterrupts();
  FUN_20005144(0x1b);
  FUN_20000ef4(0x1b);
  uVar1 = DAT_40000680;
  DAT_40000680 = uVar1 | 0x8000000;
  FUN_2000044c(0x101100);
  uVar1 = DAT_40000500;
  DAT_40000500 = uVar1 & 0xbeffffff;
  FUN_200018b8(12000000);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004c8c @ 20004c8c */


void FUN_20004c8c(void)

{
  FUN_2000e3c4(0);
  DAT_400001f0 = 0xff;
  FUN_2000e130();
  FUN_20007584();
  FUN_2000e778();
  FUN_20007368();
  FUN_2000e244();
  FUN_200074fc();
  FUN_2000ddf0();
  FUN_20007a4c();
  FUN_2000c1d4();
  FUN_2000e348();
  FUN_200079f8();
  FUN_20006d48();
  delay_ms(0x96);
  FUN_2000ce28();
  FUN_200073a8(0,7,1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004ce4 @ 20004ce4 */


undefined4 FUN_20004ce4(void)

{
  int iVar1;
  
  iVar1 = DAT_040005ec;
  DAT_040005e0 = DAT_040005e0 + 1;
  if (((DAT_040005e0 & 1) == 0) || (DAT_040005dc != 0)) {
    if (((DAT_040005e0 & 1) == 0) && (DAT_040005dc != 0)) {
      *(undefined4 *)(DAT_040005ec + 4) = 0;
      DAT_040005dc = 0;
      FUN_20000bd4();
    }
  }
  else {
    DAT_040005dc = 1;
    *(uint *)(DAT_040005ec + 4) = *(uint *)(DAT_040005ec + 4) | 2;
    *(undefined4 *)(iVar1 + 4) = 1;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004d30 @ 20004d30 */


void FUN_20004d30(void)

{
  uint uVar1;
  
  FUN_200079dc();
  FUN_2000c098();
  DAT_04000d65 = 0;
  FUN_2000cf94();
  FUN_20005004(&DAT_4000c000);
  FUN_2000e22c();
  FUN_200073a8(0,7);
  FUN_20000ee0(0x11);
  FUN_20000ee0(0x12);
  uVar1 = DAT_40020044;
  DAT_40020044 = uVar1 & 0xfffffffb;
  uVar1 = DAT_40020044;
  DAT_40020044 = uVar1 | 0x40;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004d84 @ 20004d84 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20004da4) */
/* WARNING: Removing unreachable block (ram,0x20004da4) */
/* WARNING: Type propagation algorithm not settling */

void FUN_20004d84(undefined4 param_1,uint param_2,undefined4 param_3,undefined4 param_4)

{
  undefined1 uVar1;
  int iVar2;
  uint uVar3;
  uint local_20 [3];
  
  if ((DAT_040009fd != '\0') && (DAT_040009fd = '\0', DAT_04000a10 != '\0')) {
    DAT_04000a10 = '\x06';
  }
  uVar1 = 6;
  local_20[0] = param_2;
  local_20[1] = param_3;
  local_20[2] = param_4;
  switch(DAT_04000a10) {
  case '\0':
    return;
  case '\x01':
    if ((DAT_04000d48 & 1) != 0) {
      FUN_2000de84(1);
      DAT_04000a10 = 2;
      return;
    }
    DAT_04000a10 = 0;
    return;
  case '\x02':
    if ((DAT_04000d4f & 1) == 0) {
      DAT_04000a10 = 3;
      DAT_04000d45 = 0;
      return;
    }
    return;
  case '\x03':
    FUN_20004d30();
    if (DAT_040009fb != '\0') {
      DAT_040009fc = '\0';
      local_20[0] = 0x606c0103;
      uVar3 = 0;
      local_20[1] = 0x108;
      do {
        FUN_200012a4();
        FUN_200012e4(&DAT_40002000,0,0,&LAB_2000e698_1);
        FUN_2000119c(&DAT_40002000,uVar3,~local_20[uVar3]);
        FUN_2000e6b4(uVar3,1);
        uVar3 = uVar3 + 1 & 0xff;
      } while (uVar3 < 2);
    }
    FUN_2000e3c4(1);
    FUN_20004c44();
    FUN_2000254c();
    FUN_20004b14(DAT_040009e0,10,0);
    do {
      WaitForInterrupt();
      wdt_feed();
      enableIRQinterrupts();
    } while (DAT_04000d45 == '\0');
    FUN_20004c8c();
    if (DAT_040009fb != '\0') {
      FUN_200011a8(&DAT_40002000);
      FUN_2000175c(&DAT_40004000);
      FUN_2000518c(2);
      FUN_2000518c(4);
      FUN_2000518c(5);
    }
    break;
  case '\x04':
    if (DAT_040009fc == '\0') {
      DAT_04000a10 = 6;
      return;
    }
    DAT_040009fc = '\0';
    if (DAT_040009fb == '\0') {
      DAT_040009fc = 0;
      DAT_04000a10 = 5;
      return;
    }
    iVar2 = FUN_20004b14(DAT_040009e0,0xc,0);
    if (iVar2 == 0) {
      DAT_04000a10 = 5;
      return;
    }
    break;
  case '\x05':
    goto switchD_20004da4_caseD_5;
  default:
    DAT_04000a10 = 0;
    return;
  }
  uVar1 = 4;
switchD_20004da4_caseD_5:
  DAT_04000a10 = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004eb8 @ 20004eb8 */


void FUN_20004eb8(void)

{
                    /* WARNING: Could not recover jumptable at 0x20004ec2. Too many branches */
                    /* WARNING: Treating indirect jump as call */
  (*DAT_040005c4)(&DAT_4000e000,DAT_040005c0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004ecc @ 20004ecc */


void FUN_20004ecc(undefined4 *param_1)

{
  ushort uVar1;
  int iVar2;
  
  *param_1 = 0;
  iVar2 = FUN_20004f04();
  uVar1 = *(ushort *)(&DAT_2000f42e + iVar2 * 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000240)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
    return;
  }
  DAT_40040018 = 1 << (uVar1 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004f04 @ 20004f04 */


void FUN_20004f04(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f430)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004f34 @ 20004f34 */


void FUN_20004f34(void)

{
  ushort uVar1;
  int iVar2;
  
  iVar2 = FUN_20004f04();
  uVar1 = *(ushort *)(&DAT_2000f42e + iVar2 * 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000220)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
  }
  else {
    DAT_40040014 = 1 << (uVar1 & 0xff);
  }
  DAT_40000630 = 0x100000;
  DAT_040005c4 = &LAB_20004f28_1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004f84 @ 20004f84 */


void FUN_20004f84(uint *param_1,int param_2,uint param_3,undefined4 param_4)

{
  int iVar1;
  
  iVar1 = FUN_20004f04();
  (&DAT_040005c0)[iVar1] = param_4;
  FUN_20000ef4((int)(char)(&DAT_2000f42c)[iVar1]);
  *param_1 = param_2 << 0x1f | param_3;
  return;
}


/* ---------------------------------------------------------------------- */
/* IRQ0_Handler @ 20004fb0 */


void IRQ0_Handler(void)

{
  uint uVar1;
  uint uVar2;
  
  uVar1 = DAT_4000c000;
  if ((int)((uVar1 & 0xc) << 0x1d) < 0) {
    uVar2 = DAT_4000c000;
    DAT_4000c000 = uVar2 & 0xfffffffe;
    FUN_20004fe8(&DAT_4000c000,4);
    uVar2 = DAT_4000c000;
    DAT_4000c000 = uVar2 | 1;
  }
  if ((int)((uVar1 & 0xc) << 0x1c) < 0) {
    FUN_20004fe8(&DAT_4000c000,8);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20004fe8 @ 20004fe8 */


void FUN_20004fe8(uint *param_1,int param_2)

{
  uint uVar1;
  
  uVar1 = *param_1 & 0xfffffff7;
  if (param_2 << 0x1d < 0) {
    uVar1 = *param_1 & 0xfffffff3;
  }
  if (param_2 << 0x1c < 0) {
    uVar1 = uVar1 | 8;
  }
  *param_1 = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005004 @ 20005004 */


void FUN_20005004(uint *param_1)

{
  ushort uVar1;
  int iVar2;
  
  *param_1 = *param_1 & 0xfffffffe;
  iVar2 = FUN_20005064();
  uVar1 = *(ushort *)(&DAT_2000f3b0 + iVar2 * 2);
  if (uVar1 >> 8 < 2) {
    (&DAT_40000240)[uVar1 >> 8] = 1 << (uVar1 & 0xff);
    return;
  }
  DAT_40040018 = 1 << (uVar1 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005040 @ 20005040 */


/* WARNING: Control flow encountered bad instruction data */

void FUN_20005040(undefined1 *param_1)

{
  if (param_1 != (undefined1 *)0x0) {
    *param_1 = 1;
    param_1[1] = 0;
    param_1[2] = 0;
    param_1[3] = 0;
    *(undefined4 *)(param_1 + 4) = 0xffffff;
    *(undefined4 *)(param_1 + 8) = 0xffffff;
    *(undefined4 *)(param_1 + 0xc) = 0;
    return;
  }
                    /* WARNING: Bad instruction - Truncating control flow here */
  halt_baddata();
}


/* ---------------------------------------------------------------------- */
/* FUN_20005064 @ 20005064 */


void FUN_20005064(int param_1)

{
  int iVar1;
  
  iVar1 = 0;
  do {
    if ((&DAT_2000f3b4)[iVar1] == param_1) {
      return;
    }
    iVar1 = iVar1 + 1;
  } while (iVar1 == 0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000508c @ 2000508c */


void FUN_2000508c(uint *param_1,byte *param_2,int param_3)

{
  byte bVar1;
  byte bVar2;
  byte bVar3;
  byte bVar4;
  ushort uVar5;
  int iVar6;
  uint *puVar7;
  
  puVar7 = param_1;
  if (param_2 != (byte *)0x0) {
    iVar6 = FUN_20005064();
    uVar5 = *(ushort *)(&DAT_2000f3b0 + iVar6 * 2);
    param_3 = 1;
    puVar7 = (uint *)(uint)uVar5;
    if (uVar5 >> 8 < 2) {
      (&DAT_40000220)[uVar5 >> 8] = 1 << (uVar5 & 0xff);
      goto LAB_200050bc;
    }
  }
  DAT_40040014 = param_3 << ((uint)puVar7 & 0xff);
LAB_200050bc:
  iVar6 = FUN_20005064(param_1);
  FUN_20001a38((&DAT_2000f3b8)[iVar6]);
  bVar1 = *param_2;
  bVar2 = param_2[1];
  bVar3 = param_2[2];
  bVar4 = param_2[3];
  param_1[6] = *(uint *)(param_2 + 4) & 0xffffff;
  param_1[1] = *(uint *)(param_2 + 8) & 0xffffff;
  param_1[5] = *(ushort *)(param_2 + 0xc) & 0x3ff;
  *param_1 = bVar1 & 1 | ((uint)bVar2 << 0x1f) >> 0x1e | ((uint)bVar3 << 0x1f) >> 0x1b |
             ((uint)bVar4 << 0x1f) >> 0x1a;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005114 @ 20005114 */


void FUN_20005114(int param_1)

{
  bool bVar1;
  uint uVar2;
  
  uVar2 = 0;
  bVar1 = (bool)isCurrentModePrivileged();
  if (bVar1) {
    uVar2 = isIRQinterruptsEnabled();
  }
  disableIRQinterrupts();
  *(undefined4 *)(param_1 + 8) = 0xaa;
  *(undefined4 *)(param_1 + 8) = 0x55;
  bVar1 = (bool)isCurrentModePrivileged();
  if (bVar1) {
    enableIRQinterrupts((uVar2 & 1) == 1);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* __ARM_common_switch8 @ 20005128 */


/* WARNING: This is an inlined function */

void __ARM_common_switch8(void)

{
  uint in_r3;
  uint uVar1;
  int unaff_lr;
  
  uVar1 = (uint)*(byte *)(unaff_lr + -1);
  if (in_r3 < *(byte *)(unaff_lr + -1)) {
    uVar1 = in_r3;
  }
                    /* WARNING: Could not recover jumptable at 0x20005140. Too many branches */
                    /* WARNING: Treating indirect jump as call */
  (*(code *)(unaff_lr + (uint)*(byte *)(unaff_lr + uVar1) * 2))();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005144 @ 20005144 */


void FUN_20005144(uint param_1)

{
  if (-1 < (int)param_1) {
    DAT_e000e280 = 1 << (param_1 & 0x1f);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000515c @ 2000515c */


void FUN_2000515c(uint param_1)

{
  if (-1 < (int)param_1) {
    DAT_e000e280 = 1 << (param_1 & 0x1f);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005174 @ 20005174 */


void FUN_20005174(uint param_1)

{
  if (-1 < (int)param_1) {
    DAT_e000e280 = 1 << (param_1 & 0x1f);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000518c @ 2000518c */


void FUN_2000518c(uint param_1)

{
  if (-1 < (int)param_1) {
    DAT_e000e180 = 1 << (param_1 & 0x1f);
    DataSynchronizationBarrier(0xf);
    InstructionSynchronizationBarrier(0xf);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200051ac @ 200051ac */


void FUN_200051ac(uint param_1,int param_2)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar2 = (param_1 << 0x1e) >> 0x1b;
  uVar1 = 0xff << uVar2;
  uVar2 = ((uint)(param_2 << 0x1e) >> 0x18) << uVar2;
  if (-1 < (int)param_1) {
    *(uint *)(&DAT_e000e400 + (param_1 & 0xfffffffc)) =
         *(uint *)(&DAT_e000e400 + (param_1 & 0xfffffffc)) & ~uVar1 | uVar2;
    return;
  }
  uVar3 = (param_1 & 0xf) - 8 & 0xfffffffc;
  *(uint *)(&DAT_e000ed1c + uVar3) = *(uint *)(&DAT_e000ed1c + uVar3) & ~uVar1 | uVar2;
  return;
}


/* ---------------------------------------------------------------------- */
/* NVIC_SystemReset @ 200051f0 */


/* AIRCR = 0x05FA0004 */

void NVIC_SystemReset(void)

{
  DataSynchronizationBarrier(0xf);
  DAT_e000ed0c = 0x5fa0004;
  DataSynchronizationBarrier(0xf);
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* __scatterload_zeroinit @ 2000521c */


/* ZI region clear */

void __scatterload_zeroinit(undefined4 param_1,undefined4 *param_2,int param_3)

{
  for (; param_3 != 0; param_3 = param_3 + -4) {
    *param_2 = 0;
    param_2 = param_2 + 1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000522c @ 2000522c */


void FUN_2000522c(undefined1 param_1,int param_2,undefined4 param_3,undefined1 param_4)

{
  int iVar1;
  undefined4 uVar2;
  
  iVar1 = FUN_20007c98(param_3);
  if ((iVar1 != 0) && (iVar1 = FUN_20005554(param_3), iVar1 == 0)) {
    param_2 = param_2 * 0x2c;
    (&DAT_04001ba4)[param_2] = (char)param_3;
    (&DAT_04001ba5)[param_2] = (char)((uint)param_3 >> 8);
    (&DAT_04001ba7)[param_2] = param_4;
    (&DAT_04001ba6)[param_2] = param_1;
    write_u32_le(0,&DAT_04001baa + param_2);
    write_u32_le(0,param_2 + 0x4001bb2);
    write_u32_le(0,param_2 + 0x4001bb6);
    write_u32_le(0,param_2 + 0x4001bba);
    write_u32_le(0,param_2 + 0x4001bbe);
    (&DAT_04001ba8)[param_2] = 0;
    iVar1 = write_u32_le(DAT_04001b9d,&DAT_04001bae + param_2);
    if (iVar1 == 0) {
      iVar1 = 1;
    }
    write_u32_le(iVar1,&DAT_04001bae + param_2);
    (&DAT_04001ba9)[param_2] = 1;
    uVar2 = FUN_20006f20(param_3);
    write_u32_le(uVar2,param_2 + 0x4001bc7);
    uVar2 = FUN_20006f7c(param_3);
    write_u32_le(uVar2,param_2 + 0x4001bcb);
    write_u32_le(0,param_2 + 0x4001bc2);
    (&DAT_04001bcf)[param_2] = 1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200052e0 @ 200052e0 */


void FUN_200052e0(void)

{
  uint uVar1;
  int iVar2;
  
  DAT_0400032f = 0;
  memcpy(&DAT_04000a66,&DAT_04000e40 + (uint)DAT_04000d74 * 0x164,0xd0);
  uVar1 = 0;
  do {
    iVar2 = uVar1 * 6;
    (&DAT_04000a18)[iVar2] = 0;
    (&DAT_04000a19)[iVar2] = 0;
    (&DAT_04000a1a)[iVar2] = 0;
    (&DAT_04000a1b)[iVar2] = 0;
    uVar1 = uVar1 + 1 & 0xff;
    (&DAT_04000a1d)[iVar2] = 0;
  } while (uVar1 < 0xd);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005330 @ 20005330 */


int FUN_20005330(int param_1)

{
  int iVar1;
  int iVar2;
  int iVar3;
  
  iVar3 = param_1 * 0x2c + 0x4001bb6;
  iVar1 = read_u32_le(iVar3);
  if (iVar1 == 0x3f) {
    iVar2 = 0;
  }
  else {
    iVar2 = iVar1 + 1;
  }
  write_u32_le(iVar2,iVar3);
  return iVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005360 @ 20005360 */


bool FUN_20005360(int param_1)

{
  return (&DAT_04001ba9)[param_1 * 0x2c] == '\x01';
}


/* ---------------------------------------------------------------------- */
/* FUN_2000537c @ 2000537c */


void FUN_2000537c(void)

{
  FUN_20001746(&DAT_40001000,0,0x1d,0x90);
  FUN_20007334(0,0x1d);
  FUN_20001746(&DAT_40001000,0,0x1e,0x90);
  FUN_20007334(0,0x1e);
  FUN_20001746(&DAT_40001000,0,8,0x90);
  FUN_20007334(0,8);
  FUN_20001746(&DAT_40001000,0,0x16,0x90);
  FUN_20007334(0,0x16);
  FUN_20001746(&DAT_40001000,1,3,0x90);
  FUN_20007334(1,3,0);
  FUN_20001746(&DAT_40001000,0,0,0x90);
  FUN_20007334(0,0);
  FUN_20001746(&DAT_40001000,0,0x15,0x90);
  FUN_20007334(0,0x15);
  FUN_20001746(&DAT_40001000,0,0x12,0x90);
  FUN_20007334(0,0x12);
  FUN_20001746(&DAT_40001000,0,0x13,0x90);
  FUN_20007334(0,0x13);
  FUN_20001746(&DAT_40001000,0,1,0x90);
  FUN_20007334(0,1);
  FUN_20001746(&DAT_40001000,1,7,0x90);
  FUN_20007334(1,7);
  FUN_20001746(&DAT_40001000,1,8,0x90);
  FUN_20007334(1,8,0);
  FUN_20001746(&DAT_40001000,0,6,0x180);
  FUN_20007334(0,6);
  FUN_20001746(&DAT_40001000,0,5,0x180);
  FUN_20007334(0,5);
  FUN_20001746(&DAT_40001000,0,7,0x90);
  FUN_20007334(0,7,1);
  FUN_200073a8(0,7,1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200054e0 @ 200054e0 */


void FUN_200054e0(void)

{
  byte bVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  
  uVar2 = DAT_04000330;
  uVar3 = 0;
  do {
    iVar4 = uVar3 * 6;
    bVar1 = (&DAT_04000a18)[iVar4];
    if (((int)((uint)bVar1 << 0x1e) < 0) && ((&DAT_04000a1a)[iVar4] != '\0')) {
      if ((uint)(byte)(&DAT_04000a19)[iVar4] == (uVar2 >> (uVar3 & 0xff) & 1)) {
        (&DAT_04000a1b)[iVar4] = (&DAT_04000a1b)[iVar4] + '\x01';
      }
      else {
        (&DAT_04000a1a)[iVar4] = (&DAT_04000a1a)[iVar4] + -1;
      }
    }
    else if ((uVar2 >> (uVar3 & 0xff) & 1) == 0) {
      if (((&DAT_04000a19)[iVar4] != '\x01') && ((bVar1 & 1) != 0)) goto LAB_20005544;
    }
    else if (((&DAT_04000a19)[iVar4] != '\0') && ((bVar1 & 1) == 0)) {
LAB_20005544:
      (&DAT_04000a1a)[iVar4] = (&DAT_04000a1a)[iVar4] + '\x01';
    }
    uVar3 = (uint)(char)((char)uVar3 + '\x01');
    if (10 < (int)uVar3) {
      return;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_20005554 @ 20005554 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

bool FUN_20005554(uint param_1)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  uVar1 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar2 <= uVar1) {
      return false;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar1 = uVar1 + 1 & 0xffff;
  }
  return (char)(&DAT_04001624)[uVar1 * 0xe] < '\0';
}


/* ---------------------------------------------------------------------- */
/* FUN_200055b0 @ 200055b0 */


undefined4 FUN_200055b0(uint param_1)

{
  ushort uVar1;
  undefined2 uVar2;
  uint uVar3;
  int iVar4;
  uint uVar5;
  int iVar6;
  
  uVar3 = 0;
  uVar5 = 0;
  while( true ) {
    if (CONCAT11(DAT_04001b9c,DAT_04001b9b) + uVar3 <= uVar5) {
      return 0;
    }
    iVar6 = uVar5 * 0xe;
    if ((*(ushort *)(&DAT_04001623 + iVar6) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + iVar6) & 0x7fff) == 0) {
      uVar3 = uVar3 + 1 & 0xffff;
    }
    uVar5 = uVar5 + 1 & 0xffff;
  }
  uVar1 = *(ushort *)(&DAT_04001625 + uVar5 * 0xe);
  if (uVar1 == 0) {
    return 0;
  }
  uVar2 = read_u32_le(&DAT_04001627 + iVar6);
  uVar3 = FUN_20005954((uint)uVar1 << 8,uVar2);
  iVar4 = read_u32_le(&DAT_04001627 + iVar6);
  if (uVar3 != *(ushort *)(iVar4 + (uint)*(ushort *)(&DAT_04001625 + iVar6) * 0x100)) {
    return 0;
  }
  uVar1 = *(ushort *)(&DAT_0400162b + iVar6);
  if (uVar1 == 0) {
    return 1;
  }
  uVar2 = read_u32_le(&DAT_0400162d + iVar6);
  uVar3 = FUN_20005954((uint)uVar1 << 8,uVar2);
  iVar4 = read_u32_le(&DAT_0400162d + iVar6);
  if (uVar3 == *(ushort *)(iVar4 + (uint)*(ushort *)(&DAT_0400162b + iVar6) * 0x100)) {
    return 1;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005694 @ 20005694 */


void FUN_20005694(void)

{
  int iVar1;
  
  if (DAT_04000437 == '\x01') {
    DAT_0400043e = DAT_0400043e + 1;
    if (CONCAT11(DAT_04001b9c,DAT_04001b9b) < DAT_0400043e) {
      DAT_04000440 = 0;
      DAT_0400043e = 0;
      DAT_0400043c = 0;
      DAT_04000436 = 2;
    }
    else {
      for (; ((*(ushort *)(&DAT_04001623 + (uint)DAT_0400043c * 0xe) & 0x7fff) == 0 &&
             (DAT_0400043c < 100)); DAT_0400043c = DAT_0400043c + 1) {
      }
      iVar1 = FUN_200055b0(*(ushort *)(&DAT_04001623 + (uint)DAT_0400043c * 0xe) & 0x7fff);
      if (iVar1 != 0) {
        return;
      }
      DAT_04000440 = *(ushort *)(&DAT_04001623 + (uint)DAT_0400043c * 0xe) & 0x7fff;
      DAT_04000436 = 3;
    }
    DAT_04000437 = '\0';
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005728 @ 20005728 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20005728(void)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  for (uVar1 = 0; uVar1 < _DAT_04001b9b + uVar2; uVar1 = uVar1 + 1 & 0xffff) {
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005768 @ 20005768 */


void FUN_20005768(void)

{
  if ((DAT_04002d20 & 1) != 0) {
    FUN_2000daac();
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000577c @ 2000577c */


void FUN_2000577c(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  uint uVar2;
  int iVar3;
  
  uVar2 = (uint)DAT_04000d74;
  iVar1 = (uint)DAT_04000d74 * 6;
  if (param_1 != 0) {
    (&DAT_04000d75)[iVar1] = DAT_04000c59;
    memcpy(&DAT_04000d76 + iVar1,&DAT_04000376,4,&DAT_04000d71,param_4);
    (&DAT_04000d7a)[iVar1] = DAT_0400036c;
    iVar1 = uVar2 * 0x164;
    (&DAT_04000e3f)[iVar1] = DAT_0400036e;
    (&DAT_04000e3e)[iVar1] = DAT_0400036d;
    return;
  }
  iVar3 = uVar2 * 0x164;
  DAT_04000c58 = (&DAT_04000db5)[iVar3];
  memcpy(&DAT_04000c5a,iVar3 + 0x4000e1f,0x1f,&DAT_04000d71,param_4);
  DAT_04000c59 = (&DAT_04000d75)[iVar1];
  memcpy(&DAT_04000376,&DAT_04000d76 + iVar1,4);
  DAT_0400036c = (&DAT_04000d7a)[iVar1];
  DAT_0400036e = (&DAT_04000e3f)[iVar3];
  DAT_0400036d = (&DAT_04000e3e)[iVar3];
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000580c @ 2000580c */


void FUN_2000580c(undefined1 *param_1)

{
  byte bVar1;
  undefined1 *puVar2;
  
  puVar2 = &DAT_04002d8d + (uint)(byte)param_1[1] * 0x23;
  bVar1 = 0;
  do {
    *puVar2 = *param_1;
    bVar1 = bVar1 + 1;
    param_1 = param_1 + 1;
    puVar2 = puVar2 + 1;
  } while (bVar1 < 2);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005834 @ 20005834 */


void FUN_20005834(int param_1)

{
  int iVar1;
  
  iVar1 = (g_razer_report.args[0] - 1 & 0xff) * 0x164 + param_1 * 0x23;
  *(byte *)(iVar1 + 0x4000db9) = g_razer_report.args[2];
  *(byte *)(iVar1 + 0x4000dc5) = g_razer_report.args[3];
  *(byte *)(iVar1 + 0x4000dc4) = g_razer_report.args[4];
  *(byte *)(iVar1 + 0x4000dbb) = g_razer_report.args[5];
  *(byte *)(iVar1 + 0x4000dbc) = g_razer_report.args[6];
  *(byte *)(iVar1 + 0x4000dbd) = g_razer_report.args[7];
  *(byte *)(iVar1 + 0x4000dbe) = g_razer_report.args[8];
  *(undefined1 *)(iVar1 + 0x4000dbf) = 0xff;
  *(byte *)(iVar1 + 0x4000dc0) = g_razer_report.args[9];
  *(byte *)(iVar1 + 0x4000dc1) = g_razer_report.args[10];
  *(byte *)(iVar1 + 0x4000dc2) = g_razer_report.args[0xb];
  *(undefined1 *)(iVar1 + 0x4000dc3) = 0xff;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005888 @ 20005888 */


void FUN_20005888(int param_1,int param_2,int *param_3)

{
  undefined2 uVar1;
  ushort uVar2;
  short sVar3;
  int iVar4;
  int iVar5;
  
  iVar4 = FUN_200084cc();
  *param_3 = iVar4;
  if (iVar4 == 0) {
    iVar4 = FUN_20008456(param_1,*(undefined4 *)(param_2 + 0xc));
    *param_3 = iVar4;
    if (iVar4 == 0) {
      iVar4 = FUN_200083d8(param_1,*(undefined4 *)(param_2 + 4),*(undefined4 *)(param_2 + 0xc));
      *param_3 = iVar4;
      if (iVar4 == 0) {
        iVar4 = FUN_2000840a(param_1,*(undefined4 *)(param_2 + 8),*(undefined4 *)(param_2 + 0xc));
        *param_3 = iVar4;
        if (iVar4 == 0) {
          iVar5 = *(int *)(param_2 + 4);
          iVar4 = *(int *)(param_1 + 4);
          uVar1 = *(undefined2 *)(param_1 + 0x12);
          uVar2 = __aeabi_uidiv(iVar5 - iVar4);
          sVar3 = __aeabi_uidiv(((iVar5 + *(int *)(param_2 + 0xc)) - iVar4) + -1,uVar1);
          DAT_040033a0 = (uint)uVar2 << 0xf;
          DAT_040033b4 = (uint)*(ushort *)(param_1 + 0x12);
          DAT_040033ac = (sVar3 - uVar2) + 1;
          DAT_040033aa = uVar2;
          iVar4 = FUN_20006af4(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
          *param_3 = iVar4;
          if (iVar4 == 0) {
            DAT_040033a0 = *(int *)(param_2 + 4);
            DAT_040033a4 = *(undefined4 *)(param_2 + 8);
            DAT_040033a8 = *(ushort *)(param_2 + 0xc);
            DAT_040005fc = (uint)DAT_040033a8;
            DAT_040033b8 = (uint)*(ushort *)(param_1 + 0x10);
            DAT_040033c0 = *(undefined4 *)(param_2 + 0x10);
            DAT_040033bc = *(undefined2 *)(param_1 + 0x14);
            DAT_040033be = (ushort)**(byte **)(param_1 + 0x20);
            DAT_04000600 = 1;
            iVar4 = FUN_20006b48(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
            *param_3 = iVar4;
          }
        }
      }
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005954 @ 20005954 */


uint FUN_20005954(byte *param_1,uint param_2)

{
  uint uVar1;
  uint uVar2;
  
  uVar1 = 0xffff;
  while (param_2 != 0) {
    uVar2 = (uint)*param_1 ^ uVar1 >> 8;
    uVar2 = uVar2 >> 4 ^ uVar2;
    uVar1 = (uVar1 << 8 ^ uVar2 << 0xc ^ uVar2 << 5 ^ uVar2) & 0xffff;
    param_1 = param_1 + 1;
    param_2 = param_2 - 1 & 0xffff;
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005988 @ 20005988 */


uint FUN_20005988(byte *param_1,uint param_2,uint param_3)

{
  uint uVar1;
  
  while (param_2 != 0) {
    uVar1 = (uint)*param_1 ^ param_3 >> 8;
    uVar1 = uVar1 >> 4 ^ uVar1;
    param_3 = (param_3 << 8 ^ uVar1 << 0xc ^ uVar1 << 5 ^ uVar1) & 0xffff;
    param_1 = param_1 + 1;
    param_2 = param_2 - 1 & 0xffff;
  }
  return param_3;
}


/* ---------------------------------------------------------------------- */
/* FUN_200059b8 @ 200059b8 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20005a2e) */
/* WARNING: Removing unreachable block (ram,0x20005a2e) */

void FUN_200059b8(int param_1)

{
  char cVar1;
  undefined1 uVar2;
  undefined1 uVar3;
  undefined1 uVar4;
  undefined2 uVar5;
  short sVar6;
  bool bVar7;
  int iVar8;
  int iVar9;
  int iVar10;
  int iVar11;
  uint uVar12;
  int iVar13;
  int iVar14;
  undefined *puVar15;
  byte bVar16;
  int iVar17;
  uint local_40;
  
  bVar7 = false;
  iVar13 = param_1 * 0x2c;
  iVar17 = iVar13 + 0x4001bc2;
  iVar8 = read_u32_le(iVar17);
  iVar9 = iVar13 + 0x4001bbe;
  iVar10 = read_u32_le();
  iVar14 = iVar13 + 0x4001bb6;
  puVar15 = &DAT_04001bae + iVar13;
  if (iVar8 == iVar10) {
    (&DAT_04001ba8)[iVar13] = (&DAT_04001ba8)[iVar13] + '\x01';
    write_u32_le(0,&DAT_04001baa + iVar13);
    iVar8 = write_u32_le(DAT_04001b9d,puVar15);
    if (iVar8 == 0) {
      iVar8 = 1;
    }
    write_u32_le(iVar8,puVar15);
    (&DAT_04001bc6)[iVar13] = 0;
    write_u32_le(0,iVar13 + 0x4001bb2);
    write_u32_le(0,iVar14);
    write_u32_le(0,iVar13 + 0x4001bba);
    write_u32_le(0,iVar9);
    write_u32_le(0,iVar17);
    if ((&DAT_04001ba6)[iVar13] != '\x0f') {
      return;
    }
    goto LAB_20005eaa;
  }
  iVar8 = FUN_20005330(param_1);
  iVar10 = param_1 * 8 + 0x4002292;
  iVar11 = param_1 * 0x10;
  switch((&DAT_04001de0)[iVar8 + param_1 * 0x40]) {
  default:
    (&DAT_04001ba9)[iVar13] = 0;
    FUN_20007b10(*(undefined2 *)(&DAT_04001ba4 + iVar13));
    __aeabi_memclr(&DAT_04000c48,8);
    DAT_04000430 = DAT_04000430 | 9;
    DAT_0400046c = 0;
    return;
  case 1:
    uVar12 = 2;
    do {
      iVar8 = read_u32_le(iVar14);
      if ((&DAT_04001de0)[iVar8 + param_1 * 0x40] == (&DAT_04000c48)[uVar12]) {
        bVar7 = true;
      }
      uVar12 = uVar12 + 1 & 0xff;
    } while (uVar12 < 8);
    uVar12 = 2;
    do {
      if (bVar7) break;
      if ((&DAT_04000c48)[uVar12] == '\0') {
        iVar8 = read_u32_le(iVar14);
        uVar2 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
        (&DAT_04000c48)[uVar12] = uVar2;
        *(undefined1 *)(iVar10 + uVar12) = uVar2;
        DAT_04000430 = DAT_04000430 | 1;
        break;
      }
      uVar12 = uVar12 + 1 & 0xff;
    } while (uVar12 < 8);
    FUN_20005330(param_1);
    break;
  case 2:
    local_40 = 2;
    do {
      iVar8 = read_u32_le(iVar14);
      if ((&DAT_04001de0)[iVar8 + param_1 * 0x40] == (&DAT_04000c48)[local_40]) {
        (&DAT_04000c48)[local_40] = 0;
        *(undefined1 *)(iVar10 + local_40) = 0;
        DAT_04000430 = DAT_04000430 | 1;
        break;
      }
      local_40 = local_40 + 1 & 0xff;
    } while (local_40 < 8);
    FUN_20005330(param_1);
    goto LAB_20005afa;
  case 3:
    DAT_04002130 = 3;
    (&DAT_040021c2)[iVar11] = 3;
    iVar8 = FUN_20005330(param_1);
    DAT_04002131 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    (&DAT_040021c3)[iVar11] = DAT_04002131;
    DAT_04000430 = DAT_04000430 | 2;
    break;
  case 4:
    DAT_04002130 = 3;
    (&DAT_040021c2)[iVar11] = 3;
    iVar8 = FUN_20005330(param_1);
    DAT_04002131 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    bVar16 = 2;
    (&DAT_040021c3)[iVar11] = DAT_04002131;
    goto LAB_20005c94;
  case 5:
    DAT_04002120 = 2;
    (&DAT_040021c2)[iVar11] = 2;
    iVar8 = FUN_20005330(param_1);
    (&DAT_040021c3)[iVar11] = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    (&DAT_040021c4)[iVar11] = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    uVar5 = *(undefined2 *)(&DAT_040021c3 + iVar11);
    DAT_04002121 = (undefined1)((ushort)uVar5 >> 8);
    DAT_04002122 = (undefined1)uVar5;
    DAT_04000430 = DAT_04000430 | 4;
    goto LAB_20005d66;
  case 6:
    DAT_04002120 = 2;
    (&DAT_040021c2)[iVar11] = 2;
    iVar8 = FUN_20005330(param_1);
    (&DAT_040021c3)[iVar11] = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    (&DAT_040021c4)[iVar11] = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    uVar5 = *(undefined2 *)(&DAT_040021c3 + iVar11);
    DAT_04002121 = (undefined1)((ushort)uVar5 >> 8);
    DAT_04002122 = (undefined1)uVar5;
    DAT_04000430 = DAT_04000430 | 4;
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -3;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 3;
    goto LAB_20005c52;
  case 8:
    iVar8 = FUN_20005330(param_1);
    DAT_0400046c = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    (&DAT_04002140)[param_1 * 10] = DAT_0400046c;
    bVar16 = 8;
LAB_20005c94:
    DAT_04000430 = DAT_04000430 | bVar16;
LAB_20005afa:
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -2;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 2;
LAB_20005c52:
    iVar8 = write_u32_le(iVar8,iVar17);
    (&DAT_04001bcf)[iVar13] = (&DAT_04001bcf)[iVar13] + -1;
    if ((&DAT_04001ba6)[iVar13] != '\x0f') {
      return;
    }
    iVar10 = read_u32_le(iVar9);
    if (iVar8 != iVar10) {
      return;
    }
    (&DAT_04001ba8)[iVar13] = (&DAT_04001ba8)[iVar13] + '\x01';
    write_u32_le(0,&DAT_04001baa + iVar13);
    iVar8 = write_u32_le(DAT_04001b9d,puVar15);
    if (iVar8 == 0) {
      iVar8 = 1;
    }
    write_u32_le(iVar8,puVar15);
    (&DAT_04001bc6)[iVar13] = 0;
    write_u32_le(0,iVar13 + 0x4001bb2);
    write_u32_le(0,iVar14);
    write_u32_le(0,iVar13 + 0x4001bba);
    write_u32_le(0,iVar9);
    write_u32_le(0,iVar17);
LAB_20005eaa:
    (&DAT_04001bcf)[iVar13] = 0;
    (&DAT_04001ba9)[iVar13] = 0;
    return;
  case 10:
    iVar8 = FUN_20005330(param_1);
    DAT_0400046d = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    DAT_04000430 = DAT_04000430 | 8;
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -2;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 2;
    goto LAB_20005d16;
  case 0x11:
    iVar8 = FUN_20005330(param_1);
    cVar1 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    if (cVar1 != '\0') {
      write_u32_le(cVar1,&DAT_04001baa + iVar13);
    }
    break;
  case 0x12:
    iVar8 = FUN_20005330(param_1);
    uVar2 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    sVar6 = CONCAT11(uVar2,(&DAT_04001de0)[iVar8 + param_1 * 0x40]);
    if (sVar6 != 0) {
      write_u32_le(sVar6,&DAT_04001baa + iVar13);
    }
LAB_20005d66:
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -3;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 3;
    goto LAB_20005aac;
  case 0x13:
    iVar8 = FUN_20005330(param_1);
    uVar2 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    uVar3 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    uVar12 = (uint)CONCAT21(CONCAT11(uVar2,uVar3),(&DAT_04001de0)[iVar8 + param_1 * 0x40]);
    if (uVar12 != 0) {
      write_u32_le(uVar12,&DAT_04001baa + iVar13);
    }
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -4;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 4;
    goto LAB_20005aac;
  case 0x14:
    iVar8 = FUN_20005330(param_1);
    uVar2 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    uVar3 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    uVar4 = (&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    iVar8 = CONCAT31(CONCAT21(CONCAT11(uVar2,uVar3),uVar4),(&DAT_04001de0)[iVar8 + param_1 * 0x40]);
    if (iVar8 != 0) {
      write_u32_le(iVar8,&DAT_04001baa + iVar13);
    }
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -5;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 5;
    goto LAB_20005aac;
  case 0x15:
    iVar8 = FUN_20005330(param_1);
    DAT_0400046e = (ushort)(byte)(&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    DAT_0400046e = CONCAT11((undefined1)DAT_0400046e,(&DAT_04001de0)[iVar8 + param_1 * 0x40]);
    iVar8 = FUN_20005330(param_1);
    DAT_04000470 = (ushort)(byte)(&DAT_04001de0)[iVar8 + param_1 * 0x40];
    iVar8 = FUN_20005330(param_1);
    DAT_04000470 = CONCAT11((undefined1)DAT_04000470,(&DAT_04001de0)[iVar8 + param_1 * 0x40]);
    DAT_04000430 = DAT_04000430 | 8;
    (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -5;
    iVar8 = read_u32_le(iVar17);
    iVar8 = iVar8 + 5;
LAB_20005d16:
    write_u32_le(iVar8,iVar17);
    (&DAT_04001bcf)[iVar13] = (&DAT_04001bcf)[iVar13] + -1;
    return;
  }
  (&DAT_04001bc6)[iVar13] = (&DAT_04001bc6)[iVar13] + -2;
  iVar8 = read_u32_le(iVar17);
  iVar8 = iVar8 + 2;
LAB_20005aac:
  write_u32_le(iVar8,iVar17);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005eb8 @ 20005eb8 */


void FUN_20005eb8(int param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = param_1 * 0x2c;
  (&DAT_04001ba7)[iVar1] = 0;
  write_u32_le(0,iVar1 + 0x4001bb2,param_3,param_4,param_4);
  (&DAT_04001ba9)[iVar1] = 0;
  (&DAT_04001bc6)[iVar1] = 0;
  if ((&DAT_04002140)[param_1 * 10] != '\0') {
    DAT_0400046c = 0;
    (&DAT_04002140)[param_1 * 10] = 0;
    DAT_04000430 = DAT_04000430 | 8;
  }
  iVar1 = param_1 * 8 + 0x4002292;
  uVar2 = 2;
  do {
    if (*(char *)(iVar1 + uVar2) != '\0') {
      (&DAT_04000c48)[uVar2] = 0;
      *(undefined1 *)(iVar1 + uVar2) = 0;
      DAT_04000430 = DAT_04000430 | 1;
    }
    uVar2 = uVar2 + 1 & 0xff;
  } while (uVar2 < 8);
  param_1 = param_1 * 0x10;
  if ((&DAT_040021c2)[param_1] == '\x03') {
    if ((&DAT_040021c3)[param_1] == '\0') {
      return;
    }
    DAT_04002131 = 0;
    DAT_04002130 = (&DAT_040021c2)[param_1];
    (&DAT_040021c3)[param_1] = 0;
    DAT_04000430 = DAT_04000430 | 2;
  }
  if (((&DAT_040021c2)[param_1] == '\x02') && ((&DAT_040021c3)[param_1] != '\0')) {
    DAT_04002121 = 0;
    DAT_04002122 = 0;
    DAT_04002120 = (&DAT_040021c2)[param_1];
    (&DAT_040021c4)[param_1] = 0;
    (&DAT_040021c3)[param_1] = 0;
    DAT_04000430 = DAT_04000430 | 4;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20005f80 @ 20005f80 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20006028) */
/* WARNING: Removing unreachable block (ram,0x20006028) */

void FUN_20005f80(int param_1,int param_2)

{
  char cVar1;
  int iVar2;
  undefined1 uVar3;
  undefined *puVar4;
  undefined1 *puVar5;
  uint uVar6;
  undefined1 auStack_30 [20];
  int local_1c;
  uint local_18;
  
  uVar6 = 0;
  puVar4 = (&PTR_DAT_0400049c)[*(byte *)(param_1 + 1)];
  if (param_2 != 0) {
    local_1c = (uint)*(byte *)(param_1 + 1) * 0x23;
    puVar5 = &DAT_04002d8d + local_1c;
    local_18 = (uint)(byte)(&DAT_04002d8f)[local_1c];
    memcpy(auStack_30,&DAT_04002d9d + local_1c,0x13);
    memcpy(puVar5,&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + local_1c,0x23);
    (&DAT_04002d8f)[(uint)*(byte *)(param_1 + 1) * 0x23] = (char)local_18;
    memcpy(&DAT_04002d9d + (uint)*(byte *)(param_1 + 1) * 0x23,auStack_30,0x13);
  }
  for (; uVar6 < (byte)(&DAT_04000491)[*(byte *)(param_1 + 1)]; uVar6 = uVar6 + 1 & 0xff) {
    memcpy(puVar4 + uVar6 * 0xc + 8,puVar4 + uVar6 * 0xc + 4,4);
  }
  iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
  switch((&UNK_2000f2d4)
         [(uint)(byte)(&DAT_04002d90)[iVar2] + (uint)(byte)(&DAT_04002d8f)[iVar2] * 10]) {
  case 0:
    (&DAT_04002d8f)[iVar2] = (&DAT_04002d90)[iVar2];
    write_u32_le(2000,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da6);
    write_u32_le(2000,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da2);
    break;
  case 1:
    (&DAT_04002d9d)[iVar2] = 1;
    write_u32_le(0,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002daa);
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002d9e)[iVar2] = 10;
    (&DAT_04002d9f)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002da0)[iVar2] = 1;
    (&DAT_04002da1)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002dae)[iVar2] = 0;
    (&DAT_04002daf)[iVar2] = 0;
    write_u32_le(2000,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da6);
    write_u32_le(2000,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da2);
    uVar3 = 9;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    goto LAB_20006178;
  case 2:
  case 3:
    (&DAT_04002d9d)[iVar2] = 3;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002d9e)[iVar2] = 10;
    (&DAT_04002d9f)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002da0)[iVar2] = 10;
    (&DAT_04002da1)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002dae)[iVar2] = 0;
    (&DAT_04002daf)[iVar2] = 0;
    write_u32_le(0x5dc,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da6);
    write_u32_le(0x5dc,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da2);
    FUN_20006780(param_1);
    break;
  case 4:
    (&DAT_04002d9d)[iVar2] = 2;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002d9e)[iVar2] = 10;
    (&DAT_04002d9f)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002da0)[iVar2] = 1;
    (&DAT_04002da1)[iVar2] = 0;
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    (&DAT_04002dae)[iVar2] = 0;
    (&DAT_04002daf)[iVar2] = 0;
    write_u32_le(2000,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da6);
    write_u32_le(0,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002da2);
    iVar2 = (uint)*(byte *)(param_1 + 1) * 0x23;
    uVar3 = (&DAT_04002d90)[iVar2];
LAB_20006178:
    (&DAT_04002d8f)[iVar2] = uVar3;
  }
  uVar6 = (uint)*(byte *)(param_1 + 1);
  cVar1 = (&DAT_04002d90)[uVar6 * 0x23];
  if (cVar1 == '\x01') {
    for (uVar6 = 0; uVar6 < (byte)(&DAT_04000491)[*(byte *)(param_1 + 1)]; uVar6 = uVar6 + 1 & 0xff)
    {
      memcpy(puVar4 + uVar6 * 0xc,(uint)*(byte *)(param_1 + 1) * 0x23 + 0x4002d93,4);
    }
  }
  else if (cVar1 == '\x03') {
    DAT_04002d69 = 0;
    DAT_04002d6a = 0;
    DAT_04002d6b = 0;
    DAT_04002d6c = 0;
    DAT_04002d65 = 1;
    DAT_04002d66 = 0;
    DAT_04002d63 = 10;
    DAT_04002d64 = 0;
    DAT_04002d67 = 0;
    DAT_04002d5f = 0xff;
    DAT_04002d60 = 0x18;
    DAT_04002d61 = 0xff;
    DAT_04002d62 = 0xff;
    for (uVar6 = 0; uVar6 < (byte)(&DAT_04000491)[*(byte *)(param_1 + 1)]; uVar6 = uVar6 + 1 & 0xff)
    {
      iVar2 = uVar6 * 0xc;
      puVar4[iVar2] = 0xff;
      puVar4[iVar2 + 1] = 0x18;
      puVar4[iVar2 + 2] = 0xff;
      puVar4[iVar2 + 3] = 0xff;
    }
    DAT_04002d20 = DAT_04002d20 | 1;
  }
  else if (cVar1 == '\x04') {
    (&DAT_04002d6d)[uVar6] = (&DAT_04002d9c)[uVar6 * 0x23];
    (&DAT_04002d73)[*(byte *)(param_1 + 1)] = (&DAT_04002d9b)[(uint)*(byte *)(param_1 + 1) * 0x23];
    iVar2 = (uint)*(byte *)(param_1 + 1) * 2;
    (&DAT_04002d76)[iVar2] = 0;
    (&DAT_04002d77)[iVar2] = 0;
    (&DAT_04002d70)[*(byte *)(param_1 + 1)] = 0;
    for (uVar6 = 0; uVar6 < (byte)(&DAT_04000491)[*(byte *)(param_1 + 1)]; uVar6 = uVar6 + 1 & 0xff)
    {
      memcpy(puVar4 + uVar6 * 0xc,&DAT_2000f1e4 + uVar6 * 4,4);
    }
    DAT_04002d20 = DAT_04002d20 | 4;
  }
  else if (cVar1 == '\b') {
    __aeabi_memclr(puVar4,(&DAT_04000491)[uVar6]);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200062ac @ 200062ac */


undefined4 FUN_200062ac(uint param_1)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  
  uVar3 = 1 << (param_1 & 0xff);
  if (((uVar3 & ~(uint)DAT_04000d99) == 0) && (param_1 != 1)) {
    DAT_04000d99 = DAT_04000d99 & ~(byte)uVar3;
    uVar3 = read_u32_le(param_1 * 0x164 + 0x4000c49);
    if (uVar3 != 0) {
      iVar1 = read_u32_le(param_1 * 0x164 + 0x4000c4d);
      iVar2 = read_u32_le();
      write_u32_le(iVar2 + (iVar1 + 2U & 0xff00) + 0x100,&DAT_04001b9e);
      FUN_20006dbc(uVar3 >> 8,iVar1 + 2U & 0xffff);
      settings_mark_dirty(0x80,0);
    }
  }
  else {
    if (4 < param_1 - 1) {
      return 0;
    }
    if ((DAT_04000d99 & uVar3) != 0) {
      return 0;
    }
    if (param_1 == 1) {
      return 0;
    }
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006330 @ 20006330 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000633e) */
/* WARNING: Removing unreachable block (ram,0x2000633e) */

void FUN_20006330(int param_1,int param_2,uint param_3,undefined4 param_4)

{
  byte bVar1;
  uint uVar2;
  int extraout_r1;
  int iVar3;
  int iVar4;
  int extraout_r3;
  uint uVar5;
  undefined4 local_1c;
  undefined1 *local_18;
  
  local_1c = 0;
  uVar2 = (uint)*(byte *)(param_1 + 2);
  if (8 < uVar2) {
    uVar2 = 9;
  }
  iVar4 = (uint)(&switchD_2000633e::switchdataD_20006343)[uVar2] * 2;
  local_18 = (undefined1 *)param_4;
  switch(*(byte *)(param_1 + 2)) {
  case 0:
    iVar3 = param_2;
    for (uVar2 = 0; uVar2 < param_3; uVar2 = uVar2 + 1 & 0xff) {
      memcpy(uVar2 * 0xc + param_2 + 4,&local_1c,4,iVar4,iVar3);
      iVar4 = extraout_r3;
    }
    DAT_04000d4f = 0;
    break;
  case 3:
    uVar2 = (uint)CONCAT11(DAT_04002d6c,DAT_04002d6b);
    if (DAT_04002d68 != '\0') {
      local_18 = &DAT_04002d5f;
      for (uVar5 = 0; uVar5 < param_3; uVar5 = uVar5 + 1 & 0xff) {
        iVar4 = uVar5 * 0xc + param_2;
        memcpy(iVar4 + 8,iVar4 + 4,4);
        memcpy(iVar4,local_18,4);
      }
    }
    for (uVar5 = 0; uVar5 < param_3; uVar5 = uVar5 + 1 & 0xff) {
      iVar4 = uVar5 * 0xc + param_2;
      *(char *)(iVar4 + 4) =
           (char)(uVar2 * ((uint)*(byte *)(param_2 + uVar5 * 0xc) - (uint)*(byte *)(iVar4 + 8)) +
                  (uint)*(byte *)(iVar4 + 8) * 0x100 + 0x80 >> 8);
      *(char *)(iVar4 + 5) =
           (char)(uVar2 * ((uint)*(byte *)(iVar4 + 1) - (uint)*(byte *)(iVar4 + 9)) +
                  (uint)*(byte *)(iVar4 + 9) * 0x100 + 0x80 >> 8);
      *(char *)(iVar4 + 6) =
           (char)(uVar2 * ((uint)*(byte *)(iVar4 + 2) - (uint)*(byte *)(iVar4 + 10)) +
                  (uint)*(byte *)(iVar4 + 10) * 0x100 + 0x80 >> 8);
      *(char *)(iVar4 + 7) =
           (char)(uVar2 * ((uint)*(byte *)(iVar4 + 3) - (uint)*(byte *)(iVar4 + 0xb)) +
                  (uint)*(byte *)(iVar4 + 0xb) * 0x100 + 0x80 >> 8);
    }
    return;
  case 4:
    bVar1 = (&DAT_04002d70)[*(byte *)(param_1 + 1)];
    for (uVar2 = 0; uVar2 < param_3; uVar2 = uVar2 + 1 & 0xff) {
      __aeabi_uidiv(bVar1 + uVar2,0x18);
      memcpy(uVar2 * 0xc + param_2 + 4,&DAT_2000f1e4 + extraout_r1 * 4,4);
    }
    return;
  case 8:
    bVar1 = (&DAT_04000494)[*(byte *)(param_1 + 1)];
    for (uVar2 = 0; uVar2 < param_3; uVar2 = uVar2 + 1 & 0xff) {
      iVar3 = (bVar1 + uVar2) * 4;
      iVar4 = uVar2 * 0xc + param_2;
      *(undefined1 *)(iVar4 + 4) = (&DAT_04002df6)[iVar3];
      *(undefined1 *)(iVar4 + 5) = (&DAT_04002df7)[iVar3];
      *(undefined1 *)(iVar4 + 6) = (&DAT_04002df8)[iVar3];
      *(undefined1 *)(iVar4 + 7) = 0xff;
    }
    return;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006488 @ 20006488 */


void FUN_20006488(int param_1,int param_2,int *param_3)

{
  int iVar1;
  undefined4 uVar2;
  int iVar3;
  
  iVar1 = FUN_200084cc();
  *param_3 = iVar1;
  if (iVar1 == 0) {
    iVar1 = FUN_20006b30(param_1,*(undefined4 *)(param_2 + 4));
    uVar2 = FUN_20006b30(param_1,*(undefined4 *)(param_2 + 8));
    iVar3 = FUN_2000847a(param_1,iVar1,uVar2);
    *param_3 = iVar3;
    if (iVar3 == 0) {
      DAT_040033a0 = iVar1 << 0xf;
      DAT_040033aa = (short)iVar1;
      DAT_040033b4 = (uint)*(ushort *)(param_1 + 0x12);
      DAT_040033ac = ((short)uVar2 - DAT_040033aa) + 1;
      iVar1 = FUN_20006af4(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
      *param_3 = iVar1;
      if (iVar1 == 0) {
        DAT_040033a0 = *(int *)(param_2 + 4) << 8;
        DAT_040033b8 = (uint)*(ushort *)(param_1 + 0x10);
        DAT_040033ae = (*(short *)(param_2 + 8) - *(short *)(param_2 + 4)) + 1;
        DAT_040033c0 = *(undefined4 *)(param_2 + 0xc);
        DAT_040033bc = *(undefined2 *)(param_1 + 0x16);
        DAT_040033be = (ushort)**(byte **)(param_1 + 0x20);
        DAT_040005f8 = 0;
        iVar1 = FUN_20006a2c(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
        *param_3 = iVar1;
      }
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006520 @ 20006520 */


void FUN_20006520(int param_1,int param_2,int *param_3)

{
  int iVar1;
  
  iVar1 = FUN_200084cc();
  *param_3 = iVar1;
  if (iVar1 == 0) {
    iVar1 = FUN_2000847a(param_1,*(undefined4 *)(param_2 + 4),*(undefined4 *)(param_2 + 8));
    *param_3 = iVar1;
    if (iVar1 == 0) {
      DAT_040033a0 = *(int *)(param_2 + 4) << 0xf;
      DAT_040033aa = *(undefined2 *)(param_2 + 4);
      DAT_040033b4 = (uint)*(ushort *)(param_1 + 0x12);
      DAT_040033ac = (*(short *)(param_2 + 8) - *(short *)(param_2 + 4)) + 1;
      iVar1 = FUN_20006af4(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
      *param_3 = iVar1;
      if (iVar1 == 0) {
        if (*(uint *)(param_2 + 4) < *(uint *)(param_2 + 8)) {
          FUN_20006ca0(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
        }
        DAT_040033a0 = *(int *)(param_2 + 8) << 0xf;
        DAT_040033c0 = *(undefined4 *)(param_2 + 0xc);
        DAT_040033bc = *(undefined2 *)(param_1 + 0x16);
        DAT_040033be = (ushort)**(byte **)(param_1 + 0x20);
        iVar1 = FUN_20006aa0(*(undefined4 *)(param_1 + 0xc),&DAT_040033a0);
        *param_3 = iVar1;
      }
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200065a0 @ 200065a0 */


void FUN_200065a0(void)

{
  int iVar1;
  int *extraout_r2;
  undefined4 extraout_r3;
  undefined8 uVar2;
  
  uVar2 = FUN_200084a4();
  *extraout_r2 = (int)uVar2;
  if ((int)uVar2 == 0) {
    iVar1 = *(int *)((ulonglong)uVar2 >> 0x20);
    if (iVar1 == 0x33) {
      FUN_20005888(extraout_r3);
      return;
    }
    if (iVar1 == 0x34) {
      FUN_20006520(extraout_r3);
      return;
    }
    if (iVar1 == 0x3b) {
      FUN_20006488(extraout_r3);
      return;
    }
    *extraout_r2 = 1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200065dc @ 200065dc */


void FUN_200065dc(int param_1,int param_2,uint param_3)

{
  char cVar1;
  undefined1 uVar2;
  uint uVar3;
  int iVar4;
  uint uVar5;
  int iVar6;
  int iVar7;
  
  if (*(ushort *)(param_1 + 0x11) <= *(ushort *)(param_1 + 0x21)) {
    *(undefined1 *)(param_1 + 0x21) = 0;
    *(undefined1 *)(param_1 + 0x22) = 0;
    cVar1 = *(char *)(param_1 + 0x10);
    if (cVar1 == '\x01') {
      iVar7 = param_1 + 0x1d;
      iVar4 = read_u32_le();
      uVar3 = write_u32_le(iVar4 + (uint)*(ushort *)(param_1 + 0x13),iVar7);
      if (0xfe < uVar3) {
        for (uVar3 = 0; uVar3 < param_3; uVar3 = uVar3 + 1 & 0xff) {
          uVar2 = *(undefined1 *)(param_2 + uVar3 * 0xc);
          iVar7 = uVar3 * 0xc + param_2;
          *(undefined1 *)(iVar7 + 8) = uVar2;
          *(undefined1 *)(iVar7 + 4) = uVar2;
          *(undefined1 *)(iVar7 + 9) = *(undefined1 *)(iVar7 + 1);
          *(undefined1 *)(iVar7 + 5) = *(undefined1 *)(iVar7 + 1);
          *(undefined1 *)(iVar7 + 10) = *(undefined1 *)(iVar7 + 2);
          *(undefined1 *)(iVar7 + 6) = *(undefined1 *)(iVar7 + 2);
          *(undefined1 *)(iVar7 + 0xb) = *(undefined1 *)(iVar7 + 3);
          *(undefined1 *)(iVar7 + 7) = *(undefined1 *)(iVar7 + 3);
        }
        *(undefined1 *)(param_1 + 0x10) = 9;
        *(undefined1 *)(param_1 + 2) = *(undefined1 *)(param_1 + 3);
        return;
      }
      for (uVar3 = 0; uVar3 < param_3; uVar3 = uVar3 + 1 & 0xff) {
        iVar4 = read_u32_le(iVar7);
        iVar6 = uVar3 * 0xc + param_2;
        *(char *)(iVar6 + 4) =
             (char)(((uint)*(byte *)(param_2 + uVar3 * 0xc) - (uint)*(byte *)(iVar6 + 8)) * iVar4 +
                    (uint)*(byte *)(iVar6 + 8) * 0x100 + 0x80 >> 8);
        iVar4 = read_u32_le(iVar7);
        *(char *)(iVar6 + 5) =
             (char)(((uint)*(byte *)(iVar6 + 1) - (uint)*(byte *)(iVar6 + 9)) * iVar4 +
                    (uint)*(byte *)(iVar6 + 9) * 0x100 + 0x80 >> 8);
        iVar4 = read_u32_le(iVar7);
        *(char *)(iVar6 + 6) =
             (char)(((uint)*(byte *)(iVar6 + 2) - (uint)*(byte *)(iVar6 + 10)) * iVar4 +
                    (uint)*(byte *)(iVar6 + 10) * 0x100 + 0x80 >> 8);
        iVar4 = read_u32_le(iVar7);
        *(char *)(iVar6 + 7) =
             (char)(((uint)*(byte *)(iVar6 + 3) - (uint)*(byte *)(iVar6 + 0xb)) * iVar4 +
                    (uint)*(byte *)(iVar6 + 0xb) * 0x100 + 0x80 >> 8);
      }
      return;
    }
    iVar7 = param_1 + 0x15;
    if (cVar1 == '\x02') {
      iVar4 = read_u32_le(iVar7);
      uVar3 = iVar4 + (uint)*(ushort *)(param_1 + 0x13);
      uVar5 = read_u32_le(param_1 + 0x19);
      if (uVar5 <= uVar3) {
        write_u32_le(uVar5,iVar7);
        *(undefined1 *)(param_1 + 0x10) = 9;
        return;
      }
    }
    else {
      if (cVar1 != '\x03') {
        return;
      }
      uVar3 = read_u32_le(iVar7);
      if (uVar3 <= *(ushort *)(param_1 + 0x13)) {
        write_u32_le(0,iVar7);
        *(undefined1 *)(param_1 + 2) = *(undefined1 *)(param_1 + 3);
        if (DAT_04000490 == '\0') {
          DAT_04000490 = DAT_04000490 + '\x01';
          return;
        }
        DAT_04000490 = 0;
        FUN_20006754(param_1);
        return;
      }
      uVar3 = uVar3 - *(ushort *)(param_1 + 0x13);
    }
    write_u32_le(uVar3,iVar7);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006754 @ 20006754 */


void FUN_20006754(int param_1)

{
  if (*(char *)(param_1 + 3) != '\x01') {
    *(undefined1 *)(param_1 + 0x10) = 2;
    write_u32_le(0,param_1 + 0x15);
    write_u32_le(2000,param_1 + 0x19);
    return;
  }
  *(undefined1 *)(param_1 + 0x10) = 1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006780 @ 20006780 */


void FUN_20006780(int param_1)

{
  if (*(char *)(param_1 + 2) == '\x02') {
    *(undefined1 *)(param_1 + 2) = 9;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000678c @ 2000678c */


void FUN_2000678c(int param_1,uint param_2,int param_3)

{
  int iVar1;
  undefined2 uVar2;
  uint uVar3;
  int iVar4;
  uint uVar5;
  
  uVar5 = (uint)(byte)(&DAT_04000497)[param_3];
  for (uVar3 = 0; uVar3 < param_2; uVar3 = uVar3 + 1 & 0xff) {
    iVar1 = (uVar5 * 3 & 0xff) * 3;
    (&DAT_04002ca8)[iVar1] = *(undefined1 *)(param_1 + uVar3 * 9);
    iVar4 = uVar3 * 9 + param_1;
    uVar2 = *(undefined2 *)(iVar4 + 3);
    (&DAT_04002ca9)[iVar1] = (char)uVar2;
    (&DAT_04002caa)[iVar1] = (char)((ushort)uVar2 >> 8);
    (&DAT_04002cab)[iVar1] = *(undefined1 *)(iVar4 + 1);
    uVar2 = *(undefined2 *)(iVar4 + 5);
    (&DAT_04002cac)[iVar1] = (char)uVar2;
    (&DAT_04002cad)[iVar1] = (char)((ushort)uVar2 >> 8);
    (&DAT_04002cae)[iVar1] = *(undefined1 *)(iVar4 + 2);
    uVar2 = *(undefined2 *)(iVar4 + 7);
    (&DAT_04002caf)[iVar1] = (char)uVar2;
    (&DAT_04002cb0)[iVar1] = (char)((ushort)uVar2 >> 8);
    uVar5 = uVar5 + 1 & 0xff;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006800 @ 20006800 */


void FUN_20006800(byte *param_1,uint param_2)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 2;
  __aeabi_memclr(param_1,8);
  if ((param_2 & 1) != 0) {
    *param_1 = *param_1 | DAT_04000c40;
    uVar1 = 2;
    do {
      if ((&DAT_04000c40)[uVar1] != 0) {
        param_1[uVar2] = (&DAT_04000c40)[uVar1];
        uVar2 = uVar2 + 1 & 0xff;
      }
      uVar1 = uVar1 + 1 & 0xff;
    } while (uVar1 < 8);
  }
  if ((int)(param_2 << 0x1e) < 0) {
    *param_1 = *param_1 | DAT_04000c48;
    uVar1 = 2;
    do {
      if ((&DAT_04000c48)[uVar1] != 0) {
        if (7 < uVar2) break;
        param_1[uVar2] = (&DAT_04000c48)[uVar1];
        uVar2 = uVar2 + 1 & 0xff;
      }
      uVar1 = uVar1 + 1 & 0xff;
    } while (uVar1 < 8);
  }
  if ((int)(param_2 << 0x1d) < 0) {
    *param_1 = *param_1 | DAT_04000c50;
    uVar1 = 2;
    do {
      if ((&DAT_04000c50)[uVar1] != 0) {
        if (7 < uVar2) {
          return;
        }
        param_1[uVar2] = (&DAT_04000c50)[uVar1];
        uVar2 = uVar2 + 1 & 0xff;
      }
      uVar1 = uVar1 + 1 & 0xff;
    } while (uVar1 < 8);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006888 @ 20006888 */


void FUN_20006888(int param_1,int param_2,int param_3,int param_4,uint param_5)

{
  undefined4 uVar1;
  int iVar2;
  uint uVar3;
  int iVar4;
  uint uVar5;
  int iVar6;
  
  uVar1 = read_u32_le(param_3 + 9);
  iVar2 = read_u32_le(param_3 + 5);
  iVar2 = __aeabi_uidiv((uint)*(byte *)(param_1 + 4) * iVar2,uVar1);
  iVar4 = (uint)*(byte *)(param_1 + 1) * 4;
  uVar5 = iVar2 * (uint)(byte)(&DAT_04002d17)[iVar4] + 0xff >> 8;
  for (uVar3 = 0; uVar3 < param_5; uVar3 = uVar3 + 1 & 0xff) {
    iVar2 = uVar3 * 0xc + param_2;
    iVar6 = uVar3 * 9 + param_4;
    *(char *)(iVar6 + 3) =
         (char)(((uVar5 * (byte)(&DAT_04002d14)[iVar4] + 0xff >> 8) * (uint)*(byte *)(iVar2 + 4) +
                0xff) * 0x10000 >> 0x18);
    *(undefined1 *)(iVar6 + 4) = 0;
    *(char *)(iVar6 + 5) =
         (char)(((uVar5 * (byte)(&DAT_04002d15)[iVar4] + 0xff >> 8) * (uint)*(byte *)(iVar2 + 5) +
                0xff) * 0x10000 >> 0x18);
    *(undefined1 *)(iVar6 + 6) = 0;
    *(char *)(iVar6 + 7) =
         (char)(((uVar5 * (byte)(&DAT_04002d16)[iVar4] + 0xff >> 8) * (uint)*(byte *)(iVar2 + 6) +
                0xff) * 0x10000 >> 0x18);
    *(undefined1 *)(iVar6 + 8) = 0;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000692c @ 2000692c */


undefined4 FUN_2000692c(int param_1,int *param_2)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = DAT_40034fe0;
  if (iVar1 << 0x1e < 0) {
    if (DAT_040005fc == 0) {
      uVar2 = *(uint *)(param_1 + 4) >> 0xf;
      DAT_4003401c = 0;
      DAT_40034000 = DAT_040005f0;
      DAT_40000000 = DAT_040005f4;
      DAT_040033a0 = uVar2 << 0xf;
      DAT_040033aa = (undefined2)uVar2;
      DAT_040033b0 = 0xffffffff;
      iVar1 = FUN_20006c24(&DAT_40034000,&DAT_040033a0);
      *param_2 = iVar1;
      DAT_40000240 = 0x80;
      if (*param_2 == 0) {
        return 0;
      }
      return 0xb;
    }
    iVar1 = FUN_20006b48(&DAT_40034000,&DAT_040033a0);
    *param_2 = iVar1;
  }
  return 0x1d;
}


/* ---------------------------------------------------------------------- */
/* FUN_200069ac @ 200069ac */


undefined4 FUN_200069ac(int param_1,int *param_2)

{
  int iVar1;
  uint uVar2;
  
  uVar2 = DAT_40034fe0;
  if ((uVar2 & 1) != 0) {
    if (DAT_040033ae <= DAT_040005f8) {
      uVar2 = *(uint *)(param_1 + 4) >> 7;
      DAT_4003401c = 0;
      DAT_40034000 = DAT_040005f0;
      DAT_40000000 = DAT_040005f4;
      DAT_040033a0 = uVar2 << 0xf;
      DAT_040033aa = (undefined2)uVar2;
      DAT_040033b0 = 0xffffffff;
      iVar1 = FUN_20006c24(&DAT_40034000,&DAT_040033a0);
      *param_2 = iVar1;
      DAT_40000240 = 0x80;
      if (*param_2 == 0) {
        return 0;
      }
      return 0xb;
    }
    iVar1 = FUN_20006a2c(&DAT_40034000,&DAT_040033a0);
    *param_2 = iVar1;
  }
  return 0x1d;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006a2c @ 20006a2c */


undefined4 FUN_20006a2c(undefined4 *param_1,int *param_2)

{
  uint uVar1;
  undefined4 uVar2;
  
  if (-1 < (int)(param_1[1] << 0x14)) {
    return 0xb;
  }
  if (DAT_040005f8 == 0) {
    DAT_040005f4 = DAT_40000000;
    DAT_40000000 = 2;
    DAT_040005f0 = *param_1;
  }
  uVar2 = FUN_2000e2b0(param_1,param_2[8],(short)param_2[7],*(undefined2 *)((int)param_2 + 0x1e));
  *param_1 = 0x85;
  uVar1 = DAT_040005f8;
  if (DAT_040005f8 < *(ushort *)((int)param_2 + 0xe)) {
    param_1[2] = uVar2;
    param_1[0x1c] = *param_2 + uVar1 * param_2[6] >> 4;
    param_1[0x20] = 1;
    param_1[0x3fa] = 1;
    *param_1 = 0x1181;
    DAT_040005f8 = DAT_040005f8 + 1;
    return 0x1d;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006aa0 @ 20006aa0 */


undefined4 FUN_20006aa0(undefined4 *param_1,uint *param_2)

{
  undefined4 uVar1;
  
  if ((int)(param_1[1] << 0x14) < 0) {
    DAT_040005f4 = DAT_40000000;
    DAT_40000000 = 2;
    DAT_040005f0 = *param_1;
    uVar1 = FUN_2000e2b0(param_1,param_2[8],(short)param_2[7],*(undefined2 *)((int)param_2 + 0x1e));
    param_1[2] = uVar1;
    param_1[0x1c] = *param_2 >> 4;
    param_1[0x20] = 1;
    param_1[0x3fa] = 1;
    *param_1 = 0x1081;
    return 0x1d;
  }
  return 0xb;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006af4 @ 20006af4 */


undefined4 FUN_20006af4(undefined4 param_1,int param_2)

{
  undefined4 uVar1;
  uint uVar2;
  undefined4 uVar3;
  uint uVar4;
  
  uVar3 = 0;
  uVar1 = DAT_40000000;
  DAT_40000000 = 2;
  uVar4 = 0;
  do {
    if (*(ushort *)(param_2 + 0xc) <= uVar4) {
LAB_20006b22:
      DAT_40000000 = uVar1;
      return uVar3;
    }
    uVar2 = DAT_40000404;
    if ((uVar2 & 1 << (*(byte *)(param_2 + 10) + uVar4 & 0xff)) != 0) {
      uVar3 = 9;
      goto LAB_20006b22;
    }
    uVar4 = uVar4 + 1;
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_20006b30 @ 20006b30 */


void FUN_20006b30(int param_1,undefined4 param_2)

{
  undefined4 uVar1;
  
  uVar1 = __aeabi_uidiv(*(undefined2 *)(param_1 + 0x12),*(undefined2 *)(param_1 + 0x10));
  __aeabi_uidiv(param_2,uVar1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006b48 @ 20006b48 */


undefined4 FUN_20006b48(undefined4 *param_1,int *param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  uint uVar2;
  uint uVar3;
  undefined4 uVar4;
  uint uVar5;
  undefined4 *puVar6;
  
  uVar2 = (uint)*(ushort *)(param_2 + 2);
  puVar6 = (undefined4 *)(param_2[1] + (uVar2 - DAT_040005fc & 0xfffffffc));
  uVar5 = *param_2 + (uVar2 - DAT_040005fc & 0xfffffffc);
  if (-1 < (int)(param_1[1] << 0x14)) {
    return 0xb;
  }
  if (uVar2 == DAT_040005fc) {
    DAT_040005f4 = DAT_40000000;
    DAT_40000000 = 2;
    DAT_040005f0 = *param_1;
  }
  uVar1 = FUN_2000e2b0(param_1,param_2[8],(short)param_2[7],*(undefined2 *)((int)param_2 + 0x1e),
                       param_4);
  if (DAT_040005fc == 0) {
    return 0;
  }
  *param_1 = 0x400;
  *param_1 = 7;
  if (DAT_04000600 == 0) {
    uVar2 = param_2[6];
LAB_20006bc2:
    if (uVar2 < DAT_040005fc) goto LAB_20006bca;
  }
  else {
    DAT_04000600 = 0;
    uVar2 = param_2[6];
    uVar3 = uVar2 - 1 & uVar5;
    if (uVar3 == 0) goto LAB_20006bc2;
    uVar2 = uVar2 - uVar3;
    if (uVar2 <= DAT_040005fc) goto LAB_20006bca;
  }
  uVar2 = DAT_040005fc;
LAB_20006bca:
  param_1[0x1c] = uVar5 >> 4;
  uVar3 = uVar5 + uVar2;
  for (; uVar5 < uVar3; uVar5 = uVar5 + 4) {
    uVar4 = *puVar6;
    puVar6 = puVar6 + 1;
    param_1[((uVar5 << 0x1c) >> 0x1e) + 0x20] = uVar4;
  }
  if ((uVar5 >> 2 & 3) != 0) {
    *param_1 = 0x8007;
  }
  param_1[0x3fa] = 2;
  param_1[2] = uVar1;
  *param_1 = 0x1083;
  DAT_040005fc = DAT_040005fc - uVar2;
  return 0x1d;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006c24 @ 20006c24 */


undefined4 FUN_20006c24(int *param_1,int *param_2)

{
  uint uVar1;
  int iVar2;
  uint uVar3;
  
  if (param_1[1] << 0x14 < 0) {
    iVar2 = *param_1;
    if (-1 < iVar2 * 0x4000) {
      *param_1 = 5;
      *param_1 = 0x20005;
      uVar1 = 2;
      do {
        uVar1 = uVar1 + 1;
      } while (uVar1 < 0x32);
    }
    for (uVar1 = 0; uVar1 < *(ushort *)(param_2 + 3); uVar1 = uVar1 + 1) {
      param_1[0x1c] = *param_2 + uVar1 * param_2[5] >> 4;
      param_1[0x20] = param_2[4];
      uVar3 = DAT_40000404;
      if (param_2[4] == 0) {
        uVar3 = uVar3 & ~(1 << (*(byte *)((int)param_2 + 10) + uVar1 & 0xff));
      }
      else {
        uVar3 = uVar3 | 1 << (*(byte *)((int)param_2 + 10) + uVar1 & 0xff);
      }
      DAT_40000404 = uVar3;
      *param_1 = 0x8087;
      *param_1 = 5;
    }
    *param_1 = iVar2;
    return 0;
  }
  return 0xb;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006ca0 @ 20006ca0 */


void FUN_20006ca0(undefined4 *param_1,int *param_2)

{
  uint uVar1;
  undefined4 uVar2;
  
  uVar2 = *param_1;
  for (uVar1 = 0; uVar1 < *(ushort *)(param_2 + 3); uVar1 = uVar1 + 1) {
    param_1[0x1c] = *param_2 + uVar1 * param_2[5] >> 4;
    param_1[0x20] = 1;
    *param_1 = 0x8085;
    *param_1 = 5;
  }
  *param_1 = uVar2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006cd4 @ 20006cd4 */


undefined4 FUN_20006cd4(uint param_1)

{
  uint uVar1;
  
  uVar1 = 0;
  if (0x16fff < param_1 - 0x29000) {
    return 0;
  }
  if (DAT_04000478 == '\0') {
    memcpy(&DAT_04002b4c);
    DAT_04000484 = param_1 >> 8;
    DAT_04000480 = param_1 >> 0xf;
    DAT_04000478 = '\x01';
  }
  else {
    while ((1 << uVar1 & DAT_0400047c) != 0) {
      uVar1 = uVar1 + 1 & 0xff;
      if (7 < uVar1) {
        return 2;
      }
    }
    DAT_0400047c = 1 << uVar1 | DAT_0400047c;
    memcpy(&DAT_0400232c + uVar1 * 0x100);
    (&DAT_04002b2c)[uVar1] = param_1;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006d48 @ 20006d48 */


void FUN_20006d48(void)

{
  uint uVar1;
  
  uVar1 = 0;
  do {
    memcpy(&DAT_04002d14 + uVar1 * 4,&DAT_040014f2 + uVar1 * 4,4);
    (&DAT_04002d8f)[uVar1 * 0x23] = 0;
    FUN_20005f80(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar1 * 0x23,1);
    uVar1 = uVar1 + 1 & 0xff;
  } while (uVar1 < 3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006da0 @ 20006da0 */


void FUN_20006da0(void)

{
  __aeabi_memclr(&DAT_040022fa,0x2d);
  settings_mark_dirty(0x100,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006dbc @ 20006dbc */


bool FUN_20006dbc(uint param_1,uint param_2)

{
  if (param_1 < 0x3ff) {
    FUN_2000cfec((param_1 & 0x3ff) - 0x298 & 0xffff,(param_2 >> 8) + 1 & 0xffff);
  }
  return param_1 < 0x3ff;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006de8 @ 20006de8 */


undefined4 FUN_20006de8(void)

{
  return 0x100;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006dee @ 20006dee */


void FUN_20006dee(void)

{
  FUN_20006ea4();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006df8 @ 20006df8 */


void FUN_20006df8(int param_1,int param_2,uint param_3,undefined1 *param_4,int param_5)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  
  uVar3 = param_3 + param_5;
  for (; (param_3 < uVar3 && (param_3 < 0xd)); param_3 = param_3 + 1 & 0xff) {
    iVar1 = param_3 * 0x10 + param_1 * 0x164;
    iVar2 = param_2 + iVar1;
    *param_4 = (&DAT_04000d95)[iVar1 + -0xb9];
    param_4[1] = (&DAT_04000d95)[iVar2 + -0xb7];
    param_4[2] = (&DAT_04000d95)[iVar2 + -0xb5];
    param_4[3] = (&DAT_04000d95)[iVar2 + -0xb3];
    param_4[4] = (&DAT_04000d95)[iVar2 + -0xb1];
    param_4[5] = (&DAT_04000d95)[iVar2 + -0xaf];
    param_4[6] = (&DAT_04000d95)[iVar2 + -0xad];
    param_4[7] = (&DAT_04000d95)[iVar2 + -0xab];
    param_4 = param_4 + 8;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006e4c @ 20006e4c */


uint FUN_20006e4c(void)

{
  uint uVar1;
  
  uVar1 = 0;
  if (DAT_04000ca9 == '\x04') {
    if (DAT_04000a43 != '\0') {
      DAT_04000caa = 0x52;
    }
    uVar1 = (uint)(DAT_04000a43 != '\0');
    if (DAT_04000a4f != '\0') {
      (&DAT_04000caa)[uVar1] = 0x50;
      uVar1 = uVar1 + 1;
    }
    if (DAT_04000a49 != '\0') {
      (&DAT_04000caa)[uVar1] = 0x51;
      uVar1 = uVar1 + 1;
    }
    if (DAT_04000a55 != '\0') {
      (&DAT_04000caa)[uVar1] = 0x54;
      uVar1 = uVar1 + 1;
    }
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006ea4 @ 20006ea4 */


int FUN_20006ea4(void)

{
  uint uVar1;
  uint uVar2;
  int iVar3;
  
  iVar3 = 0;
  uVar2 = 0;
  do {
    uVar1 = 0;
    do {
      if (((byte)(&DAT_040022fa)[uVar2] >> uVar1 & 1) == 0) {
        iVar3 = iVar3 + 1;
      }
      uVar1 = uVar1 + 1 & 0xff;
    } while (uVar1 < 8);
    uVar2 = uVar2 + 1 & 0xffff;
  } while (uVar2 < 0x2d);
  return iVar3 << 8;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006ed4 @ 20006ed4 */


undefined4 FUN_20006ed4(undefined4 param_1,uint param_2,undefined4 param_3,int param_4)

{
  int iVar1;
  uint uVar2;
  undefined4 uVar3;
  
  uVar3 = 2;
  iVar1 = FUN_20006f20(param_1);
  uVar2 = FUN_20006f7c(param_1);
  if ((iVar1 == 0) || (uVar2 == 0)) {
    uVar3 = 0;
  }
  else {
    if (uVar2 < param_2 + param_4) {
      if (uVar2 <= param_2) {
        return 2;
      }
      param_4 = uVar2 - param_2;
    }
    iVar1 = FUN_2000b7e8(iVar1 + param_2,param_3,param_4);
    if (iVar1 != 0) {
      uVar3 = 1;
    }
  }
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006f20 @ 20006f20 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

int FUN_20006f20(uint param_1)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  uVar1 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar2 <= uVar1) {
      return 0;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar1 = uVar1 + 1 & 0xffff;
  }
  return (uint)*(ushort *)(&DAT_04001625 + uVar1 * 0xe) << 8;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006f7c @ 20006f7c */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20006f7c(uint param_1)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  uVar1 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar2 <= uVar1) {
      return;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar1 = uVar1 + 1 & 0xffff;
  }
  read_u32_le(&DAT_04001627 + uVar1 * 0xe);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20006fd4 @ 20006fd4 */


void FUN_20006fd4(uint param_1,undefined1 *param_2,byte *param_3,uint param_4)

{
  ushort uVar1;
  uint uVar2;
  uint uVar3;
  
  *param_2 = DAT_04001b9c;
  uVar3 = 0;
  param_2[1] = DAT_04001b9b;
  for (uVar2 = param_1;
      (uVar2 < CONCAT11(DAT_04001b9c,DAT_04001b9b) + uVar3 && (uVar2 < (param_4 >> 1) + param_1));
      uVar2 = uVar2 + 1 & 0xffff) {
    uVar1 = *(ushort *)(&DAT_04001623 + uVar2 * 0xe);
    if ((uVar1 & 0x7fff) == 0) {
      uVar3 = uVar3 + 1 & 0xffff;
    }
    else {
      *param_3 = (byte)(((uint)uVar1 << 0x11) >> 0x19);
      param_3[1] = (byte)*(ushort *)(&DAT_04001623 + uVar2 * 0xe);
      param_3 = param_3 + 2;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000704c @ 2000704c */


undefined1 FUN_2000704c(void)

{
  return DAT_04001b9d;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007058 @ 20007058 */


undefined4
FUN_20007058(undefined4 param_1,undefined1 *param_2,uint param_3,undefined4 param_4,int param_5)

{
  int iVar1;
  uint uVar2;
  undefined4 uVar3;
  
  uVar3 = 2;
  iVar1 = FUN_200070ac(param_1);
  uVar2 = FUN_20007108(param_1);
  *param_2 = (char)(uVar2 >> 8);
  param_2[1] = (char)uVar2;
  if ((iVar1 == 0) || (uVar2 == 0)) {
    uVar3 = 0;
  }
  else {
    if (uVar2 < param_3 + param_5) {
      if (uVar2 <= param_3) {
        return 2;
      }
      param_5 = uVar2 - param_3;
    }
    iVar1 = FUN_2000b7e8(iVar1 + param_3,param_4,param_5);
    if (iVar1 != 0) {
      uVar3 = 1;
    }
  }
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_200070ac @ 200070ac */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

int FUN_200070ac(uint param_1)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  uVar1 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar2 <= uVar1) {
      return 0;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar1 = uVar1 + 1 & 0xffff;
  }
  return (uint)*(ushort *)(&DAT_0400162b + uVar1 * 0xe) << 8;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007108 @ 20007108 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

undefined4 FUN_20007108(uint param_1)

{
  undefined4 uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar3 = 0;
  uVar2 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar3 <= uVar2) {
      return 0;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar2 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar2 * 0xe) & 0x7fff) == 0) {
      uVar3 = uVar3 + 1 & 0xffff;
    }
    uVar2 = uVar2 + 1 & 0xffff;
  }
  uVar1 = read_u32_le(&DAT_0400162d + uVar2 * 0xe);
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007160 @ 20007160 */


undefined2 FUN_20007160(void)

{
  return CONCAT11(DAT_04001b9c,DAT_04001b9b);
}


/* ---------------------------------------------------------------------- */
/* FUN_20007170 @ 20007170 */


undefined8 FUN_20007170(uint param_1,undefined1 *param_2)

{
  undefined1 uVar1;
  undefined1 extraout_var;
  undefined1 extraout_var_00;
  undefined1 extraout_var_01;
  uint uVar2;
  uint uVar3;
  int iVar4;
  undefined4 uVar5;
  undefined4 uStack_20;
  
  uVar3 = 0;
  uVar5 = 0;
  uVar2 = 0;
  do {
    if (CONCAT11(DAT_04001b9c,DAT_04001b9b) + uVar3 <= uVar2) {
LAB_200071ea:
      return CONCAT44(uStack_20,uVar5);
    }
    iVar4 = uVar2 * 0xe;
    if ((*(ushort *)(&DAT_04001623 + iVar4) & 0x7fff) == param_1) {
      read_u32_le(&DAT_04001627 + uVar2 * 0xe);
      *param_2 = extraout_var_01;
      read_u32_le(&DAT_04001627 + iVar4);
      param_2[1] = extraout_var_00;
      read_u32_le(&DAT_04001627 + iVar4);
      param_2[2] = extraout_var;
      uVar1 = read_u32_le(&DAT_04001627 + iVar4);
      param_2[3] = uVar1;
      uVar5 = 1;
      goto LAB_200071ea;
    }
    if ((*(ushort *)(&DAT_04001623 + iVar4) & 0x7fff) == 0) {
      uVar3 = uVar3 + 1 & 0xffff;
    }
    uVar2 = uVar2 + 1 & 0xffff;
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_200071f8 @ 200071f8 */


undefined4 FUN_200071f8(void)

{
  return 100;
}


/* ---------------------------------------------------------------------- */
/* FUN_200071fc @ 200071fc */


undefined4 FUN_200071fc(void)

{
  return 0x16800;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007204 @ 20007204 */


undefined4
FUN_20007204(int param_1,undefined1 *param_2,uint param_3,undefined4 param_4,uint param_5)

{
  ushort uVar1;
  int iVar2;
  uint uVar3;
  undefined4 uVar4;
  
  uVar4 = 0;
  if (param_1 - 1U < 5) {
    iVar2 = read_u32_le(param_1 * 0x164 + 0x4000c49);
    if (iVar2 != 0) {
      uVar1 = read_u32_le(param_1 * 0x164 + 0x4000c4d);
      uVar3 = (uint)uVar1;
      *param_2 = (char)(uVar1 >> 8);
      param_2[1] = (char)uVar1;
      if (param_3 < uVar3) {
        if (uVar3 < param_3 + param_5) {
          param_5 = uVar3 - param_3 & 0xff;
        }
        iVar2 = FUN_2000b7e8(iVar2 + param_3,param_4,param_5);
        if (iVar2 == 0) {
          uVar4 = 2;
        }
        else {
          uVar4 = 1;
        }
      }
    }
  }
  return uVar4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007270 @ 20007270 */


undefined4 FUN_20007270(uint param_1)

{
  undefined4 uVar1;
  uint uVar2;
  
  uVar2 = 0;
  do {
    if ((byte)(&DAT_04000dac)[uVar2 * 0x164] == param_1) {
      uVar1 = read_u32_le(&DAT_04000dad + uVar2 * 0x164);
      return uVar1;
    }
    uVar2 = uVar2 + 1 & 0xff;
  } while (uVar2 < 5);
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200072a8 @ 200072a8 */


char FUN_200072a8(void)

{
  char cVar1;
  uint uVar2;
  
  cVar1 = '\0';
  uVar2 = 0;
  do {
    if ((DAT_04000d99 >> uVar2 & 1) != 0) {
      cVar1 = cVar1 + '\x01';
    }
    uVar2 = uVar2 + 1 & 0xff;
  } while (uVar2 < 8);
  return cVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_200072cc @ 200072cc */


void FUN_200072cc(void)

{
  read_u32_le(&DAT_04001b9e);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200072dc @ 200072dc */


int FUN_200072dc(int param_1)

{
  int iVar1;
  int iVar2;
  int iVar3;
  
  iVar1 = 0x8000;
  iVar3 = 0;
  if (param_1 << 0x1d < 0) {
    iVar2 = 0x10000;
  }
  else {
    iVar2 = 0x8000;
  }
  if (((uint)(param_1 << 0x1b) >> 0x1e != 1) && (iVar1 = 0, param_1 << 0x1b < 0)) {
    iVar1 = 0x10000;
  }
  if (param_1 << 0x1a < 0) {
    iVar3 = 0x8000;
  }
  return iVar2 + iVar1 + iVar3;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007318 @ 20007318 */


undefined4 FUN_20007318(uint param_1)

{
  undefined4 uVar1;
  
  uVar1 = 0;
  if ((param_1 & 3) != 1) {
    if ((int)(param_1 << 0x1e) < 0) {
      uVar1 = 0x8000;
    }
    return uVar1;
  }
  return 0x4000;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007334 @ 20007334 */


void FUN_20007334(int param_1,uint param_2,int param_3)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 1 << (param_2 & 0xff);
  uVar1 = *(uint *)(&DAT_4008e000 + param_1 * 4);
  if (param_3 == 0) {
    uVar1 = uVar1 & ~uVar2;
  }
  else {
    uVar1 = uVar1 | uVar2;
  }
  *(uint *)(&DAT_4008e000 + param_1 * 4) = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007358 @ 20007358 */


undefined1 FUN_20007358(int param_1,int param_2)

{
  return (&UNK_4008c000)[param_2 + param_1 * 0x20];
}


/* ---------------------------------------------------------------------- */
/* FUN_20007368 @ 20007368 */


void FUN_20007368(void)

{
  FUN_20000490(0xe);
  FUN_20000490(0xf);
  FUN_2000c8bc();
  FUN_2000537c();
  FUN_20007a54();
  FUN_20001746(&DAT_40001000,0,0x17,0x90);
  FUN_20007334(0,0x17,1);
  FUN_200073a8(0,0x17);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200073a8 @ 200073a8 */


void FUN_200073a8(int param_1,uint param_2,int param_3)

{
  int iVar1;
  
  if (param_3 == 0) {
    iVar1 = 0x2280;
  }
  else {
    iVar1 = 0x2200;
  }
  *(uint *)(&UNK_4008c000 + iVar1 + param_1 * 4) =
       *(uint *)(&UNK_4008c000 + iVar1 + param_1 * 4) | 1 << (param_2 & 0xff);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200073d0 @ 200073d0 */


void FUN_200073d0(void)

{
  DAT_400001f0 = 0xff;
  FUN_2000e130();
  FUN_20007584();
  FUN_2000e778();
  FUN_2000e244();
  FUN_20007368();
  FUN_200074fc();
  FUN_2000ddf0();
  FUN_20007a4c();
  FUN_2000c1d4();
  DAT_04000d3e = (DAT_04000d3e & 0xf0) + 1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007414 @ 20007414 */


/* WARNING: Removing unreachable block (ram,0x20007464) */
/* WARNING: Removing unreachable block (ram,0x20007472) */

undefined4
FUN_20007414(uint param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,int param_5)

{
  int iVar1;
  
  if (DAT_04000d4e != '\0') {
    return 1;
  }
  DAT_04002c5c = (undefined2)(param_1 >> 1);
  DAT_04002c64 = 1;
  DAT_04002c5e = 1;
  DAT_04002c58 = 0;
  DAT_04002c60 = param_2;
  DAT_04002c68 = param_3;
  DAT_04002c6c = param_4;
  iVar1 = FUN_2000150c(&DAT_4008a000,&DAT_04002c70,&DAT_04002c58,param_4,param_4);
  if (iVar1 != 0) {
    return 2;
  }
  if (param_5 != 0) {
    do {
    } while( true );
  }
  DAT_04000d4e = 1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007488 @ 20007488 */


/* WARNING: Removing unreachable block (ram,0x200074d8) */
/* WARNING: Removing unreachable block (ram,0x200074e6) */

undefined4
FUN_20007488(uint param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4,int param_5)

{
  int iVar1;
  
  if (DAT_04000d4e != '\0') {
    return 1;
  }
  DAT_04002c5c = (undefined2)(param_1 >> 1);
  DAT_04002c5e = 0;
  DAT_04002c64 = 1;
  DAT_04002c58 = 0;
  DAT_04002c60 = param_2;
  DAT_04002c68 = param_3;
  DAT_04002c6c = param_4;
  iVar1 = FUN_2000150c(&DAT_4008a000,&DAT_04002c70,&DAT_04002c58,param_4,param_4);
  if (iVar1 != 0) {
    return 2;
  }
  DAT_04000d4d = 0;
  if (param_5 != 0) {
    do {
    } while( true );
  }
  DAT_04000d4e = 1;
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200074fc @ 200074fc */


void FUN_200074fc(void)

{
  FUN_2000044c(0x110);
  FUN_20001a38(0x1000f);
  DAT_40001064 = 0x681;
  DAT_40001068 = 0x681;
  FUN_200013ec(&DAT_04002c4c);
  DAT_04002c50 = 1000000;
  FUN_20001400(&DAT_4008a000,&DAT_04002c4c,12000000);
  FUN_2000148c(&DAT_4008a000,&DAT_04002c70,&LAB_20007564_1,0);
  DAT_04000d4e = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007574 @ 20007574 */


void FUN_20007574(void)

{
  disableIRQinterrupts();
  (*(code *)0x3000205)();
  enableIRQinterrupts();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007584 @ 20007584 */


void FUN_20007584(void)

{
  FUN_200051ac(0x1c,0);
  FUN_200051ac(10,1);
  FUN_200051ac(0xb,1);
  FUN_200051ac(1,2);
  FUN_200051ac(0x11,2);
  FUN_200051ac(0x12,2);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200075b8 @ 200075b8 */


void FUN_200075b8(void)

{
  undefined1 local_64 [4];
  undefined1 auStack_60 [76];
  
  DAT_040004a8 = 0;
  (*DAT_040004b4)(DAT_040004b0,DAT_040004b1,0);
  (*DAT_040004b8)(10);
  (*DAT_040004b4)(DAT_040004b0,DAT_040004b1,1);
  (*DAT_040004b8)(10);
  local_64[0] = 0xae;
  (*DAT_040004bc)(0xc0,0x8f,local_64,1,1);
  local_64[0] = 0xc5;
  (*DAT_040004bc)(0xc0,0xfe,local_64,1,1);
  DAT_040004a8 = DAT_040004a8 & 0xfe | 2;
  local_64[0] = 1;
  (*DAT_040004bc)(0xc0,0xfd,local_64,1,1);
  _memset_byte(auStack_60,0x48,0x80);
  (*DAT_040004bc)(0xc0,1,auStack_60,0x48,1);
  local_64[0] = 0x77;
  (*DAT_040004bc)(0xc0,0x52,local_64,1,1);
  local_64[0] = 0xff;
  (*DAT_040004bc)(0xc0,0x51,local_64,1,1);
  local_64[0] = 1;
  (*DAT_040004bc)(0xc0,0x50,local_64,1,1);
  local_64[0] = 0xc5;
  (*DAT_040004bc)(0xc0,0xfe,local_64,1,1);
  local_64[0] = 0;
  (*DAT_040004bc)(0xc0,0xfd,local_64,1,1);
  DAT_040004a8 = DAT_040004a8 & 0xfd | 1;
  __aeabi_memclr(auStack_60,0x48);
  (*DAT_040004bc)(0xc0,1,auStack_60,0x48,1);
  DAT_04000d51 = 0xd0;
  DAT_04000d52 = 7;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200076e0 @ 200076e0 */


void FUN_200076e0(void)

{
  undefined1 local_64 [4];
  undefined1 auStack_60 [76];
  
  local_64[0] = 0xc5;
  (*DAT_040004bc)(0xc0,0xfe,local_64,1,1);
  local_64[0] = 0;
  (*DAT_040004bc)(0xc0,0xfd,local_64,1,1);
  __aeabi_memclr(auStack_60,0x48);
  (*DAT_040004bc)(0xc0,1,auStack_60,0x48,1);
  local_64[0] = 0xc5;
  (*DAT_040004bc)(0xc0,0xfe,local_64,1,1);
  local_64[0] = 1;
  (*DAT_040004bc)(0xc0,0xfd,local_64,1,1);
  local_64[0] = 0;
  (*DAT_040004bc)(0xc0,0x50,local_64,1,1);
  (*DAT_040004b4)(DAT_040004b0,DAT_040004b1,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007770 @ 20007770 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x200077e6) */
/* WARNING: Removing unreachable block (ram,0x200077e6) */
/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20007770(undefined4 param_1,undefined4 param_2,uint param_3)

{
  byte bVar1;
  uint uVar2;
  int iVar3;
  uint local_1c;
  undefined1 *local_18;
  
  if (DAT_040004ac != DAT_04000398) {
    DAT_040004ac = (byte)DAT_04000398;
    uVar2 = 0;
    do {
      iVar3 = uVar2 * 3;
      uVar2 = uVar2 + 1 & 0xff;
      (&DAT_04002e21)[(byte)(&DAT_04002ca8)[iVar3]] = (&DAT_04002ca9)[iVar3];
    } while (uVar2 < 0x24);
  }
  if (DAT_04000d50 != '\0') {
    return;
  }
  local_18 = &DAT_04000d41;
  if (_DAT_04000d51 == 0) {
    if (DAT_040004a9 == '\0') {
      DAT_040004a9 = '\x01';
      DAT_040004ab = '\x02';
    }
  }
  else {
    if (DAT_040004ab != '\x01') {
      DAT_040004ab = '\x01';
    }
    DAT_04000d50 = '\b';
  }
  local_1c._1_3_ = (uint3)(param_3 >> 8);
  local_1c = param_3;
  switch(DAT_040004ab) {
  case '\0':
    FUN_200074fc();
    FUN_200075b8();
    DAT_040004a9 = 0;
    DAT_040004aa = 0;
    DAT_040004ab = 1;
    local_18[0x10] = 0xd0;
    local_18[0x11] = 7;
    return;
  case '\x01':
    iVar3 = (*DAT_040004bc)(0xc0,1,&DAT_04002e22,0x48,0);
    if (iVar3 == 0) {
      DAT_040004aa = 0;
      return;
    }
    goto LAB_2000781e;
  case '\x02':
    local_1c = CONCAT31(local_1c._1_3_,0xc5);
    iVar3 = (*DAT_040004bc)(0xc0,0xfe,&local_1c,1,1);
    if (iVar3 == 0) {
      if ((DAT_040004a8 & 1) == 0) {
        if (-1 < (int)((uint)DAT_040004a8 << 0x1e)) {
          DAT_040004aa = 0;
          return;
        }
        DAT_040004ab = 5;
      }
      else {
        DAT_040004ab = 3;
      }
      DAT_040004aa = 0;
      return;
    }
LAB_2000781e:
    bVar1 = DAT_040004aa + 1;
    DAT_040004aa = bVar1;
    goto LAB_200078c8;
  case '\x03':
    DAT_040004a8 = DAT_040004a8 & 0xfe | 2;
    local_1c = CONCAT31(local_1c._1_3_,1);
    iVar3 = (*DAT_040004bc)(0xc0,0xfd,&local_1c,1,1);
    if (iVar3 == 0) {
      DAT_040004aa = 0;
      DAT_040004ab = 4;
      return;
    }
    break;
  case '\x04':
    local_1c = (uint)local_1c._1_3_ << 8;
    iVar3 = (*DAT_040004c0)(0xc1,0x50,&local_1c,1,1);
    if (iVar3 == 0) {
      if ((local_1c & 1) == 0) {
        DAT_040004ab = 0;
        return;
      }
      DAT_040004aa = 0;
      DAT_040004ab = 2;
      return;
    }
    break;
  case '\x05':
    DAT_040004a8 = DAT_040004a8 & 0xfd | 1;
    local_1c = (uint)local_1c._1_3_ << 8;
    iVar3 = (*DAT_040004bc)(0xc0,0xfd,&local_1c,1,1);
    if (iVar3 == 0) {
      local_18[0x10] = 0xd0;
      local_18[0x11] = 7;
      DAT_040004a9 = 0;
      DAT_040004aa = 0;
      DAT_040004ab = 1;
      return;
    }
    break;
  default:
    goto switchD_200077e6_default;
  }
  bVar1 = DAT_040004aa;
  DAT_040004aa = DAT_040004aa + 1;
LAB_200078c8:
  if (bVar1 < 3) {
    return;
  }
  DAT_040004aa = 0;
switchD_200077e6_default:
  DAT_040004ab = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200078fc @ 200078fc */


uint FUN_200078fc(uint param_1,int param_2)

{
  param_1 = param_1 & param_2 - 1U;
  if (param_1 != 0) {
    param_1 = 1;
  }
  return param_1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007908 @ 20007908 */


undefined1 * FUN_20007908(int param_1,uint param_2)

{
  uint uVar1;
  
  for (uVar1 = 0;
      ((byte)(&DAT_04000db6)[(uint)DAT_04000d74 * 0x164 + uVar1 * 0x23] != param_2 && (uVar1 < 3));
      uVar1 = uVar1 + 1 & 0xff) {
  }
  if ((param_1 != 0) && (uVar1 != 3)) {
    return &DAT_04000c52 + param_1 * 0x164 + uVar1 * 0x23;
  }
  return &DAT_04002d8d + uVar1 * 0x23;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007964 @ 20007964 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20007964(void)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  
  uVar3 = 0;
  if ((DAT_04002d20 & 1) != 0) {
    _DAT_04002d69 = _DAT_04002d69 + 1;
  }
  if ((int)((uint)DAT_04002d20 << 0x1d) < 0) {
    FUN_2000e714();
  }
  do {
    iVar1 = uVar3 * 0x23;
    iVar2 = *(ushort *)(&DAT_04002dae + iVar1) + 1;
    (&DAT_04002dae)[iVar1] = (char)iVar2;
    uVar3 = uVar3 + 1 & 0xff;
    (&DAT_04002daf)[iVar1] = (char)((uint)iVar2 >> 8);
  } while (uVar3 < 3);
  if (DAT_04000d50 != '\0') {
    DAT_04000d50 = DAT_04000d50 + -1;
  }
  if (CONCAT11(DAT_04000d52,DAT_04000d51) != 0) {
    iVar1 = CONCAT11(DAT_04000d52,DAT_04000d51) - 1;
    DAT_04000d51 = (undefined1)iVar1;
    DAT_04000d52 = (undefined1)((uint)iVar1 >> 8);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200079dc @ 200079dc */


void FUN_200079dc(void)

{
  FUN_200076e0();
  FUN_20007a7c();
  DAT_04000d51 = 0;
  DAT_04000d52 = 0;
  DAT_04000d50 = 0;
  DAT_04000d4e = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200079f8 @ 200079f8 */


void FUN_200079f8(void)

{
  __aeabi_memclr(&DAT_04002d8d,0x69);
  __aeabi_memclr(&DAT_04002d14,0xc);
  __aeabi_memclr(&DAT_04002ca8,0x6c);
  __aeabi_memclr(&DAT_04002d20,0x6d);
  __aeabi_memclr(&DAT_04002e76,0xc);
  __aeabi_memclr(&DAT_04002e6a,0xc);
  __aeabi_memclr(&DAT_04002e82,0x6c);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007a4c @ 20007a4c */


void FUN_20007a4c(void)

{
  FUN_200075b8();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007a54 @ 20007a54 */


void FUN_20007a54(void)

{
  FUN_20001746(&DAT_40001000,0,0x14,0x90);
  FUN_20007334(0,0x14,1);
  FUN_200073a8(0,0x14);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007a7c @ 20007a7c */


void FUN_20007a7c(void)

{
  FUN_20001746(&DAT_40001000,0,0x14,0x90);
  FUN_20007334(0,0x14);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007a9c @ 20007a9c */


void FUN_20007a9c(void)

{
  FUN_200079f8();
  FUN_20006d48();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007aa8 @ 20007aa8 */


void FUN_20007aa8(void)

{
  undefined4 in_r3;
  
  FUN_200065dc(&DAT_04002d8d + (uint)DAT_040004cf * 0x23,&DAT_04002e76,DAT_040004d0,in_r3,in_r3);
  FUN_20006330(&DAT_04002d8d + (uint)DAT_040004cf * 0x23,&DAT_04002e76,DAT_040004d0);
  FUN_20006888(&DAT_04002d8d + (uint)DAT_040004cf * 0x23,&DAT_04002e76,
               &DAT_04002d9d + (uint)DAT_040004cf * 0x23,&DAT_040004d1,DAT_040004d0);
  FUN_2000c418(&DAT_040004d1,DAT_040004d0,DAT_04000356,0);
  FUN_2000678c(&DAT_040004d1,DAT_040004d0,DAT_040004cf);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007b10 @ 20007b10 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_20007b10(uint param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  ushort uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar3 = 0;
  uVar2 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar3 <= uVar2) {
      return;
    }
    uVar1 = *(ushort *)(&DAT_04001623 + uVar2 * 0xe);
    if ((uVar1 & 0x7fff) == param_1) break;
    if ((uVar1 & 0x7fff) == 0) {
      uVar3 = uVar3 + 1 & 0xffff;
    }
    uVar2 = uVar2 + 1 & 0xffff;
  }
  (&DAT_04001624)[uVar2 * 0xe] = (&DAT_04001624)[uVar2 * 0xe] | 0x80;
  settings_mark_dirty(0x80,uVar2 & 0xff,&DAT_04001623 + uVar2 * 0xe,0x80,param_4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007b70 @ 20007b70 */


undefined4 FUN_20007b70(uint param_1)

{
  ushort uVar1;
  uint uVar2;
  int iVar3;
  int iVar4;
  uint uVar5;
  int iVar6;
  
  uVar2 = 0;
  uVar5 = 0;
  while( true ) {
    if (CONCAT11(DAT_04001b9c,DAT_04001b9b) + uVar2 <= uVar5) {
      return 1;
    }
    if (99 < uVar5) break;
    iVar6 = uVar5 * 0xe;
    uVar1 = *(ushort *)(&DAT_04001623 + iVar6);
    if ((uVar1 & 0x7fff) == param_1) {
      if (*(short *)(&DAT_04001625 + uVar5 * 0xe) != 0) {
        iVar3 = read_u32_le(&DAT_04001b9e);
        iVar4 = read_u32_le(&DAT_04001627 + iVar6);
        write_u32_le(iVar3 + (iVar4 + 2U & 0xffffff00) + 0x100,&DAT_04001b9e);
      }
      if (*(short *)(&DAT_0400162b + iVar6) != 0) {
        iVar3 = read_u32_le(&DAT_04001b9e);
        iVar4 = read_u32_le(&DAT_0400162d + iVar6);
        write_u32_le(iVar3 + (iVar4 + 2U & 0xffffff00) + 0x100,&DAT_04001b9e);
      }
      (&DAT_04001623)[iVar6] = 0;
      (&DAT_04001624)[iVar6] = (&DAT_04001624)[iVar6] & 0x80;
      (&DAT_04001625)[iVar6] = 0;
      (&DAT_04001626)[iVar6] = 0;
      write_u32_le(0,&DAT_04001627 + iVar6);
      (&DAT_0400162b)[iVar6] = 0;
      (&DAT_0400162c)[iVar6] = 0;
      write_u32_le(0,&DAT_0400162d + iVar6);
      iVar6 = CONCAT11(DAT_04001b9c,DAT_04001b9b) - 1;
      DAT_04001b9b = (undefined1)iVar6;
      DAT_04001b9c = (undefined1)((uint)iVar6 >> 8);
      settings_mark_dirty(0x80,uVar5 & 0xff);
      return 1;
    }
    if ((uVar1 & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar5 = uVar5 + 1 & 0xffff;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007c74 @ 20007c74 */


void FUN_20007c74(void)

{
  if (((ushort)DAT_04000488 & 0xfff) == 0 && DAT_04000478 == '\0') {
    FUN_20007ce8();
    FUN_20005694();
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007c98 @ 20007c98 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

undefined4 FUN_20007c98(uint param_1)

{
  uint uVar1;
  uint uVar2;
  
  uVar2 = 0;
  uVar1 = 0;
  while( true ) {
    if (_DAT_04001b9b + uVar2 <= uVar1) {
      return 0;
    }
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == param_1) break;
    if ((*(ushort *)(&DAT_04001623 + uVar1 * 0xe) & 0x7fff) == 0) {
      uVar2 = uVar2 + 1 & 0xffff;
    }
    uVar1 = uVar1 + 1 & 0xffff;
  }
  return 1;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007ce8 @ 20007ce8 */


void FUN_20007ce8(void)

{
  char cVar1;
  int iVar2;
  int iVar3;
  undefined4 uVar4;
  uint uVar5;
  
  uVar5 = 0;
  do {
    iVar2 = uVar5 * 0x2c;
    if ((&DAT_04001ba9)[iVar2] == '\x01') {
      cVar1 = (&DAT_04001ba6)[iVar2];
      if (cVar1 == '\x03') {
        if ((byte)(&DAT_04001ba8)[iVar2] < (byte)(&DAT_04001ba7)[iVar2]) {
          iVar3 = read_u32_le(&DAT_04001baa + iVar2);
          if (iVar3 == 0) {
            uVar4 = read_u32_le(&DAT_04001bae + iVar2);
            write_u32_le(uVar4,&DAT_04001baa + iVar2);
LAB_20007d8e:
            FUN_20007da8(uVar5);
            FUN_200059b8(uVar5);
          }
        }
        else {
LAB_20007d32:
          (&DAT_04001ba9)[iVar2] = 0;
        }
      }
      else if ((cVar1 == '\x04') || (cVar1 == '\x05')) {
        iVar3 = read_u32_le(&DAT_04001baa + iVar2);
        if (iVar3 == 0) {
          uVar4 = read_u32_le(&DAT_04001bae + iVar2);
          write_u32_le(uVar4,&DAT_04001baa + iVar2);
          FUN_20007da8(uVar5);
          FUN_200059b8(uVar5);
        }
        if (((&DAT_04001ba7)[iVar2] == '\0') && (iVar3 = read_u32_le(iVar2 + 0x4001bb2), iVar3 == 0)
           ) goto LAB_20007d32;
      }
      else if ((cVar1 == '\x0f') && (iVar3 = read_u32_le(&DAT_04001baa + iVar2), iVar3 == 0)) {
        uVar4 = read_u32_le(&DAT_04001bae + iVar2);
        write_u32_le(uVar4,&DAT_04001baa + iVar2);
        if ((&DAT_04001bcf)[iVar2] != '\0') goto LAB_20007d8e;
      }
    }
    uVar5 = uVar5 + 1 & 0xff;
    if (0xc < uVar5) {
      return;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_20007da8 @ 20007da8 */


void FUN_20007da8(int param_1)

{
  int iVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  undefined *puVar5;
  int iVar6;
  int iVar7;
  int iVar8;
  int iVar9;
  int iVar10;
  uint uVar11;
  
  iVar8 = param_1 * 0x2c;
  iVar1 = read_u32_le(iVar8 + 0x4001bc7);
  uVar2 = read_u32_le(iVar8 + 0x4001bcb);
  iVar8 = iVar8 + 0x4001bbe;
  uVar3 = read_u32_le(iVar8);
  if (uVar3 < uVar2) {
    iVar4 = param_1 * 0x2c;
    puVar5 = &DAT_04001de0 + param_1 * 0x40;
    iVar9 = iVar4 + 0x4001bb2;
    iVar10 = iVar4 + 0x4001bba;
    if (uVar2 < 0x41) {
      iVar6 = read_u32_le(iVar10);
      iVar7 = read_u32_le(iVar9);
      FUN_2000b7e8(iVar7 + iVar1,puVar5 + iVar6,uVar2);
      (&DAT_04001bc6)[iVar4] = (&DAT_04001bc6)[iVar4] + (char)uVar2;
      iVar1 = read_u32_le(iVar10);
      write_u32_le(iVar1 + uVar2,iVar10);
      iVar1 = read_u32_le(iVar8);
      write_u32_le(iVar1 + uVar2,iVar8);
      iVar1 = read_u32_le(iVar9);
      write_u32_le(iVar1 + uVar2,iVar9);
    }
    else {
      uVar11 = 0x40 - (byte)(&DAT_04001bc6)[iVar4];
      iVar6 = read_u32_le(iVar9);
      uVar3 = uVar2 - iVar6;
      if (uVar11 <= uVar2 - iVar6) {
        uVar3 = uVar11;
      }
      iVar7 = read_u32_le(iVar10);
      if ((0x40U - iVar7 < uVar11) && (0x40U - iVar7 <= uVar3)) {
        FUN_2000b7e8(iVar6 + iVar1,puVar5 + iVar7);
        iVar6 = read_u32_le(iVar9);
        iVar7 = read_u32_le(iVar10);
        iVar6 = write_u32_le(iVar6 + (0x40 - iVar7),iVar9);
        iVar7 = uVar3 - (0x40 - iVar7);
        FUN_2000b7e8(iVar6 + iVar1,puVar5,iVar7);
        iVar1 = read_u32_le(iVar9);
        write_u32_le(iVar1 + iVar7,iVar9);
      }
      else {
        FUN_2000b7e8(iVar6 + iVar1,puVar5 + iVar7,uVar3);
        iVar1 = read_u32_le(iVar10);
        write_u32_le(iVar1 + uVar3,iVar10);
        iVar7 = read_u32_le(iVar9);
        iVar7 = iVar7 + uVar3;
        iVar10 = iVar9;
      }
      write_u32_le(iVar7,iVar10);
      iVar1 = read_u32_le(iVar8);
      write_u32_le(iVar1 + uVar3,iVar8);
      (&DAT_04001bc6)[iVar4] = (&DAT_04001bc6)[iVar4] + (char)uVar3;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20007f20 @ 20007f20 */


void FUN_20007f20(int param_1)

{
  (&DAT_04001bcf)[param_1 * 0x2c] = (&DAT_04001bcf)[param_1 * 0x2c] + '\x01';
  return;
}


/* ---------------------------------------------------------------------- */
/* main @ 20007f38 */


/* firmware main loop */

undefined4 main(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  
  __aeabi_memclr(&DAT_04000d3e,0x28,param_3,param_4,param_4);
  FUN_200073d0();
  FUN_2000e414();
  FUN_200025d4();
  FUN_20000c3c();
  if (DAT_04000d6d == '\x01') {
    FUN_2000de84();
    uVar1 = 0;
    do {
      memcpy(&DAT_04002d14 + uVar1 * 4,&DAT_040014f2 + uVar1 * 4,4);
      if (uVar1 == 1) {
        DAT_04002db3 = 0;
      }
      else {
        (&DAT_04002d90)[uVar1 * 0x23] = 4;
      }
      (&DAT_04002d91)[uVar1 * 0x23] = 0xff;
      FUN_20005f80(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar1 * 0x23,0);
      uVar1 = uVar1 + 1 & 0xff;
    } while (uVar1 < 3);
    DAT_0400036e = 0;
    DAT_0400036d = 0;
    do {
      FUN_2000b2f8();
    } while ((DAT_04000d48 & 1) == 0);
    DAT_04000d6d = '\0';
    DAT_04000d41 = '\x01';
    settings_mark_dirty(2,0);
  }
  if (DAT_04000d6d != '\0') {
    return 0;
  }
  FUN_20007a9c();
  do {
    wdt_feed();
    if (DAT_04000d41 == '\x01') {
      FUN_2000c218();
      FUN_2000b58c();
      FUN_2000a7a8();
    }
    FUN_20004d84();
  } while ((DAT_04000d48 & 1) == 0);
  FUN_2000de84(0);
  DAT_04000d3e = (DAT_04000d3e & 0xf0) + 3;
  delay_ms(100);
  do {
    do {
      FUN_20004d84();
    } while ((DAT_04000d48 & 1) == 0);
    wdt_feed();
    periodic_tasks();
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_20008054 @ 20008054 */


undefined8 FUN_20008054(uint param_1)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  uint uVar5;
  uint uVar6;
  
  uVar5 = 0;
  iVar4 = -1;
  uVar1 = (param_1 >> 8) + 1;
  uVar6 = 0;
  do {
    uVar3 = 0;
    do {
      if (((byte)(&DAT_040022fa)[uVar6] >> uVar3 & 1) == 0) {
        uVar5 = uVar5 + 1;
        if (iVar4 == -1) {
          iVar4 = (int)(short)((short)(uVar6 << 3) + (short)uVar3);
        }
      }
      else {
        uVar5 = 0;
        iVar4 = -1;
      }
      if (uVar5 == uVar1) {
        FUN_2000cfb8(iVar4,uVar1 & 0xffff);
        uVar2 = iVar4 + 0x298U & 0xffff;
        if (uVar2 < 0x400) goto LAB_200080a4;
      }
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 8);
    uVar6 = uVar6 + 1 & 0xffff;
  } while (uVar6 < 0x2d);
  uVar2 = 0;
LAB_200080a4:
  return CONCAT44(uVar1,uVar2);
}


/* ---------------------------------------------------------------------- */
/* FUN_200080d4 @ 200080d4 */


void FUN_200080d4(void)

{
  FUN_20001746(&DAT_40001000,1,1,0x83);
  FUN_20001746(&DAT_40001000,1,2,0x83);
  FUN_20001746(&DAT_40001000,1,4,0x90);
  FUN_20007334(1,4);
  FUN_200073a8(1,4,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20008118 @ 20008118 */


void FUN_20008118(void)

{
  FUN_20001746(&DAT_40001000,1,1,0x90);
  FUN_20007334(1,1,0);
  FUN_20001746(&DAT_40001000,1,2,0x90);
  FUN_20007334(1,2,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20008150 @ 20008150 */


void FUN_20008150(void)

{
  DAT_04000359 = 0;
  DAT_04000358 = 0;
  DAT_04000364 = 0;
  DAT_04000362 = 0;
  DAT_04000366 = 0;
  __aeabi_memclr(&DAT_04000382,8);
  __aeabi_memclr(&DAT_04000c79,0x50);
  __aeabi_memclr(&DAT_0400038a,8);
  __aeabi_memclr(&DAT_0400036f,3);
  __aeabi_memclr(&DAT_04000b36,0x10a);
  DAT_0400035b = 0;
  DAT_0400035a = 0;
  DAT_0400035d = 0;
  DAT_0400035c = 0;
  DAT_04000372 = 0;
  DAT_04000374 = 0;
  FUN_2000bfe4();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200081b4 @ 200081b4 */


void FUN_200081b4(void)

{
  ushort uVar1;
  int iVar2;
  int iVar3;
  uint uVar4;
  
  uVar4 = 0;
  do {
    iVar2 = uVar4 * 0x2c;
    if (((&DAT_04001ba9)[iVar2] == '\x01') &&
       (iVar3 = read_u32_le(&DAT_04001baa + iVar2), iVar3 != 0)) {
      write_u32_le(iVar3 + -1,&DAT_04001baa + iVar2);
    }
    uVar4 = uVar4 + 1 & 0xff;
  } while (uVar4 < 0xd);
  uVar4 = 0;
  do {
    if ((&DAT_04000b44)[uVar4] != '\0') {
      iVar2 = uVar4 * 2;
      uVar1 = *(ushort *)(&DAT_04000b6b + iVar2);
      (&DAT_04000b6b)[iVar2] = (char)(uVar1 + 1);
      (&DAT_04000b6c)[iVar2] = (char)(uVar1 + 1 >> 8);
    }
    if ((&DAT_04000bc9)[uVar4] != '\0') {
      iVar2 = uVar4 * 2;
      uVar1 = *(ushort *)(&DAT_04000bf0 + iVar2);
      (&DAT_04000bf0)[iVar2] = (char)(uVar1 + 1);
      (&DAT_04000bf1)[iVar2] = (char)(uVar1 + 1 >> 8);
    }
    uVar4 = uVar4 + 1 & 0xff;
  } while (uVar4 < 0xd);
  if ((char)DAT_04000372 != '\0') {
    DAT_04000372._0_1_ = (char)DAT_04000372 + -1;
  }
  if ((char)DAT_04000374 != '\0') {
    DAT_04000374._0_1_ = (char)DAT_04000374 + -1;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000824c @ 2000824c */


void FUN_2000824c(void)

{
  FUN_20008150();
  FUN_200052e0();
  FUN_2000577c(0);
  delay_ms(100);
  FUN_2000ce28();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20008268 @ 20008268 */


undefined8 FUN_20008268(uint param_1,undefined *param_2)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  bool bVar4;
  undefined4 uVar5;
  undefined *local_20;
  
  bVar4 = false;
  if (param_1 - 1 < 5) {
    uVar3 = 1 << (param_1 & 0xff);
    if ((DAT_04000d99 & uVar3) == 0) {
      DAT_04000d99 = DAT_04000d99 | (byte)uVar3;
    }
    bVar4 = true;
  }
  local_20 = param_2;
  if ((param_1 == 1) && (uVar3 = read_u32_le(&DAT_04000dad), uVar3 != 0)) {
    iVar1 = read_u32_le(&DAT_04000db1);
    local_20 = &DAT_04001b9e;
    iVar2 = read_u32_le();
    write_u32_le(iVar2 + (iVar1 + 2U & 0xff00) + 0x100,&DAT_04001b9e);
    FUN_20006dbc(uVar3 >> 8,iVar1 + 2U & 0xffff);
    settings_mark_dirty(0x80,0);
  }
  if ((bVar4) || (uVar5 = 0, param_1 == 1)) {
    memcpy(&DAT_04000c48 + param_1 * 0x164,&UNK_2000e97c + param_1 * 0x164,0x164);
    settings_mark_dirty(0x10,param_1 - 1 & 0xff);
    uVar5 = 1;
  }
  return CONCAT44(local_20,uVar5);
}


/* ---------------------------------------------------------------------- */
/* FUN_20008318 @ 20008318 */


void FUN_20008318(void)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  uint uVar4;
  
  if (DAT_04000c58 <= DAT_04000d62) {
    DAT_04000d62 = 0;
    FUN_2000db54();
    DAT_04000362 = DAT_04000362 + DAT_0400054a;
    iVar1 = (int)DAT_04000362;
    DAT_04000364 = DAT_04000364 + DAT_0400054c;
    iVar2 = (int)DAT_04000364;
    DAT_0400054c = 0;
    DAT_0400054a = 0;
    if (DAT_04000d5e == '\x04') {
      if (iVar1 < 1) {
        iVar1 = -iVar1;
      }
      uVar3 = (uint)DAT_04000368;
      DAT_04000368 = (ushort)(iVar1 + uVar3);
      if (iVar2 < 1) {
        iVar2 = -iVar2;
      }
      uVar4 = (uint)DAT_0400036a;
      DAT_0400036a = (ushort)(iVar2 + uVar4);
      if ((2000 < (iVar1 + uVar3 & 0xffff)) && (2000 < (iVar2 + uVar4 & 0xffff))) {
        DAT_04000354 = 1;
      }
    }
    if (DAT_04000d63 == 'U') {
      if (DAT_04000362 != 0 || DAT_04000364 != 0) {
        DAT_04000366 = DAT_04000366 | 4;
        return;
      }
    }
    else {
      DAT_04000364 = 0;
      DAT_04000362 = 0;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200083d8 @ 200083d8 */


undefined4 FUN_200083d8(int param_1,uint param_2,undefined4 param_3)

{
  int iVar1;
  int extraout_r2;
  int extraout_r3;
  
  iVar1 = FUN_200078fc(param_2,*(undefined2 *)(param_1 + 0x10),param_3,param_1);
  if (iVar1 != 0) {
    return 3;
  }
  if ((*(uint *)(extraout_r3 + 4) <= param_2) &&
     (param_2 + extraout_r2 <=
      *(uint *)(extraout_r3 + 4) + (uint)**(byte **)(extraout_r3 + 0x1c) * 0x1000)) {
    return 0;
  }
  return 5;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000840a @ 2000840a */


undefined4 FUN_2000840a(uint *param_1,uint param_2)

{
  int iVar1;
  int extraout_r2;
  int extraout_r3;
  
  iVar1 = FUN_200078fc(param_2,4);
  if (iVar1 != 0) {
    return 2;
  }
  if ((*param_1 <= param_2) &&
     (iVar1 = FUN_200072dc(*(undefined1 *)param_1[6]), param_2 + extraout_r2 <= iVar1 + *param_1)) {
    return 0;
  }
  if ((0x3ffffff < param_2) &&
     (iVar1 = FUN_20007318(*(undefined1 *)param_1[6]),
     param_2 + extraout_r2 <= (uint)(iVar1 + extraout_r3))) {
    return 0;
  }
  return 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_20008456 @ 20008456 */


undefined4 FUN_20008456(int param_1,undefined4 param_2)

{
  int iVar1;
  uint extraout_r2;
  int extraout_r3;
  
  iVar1 = FUN_200078fc(param_2,*(undefined2 *)(param_1 + 0x10),param_2,param_1);
  if (((iVar1 == 0) && (extraout_r2 <= *(ushort *)(extraout_r3 + 0x12))) && (extraout_r2 != 0)) {
    return 0;
  }
  return 6;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000847a @ 2000847a */


undefined4 FUN_2000847a(int param_1,uint param_2,uint param_3)

{
  int iVar1;
  
  if (param_2 <= param_3) {
    iVar1 = __aeabi_uidiv((uint)**(byte **)(param_1 + 0x1c) << 0xc,*(undefined2 *)(param_1 + 0x12));
    if ((param_2 <= iVar1 - 1U) && (param_3 <= iVar1 - 1U)) {
      return 0;
    }
  }
  return 7;
}


/* ---------------------------------------------------------------------- */
/* FUN_200084a4 @ 200084a4 */


undefined4 FUN_200084a4(void)

{
  int iVar1;
  
  iVar1 = DAT_40000610;
  if (iVar1 << 0x1a < 0) {
    return 0x18;
  }
  iVar1 = DAT_40000200;
  if ((uint)(iVar1 << 0x17) >> 0x1e != 3) {
    return 0x1b;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_200084cc @ 200084cc */


uint FUN_200084cc(void)

{
  int iVar1;
  uint uVar2;
  
  iVar1 = DAT_40000610;
  uVar2 = (uint)(iVar1 << 0x1b) >> 0x1e;
  if (uVar2 != 0) {
    uVar2 = 0x17;
  }
  return uVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_200084e0 @ 200084e0 */


void FUN_200084e0(undefined4 param_1,uint param_2,undefined4 param_3,uint param_4)

{
  uint uVar1;
  byte bVar2;
  uint uVar3;
  uint uVar4;
  undefined1 *puVar5;
  int iVar6;
  uint uVar7;
  int iVar8;
  uint uVar9;
  
  uVar1 = DAT_0400048c;
  uVar3 = DAT_04000488;
  uVar4 = DAT_0400047c;
  param_2 = param_2 & 0xffff0000;
  uVar9 = param_4 & 0xffffff00;
  if (DAT_0400047c != 0) {
    uVar7 = 0;
    do {
      if ((1 << (uVar7 & 0xff) & DAT_0400047c) != 0) {
        __aeabi_memclr(&DAT_04002b4c,0x100,param_3,param_4,param_2,0,uVar9);
        memcpy(&DAT_04002b4c,&DAT_0400232c + uVar7 * 0x100,0x100);
        DAT_04000478 = 1;
        DAT_0400047c = uVar4 & ~(1 << (uVar7 & 0xff));
        DAT_04000480 = (uint)(&DAT_04002b2c)[uVar7] >> 0xf;
        DAT_04000484 = (uint)(&DAT_04002b2c)[uVar7] >> 8;
        return;
      }
      uVar7 = uVar7 + 1;
    } while (uVar7 < 8);
  }
  if ((DAT_04000488 & 3) != 0) {
    if ((DAT_04000488 & 1) != 0) {
      __aeabi_memclr(&DAT_04002b4c,0x100,param_3,param_4,param_2,0,uVar9);
      memcpy(&DAT_04002b4c,&DAT_040014ae,0x56);
      DAT_04000478 = 1;
      DAT_04000480 = 5;
      DAT_04000484 = 0x280;
      DAT_04000488 = uVar3 & 0xfffffffe;
      DAT_0400048c = uVar1;
      return;
    }
    if (-1 < (int)(DAT_04000488 << 0x1e)) {
      return;
    }
    __aeabi_memclr(&DAT_04002b4c,0x100,param_3,param_4,param_2,0,uVar9);
    memcpy(&DAT_04002b4c,&DAT_04000d66,0xb);
    DAT_04000484 = 0x281;
    uVar4 = 0xfffffffd;
LAB_200085c2:
    DAT_04000488 = uVar3 & uVar4;
    DAT_04000480 = 5;
    DAT_04000478 = 1;
    DAT_0400048c = uVar1;
    return;
  }
  if ((int)(DAT_04000488 << 0x1d) < 0) {
    __aeabi_memclr(&DAT_04002b4c,0x100,param_3,param_4,param_2,0,uVar9);
    memcpy(&DAT_04002b4c,&DAT_04000d71,0x24);
    DAT_04000484 = 0x282;
    uVar4 = 0xfffffffb;
    goto LAB_200085c2;
  }
  if ((DAT_04000488 << 0x12) >> 0x15 == 0) {
    if ((DAT_04000488 << 0x10) >> 0x1e == 0) {
      if ((DAT_04000488 << 8) >> 0x18 == 0) {
        return;
      }
      iVar8 = 0x10;
      uVar9 = 0x16;
      uVar4 = 0x10;
      while( true ) {
        if ((uVar9 & 0xff) <= uVar4) {
          return;
        }
        uVar7 = __aeabi_llsr(uVar3,uVar1,uVar4);
        if ((uVar7 & 1) != 0) break;
        uVar4 = uVar4 + 1;
      }
      iVar8 = (uVar4 - iVar8) * 0x100;
      uVar3 = iVar8 + 0x29000;
      __aeabi_memclr(&DAT_04002b4c,0x100);
      puVar5 = &DAT_04001623;
      if (uVar4 == (uVar9 & 0xff) - 1) {
        iVar6 = 0x581;
LAB_2000874c:
        iVar6 = iVar6 - iVar8;
        puVar5 = puVar5 + iVar8;
        goto LAB_20008642;
      }
    }
    else {
      iVar8 = 0xe;
      uVar9 = 0xf;
      uVar4 = 0xe;
      while( true ) {
        if ((uVar9 & 0xff) <= uVar4) {
          return;
        }
        uVar7 = __aeabi_llsr(uVar3,uVar1,uVar4);
        if ((uVar7 & 1) != 0) break;
        uVar4 = uVar4 + 1;
      }
      iVar8 = (uVar4 - iVar8) * 0x100;
      uVar3 = iVar8 + 0x28e00;
      __aeabi_memclr(&DAT_04002b4c,0x100);
      puVar5 = &DAT_040022fa;
      if (uVar4 == (uVar9 & 0xff) - 1) {
        iVar6 = 0x2f;
        goto LAB_2000874c;
      }
    }
    puVar5 = puVar5 + iVar8;
  }
  else {
    iVar8 = 3;
    bVar2 = DAT_04000d98 + 3;
    if (DAT_04000d97 != '\0') {
      bVar2 = DAT_04000d98 + 4;
    }
    uVar9 = (uint)bVar2;
    uVar4 = 3;
    while( true ) {
      if ((uVar9 & 0xff) <= uVar4) {
        return;
      }
      uVar7 = __aeabi_llsr(uVar3,uVar1,uVar4);
      if ((uVar7 & 1) != 0) break;
      uVar4 = uVar4 + 1;
    }
    iVar8 = (uVar4 - iVar8) * 0x100;
    uVar3 = iVar8 + 0x28300;
    __aeabi_memclr(&DAT_04002b4c,0x100);
    if (uVar4 == (uVar9 & 0xff) - 1) {
      iVar6 = 0x70b - iVar8;
      puVar5 = &DAT_04000d95 + iVar8;
      goto LAB_20008642;
    }
    puVar5 = &DAT_04000d95 + iVar8;
  }
  iVar6 = 0x100;
LAB_20008642:
  memcpy(&DAT_04002b4c,puVar5,iVar6);
  DAT_04000484 = uVar3 >> 8;
  DAT_04000480 = uVar3 >> 0xf;
  DAT_04000478 = 1;
  uVar4 = ~(1 << (uVar4 & 0xff));
  DAT_0400048c = (int)uVar4 >> 0x1f & DAT_0400048c;
  DAT_04000488 = uVar4 & DAT_04000488;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_200087a0 @ 200087a0 */


undefined4 FUN_200087a0(int param_1,int param_2)

{
  uint uVar1;
  int iVar2;
  uint uVar3;
  
  if ((param_1 - 0x28000U < 0x18000) && (param_2 != 0)) {
    do {
      uVar1 = param_1 - 0x28000U & 0xff;
      if (param_2 + uVar1 < 0x101) {
        uVar1 = 1 << (param_1 - 0x28000U >> 8 & 0xff);
        DAT_04000488 = uVar1 | DAT_04000488;
        DAT_0400048c = (int)uVar1 >> 0x1f | DAT_0400048c;
        return 1;
      }
      uVar3 = 1 << (param_1 - 0x28000U >> 8 & 0xff);
      DAT_0400048c = (int)uVar3 >> 0x1f | DAT_0400048c;
      DAT_04000488 = uVar3 | DAT_04000488;
      iVar2 = 0x100 - uVar1;
      param_2 = param_2 - iVar2;
      param_1 = iVar2 + param_1;
    } while (param_2 != 0);
    return 1;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class02_keymap @ 20008814 */


/* class 0x02: button / key remapping */

void razer_cmd_class02_keymap(void)

{
  byte bVar1;
  uint uVar2;
  undefined4 uVar3;
  uint uVar4;
  int iVar5;
  int iVar6;
  uint uVar7;
  uint uVar8;
  uint uVar9;
  int iVar10;
  bool bVar11;
  
  bVar1 = g_razer_report.args[1];
  uVar2 = (uint)g_razer_report.args[0];
  uVar4 = 0;
  iVar5 = uVar2 * 6;
  iVar6 = uVar2 * 0x164;
  if (g_razer_report.command_id == 0x84) {
    g_razer_report.args[0] = 0xd;
    uVar2 = 1;
    do {
      g_razer_report.args[uVar2] = *(byte *)(uVar2 * 0x10 + 0x4000e30);
      uVar2 = uVar2 + 1 & 0xff;
    } while (uVar2 < 0xe);
    return;
  }
  if (0x84 < g_razer_report.command_id) {
    if (g_razer_report.command_id == 0x96) {
      if (uVar2 != 0) {
        g_razer_report.args[1] = *(byte *)((int)&DAT_04000cd8 + iVar6 + 2);
        return;
      }
      g_razer_report.args[1] = DAT_0400036d;
      return;
    }
    if (0x96 < g_razer_report.command_id) {
      if (g_razer_report.command_id == 0x97) {
        if (uVar2 != 0) {
          g_razer_report.args[1] = *(byte *)((int)&DAT_04000cd8 + iVar6 + 3);
          return;
        }
        g_razer_report.args[1] = DAT_0400036e;
        return;
      }
      if (g_razer_report.command_id != 0x98) {
        g_razer_report.status = 5;
        return;
      }
      g_razer_report.args[0] = DAT_04000d6c;
      return;
    }
    if (g_razer_report.command_id == 0x8c) {
      for (; (&DAT_04000e40)[uVar4 * 0x10] != g_razer_report.args[1]; uVar4 = uVar4 + 1 & 0xff) {
        if (0xc < uVar4) {
          g_razer_report.status = 3;
          return;
        }
      }
      if (uVar4 < 0xd) {
        if (g_razer_report.args[0] == 0) {
          bVar11 = g_razer_report.args[2] != 0;
          iVar5 = uVar4 * 0x10;
          g_razer_report.args[1] = (&DAT_04000a66)[iVar5];
          g_razer_report.args[2] = *(byte *)(iVar5 + 0x4000a67);
          iVar5 = (uint)bVar11 + iVar5;
          g_razer_report.args[3] = (&DAT_04000a66)[iVar5 + 2];
          g_razer_report.args[4] = (&DAT_04000a66)[iVar5 + 4];
          g_razer_report.args[5] = (&DAT_04000a66)[iVar5 + 6];
          g_razer_report.args[6] = (&DAT_04000a66)[iVar5 + 8];
          g_razer_report.args[7] = (&DAT_04000a66)[iVar5 + 10];
          g_razer_report.args[8] = (&DAT_04000a66)[iVar5 + 0xc];
          g_razer_report.args[9] = (&DAT_04000a66)[iVar5 + 0xe];
        }
        else {
          uVar2 = (uint)g_razer_report.args[2];
          if (uVar2 != 0) {
            uVar2 = 1;
          }
          iVar5 = uVar4 * 0x10 + (uint)(byte)(g_razer_report.args[0] - 1) * 0x164;
          g_razer_report.args[1] = (&DAT_04000d95)[iVar5 + 0xab];
          g_razer_report.args[2] = (&DAT_04000d95)[iVar5 + 0xac];
          iVar5 = uVar2 + iVar5;
          g_razer_report.args[3] = (&DAT_04000d95)[iVar5 + 0xad];
          g_razer_report.args[4] = (&DAT_04000d95)[iVar5 + 0xaf];
          g_razer_report.args[5] = (&DAT_04000d95)[iVar5 + 0xb1];
          g_razer_report.args[6] = (&DAT_04000d95)[iVar5 + 0xb3];
          g_razer_report.args[7] = (&DAT_04000d95)[iVar5 + 0xb5];
          g_razer_report.args[8] = (&DAT_04000d95)[iVar5 + 0xb7];
          g_razer_report.args[9] = (&DAT_04000d95)[iVar5 + 0xb9];
        }
        g_razer_report.data_size = 10;
        return;
      }
    }
    else {
      if (g_razer_report.command_id != 0x8e) {
        if (g_razer_report.command_id != 0x94) {
          g_razer_report.status = 5;
          return;
        }
        if (uVar2 != 0) {
          g_razer_report.args[1] = (&DAT_04000d74)[iVar5];
          return;
        }
        g_razer_report.args[1] = DAT_0400036c;
        return;
      }
      if (uVar2 != 0) {
        iVar5 = g_razer_report.data_size - 3;
        FUN_20006df8(uVar2,g_razer_report.args[1],g_razer_report.args[2],0x4000cef,
                     (((uint)(iVar5 >> 0x1f) >> 0x1d) + iVar5) * 0x200000 >> 0x18);
        return;
      }
    }
    g_razer_report.status = 3;
    return;
  }
  uVar7 = (uint)DAT_04000d73;
  uVar8 = (uint)g_razer_report.args[0];
  uVar9 = (uint)DAT_04000d74;
  iVar10 = uVar9 * 0x164;
  if (g_razer_report.command_id == 0x16) {
    if (uVar2 == 0) {
      if (g_razer_report.args[1] == DAT_0400036d) {
        return;
      }
      DAT_0400036d = g_razer_report.args[1];
      return;
    }
    if (uVar2 == uVar7) {
      if (g_razer_report.args[1] == (&DAT_04000e3e)[iVar10]) {
        return;
      }
      (&DAT_04000e3e)[iVar10] = g_razer_report.args[1];
      DAT_0400036d = bVar1;
    }
    else {
      if (g_razer_report.args[1] == *(byte *)((int)&DAT_04000cd8 + iVar6 + 2)) {
        return;
      }
      *(byte *)((int)&DAT_04000cd8 + iVar6 + 2) = g_razer_report.args[1];
LAB_20008bb8:
      uVar9 = uVar8 - 1 & 0xff;
    }
  }
  else if (g_razer_report.command_id < 0x17) {
    if (g_razer_report.command_id == 2) {
      DAT_04000d68 = g_razer_report.args[0];
      DAT_04000d69 = g_razer_report.args[1];
      DAT_04000d6a = g_razer_report.args[2];
      DAT_04000d6b = g_razer_report.args[3];
      bVar1 = DAT_04000d6c;
      if (g_razer_report.data_size == 2) {
        DAT_04000d6a = g_razer_report.args[0];
        DAT_04000d6b = g_razer_report.args[1];
      }
LAB_200088f2:
      DAT_04000d6c = bVar1;
      uVar9 = 0;
      uVar3 = 2;
      goto LAB_20008a8c;
    }
    if (g_razer_report.command_id != 0xc) {
      if (g_razer_report.command_id != 0x14) {
        g_razer_report.status = 5;
        return;
      }
      if (uVar2 == 0) {
        if (g_razer_report.args[1] != DAT_0400036c) {
          DAT_0400036c = g_razer_report.args[1];
          FUN_2000c034(2,0);
          return;
        }
        return;
      }
      if (uVar2 == uVar7) {
        if (g_razer_report.args[1] == (&DAT_04000d7a)[uVar9 * 6]) {
          return;
        }
        (&DAT_04000d7a)[uVar9 * 6] = g_razer_report.args[1];
        DAT_0400036c = bVar1;
        FUN_2000c034(2,0);
      }
      else {
        if (g_razer_report.args[1] == (&DAT_04000d74)[iVar5]) {
          return;
        }
        (&DAT_04000d74)[iVar5] = g_razer_report.args[1];
      }
      uVar9 = 0;
      uVar3 = 0x20;
      goto LAB_20008a8c;
    }
    for (; (&DAT_04000e40)[uVar4 * 0x10] != g_razer_report.args[1]; uVar4 = uVar4 + 1 & 0xff) {
      if (0xc < uVar4) {
        g_razer_report.status = 3;
        return;
      }
    }
    if (0xc < uVar4) {
      g_razer_report.status = 3;
      return;
    }
    uVar2 = (uint)g_razer_report.args[0];
    if (uVar2 == 0) {
      uVar2 = (uint)g_razer_report.args[2];
      if (uVar2 != 0) {
        uVar2 = 1;
      }
      iVar5 = uVar4 * 0x10;
      (&DAT_04000a66)[iVar5] = g_razer_report.args[1];
      *(byte *)(iVar5 + 0x4000a67) = g_razer_report.args[2];
      iVar5 = uVar2 + iVar5;
      (&DAT_04000a66)[iVar5 + 2] = g_razer_report.args[3];
      (&DAT_04000a66)[iVar5 + 4] = g_razer_report.args[4];
      (&DAT_04000a66)[iVar5 + 6] = g_razer_report.args[5];
      (&DAT_04000a66)[iVar5 + 8] = g_razer_report.args[6];
      (&DAT_04000a66)[iVar5 + 10] = g_razer_report.args[7];
      (&DAT_04000a66)[iVar5 + 0xc] = g_razer_report.args[8];
      (&DAT_04000a66)[iVar5 + 0xe] = g_razer_report.args[9];
      return;
    }
    if (uVar2 == uVar7) {
      uVar9 = uVar2 - 1 & 0xff;
      bVar11 = g_razer_report.args[2] != 0;
      iVar5 = uVar4 * 0x10 + uVar9 * 0x164;
      (&DAT_04000d95)[iVar5 + 0xab] = g_razer_report.args[1];
      (&DAT_04000d95)[iVar5 + 0xac] = g_razer_report.args[2];
      iVar6 = (uint)bVar11 + iVar5;
      (&DAT_04000d95)[iVar6 + 0xad] = g_razer_report.args[3];
      (&DAT_04000d95)[iVar6 + 0xaf] = g_razer_report.args[4];
      (&DAT_04000d95)[iVar6 + 0xb1] = g_razer_report.args[5];
      (&DAT_04000d95)[iVar6 + 0xb3] = g_razer_report.args[6];
      (&DAT_04000d95)[iVar6 + 0xb5] = g_razer_report.args[7];
      (&DAT_04000d95)[iVar6 + 0xb7] = g_razer_report.args[8];
      (&DAT_04000d95)[iVar6 + 0xb9] = g_razer_report.args[9];
      memcpy(&DAT_04000a66 + uVar4 * 0x10,&DAT_04000d95 + iVar5 + 0xab,0x10);
    }
    else {
      uVar7 = (uint)g_razer_report.args[2];
      uVar9 = uVar2 - 1 & 0xff;
      if (uVar7 != 0) {
        uVar7 = 1;
      }
      iVar5 = uVar4 * 0x10 + uVar9 * 0x164;
      (&DAT_04000d95)[iVar5 + 0xab] = g_razer_report.args[1];
      (&DAT_04000d95)[iVar5 + 0xac] = g_razer_report.args[2];
      iVar5 = uVar7 + iVar5;
      (&DAT_04000d95)[iVar5 + 0xad] = g_razer_report.args[3];
      (&DAT_04000d95)[iVar5 + 0xaf] = g_razer_report.args[4];
      (&DAT_04000d95)[iVar5 + 0xb1] = g_razer_report.args[5];
      (&DAT_04000d95)[iVar5 + 0xb3] = g_razer_report.args[6];
      (&DAT_04000d95)[iVar5 + 0xb5] = g_razer_report.args[7];
      (&DAT_04000d95)[iVar5 + 0xb7] = g_razer_report.args[8];
      (&DAT_04000d95)[iVar5 + 0xb9] = g_razer_report.args[9];
    }
  }
  else {
    if (g_razer_report.command_id != 0x17) {
      bVar1 = g_razer_report.args[0];
      if (g_razer_report.command_id != 0x18) {
        if (g_razer_report.command_id != 0x82) {
          g_razer_report.status = 5;
          return;
        }
        g_razer_report.args[0] = DAT_04000d68;
        g_razer_report.args[1] = DAT_04000d69;
        g_razer_report.args[2] = DAT_04000d6a;
        g_razer_report.args[3] = DAT_04000d6b;
        return;
      }
      goto LAB_200088f2;
    }
    if (uVar2 == 0) {
      if (g_razer_report.args[1] == DAT_0400036e) {
        return;
      }
      DAT_0400036e = g_razer_report.args[1];
      return;
    }
    if (uVar2 != uVar7) {
      if (g_razer_report.args[1] == *(byte *)((int)&DAT_04000cd8 + iVar6 + 3)) {
        return;
      }
      *(byte *)((int)&DAT_04000cd8 + iVar6 + 3) = g_razer_report.args[1];
      goto LAB_20008bb8;
    }
    if (g_razer_report.args[1] == (&DAT_04000e3f)[iVar10]) {
      return;
    }
    (&DAT_04000e3f)[iVar10] = g_razer_report.args[1];
    DAT_0400036e = bVar1;
  }
  uVar3 = 0x40;
LAB_20008a8c:
  settings_mark_dirty(uVar3,uVar9);
  return;
}


/* ---------------------------------------------------------------------- */
/* button_action_execute @ 20008bf4 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x20008cbe) */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000902c) */
/* WARNING (jumptable): Removing unreachable block (ram,0x20008df6) */
/* WARNING: Removing unreachable block (ram,0x2000902c) */
/* WARNING: Removing unreachable block (ram,0x20008cbe) */
/* WARNING: Removing unreachable block (ram,0x20008df6) */
/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */
/* executes the action bound to a physical button (mouse button, key, DPI step +-100 up to 26000,
   profile, ...) */

void button_action_execute(int param_1,uint param_2)

{
  byte bVar1;
  undefined1 uVar2;
  undefined2 uVar3;
  undefined2 uVar4;
  char cVar5;
  uint uVar6;
  undefined4 uVar7;
  int iVar8;
  undefined1 uVar9;
  undefined1 extraout_r1;
  ushort uVar10;
  uint uVar11;
  uint uVar12;
  uint uVar13;
  uint uVar14;
  int iVar15;
  int iVar16;
  bool bVar17;
  uint local_30;
  
  bVar1 = DAT_04000c59;
  local_30 = 0;
  uVar11 = ((uint)DAT_04000d3e << 0x1a) >> 0x1e;
  uVar10 = DAT_04000366 | 1;
  if (uVar11 == 3) {
    if (param_2 < 5) {
      if (param_1 != 1) {
        DAT_0400032f = DAT_0400032f &
                       ~(byte)(1 << ((byte)(&UNK_2000eb7a)
                                           [(uint)DAT_04000d74 * 0x164 + param_2 * 0x10] - 1 & 0xff)
                              );
        DAT_04000366 = uVar10;
        return;
      }
      DAT_0400032f = (byte)(1 << ((byte)(&UNK_2000eb7a)[(uint)DAT_04000d74 * 0x164 + param_2 * 0x10]
                                  - 1 & 0xff)) | DAT_0400032f;
      DAT_04000366 = uVar10;
      return;
    }
    if (param_2 == 5) {
      if (param_1 == 1) {
        DAT_0400032f = DAT_0400032f | 0x20;
        DAT_04000366 = uVar10;
        return;
      }
      DAT_0400032f = DAT_0400032f & 0xdf;
      DAT_04000366 = uVar10;
      return;
    }
    if (param_2 != 6) {
      DAT_04000366 = DAT_04000366 | 0x40;
      DAT_04000ca9 = 4;
      return;
    }
    if (param_1 != 1) {
      DAT_0400032f = DAT_0400032f & 0xbf;
      DAT_04000366 = uVar10;
      return;
    }
    DAT_0400032f = DAT_0400032f | 0x40;
    DAT_04000366 = uVar10;
    return;
  }
  uVar12 = (uint)DAT_0400032c;
  uVar13 = 1 << (param_2 & 0xff);
  if (uVar12 == 0) {
    if (param_1 == 1) {
      DAT_04000338 = uVar13 | DAT_04000338;
    }
    else {
      DAT_04000338 = DAT_04000338 & ~uVar13;
    }
  }
  else if (uVar12 == 1) {
    if (param_1 == 1) {
      DAT_04000334 = uVar13 | DAT_04000334;
    }
    else {
      DAT_04000334 = DAT_04000334 & ~uVar13;
    }
  }
  if ((((DAT_0400033c != 0) && (uVar12 == 1)) && (param_1 == 0)) && ((uVar13 & DAT_04000338) != 0))
  {
    uVar12 = 0;
    DAT_04000338 = DAT_04000338 & ~uVar13;
  }
  iVar15 = param_2 * 2;
  iVar8 = uVar12 + param_2 * 0x10;
  uVar14 = (uint)CONCAT11(DAT_04000379,DAT_04000378);
  uVar12 = (uint)CONCAT11(DAT_04000377,DAT_04000376);
  uVar6 = 0;
  uVar9 = (undefined1)param_2;
  switch((&DAT_04000a66)[iVar8 + 2]) {
  case 1:
    bVar1 = (&DAT_04000a66)[iVar8 + 6];
    if (bVar1 != 5) {
      if (5 < bVar1) {
        uVar11 = (uint)DAT_04000d74;
        if (bVar1 == 9) {
          if (param_1 != 1) {
            return;
          }
          if (DAT_04000327 == '\0') {
            cVar5 = '\x01';
            goto LAB_20008dd4;
          }
          uVar12 = uVar12 + 100;
          if (25999 < uVar12) {
            uVar12 = 26000;
          }
          uVar12 = uVar12 & 0xffff;
          DAT_04000376 = (undefined1)uVar12;
          DAT_04000377 = (undefined1)(uVar12 >> 8);
          uVar14 = uVar14 + 100;
          if (25999 < uVar14) {
            uVar14 = 26000;
          }
        }
        else {
          if (bVar1 != 10) {
            if (bVar1 == 0x68) {
              if (param_1 != 1) {
                return;
              }
              cVar5 = -1;
            }
            else {
              if (bVar1 != 0x69) {
                return;
              }
              if (param_1 != 1) {
                return;
              }
              cVar5 = '\x01';
            }
            DAT_04000359 = DAT_04000359 + cVar5;
            DAT_04000366 = DAT_04000366 | 2;
            return;
          }
          if (param_1 != 1) {
            return;
          }
          if (DAT_04000327 == '\0') {
            cVar5 = -1;
LAB_20008dd4:
            DAT_04000358 = DAT_04000358 + cVar5;
            DAT_04000366 = DAT_04000366 | 2;
            return;
          }
          uVar12 = uVar12 - 100;
          if ((int)uVar12 < 0x33) {
            uVar12 = 0x32;
          }
          uVar12 = uVar12 & 0xffff;
          DAT_04000376 = (undefined1)uVar12;
          DAT_04000377 = (undefined1)(uVar12 >> 8);
          uVar14 = uVar14 - 100;
          if ((int)uVar14 < 0x33) {
            uVar14 = 0x32;
          }
        }
        uVar14 = uVar14 & 0xffff;
        uVar9 = (undefined1)(uVar14 >> 8);
        DAT_04000378 = (char)uVar14;
        DAT_04000379 = uVar9;
        (&DAT_04000d76)[uVar11 * 6] = (char)uVar12;
        (&DAT_04000d77)[uVar11 * 6] = (char)(uVar12 >> 8);
        uVar11 = (uint)DAT_04000d74;
        (&DAT_04000d78)[uVar11 * 6] = (char)uVar14;
        (&DAT_04000d79)[uVar11 * 6] = uVar9;
        FUN_2000cc38(uVar12,uVar14,0);
        goto LAB_20009332;
      }
      if ((((bVar1 != 1) && (bVar1 != 2)) && (bVar1 != 3)) && (bVar1 != 4)) {
        return;
      }
    }
    DAT_04000366 = uVar10;
    if (param_1 == 1) {
      DAT_0400032f = (byte)(1 << (uint)(byte)(bVar1 - 1)) | DAT_0400032f;
    }
    else {
      DAT_0400032f = DAT_0400032f & ~(byte)(1 << (uint)(byte)(bVar1 - 1));
    }
    break;
  case 2:
    uVar10 = DAT_04000366 | 8;
    if (param_1 == 1) {
      bVar1 = (&DAT_04000a66)[iVar8 + 6];
      do {
        if ((bVar1 >> uVar6 & 1) != 0) {
          (&DAT_04000344)[uVar6] = (&DAT_04000344)[uVar6] + '\x01';
          DAT_04000c40 = DAT_04000c40 | (byte)(1 << uVar6);
        }
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 8);
      uVar11 = 2;
      do {
        if ((&DAT_04000c40)[uVar11] == '\0') {
          uVar9 = (&DAT_04000a66)[iVar8 + 8];
LAB_20008fda:
          (&DAT_04000c40)[uVar11] = uVar9;
          DAT_04000366 = uVar10;
          return;
        }
        uVar11 = uVar11 + 1 & 0xff;
      } while (uVar11 < 8);
    }
    else {
      bVar1 = (&DAT_04000a66)[iVar8 + 6];
      do {
        if (((bVar1 >> uVar6 & 1) != 0) &&
           ((cVar5 = (&DAT_04000344)[uVar6], cVar5 == '\0' ||
            ((&DAT_04000344)[uVar6] = cVar5 + -1, cVar5 == '\x01')))) {
          DAT_04000c40 = DAT_04000c40 & ~(byte)(1 << uVar6);
        }
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 8);
      uVar11 = 2;
      do {
        if ((&DAT_04000c40)[uVar11] == (&DAT_04000a66)[iVar8 + 8]) {
          uVar9 = 0;
          goto LAB_20008fda;
        }
        uVar11 = uVar11 + 1 & 0xff;
      } while (uVar11 < 8);
    }
    break;
  case 3:
    if (param_1 != 1) {
      return;
    }
    iVar15 = FUN_20005360(param_2);
    if (iVar15 != 0) {
      return;
    }
    uVar7 = 3;
    uVar9 = (&DAT_04000a66)[iVar8 + 10];
    uVar3 = CONCAT11((&DAT_04000a66)[iVar8 + 6],(&DAT_04000a66)[iVar8 + 8]);
    goto LAB_200090ea;
  case 4:
    if (param_1 != 1) {
LAB_200090ba:
      FUN_20005eb8(param_2);
      return;
    }
    uVar3 = CONCAT11((&DAT_04000a66)[iVar8 + 6],(&DAT_04000a66)[iVar8 + 8]);
    iVar8 = FUN_20005360(param_2);
    if (iVar8 != 0) {
      return;
    }
    uVar9 = 1;
    uVar7 = 4;
    goto LAB_200090ea;
  case 5:
    if (param_1 != 1) {
      return;
    }
    iVar15 = FUN_20005360(param_2);
    if (iVar15 != 0) goto LAB_200090ba;
    uVar7 = 4;
    goto LAB_200090de;
  case 6:
    uVar11 = (uint)DAT_04000c59;
    uVar13 = (uint)DAT_04000c5a;
    switch((&DAT_04000a66)[iVar8 + 6]) {
    default:
      break;
    case 1:
      if (param_1 != 1) {
        return;
      }
      uVar12 = uVar13 - 1 & 0xff;
      DAT_04000c59 = (byte)(uVar13 - 1);
      goto LAB_20008e3e;
    case 2:
      if (param_1 != 1) {
        return;
      }
      if ((int)(uVar11 - 1) < 1) {
        DAT_04000c59 = 0;
      }
      else {
        DAT_04000c59 = DAT_04000c59 - 1;
      }
      uVar12 = (uint)DAT_04000c59;
LAB_20008e3e:
      DAT_0400032a = bVar1;
      DAT_0400032b = DAT_04000c59;
      if (uVar12 == uVar11) {
        return;
      }
LAB_20008e5e:
      uVar3 = *(undefined2 *)(&DAT_04000c5b + uVar12 * 6);
      DAT_04000376 = (undefined1)uVar3;
      DAT_04000377 = (undefined1)((ushort)uVar3 >> 8);
      uVar4 = *(undefined2 *)(&DAT_04000c5d + uVar12 * 6);
      DAT_04000378 = (undefined1)uVar4;
      DAT_04000379 = (undefined1)((ushort)uVar4 >> 8);
      FUN_2000cc38(uVar3,uVar4,0);
      (&DAT_04000d75)[(uint)DAT_04000d74 * 6] = DAT_04000c59;
      uVar9 = DAT_04000377;
      uVar11 = (uint)DAT_04000d74;
      (&DAT_04000d76)[uVar11 * 6] = DAT_04000376;
      (&DAT_04000d77)[uVar11 * 6] = uVar9;
      uVar9 = DAT_04000379;
      uVar11 = (uint)DAT_04000d74;
      (&DAT_04000d78)[uVar11 * 6] = DAT_04000378;
      (&DAT_04000d79)[uVar11 * 6] = uVar9;
      goto LAB_20009332;
    case 3:
      if (param_1 != 1) {
        return;
      }
      DAT_04000c59 = (&DAT_04000a66)[iVar8 + 8] - 1;
      uVar12 = (uint)DAT_04000c59;
      if ((int)(uVar13 - 1) < (int)uVar12) {
        return;
      }
      goto LAB_20008e5e;
    case 4:
      if (param_1 == 1) {
        DAT_04000327 = '\x01';
      }
      else {
        DAT_04000327 = '\0';
      }
      break;
    case 5:
      if (param_1 == 1) {
        DAT_04000328 = 1;
        _DAT_04000340 = CONCAT11((&DAT_04000a66)[iVar8 + 8],(&DAT_04000a66)[iVar8 + 10]);
        _DAT_04000342 = CONCAT11((&DAT_04000a66)[iVar8 + 0xc],(&DAT_04000a66)[iVar8 + 0xe]);
        FUN_2000ccc8(_DAT_04000340,_DAT_04000342,0);
      }
      else {
        DAT_04000328 = 0;
        FUN_2000cc38(uVar12,uVar14,0);
      }
      break;
    case 6:
      if (param_1 != 1) {
        return;
      }
      if (uVar11 + 1 < uVar13) {
        DAT_04000c59 = DAT_04000c59 + 1;
      }
      else {
        DAT_04000c59 = 0;
      }
      goto LAB_20008f4c;
    case 7:
      if (param_1 != 1) {
        return;
      }
      if ((int)(uVar11 - 1) < 0) {
        DAT_04000c59 = DAT_04000c5a - 1;
      }
      else {
        DAT_04000c59 = DAT_04000c59 - 1;
      }
LAB_20008f4c:
      uVar12 = (uint)DAT_04000c59;
      goto LAB_20008e5e;
    }
    break;
  case 7:
    if (param_1 != 1) {
      return;
    }
    if (uVar11 == 2) {
      __aeabi_uidiv(DAT_04000329 + 1,5);
      DAT_04000329 = extraout_r1;
      return;
    }
    switch((&DAT_04000a66)[iVar8 + 6]) {
    default:
      return;
    case 1:
      uVar9 = 0;
      uVar7 = 1;
      break;
    case 2:
      uVar9 = 0;
      uVar7 = 2;
      break;
    case 3:
      uVar9 = (&DAT_04000a66)[iVar8 + 8];
      uVar7 = 3;
      break;
    case 4:
      uVar9 = 0;
      uVar7 = 4;
      break;
    case 5:
      uVar9 = 0;
      uVar7 = 5;
    }
    FUN_2000df1c(uVar7,uVar9);
    goto LAB_20009332;
  case 9:
    if (param_1 == 1) {
      DAT_04000c9a = (&DAT_04000a66)[iVar8 + 6];
    }
    else {
      DAT_04000c9a = 0;
    }
    DAT_04000c99 = 3;
    DAT_04000366 = DAT_04000366 | 0x20;
    break;
  case 10:
    if (param_1 == 1) {
      DAT_04000c8b = (&DAT_04000a66)[iVar8 + 6];
      DAT_04000c8a = (&DAT_04000a66)[iVar8 + 8];
    }
    else {
      DAT_04000c8a = 0;
      DAT_04000c8b = 0;
    }
    DAT_04000c89 = 2;
    DAT_04000366 = DAT_04000366 | 0x10;
    break;
  case 0xb:
    if (param_1 == 1) {
      DAT_04000325 = (undefined1)(1 << ((byte)(&DAT_04000a66)[iVar8 + 6] - 1 & 0xff));
      DAT_04000326 = 0;
      DAT_04000324 = 1;
    }
    break;
  case 0xc:
    if (param_1 == 1) {
      DAT_0400033c = uVar13 | DAT_0400033c;
      DAT_0400032c = 1;
    }
    else {
      DAT_0400033c = DAT_0400033c & ~uVar13;
      if (DAT_0400033c == 0) {
        do {
          if ((1 << local_30 & DAT_04000334) != 0) {
            button_action_execute(0,local_30);
          }
          local_30 = local_30 + 1 & 0xff;
        } while (local_30 < 0xd);
        DAT_04000334 = 0;
        DAT_0400032c = 0;
      }
    }
    break;
  case 0xd:
    iVar16 = param_2 * 2;
    if (param_1 == 1) {
      DAT_04000b36 = uVar9;
      (&DAT_04000b86)[iVar16] = 0;
      (&DAT_04000b87)[iVar16] = 0;
      bVar1 = (&DAT_04000a66)[iVar8 + 6];
      do {
        if ((bVar1 >> uVar6 & 1) != 0) {
          (&DAT_0400034c)[uVar6] = (&DAT_0400034c)[uVar6] + '\x01';
          (&DAT_04000b86)[iVar16] = (&DAT_04000b86)[iVar16] | (byte)(1 << uVar6);
        }
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 0xb);
      (&DAT_04000b87)[iVar16] = (&DAT_04000a66)[iVar8 + 8];
      uVar9 = (&DAT_04000a66)[iVar8 + 10];
      uVar2 = (&DAT_04000a66)[iVar8 + 0xc];
      (&DAT_04000b51)[iVar16] = uVar2;
      (&DAT_04000b52)[iVar16] = uVar9;
      (&DAT_04000b6b)[iVar15] = uVar2;
      (&DAT_04000b6c)[iVar15] = uVar9;
      uVar9 = 1;
    }
    else {
      bVar1 = (&DAT_04000a66)[iVar8 + 6];
      do {
        if (((bVar1 >> uVar6 & 1) != 0) &&
           ((cVar5 = (&DAT_0400034c)[uVar6], cVar5 == '\0' ||
            ((&DAT_0400034c)[uVar6] = cVar5 + -1, cVar5 == '\x01')))) {
          (&DAT_04000b86)[iVar16] = (&DAT_04000b86)[iVar16] & ~(byte)(1 << uVar6);
        }
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 0xb);
      (&DAT_04000b51)[iVar16] = 0;
      (&DAT_04000b52)[iVar16] = 0;
      uVar9 = 3;
    }
    (&DAT_04000b44)[param_2] = uVar9;
    break;
  case 0xe:
    iVar16 = param_2 * 2;
    if (param_1 == 1) {
      cVar5 = (&DAT_04000a66)[iVar8 + 6];
      DAT_04000bbb = uVar9;
      if (cVar5 == '\t') {
        (&DAT_04000c26)[param_2] = 1;
      }
      else if (cVar5 == '\n') {
        (&DAT_04000c26)[param_2] = 0xff;
      }
      else if (cVar5 == 'h') {
        (&DAT_04000c33)[param_2] = 0xff;
      }
      else if (cVar5 == 'i') {
        (&DAT_04000c33)[param_2] = 1;
      }
      else {
        DAT_04000c25 = DAT_04000c25 | (byte)(1 << (uint)(byte)(cVar5 - 1));
      }
      uVar9 = (&DAT_04000a66)[iVar8 + 8];
      uVar2 = (&DAT_04000a66)[iVar8 + 10];
      (&DAT_04000bd6)[iVar16] = uVar2;
      (&DAT_04000bd7)[iVar16] = uVar9;
      (&DAT_04000bf0)[iVar15] = uVar2;
      (&DAT_04000bf1)[iVar15] = uVar9;
      (&DAT_04000bc9)[param_2] = 1;
      DAT_04000c0a = DAT_04000c0a + '\x01';
    }
    else {
      cVar5 = (&DAT_04000a66)[iVar8 + 6];
      if ((cVar5 == '\t') || (cVar5 == '\n')) {
        (&DAT_04000c26)[param_2] = 0;
      }
      else if ((cVar5 == 'h') || (cVar5 == 'i')) {
        (&DAT_04000c33)[param_2] = 0;
      }
      else {
        DAT_04000c25 = DAT_04000c25 & ~(byte)(1 << (uint)(byte)(cVar5 - 1));
      }
      (&DAT_04000bd6)[iVar16] = 0;
      (&DAT_04000bd7)[iVar16] = 0;
      if ((DAT_04000c0a == '\0') ||
         (cVar5 = DAT_04000c0a + -1, bVar17 = DAT_04000c0a == '\x01', DAT_04000c0a = cVar5, bVar17))
      {
        (&DAT_04000bc9)[param_2] = 3;
      }
    }
    break;
  case 0xf:
    if (param_1 != 1) {
      return;
    }
    iVar15 = FUN_20005360(param_2);
    if (iVar15 != 0) {
      FUN_20007f20(param_2);
      return;
    }
    uVar7 = 0xf;
LAB_200090de:
    uVar3 = CONCAT11((&DAT_04000a66)[iVar8 + 6],(&DAT_04000a66)[iVar8 + 8]);
    uVar9 = 1;
LAB_200090ea:
    FUN_2000522c(uVar7,param_2,uVar3,uVar9);
    break;
  case 0x12:
    if ((&DAT_04000a66)[iVar8 + 6] != '\x01') {
      return;
    }
    if (param_1 != 1) {
      return;
    }
    iVar8 = FUN_2000c034(2,0,1);
    if (iVar8 == 0) {
      return;
    }
    DAT_0400036c = DAT_0400036c == '\0';
    (&DAT_04000d7a)[(uint)DAT_04000d74 * 6] = DAT_0400036c;
LAB_20009332:
    settings_mark_dirty(8,0);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class0F_led @ 200093e0 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000951c) */
/* WARNING: Removing unreachable block (ram,0x2000951c) */
/* class 0x0F: Chroma lighting effects */

void razer_cmd_class0F_led(void)

{
  byte bVar1;
  byte bVar2;
  uint uVar3;
  int iVar4;
  undefined4 uVar5;
  undefined4 in_r3;
  uint uVar6;
  byte *unaff_r6;
  bool bVar7;
  
  uVar6 = 0;
  bVar1 = g_razer_report.command_id & 0x7f;
  bVar2 = g_razer_report.args[0];
  if (bVar1 == 3) {
LAB_20009432:
    if (g_razer_report.args[1] == 0) {
      bVar1 = 4;
    }
    else {
      bVar1 = g_razer_report.args[1];
      if (((g_razer_report.args[1] != 1) && (g_razer_report.args[1] != 4)) &&
         (g_razer_report.args[1] != 10)) {
        g_razer_report.status = 3;
        return;
      }
    }
LAB_20009454:
    unaff_r6 = (byte *)FUN_20007908(bVar2,bVar1,g_razer_report.args[0],in_r3,in_r3);
  }
  else {
    if (bVar1 < 4) {
      if ((g_razer_report.command_id & 0x7f) != 0) {
        if (bVar1 == 1) goto LAB_20009420;
        if (bVar1 != 2) {
          g_razer_report.status = 5;
          return;
        }
        goto LAB_20009432;
      }
      bVar1 = 1;
      goto LAB_20009454;
    }
    if (bVar1 == 4) goto LAB_20009432;
    if (bVar1 == 5) {
LAB_20009420:
      if (((g_razer_report.args[0] != 1) && (g_razer_report.args[0] != 4)) &&
         (g_razer_report.args[0] != 10)) {
        g_razer_report.status = 3;
        return;
      }
      bVar2 = 1;
      bVar1 = g_razer_report.args[0];
      goto LAB_20009454;
    }
    if (bVar1 != 0x10) {
      g_razer_report.status = 5;
      return;
    }
  }
  bVar2 = g_razer_report.args[1];
  if (g_razer_report.command_id == 0x80) {
    g_razer_report.args[0xe] = 9;
    g_razer_report.args[0xd] = 1;
    g_razer_report.args[0xc] = 3;
    g_razer_report.args[0xb] = 0x19;
    g_razer_report.args[10] = 10;
    g_razer_report.args[9] = 1;
    g_razer_report.args[8] = 1;
    g_razer_report.args[7] = 3;
    g_razer_report.args[6] = 0x19;
    g_razer_report.args[5] = 1;
    g_razer_report.args[4] = 1;
    g_razer_report.args[3] = 1;
    g_razer_report.args[2] = 3;
    g_razer_report.args[1] = 0x19;
    g_razer_report.args[0] = 4;
    g_razer_report.data_size = 0xf;
    return;
  }
  if (0x80 < g_razer_report.command_id) {
    if (g_razer_report.command_id == 0x81) {
      if (((g_razer_report.args[0] == 4) || (g_razer_report.args[0] == 1)) ||
         (g_razer_report.args[0] == 10)) {
        g_razer_report.args[1] = 0;
        g_razer_report.args[2] = 1;
        g_razer_report.args[3] = 3;
        g_razer_report.args[4] = 4;
        g_razer_report.args[5] = 8;
        uVar6 = 6;
      }
      g_razer_report.data_size = (byte)uVar6;
      return;
    }
    if (g_razer_report.command_id == 0x82) {
      g_razer_report.data_size = 0xc;
      g_razer_report.args[0] = 0;
      g_razer_report.args[1] = *unaff_r6;
      g_razer_report.args[2] = unaff_r6[3];
      g_razer_report.args[3] = unaff_r6[0xf];
      g_razer_report.args[4] = unaff_r6[0xe];
      g_razer_report.args[5] = unaff_r6[5];
      g_razer_report.args[6] = unaff_r6[6];
      g_razer_report.args[7] = unaff_r6[7];
      g_razer_report.args[8] = unaff_r6[8];
      g_razer_report.args[9] = unaff_r6[10];
      g_razer_report.args[10] = unaff_r6[0xb];
      g_razer_report.args[0xb] = unaff_r6[0xc];
      return;
    }
    if (g_razer_report.command_id == 0x84) {
      if (g_razer_report.args[1] == 0) {
        g_razer_report.status = 3;
      }
      else {
        g_razer_report.args[2] = unaff_r6[4];
      }
      g_razer_report.data_size = 3;
      return;
    }
    bVar7 = g_razer_report.command_id == 0x85;
    if (bVar7) {
      g_razer_report.data_size = 5;
      g_razer_report.args[1] = (&DAT_040014f2)[(uint)unaff_r6[1] * 4];
      g_razer_report.args[2] = (&DAT_040014f3)[(uint)unaff_r6[1] * 4];
      g_razer_report.args[3] = (&DAT_040014f4)[(uint)unaff_r6[1] * 4];
      g_razer_report.args[4] = (&DAT_040014f5)[(uint)unaff_r6[1] * 4];
      return;
    }
LAB_2000947c:
    if (!bVar7) {
LAB_200097fe:
      g_razer_report.status = 5;
      return;
    }
    (&DAT_040014f2)[(uint)unaff_r6[1] * 4] = g_razer_report.args[1];
    (&DAT_04002d14)[(uint)unaff_r6[1] * 4] = bVar2;
    bVar2 = g_razer_report.args[2];
    (&DAT_040014f3)[(uint)unaff_r6[1] * 4] = g_razer_report.args[2];
    (&DAT_04002d15)[(uint)unaff_r6[1] * 4] = bVar2;
    bVar2 = g_razer_report.args[3];
    (&DAT_040014f4)[(uint)unaff_r6[1] * 4] = g_razer_report.args[3];
    (&DAT_04002d16)[(uint)unaff_r6[1] * 4] = bVar2;
    bVar2 = g_razer_report.args[4];
    (&DAT_040014f5)[(uint)unaff_r6[1] * 4] = g_razer_report.args[4];
    (&DAT_04002d17)[(uint)unaff_r6[1] * 4] = bVar2;
    g_razer_report.data_size = 5;
    bVar2 = 0;
    uVar5 = 1;
    goto LAB_200095d2;
  }
  if (g_razer_report.command_id == 2) {
    switch(g_razer_report.args[2]) {
    case 0:
    case 1:
    case 3:
    case 4:
    case 8:
      goto switchD_2000951c_caseD_0;
    default:
      goto LAB_200097fe;
    }
  }
  if (g_razer_report.command_id == 3) {
    if (((g_razer_report.args[2] == 0xfe) && (g_razer_report.args[3] == 0xfe)) &&
       (g_razer_report.args[4] == 0xfe)) {
      do {
        iVar4 = uVar6 * 4;
        (&DAT_04002df6)[iVar4] = 0;
        (&DAT_04002df7)[iVar4] = 0;
        uVar6 = uVar6 + 1 & 0xff;
        (&DAT_04002df8)[iVar4] = 0;
      } while (uVar6 < 0xb);
      return;
    }
    uVar3 = 5;
    do {
      iVar4 = uVar6 * 4;
      (&DAT_04002df6)[iVar4] = g_razer_report.args[uVar3];
      uVar3 = uVar3 + 1 & 0xff;
      (&DAT_04002df7)[iVar4] = g_razer_report.args[uVar3];
      uVar3 = uVar3 + 1 & 0xff;
      uVar6 = uVar6 + 1 & 0xff;
      (&DAT_04002df8)[iVar4] = g_razer_report.args[uVar3];
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar6 < 0xb);
    uVar6 = 0;
    do {
      iVar4 = uVar6 * 0x23;
      (&DAT_04002d8f)[iVar4] = 8;
      if (((uint)DAT_04000d3e << 0x1a) >> 0x1e == 3) {
        unaff_r6[iVar4 + 2] = 8;
        unaff_r6[iVar4 + 3] = 8;
      }
      uVar6 = uVar6 + 1 & 0xff;
    } while (uVar6 < 3);
    return;
  }
  if (g_razer_report.command_id != 4) {
    bVar7 = g_razer_report.command_id == 5;
    goto LAB_2000947c;
  }
  uVar3 = (uint)g_razer_report.args[0];
  if (uVar3 == 0) {
    if (g_razer_report.args[1] == 0) {
      do {
        iVar4 = uVar6 * 0x23;
        uVar6 = uVar6 + 1 & 0xff;
        (&DAT_04002d91)[iVar4] = g_razer_report.args[2];
      } while (uVar6 < 3);
    }
    else {
LAB_20009714:
      unaff_r6[4] = g_razer_report.args[2];
    }
  }
  else if (uVar3 == DAT_04000d73) {
    if (g_razer_report.args[1] == 0) {
      uVar3 = (uint)DAT_04000d74;
      do {
        iVar4 = uVar6 * 0x23;
        (&DAT_04000dba)[iVar4 + uVar3 * 0x164] = g_razer_report.args[2];
        uVar6 = uVar6 + 1 & 0xff;
        (&DAT_04002d91)[iVar4] = g_razer_report.args[2];
      } while (uVar6 < 3);
    }
    else {
      unaff_r6[4] = g_razer_report.args[2];
      (&DAT_04002d91)[(uint)unaff_r6[1] * 0x23] = g_razer_report.args[2];
    }
  }
  else {
    if (g_razer_report.args[1] != 0) goto LAB_20009714;
    do {
      iVar4 = uVar6 * 0x23;
      uVar6 = uVar6 + 1 & 0xff;
      (&DAT_04000c56)[iVar4 + uVar3 * 0x164] = g_razer_report.args[2];
    } while (uVar6 < 3);
  }
  if (g_razer_report.args[0] == 0) {
    return;
  }
LAB_2000971e:
  bVar2 = g_razer_report.args[0] - 1;
  goto LAB_20009722;
switchD_2000951c_caseD_0:
  uVar3 = (uint)g_razer_report.args[0];
  if (uVar3 == 0) {
    if (g_razer_report.args[1] == 0) {
      do {
        FUN_2000b810(&DAT_04002d8d + uVar6 * 0x23,0x4000cec);
        FUN_20005f80(&DAT_04002d8d + uVar6 * 0x23,g_razer_report.args[0]);
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 3);
      return;
    }
    FUN_2000b810(unaff_r6,0x4000cec);
    FUN_20005f80(unaff_r6,g_razer_report.args[0]);
    FUN_2000e0fc(unaff_r6);
    return;
  }
  if (DAT_04000d73 != uVar3) {
    if (g_razer_report.args[1] == 0) {
      do {
        FUN_20005834(uVar6);
        uVar6 = uVar6 + 1 & 0xff;
      } while (uVar6 < 3);
    }
    else {
      for (; ((&DAT_04000c52)[uVar3 * 0x164 + uVar6 * 0x23] != g_razer_report.args[1] && (uVar6 < 3)
             ); uVar6 = uVar6 + 1 & 0xff) {
      }
      FUN_20005834(uVar6);
    }
    goto LAB_2000971e;
  }
  if (g_razer_report.args[1] == 0) {
    uVar3 = (uint)DAT_04000d74;
    do {
      FUN_2000b810(&DAT_04000db6 + uVar6 * 0x23 + uVar3 * 0x164,0x4000cec);
      FUN_20005f80(&DAT_04000db6 + uVar6 * 0x23 + uVar3 * 0x164,g_razer_report.args[0]);
      uVar6 = uVar6 + 1 & 0xff;
      bVar2 = DAT_04000d74;
    } while (uVar6 < 3);
  }
  else {
    FUN_2000b810(unaff_r6,0x4000cec);
    FUN_20005f80(unaff_r6,g_razer_report.args[0]);
    FUN_2000e0fc(unaff_r6);
    bVar2 = DAT_04000d74;
  }
LAB_20009722:
  uVar5 = 0x40;
LAB_200095d2:
  settings_mark_dirty(uVar5,bVar2);
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class00_device @ 20009804 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */
/* class 0x00: version (0x87), serial (0x82), device mode (0x04 -> bootloader), factory reset
   (0x0B)... */

void razer_cmd_class00_device(void)

{
  byte bVar1;
  razer_report_t *prVar2;
  undefined4 uVar3;
  byte bVar4;
  undefined *puVar5;
  uint uVar6;
  uint uVar7;
  char cVar8;
  undefined *local_24;
  
  bVar1 = g_razer_report.args[1];
  bVar4 = g_razer_report.args[0];
  puVar5 = &DAT_040014c8;
  local_24 = &DAT_040014d6;
  uVar6 = (uint)DAT_04000d74;
  uVar7 = (uint)g_razer_report.args[0];
  prVar2 = (razer_report_t *)g_razer_report.args;
  if (g_razer_report.command_id == 0x81) {
    g_razer_report.args[1] = 2;
    g_razer_report.args[0] = 1;
    return;
  }
  if (0x81 < g_razer_report.command_id) {
    if (g_razer_report.command_id == 0x87) {
      g_razer_report.args[0] = 1;
      g_razer_report.args[1] = 2;
      g_razer_report.args[2] = 0;
      g_razer_report.args[3] = 0;
      return;
    }
    if (g_razer_report.command_id < 0x88) {
      if (g_razer_report.command_id == 0x82) {
        uVar6 = 0;
        do {
          prVar2->status = g_serial_number[uVar6];
          uVar6 = uVar6 + 1 & 0xff;
          prVar2 = (razer_report_t *)((int)prVar2 + 1);
        } while (uVar6 < 0x16);
        return;
      }
      if (g_razer_report.command_id == 0x84) {
        bVar4 = (byte)(((uint)DAT_04000d3e << 0x1a) >> 0x1e);
        goto LAB_20009a66;
      }
      if (g_razer_report.command_id == 0x85) {
        bVar4 = (&DAT_04000db5)[uVar6 * 0x164];
        goto LAB_20009a66;
      }
      if (g_razer_report.command_id == 0x86) {
        g_razer_report.args[0] = DAT_040014b0;
        g_razer_report.args[1] = DAT_040014b1;
        return;
      }
    }
    else {
      if (g_razer_report.command_id == 0x8d) {
        uVar3 = 4;
        puVar5 = &DAT_040014fe;
LAB_20009a8a:
        memcpy(prVar2,puVar5,uVar3);
        return;
      }
      if (g_razer_report.command_id == 0x8e) {
        if (uVar7 != 0) {
          g_razer_report.args[1] = (&DAT_04000c51)[uVar7 * 0x164];
          return;
        }
        g_razer_report.args[1] = DAT_04000c58;
        return;
      }
      bVar4 = DAT_04000d6e;
      if (g_razer_report.command_id == 0xb3) goto LAB_20009a66;
      if (g_razer_report.command_id == 0xbd) {
        if ((uVar7 != 0) && (puVar5 = local_24, uVar7 != 1)) {
          if (uVar7 != 2) {
            return;
          }
          puVar5 = &DAT_040014e4;
        }
        uVar3 = 0x14;
        prVar2 = (razer_report_t *)(g_razer_report.args + 1);
        goto LAB_20009a8a;
      }
    }
LAB_200098a8:
    prVar2 = &g_razer_report;
    bVar4 = 5;
LAB_20009a66:
    prVar2->status = bVar4;
    return;
  }
  if (g_razer_report.command_id == 0xb) {
    if (uVar7 != 0) {
      if (uVar7 == 1) {
        memcpy(&DAT_04000d66,&DAT_2000ea9a,0xb);
        settings_mark_dirty(2,0);
        memcpy(&DAT_04000d71,&DAT_2000eaa5,0x24);
        memcpy(&DAT_04000d95,&DAT_2000eac9,0x70b);
        settings_mark_dirty(0x20,0);
        cVar8 = '\x05';
        do {
          cVar8 = cVar8 + -1;
          settings_mark_dirty(0x40,cVar8);
        } while (cVar8 != '\0');
        FUN_2000577c(0);
        memcpy(&DAT_04000a66,&DAT_04000e40,0xd0);
        FUN_20006d48();
        FUN_2000cc38(_DAT_04000d76,_DAT_04000d78,0);
        FUN_2000c034(1,0);
        FUN_20006da0();
        __aeabi_memclr(&DAT_04001623,0x581);
        cVar8 = 'd';
        do {
          cVar8 = cVar8 + -1;
          settings_mark_dirty(0x80,cVar8);
        } while (cVar8 != '\0');
        return;
      }
      return;
    }
    disableIRQinterrupts();
LAB_20009a50:
    prVar2 = (razer_report_t *)NVIC_SystemReset();
LAB_20009a54:
    uVar3 = 4;
    puVar5 = &DAT_040014fe;
LAB_20009ac0:
    memcpy(puVar5,prVar2,uVar3);
    bVar4 = DAT_040014b0;
    bVar1 = DAT_040014b1;
  }
  else {
    if (0xb < g_razer_report.command_id) {
      if (g_razer_report.command_id == 0xd) goto LAB_20009a54;
      if (g_razer_report.command_id == 0xe) {
        if (uVar7 != 0) {
          (&DAT_04000c51)[uVar7 * 0x164] = g_razer_report.args[1];
        }
        if (((DAT_04000d73 == uVar7) || (uVar7 == 0)) && (DAT_04000c58 = bVar1, uVar7 == 0)) {
          return;
        }
        uVar6 = uVar7 - 1 & 0xff;
LAB_2000997e:
        uVar3 = 0x40;
        goto LAB_20009a72;
      }
      if (g_razer_report.command_id == 0x33) {
        uVar6 = 0;
        DAT_04000d6e = g_razer_report.args[0];
        uVar3 = 2;
        goto LAB_20009a72;
      }
      if (g_razer_report.command_id != 0x3d) goto LAB_200098a8;
      if (uVar7 == 0) {
        uVar3 = 0x14;
        prVar2 = (razer_report_t *)(g_razer_report.args + 1);
      }
      else if (uVar7 == 1) {
        prVar2 = (razer_report_t *)(g_razer_report.args + 1);
        uVar3 = 0x14;
        puVar5 = &DAT_040014d6;
      }
      else {
        bVar4 = DAT_040014b0;
        bVar1 = DAT_040014b1;
        if (uVar7 != 2) goto LAB_200098ea;
        uVar3 = 0x14;
        prVar2 = (razer_report_t *)(g_razer_report.args + 1);
        puVar5 = &DAT_040014e4;
      }
      goto LAB_20009ac0;
    }
    if (g_razer_report.command_id == 2) {
      uVar6 = 0;
      do {
        bVar4 = prVar2->status;
        uVar7 = uVar6 + 1 & 0xff;
        prVar2 = (razer_report_t *)((int)prVar2 + 1);
        g_serial_number[uVar6] = bVar4;
        uVar6 = uVar7;
        bVar4 = DAT_040014b0;
        bVar1 = DAT_040014b1;
      } while (uVar7 < 0x16);
    }
    else {
      if (g_razer_report.command_id == 4) {
        bVar1 = (byte)((uVar7 << 0x1e) >> 0x1a);
        bVar4 = DAT_04000d3e & 0xcf | bVar1;
        if (uVar7 == 0) {
          DAT_04000d3e = bVar4;
          return;
        }
        if (uVar7 != 1) {
          if (uVar7 == 2) {
            DAT_04000d3e = DAT_04000d3e & 0x8f | bVar1 |
                           (byte)(((uint)g_razer_report.args[1] << 0x1f) >> 0x19);
            return;
          }
          if (uVar7 != 3) {
            DAT_04000d3e = bVar4;
            return;
          }
          DAT_04000d3e = bVar4;
          FUN_2000df1c(3,1);
          uVar6 = (uint)DAT_04000d74;
          uVar3 = 0x20;
          goto LAB_20009a72;
        }
        g_bootloader_magic = 0xaaaaaaaa;
        DAT_04000d3e = bVar4;
        goto LAB_20009a50;
      }
      if (g_razer_report.command_id == 5) {
        (&DAT_04000db5)[uVar6 * 0x164] = g_razer_report.args[0];
        DAT_04000c58 = bVar4;
        goto LAB_2000997e;
      }
      bVar4 = g_razer_report.args[0];
      bVar1 = g_razer_report.args[1];
      if (g_razer_report.command_id != 6) goto LAB_200098a8;
    }
  }
LAB_200098ea:
  DAT_040014b1 = bVar1;
  DAT_040014b0 = bVar4;
  uVar6 = 0;
  uVar3 = 1;
LAB_20009a72:
  settings_mark_dirty(uVar3,uVar6);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20009b0c @ 20009b0c */


void FUN_20009b0c(void)

{
  if (DAT_0400037f != '\0') {
    return;
  }
  if (DAT_04000324 != '\x01') {
    return;
  }
  DAT_04000326 = DAT_04000326 + '\x01';
  if (DAT_04000326 != '\x01') {
    if (DAT_04000326 == '\x02') {
      DAT_0400035e = 0;
      goto LAB_20009b54;
    }
    if (DAT_04000326 != '\x03') {
      if (DAT_04000326 == '\x04') {
        DAT_0400035e = 0;
        DAT_04000324 = '\0';
        DAT_04000326 = '\0';
        DAT_04000325 = 0;
      }
      goto LAB_20009b54;
    }
  }
  DAT_0400035e = DAT_04000325;
LAB_20009b54:
  DAT_04000366 = DAT_04000366 | 1;
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class04_sensor @ 20009b70 */


/* class 0x04: DPI stages, sensor settings */

void razer_cmd_class04_sensor(void)

{
  byte bVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  int iVar5;
  uint uVar6;
  bool bVar7;
  
  uVar6 = (uint)g_razer_report.command_id;
  bVar1 = DAT_04000c59 + 1;
  uVar2 = (uint)g_razer_report.args[0];
  iVar4 = uVar2 * 6;
  iVar5 = (uint)(byte)(g_razer_report.args[1] - 1) * 6;
  uVar3 = 0;
  if (uVar6 == 0x80) {
    g_razer_report.args[0] = bVar1;
    return;
  }
  if (uVar6 < 0x81) {
    bVar7 = 6 < uVar6;
switchD_20009c4e_default:
    if (!bVar7) {
                    /* WARNING: Could not recover jumptable at 0x20009c30. Too many branches */
                    /* WARNING: Treating indirect jump as call */
      (*(code *)(&UNK_20009c34 + (uint)*(ushort *)(&DAT_20009c32 + uVar6 * 2) * 2))();
      return;
    }
    uVar2 = FUN_20009cb4(5);
    goto switchD_20009c4e_caseD_3;
  }
  uVar6 = uVar6 - 0x82;
  bVar7 = 4 < uVar6;
  switch(uVar6) {
  case 0:
    bVar1 = g_razer_report.args[0];
    if (uVar2 != 0) {
      bVar1 = g_razer_report.args[0] - 1;
    }
    if ((g_razer_report.args[1] == 0) || (DAT_04000c5a < g_razer_report.args[1])) {
      g_razer_report.status = 3;
    }
    else {
      if (uVar2 == 0) {
        g_razer_report.args[2] = (&DAT_04000c5c)[iVar5];
        g_razer_report.args[3] = (&DAT_04000c5b)[iVar5];
        g_razer_report.args[4] = (&DAT_04000c5e)[iVar5];
        g_razer_report.args[5] = (&DAT_04000c5d)[iVar5];
      }
      else {
        iVar5 = iVar5 + (uint)bVar1 * 0x164;
        g_razer_report.args[2] = (&DAT_04000d95)[iVar5 + 0x8c];
        g_razer_report.args[3] = (&DAT_04000d95)[iVar5 + 0x8b];
        g_razer_report.args[4] = (&DAT_04000d95)[iVar5 + 0x8e];
        g_razer_report.args[5] = (&DAT_04000d95)[iVar5 + 0x8d];
      }
      g_razer_report.args[6] = 0;
      g_razer_report.args[7] = 0;
    }
    break;
  case 1:
    if (uVar2 == 0) {
      g_razer_report.args[2] = 5;
      uVar2 = 3;
      g_razer_report.args[1] = bVar1;
      do {
        bVar1 = (char)uVar3 + 1;
        g_razer_report.args[uVar2] = bVar1;
        uVar2 = uVar2 + 1 & 0xff;
        iVar5 = uVar3 * 6;
        g_razer_report.args[uVar2] = (&DAT_04000c5c)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5b)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5e)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5d)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c60)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5f)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        uVar3 = (uint)bVar1;
      } while (uVar3 < 5);
    }
    else {
      g_razer_report.args[1] = (&DAT_04000d6f)[iVar4] + 1;
      g_razer_report.args[2] = 5;
      uVar2 = 3;
      do {
        bVar1 = (char)uVar3 + 1;
        g_razer_report.args[uVar2] = bVar1;
        iVar5 = uVar3 * 6;
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbd)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbc)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbf)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbe)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cc1)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cc0)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar3 = (uint)bVar1;
        uVar2 = uVar2 + 1 & 0xff;
      } while (uVar3 < 5);
    }
    break;
  case 2:
    g_razer_report.args[1] = bVar1;
    if (uVar2 != 0) {
      g_razer_report.args[1] = (&DAT_04000d6f)[iVar4] + 1;
    }
    break;
  case 3:
switchD_20009c4e_caseD_3:
    if (uVar2 == 0) {
      g_razer_report.args[1] = DAT_04000377;
      g_razer_report.args[2] = DAT_04000376;
      g_razer_report.args[3] = DAT_04000379;
      g_razer_report.args[4] = DAT_04000378;
    }
    else {
      g_razer_report.args[2] = (&DAT_04000d70)[(uint)g_razer_report.args[0] * 6];
      g_razer_report.args[3] = (&DAT_04000d73)[(uint)g_razer_report.args[0] * 6];
      g_razer_report.args[4] = (&DAT_04000d72)[(uint)g_razer_report.args[0] * 6];
      g_razer_report.args[1] = (&DAT_04000d71)[iVar4];
    }
    break;
  case 4:
    if (uVar2 == 0) {
      g_razer_report.args[2] = DAT_04000c5a;
      uVar2 = 3;
      g_razer_report.args[1] = bVar1;
      while (uVar3 < DAT_04000c5a) {
        bVar1 = (char)uVar3 + 1;
        g_razer_report.args[uVar2] = bVar1;
        uVar2 = uVar2 + 1 & 0xff;
        iVar5 = uVar3 * 6;
        g_razer_report.args[uVar2] = (&DAT_04000c5c)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5b)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5e)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5d)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c60)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000c5f)[iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        uVar3 = (uint)bVar1;
      }
    }
    else {
      g_razer_report.args[1] = (&DAT_04000d6f)[iVar4] + 1;
      g_razer_report.args[2] = (&DAT_04000cbb)[(uint)g_razer_report.args[0] * 0x164];
      uVar2 = 3;
      while (uVar3 < (byte)(&DAT_04000cbb)[(uint)g_razer_report.args[0] * 0x164]) {
        bVar1 = (char)uVar3 + 1;
        g_razer_report.args[uVar2] = bVar1;
        iVar5 = uVar3 * 6;
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbd)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbc)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbf)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cbe)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cc1)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        g_razer_report.args[uVar2] = (&DAT_04000cc0)[(uint)g_razer_report.args[0] * 0x164 + iVar5];
        uVar2 = uVar2 + 1 & 0xff;
        uVar3 = (uint)bVar1;
      }
    }
    break;
  default:
    goto switchD_20009c4e_default;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_20009cb4 @ 20009cb4 */


void FUN_20009cb4(byte param_1)

{
  g_razer_report.status = param_1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000a7a8 @ 2000a7a8 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000a7b8) */
/* WARNING: Removing unreachable block (ram,0x2000a7b8) */

void FUN_2000a7a8(void)

{
  char cVar1;
  char cVar2;
  
  switch(DAT_04000478) {
  case '\0':
    FUN_200084e0();
    return;
  case '\x01':
    cVar2 = '\x02';
    break;
  case '\x02':
    FUN_20001728(DAT_04000480);
    if (0x400 < DAT_04000484) {
      return;
    }
    FUN_200016fe(DAT_04000484,DAT_04000484,SystemCoreClock);
    DAT_04000478 = 3;
    return;
  case '\x03':
    cVar1 = FUN_200016b0(DAT_04000484);
    cVar2 = DAT_04000478;
    if (cVar1 == '\0') {
      cVar2 = '\x04';
    }
    break;
  case '\x04':
    FUN_20001728(DAT_04000480);
    FUN_200016d4(DAT_04000484 << 8,&DAT_04002b4c,0x100,SystemCoreClock);
    cVar2 = '\x05';
    break;
  case '\x05':
    cVar2 = FUN_2000168c(DAT_04000484 << 8,&DAT_04002b4c,0x100,SystemCoreClock);
    if (cVar2 != '\0') {
      return;
    }
    break;
  default:
    return;
  }
  DAT_04000478 = cVar2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000a83c @ 2000a83c */


void FUN_2000a83c(void)

{
  FUN_20005768();
  FUN_20007aa8();
  FUN_2000c260();
  FUN_2000e2e0();
  DAT_04002d68 = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class06_storage @ 2000a85c */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000a8a2) */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000a8d6) */
/* WARNING: Removing unreachable block (ram,0x2000a8a2) */
/* WARNING: Removing unreachable block (ram,0x2000a8d6) */
/* class 0x06: on-board storage / profile and macro memory */

void razer_cmd_class06_storage(void)

{
  byte bVar1;
  byte bVar2;
  byte bVar3;
  undefined2 uVar4;
  int iVar5;
  undefined4 uVar6;
  uint uVar7;
  uint uVar8;
  uint uVar9;
  bool bVar10;
  
  bVar3 = g_razer_report.args[6];
  bVar2 = g_razer_report.args[1];
  bVar1 = g_razer_report.data_size;
  uVar7 = (uint)g_razer_report.args[5];
  uVar8 = (uint)g_razer_report.args[3];
  uVar9 = (uint)CONCAT11(g_razer_report.args[1],g_razer_report.args[0]);
  if (g_razer_report.command_id == 0x84) {
    return;
  }
  if (g_razer_report.command_id < 0x85) {
    if (g_razer_report.command_id == 8) {
      uVar8 = read_u32_le(0x4000cee);
      iVar5 = FUN_2000d53c((uVar9 & 0xff) << 8 | (uint)bVar2,
                           uVar8 << 0x18 | (uVar8 >> 8 & 0xff) << 0x10 | (uVar8 >> 0x10 & 0xff) << 8
                           | uVar7);
      goto LAB_2000a93c;
    }
    if (g_razer_report.command_id < 9) {
      switch(g_razer_report.command_id) {
      case 2:
      case 4:
      case 5:
        return;
      case 3:
        iVar5 = FUN_20007b70((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1]);
        if (iVar5 != 1) {
          g_razer_report.status = 3;
          return;
        }
        return;
      case 7:
        FUN_2000d210(g_razer_report.args[0]);
        settings_mark_dirty(0x80,0);
        return;
      }
      goto switchD_2000a8a2_caseD_6;
    }
    if (g_razer_report.command_id != 0xc) {
      if (g_razer_report.command_id < 0xd) {
        if (g_razer_report.command_id == 9) {
          uVar8 = read_u32_le(0x4000cee);
          iVar5 = FUN_2000d020((uVar9 & 0xff) << 8 | (uint)bVar2,
                               uVar8 << 0x18 | (uVar8 >> 8 & 0xff) << 0x10 |
                               (uVar8 >> 0x10 & 0xff) << 8 | uVar7,0x4000cf3,bVar3);
          goto LAB_2000aa2e;
        }
        bVar10 = g_razer_report.command_id == 10;
      }
      else {
        if (g_razer_report.command_id == 0x80) {
          uVar4 = FUN_20007160();
          g_razer_report.args[0] = (byte)((ushort)uVar4 >> 8);
          g_razer_report.args[1] = (byte)uVar4;
          return;
        }
        bVar10 = g_razer_report.command_id == 0x81;
        if (bVar10) {
          return;
        }
      }
      if (bVar10) {
        if (g_razer_report.args[2] != 0) {
          return;
        }
        if (uVar8 != 0) {
          if (uVar8 == 1) {
            DAT_04000436 = 1;
            DAT_04000437 = 1;
            return;
          }
          if (uVar8 == 2) {
            __aeabi_memclr(&DAT_04001623,0x581);
            uVar7 = 100;
            while (bVar10 = uVar7 != 0, uVar7 = uVar7 - 1, bVar10) {
              settings_mark_dirty(0x80,uVar7 & 0xff);
            }
            FUN_20006da0();
          }
          else {
            if (uVar8 != 3) {
              return;
            }
            iVar5 = FUN_200055b0((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1]);
            if (iVar5 == 0) {
              DAT_04000436 = 3;
              return;
            }
          }
        }
        DAT_04000436 = 2;
        return;
      }
      goto switchD_2000a8a2_caseD_6;
    }
    iVar5 = FUN_2000d21c((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1],
                         g_razer_report.args._4_2_ << 8 | (ushort)g_razer_report.args._4_2_ >> 8,
                         (CONCAT11(g_razer_report.args[3],g_razer_report.args[2]) & 0xff) << 8 |
                         (uint)g_razer_report.args[3],0x4000cf2,g_razer_report.data_size - 6);
    goto LAB_2000aa2e;
  }
  switch(g_razer_report.command_id) {
  case 0x85:
  case 0x86:
    break;
  case 0x87:
    g_razer_report.args[0] = FUN_2000704c();
    break;
  case 0x88:
    iVar5 = FUN_20007170((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1],0x4000cee);
LAB_2000a93c:
    if (iVar5 == 0) {
      g_razer_report.status = 3;
      return;
    }
    return;
  case 0x89:
    uVar9 = (uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1];
    DAT_0400031c = (undefined2)uVar9;
    uVar8 = read_u32_le(0x4000cee);
    DAT_04000320 = uVar8 << 0x18 | (uVar8 >> 8 & 0xff) << 0x10 | (uVar8 >> 0x10 & 0xff) << 8 | uVar7
    ;
    DAT_0400031a = bVar3;
    iVar5 = FUN_20006ed4(uVar9,DAT_04000320,0x4000cf3);
    goto LAB_2000aa2e;
  case 0x8a:
    g_razer_report.args[2] = DAT_04000436;
    break;
  case 0x8b:
    FUN_20006fd4((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1],0x4000cee,0x4000cf0,
                 g_razer_report.data_size - 4);
    break;
  case 0x8c:
    iVar5 = FUN_20007058((uVar9 & 0xff) << 8 | (uint)g_razer_report.args[1],0x4000cf0,
                         (CONCAT11(g_razer_report.args[3],g_razer_report.args[2]) & 0xff) << 8 |
                         (uint)g_razer_report.args[3],0x4000cf2,g_razer_report.data_size - 6);
LAB_2000aa2e:
    if (iVar5 == 0) {
      g_razer_report.status = 3;
      DAT_04000472 = 0;
    }
    else if (iVar5 == 2) {
      DAT_04000472 = 1;
    }
    break;
  case 0x8d:
    uVar7 = read_u32_le(0x4000cec);
    FUN_2000130c(uVar7 << 0x18 | (uVar7 >> 8 & 0xff) << 0x10 | (uVar7 >> 0x10 & 0xff) << 8 | uVar8,
                 0x4000cf0,bVar1 - 4);
    break;
  case 0x8e:
    uVar4 = FUN_200071f8();
    g_razer_report.args[0] = (byte)((ushort)uVar4 >> 8);
    g_razer_report.args[1] = (byte)uVar4;
    uVar6 = FUN_200071fc();
    g_razer_report.args[2] = (byte)((uint)uVar6 >> 0x18);
    g_razer_report.args[3] = (byte)((uint)uVar6 >> 0x10);
    g_razer_report.args[5] = (byte)uVar6;
    g_razer_report.args[4] = (byte)((uint)uVar6 >> 8);
    uVar6 = FUN_20006dee();
    g_razer_report.args[6] = (byte)((uint)uVar6 >> 0x18);
    g_razer_report.args[7] = (byte)((uint)uVar6 >> 0x10);
    g_razer_report.args[8] = (byte)((uint)uVar6 >> 8);
    g_razer_report.args[9] = (byte)uVar6;
    uVar6 = FUN_200072cc();
    g_razer_report.args[10] = (byte)((uint)uVar6 >> 0x18);
    g_razer_report.args[0xb] = (byte)((uint)uVar6 >> 0x10);
    g_razer_report.args[0xc] = (byte)((uint)uVar6 >> 8);
    g_razer_report.args[0xd] = (byte)uVar6;
    break;
  default:
switchD_2000a8a2_caseD_6:
    g_razer_report.status = 5;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000aab8 @ 2000aab8 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_2000aab8(void)

{
  undefined1 uVar1;
  undefined2 uVar2;
  undefined1 *puVar3;
  int iVar4;
  byte bVar5;
  ushort uVar6;
  int iVar7;
  undefined4 in_r3;
  uint uVar8;
  bool bVar9;
  
  if ((DAT_0400037f == '\0') && ((DAT_04000430 & 8) != 0 || (DAT_04000366 & 7) != 0)) {
    DAT_04000382 = (ushort)(DAT_0400046c | DAT_0400036f) |
                   DAT_0400032f & 0x7f | (ushort)DAT_0400035e;
    DAT_04000385 = DAT_0400046d + DAT_04000370 + DAT_04000358;
    DAT_04000384 = DAT_04000371 + DAT_04000359;
    iVar7 = ((int)((uint)DAT_0400046e._1_1_ << 0x18) >> 0x10 | (uint)(byte)DAT_0400046e) +
            (uint)DAT_04000362;
    uVar8 = (int)((uint)DAT_04000470._1_1_ << 0x18) >> 0x10 | (uint)(byte)DAT_04000470;
    DAT_04000386 = (undefined1)iVar7;
    iVar4 = uVar8 + DAT_04000364;
    DAT_04000387 = (undefined1)((uint)iVar7 >> 8);
    DAT_04000388 = (undefined1)iVar4;
    DAT_04000389 = (undefined1)((uint)iVar4 >> 8);
    DAT_04000359 = '\0';
    DAT_04000358 = '\0';
    __aeabi_memclr(&DAT_0400046c,6,iVar7 >> 8,uVar8,in_r3);
    __aeabi_memclr(&DAT_0400036f,3);
    iVar4 = FUN_20003778(DAT_040009e4,1,&DAT_04000382,8);
    if (iVar4 == 0) {
      DAT_04000430 = DAT_04000430 & 0xf7;
      DAT_04000366 = DAT_04000366 & 0xfff8;
      DAT_04000364 = 0;
      DAT_04000362 = 0;
      DAT_0400037f = '\x01';
      DAT_0400037b = 2;
    }
  }
  bVar9 = DAT_04000380 == '\0';
  do {
    if (!bVar9) goto LAB_2000ad06;
    uVar8 = (uint)DAT_04000430;
    if ((uVar8 << 0x1d) >> 0x1e == 0) {
      uVar8 = (uint)DAT_04000366;
      if ((uVar8 << 0x17) >> 0x1b == 0) goto LAB_2000ad06;
      if ((int)(uVar8 << 0x18) < 0) {
        DAT_04000cb9 = 5;
        DAT_04000cba = DAT_04000d40;
        uVar1 = DAT_04000d3f;
        if (DAT_04000d40 == '\x01') {
LAB_2000ac5a:
          uVar2 = 0;
          DAT_04000cbc = 0;
          DAT_04000cbd = 0;
          DAT_04000cbb = uVar1;
LAB_2000ac26:
          DAT_04000cbe = (undefined1)uVar2;
        }
        else {
          if (DAT_04000d40 == '\x02') {
            if (DAT_04000328 == '\x01') {
              DAT_04000cbb = DAT_04000341;
              DAT_04000cbc = DAT_04000340;
              uVar2 = CONCAT11(DAT_04000343,DAT_04000342);
            }
            else {
              DAT_04000cbb = (undefined1)((ushort)_DAT_04000376 >> 8);
              DAT_04000cbc = (undefined1)_DAT_04000376;
              uVar2 = _DAT_04000378;
            }
            DAT_04000cbd = (undefined1)((ushort)uVar2 >> 8);
            goto LAB_2000ac26;
          }
          if ((DAT_04000d40 == '\n') || (uVar1 = DAT_0400036c, DAT_04000d40 == '9'))
          goto LAB_2000ac5a;
        }
        iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04000cb9,0x10);
        if (iVar4 == 0) {
          DAT_04000366 = DAT_04000366 & 0xff7f;
          DAT_04000380 = '\x01';
          DAT_0400037c = 2;
        }
        puVar3 = &DAT_04000cb9;
      }
      else if ((int)(uVar8 << 0x19) < 0) {
        FUN_20006e4c();
        puVar3 = &DAT_04000ca9;
        iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04000ca9,0x10);
        if (iVar4 == 0) {
          uVar6 = 0x40;
LAB_2000acc2:
          DAT_04000366 = DAT_04000366 & ~uVar6;
          DAT_04000380 = '\x01';
          DAT_0400037c = 2;
        }
      }
      else if ((int)(uVar8 << 0x1b) < 0) {
        puVar3 = &DAT_04000c89;
        iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04000c89,0x10);
        if (iVar4 == 0) {
          uVar6 = 0x10;
          goto LAB_2000acc2;
        }
      }
      else {
        if (-1 < (int)(uVar8 << 0x1a)) goto LAB_2000ad06;
        puVar3 = &DAT_04000c99;
        iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04000c99,0x10);
        if (iVar4 == 0) {
          DAT_04000366 = DAT_04000366 & 0xffdf;
          DAT_04000380 = '\x01';
          DAT_0400037c = 2;
        }
      }
      __aeabi_memclr(puVar3,0x10);
      goto LAB_2000ad06;
    }
    if (-1 < (int)(uVar8 << 0x1d)) {
      if ((-1 < (int)(uVar8 << 0x1e)) ||
         (iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04002130,0x10), iVar4 != 0)) goto LAB_2000ad06;
      bVar5 = 0xfd;
      goto LAB_2000abca;
    }
    iVar4 = FUN_20003778(DAT_040009e8,2,&DAT_04002120,0x10);
    bVar9 = iVar4 == 0;
  } while (!bVar9);
  bVar5 = 0xfb;
LAB_2000abca:
  DAT_04000430 = DAT_04000430 & bVar5;
  DAT_04000380 = '\x01';
  DAT_0400037c = 2;
LAB_2000ad06:
  if ((DAT_04000381 == '\0') && ((DAT_04000430 & 1) != 0 || (DAT_04000366 & 8) != 0)) {
    FUN_20006800(&DAT_0400038a,7);
    iVar4 = FUN_20003778(DAT_040009ec,3,&DAT_0400038a,8);
    if (iVar4 == 0) {
      DAT_04000430 = DAT_04000430 & 0xfe;
      DAT_04000366 = DAT_04000366 & 0xfff7;
      DAT_04000381 = '\x01';
      DAT_0400037d = 2;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* periodic_tasks @ 2000ad88 */


/* flag-driven task runner (flags @0x04000D65); bit1 -> razer_cmd_dispatch() and friends */

void periodic_tasks(void)

{
  if ((int)((uint)DAT_04000d65 << 0x1e) < 0) {
    FUN_2000a83c();
    FUN_2000d8c4(2);
    FUN_2000b778();
    FUN_20007c74();
    razer_cmd_dispatch();
    FUN_2000b58c();
    FUN_2000a7a8();
    DAT_04000d65 = DAT_04000d65 & 0xfd;
  }
  if ((DAT_04000d65 & 1) != 0) {
    FUN_2000cd7c();
  }
  FUN_2000c0d0(&DAT_0400036c,&DAT_04000398);
  if ((int)((uint)DAT_04000d65 << 0x1d) < 0) {
    FUN_2000b924();
    FUN_2000c2e4();
  }
  if ((int)((uint)DAT_04000d65 << 0x1b) < 0) {
    FUN_2000bbb0(&DAT_0400036c,&DAT_04000398);
    FUN_2000aed4();
    DAT_04000d65 = DAT_04000d65 & 0xef;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_dispatch @ 2000ae00 */


/* verify CRC, dispatch on command_class, recompute CRC, set status */

void razer_cmd_dispatch(void)

{
  uint uVar1;
  byte bVar2;
  
  if (-1 < (int)((uint)DAT_04000d48 << 0x1c)) {
    return;
  }
  uVar1 = 2;
  bVar2 = 0;
  do {
    bVar2 = bVar2 ^ g_razer_report.remaining_packets[uVar1 - 2];
    uVar1 = uVar1 + 1 & 0xff;
  } while (uVar1 < 0x59);
  if (bVar2 != 0) {
    g_razer_report.status = 3;
    goto LAB_2000aebe;
  }
  g_razer_report.status = 1;
  if (g_razer_report.command_class == 6) {
    razer_cmd_class06_storage();
  }
  else if (g_razer_report.command_class < 7) {
    if (g_razer_report.command_class == 0) {
      razer_cmd_class00_device();
    }
    else if (g_razer_report.command_class == 2) {
      razer_cmd_class02_keymap();
    }
    else if (g_razer_report.command_class == 4) {
      razer_cmd_class04_sensor();
    }
    else {
      if (g_razer_report.command_class != 5) goto LAB_2000ae4e;
      razer_cmd_class05();
    }
  }
  else if (g_razer_report.command_class == 0xb) {
    razer_cmd_class0B();
  }
  else if (g_razer_report.command_class == 0xf) {
    razer_cmd_class0F_led();
  }
  else if (g_razer_report.command_class == 0xfe) {
    razer_cmd_classFE();
  }
  else {
LAB_2000ae4e:
    g_razer_report.status = 5;
  }
  uVar1 = 2;
  g_razer_report.crc = 0;
  do {
    g_razer_report.crc = g_razer_report.crc ^ g_razer_report.remaining_packets[uVar1 - 2];
    uVar1 = uVar1 + 1 & 0xff;
  } while (uVar1 < 0x58);
  if (DAT_04000472 == '\0') {
    if (g_razer_report.status == 1) {
      g_razer_report.status = 2;
    }
  }
  else {
    DAT_04000472 = '\0';
    g_razer_report.status = 1;
  }
LAB_2000aebe:
  DAT_04000d48 = DAT_04000d48 & 0xf7;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000aed4 @ 2000aed4 */


void FUN_2000aed4(void)

{
  FUN_20009b0c();
  FUN_2000b364();
  FUN_2000b330();
  FUN_2000aab8();
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class05 @ 2000aee8 */


/* class 0x05 */

void razer_cmd_class05(void)

{
  uint uVar1;
  int iVar2;
  uint uVar3;
  
  if (g_razer_report.command_id == 0x80) {
    g_razer_report.args[0] = FUN_200072a8();
    return;
  }
  if (0x80 < g_razer_report.command_id) {
    if (g_razer_report.command_id == 0x81) {
      g_razer_report.args[0] = 5;
      uVar1 = 0;
      uVar3 = 1;
      do {
        if ((DAT_04000d99 >> uVar1 & 1) != 0) {
          g_razer_report.args[uVar3] = (byte)uVar1;
          uVar3 = uVar3 + 1 & 0xff;
        }
        uVar1 = uVar1 + 1 & 0xff;
      } while (uVar1 < 8);
      g_razer_report.data_size = (byte)uVar3;
      return;
    }
    if (g_razer_report.command_id == 0x84) {
      g_razer_report.args[0] = DAT_04000d73;
      return;
    }
    if (g_razer_report.command_id != 0x88) {
      if (g_razer_report.command_id == 0x8a) {
        g_razer_report.args[0] = 5;
        return;
      }
      g_razer_report.status = 5;
      return;
    }
    iVar2 = FUN_20007204(g_razer_report.args[0],0x4000cef,
                         ((ushort)g_razer_report.args._1_2_ & 0xff) << 8 |
                         (uint)((ushort)g_razer_report.args._1_2_ >> 8),0x4000cf1,
                         g_razer_report.data_size - 5);
LAB_2000afd8:
    if (iVar2 == 0) {
      g_razer_report.status = 3;
      DAT_04000472 = 0;
      return;
    }
    if (iVar2 != 2) {
      return;
    }
    DAT_04000472 = 1;
    return;
  }
  if (g_razer_report.command_id == 2) {
    iVar2 = FUN_20008268();
  }
  else {
    if (g_razer_report.command_id != 3) {
      if (g_razer_report.command_id != 4) {
        if (g_razer_report.command_id != 8) {
          g_razer_report.status = 5;
          return;
        }
        iVar2 = FUN_2000d5f0(g_razer_report.args[0],
                             g_razer_report.args._3_2_ << 8 | (ushort)g_razer_report.args._3_2_ >> 8
                             ,((ushort)g_razer_report.args._1_2_ & 0xff) << 8 |
                              (uint)((ushort)g_razer_report.args._1_2_ >> 8),0x4000cf1,
                             g_razer_report.data_size - 5);
        goto LAB_2000afd8;
      }
      if (g_razer_report.args[0] == 0) {
        g_razer_report.status = 3;
        return;
      }
      if (DAT_04000d73 == g_razer_report.args[0]) {
        return;
      }
      iVar2 = FUN_2000df1c(3);
      if (iVar2 == 0) {
        g_razer_report.status = 3;
        return;
      }
      goto LAB_2000afa0;
    }
    iVar2 = FUN_200062ac();
  }
  if (iVar2 == 0) {
    g_razer_report.status = 3;
    return;
  }
  settings_mark_dirty(0x40,DAT_04000d74);
LAB_2000afa0:
  settings_mark_dirty(0x20,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_class0B @ 2000aff8 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000b042) */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000b164) */
/* WARNING: Removing unreachable block (ram,0x2000b042) */
/* WARNING: Removing unreachable block (ram,0x2000b164) */
/* class 0x0B: sensor calibration / lift-off */

void razer_cmd_class0B(void)

{
  undefined4 uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar2 = 0x4000cec;
  uVar3 = (uint)DAT_04000d5d;
  if (g_razer_report.command_id == 0x80) {
    g_razer_report.args[0] = 1;
    g_razer_report.args[1] = 4;
    return;
  }
  if (g_razer_report.command_id < 0x81) {
    uVar2 = (uint)g_razer_report.args[3];
    switch(g_razer_report.command_id) {
    case 3:
      if (g_razer_report.args[1] == 4) {
        if (g_razer_report.args[2] == 1) {
          DAT_04000d5d = DAT_04000d5d & 0xf7 | 8;
          DAT_04000d64 = 0;
          return;
        }
        if (g_razer_report.args[2] != 0) {
          return;
        }
        DAT_04000d5e = 0;
        DAT_04000d64 = 1;
        return;
      }
      goto LAB_2000b07e;
    default:
switchD_2000b042_caseD_4:
      g_razer_report.status = 5;
      return;
    case 5:
      DAT_0400056d = g_razer_report.args[2];
      DAT_0400056e = g_razer_report.args[3];
      DAT_0400056f = g_razer_report.args[4];
      DAT_04000570 = g_razer_report.args[5];
      DAT_04000571 = g_razer_report.args[6];
      DAT_04000572 = g_razer_report.args[7];
      DAT_04000573 = g_razer_report.args[8];
      DAT_04000574 = g_razer_report.args[9];
      if (((int)(uVar3 << 0x1c) < 0) && (g_razer_report.args[1] == 4)) {
        DAT_04000d5e = 2;
        FUN_2000c460();
        return;
      }
      break;
    case 9:
      if ((DAT_04000d73 == g_razer_report.args[0]) || (g_razer_report.args[0] == 0)) {
        if (g_razer_report.args[1] != 4) {
          return;
        }
        if (g_razer_report.args[2] != 0) {
          return;
        }
        if (uVar2 == 0) {
          DAT_0400056d = 0;
          DAT_0400056e = 0;
          DAT_0400056f = 0;
          DAT_04000570 = 0;
          DAT_04000571 = 0;
          DAT_04000572 = 0;
          DAT_04000573 = 0;
          DAT_04000574 = 0;
          DAT_04000d5e = 1;
          return;
        }
        if (uVar2 != 1) {
          return;
        }
        DAT_04000d5e = 9;
        return;
      }
      break;
    case 0xb:
      if (((DAT_04000d73 == g_razer_report.args[0]) || (g_razer_report.args[0] == 0)) &&
         (g_razer_report.args[1] == 4)) {
        DAT_04000318 = g_razer_report.args[2];
        DAT_04000319 = g_razer_report.args[3];
        switch(g_razer_report.args[2]) {
        default:
          goto switchD_2000b042_caseD_4;
        case 1:
          uVar1 = 0;
          break;
        case 2:
          uVar1 = 1;
          break;
        case 3:
        case 4:
        case 5:
        case 6:
          return;
        }
        FUN_2000c574(uVar1);
        return;
      }
      break;
    case 0xc:
      DAT_04000568 = g_razer_report.args[2];
      DAT_04000569 = g_razer_report.args[3];
      DAT_0400056a = g_razer_report.args[4];
      DAT_0400056b = g_razer_report.args[5];
      DAT_0400056c = g_razer_report.args[6];
      if (((int)(uVar3 << 0x1c) < 0) && (g_razer_report.args[1] == 4)) {
        DAT_04000d5e = 2;
        FUN_2000c5b0();
        return;
      }
      break;
    case 0xd:
      DAT_04000575 = g_razer_report.args[2];
      DAT_04000576 = g_razer_report.args[3];
      DAT_04000577 = g_razer_report.args[4];
      DAT_04000578 = g_razer_report.args[5];
      DAT_04000579 = g_razer_report.args[6];
      DAT_0400057a = g_razer_report.args[7];
      DAT_0400057b = g_razer_report.args[8];
      DAT_0400057c = g_razer_report.args[9];
      if (((int)(uVar3 << 0x1c) < 0) && (g_razer_report.args[1] == 4)) {
        DAT_04000d5e = 2;
        FUN_2000cdbc();
        return;
      }
    }
  }
  else {
    if (g_razer_report.command_id == 0x8c) {
      if (g_razer_report.args[1] == 4) {
        g_razer_report.args[2] = DAT_04000568;
        g_razer_report.args[3] = DAT_04000569;
        g_razer_report.args[4] = DAT_0400056a;
        g_razer_report.args[5] = DAT_0400056b;
        g_razer_report.args[6] = DAT_0400056c;
        return;
      }
      g_razer_report.status = 3;
      return;
    }
    if (0x8c < g_razer_report.command_id) {
      if (g_razer_report.command_id == 0x8d) {
        if (g_razer_report.args[1] != 4) {
          return;
        }
        g_razer_report.args[2] = DAT_04000575;
        g_razer_report.args[3] = DAT_04000576;
        g_razer_report.args[4] = DAT_04000577;
        g_razer_report.args[5] = DAT_04000578;
        g_razer_report.args[6] = DAT_04000579;
        g_razer_report.args[7] = DAT_0400057a;
        g_razer_report.args[8] = DAT_0400057b;
        g_razer_report.args[9] = DAT_0400057c;
        return;
      }
      if (g_razer_report.command_id != 0x8e) {
        g_razer_report.status = 5;
        return;
      }
      g_razer_report.args[0] = 4;
      g_razer_report.args[1] = 0;
      g_razer_report.args[2] = 0;
      g_razer_report.args[3] = 0;
      g_razer_report.args[4] = 0x52;
      g_razer_report.args[5] = 0x10;
      return;
    }
    if (g_razer_report.command_id != 0x83) {
      if (g_razer_report.command_id == 0x85) {
        g_razer_report.args[2] = DAT_04000588;
        g_razer_report.args[3] = DAT_04000589;
        g_razer_report.args[4] = DAT_0400058a;
        g_razer_report.args[5] = DAT_0400058b;
        g_razer_report.args[6] = 0;
        g_razer_report.args[7] = 0;
        g_razer_report.args[8] = 0;
        g_razer_report.args[9] = 0;
        g_razer_report.args[10] = 0;
        return;
      }
      if (g_razer_report.command_id == 0x8b) {
        if (g_razer_report.args[1] == 4) {
          g_razer_report.args[2] = DAT_04000318;
          g_razer_report.args[3] = DAT_04000319;
          return;
        }
        g_razer_report.status = 3;
        return;
      }
      g_razer_report.status = 5;
      return;
    }
LAB_2000b07e:
    if (g_razer_report.args[1] == 4) {
      *(byte *)(uVar2 + 2) = (byte)((uVar3 << 0x1c) >> 0x1f);
      DAT_04000d5e = 0;
      return;
    }
  }
  g_razer_report.status = 3;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b278 @ 2000b278 */


void FUN_2000b278(int param_1,int param_2)

{
  int iVar1;
  int extraout_r1;
  
  if ((((((uint)DAT_04000d3e << 0x1a) >> 0x1e != 3) && ((&DAT_04000a68)[param_2 * 0x10] == '\x12'))
      && ((&DAT_04000a6c)[param_2 * 0x10] == '\x01')) &&
     (((param_1 == 1 && (iVar1 = FUN_2000c034(2,0), iVar1 != 0)) && (DAT_04000d6d == '\x01')))) {
    __aeabi_uidiv(DAT_0400032e + 1,3);
    DAT_0400032e = (byte)extraout_r1;
    if (extraout_r1 == 0) {
      DAT_0400036c = 0;
    }
    else {
      if (extraout_r1 != 1) {
        if (extraout_r1 != 2) {
          return;
        }
        DAT_0400036c = 0;
        DAT_0400036e = 1;
        return;
      }
      DAT_0400036c = 1;
    }
    DAT_0400036e = 0;
    return;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b2f8 @ 2000b2f8 */


void FUN_2000b2f8(void)

{
  wdt_feed();
  FUN_2000b924();
  FUN_2000c2e4();
  FUN_2000c0d0(&DAT_0400036c,&DAT_04000398);
  FUN_2000bbb0(&DAT_0400036c,&DAT_04000398);
  FUN_2000b58c();
  FUN_2000a7a8();
  FUN_2000a83c();
  FUN_2000b778();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b330 @ 2000b330 */


void FUN_2000b330(void)

{
  if ((DAT_04000372._1_1_ != '\0') && ((char)DAT_04000372 == '\0')) {
    button_action_execute(0,0xb);
    DAT_04000372._1_1_ = '\0';
  }
  if ((DAT_04000374._1_1_ != '\0') && ((char)DAT_04000374 == '\0')) {
    button_action_execute(0,0xc);
    DAT_04000374._1_1_ = '\0';
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b364 @ 2000b364 */


void FUN_2000b364(void)

{
  char cVar1;
  char cVar2;
  uint uVar3;
  undefined1 uVar4;
  uint uVar5;
  int iVar6;
  
  cVar2 = DAT_04000381;
  uVar3 = 0;
  do {
    if (cVar2 == '\0') {
      cVar1 = (&DAT_04000b44)[uVar3];
      if (cVar1 == '\x01') {
        iVar6 = uVar3 * 2;
        if ((*(ushort *)(&DAT_04000b51 + iVar6) <= *(ushort *)(&DAT_04000b6b + iVar6)) &&
           (*(ushort *)(&DAT_04000b51 + iVar6) != 0)) {
          DAT_04000c50 = DAT_04000c50 | (&DAT_04000b86)[iVar6];
          uVar5 = 2;
          do {
            if ((&DAT_04000c50)[uVar5] == (&DAT_04000b87)[iVar6]) break;
            if ((&DAT_04000c50)[uVar5] == '\0') {
              (&DAT_04000c50)[uVar5] = (&DAT_04000b87)[iVar6];
              break;
            }
            uVar5 = uVar5 + 1 & 0xff;
          } while (uVar5 < 8);
          (&DAT_04000b6b)[iVar6] = 0;
          (&DAT_04000b6c)[iVar6] = 0;
          (&DAT_04000b37)[uVar3] = 1;
          uVar4 = 2;
LAB_2000b420:
          (&DAT_04000b44)[uVar3] = uVar4;
LAB_2000b422:
          DAT_04000366 = DAT_04000366 | 8;
        }
      }
      else if (cVar1 == '\x02') {
        if ((&DAT_04000b37)[uVar3] != '\0') {
          DAT_04000c50 = DAT_04000c50 & ~(&DAT_04000b86)[uVar3 * 2];
          uVar5 = 2;
          do {
            if ((&DAT_04000c50)[uVar5] == (&DAT_04000b87)[uVar3 * 2]) {
              (&DAT_04000c50)[uVar5] = 0;
              break;
            }
            uVar5 = uVar5 + 1 & 0xff;
          } while (uVar5 < 8);
          (&DAT_04000b37)[uVar3] = 0;
          uVar4 = 1;
          goto LAB_2000b420;
        }
      }
      else if (cVar1 == '\x03') {
        if ((&DAT_04000b37)[uVar3] != '\0') {
          DAT_04000c50 = DAT_04000c50 & ~(&DAT_04000b86)[uVar3 * 2];
          uVar5 = 2;
          do {
            if ((&DAT_04000c50)[uVar5] == (&DAT_04000b87)[uVar3 * 2]) {
              (&DAT_04000c50)[uVar5] = 0;
              break;
            }
            uVar5 = uVar5 + 1 & 0xff;
          } while (uVar5 < 8);
          (&DAT_04000b37)[uVar3] = 0;
          (&DAT_04000b44)[uVar3] = 0;
          goto LAB_2000b422;
        }
        (&DAT_04000b44)[uVar3] = 0;
      }
    }
    if (DAT_0400037f == '\0') {
      cVar1 = (&DAT_04000bc9)[uVar3];
      if (cVar1 == '\x01') {
        iVar6 = uVar3 * 2;
        if ((*(ushort *)(&DAT_04000bd6 + iVar6) <= *(ushort *)(&DAT_04000bf0 + iVar6)) &&
           (*(ushort *)(&DAT_04000bd6 + iVar6) != 0)) {
          (&DAT_04000bf0)[iVar6] = 0;
          (&DAT_04000bf1)[iVar6] = 0;
          DAT_0400036f = DAT_04000c25;
          DAT_04000370 = (&DAT_04000c26)[uVar3];
          DAT_04000371 = (&DAT_04000c33)[uVar3];
          (&DAT_04000bc9)[uVar3] = 2;
          (&DAT_04000bbc)[uVar3] = 1;
          (&DAT_04000bf0)[iVar6] = 0;
          (&DAT_04000bf1)[iVar6] = 0;
LAB_2000b4f4:
          DAT_04000366 = DAT_04000366 | 1;
        }
      }
      else if (cVar1 == '\x02') {
        if ((&DAT_04000bbc)[uVar3] != '\0') {
          DAT_0400036f = 0;
          DAT_04000370 = 0;
          DAT_04000371 = 0;
          (&DAT_04000bbc)[uVar3] = 0;
          (&DAT_04000bc9)[uVar3] = 1;
          goto LAB_2000b4f4;
        }
      }
      else if (cVar1 == '\x03') {
        if ((&DAT_04000bbc)[uVar3] != '\0') {
          DAT_0400036f = 0;
          DAT_04000370 = 0;
          DAT_04000371 = 0;
          (&DAT_04000bc9)[uVar3] = 0;
          goto LAB_2000b4f4;
        }
        (&DAT_04000bc9)[uVar3] = 0;
      }
    }
    uVar3 = uVar3 + 1 & 0xff;
    if (0xc < uVar3) {
      return;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* razer_cmd_classFE @ 2000b52c */


/* class 0xFE: factory / diagnostic */

uint razer_cmd_classFE(void)

{
  undefined2 uVar1;
  uint uVar2;
  int iVar3;
  undefined4 extraout_r1;
  undefined4 uVar4;
  uint uVar5;
  undefined4 extraout_r2;
  undefined4 extraout_r3;
  uint unaff_r5;
  undefined4 uVar6;
  undefined4 uVar7;
  
  if (g_razer_report.command_id != 0x32) {
    if (g_razer_report.command_id == 0xb1) {
      g_razer_report.args[0] = (byte)DAT_04000564;
      g_razer_report.args[1] = (byte)((uint)DAT_04000564 >> 8);
      g_razer_report.args[2] = (byte)((uint)DAT_04000564 >> 0x10);
      g_razer_report.args[3] = (byte)((uint)DAT_04000564 >> 0x18);
      g_razer_report.args[4] = (byte)DAT_04000540;
      g_razer_report.args[5] = (byte)((uint)DAT_04000540 >> 8);
      g_razer_report.args[6] = (byte)((uint)DAT_04000540 >> 0x10);
      g_razer_report.args[7] = (byte)((uint)DAT_04000540 >> 0x18);
      return 0x4000cec;
    }
    g_razer_report.status = 5;
    return 5;
  }
  if (g_razer_report.args[0] == 0) {
    NVIC_SystemReset();
    uVar2 = 0;
    if ((DAT_04000d42 != 0) && (uVar2 = (uint)CONCAT11(DAT_04000d44,DAT_04000d43), uVar2 == 0)) {
      disableIRQinterrupts();
      if (((DAT_04000d42 & 1) != 0) &&
         (iVar3 = FUN_200087a0(0x28000,0x56,DAT_04000d44,DAT_04000d43,extraout_r1,extraout_r2,
                               extraout_r3,(unaff_r5 >> 0x13) << 0x15), iVar3 != 0)) {
        DAT_04000d42 = DAT_04000d42 & 0xfe;
      }
      if ((int)((uint)DAT_04000d42 << 0x1e) < 0) {
        DAT_04000d66 = 0xb;
        DAT_04000d67 = 0;
        uVar1 = FUN_20005954(&DAT_04000d66,9);
        DAT_04000d6f = (undefined1)uVar1;
        DAT_04000d70 = (undefined1)((ushort)uVar1 >> 8);
        iVar3 = FUN_200087a0(0x28100,0xb);
        if (iVar3 != 0) {
          DAT_04000d42 = DAT_04000d42 & 0xfd;
        }
      }
      if ((int)((uint)DAT_04000d42 << 0x1d) < 0) {
        DAT_04000d71 = 0x24;
        DAT_04000d72 = 0;
        uVar1 = FUN_20005954(&DAT_04000d71,0x22);
        DAT_04000d93 = (undefined1)uVar1;
        DAT_04000d94 = (undefined1)((ushort)uVar1 >> 8);
        iVar3 = FUN_200087a0(0x28200,0x24);
        if (iVar3 != 0) {
          DAT_04000d42 = DAT_04000d42 & 0xfb;
        }
      }
      if ((int)((uint)DAT_04000d42 << 0x1c) < 0) {
        DAT_04000d97 = 0xb;
        DAT_04000d98 = 7;
        uVar1 = FUN_20005954(&DAT_04000d97,0x709);
        DAT_04000d95 = (undefined1)uVar1;
        DAT_04000d96 = (undefined1)((ushort)uVar1 >> 8);
        uVar2 = 0;
        uVar7 = 0x17;
        uVar6 = 0x164;
        do {
          if ((DAT_040014a0 >> (uVar2 & 0xff) & 1) != 0) {
            if (uVar2 * 0x164 + 0x17 < 0x100) {
              iVar3 = 0x28300;
              uVar4 = 0x17b;
            }
            else {
              uVar4 = uVar6;
              FUN_200087a0(0x28300,uVar7);
              iVar3 = uVar2 * 0x164 + 0x28317;
              uVar6 = uVar4;
            }
            FUN_200087a0(iVar3,uVar4);
            DAT_040014a0 = DAT_040014a0 & ~(byte)(1 << (uVar2 & 0xff));
          }
          uVar2 = uVar2 + 1 & 0xffff;
        } while (uVar2 < 5);
        DAT_04000d42 = DAT_04000d42 & 0xf7;
      }
      if ((int)((uint)DAT_04000d42 << 0x1b) < 0) {
        uVar1 = FUN_20005954(&DAT_04001623,0x57f);
        DAT_04001ba2 = (undefined1)uVar1;
        DAT_04001ba3 = (undefined1)((ushort)uVar1 >> 8);
        uVar2 = 0;
        do {
          uVar5 = uVar2 >> 3;
          if (((byte)(&DAT_040014a1)[uVar5] >> (uVar2 & 7) & 1) != 0) {
            FUN_200087a0(uVar2 * 0xe + 0x29000,0xe);
            (&DAT_040014a1)[uVar5] = (&DAT_040014a1)[uVar5] & ~(byte)(1 << (uVar2 & 7));
          }
          uVar2 = uVar2 + 1 & 0xffff;
        } while (uVar2 < 100);
        FUN_200087a0(0x29578,9);
        DAT_04000d42 = DAT_04000d42 & 0xef;
      }
      uVar2 = (uint)DAT_04000d42 << 0x1a;
      if ((int)uVar2 < 0) {
        uVar1 = FUN_20005954(&DAT_040022fa,0x2d);
        DAT_04002327 = (undefined1)uVar1;
        DAT_04002328 = (undefined1)((ushort)uVar1 >> 8);
        uVar2 = FUN_200087a0(0x28e00,0x2f);
        if (uVar2 != 0) {
          uVar2 = DAT_04000d42 & 0xdf;
          DAT_04000d42 = (byte)uVar2;
        }
      }
      enableIRQinterrupts();
    }
    return uVar2;
  }
  uVar2 = FUN_2000cda0();
  return uVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b58c @ 2000b58c */


void FUN_2000b58c(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined2 uVar1;
  int iVar2;
  undefined4 uVar3;
  uint uVar4;
  uint uVar5;
  undefined4 uVar6;
  undefined4 uVar7;
  
  if ((DAT_04000d42 != 0) && (CONCAT11(DAT_04000d44,DAT_04000d43) == 0)) {
    disableIRQinterrupts();
    if (((DAT_04000d42 & 1) != 0) &&
       (iVar2 = FUN_200087a0(0x28000,0x56,DAT_04000d44,DAT_04000d43,param_2,param_3,param_4),
       iVar2 != 0)) {
      DAT_04000d42 = DAT_04000d42 & 0xfe;
    }
    if ((int)((uint)DAT_04000d42 << 0x1e) < 0) {
      DAT_04000d66 = 0xb;
      DAT_04000d67 = 0;
      uVar1 = FUN_20005954(&DAT_04000d66,9);
      DAT_04000d6f = (undefined1)uVar1;
      DAT_04000d70 = (undefined1)((ushort)uVar1 >> 8);
      iVar2 = FUN_200087a0(0x28100,0xb);
      if (iVar2 != 0) {
        DAT_04000d42 = DAT_04000d42 & 0xfd;
      }
    }
    if ((int)((uint)DAT_04000d42 << 0x1d) < 0) {
      DAT_04000d71 = 0x24;
      DAT_04000d72 = 0;
      uVar1 = FUN_20005954(&DAT_04000d71,0x22);
      DAT_04000d93 = (undefined1)uVar1;
      DAT_04000d94 = (undefined1)((ushort)uVar1 >> 8);
      iVar2 = FUN_200087a0(0x28200,0x24);
      if (iVar2 != 0) {
        DAT_04000d42 = DAT_04000d42 & 0xfb;
      }
    }
    if ((int)((uint)DAT_04000d42 << 0x1c) < 0) {
      DAT_04000d97 = 0xb;
      DAT_04000d98 = 7;
      uVar1 = FUN_20005954(&DAT_04000d97,0x709);
      DAT_04000d95 = (undefined1)uVar1;
      DAT_04000d96 = (undefined1)((ushort)uVar1 >> 8);
      uVar5 = 0;
      uVar7 = 0x17;
      uVar6 = 0x164;
      do {
        if ((DAT_040014a0 >> (uVar5 & 0xff) & 1) != 0) {
          if (uVar5 * 0x164 + 0x17 < 0x100) {
            iVar2 = 0x28300;
            uVar3 = 0x17b;
          }
          else {
            uVar3 = uVar6;
            FUN_200087a0(0x28300,uVar7);
            iVar2 = uVar5 * 0x164 + 0x28317;
            uVar6 = uVar3;
          }
          FUN_200087a0(iVar2,uVar3);
          DAT_040014a0 = DAT_040014a0 & ~(byte)(1 << (uVar5 & 0xff));
        }
        uVar5 = uVar5 + 1 & 0xffff;
      } while (uVar5 < 5);
      DAT_04000d42 = DAT_04000d42 & 0xf7;
    }
    if ((int)((uint)DAT_04000d42 << 0x1b) < 0) {
      uVar1 = FUN_20005954(&DAT_04001623,0x57f);
      DAT_04001ba2 = (undefined1)uVar1;
      DAT_04001ba3 = (undefined1)((ushort)uVar1 >> 8);
      uVar5 = 0;
      do {
        uVar4 = uVar5 >> 3;
        if (((byte)(&DAT_040014a1)[uVar4] >> (uVar5 & 7) & 1) != 0) {
          FUN_200087a0(uVar5 * 0xe + 0x29000,0xe);
          (&DAT_040014a1)[uVar4] = (&DAT_040014a1)[uVar4] & ~(byte)(1 << (uVar5 & 7));
        }
        uVar5 = uVar5 + 1 & 0xffff;
      } while (uVar5 < 100);
      FUN_200087a0(0x29578,9);
      DAT_04000d42 = DAT_04000d42 & 0xef;
    }
    if ((int)((uint)DAT_04000d42 << 0x1a) < 0) {
      uVar1 = FUN_20005954(&DAT_040022fa,0x2d);
      DAT_04002327 = (undefined1)uVar1;
      DAT_04002328 = (undefined1)((ushort)uVar1 >> 8);
      iVar2 = FUN_200087a0(0x28e00,0x2f);
      if (iVar2 != 0) {
        DAT_04000d42 = DAT_04000d42 & 0xdf;
      }
    }
    enableIRQinterrupts();
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b778 @ 2000b778 */


void FUN_2000b778(void)

{
  FUN_20007770();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b780 @ 2000b780 */


uint FUN_2000b780(uint param_1,uint param_2)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  uint uVar4;
  undefined8 uVar5;
  
  uVar1 = 0x80000000;
  uVar2 = 0xffffffff;
  uVar3 = param_1;
  uVar4 = param_2;
  if (param_2 < param_1) {
    uVar3 = param_2;
    uVar4 = param_1;
  }
  if (uVar4 - uVar3 == 0) {
    return param_2;
  }
  for (; (uVar4 - uVar3 & uVar1) == 0; uVar1 = uVar1 >> 1) {
    uVar2 = uVar2 >> 1;
  }
  do {
    uVar5 = __aeabi_idiv(DAT_040003f0,0x1f31d);
    DAT_040003f0 = (int)((ulonglong)uVar5 >> 0x20) * 0x41a7 + (int)uVar5 * -0xb14;
    if ((int)DAT_040003f0 < 1) {
      DAT_040003f0 = DAT_040003f0 + 0x7fffffff;
    }
    uVar1 = (DAT_040003f0 & uVar2) + uVar3;
  } while (uVar4 < uVar1);
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b7e8 @ 2000b7e8 */


undefined4 FUN_2000b7e8(uint param_1,undefined4 param_2)

{
  if (DAT_04000478 < 2) {
    disableIRQinterrupts();
    memcpy(param_2,param_1 & 0xfffff);
    enableIRQinterrupts();
    return 1;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b810 @ 2000b810 */


void FUN_2000b810(int param_1,int param_2)

{
  *(undefined1 *)(param_1 + 3) = *(undefined1 *)(param_2 + 2);
  *(undefined1 *)(param_1 + 0xf) = *(undefined1 *)(param_2 + 3);
  *(undefined1 *)(param_1 + 0xe) = *(undefined1 *)(param_2 + 4);
  *(undefined1 *)(param_1 + 5) = *(undefined1 *)(param_2 + 5);
  *(undefined1 *)(param_1 + 6) = *(undefined1 *)(param_2 + 6);
  *(undefined1 *)(param_1 + 7) = *(undefined1 *)(param_2 + 7);
  *(undefined1 *)(param_1 + 8) = *(undefined1 *)(param_2 + 8);
  *(undefined1 *)(param_1 + 9) = 0xff;
  *(undefined1 *)(param_1 + 10) = *(undefined1 *)(param_2 + 9);
  *(undefined1 *)(param_1 + 0xb) = *(undefined1 *)(param_2 + 10);
  *(undefined1 *)(param_1 + 0xc) = *(undefined1 *)(param_2 + 0xb);
  *(undefined1 *)(param_1 + 0xd) = 0xff;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b840 @ 2000b840 */


void FUN_2000b840(undefined1 param_1,undefined1 param_2)

{
  DAT_04000d3f = param_2;
  DAT_04000d40 = param_1;
  DAT_04000366 = DAT_04000366 | 0x80;
  return;
}


/* ---------------------------------------------------------------------- */
/* settings_mark_dirty @ 2000b85c */


/* schedules persistence of a settings group to flash */

ulonglong settings_mark_dirty(int param_1,uint param_2)

{
  byte bVar1;
  int iVar2;
  uint uVar3;
  
  iVar2 = 1 << (param_2 & 0xff);
  uVar3 = (uint)DAT_04000d42;
  bVar1 = 4;
  if (param_1 == 0x20) {
LAB_2000b8d4:
    DAT_04000d42 = DAT_04000d42 | bVar1;
    DAT_04000d43 = 100;
  }
  else {
    if (param_1 < 0x21) {
      if (param_1 == 1) {
        DAT_04000d42 = DAT_04000d42 | 1;
        return CONCAT44(iVar2,uVar3) | 4;
      }
      if (param_1 == 2) {
LAB_2000b914:
        bVar1 = (byte)param_1;
      }
      else if (param_1 != 8) {
        if (param_1 != 0x10) goto LAB_2000b8ca;
        goto LAB_2000b8e0;
      }
      goto LAB_2000b8d4;
    }
    if (param_1 == 0x40) {
LAB_2000b8e0:
      DAT_04000d42 = DAT_04000d42 | 8;
      DAT_04000d43 = 100;
      DAT_04000d44 = 0;
      DAT_040014a0 = DAT_040014a0 | (byte)iVar2;
      return CONCAT44(iVar2,uVar3) | 4;
    }
    if (param_1 == 0x80) {
      DAT_04000d42 = DAT_04000d42 | 0x10;
      DAT_04000d43 = 100;
      DAT_04000d44 = 0;
      (&DAT_040014a1)[param_2 >> 3] = (&DAT_040014a1)[param_2 >> 3] | (byte)(1 << (param_2 & 7));
      return CONCAT44(iVar2,uVar3) | 4;
    }
    if (param_1 == 0x100) {
      param_1 = 0x20;
      goto LAB_2000b914;
    }
    if (param_1 != 0x200) goto LAB_2000b8ca;
    DAT_04000d42 = DAT_04000d42 | 0x2c;
    DAT_040014a0 = DAT_040014a0 | 0x1f;
    DAT_04000d43 = 0;
  }
  DAT_04000d44 = 0;
LAB_2000b8ca:
  return CONCAT44(iVar2,uVar3) | 4;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000b924 @ 2000b924 */


void FUN_2000b924(void)

{
  byte bVar1;
  undefined1 uVar2;
  byte bVar3;
  uint uVar4;
  int iVar5;
  int iVar6;
  int iVar7;
  int iVar8;
  int iVar9;
  int iVar10;
  int iVar11;
  int iVar12;
  int iVar13;
  uint uVar14;
  int iVar15;
  uint uVar16;
  byte bVar17;
  
  bVar1 = DAT_04000d6b;
  bVar17 = DAT_04000d69;
  if (DAT_04000547 == '\0') {
    if (DAT_0400032d != '\0') {
      uVar4 = 0;
      do {
        iVar15 = uVar4 * 6;
        (&DAT_04000a18)[iVar15] = (&DAT_04000a18)[iVar15] | 2;
        (&DAT_04000a1a)[iVar15] = bVar1;
        uVar4 = uVar4 + 1 & 0xff;
        (&DAT_04000a1d)[iVar15] = 0;
      } while (uVar4 < 0xd);
      DAT_0400032d = '\0';
    }
  }
  else {
    bVar17 = DAT_04000d69 - DAT_04000d68;
    bVar1 = DAT_04000d6b - DAT_04000d6a;
    uVar4 = 0;
    do {
      iVar15 = uVar4 * 6;
      uVar4 = uVar4 + 1 & 0xff;
      (&DAT_04000a1d)[iVar15] = 1;
    } while (uVar4 < 0xd);
    DAT_0400032d = '\x01';
  }
  if (0x1e < bVar17) {
    bVar17 = 0x1c;
  }
  if (0x1e < bVar1) {
    bVar1 = 0x1c;
  }
  uVar4 = FUN_20007358(0,0x1d);
  iVar15 = FUN_20007358(0,0x1e);
  iVar5 = FUN_20007358(0,8);
  iVar6 = FUN_20007358(0,0x16);
  iVar7 = FUN_20007358(0);
  iVar8 = FUN_20007358(0,0x15);
  iVar9 = FUN_20007358(0,0x12);
  iVar10 = FUN_20007358(0,0x13);
  iVar11 = FUN_20007358(0,1);
  iVar12 = FUN_20007358(1,3);
  iVar13 = FUN_20007358(1,8);
  uVar4 = uVar4 | iVar15 << 1 | iVar5 << 2 | iVar6 << 7 | iVar7 << 3 | iVar8 << 4 | iVar9 << 5 |
          iVar10 << 6 | iVar11 << 8 | iVar12 << 9 | iVar13 << 10;
  uVar16 = 0;
  DAT_04000330 = uVar4;
  do {
    iVar15 = uVar16 * 6;
    uVar14 = (uint)(byte)(&DAT_04000a18)[iVar15];
    if ((int)(uVar14 << 0x1e) < 0) {
      if ((&DAT_04000a1a)[iVar15] == '\0') {
        uVar14 = uVar14 & 0xfd;
        (&DAT_04000a18)[iVar15] = (char)uVar14;
        goto LAB_2000ba60;
      }
      if ((uint)(byte)(&DAT_04000a19)[iVar15] == (uVar4 >> uVar16 & 1)) {
        if (bVar17 <= (byte)(&DAT_04000a1b)[iVar15]) {
          (&DAT_04000a18)[iVar15] = (&DAT_04000a18)[iVar15] & 0xfd;
        }
      }
      else {
        (&DAT_04000a1b)[iVar15] = 0;
      }
      goto LAB_2000bb22;
    }
LAB_2000ba60:
    if ((uVar4 >> uVar16 & 1) == 0) {
      if ((&DAT_04000a19)[iVar15] == '\x01') goto LAB_2000bb34;
      if ((uVar14 & 1) == 0) {
        (&DAT_04000a18)[iVar15] = (byte)uVar14 | 1;
        (&DAT_04000a1a)[iVar15] = 1;
        if (((&DAT_04000a1d)[iVar15] == '\0') && ((uVar16 == 0 || (uVar16 == 1)))) {
LAB_2000baca:
          button_action_execute(1,uVar16);
          goto LAB_2000bae2;
        }
      }
      else {
        bVar3 = DAT_04000d68;
        if ((&DAT_04000a1d)[iVar15] != '\x01') {
          bVar3 = 0;
        }
        if (bVar3 < (byte)(&DAT_04000a1a)[iVar15]) {
          if (DAT_04000d6d != '\x01') goto LAB_2000baca;
          FUN_2000b278(1,uVar16);
LAB_2000bae2:
          (&DAT_04000a19)[iVar15] = 1;
          (&DAT_04000a18)[iVar15] = (&DAT_04000a18)[iVar15] | 2;
          (&DAT_04000a1a)[iVar15] = bVar17;
          (&DAT_04000a1d)[iVar15] = 0;
        }
      }
    }
    else {
      if ((&DAT_04000a19)[iVar15] == '\0') {
LAB_2000bb34:
        uVar2 = 0;
      }
      else {
        if ((uVar14 & 1) == 0) {
          bVar3 = DAT_04000d6a;
          if ((&DAT_04000a1d)[iVar15] != '\x01') {
            bVar3 = 0;
          }
          if (bVar3 < (byte)(&DAT_04000a1a)[iVar15]) {
            button_action_execute(0,uVar16);
            (&DAT_04000a19)[iVar15] = 0;
            (&DAT_04000a18)[iVar15] = (&DAT_04000a18)[iVar15] | 2;
            (&DAT_04000a1a)[iVar15] = bVar1;
            (&DAT_04000a1d)[iVar15] = 0;
          }
          goto LAB_2000bb22;
        }
        (&DAT_04000a18)[iVar15] = 0;
        uVar2 = 1;
      }
      (&DAT_04000a1a)[iVar15] = uVar2;
    }
LAB_2000bb22:
    uVar16 = uVar16 + 1 & 0xff;
    if (10 < uVar16) {
      return;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_2000bb48 @ 2000bb48 */


void FUN_2000bb48(char *param_1)

{
  if (*param_1 != '\0') {
    DAT_04000401 = *param_1;
    *param_1 = '\0';
    DAT_04000366 = DAT_04000366 & 0xfffd;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000bb6c @ 2000bb6c */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000bb76) */
/* WARNING: Removing unreachable block (ram,0x2000bb76) */

void FUN_2000bb6c(undefined4 param_1)

{
  undefined4 uVar1;
  undefined1 uVar2;
  
  uVar1 = 1000;
  switch(param_1) {
  default:
    uVar2 = 0;
    break;
  case 1:
    uVar2 = 10;
    break;
  case 2:
    uVar2 = 9;
    goto LAB_2000bb8e;
  case 3:
    uVar2 = 4;
LAB_2000bb8e:
    uVar1 = 0x5dc;
    break;
  case 4:
    uVar2 = 1;
    uVar1 = 0;
  }
  write_u32_le(uVar1,&DAT_0400151f);
  DAT_04001514 = uVar2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000bbb0 @ 2000bbb0 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_2000bbb0(char *param_1,int *param_2)

{
  char cVar1;
  short sVar2;
  char cVar3;
  ushort uVar4;
  int iVar5;
  int iVar6;
  uint uVar7;
  undefined4 uVar8;
  byte bVar9;
  uint uVar10;
  byte bVar11;
  bool bVar12;
  uint local_24;
  
  uVar10 = 0;
  local_24 = 0;
  iVar5 = *param_2;
  iVar6 = read_u32_le();
  if (iVar6 == iVar5) {
    return;
  }
  write_u32_le(iVar5,&DAT_04001517);
  if ((int)((uint)DAT_04001504 * 0x20000000) < 0) {
    if (DAT_04000400 == '\0') {
      DAT_04000408 = 0xfa;
      DAT_04000400 = '\x01';
    }
LAB_2000bbf6:
    DAT_04000408 = DAT_04000408 + -1;
    if (DAT_04000408 == -1) {
      DAT_04000400 = '\0';
    }
    else {
      DAT_04000401 = '\0';
    }
  }
  else if (DAT_04000400 != '\0') goto LAB_2000bbf6;
  if (DAT_04001506 != '\0') {
    DAT_04000401 = 0;
    FUN_2000bfe4();
    DAT_04001506 = 0;
    return;
  }
  if (DAT_04000401 == 0) {
    if ((int)((uint)DAT_0400150e << 0x1d) < 0) {
      if (DAT_0400150f == '\x01') {
        DAT_04000410 = 300;
      }
      else if (DAT_0400150f == '\x02') {
        DAT_04000410 = 400;
      }
      uVar8 = read_u32_le(&DAT_0400151b);
      uVar10 = FUN_2000c378(uVar8,iVar5);
      if (DAT_04000410 < uVar10) {
        if (*param_1 == '\x01') {
          *param_1 = '\0';
          FUN_2000c034(4,0,0);
          DAT_04001510 = 0;
        }
        DAT_0400150e = DAT_0400150e & 0xfb;
      }
    }
    cVar3 = DAT_0400150f;
    if ((-1 < (int)((uint)DAT_0400150e << 0x1e)) && ((DAT_0400150e & 1) != 0)) {
      iVar6 = read_u32_le(&DAT_0400151f);
      DAT_0400040c = iVar6 - DAT_04000410;
      uVar8 = read_u32_le(&DAT_0400151b);
      uVar10 = FUN_2000c378(uVar8,iVar5);
      cVar3 = DAT_0400150f;
      if (DAT_0400040c < uVar10) {
        DAT_04001512 = 1;
        DAT_0400150e = DAT_0400150e | 2;
        DAT_04000410 = 0;
        write_u32_le(iVar5,&DAT_0400151b);
        cVar3 = DAT_0400150f;
      }
    }
  }
  else {
    if ((int)DAT_04000401 << 0x18 < 0) {
      cVar3 = '\x01';
    }
    else {
      cVar3 = '\x02';
    }
    DAT_04000401 = '\0';
    uVar7 = DAT_0400150e & 0xfd;
    bVar9 = (byte)uVar7;
    if (DAT_0400150f == cVar3) {
      DAT_0400150e = bVar9 | 8;
      if (*param_1 == '\0') {
        uVar8 = read_u32_le(&DAT_0400151b);
        uVar4 = FUN_2000c378(uVar8,iVar5);
        write_u32_le(iVar5,&DAT_0400151b);
        if (DAT_0400150f == '\x01') {
          uVar10 = 0x12;
        }
        else if (DAT_0400150f == '\x02') {
          uVar10 = 0x17;
        }
        if (uVar4 < uVar10) {
          DAT_04001511 = 0;
          bVar9 = DAT_04001510 + 1;
          if (2 < DAT_04001510) {
            DAT_04001510 = 0;
            if (param_1[2] != '\0') {
              DAT_0400150e = DAT_0400150e & 0xfe | 4;
              DAT_04001512 = 0;
              *param_1 = '\x01';
              FUN_2000c034(4,0);
            }
            if (param_1[1] != '\0') {
              DAT_0400150e = DAT_0400150e | 1;
              DAT_04001512 = 3;
              DAT_04001513 = DAT_0400150f;
            }
            DAT_04001514 = '\x01';
            goto LAB_2000bf58;
          }
          DAT_04001510 = bVar9;
          if ((DAT_0400150e & 1) != 0) goto LAB_2000bf58;
        }
        else {
          DAT_04001510 = 0;
          if ((DAT_0400150e & 1) != 0) {
            bVar12 = DAT_04001511 < 2;
            DAT_04001511 = DAT_04001511 + 1;
            if (bVar12) goto LAB_2000bf58;
            DAT_04001511 = 0;
            DAT_0400150e = DAT_0400150e & 0xfe;
            DAT_04001512 = 0;
          }
        }
        DAT_04001514 = '\x01';
      }
      else if (*param_1 == '\x01') {
        _DAT_04001515 = _DAT_04001515 + 1;
        uVar8 = read_u32_le(&DAT_0400151b);
        uVar4 = FUN_2000c378(uVar8,iVar5);
        if (uVar4 < 0xc9) {
          if ((DAT_0400150e & 1) == 0) {
            DAT_04001512 = 0;
            DAT_04001514 = '\x01';
          }
        }
        else {
          write_u32_le(iVar5,&DAT_0400151b);
          cVar1 = DAT_0400150f;
          bVar9 = DAT_0400150e;
          DAT_04000402 = _DAT_04001515 + DAT_04000402;
          _DAT_04001515 = 0;
          DAT_04001514 = '\x01';
          if (DAT_0400150f == '\x01') {
            uVar10 = 0x20;
            local_24 = 0xb;
          }
          else if (DAT_0400150f == '\x02') {
            uVar10 = 0x15;
            local_24 = 7;
          }
          uVar7 = (uint)DAT_0400150e;
          if ((DAT_0400150e & 1) == 0) {
            bVar11 = 3;
          }
          else {
            bVar11 = 1;
          }
          bVar12 = bVar11 <= DAT_04001510;
          DAT_04001510 = DAT_04001510 + 1;
          if (bVar12) {
            DAT_04001510 = 0;
            DAT_04000404 = __aeabi_uidiv();
            DAT_04000402 = 0;
            DAT_04001513 = cVar1;
            if ((DAT_04000404 == 0) || (uVar10 < DAT_04000404)) {
              if (param_1[1] == '\0') {
                DAT_04001512 = 0;
                DAT_04001514 = '\x01';
                DAT_0400150e = bVar9 & 0xfe;
              }
              else {
                DAT_04001512 = 3;
                DAT_0400150e = bVar9 | 1;
              }
              goto LAB_2000bf58;
            }
            DAT_04001514 = '\x01';
            if ((bVar9 & 1) != 0) {
              DAT_04001512 = 1;
            }
            if ((DAT_04000404 <= local_24) && (*param_1 == '\x01')) {
              if (((int)(uVar7 << 0x1d) < 0) && (param_1[2] != '\0')) {
                *param_1 = '\0';
                FUN_2000c034(4,0,0);
                bVar9 = DAT_0400150e;
                bVar11 = DAT_0400150e & 0xfb;
                DAT_0400150e = bVar11;
                write_u32_le(iVar5,&DAT_0400151b);
                if (param_1[1] == '\0') {
                  DAT_0400150e = bVar9 & 0xfa;
                  DAT_04001512 = 0;
                  DAT_04001514 = '\x01';
                }
                else {
                  DAT_04001512 = 1;
                  DAT_0400150e = bVar11 | 1;
                }
              }
              goto LAB_2000bf58;
            }
          }
          DAT_04001514 = '\x01';
        }
      }
    }
    else {
      DAT_04001512 = 0;
      DAT_04001514 = '\x01';
      DAT_04001513 = cVar3;
      sVar2 = _DAT_04001515 + 1;
      if ((int)(uVar7 << 0x1c) < 0) {
        if (*param_1 == '\0') {
          DAT_0400150e = bVar9;
          uVar8 = read_u32_le(&DAT_0400151b);
          uVar4 = FUN_2000c378(uVar8,iVar5);
          if (uVar4 < DAT_04000d6c) {
            DAT_04001514 = '\0';
            DAT_04001510 = 0;
            DAT_0400150e = DAT_0400150e & 0xf7 | 0x10;
          }
          bVar9 = DAT_0400150e & 0xfe;
          sVar2 = _DAT_04001515;
        }
        else {
          sVar2 = _DAT_04001515;
          if ((*param_1 == '\x01') && (param_1[1] != '\0')) {
            bVar9 = DAT_0400150e & 0xf4;
          }
        }
      }
      _DAT_04001515 = sVar2;
      DAT_0400150e = bVar9;
      write_u32_le(iVar5,&DAT_0400151b);
    }
  }
LAB_2000bf58:
  DAT_0400150f = cVar3;
  if ((DAT_04001514 != '\0') &&
     (cVar3 = DAT_04001514 + -1, bVar12 = DAT_04001514 == '\x01', DAT_04001514 = cVar3, bVar12)) {
    FUN_2000bb6c(DAT_04001512);
    if (DAT_04001513 == '\x02') {
      DAT_04000358 = DAT_04000358 + '\x01';
    }
    else if (DAT_04001513 == '\x01') {
      DAT_04000358 = DAT_04000358 + -1;
    }
    if (DAT_04000d6d == '\x01') {
      DAT_04000358 = '\0';
      DAT_04000366 = 0;
    }
    else {
      DAT_04000366 = DAT_04000366 | 2;
    }
  }
  iVar6 = read_u32_le(&DAT_0400151b);
  if (iVar6 != 0) {
    uVar10 = FUN_2000c378(iVar6,iVar5);
    uVar7 = read_u32_le(&DAT_0400151f);
    if (uVar7 < uVar10) {
      FUN_2000bfe4();
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000bfe4 @ 2000bfe4 */


void FUN_2000bfe4(void)

{
  byte bVar1;
  
  bVar1 = DAT_0400150e;
  DAT_0400150f = 0;
  write_u32_le(0,&DAT_0400151b);
  DAT_04001515 = 0;
  DAT_04001516 = 0;
  DAT_04001514 = 0;
  DAT_04001512 = 0;
  DAT_0400150e = bVar1 & 0xe0;
  DAT_04001510 = 0;
  DAT_04001511 = 0;
  DAT_04001513 = 0;
  write_u32_le(1000,&DAT_0400151f);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c034 @ 2000c034 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000c040) */
/* WARNING: Removing unreachable block (ram,0x2000c040) */

undefined4 FUN_2000c034(undefined4 param_1)

{
  undefined4 uVar1;
  uint uVar2;
  byte bVar3;
  
  uVar2 = (uint)DAT_04001504;
  uVar1 = 0;
  switch(param_1) {
  default:
    return 0;
  case 1:
    bVar3 = 2;
    break;
  case 2:
    if ((int)(uVar2 << 0x1d) < 0) {
      return 0;
    }
    if ((int)(uVar2 << 0x1e) < 0) {
      return 0;
    }
    DAT_04001504 = DAT_04001504 | 4;
    return 1;
  case 3:
    DAT_04001505 = 1;
    return 0;
  case 4:
    if ((int)(uVar2 << 0x1e) < 0) {
      return 0;
    }
    uVar1 = 1;
    bVar3 = 8;
  }
  DAT_04001504 = DAT_04001504 | bVar3;
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c07c @ 2000c07c */


void FUN_2000c07c(void)

{
  FUN_20000e80(0,DAT_040003f8);
  FUN_20000e80(0,DAT_040003fc);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c098 @ 2000c098 */


void FUN_2000c098(void)

{
  DAT_040003f4 = 0;
  FUN_2000c250();
  FUN_2000c07c();
  FUN_20008118();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c0b4 @ 2000c0b4 */


void FUN_2000c0b4(void)

{
  FUN_20000e80(100,DAT_040003f8);
  FUN_20000e80(0,DAT_040003fc);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c0d0 @ 2000c0d0 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000c0f4) */
/* WARNING: Removing unreachable block (ram,0x2000c0f4) */

void FUN_2000c0d0(char *param_1,int *param_2)

{
  int iVar1;
  
  iVar1 = read_u32_le(&DAT_0400150a);
  if ((uint)(*param_2 - iVar1) < 100) {
    return;
  }
  switch(DAT_040003f4) {
  case 0:
    DAT_040003f4 = 1;
    return;
  case 1:
    DAT_04001507 = '\0';
    break;
  case 2:
    DAT_04001507 = *param_1;
    break;
  case 3:
    if ((int)((uint)DAT_04001504 << 0x1e) < 0) {
      DAT_04001506 = 1;
      DAT_040003f4 = 1;
      DAT_04001504 = DAT_04001504 | 1;
      return;
    }
    if ((int)((uint)DAT_04001504 * 0x20000000) < 0) {
      DAT_04001504 = DAT_04001504 & 0xf7;
      DAT_04001507 = *param_1;
      DAT_04001506 = 1;
      DAT_040003f4 = 4;
    }
    if ((int)((uint)DAT_04001504 << 0x1c) < 0) {
      DAT_040003f4 = 4;
      DAT_04001504 = DAT_04001504 & 0xf7;
      DAT_04001507 = *param_1;
      return;
    }
    return;
  case 4:
    if (DAT_04001507 == '\0') {
      FUN_2000c234();
    }
    else if (DAT_04001507 == '\x01') {
      FUN_2000c0b4();
    }
    write_u32_le(*param_2,&DAT_0400150a);
    DAT_040003f4 = 5;
    return;
  case 5:
    FUN_2000c07c();
    if ((int)((uint)DAT_04001504 << 0x1b) < 0) {
      if ((int)((uint)DAT_04001504 << 0x1d) < 0) {
        DAT_04001504 = DAT_04001504 & 0xfb;
      }
      else if ((DAT_04001505 == '\0') && ((DAT_04001504 & 1) == 0)) {
        DAT_040003f4 = 3;
        return;
      }
      DAT_04001505 = 0;
      if ((DAT_04001504 & 1) != 0) {
        DAT_04001504 = DAT_04001504 & 0xfc;
      }
      if (-1 < (int)((uint)(byte)DAT_04000366 << 0x18)) {
        FUN_2000b840(0x39,0);
      }
      DAT_040003f4 = 3;
      return;
    }
    if (DAT_040003f5 == '\x01') {
      DAT_040003f4 = 2;
      return;
    }
    if (DAT_040003f5 != '\x02') {
      return;
    }
    DAT_040003f5 = 0;
    DAT_04001504 = DAT_04001504 | 0x10;
    return;
  default:
    return;
  }
  DAT_040003f5 = DAT_040003f4;
  DAT_040003f4 = 4;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c1d4 @ 2000c1d4 */


void FUN_2000c1d4(void)

{
  FUN_200080d4();
  FUN_200073a8(1,4,0);
  delay_ms(5);
  FUN_200073a8(1,4);
  delay_ms(5);
  FUN_20001e60();
  DAT_040003f4 = 0;
  __aeabi_memclr(&DAT_04001504,10);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c218 @ 2000c218 */


void FUN_2000c218(void)

{
  DAT_040003f4 = 0;
  __aeabi_memclr(&DAT_04001504,10);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c234 @ 2000c234 */


void FUN_2000c234(void)

{
  FUN_20000e80(0,DAT_040003f8);
  FUN_20000e80(100,DAT_040003fc);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c250 @ 2000c250 */


void FUN_2000c250(void)

{
  FUN_200073a8(1,4,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c260 @ 2000c260 */


void FUN_2000c260(void)

{
  undefined1 uVar1;
  undefined4 in_r3;
  
  FUN_200065dc(&DAT_04002d8d + (uint)DAT_040004c4 * 0x23,&DAT_04002e6a,DAT_040004c5,in_r3,in_r3);
  FUN_20006330(&DAT_04002d8d + (uint)DAT_040004c4 * 0x23,&DAT_04002e6a,DAT_040004c5);
  FUN_20006888(&DAT_04002d8d + (uint)DAT_040004c4 * 0x23,&DAT_04002e6a,
               &DAT_04002d9d + (uint)DAT_040004c4 * 0x23,&DAT_040004c6,DAT_040004c5);
  uVar1 = DAT_04000356;
  if (DAT_04000d6d == '\x01') {
    uVar1 = 1;
  }
  FUN_2000c418(&DAT_040004c6,DAT_040004c5,uVar1,DAT_04000360);
  FUN_2000678c(&DAT_040004c6,DAT_040004c5,DAT_040004c4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c2e4 @ 2000c2e4 */


void FUN_2000c2e4(void)

{
  char cVar1;
  byte bVar2;
  ushort uVar3;
  undefined4 in_r3;
  uint uVar4;
  
  cVar1 = DAT_4008c005;
  bVar2 = DAT_4008c006;
  DAT_0400035b = cVar1 << 1 | bVar2;
  if (DAT_0400035a == DAT_0400035b) goto LAB_2000c362;
  DAT_04000357 = DAT_04000357 << 2 | DAT_0400035b;
  uVar4 = ((uint)DAT_04000d3e << 0x1a) >> 0x1e;
  bVar2 = DAT_04000357 & 0x3f;
  uVar3 = DAT_04000366 | 2;
  DAT_0400035a = DAT_0400035b;
  if (bVar2 == 7) {
LAB_2000c334:
    if (uVar4 != 3) {
      button_action_execute(1,0xc,uVar3,&DAT_04000354,in_r3);
      DAT_04000374._0_1_ = 2;
      DAT_04000374._1_1_ = 1;
      goto LAB_2000c362;
    }
    cVar1 = -1;
  }
  else {
    if ((bVar2 != 0xb) && (bVar2 != 0x34)) {
      if (bVar2 != 0x38) goto LAB_2000c362;
      goto LAB_2000c334;
    }
    if (uVar4 != 3) {
      button_action_execute(1,0xb,uVar3,&DAT_04000354,in_r3);
      DAT_04000372._0_1_ = 2;
      DAT_04000372._1_1_ = 1;
      goto LAB_2000c362;
    }
    cVar1 = '\x01';
  }
  DAT_04000358 = DAT_04000358 + cVar1;
  DAT_04000366 = uVar3;
LAB_2000c362:
  FUN_2000bb48(&DAT_04000358);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c378 @ 2000c378 */


int FUN_2000c378(int param_1,int param_2)

{
  return param_2 - param_1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c37c @ 2000c37c */


void FUN_2000c37c(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  
  if (-1 < (int)((uint)DAT_04000d5d << 0x1c)) {
    return;
  }
  uVar1 = param_4;
  if (((uint)DAT_04000d3e << 0x1a) >> 0x1e == 3) {
    param_3 = 5000;
    if (((byte)DAT_04000330 & 7) == 0) {
      uVar1 = 1;
      if (DAT_04000355 == '\0') {
        DAT_04000360 = 0;
        DAT_04000355 = '\x01';
      }
      else if (4999 < DAT_04000360) {
        DAT_04000356 = 0;
        goto LAB_2000c3c4;
      }
      DAT_04000356 = 1;
      return;
    }
    if (DAT_04000d64 != '\x01') {
      if (4999 < DAT_04000360) {
        return;
      }
      DAT_04000355 = 0;
      DAT_04000356 = 0;
      return;
    }
  }
LAB_2000c3c4:
  DAT_04000d5e = 0;
  DAT_04000d63 = 0x55;
  FUN_2000c574(0,1,param_3,uVar1,param_4);
  DAT_04000360 = 0;
  DAT_04000355 = 0;
  if (DAT_04000d64 == '\0') {
    FUN_2000b840(10,3);
    DAT_04000cb9 = 5;
  }
  DAT_04000d5d = DAT_04000d5d & 0xf7;
  DAT_04000d64 = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c418 @ 2000c418 */


void FUN_2000c418(int param_1,uint param_2,int param_3,undefined4 param_4)

{
  uint uVar1;
  int iVar2;
  undefined1 uVar3;
  
  uVar3 = 0;
  if (param_3 != 0) {
    uVar1 = __aeabi_uidiv(param_4,500,param_3,param_4,param_4);
    if ((uVar1 & 1) != 0) {
      uVar3 = 0xff;
    }
    for (uVar1 = 0; uVar1 < param_2; uVar1 = uVar1 + 1 & 0xff) {
      iVar2 = uVar1 * 9 + param_1;
      *(undefined1 *)(iVar2 + 3) = 0;
      *(undefined1 *)(iVar2 + 4) = 0;
      *(undefined1 *)(iVar2 + 5) = uVar3;
      *(undefined1 *)(iVar2 + 6) = 0;
      *(undefined1 *)(iVar2 + 7) = 0;
      *(undefined1 *)(iVar2 + 8) = 0;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c460 @ 2000c460 */


void FUN_2000c460(void)

{
  FUN_2000c4d0();
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x41,DAT_0400056d);
  FUN_2000dd10(0x43,DAT_0400056e);
  FUN_2000dd10(0x44,DAT_0400056f);
  FUN_2000dd10(0x4e,DAT_04000570);
  FUN_2000dd10(0x5a,DAT_04000571);
  FUN_2000dd10(0x5b,DAT_04000572);
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x6e,DAT_04000573);
  FUN_2000dd10(0x7f,9);
  FUN_2000dd10(0x71,DAT_04000574);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c4d0 @ 2000c4d0 */


void FUN_2000c4d0(void)

{
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x41,0x30);
  FUN_2000dd10(0x43,0x20);
  FUN_2000dd10(0x44,0xd);
  FUN_2000dd10(0x4a,0x12);
  FUN_2000dd10(0x4b,9);
  FUN_2000dd10(0x4c,0x30);
  FUN_2000dd10(0x4e,8);
  FUN_2000dd10(0x53,0x16);
  FUN_2000dd10(0x55,0x14);
  FUN_2000dd10(0x5a,0xd);
  FUN_2000dd10(0x5b,5);
  FUN_2000dd10(0x5f,0x1e);
  FUN_2000dd10(0x66,0x30);
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x6e,0xf);
  FUN_2000dd10(0x7f,9);
  FUN_2000dd10(0x71,0xf);
  FUN_2000dd10(0x72,10);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c574 @ 2000c574 */


void FUN_2000c574(int param_1,uint param_2)

{
  uint uVar1;
  
  uVar1 = 8;
  if (param_1 == 0) {
    uVar1 = param_2 & 3 | 8;
  }
  else if (param_1 == 1) {
    uVar1 = (param_2 & 3) * 0x10 + 0x80 | 8;
  }
  FUN_2000c4d0();
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x4e,uVar1);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c5b0 @ 2000c5b0 */


void FUN_2000c5b0(void)

{
  FUN_2000c4d0();
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x41,DAT_04000568);
  FUN_2000dd10(0x43,DAT_04000569);
  FUN_2000dd10(0x44,DAT_0400056a);
  FUN_2000dd10(0x5a,DAT_0400056b);
  FUN_2000dd10(0x7f,9);
  FUN_2000dd10(0x71,DAT_0400056c);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c600 @ 2000c600 */


void FUN_2000c600(void)

{
  FUN_2000c4d0();
  DAT_04000545 = FUN_2000dc50(0x40);
  FUN_2000dd10(0x7f,0);
  FUN_2000dd10(0x40,0x80);
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x43,0xe7);
  FUN_2000dd10(0x7f,4);
  FUN_2000dd10(0x40,0xc0);
  FUN_2000dd10(0x41,0x10);
  FUN_2000dd10(0x44,0xf);
  FUN_2000dd10(0x45,0xf);
  FUN_2000dd10(0x46,0xf);
  FUN_2000dd10(0x47,0xf);
  FUN_2000dd10(0x48,0xf);
  FUN_2000dd10(0x49,0xf);
  FUN_2000dd10(0x4a,0xf);
  FUN_2000dd10(0x4b,0xf);
  FUN_2000dd10(0x40,0xc1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c698 @ 2000c698 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000c6b4) */
/* WARNING: Removing unreachable block (ram,0x2000c6b4) */
/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_2000c698(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  
  if (-1 < (int)((uint)DAT_04000d5d << 0x1c)) {
    return;
  }
  uVar1 = (uint)DAT_04000d5e;
  if (uVar1 != 0) {
    if (9 < uVar1) {
      uVar1 = 10;
    }
    switch(DAT_04000d5e) {
    case 1:
      DAT_04000d63 = 0;
      DAT_04000354 = 0;
      FUN_2000cc38(100,100,1);
      FUN_2000b840(10,0);
      FUN_2000c600();
      DAT_0400036a = 0;
      DAT_04000368 = 0;
      DAT_04000d5e = 4;
      DAT_04000550 = 0;
      DAT_04000554 = 0;
      DAT_04000558 = 0;
      DAT_04000548 = 3000;
      break;
    default:
      DAT_04000d5e = 0;
      return;
    case 4:
      return;
    case 8:
      DAT_04000354 = 0;
      DAT_0400036a = 0;
      DAT_04000368 = 0;
      FUN_2000dd10(0x4e,8,param_3,(uint)(byte)(&UNK_2000c6b9)[uVar1] * 2,param_4);
      FUN_2000dd10(0x7f,5);
      FUN_2000dd10(0x43,0xe4);
      FUN_2000dd10(0x7f,0);
      FUN_2000dd10(0x40,DAT_04000545);
      FUN_2000c574(0,1);
      FUN_2000b840(10,2);
    case 6:
      DAT_04000d5e = 0;
      FUN_2000cc38(_DAT_04000376,_DAT_04000378,1);
      DAT_04000d63 = 0x55;
      break;
    case 9:
      FUN_2000dd10(0x40);
      if ((DAT_04000354 & -DAT_04000544) != 0) {
        DAT_0400036a = 0;
        DAT_04000368 = 0;
        uVar1 = FUN_2000dc50(0x4c);
        if ((uVar1 & 0xf) == 5) {
          DAT_04000588 = FUN_2000dc50(0x4d);
          FUN_2000dd10(0x7f,0xc);
          if (DAT_04000588 < 0x32) {
            DAT_04000589 = 3;
          }
          else {
            DAT_04000589 = 5;
          }
          DAT_0400058a = 0x30;
          DAT_0400058b = 3;
          FUN_2000dd10(0x4e,8);
          FUN_2000dd10(0x7f,5);
          FUN_2000dd10(0x43,0xe4);
          FUN_2000dd10(0x7f,0);
          FUN_2000dd10(0x40,DAT_04000545);
          uVar1 = DAT_04000554;
          if (DAT_04000554 < 0x2d) {
            DAT_04000580 = 0x17;
          }
          else {
            DAT_04000580 = 0x1a;
          }
          DAT_04000584 = __aeabi_uidiv(DAT_04000550 * 100,DAT_04000558);
          if ((DAT_04000584 < DAT_04000580) && (uVar1 < 0x41)) {
            DAT_04000588 = 0x30;
            DAT_04000589 = 0xd;
            DAT_0400058a = 0x20;
            DAT_0400058b = 2;
          }
          DAT_04000364 = 0;
          DAT_04000362 = 0;
          DAT_0400054a = 0;
          DAT_0400054c = 0;
          FUN_2000b840(10,1);
          DAT_04000d5e = 6;
          return;
        }
        FUN_20007358(0,0x1d);
      }
      DAT_04000d5e = 8;
      return;
    }
    DAT_04000544 = 0;
    return;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c890 @ 2000c890 */


void FUN_2000c890(int param_1)

{
  undefined4 uVar1;
  
  if (param_1 == 0) {
    FUN_2000dd10(0x7f,0xd);
    uVar1 = 0xdc;
  }
  else {
    FUN_2000dd10(0x7f,0xd);
    uVar1 = 0xdd;
  }
  FUN_2000dd10(0x48,uVar1);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c8bc @ 2000c8bc */


void FUN_2000c8bc(void)

{
  FUN_20001746(&DAT_40001000,0,10,0x90);
  FUN_20007334(0,10);
  FUN_20001746(&DAT_40001000,0,0xe,0x90);
  FUN_20007334(0,0xe,1);
  FUN_200073a8(0,0xe,1);
  FUN_20001746(&DAT_40001000,1,0xf,0x90);
  FUN_20007334(1,0xf);
  FUN_200073a8(1,0xf);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000c91c @ 2000c91c */


void FUN_2000c91c(void)

{
  FUN_2000dd10(0x40,0x80);
  FUN_2000dd10(0x7f,0xe);
  FUN_2000dd10(0x55,0xd);
  FUN_2000dd10(0x56,0x1b);
  FUN_2000dd10(0x57,0xe8);
  FUN_2000dd10(0x58,0xd5);
  FUN_2000dd10(0x7f,0x14);
  FUN_2000dd10(0x42,0xbc);
  FUN_2000dd10(0x43,0x74);
  FUN_2000dd10(0x4b,0x20);
  FUN_2000dd10(0x4d,0);
  FUN_2000dd10(0x53,0xd);
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x51,0x40);
  FUN_2000dd10(0x53,0x40);
  FUN_2000dd10(0x55,0xca);
  FUN_2000dd10(0x61,0x31);
  FUN_2000dd10(0x62,100);
  FUN_2000dd10(0x6d,0xb8);
  FUN_2000dd10(0x6e,0xf);
  FUN_2000dd10(0x70,2);
  FUN_2000dd10(0x4a,0x2a);
  FUN_2000dd10(0x60,0x26);
  FUN_2000dd10(0x7f,6);
  FUN_2000dd10(0x6d,0x70);
  FUN_2000dd10(0x6e,0x60);
  FUN_2000dd10(0x6f,4);
  FUN_2000dd10(0x53,2);
  FUN_2000dd10(0x55,0x11);
  FUN_2000dd10(0x7d,0x51);
  FUN_2000dd10(0x7f,8);
  FUN_2000dd10(0x71,0x4f);
  FUN_2000dd10(0x7f,9);
  FUN_2000dd10(0x62,0x1f);
  FUN_2000dd10(99,0x1f);
  FUN_2000dd10(0x65,3);
  FUN_2000dd10(0x66,3);
  FUN_2000dd10(0x67,0x1f);
  FUN_2000dd10(0x68,0x1f);
  FUN_2000dd10(0x69,3);
  FUN_2000dd10(0x6a,3);
  FUN_2000dd10(0x6c,0x1f);
  FUN_2000dd10(0x6d,0x1f);
  FUN_2000dd10(0x51,4);
  FUN_2000dd10(0x53,0x20);
  FUN_2000dd10(0x54,0x20);
  FUN_2000dd10(0x71,0xf);
  FUN_2000dd10(0x7f,10);
  FUN_2000dd10(0x4a,0x14);
  FUN_2000dd10(0x4c,0x14);
  FUN_2000dd10(0x55,0x19);
  FUN_2000dd10(0x7f,0x14);
  FUN_2000dd10(99,0x16);
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x41,0x30);
  FUN_2000dd10(0x55,0x14);
  FUN_2000dd10(0x49,10);
  FUN_2000dd10(0x42,0);
  FUN_2000dd10(0x44,0xd);
  FUN_2000dd10(0x4a,0x12);
  FUN_2000dd10(0x4b,9);
  FUN_2000dd10(0x4c,0x30);
  FUN_2000dd10(0x5a,0xd);
  FUN_2000dd10(0x5f,0x1e);
  FUN_2000dd10(0x5b,5);
  FUN_2000dd10(0x5e,0xf);
  FUN_2000dd10(0x7f,0xd);
  FUN_2000dd10(0x48,0xdd);
  FUN_2000dd10(0x4f,3);
  FUN_2000dd10(0x5a,0x29);
  FUN_2000dd10(0x5b,0x47);
  FUN_2000dd10(0x5c,0x81);
  FUN_2000dd10(0x5d,0x40);
  FUN_2000dd10(0x71,0xdc);
  FUN_2000dd10(0x70,7);
  FUN_2000dd10(0x73,0);
  FUN_2000dd10(0x72,8);
  FUN_2000dd10(0x75,0xdc);
  FUN_2000dd10(0x74,7);
  FUN_2000dd10(0x77,0);
  FUN_2000dd10(0x76,8);
  FUN_2000dd10(0x7f,0x10);
  FUN_2000dd10(0x4c,0xd0);
  FUN_2000dd10(0x7f,0);
  FUN_2000dd10(0x4f,99);
  FUN_2000dd10(0x4e,0);
  FUN_2000dd10(0x52,99);
  FUN_2000dd10(0x51,0);
  FUN_2000dd10(0x5a,0x10);
  FUN_2000dd10(0x77,0x4f);
  FUN_2000dd10(0x47,1);
  FUN_2000dd10(0x5b,0x40);
  FUN_2000dd10(0x66,0x13);
  FUN_2000dd10(0x67,0xf);
  FUN_2000dd10(0x78,1);
  FUN_2000dd10(0x79,0x9c);
  FUN_2000dd10(0x55,2);
  FUN_2000dd10(0x23,0x70);
  FUN_2000dd10(0x22,1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cc38 @ 2000cc38 */


void FUN_2000cc38(undefined4 param_1,undefined4 param_2,int param_3)

{
  int iVar1;
  int iVar2;
  
  DAT_040003e8 = (undefined1)param_1;
  DAT_040003e9 = (undefined1)((uint)param_1 >> 8);
  DAT_040003ea = (undefined1)param_2;
  DAT_040003eb = (undefined1)((uint)param_2 >> 8);
  if (param_3 != 0) {
    iVar1 = __aeabi_uidiv(param_1,0x32);
    iVar2 = __aeabi_uidiv(param_2,0x32);
    FUN_2000dd10(0x48,iVar1 - 1U & 0xff);
    FUN_2000dd10(0x49,(iVar1 - 1U & 0xffff) >> 8);
    FUN_2000dd10(0x4a,iVar2 - 1U & 0xff);
    FUN_2000dd10(0x4b,(iVar2 - 1U & 0xffff) >> 8);
    FUN_2000dd10(0x47,1);
    if (-1 < (int)((uint)(byte)DAT_04000366 << 0x18)) {
      FUN_2000b840(2,0);
    }
    DAT_04000364 = 0;
    DAT_04000362 = 0;
    return;
  }
  DAT_04000d5d = DAT_04000d5d | 2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000ccc8 @ 2000ccc8 */


void FUN_2000ccc8(undefined4 param_1,undefined4 param_2)

{
  DAT_04000d5d = DAT_04000d5d | 2;
  DAT_040003e8 = (char)param_1;
  DAT_040003e9 = (char)((uint)param_1 >> 8);
  DAT_040003ea = (char)param_2;
  DAT_040003eb = (char)((uint)param_2 >> 8);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000ccec @ 2000ccec */


void FUN_2000ccec(void)

{
  int iVar1;
  int iVar2;
  
  if ((int)((uint)DAT_04000d5d << 0x1e) < 0) {
    iVar1 = __aeabi_uidiv(CONCAT11(DAT_040003e9,DAT_040003e8),0x32);
    iVar2 = __aeabi_uidiv(CONCAT11(DAT_040003eb,DAT_040003ea),0x32);
    FUN_2000dd10(0x48,iVar1 - 1U & 0xff);
    FUN_2000dd10(0x49,(iVar1 - 1U & 0xffff) >> 8);
    FUN_2000dd10(0x4a,iVar2 - 1U & 0xff);
    FUN_2000dd10(0x4b,(iVar2 - 1U & 0xffff) >> 8);
    FUN_2000dd10(0x47,1);
    DAT_04000d5d = DAT_04000d5d & 0xfd;
    if (-1 < (int)((uint)(byte)DAT_04000366 << 0x18)) {
      FUN_2000b840(2,0);
    }
    DAT_04000364 = 0;
    DAT_04000362 = 0;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cd7c @ 2000cd7c */


undefined4 FUN_2000cd7c(void)

{
  if ((DAT_04000d5d & 1) != 0) {
    FUN_20008318();
    FUN_2000ccec();
    FUN_2000c698();
  }
  FUN_2000c37c();
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cda0 @ 2000cda0 */


void FUN_2000cda0(void)

{
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x46,0x9b);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cdbc @ 2000cdbc */


void FUN_2000cdbc(void)

{
  FUN_2000dd10(0x7f,0xc);
  FUN_2000dd10(0x55,DAT_04000575);
  FUN_2000dd10(0x66,DAT_04000576);
  FUN_2000dd10(0x53,DAT_04000577);
  FUN_2000dd10(0x4e,DAT_04000578);
  FUN_2000dd10(0x5f,DAT_04000579);
  FUN_2000dd10(0x5b,DAT_0400057a);
  FUN_2000dd10(0x7f,5);
  FUN_2000dd10(0x6e,DAT_0400057b);
  FUN_2000dd10(0x7f,9);
  FUN_2000dd10(0x72,DAT_0400057c);
  FUN_2000dd10(0x7f,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000ce28 @ 2000ce28 */


void FUN_2000ce28(void)

{
  wdt_feed();
  __aeabi_memclr(&DAT_040003e8,4);
  FUN_2000ce68();
  FUN_2000cc38(*(undefined2 *)(&DAT_04000d76 + (uint)DAT_04000d74 * 6),
               *(undefined2 *)(&DAT_04000d78 + (uint)DAT_04000d74 * 6),1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000ce68 @ 2000ce68 */


void FUN_2000ce68(void)

{
  int iVar1;
  uint uVar2;
  byte bVar3;
  
  bVar3 = 0;
  DAT_04000d5d = DAT_04000d5d & 0xfe;
  wdt_feed();
  FUN_200073a8(0,0xe,1);
  delay_ms(1);
  FUN_200073a8(0,0xe);
  delay_ms(1);
  FUN_200073a8(1,0xf,0);
  delay_ms(1);
  FUN_200073a8(1,0xf);
  delay_ms(1);
  FUN_2000dd10(0x3a,0x5a);
  delay_ms(10);
  FUN_2000c91c();
  delay_ms(1);
  do {
    delay_us(1000);
    iVar1 = FUN_2000dc50(0x6c);
    bVar3 = bVar3 + 1;
    if (iVar1 == 0x80) {
      if (bVar3 < 0x3c) goto LAB_2000cf0c;
      break;
    }
  } while (bVar3 < 0x3c);
  FUN_2000dd10(0x7f,0x14);
  FUN_2000dd10(0x6c,0);
  FUN_2000dd10(0x7f,0);
LAB_2000cf0c:
  FUN_2000dd10(0x22,0);
  FUN_2000dd10(0x55,0);
  FUN_2000dd10(0x7f,0);
  FUN_2000dd10(0x40,0);
  FUN_2000c574(0,1);
  uVar2 = FUN_2000dc50(0x40);
  FUN_2000dd10(0x40,uVar2 | 0x80);
  FUN_2000c890(1);
  FUN_2000dc50(2);
  FUN_2000dc50(3);
  FUN_2000dc50(4);
  FUN_2000dc50(5);
  FUN_2000dc50(6);
  FUN_2000dd10(0x68,1);
  DAT_04000d5d = DAT_04000d5d | 1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cf80 @ 2000cf80 */


void FUN_2000cf80(void)

{
  FUN_2000ddf0();
  delay_ms(100);
  FUN_2000ce28();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cf94 @ 2000cf94 */


void FUN_2000cf94(void)

{
  FUN_2000dd10(0x3b,0xb6);
  FUN_200073a8(0,0xe,1);
  DAT_04000d5d = DAT_04000d5d & 0xfe;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cfb8 @ 2000cfb8 */


void FUN_2000cfb8(uint param_1,int param_2,uint param_3,uint param_4)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar3 = param_1 + param_2;
  uVar2 = param_4;
  for (; param_1 < uVar3; param_1 = param_1 + 1) {
    uVar1 = (param_1 << 0x15) >> 0x18;
    uVar2 = param_1 & 7;
    param_3 = (uint)(byte)(&DAT_040022fa)[uVar1] | 1 << uVar2;
    (&DAT_040022fa)[uVar1] = (char)param_3;
  }
  settings_mark_dirty(0x100,0,param_3,uVar2,param_4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000cfec @ 2000cfec */


void FUN_2000cfec(uint param_1,int param_2,int param_3,uint param_4)

{
  uint uVar1;
  uint uVar2;
  uint uVar3;
  
  uVar3 = param_1 + param_2;
  uVar2 = param_4;
  for (; param_1 < uVar3; param_1 = param_1 + 1) {
    uVar1 = (param_1 << 0x15) >> 0x18;
    uVar2 = param_1 & 7;
    param_3 = 1 << uVar2;
    (&DAT_040022fa)[uVar1] = (&DAT_040022fa)[uVar1] & ~(byte)param_3;
  }
  settings_mark_dirty(0x100,0,param_3,uVar2,param_4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d020 @ 2000d020 */


uint FUN_2000d020(undefined4 param_1,int param_2,int param_3,uint param_4)

{
  uint uVar1;
  uint uVar2;
  int iVar3;
  uint uVar4;
  bool bVar5;
  
  if (DAT_04000448 != param_2) {
    if (DAT_04000454 != param_2) {
      DAT_04000444 = 0;
      DAT_04000438 = 0xffff;
      DAT_0400044c = 0;
      DAT_04000448 = 0;
      DAT_04000431 = 0;
    }
    DAT_04000432 = 0;
    return (uint)(DAT_04000454 == param_2);
  }
  uVar1 = FUN_20006f20(param_1);
  uVar2 = FUN_20006f7c(param_1);
  if (uVar2 < param_2 + param_4) {
    param_4 = uVar2 - param_2 & 0xff;
  }
  bVar5 = uVar1 == 0;
  do {
    if (bVar5) {
      return 0;
    }
    bVar5 = uVar2 == 0;
  } while (bVar5);
  if (param_2 == 0) {
    DAT_04000450 = uVar1 & 0xffffff00;
    DAT_04000444 = uVar1 - DAT_04000450;
    iVar3 = FUN_2000b7e8(DAT_04000450,&DAT_04001523);
    if (iVar3 != 0) goto LAB_2000d074;
LAB_2000d0a4:
    uVar4 = 2;
  }
  else {
LAB_2000d074:
    DAT_04000438 = FUN_20005988(param_3,param_4,DAT_04000438);
    if (param_4 + DAT_04000444 < 0x100) {
      DAT_04000432 = '\0';
      memcpy(&DAT_04001523 + DAT_04000444,param_3,param_4);
      DAT_04000444 = DAT_04000444 + param_4;
      uVar4 = 1;
    }
    else {
      memcpy(&DAT_04001523 + DAT_04000444,param_3,0x100 - DAT_04000444);
      uVar4 = FUN_20006cd4(DAT_0400044c * 0x100 + DAT_04000450,&DAT_04001523,0x100);
      if (uVar4 == 1) {
        DAT_0400044c = DAT_0400044c + 1;
        memcpy(&DAT_04001523,(0x100 - DAT_04000444) + param_3,param_4 - (0x100 - DAT_04000444));
        DAT_04000444 = param_4 - (0x100 - DAT_04000444);
      }
    }
    iVar3 = DAT_04000444;
    if (param_2 + param_4 < uVar2) {
      if (uVar4 != 1) {
        return uVar4;
      }
    }
    else {
      if (DAT_04000444 + 2U < 0x101) {
        (&DAT_04001523)[DAT_04000444] = (undefined1)DAT_04000438;
        (&DAT_04001524)[iVar3] = DAT_04000438._1_1_;
        memcpy(iVar3 + 0x4001525,uVar1 + uVar2 + 2,0xfe - iVar3);
      }
      else if (DAT_04000432 == '\0') {
        memcpy(&DAT_04001523 + DAT_04000444,&DAT_04000438,0x100 - DAT_04000444);
        uVar4 = FUN_20006cd4(DAT_0400044c * 0x100 + DAT_04000450,&DAT_04001523,0x100);
        if (uVar4 != 1) {
          return uVar4;
        }
        DAT_04000432 = '\x01';
        DAT_04000431 = (char)DAT_04000444 + 2;
        DAT_0400044c = DAT_0400044c + 1;
        memcpy(&DAT_04001523,&DAT_04000438 + (2 - (uint)DAT_04000431));
        uVar4 = (uint)DAT_04000431;
        memcpy(0x4001525 - uVar4,((uVar1 + uVar2) - uVar4) + 2,uVar4 + 0xfe);
        goto LAB_2000d0a4;
      }
      uVar1 = FUN_20006cd4(DAT_0400044c * 0x100 + DAT_04000450,&DAT_04001523,0x100);
      if (uVar1 != 1) {
        return uVar1;
      }
      DAT_04000444 = 0;
      DAT_04000438 = 0xffff;
      DAT_0400044c = 0;
      DAT_04000448 = 0;
      DAT_04000454 = 0;
      DAT_04000432 = '\0';
      uVar4 = 1;
    }
    if (param_2 + param_4 < uVar2) {
      DAT_04000454 = DAT_04000448;
      DAT_04000448 = DAT_04000448 + param_4;
    }
  }
  return uVar4;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d210 @ 2000d210 */


void FUN_2000d210(undefined1 param_1)

{
  DAT_04001b9d = param_1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d21c @ 2000d21c */


uint FUN_2000d21c(uint param_1,uint param_2,int param_3,int param_4,uint param_5)

{
  uint uVar1;
  int iVar2;
  int iVar3;
  int iVar4;
  undefined4 uVar5;
  int iVar6;
  uint uVar7;
  uint uVar8;
  
  uVar1 = 0;
  uVar8 = 0;
  if (DAT_04000464 == param_3) {
    if (param_2 < param_3 + param_5) {
      param_5 = param_2 - param_3 & 0xff;
    }
    for (uVar7 = 0; uVar7 < CONCAT11(DAT_04001b9c,DAT_04001b9b) + uVar1; uVar7 = uVar7 + 1) {
      iVar6 = uVar7 * 0xe;
      if ((*(ushort *)(&DAT_04001623 + iVar6) & 0x7fff) == param_1) {
        if (DAT_04000434 == '\0' && param_3 == 0) {
          DAT_04000435 = '\0';
          DAT_04000468 = 0;
          iVar2 = FUN_20008054(param_2 + 2);
          if (iVar2 == 0) {
            DAT_04000434 = 0;
            return 0;
          }
          if (*(short *)(&DAT_0400162b + uVar7 * 0xe) != 0) {
            iVar3 = read_u32_le();
            iVar4 = read_u32_le(&DAT_0400162d + iVar6);
            write_u32_le(iVar3 + (iVar4 + 2U & 0xffffff00) + 0x100,&DAT_04001b9e);
            uVar5 = read_u32_le(&DAT_04001627 + iVar6);
            FUN_20006dbc(*(undefined2 *)(&DAT_04001625 + iVar6),uVar5);
          }
          write_u32_le(param_2,&DAT_0400162d + iVar6);
          (&DAT_0400162b)[iVar6] = (char)iVar2;
          (&DAT_0400162c)[iVar6] = (char)((uint)iVar2 >> 8);
          settings_mark_dirty(0x80,uVar7 & 0xff);
          DAT_04000434 = '\x01';
        }
        uVar1 = FUN_200070ac(param_1);
        uVar7 = FUN_20007108(param_1);
        DAT_0400043a = FUN_20005988(param_4,param_5,DAT_0400043a);
        if (param_3 == 0) {
          DAT_04000460 = uVar1 & 0xffffff00;
          DAT_04000458 = uVar1 - DAT_04000460;
          iVar6 = FUN_2000b7e8(DAT_04000460,&DAT_04001523);
          if (iVar6 == 0) {
            return 2;
          }
        }
        if (param_5 + DAT_04000458 < 0x100) {
          DAT_04000434 = '\0';
          DAT_04000435 = '\0';
          memcpy(&DAT_04001523 + DAT_04000458,param_4,param_5);
          DAT_04000458 = DAT_04000458 + param_5;
          uVar8 = 1;
        }
        else {
          memcpy(&DAT_04001523 + DAT_04000458,param_4,0x100 - DAT_04000458);
          uVar8 = FUN_20006cd4(DAT_0400045c * 0x100 + DAT_04000460,&DAT_04001523,0x100);
          if (uVar8 == 1) {
            DAT_0400045c = DAT_0400045c + 1;
            memcpy(&DAT_04001523,(0x100 - DAT_04000458) + param_4,param_5 - (0x100 - DAT_04000458));
            DAT_04000458 = param_5 - (0x100 - DAT_04000458);
          }
        }
        iVar6 = DAT_04000458;
        if (uVar7 <= param_3 + param_5) {
          if (DAT_04000458 + 2U < 0x101) {
            (&DAT_04001523)[DAT_04000458] = (undefined1)DAT_0400043a;
            (&DAT_04001524)[iVar6] = DAT_0400043a._1_1_;
            memcpy(iVar6 + 0x4001525,uVar1 + uVar7 + 2,0xfe - iVar6);
            uVar8 = FUN_20006cd4(DAT_0400045c * 0x100 + DAT_04000460,&DAT_04001523,0x100);
            if (uVar8 != 1) {
              return uVar8;
            }
            DAT_04000458 = 0;
            DAT_0400043a = 0xffff;
            DAT_04000460 = 0;
            DAT_0400045c = 0;
            DAT_04000464 = 0;
            DAT_04000468 = 0;
            DAT_04000435 = '\0';
            DAT_04000434 = '\0';
            uVar8 = 1;
          }
          else {
            memcpy(&DAT_04001523 + DAT_04000458,&DAT_0400043a,0x100 - DAT_04000458);
            if (DAT_04000435 == '\0') {
              memcpy(&DAT_04001523 + DAT_04000458,&DAT_0400043a,0x100 - DAT_04000458);
              uVar8 = FUN_20006cd4(DAT_0400045c * 0x100 + DAT_04000460,&DAT_04001523,0x100);
              if (uVar8 == 1) {
                DAT_04000435 = 1;
                DAT_04000433 = (char)DAT_04000458 + 2;
                DAT_0400045c = DAT_0400045c + 1;
                memcpy(&DAT_04001523,&DAT_0400043a + (2 - (uint)DAT_04000433));
                uVar8 = (uint)DAT_04000433;
                memcpy(0x4001525 - uVar8,((uVar1 + uVar7) - uVar8) + 2,uVar8 + 0xfe);
                return 2;
              }
              return uVar8;
            }
            uVar8 = FUN_20006cd4(DAT_0400045c * 0x100 + DAT_04000460,&DAT_04001523,0x100);
            if (uVar8 != 1) {
              return uVar8;
            }
            DAT_04000458 = 0;
            DAT_0400043a = 0xffff;
            DAT_04000460 = 0;
            DAT_0400045c = 0;
            DAT_04000464 = 0;
            DAT_04000468 = 0;
            DAT_04000435 = '\0';
            DAT_04000434 = '\0';
            uVar8 = 1;
          }
          goto LAB_2000d510;
        }
        break;
      }
      if ((*(ushort *)(&DAT_04001623 + iVar6) & 0x7fff) == 0) {
        uVar1 = uVar1 + 1 & 0xffff;
      }
    }
    if (uVar8 == 1) {
LAB_2000d510:
      if (param_3 + param_5 < param_2) {
        DAT_04000468 = DAT_04000464;
        DAT_04000464 = DAT_04000464 + param_5;
      }
    }
  }
  else {
    if (DAT_04000468 != param_3) {
      DAT_04000458 = 0;
      DAT_0400043a = 0xffff;
      DAT_0400045c = 0;
      DAT_04000464 = 0;
      DAT_04000433 = 0;
    }
    uVar8 = (uint)(DAT_04000468 == param_3);
    DAT_04000434 = '\0';
    DAT_04000435 = '\0';
  }
  return uVar8;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d53c @ 2000d53c */


undefined8 FUN_2000d53c(uint param_1,int param_2)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  undefined4 local_20;
  
  local_20 = 0;
  if (((param_1 - 1 < 0x7fff) && (iVar1 = FUN_20007c98(param_1), iVar1 == 0)) &&
     (CONCAT11(DAT_04001b9c,DAT_04001b9b) < 100)) {
    uVar3 = 0;
    do {
      if ((*(ushort *)(&DAT_04001623 + uVar3 * 0xe) & 0x7fff) == 0) {
        iVar1 = FUN_20008054(param_2 + 2);
        if (iVar1 != 0) {
          iVar2 = uVar3 * 0xe;
          (&DAT_04001623)[iVar2] = (char)(param_1 & 0x7fff);
          (&DAT_04001624)[iVar2] = (char)((param_1 & 0x7fff) >> 8);
          (&DAT_04001625)[iVar2] = (char)iVar1;
          (&DAT_04001626)[iVar2] = (char)((uint)iVar1 >> 8);
          write_u32_le(param_2,&DAT_04001627 + iVar2);
          iVar1 = CONCAT11(DAT_04001b9c,DAT_04001b9b) + 1;
          DAT_04001b9b = (undefined1)iVar1;
          DAT_04001b9c = (undefined1)((uint)iVar1 >> 8);
          settings_mark_dirty(0x80,uVar3 & 0xff);
          local_20 = 1;
        }
        break;
      }
      uVar3 = uVar3 + 1 & 0xffff;
    } while (uVar3 < 100);
  }
  return CONCAT44(local_20,local_20);
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d5f0 @ 2000d5f0 */


uint FUN_2000d5f0(uint param_1,uint param_2,int param_3,int param_4,uint param_5)

{
  int iVar1;
  int iVar2;
  uint uVar3;
  int iVar4;
  int iVar5;
  int iVar6;
  uint uVar7;
  
  if (((uint)DAT_04000d99 & 1 << (param_1 & 0xff)) == 0) {
    return 0;
  }
  if (DAT_04000428 != param_3) {
    if (DAT_0400042c != param_3) {
      DAT_0400041c = 0;
      DAT_04000418 = 0xffff;
      DAT_04000424 = 0;
      DAT_04000428 = 0;
      DAT_04000414 = 0;
    }
    DAT_04000415 = 0;
    DAT_04000416 = 0;
    return (uint)(DAT_0400042c == param_3);
  }
  if (param_2 < param_3 + param_5) {
    param_5 = param_2 - param_3 & 0xff;
  }
  if (DAT_04000415 == '\0' && param_3 == 0) {
    iVar1 = FUN_20008054(param_2 + 2);
    DAT_0400042c = 0;
    DAT_04000416 = '\0';
    if (iVar1 == 0) {
      DAT_04000415 = 0;
      DAT_04000416 = 0;
      DAT_0400042c = 0;
      return 0;
    }
    iVar2 = param_1 * 0x164 + 0x4000c49;
    uVar3 = read_u32_le();
    iVar6 = param_1 * 0x164 + 0x4000c4d;
    if (uVar3 != 0) {
      iVar4 = read_u32_le();
      iVar5 = read_u32_le(iVar6);
      write_u32_le(iVar4 + (iVar5 + 2U & 0xffffff00) + 0x100,&DAT_04001b9e);
      FUN_20006dbc(uVar3 >> 8,iVar5 + 2);
      write_u32_le(0,iVar2);
      write_u32_le(0,iVar6);
      settings_mark_dirty(0x80,0);
    }
    write_u32_le(iVar1 << 8,iVar2);
    write_u32_le(param_2,iVar6);
    settings_mark_dirty(0x10,param_1 - 1 & 0xff);
    DAT_04000415 = '\x01';
  }
  uVar3 = FUN_20007270(param_1);
  DAT_04000418 = FUN_20005988(param_4,param_5,DAT_04000418);
  if (param_3 == 0) {
    DAT_04000420 = uVar3 & 0xffffff00;
    DAT_0400041c = uVar3 - DAT_04000420;
    iVar1 = FUN_2000b7e8(DAT_04000420,&DAT_04001523);
    if (iVar1 != 0) goto LAB_2000d704;
LAB_2000d730:
    uVar7 = 2;
  }
  else {
LAB_2000d704:
    if (param_5 + DAT_0400041c < 0x100) {
      DAT_04000415 = '\0';
      DAT_04000416 = '\0';
      memcpy(&DAT_04001523 + DAT_0400041c,param_4,param_5);
      DAT_0400041c = DAT_0400041c + param_5;
      uVar7 = 1;
    }
    else {
      memcpy(&DAT_04001523 + DAT_0400041c,param_4,0x100 - DAT_0400041c);
      uVar7 = FUN_20006cd4(DAT_04000424 * 0x100 + DAT_04000420,&DAT_04001523,0x100);
      if (uVar7 == 1) {
        DAT_04000424 = DAT_04000424 + 1;
        memcpy(&DAT_04001523,(0x100 - DAT_0400041c) + param_4,param_5 - (0x100 - DAT_0400041c));
        DAT_0400041c = param_5 - (0x100 - DAT_0400041c);
      }
    }
    iVar1 = DAT_0400041c;
    if (param_3 + param_5 < param_2) {
      if (uVar7 != 1) {
        return uVar7;
      }
    }
    else {
      if (DAT_0400041c + 2U < 0x101) {
        (&DAT_04001523)[DAT_0400041c] = (undefined1)DAT_04000418;
        (&DAT_04001524)[iVar1] = DAT_04000418._1_1_;
        memcpy(iVar1 + 0x4001525,uVar3 + param_2 + 2,0xfe - iVar1);
        uVar3 = FUN_20006cd4(DAT_04000424 * 0x100 + DAT_04000420,&DAT_04001523,0x100);
        if (uVar3 != 1) {
          return uVar3;
        }
        DAT_0400042c = DAT_04000428;
      }
      else {
        if (DAT_04000416 == '\0') {
          memcpy(&DAT_04001523 + DAT_0400041c,&DAT_04000418,0x100 - DAT_0400041c);
          uVar7 = FUN_20006cd4(DAT_04000424 * 0x100 + DAT_04000420,&DAT_04001523,0x100);
          if (uVar7 != 1) {
            return uVar7;
          }
          DAT_04000416 = '\x01';
          DAT_04000414 = (char)DAT_0400041c + 2;
          DAT_04000424 = DAT_04000424 + 1;
          memcpy(&DAT_04001523,&DAT_04000418 + (2 - (uint)DAT_04000414));
          uVar7 = (uint)DAT_04000414;
          memcpy(0x4001525 - uVar7,((uVar3 + param_2) - uVar7) + 2,uVar7 + 0xfe);
          goto LAB_2000d730;
        }
        uVar3 = FUN_20006cd4(DAT_04000424 * 0x100 + DAT_04000420,&DAT_04001523,0x100);
        if (uVar3 != 1) {
          return uVar3;
        }
        DAT_0400042c = 0;
      }
      uVar7 = 1;
      DAT_04000428 = 0;
      DAT_04000424 = 0;
      DAT_0400041c = 0;
      DAT_04000418 = 0xffff;
      DAT_04000415 = '\0';
      DAT_04000416 = '\0';
    }
    if (param_3 + param_5 < param_2) {
      DAT_0400042c = DAT_04000428;
      DAT_04000428 = DAT_04000428 + param_5;
    }
  }
  return uVar7;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d8c4 @ 2000d8c4 */


void FUN_2000d8c4(int param_1)

{
  char cVar1;
  
  if (((uint)DAT_04000d48 << 0x1d) >> 0x1e == 2) {
    if (DAT_040004dc != -1) {
      cVar1 = -1;
LAB_2000d906:
      DAT_040004dc = cVar1;
      FUN_2000da80();
      return;
    }
  }
  else if (param_1 == 1) {
    cVar1 = DAT_04000c59;
    if (DAT_04000c59 != DAT_040004dc) goto LAB_2000d906;
  }
  else if (param_1 == 2) {
    cVar1 = DAT_04000329;
    if (((uint)DAT_04000d3e << 0x1a) >> 0x1e != 2) {
      cVar1 = DAT_04000d73 + -1;
    }
    if (DAT_040004dc != cVar1) goto LAB_2000d906;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000d928 @ 2000d928 */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000d93a) */
/* WARNING: Removing unreachable block (ram,0x2000d93a) */

void FUN_2000d928(uint param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  byte *pbVar1;
  int iVar2;
  uint uVar3;
  uint uVar4;
  undefined *puVar5;
  
  uVar4 = 0;
  uVar3 = (uint)DAT_040004db;
  if (param_1 < 8) {
    pbVar1 = &switchD_2000d93a::switchdataD_2000d93f + param_1;
  }
  else {
    pbVar1 = &DAT_2000d947;
  }
  puVar5 = (undefined *)((uint)*pbVar1 * 2);
  switch(param_1) {
  case 0:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      puVar5 = &DAT_040004dd + iVar2;
      (&DAT_040004e0)[iVar2] = 0xff;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0xff;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0xff;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 1:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0xff;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0;
      (&DAT_040004e3)[iVar2] = 0;
      puVar5 = &DAT_040004e0 + iVar2;
      (&DAT_040004e4)[iVar2] = 0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 2:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0xff;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 3:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0xff;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 4:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0xff;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0xff;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 5:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0xff;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0xff;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 6:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0xff;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0xff;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  case 7:
    for (; uVar4 < uVar3; uVar4 = uVar4 + 1 & 0xff) {
      iVar2 = uVar4 * 9;
      (&DAT_040004e0)[iVar2] = 0;
      (&DAT_040004e1)[iVar2] = 0;
      (&DAT_040004e2)[iVar2] = 0;
      (&DAT_040004e3)[iVar2] = 0;
      (&DAT_040004e4)[iVar2] = 0;
      puVar5 = (undefined *)0x0;
      (&DAT_040004e5)[iVar2] = 0;
    }
    break;
  default:
    return;
  }
  FUN_2000678c(&DAT_040004dd,uVar3,DAT_040004da,puVar5,param_4);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000da80 @ 2000da80 */


void FUN_2000da80(int param_1)

{
  if (param_1 == 3) goto LAB_2000daa0;
  if (param_1 < 4) {
    if (((param_1 == 0) || (param_1 == 1)) || (param_1 == 2)) goto LAB_2000daa0;
  }
  else {
    if (param_1 == 4) goto LAB_2000daa0;
    if (param_1 == 5) {
      param_1 = 6;
      goto LAB_2000daa0;
    }
  }
  param_1 = 7;
LAB_2000daa0:
  FUN_2000d928(param_1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000daac @ 2000daac */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_2000daac(void)

{
  int iVar1;
  
  if (_DAT_04002d63 <= CONCAT11(DAT_04002d6a,DAT_04002d69)) {
    DAT_04002d69 = 0;
    DAT_04002d6a = 0;
    _DAT_04002d6b = _DAT_04002d6b + CONCAT11(DAT_04002d66,DAT_04002d65);
    if (0xfe < _DAT_04002d6b) {
      _DAT_04002d6b = 0;
      if (DAT_04002d67 < 9) {
        DAT_04002d67 = DAT_04002d67 + 1;
      }
      else {
        DAT_04002d67 = 0;
      }
      iVar1 = (uint)DAT_04002d67 * 8;
      _DAT_04002d63 = *(ushort *)(&DAT_2000f244 + iVar1);
      DAT_04002d65 = (undefined1)*(undefined2 *)(&DAT_2000f246 + iVar1);
      DAT_04002d66 = (undefined1)((ushort)*(undefined2 *)(&DAT_2000f246 + iVar1) >> 8);
      memcpy(&DAT_04002d5b,&DAT_04002d5f,4);
      DAT_04002d5f = (&DAT_2000f248)[iVar1];
      DAT_04002d60 = (&DAT_2000f249)[iVar1];
      DAT_04002d61 = (&DAT_2000f24a)[iVar1];
      DAT_04002d62 = (&DAT_2000f24b)[iVar1];
      DAT_04002d68 = 1;
    }
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000db54 @ 2000db54 */


void FUN_2000db54(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  
  __aeabi_memclr(&DAT_04003148,0xf,param_3,param_4,param_4);
  if (DAT_04000d5e == '\x04') {
    uVar1 = 0xf;
  }
  else {
    uVar1 = 6;
  }
  FUN_2000dc9c(0x16,&DAT_04003148,uVar1);
  if ((int)((uint)DAT_04003148 * 0x4000000) < 0) {
    DAT_0400055c = 0;
  }
  else {
    DAT_0400055c = DAT_0400055c + 1;
    DAT_04000560 = DAT_04000560 + 1;
  }
  DAT_04000547 = (byte)(((uint)DAT_04003148 << 0x1c) >> 0x1f);
  DAT_04000546 = '\x01';
  if ((DAT_04003149 == -0x49) || (DAT_04003149 == -0x41)) {
    DAT_04000546 = '\0';
  }
  if ((DAT_0400055c == 3) || (DAT_04000546 == '\x01')) {
    FUN_2000cf80();
    DAT_0400055c = 0;
    DAT_04000564 = DAT_04000564 + 1;
  }
  if ((char)DAT_04003148 < '\0') {
    DAT_0400054a = CONCAT11(DAT_0400314b,DAT_0400314a);
    DAT_0400054c = CONCAT11(DAT_0400314d,DAT_0400314c);
  }
  if (DAT_04000d5e == '\x04') {
    if (DAT_04000544 == '\0') {
      if (DAT_04000548 == 0) {
        DAT_04000544 = '\x01';
        DAT_04000548 = 3000;
        DAT_04000550 = __aeabi_uidiv(DAT_04000550,3000);
        DAT_04000554 = __aeabi_uidiv(DAT_04000554,3000);
        DAT_04000558 = __aeabi_uidiv(DAT_04000558,3000);
      }
      else {
        DAT_04000548 = DAT_04000548 + -1;
        DAT_04000550 = (uint)DAT_0400314e + DAT_04000550;
        DAT_04000554 = (uint)DAT_0400314f + DAT_04000554;
        DAT_04000558 = (uint)DAT_04003156 + DAT_04000558;
      }
      return;
    }
  }
  else if (DAT_04000d5e == '\0') {
    DAT_04000544 = '\0';
    DAT_04000548 = 3000;
    DAT_04000550 = 0;
    DAT_04000554 = 0;
    DAT_04000558 = 0;
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000dc50 @ 2000dc50 */


undefined1 FUN_2000dc50(uint param_1)

{
  undefined1 uVar1;
  
  FUN_200073a8(0,0xe);
  FUN_2000dd5c(param_1 & 0x7f,1);
  delay_us(3);
  FUN_2000dd5c(0xff,1);
  uVar1 = DAT_04002ef0;
  delay_us(1);
  FUN_200073a8(0,0xe,1);
  delay_us(2);
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000dc9c @ 2000dc9c */


void FUN_2000dc9c(uint param_1,undefined1 *param_2,uint param_3,undefined4 param_4)

{
  FUN_200073a8(0,0xe,0,param_4,param_4);
  FUN_20001750(&DAT_40001000,0,0xc,0x181);
  FUN_2000dd5c(param_1 & 0x7f,1);
  delay_us(3);
  FUN_20001750(&DAT_40001000,0,0xc,400);
  FUN_20007334(0,0xc);
  FUN_2000dd5c(*param_2,param_3 & 0xff,1);
  memcpy(param_2,&DAT_04002ef0,param_3);
  FUN_200073a8(0,0xe,1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000dd10 @ 2000dd10 */


void FUN_2000dd10(uint param_1,undefined4 param_2)

{
  FUN_200073a8(0,0xe);
  FUN_20001750(&DAT_40001000,0,0xc,0x181);
  FUN_2000dd5c(param_1 | 0x80,1);
  delay_us(3);
  FUN_2000dd5c(param_2,1);
  FUN_200073a8(0,0xe,1);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000dd5c @ 2000dd5c */


undefined4 FUN_2000dd5c(undefined1 param_1,undefined4 param_2,int param_3)

{
  int iVar1;
  
  __aeabi_memclr(&DAT_04002ef0);
  DAT_040030f0 = &DAT_04002ff0;
  DAT_040030f4 = &DAT_04002ef0;
  DAT_040030f8 = DAT_040030f8 | 0x100000;
  DAT_0400053c = '\0';
  DAT_04002ff0 = param_1;
  DAT_040030fc = param_2;
  FUN_200022c0(&DAT_40089000,&DAT_04003100);
  iVar1 = DAT_04000398;
  DAT_04000d53 = DAT_04000d53 & 0xfd;
  if (param_3 != 0) {
    while (DAT_0400053c == '\0') {
      wdt_feed();
      if (5 < (uint)(DAT_04000398 - iVar1)) {
        DAT_04000d53 = DAT_04000d53 | 2;
        DAT_04000540 = DAT_04000540 + 1;
        return 1;
      }
    }
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000ddf0 @ 2000ddf0 */


void FUN_2000ddf0(void)

{
  undefined4 uVar1;
  
  FUN_20001750(&DAT_40001000,0,0xb,0x181);
  FUN_20001750(&DAT_40001000,0,0xc,0x181);
  FUN_20001750(&DAT_40001000,0,0xd,0x181);
  FUN_2000044c(0x20f);
  FUN_20001a38(0x1000e);
  uVar1 = FUN_2000063c(0xe);
  FUN_20001fb0(&DAT_04003130);
  DAT_04003133 = 1;
  DAT_04003132 = 1;
  DAT_04003138 = 8000000;
  FUN_20001fe8(&DAT_40089000,&DAT_04003130,uVar1);
  FUN_2000212c(&DAT_40089000,&DAT_04003100,&LAB_200080bc_1,0);
  DAT_0400053c = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000de84 @ 2000de84 */


void FUN_2000de84(int param_1)

{
  uint uVar1;
  
  if (param_1 == 0) {
    uVar1 = DAT_40008004;
    uVar1 = uVar1 & 0xfffffffe;
  }
  else {
    if (param_1 != 1) {
      return;
    }
    uVar1 = DAT_40008004;
    uVar1 = uVar1 | 1;
  }
  DAT_40008004 = uVar1;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000dea4 @ 2000dea4 */


void FUN_2000dea4(void)

{
  byte bVar1;
  uint uVar2;
  uint uVar3;
  int iVar4;
  
  uVar2 = 0;
  do {
    iVar4 = uVar2 * 0x2c;
    uVar2 = uVar2 + 1 & 0xff;
    (&DAT_04001ba9)[iVar4] = 0;
  } while (uVar2 < 0xd);
  __aeabi_memclr(&DAT_04000c40,0x18);
  uVar2 = 0;
  do {
    (&DAT_04000b44)[uVar2] = 0;
    uVar3 = uVar2 + 1 & 0xff;
    (&DAT_04000bc9)[uVar2] = 0;
    bVar1 = DAT_04000430;
    uVar2 = uVar3;
  } while (uVar3 < 0xd);
  DAT_0400035e = 0;
  DAT_0400032f = 0;
  DAT_0400046c = 0;
  __aeabi_memclr(&DAT_0400036f,3);
  DAT_04000430 = bVar1 | 9;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000df1c @ 2000df1c */


/* WARNING: Function: __ARM_common_switch8 replaced with injection: switch8_r3 */
/* WARNING (jumptable): Removing unreachable block (ram,0x2000df38) */
/* WARNING: Removing unreachable block (ram,0x2000df38) */

undefined4 FUN_2000df1c(undefined4 param_1,byte param_2)

{
  undefined2 uVar1;
  undefined4 uVar2;
  uint uVar3;
  uint uVar4;
  uint uVar5;
  
  uVar5 = (uint)DAT_04000d73;
  uVar3 = uVar5 + 1;
  uVar4 = uVar5 - 1;
  uVar2 = 0;
  switch(param_1) {
  default:
    goto switchD_2000df38_caseD_0;
  case 1:
    while( true ) {
      uVar4 = uVar3 & 0xff;
      if (uVar5 == uVar4) {
        return 0;
      }
      if (uVar4 == 8) {
        return 0;
      }
      if ((DAT_04000d99 >> uVar4 & 1) != 0) break;
      uVar3 = uVar4 + 1;
    }
    DAT_04000d74 = (byte)uVar3 - 1;
    DAT_04000d73 = (byte)uVar3;
    FUN_20006d48(0);
    uVar3 = 0;
    do {
      FUN_2000580c(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar3 * 0x23);
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 3);
    break;
  case 2:
    while( true ) {
      uVar3 = uVar4 & 0xff;
      if (uVar5 == uVar3) {
        return 0;
      }
      if (uVar3 == 0) {
        return 0;
      }
      if ((DAT_04000d99 >> uVar3 & 1) != 0) break;
      uVar4 = uVar3 - 1;
    }
    DAT_04000d74 = (byte)uVar4 - 1;
    DAT_04000d73 = (byte)uVar4;
    FUN_20006d48(0);
    uVar3 = 0;
    do {
      FUN_2000580c(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar3 * 0x23);
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 3);
    goto LAB_2000dfc4;
  case 3:
    if ((DAT_04000d99 >> (uint)param_2 & 1) == 0) {
      return 0;
    }
    DAT_04000d74 = param_2 - 1;
    DAT_04000d73 = param_2;
    FUN_20006d48();
    uVar3 = 0;
    do {
      FUN_2000580c(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar3 * 0x23);
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 3);
    break;
  case 4:
    while( true ) {
      uVar3 = uVar3 & 0xff;
      if (uVar3 == 8) {
        uVar3 = 1;
      }
      if (uVar5 == uVar3) {
        return 0;
      }
      if ((DAT_04000d99 >> uVar3 & 1) != 0) break;
      uVar3 = uVar3 + 1;
    }
    DAT_04000d73 = (byte)uVar3;
    DAT_04000d74 = DAT_04000d73 - 1;
    FUN_2000577c(0);
    FUN_20006d48();
    uVar3 = 0;
    do {
      FUN_2000580c(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar3 * 0x23);
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 3);
    goto LAB_2000e04e;
  case 5:
    while( true ) {
      uVar4 = uVar4 & 0xff;
      if (uVar4 == 0) {
        uVar4 = 7;
      }
      if (uVar5 == uVar4) {
        return 0;
      }
      if ((DAT_04000d99 >> uVar4 & 1) != 0) break;
      uVar4 = uVar4 - 1;
    }
    DAT_04000d73 = (byte)uVar4;
    DAT_04000d74 = DAT_04000d73 - 1;
    FUN_20006d48(0);
    uVar3 = 0;
    do {
      FUN_2000580c(&DAT_04000db6 + (uint)DAT_04000d74 * 0x164 + uVar3 * 0x23);
      uVar3 = uVar3 + 1 & 0xff;
    } while (uVar3 < 3);
LAB_2000dfc4:
    FUN_2000577c(0);
LAB_2000e04e:
    uVar1 = CONCAT11(DAT_04000379,DAT_04000378);
    goto LAB_2000dfcc;
  }
  FUN_2000577c(0);
  uVar1 = CONCAT11(DAT_04000379,DAT_04000378);
LAB_2000dfcc:
  FUN_2000cc38(CONCAT11(DAT_04000377,DAT_04000376),uVar1,0);
  FUN_2000dea4();
  memcpy(&DAT_04000a66,&DAT_04000e40 + (uint)DAT_04000d74 * 0x164,0xd0);
  FUN_2000c034(2,0);
  uVar2 = 1;
switchD_2000df38_caseD_0:
  return uVar2;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e0fc @ 2000e0fc */


void FUN_2000e0fc(char *param_1)

{
  int iVar1;
  uint uVar2;
  
  uVar2 = 0;
  do {
    iVar1 = uVar2 * 0x23;
    if (*param_1 != (&DAT_04002d8d)[iVar1]) {
      if (param_1[3] == (&DAT_04002d8f)[iVar1]) {
        FUN_20005f80(&DAT_04002d8d + iVar1,0);
      }
    }
    uVar2 = uVar2 + 1 & 0xff;
  } while (uVar2 < 3);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e130 @ 2000e130 */


void FUN_2000e130(void)

{
  DAT_4000004c = 1;
  FUN_20000430();
  clock_init();
  DAT_40000630 = 0x200000;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e154 @ 2000e154 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

undefined4 FUN_2000e154(void)

{
  uint uVar1;
  ushort uVar2;
  int iVar3;
  undefined4 in_r3;
  
  uVar2 = _DAT_04000d5b;
  if ((DAT_04000d59 & 1) == 0) {
    return 1;
  }
  if (_DAT_04000d5b == 0) {
    DAT_0400039c = 96000;
    DAT_40009008 = 0;
    FUN_20000aa4(&DAT_040003a0);
    FUN_20000ae0(&DAT_40009000,&DAT_040003a0);
    DAT_04000cdc = 0;
    DAT_04000cdd = 0;
    DAT_04000cd8 = 0x2edff;
    DAT_04000cde = 0;
    DAT_04000cdf = 0;
    DAT_04000ce0 = 1;
    FUN_20000b44(&DAT_40009000,&DAT_040003c8,0);
    FUN_20000b64(&DAT_40009000,0,&DAT_04000cd8);
    uVar1 = DAT_40009004;
    DAT_40009004 = uVar1 | 1;
    _DAT_04000d5b = _DAT_04000d5b + 1;
  }
  else {
    if (199 < _DAT_04000d5b) {
      DAT_04000cdc = 1;
      _DAT_04000d5b = _DAT_04000d5b + 1;
      iVar3 = __aeabi_uidiv(DAT_0400039c,0x14,DAT_0400039c,uVar2,in_r3);
      DAT_04000cd8 = iVar3 + -1;
      FUN_20000b64(&DAT_40009000,0,&DAT_04000cd8);
      DAT_04000d59 = 0;
      _DAT_04000d5b = 0;
      return 1;
    }
    iVar3 = DAT_40009008;
    DAT_0400039c = iVar3 + DAT_0400039c >> 1;
    _DAT_04000d5b = _DAT_04000d5b + 1;
  }
  return 0;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e22c @ 2000e22c */


void FUN_2000e22c(void)

{
  FUN_200009e8(&DAT_40008000);
  FUN_200009e8(&DAT_40009000);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e244 @ 2000e244 */


void FUN_2000e244(void)

{
  FUN_2000044c(0x21c);
  FUN_20000aa4(&DAT_040003a0);
  FUN_20000ae0(&DAT_40008000,&DAT_040003a0);
  DAT_04000cd0 = 1;
  DAT_04000cd1 = 0;
  DAT_04000ccc = 95999;
  DAT_04000cd2 = 0;
  DAT_04000cd3 = 0;
  DAT_04000cd4 = 1;
  FUN_20000b44(&DAT_40008000,&DAT_040003a8,0);
  FUN_20000b64(&DAT_40008000,0,&DAT_04000ccc);
  FUN_2000de84(0);
  DAT_04000d59 = 1;
  DAT_04000d5b = 0;
  DAT_04000d5c = 0;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e2b0 @ 2000e2b0 */


int FUN_2000e2b0(int param_1,int param_2,int param_3,int param_4)

{
  int iVar1;
  
  iVar1 = __aeabi_uidiv(param_2,param_4 * 3);
  *(int *)(param_1 + 0x1c) = iVar1 + -1;
  return param_2 * param_3 * 2 + 7;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e2d0 @ 2000e2d0 */


int FUN_2000e2d0(int param_1)

{
  if (param_1 != 0) {
    param_1 = param_1 + 0x27d8;
  }
  return param_1;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e2e0 @ 2000e2e0 */


void FUN_2000e2e0(void)

{
  undefined4 in_r3;
  
  FUN_200065dc(&DAT_04002d8d + (uint)DAT_040004e6 * 0x23,&DAT_04002e82,DAT_040004e7,in_r3,in_r3);
  FUN_20006330(&DAT_04002d8d + (uint)DAT_040004e6 * 0x23,&DAT_04002e82,DAT_040004e7);
  FUN_20006888(&DAT_04002d8d + (uint)DAT_040004e6 * 0x23,&DAT_04002e82,
               &DAT_04002d9d + (uint)DAT_040004e6 * 0x23,&DAT_040004e8,DAT_040004e7);
  FUN_2000c418(&DAT_040004e8,DAT_040004e7,DAT_04000356,0);
  FUN_2000678c(&DAT_040004e8,DAT_040004e7,DAT_040004e6);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e348 @ 2000e348 */


void FUN_2000e348(undefined4 param_1,undefined4 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  int iVar2;
  undefined4 uStack_18;
  undefined4 uStack_14;
  
  DAT_4000004c = 1;
  uStack_18 = param_3;
  uStack_14 = param_4;
  FUN_2000044c(0x11c);
  FUN_20000aa4(&uStack_18);
  FUN_20000ae0(&DAT_40048000,&uStack_18);
  uVar1 = FUN_20000514();
  iVar2 = FUN_20006de8();
  if (iVar2 != 0) {
    uVar1 = __aeabi_uidiv(uVar1,1000);
    FUN_20000d94(&DAT_40048000,uVar1);
    return;
  }
  do {
                    /* WARNING: Do nothing block with infinite loop */
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e3c4 @ 2000e3c4 */


void FUN_2000e3c4(int param_1)

{
  uint uVar1;
  
  if (param_1 != 0) {
    uVar1 = DAT_40000680;
    DAT_40000680 = uVar1 | 0x100;
    FUN_20004f34(&DAT_4000e000);
    FUN_20004f84(&DAT_4000e000,1,89999,&LAB_2000e394_1);
    DAT_e000e100 = 0x100;
    return;
  }
  FUN_20004ecc(&DAT_4000e000);
  FUN_2000518c(8);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e414 @ 2000e414 */


/* WARNING: Globals starting with '_' overlap smaller symbols at the same address */

void FUN_2000e414(void)

{
  undefined2 uVar1;
  int iVar2;
  uint uVar3;
  int iVar4;
  undefined4 uVar5;
  undefined4 in_r3;
  char cVar6;
  
  DAT_04000d42 = 0;
  DAT_04000d43 = 0;
  DAT_04000d44 = 0;
  DAT_04000d48 = DAT_04000d48 & 0xf7;
  DAT_04000d45 = 0;
  DAT_04000d3e = DAT_04000d3e & 0xcf;
  DAT_04000d5d = DAT_04000d5d & 0xf5;
  DAT_04000d63 = 0x55;
  memcpy(&DAT_040014ae,0x28000,0x56,in_r3,in_r3);
  if (CONCAT11(DAT_040014af,DAT_040014ae) != 0x56) {
    memcpy(&DAT_040014ae,&DAT_2000ea44,0x56);
  }
  memcpy(&DAT_04000d66,0x28100,0xb);
  if (CONCAT11(DAT_04000d67,DAT_04000d66) == 0xb) {
    uVar3 = FUN_20005954(&DAT_04000d66,9);
    if (uVar3 != CONCAT11(DAT_04000d70,DAT_04000d6f)) goto LAB_2000e498;
  }
  else {
LAB_2000e498:
    memcpy(&DAT_04000d66,&DAT_2000ea9a,0xb);
  }
  memcpy(&DAT_04000d71,0x28200,0x24);
  memcpy(&DAT_04000d95,0x28300,0x70b);
  if ((CONCAT11(DAT_04000d98,DAT_04000d97) != 0x70b) ||
     (uVar3 = FUN_20005954(&DAT_04000d97,0x709), uVar3 != CONCAT11(DAT_04000d96,DAT_04000d95))) {
    memcpy(&DAT_04000d95,&DAT_2000eac9,0x70b);
    cVar6 = '\x05';
    do {
      cVar6 = cVar6 + -1;
      settings_mark_dirty(0x10,cVar6);
    } while (cVar6 != '\0');
  }
  if (CONCAT11(DAT_04000d72,DAT_04000d71) == 0x24) {
    uVar3 = FUN_20005954(&DAT_04000d71,0x22);
    if (uVar3 == _DAT_04000d93) goto LAB_2000e56a;
  }
  memcpy(&DAT_04000d71,&DAT_2000eaa5,0x24);
  iVar4 = (uint)DAT_04000d74 * 6;
  iVar2 = (uint)(byte)(&DAT_04000d75)[iVar4] * 6 + (uint)DAT_04000d74 * 0x164;
  uVar1 = *(undefined2 *)(&DAT_04000d95 + iVar2 + 0x8b);
  (&DAT_04000d76)[iVar4] = (char)uVar1;
  (&DAT_04000d77)[iVar4] = (char)((ushort)uVar1 >> 8);
  uVar1 = *(undefined2 *)(&DAT_04000d95 + iVar2 + 0x8d);
  (&DAT_04000d78)[iVar4] = (char)uVar1;
  (&DAT_04000d79)[iVar4] = (char)((ushort)uVar1 >> 8);
  settings_mark_dirty(8,0);
LAB_2000e56a:
  memcpy(&DAT_04001623,0x29000,0x581);
  uVar3 = FUN_20005954(&DAT_04001623,0x57f);
  if (uVar3 != CONCAT11(DAT_04001ba3,DAT_04001ba2)) {
    FUN_20006da0();
    __aeabi_memclr(&DAT_04001623,0x581);
    cVar6 = 'd';
    do {
      cVar6 = cVar6 + -1;
      settings_mark_dirty(0x80,cVar6);
    } while (cVar6 != '\0');
  }
  memcpy(&DAT_040022fa,0x28e00,0x2f);
  uVar3 = FUN_20005954(&DAT_040022fa,0x2d);
  if (uVar3 != _DAT_04002327) {
    __aeabi_memclr(&DAT_040022fa,0x2f);
    __aeabi_memclr(&DAT_04001623,0x581);
    memcpy(&DAT_04000d71,&DAT_2000eaa5,0x24);
    memcpy(&DAT_04000d95,&DAT_2000eac9,0x70b);
    FUN_20006da0();
    settings_mark_dirty(8,0);
    cVar6 = '\x05';
    do {
      cVar6 = cVar6 + -1;
      settings_mark_dirty(0x10,cVar6);
    } while (cVar6 != '\0');
    cVar6 = 'd';
    do {
      cVar6 = cVar6 + -1;
      settings_mark_dirty(0x80,cVar6);
    } while (cVar6 != '\0');
  }
  FUN_20005728();
  FUN_2000824c();
  FUN_200079f8();
  FUN_20006d48();
  uVar5 = FUN_2000b780(10,100);
  FUN_2000b780(1,uVar5);
  DAT_04000d3e = (DAT_04000d3e & 0xf0) + 2;
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e6b4 @ 2000e6b4 */


void FUN_2000e6b4(int param_1,int param_2,undefined4 param_3,undefined4 param_4)

{
  uint uVar1;
  undefined4 *local_20 [3];
  
  local_20[2] = (undefined4 *)param_4;
  local_20[0] = &DAT_40002000;
  local_20[1] = &DAT_40003000;
  if (param_2 == 0) {
    FUN_200011fc(local_20[param_1]);
    if (param_1 == 0) {
      uVar1 = DAT_40000680;
      uVar1 = uVar1 & 0xfffffffb;
    }
    else {
      if (param_1 != 1) {
        return;
      }
      uVar1 = DAT_40000680;
      uVar1 = uVar1 & 0xfffffff7;
    }
    DAT_40000680 = uVar1;
    return;
  }
  if (param_1 == 0) {
    uVar1 = DAT_40000680;
    uVar1 = uVar1 | 4;
  }
  else {
    if (param_1 != 1) goto LAB_2000e6e6;
    uVar1 = DAT_40000680;
    uVar1 = uVar1 | 8;
  }
  DAT_40000680 = uVar1;
LAB_2000e6e6:
  FUN_20001240(local_20[param_1]);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e714 @ 2000e714 */


void FUN_2000e714(void)

{
  ushort uVar1;
  int iVar2;
  int iVar3;
  uint uVar4;
  char cVar5;
  
  uVar4 = 0;
  do {
    iVar2 = uVar4 * 2;
    uVar1 = *(ushort *)(&DAT_04002d76 + iVar2);
    iVar3 = uVar1 + 1;
    (&DAT_04002d76)[iVar2] = (char)iVar3;
    (&DAT_04002d77)[iVar2] = (char)((uint)iVar3 >> 8);
    if ((uint)(byte)(&DAT_04002d73)[uVar4] < (uint)uVar1) {
      (&DAT_04002d76)[iVar2] = 0;
      (&DAT_04002d77)[iVar2] = 0;
      if ((&DAT_04002d6d)[uVar4] == '\x01') {
        if ((byte)(&DAT_04002d70)[uVar4] < 0x18) {
          cVar5 = (&DAT_04002d70)[uVar4] + 1;
        }
        else {
          cVar5 = '\0';
        }
      }
      else {
        if ((&DAT_04002d6d)[uVar4] != '\x02') goto LAB_2000e768;
        if ((&DAT_04002d70)[uVar4] == '\0') {
          cVar5 = '\x17';
        }
        else {
          cVar5 = (&DAT_04002d70)[uVar4] + -1;
        }
      }
      (&DAT_04002d70)[uVar4] = cVar5;
    }
LAB_2000e768:
    uVar4 = uVar4 + 1 & 0xff;
    if (2 < uVar4) {
      return;
    }
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e778 @ 2000e778 */


void FUN_2000e778(void)

{
  uint uVar1;
  uint uVar2;
  undefined1 uStack_28;
  undefined1 local_27;
  undefined4 local_24;
  int local_20;
  undefined4 local_1c;
  
  DAT_40000630 = 0x100000;
  uVar2 = FUN_2000063c(7);
  DAT_e000e100 = 1;
  uVar1 = DAT_4000c000;
  if ((int)((uVar1 & 0xc) << 0x1d) < 0) {
    FUN_20004fe8(&DAT_4000c000,4);
  }
  FUN_20005040(&uStack_28);
  local_20 = (uVar2 >> 2) << 1;
  local_27 = 1;
  local_1c = 0;
  local_24 = 0;
  FUN_2000508c(&DAT_4000c000,&uStack_28);
  return;
}


/* ---------------------------------------------------------------------- */
/* wdt_feed @ 2000e7d0 */


/* feeds watchdog @0x4000C000 with IRQs masked */

void wdt_feed(void)

{
  disableIRQinterrupts();
  FUN_20005114(&DAT_4000c000);
  enableIRQinterrupts();
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_2000e7e4 @ 2000e7e4 */


void FUN_2000e7e4(undefined4 param_1,undefined4 param_2)

{
  DAT_40000220 = 0x80;
  FUN_200065a0(&DAT_2000f440,param_1,param_2);
  return;
}


