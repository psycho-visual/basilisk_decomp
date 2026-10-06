/*
 * FWUpdaterDLL.dll (FW updater native helper, built 2021-02-18, MSVC 14 + static MFC)
 * Razer-authored code only: entry points 0x10002500-0x10005AFF (the 37 exports and their helpers).
 * Everything else in the image is statically-linked MFC / ATL / UCRT; see FWUpdaterDLL.dll.c for the full decompilation.
 * Generated with Ghidra 11.4.2 headless (tools/ghidra/ExportDecomp.java), symbols from native/symbols.tsv.
 */

#include "FWUpdaterDLL.dll.h"

/* ---------------------------------------------------------------------- */
/* delay @ 10002500 */


void __cdecl delay(float param_1)

{
  BOOL BVar1;
  double in_XMM0_Qa;
  double dVar2;
  LARGE_INTEGER local_1c;
  LARGE_INTEGER local_14;
  LARGE_INTEGER local_c;
  
                    /* 0x2500  37  delay */
  BVar1 = QueryPerformanceFrequency(&local_1c);
  if (BVar1 != 0) {
    QueryPerformanceCounter(&local_14);
    do {
      QueryPerformanceCounter(&local_c);
      FUN_1015a000(local_c.s.LowPart - local_14._0_4_,
                   (local_c.s.HighPart - local_14._4_4_) -
                   (uint)(local_c.s.LowPart < local_14.s.LowPart));
      dVar2 = in_XMM0_Qa;
      FUN_1015a000(local_1c.s.LowPart,local_1c.s.HighPart);
      in_XMM0_Qa = (in_XMM0_Qa / dVar2) * 10.0 * 10.0 * 10.0 * 10.0 * 10.0 * 10.0;
    } while (in_XMM0_Qa < (double)(param_1 * 10.0 * 10.0 * 10.0));
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_report_crc @ 100025d0 */


/* XOR of report bytes [3..88] (buffer incl. report id) stored at [89] */

void __cdecl razer_report_crc(int param_1)

{
  undefined4 local_c;
  undefined1 local_5;
  
  local_5 = 0;
  for (local_c = 2; local_c < 0x58; local_c = local_c + 1) {
    local_5 = *(byte *)(param_1 + local_c) ^ local_5;
  }
  *(byte *)(param_1 + 0x58) = local_5;
  return;
}


/* ---------------------------------------------------------------------- */
/* razer_feature_transact @ 10002630 */


/* HidD_SetFeature(91 bytes) then poll HidD_GetFeature until txn/class/id echo with status 0x02
   (OK); returns status */

void __cdecl razer_feature_transact(int param_1,undefined4 *param_2,int param_3,int param_4)

{
  char cVar1;
  char cVar2;
  char cVar3;
  char cVar4;
  char cVar5;
  int iVar6;
  undefined4 *puVar7;
  int local_78;
  int local_68;
  undefined4 local_64;
  char local_5d;
  char local_5c;
  uint local_8;
  
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  cVar1 = *(char *)((int)param_2 + 2);
  cVar2 = *(char *)(param_2 + 2);
  cVar3 = *(char *)((int)param_2 + 7);
  if ((param_1 != -1) && (param_1 != 0)) {
    cVar4 = '\0';
    for (local_78 = 0; local_78 < 3; local_78 = local_78 + 1) {
      delay((float)param_4);
      local_68 = 0;
      while (local_68 < 3) {
        local_68 = local_68 + 1;
        razer_report_crc((int)param_2 + 1);
        cVar4 = HidD_SetFeature(param_1,param_2,0x5b);
        if (cVar4 != '\0') break;
        delay((float)param_4);
        if (local_68 == 3) goto LAB_1000282c;
      }
      local_68 = 0;
      _memset(&local_64,0,0x5b);
      local_64._0_1_ = *(undefined1 *)param_2;
      do {
        if ((param_3 <= local_68) || (cVar4 == '\0')) break;
        delay((float)param_4);
        local_68 = local_68 + 1;
        cVar5 = HidD_GetFeature(param_1,&local_64,0x5b);
        if (((cVar5 != '\0') &&
            (((cVar1 == local_64._2_1_ && (cVar2 == local_5c)) && (cVar3 == local_5d)))) &&
           ((local_64._1_1_ != '\x01' && (local_64._1_1_ != '\0')))) {
          if (local_64._1_1_ == '\x02') {
            puVar7 = &local_64;
            for (iVar6 = 0x16; iVar6 != 0; iVar6 = iVar6 + -1) {
              *param_2 = *puVar7;
              puVar7 = puVar7 + 1;
              param_2 = param_2 + 1;
            }
            *(undefined2 *)param_2 = *(undefined2 *)puVar7;
            *(undefined1 *)((int)param_2 + 2) = *(undefined1 *)((int)puVar7 + 2);
            goto LAB_1000282c;
          }
          break;
        }
      } while (local_68 != param_3);
    }
  }
LAB_1000282c:
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* hid_get_caps @ 10002840 */


/* HidD_GetPreparsedData + HidP_GetCaps (result unused) */

void __cdecl hid_get_caps(undefined4 param_1)

{
  char cVar1;
  int iVar2;
  undefined4 local_4c;
  undefined1 local_48 [64];
  uint local_8;
  
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  cVar1 = HidD_GetPreparsedData(param_1,&local_4c,1);
  if ((cVar1 != '\0') && (iVar2 = HidP_GetCaps(local_4c,local_48), iVar2 == 0x110000)) {
    HidD_FreePreparsedData(local_4c);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetDevPIDInBootloader @ 10002900 */


void __cdecl GetDevPIDInBootloader(int param_1,float param_2)

{
  undefined1 local_8c [4];
  undefined4 local_88;
  int local_84;
  undefined2 local_7c;
  undefined4 local_78;
  undefined1 local_72;
  undefined1 local_71;
  undefined1 local_70;
  undefined1 local_1c [12];
  undefined2 local_10;
  uint local_8;
  
                    /* 0x2900  18  GetDevPIDInBootloader */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  if (((param_2 == 1.0) || (param_2 == 1.1)) || (param_2 == 3.0)) {
    local_7c = 0;
    local_84 = WinUsb_Initialize(param_1,&local_88);
    if (local_84 == 0) {
      local_84 = 0;
    }
    else {
      local_84 = WinUsb_GetDescriptor(local_88,1,0,0x409,local_1c,0x12,local_8c);
      if (local_84 == 0) {
        WinUsb_Free(local_88);
      }
      else {
        local_7c = local_10;
        WinUsb_Free(local_88);
      }
    }
  }
  else if (param_2 == 2.0) {
    _memset(&local_78,0,0x5b);
    local_78._0_1_ = 0;
    local_78._1_1_ = 0;
    local_72 = 9;
    local_71 = 0x10;
    local_70 = 0x80;
    razer_feature_transact(param_1,&local_78,5,2);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetDevManufacturer @ 10002a80 */


uint __cdecl GetDevManufacturer(undefined4 param_1)

{
  uint uVar1;
  undefined1 local_14 [4];
  undefined1 local_10 [3];
  byte bStack_d;
  undefined4 local_c;
  int local_8;
  
                    /* 0x2a80  17  GetDevManufacturer */
  local_8 = WinUsb_Initialize(param_1,&local_c);
  if (local_8 == 0) {
    uVar1 = 0;
  }
  else {
    local_8 = WinUsb_GetDescriptor(local_c,3,0,0x409,local_10,4,local_14);
    if (local_8 == 0) {
      uVar1 = WinUsb_Free(local_c);
      uVar1 = uVar1 & 0xffffff00;
    }
    else {
      WinUsb_Free(local_c);
      uVar1 = (uint)bStack_d;
    }
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* EnterDeviceMode @ 10002af0 */


void __cdecl EnterDeviceMode(int param_1,undefined1 param_2)

{
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined1 uStack_5b;
  undefined1 local_5a;
  uint local_8;
  
                    /* 0x2af0  12  EnterDeviceMode */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 2;
  local_5d = 0;
  local_5c = 4;
  uStack_5b = param_2;
  local_5a = 0;
  razer_feature_transact(param_1,(undefined4 *)&local_64,5,2);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetFWVersion @ 10002b70 */


void __cdecl GetFWVersion(int param_1,undefined4 *param_2,char param_3)

{
  int iVar1;
  undefined4 *puVar2;
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_62;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined4 local_5b [20];
  uint local_8;
  
                    /* 0x2b70  21  GetFWVersion */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  if (param_3 == '\x04') {
    local_5c = 0x93;
  }
  else {
    local_62 = 0;
    local_5c = 0x87;
  }
  local_5d = 0;
  local_5e = 8;
  local_63 = 0;
  local_64 = 0;
  iVar1 = razer_feature_transact(param_1,(undefined4 *)&local_64,5,0x14);
  if (iVar1 == 2) {
    _memset(param_2,0,0x50);
    puVar2 = local_5b;
    for (iVar1 = 0x14; iVar1 != 0; iVar1 = iVar1 + -1) {
      *param_2 = *puVar2;
      puVar2 = puVar2 + 1;
      param_2 = param_2 + 1;
    }
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetBootloaderHandle @ 10002c20 */


void __cdecl GetBootloaderHandle(undefined4 param_1,undefined4 param_2,short param_3,float param_4)

{
  char cVar1;
  short sVar2;
  undefined1 (*pauVar3) [16];
  CSimpleStringT<wchar_t,0> *pCVar4;
  WCHAR *in_stack_ffffff58;
  int iVar5;
  DWORD local_74;
  undefined1 local_70 [4];
  int local_6c;
  int local_68;
  int local_64;
  PSP_DEVICE_INTERFACE_DATA local_60;
  HANDLE local_5c;
  ULONG_PTR local_58;
  PSP_DEVICE_INTERFACE_DETAIL_DATA_W local_54;
  _SP_DEVINFO_DATA local_50;
  _SP_DEVICE_INTERFACE_DATA local_34;
  GUID local_18;
  uint local_8;
  
                    /* 0x2c20  16  GetBootloaderHandle */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  CStringT<>(&local_68);
  CStringT<>(&local_64);
  FUN_10006b30(&local_68,L"%04X");
  FUN_10006b30(&local_64,L"%04X");
  local_5c = (HANDLE)0x0;
  local_58 = 1;
  local_50.cbSize = 0x1c;
  local_18.Data1 = 0xc9348766;
  local_18.Data2 = 0xd27c;
  local_18.Data3 = 0x41ee;
  local_18.Data4[0] = 0xb2;
  local_18.Data4[1] = 0xbe;
  local_18.Data4[2] = 0xea;
  local_18.Data4[3] = 0x94;
  local_18.Data4[4] = '\x12';
  local_18.Data4[5] = 0xf7;
  local_18.Data4[6] = '+';
  local_18.Data4[7] = 'R';
  local_60 = (PSP_DEVICE_INTERFACE_DATA)SetupDiGetClassDevsW(&local_18,(PCWSTR)0x0,(HWND)0x0,0x12);
  local_74 = 0;
  do {
    if (local_58 != 1) {
LAB_10002f2b:
      SetupDiDestroyDeviceInfoList(local_60);
      FUN_10005e20(&local_64);
      FUN_10005e20(&local_68);
LAB_10002f4f:
      __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
      return;
    }
    local_34.cbSize = 0x1c;
    local_58 = SetupDiEnumDeviceInterfaces
                         (local_60,(PSP_DEVINFO_DATA)0x0,&local_18,local_74,&local_34);
    local_74 = local_74 + 1;
    if (local_58 == 0) {
      local_58 = 0;
      goto LAB_10002f2b;
    }
    local_70 = (undefined1  [4])0x0;
    local_58 = SetupDiGetDeviceInterfaceDetailW
                         (in_stack_ffffff58,local_60,(PSP_DEVICE_INTERFACE_DETAIL_DATA_W)&local_34,0
                          ,(PDWORD)0x0,(PSP_DEVINFO_DATA)local_70);
    local_54 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)FUN_10143a83((size_t)local_70);
    local_54->cbSize = 6;
    in_stack_ffffff58 = L"䖉莬걽甀謓끍\xe851ೖ\x14쒃위끅";
    local_58 = SetupDiGetDeviceInterfaceDetailW
                         (local_60,&local_34,local_54,(DWORD)local_70,(PDWORD)local_70,&local_50);
    if (local_58 == 0) {
      FUN_10143a68(local_54);
      local_54 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
    }
    CStringT<>(&local_6c,local_54->DevicePath);
    cVar1 = FUN_10005b10(&local_68,(char *)L"");
    if (cVar1 == '\0') {
LAB_10002f0b:
      FUN_10143a68(local_54);
      local_54 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
    }
    else {
      cVar1 = FUN_10005b10(&local_64,(char *)((int)L"atlTraceQI" + 0x17));
      if (cVar1 == '\0') goto LAB_10002f0b;
      iVar5 = 0;
      pauVar3 = (undefined1 (*) [16])FUN_10005fc0(&local_68);
      pCVar4 = FUN_10005d10((CSimpleStringT<wchar_t,0> *)&local_6c);
      iVar5 = FUN_10005d60(pCVar4,pauVar3,iVar5);
      if (iVar5 < 1) goto LAB_10002f0b;
      iVar5 = 0;
      pauVar3 = (undefined1 (*) [16])FUN_10005fc0(&local_64);
      pCVar4 = FUN_10005d10((CSimpleStringT<wchar_t,0> *)&local_6c);
      iVar5 = FUN_10005d60(pCVar4,pauVar3,iVar5);
      if (iVar5 < 1) goto LAB_10002f0b;
      in_stack_ffffff58 = local_54->DevicePath;
      local_5c = CreateFileW(in_stack_ffffff58,0xc0000000,3,(LPSECURITY_ATTRIBUTES)0x0,3,0x40000000,
                             (HANDLE)0x0);
      if ((local_5c == (HANDLE)0xffffffff) || (local_5c == (HANDLE)0x0)) {
        SetupDiDestroyDeviceInfoList(local_60);
        FUN_10143a68(local_54);
        local_54 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
        FUN_10005e20(&local_6c);
        FUN_10005e20(&local_64);
        FUN_10005e20(&local_68);
        goto LAB_10002f4f;
      }
      sVar2 = GetDevPIDInBootloader((int)local_5c,param_4);
      if (param_3 == sVar2) {
        FUN_10143a68(local_54);
        local_54 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
        SetupDiDestroyDeviceInfoList(local_60);
        FUN_10005e20(&local_6c);
        FUN_10005e20(&local_64);
        FUN_10005e20(&local_68);
        goto LAB_10002f4f;
      }
      CloseHandle(local_5c);
    }
    FUN_10005e20(&local_6c);
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* OpenDevice @ 10002f60 */


undefined4 __cdecl
OpenDevice(undefined4 param_1,undefined4 param_2,short param_3,float param_4,uint param_5)

{
  ushort *puVar1;
  ushort *puVar2;
  undefined4 uVar3;
  int local_c;
  int local_8;
  
                    /* 0x2f60  29  OpenDevice */
  CStringT<>(&local_c);
  CStringT<>(&local_8);
  FUN_10006b30(&local_c,L"%04X");
  FUN_10006b30(&local_8,L"%04X");
  puVar1 = (ushort *)FUN_10005fc0(&local_8);
  puVar2 = (ushort *)FUN_10005fc0(&local_c);
  uVar3 = open_hid_device(puVar2,puVar1,param_3,param_4,param_5);
  FUN_10005e20(&local_8);
  FUN_10005e20(&local_c);
  return uVar3;
}


/* ---------------------------------------------------------------------- */
/* CloseDevice @ 10003000 */


void __cdecl CloseDevice(HANDLE param_1)

{
                    /* 0x3000  3  CloseDevice */
  if ((param_1 != (HANDLE)0xffffffff) && (param_1 != (HANDLE)0x0)) {
    CloseHandle(param_1);
  }
  return;
}


/* ---------------------------------------------------------------------- */
/* open_hid_device @ 10003020 */


/* enumerate HID interfaces (or WinUSB GUID for BL 1.x/3.0) matching VID/PID[/bcd], picks MI/COL by
   report type flags, opens handle */

void __cdecl
open_hid_device(ushort *param_1,ushort *param_2,short param_3,float param_4,uint param_5)

{
  bool bVar1;
  char cVar2;
  short sVar3;
  uint uVar4;
  CSimpleStringT<wchar_t,0> *pCVar5;
  BOOL BVar6;
  DWORD DVar7;
  int *piVar8;
  wchar_t *pwVar9;
  undefined1 (*pauVar10) [16];
  int iVar11;
  DWORD local_f8;
  uint local_f4;
  undefined4 local_f0;
  undefined4 local_ec;
  int local_e8;
  DWORD local_e4;
  CSimpleStringT<wchar_t,0> *local_e0;
  CSimpleStringT<wchar_t,0> *local_dc;
  undefined4 local_d8;
  HANDLE local_d4;
  HANDLE local_d0;
  int local_cc;
  HANDLE local_c8;
  HANDLE local_c4;
  int local_c0;
  CSimpleStringT<wchar_t,0> *local_bc;
  CSimpleStringT<wchar_t,0> *local_b8;
  int local_b4;
  DWORD local_b0;
  int local_ac;
  CSimpleStringT<wchar_t,0> local_a8 [4];
  int local_a4;
  DWORD local_a0;
  DWORD local_9c;
  wchar_t *local_98;
  int local_94;
  int local_90;
  HDEVINFO local_8c;
  CSimpleStringT<wchar_t,0> local_88 [4];
  int local_84;
  HANDLE local_80;
  PSP_DEVICE_INTERFACE_DETAIL_DATA_W local_7c;
  _SP_DEVINFO_DATA local_78;
  _SP_DEVINFO_DATA local_5c;
  _SP_DEVICE_INTERFACE_DATA local_40;
  GUID local_24;
  uint local_14;
  void *local_10;
  undefined1 *puStack_c;
  int local_8;
  
  local_8 = 0xffffffff;
  puStack_c = &LAB_1015a0af;
  local_10 = ExceptionList;
  uVar4 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  ExceptionList = &local_10;
  local_80 = (HANDLE)0x0;
  local_ec = 0;
  local_a4 = 1;
  local_78.cbSize = 0x1c;
  local_14 = uVar4;
  CStringT<>(&local_94);
  local_8 = 0;
  FUN_10006b30(&local_94,L"%04X");
  local_f0 = 0;
  HidD_GetHidGuid(&local_24,uVar4);
  local_8c = SetupDiGetClassDevsW(&local_24,(PCWSTR)0x0,(HWND)0x0,0x12);
  local_a0 = 0;
LAB_100030cd:
  if (local_a4 != 1) {
    local_d8 = 0;
    local_8 = 0xffffffff;
    FUN_10005e20(&local_94);
LAB_100037d4:
    ExceptionList = local_10;
    __security_check_cookie(local_14 ^ (uint)&stack0xfffffffc);
    return;
  }
  local_40.cbSize = 0x1c;
  local_e4 = local_a0;
  local_a4 = SetupDiEnumDeviceInterfaces
                       (local_8c,(PSP_DEVINFO_DATA)0x0,&local_24,local_a0,&local_40);
  local_a0 = local_a0 + 1;
  local_9c = 0;
  SetupDiGetDeviceInterfaceDetailW
            (local_8c,&local_40,(PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0,0,&local_9c,&local_78);
  local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)FUN_10143a83(local_9c);
  local_7c->cbSize = 6;
  SetupDiGetDeviceInterfaceDetailW(local_8c,&local_40,local_7c,local_9c,&local_9c,&local_78);
  CStringT<>(local_88,local_7c->DevicePath);
  local_8._0_1_ = 1;
  CStringT<>(&local_90,(char *)L"");
  local_8._0_1_ = 2;
  CStringT<>(&local_84,(char *)((int)L"atlTraceRefcount" + 0x23));
  local_8._0_1_ = 3;
  iVar11 = 0;
  pauVar10 = (undefined1 (*) [16])&DAT_1019b2fc;
  pCVar5 = FUN_10005d10(local_88);
  local_ac = FUN_10005d60(pCVar5,pauVar10,iVar11);
  uVar4 = 4;
  iVar11 = local_ac + 4;
  piVar8 = &local_e8;
  pCVar5 = FUN_10005d10(local_88);
  local_e0 = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar5,piVar8,iVar11,uVar4);
  local_8._0_1_ = 4;
  local_dc = local_e0;
  FUN_10005e00(&local_90,local_e0);
  local_8._0_1_ = 3;
  FUN_10005e20(&local_e8);
  iVar11 = 0;
  pauVar10 = (undefined1 (*) [16])&DAT_1019b304;
  pCVar5 = FUN_10005d10(local_88);
  local_ac = FUN_10005d60(pCVar5,pauVar10,iVar11);
  uVar4 = 4;
  iVar11 = local_ac + 4;
  piVar8 = &local_c0;
  pCVar5 = FUN_10005d10(local_88);
  local_bc = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar5,piVar8,iVar11,uVar4);
  local_8._0_1_ = 5;
  local_b8 = local_bc;
  FUN_10005e00(&local_84,local_bc);
  local_8._0_1_ = 3;
  FUN_10005e20(&local_c0);
  if ((((param_1 != (ushort *)0x0) && (param_2 != (ushort *)0x0)) &&
      (bVar1 = FUN_10005b90(&local_90,param_1), bVar1)) &&
     (bVar1 = FUN_10005b90(&local_84,param_2), bVar1)) {
    local_80 = (HANDLE)0x0;
    local_80 = CreateFileW(local_7c->DevicePath,0,3,(LPSECURITY_ATTRIBUTES)0x0,3,0,(HANDLE)0x0);
    if ((local_80 == (HANDLE)0xffffffff) || (local_80 == (HANDLE)0x0)) {
      FUN_10143a68(local_7c);
      local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
      local_8._0_1_ = 2;
      FUN_10005e20(&local_84);
      local_8._0_1_ = 1;
      FUN_10005e20(&local_90);
      local_8 = (uint)local_8._1_3_ << 8;
      FUN_10005e20((int *)local_88);
      goto LAB_100030cd;
    }
    cVar2 = FUN_10005b50(&local_84,"1004");
    if ((((cVar2 != '\0') || (cVar2 = FUN_10005b50(&local_84,"1000"), cVar2 != '\0')) ||
        (cVar2 = FUN_10005b50(&local_84,"1007"), cVar2 != '\0')) &&
       (iVar11 = FUN_10005d60(local_88,(undefined1 (*) [16])L"COL01",0), 0 < iVar11)) {
      FUN_10143a68(local_7c);
      local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
      SetupDiDestroyDeviceInfoList(local_8c);
      local_c4 = local_80;
      local_8._0_1_ = 2;
      FUN_10005e20(&local_84);
      local_8._0_1_ = 1;
      FUN_10005e20(&local_90);
      local_8 = (uint)local_8._1_3_ << 8;
      FUN_10005e20((int *)local_88);
      local_8 = 0xffffffff;
      FUN_10005e20(&local_94);
      goto LAB_100037d4;
    }
    iVar11 = hid_get_caps(local_80);
    if (iVar11 != 0) {
      local_f4 = param_5 & 8;
      if ((param_5 & 8) == 0) {
        FUN_10143a68(local_7c);
        local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
        SetupDiDestroyDeviceInfoList(local_8c);
        local_d4 = local_80;
        local_8._0_1_ = 2;
        FUN_10005e20(&local_84);
        local_8._0_1_ = 1;
        FUN_10005e20(&local_90);
        local_8 = (uint)local_8._1_3_ << 8;
        FUN_10005e20((int *)local_88);
        local_8 = 0xffffffff;
        FUN_10005e20(&local_94);
      }
      else {
        sVar3 = GetDevPIDInBootloader((int)local_80,param_4);
        if (param_3 == sVar3) {
          FUN_10143a68(local_7c);
          local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
          SetupDiDestroyDeviceInfoList(local_8c);
          local_c8 = local_80;
          local_8._0_1_ = 2;
          FUN_10005e20(&local_84);
          local_8._0_1_ = 1;
          FUN_10005e20(&local_90);
          local_8 = (uint)local_8._1_3_ << 8;
          FUN_10005e20((int *)local_88);
          local_8 = 0xffffffff;
          FUN_10005e20(&local_94);
        }
        else {
          local_98 = (wchar_t *)0x0;
          local_b0 = 0;
          local_5c.cbSize = 0x1c;
          local_a4 = SetupDiEnumDeviceInfo(local_8c,local_a0 - 1,&local_5c);
          if (local_a4 != 0) {
            while (BVar6 = SetupDiGetDeviceRegistryPropertyW
                                     (local_8c,&local_5c,1,&local_f8,(PBYTE)local_98,local_b0,
                                      &local_b0), BVar6 == 0) {
              DVar7 = GetLastError();
              if (DVar7 == 0x7a) {
                if (local_98 != (wchar_t *)0x0) {
                  LocalFree(local_98);
                }
                local_98 = (wchar_t *)LocalAlloc(0x40,local_b0);
              }
            }
          }
          CStringT<>(local_a8,local_98);
          local_8._0_1_ = 6;
          LocalFree(local_98);
          iVar11 = 0;
          pwVar9 = L"REV_";
          pCVar5 = FUN_10005d10(local_a8);
          local_cc = FUN_10005d60(pCVar5,(undefined1 (*) [16])pwVar9,iVar11);
          FUN_10005c30(local_a8,&local_b4,local_cc + 4,4);
          bVar1 = FUN_10005bc0(&local_94,&local_b4);
          if (!bVar1) {
            CloseHandle(local_80);
            FUN_10005e20(&local_b4);
            local_8._0_1_ = 3;
            FUN_10005e20((int *)local_a8);
            goto LAB_10003783;
          }
          FUN_10143a68(local_7c);
          local_7c = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
          SetupDiDestroyDeviceInfoList(local_8c);
          local_d0 = local_80;
          FUN_10005e20(&local_b4);
          local_8._0_1_ = 3;
          FUN_10005e20((int *)local_a8);
          local_8._0_1_ = 2;
          FUN_10005e20(&local_84);
          local_8._0_1_ = 1;
          FUN_10005e20(&local_90);
          local_8 = (uint)local_8._1_3_ << 8;
          FUN_10005e20((int *)local_88);
          local_8 = 0xffffffff;
          FUN_10005e20(&local_94);
        }
      }
      goto LAB_100037d4;
    }
    CloseHandle(local_80);
  }
LAB_10003783:
  local_8._0_1_ = 2;
  FUN_10005e20(&local_84);
  local_8._0_1_ = 1;
  FUN_10005e20(&local_90);
  local_8 = (uint)local_8._1_3_ << 8;
  FUN_10005e20((int *)local_88);
  goto LAB_100030cd;
}


/* ---------------------------------------------------------------------- */
/* GetBLFWVERInBootloader @ 100037f0 */


void __cdecl GetBLFWVERInBootloader(undefined4 param_1,float param_2,undefined4 *param_3)

{
  undefined1 local_24 [4];
  undefined4 local_20;
  int local_1c;
  int local_18;
  undefined4 local_14;
  undefined4 local_10;
  undefined1 local_c;
  uint local_8;
  
                    /* 0x37f0  15  GetBLFWVERInBootloader */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  if (((param_2 == 1.0) || (param_2 == 1.1)) || (param_2 == 3.0)) {
    local_14 = 0;
    local_10 = 0;
    local_c = 0;
    *param_3 = 0;
    *(undefined1 *)(param_3 + 1) = 0;
    local_1c = WinUsb_Initialize(param_1,&local_20);
    if (local_1c == 0) {
      local_1c = 0;
    }
    else {
      local_1c = WinUsb_GetDescriptor(local_20,3,0,0x409,&local_14,9,local_24);
      if (local_1c == 0) {
        WinUsb_Free(local_20);
      }
      else {
        for (local_18 = 0; local_18 < 4; local_18 = local_18 + 1) {
          *(undefined1 *)((int)param_3 + local_18) = *(undefined1 *)((int)&local_10 + local_18);
        }
        WinUsb_Free(local_20);
      }
    }
  }
  else if (param_2 == 2.0) {
    *param_3 = 0;
    *(undefined1 *)(param_3 + 1) = 0;
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* DFUErase @ 10003910 */


void __cdecl DFUErase(int param_1,undefined4 param_2,undefined4 param_3)

{
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined1 uStack_5b;
  undefined1 local_5a;
  undefined1 uStack_59;
  undefined1 uStack_58;
  undefined1 uStack_57;
  undefined1 uStack_56;
  undefined1 uStack_55;
  undefined1 uStack_54;
  uint local_8;
  
                    /* 0x3910  6  DFUErase */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 8;
  local_5d = 0x10;
  local_5c = 1;
  uStack_5b = (undefined1)((uint)param_2 >> 0x18);
  local_5a = (undefined1)((uint)param_2 >> 0x10);
  uStack_59 = (undefined1)((uint)param_2 >> 8);
  uStack_58 = (undefined1)param_2;
  uStack_57 = (undefined1)((uint)param_3 >> 0x18);
  uStack_56 = (undefined1)((uint)param_3 >> 0x10);
  uStack_55 = (undefined1)((uint)param_3 >> 8);
  uStack_54 = (undefined1)param_3;
  razer_feature_transact(param_1,(undefined4 *)&local_64,5,2);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* DFUProgram @ 10003a70 */


void __cdecl DFUProgram(int param_1,byte param_2,undefined4 param_3,int param_4,uint *param_5)

{
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  byte bStack_5b;
  undefined1 local_5a;
  undefined1 uStack_59;
  undefined1 uStack_58;
  undefined1 uStack_57;
  uint local_56 [19];
  uint local_8;
  
                    /* 0x3a70  8  DFUProgram */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 8;
  local_5d = 0x10;
  local_5c = 2;
  bStack_5b = param_2;
  local_5a = (undefined1)((uint)param_3 >> 0x18);
  uStack_59 = (undefined1)((uint)param_3 >> 0x10);
  uStack_58 = (undefined1)((uint)param_3 >> 8);
  uStack_57 = (undefined1)param_3;
  FUN_1013cd50(local_56,param_5,(uint)param_2);
  razer_feature_transact(param_1,(undefined4 *)&local_64,5,param_4);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* DFUVerify @ 10003b80 */


void __cdecl DFUVerify(int param_1,byte param_2,undefined4 param_3,int param_4,uint *param_5)

{
  int iVar1;
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  byte bStack_5b;
  undefined1 local_5a;
  undefined1 uStack_59;
  undefined1 uStack_58;
  undefined1 uStack_57;
  uint local_56 [19];
  uint local_8;
  
                    /* 0x3b80  9  DFUVerify */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 5;
  local_5d = 0x10;
  local_5c = 0x83;
  bStack_5b = param_2;
  local_5a = (undefined1)((uint)param_3 >> 0x18);
  uStack_59 = (undefined1)((uint)param_3 >> 0x10);
  uStack_58 = (undefined1)((uint)param_3 >> 8);
  uStack_57 = (undefined1)param_3;
  iVar1 = razer_feature_transact(param_1,(undefined4 *)&local_64,5,param_4);
  if (iVar1 == 2) {
    *param_5 = 0;
    *(undefined1 *)(param_5 + 1) = 0;
    FUN_1013cd50(param_5,local_56,(uint)bStack_5b);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* DFUExit @ 10003ca0 */


void __cdecl DFUExit(int param_1)

{
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  uint local_8;
  
                    /* 0x3ca0  7  DFUExit */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 0;
  local_5d = 0x10;
  local_5c = 5;
  razer_feature_transact(param_1,(undefined4 *)&local_64,1,2);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* BackToDefult @ 10003d00 */


void __cdecl BackToDefult(int param_1)

{
  undefined4 local_64;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined1 uStack_5b;
  uint local_8;
  
                    /* 0x3d00  1  BackToDefult */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64._0_1_ = 0;
  local_64._1_1_ = 0;
  local_5e = 1;
  local_5d = 0;
  local_5c = 0xb;
  uStack_5b = 1;
  razer_feature_transact(param_1,&local_64,2,200);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* SendCmd @ 10003d80 */


void __cdecl
SendCmd(HANDLE param_1,undefined1 param_2,undefined1 param_3,undefined1 param_4,undefined1 param_5,
       undefined1 param_6,byte param_7,int param_8,int param_9,uint *param_10,uint *param_11)

{
  int iVar1;
  uint *puVar2;
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_61;
  undefined1 local_60;
  byte local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  uint local_5b [20];
  uint local_8;
  
                    /* 0x3d80  34  SendCmd */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  if ((param_1 == (HANDLE)0xffffffff) || (param_1 == (HANDLE)0x0)) {
    CloseHandle(param_1);
  }
  else {
    _memset(&local_64,0,0x5b);
    local_64 = param_2;
    local_63 = 0;
    local_61 = param_5;
    local_60 = param_6;
    local_5e = param_7;
    local_5d = param_3;
    local_5c = param_4;
    FUN_1013cd50(local_5b,param_10,(uint)param_7);
    iVar1 = razer_feature_transact((int)param_1,(undefined4 *)&local_64,param_8,param_9);
    if (iVar1 == 2) {
      puVar2 = local_5b;
      for (iVar1 = 0x14; iVar1 != 0; iVar1 = iVar1 + -1) {
        *param_11 = *puVar2;
        puVar2 = puVar2 + 1;
        param_11 = param_11 + 1;
      }
    }
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetDevRegionList @ 10003e40 */


undefined4 GetDevRegionList(void)

{
                    /* 0x3e40  19  GetDevRegionList */
  return 0;
}


/* ---------------------------------------------------------------------- */
/* GetPS4FWVerion @ 10003e50 */


char * __cdecl GetPS4FWVerion(undefined4 param_1,size_t param_2,int param_3,undefined4 *param_4)

{
  char *pcVar1;
  char cVar2;
  int local_14;
  int local_10;
  char *local_c;
  char *local_8;
  
                    /* 0x3e50  24  GetPS4FWVerion */
  local_c = (char *)LocalAlloc(0x40,0xb);
  local_c[0] = '\0';
  local_c[1] = '\0';
  local_c[2] = '\0';
  local_c[3] = '\0';
  local_c[4] = '\0';
  local_c[5] = '\0';
  local_c[6] = '\0';
  local_c[7] = '\0';
  local_c[8] = '\0';
  local_c[9] = '\0';
  local_c[10] = '\0';
  local_8 = (char *)FUN_10006d84(param_2);
  local_10 = 0;
  while( true ) {
    if (99 < local_10) {
      thunk_FUN_10143a68(local_8);
      return local_c;
    }
    _memset(local_8,0,param_2);
    *local_8 = '\x03';
    local_8[1] = 'Z';
    local_8[2] = -0x5b;
    if ((param_3 == 1) || (param_3 == 3)) {
      local_8[3] = -0x56;
      local_8[4] = '\x01';
    }
    else if (param_3 == 2) {
      local_8[3] = '\x01';
    }
    HidD_SetFeature(param_1,local_8,param_2);
    CStringT<>(&local_14);
    GetLastError();
    Sleep(2);
    GetLastError();
    FUN_10006b30(&local_14,L"GetLastError: %d");
    cVar2 = HidD_GetFeature(param_1,local_8,param_2);
    if ((cVar2 != '\0') && (*local_8 == '\x01')) break;
    local_10 = local_10 + 1;
    FUN_10005e20(&local_14);
  }
  *param_4 = 0;
  *param_4 = *(undefined4 *)(local_8 + 1);
  FUN_10001e80(local_c,"%d.%02d.%02d.%02d");
  pcVar1 = local_c;
  FUN_10005e20(&local_14);
  return pcVar1;
}


/* ---------------------------------------------------------------------- */
/* ControlIn @ 10004040 */


undefined4 __cdecl
ControlIn(undefined4 param_1,undefined1 param_2,undefined2 param_3,undefined2 param_4,
         undefined2 param_5,undefined4 param_6)

{
  undefined4 local_20;
  undefined4 local_1c;
  undefined4 local_14;
  int local_10;
  undefined4 local_c;
  undefined4 local_8;
  
                    /* 0x4040  4  ControlIn */
  local_10 = WinUsb_Initialize(param_1,&local_8);
  if (local_10 == 0) {
    local_c = 0;
  }
  else {
    local_14 = 0;
    local_1c = CONCAT22(param_5,param_4);
    local_20 = CONCAT22(param_3,CONCAT11(param_2,0xc0));
    local_c = WinUsb_ControlTransfer(local_8,local_20,local_1c,param_6,param_5,&local_14,0);
    GetLastError();
    WinUsb_Free(local_8);
  }
  return local_c;
}


/* ---------------------------------------------------------------------- */
/* ControlOut @ 100040d0 */


undefined4 __cdecl
ControlOut(undefined4 param_1,undefined1 param_2,undefined2 param_3,undefined2 param_4,
          undefined2 param_5,undefined4 param_6)

{
  undefined4 local_20;
  undefined4 local_1c;
  undefined4 local_14;
  int local_10;
  undefined4 local_c;
  undefined4 local_8;
  
                    /* 0x40d0  5  ControlOut */
  local_10 = WinUsb_Initialize(param_1,&local_8);
  if (local_10 == 0) {
    local_c = 0;
  }
  else {
    local_14 = 0;
    local_1c = CONCAT22(param_5,param_4);
    local_20 = CONCAT22(param_3,CONCAT11(param_2,0x40));
    local_c = WinUsb_ControlTransfer(local_8,local_20,local_1c,param_6,param_5,&local_14,0);
    GetLastError();
    WinUsb_Free(local_8);
  }
  return local_c;
}


/* ---------------------------------------------------------------------- */
/* EnterPS4Bootloader @ 10004160 */


void __cdecl EnterPS4Bootloader(undefined4 param_1,size_t param_2,int param_3)

{
  char cVar1;
  undefined1 *_Dst;
  undefined4 uVar2;
  int local_c;
  
                    /* 0x4160  13  EnterPS4Bootloader */
  uVar2 = 1;
  _Dst = (undefined1 *)FUN_10006d84(param_2);
  for (local_c = 0; local_c < 100; local_c = local_c + 1) {
    _memset(_Dst,0,param_2);
    if (param_3 == 1) {
      *_Dst = 3;
      _Dst[1] = 0x66;
      _Dst[2] = 0x88;
      _Dst[3] = 0x99;
      _Dst[4] = 4;
      _Dst[5] = 1;
    }
    else if (param_3 == 2) {
      *_Dst = 3;
      _Dst[1] = 0x5a;
      _Dst[2] = 0xa5;
      _Dst[3] = 10;
    }
    else if (param_3 == 3) {
      *_Dst = 3;
      _Dst[1] = 0x5a;
      _Dst[2] = 0xa5;
      _Dst[3] = 0xaa;
      _Dst[4] = 6;
      _Dst[5] = 2;
    }
    cVar1 = HidD_SetFeature(param_1,_Dst,param_2,uVar2);
    if (cVar1 != '\0') break;
    delay(2.0);
  }
  thunk_FUN_10143a68(_Dst);
  return;
}


/* ---------------------------------------------------------------------- */
/* InstallBLDriver @ 10004300 */


void __cdecl InstallBLDriver(LPCSTR param_1)

{
                    /* 0x4300  26  InstallBLDriver */
  ShellExecuteA((HWND)0x0,"open",param_1," /s",(LPCSTR)0x0,0);
  return;
}


/* ---------------------------------------------------------------------- */
/* rtl_get_version @ 10004330 */


/* ntdll!RtlGetVersion into OSVERSIONINFOEXW */

void rtl_get_version(void)

{
  HMODULE hModule;
  FARPROC pFVar1;
  char *lpProcName;
  undefined4 local_124 [71];
  uint local_8;
  
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(local_124,0,0x11c);
  local_124[0] = 0x11c;
  lpProcName = "RtlGetVersion";
  hModule = GetModuleHandleW(L"ntdll.dll");
  pFVar1 = GetProcAddress(hModule,lpProcName);
  if (pFVar1 != (FARPROC)0x0) {
    (*pFVar1)(local_124);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetOSVersion @ 10004410 */


void __cdecl GetOSVersion(undefined2 *param_1,undefined2 *param_2)

{
  HMODULE hModule;
  FARPROC pFVar1;
  int iVar2;
  char *lpProcName;
  undefined4 local_124;
  undefined2 local_120;
  undefined2 local_11c;
  uint local_8;
  
                    /* 0x4410  23  GetOSVersion */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_124,0,0x11c);
  local_124 = 0x11c;
  lpProcName = "RtlGetVersion";
  hModule = GetModuleHandleW(L"ntdll.dll");
  pFVar1 = GetProcAddress(hModule,lpProcName);
  if ((pFVar1 != (FARPROC)0x0) && (iVar2 = (*pFVar1)(&local_124), iVar2 == 0)) {
    *param_1 = local_120;
    *param_2 = local_11c;
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* IsWindows10OrGreater @ 100044b0 */


void IsWindows10OrGreater(void)

{
                    /* 0x44b0  27  IsWindows10OrGreater */
  rtl_get_version();
  return;
}


/* ---------------------------------------------------------------------- */
/* IsWindows8BLUEOrGreater @ 100044d0 */


void IsWindows8BLUEOrGreater(void)

{
                    /* 0x44d0  28  IsWindows8BLUEOrGreater */
  rtl_get_version();
  return;
}


/* ---------------------------------------------------------------------- */
/* RebootSystem @ 100044f0 */


void RebootSystem(void)

{
  HANDLE ProcessHandle;
  BOOL BVar1;
  DWORD DVar2;
  HANDLE *TokenHandle;
  HANDLE local_1c;
  _TOKEN_PRIVILEGES local_18;
  uint local_8;
  
                    /* 0x44f0  33  RebootSystem */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  TokenHandle = &local_1c;
  DVar2 = 0x28;
  ProcessHandle = GetCurrentProcess();
  BVar1 = OpenProcessToken(ProcessHandle,DVar2,TokenHandle);
  if (BVar1 != 0) {
    LookupPrivilegeValueW((LPCWSTR)0x0,L"SeShutdownPrivilege",&local_18.Privileges[0].Luid);
    local_18.PrivilegeCount = 1;
    local_18.Privileges[0].Attributes = 2;
    AdjustTokenPrivileges(local_1c,0,&local_18,0,(PTOKEN_PRIVILEGES)0x0,(PDWORD)0x0);
    DVar2 = GetLastError();
    if (DVar2 == 0) {
      ExitWindowsEx(2,0);
    }
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* SetActiveProfile @ 100045a0 */


void __cdecl SetActiveProfile(int param_1,undefined1 param_2)

{
  undefined1 local_64;
  undefined1 local_63;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined1 uStack_5b;
  uint local_8;
  
                    /* 0x45a0  35  SetActiveProfile */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64 = 0;
  local_63 = 0;
  local_5e = 1;
  local_5d = 5;
  local_5c = 4;
  uStack_5b = param_2;
  razer_feature_transact(param_1,(undefined4 *)&local_64,3,200);
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* CheckPipeID @ 10004610 */


void __cdecl CheckPipeID(HANDLE param_1,undefined1 *param_2,undefined1 *param_3)

{
  undefined4 local_38;
  undefined4 local_34;
  undefined4 local_30;
  byte local_29;
  int local_28;
  byte local_21;
  undefined1 local_20 [4];
  byte local_1c;
  undefined1 local_14 [4];
  char local_10;
  uint local_8;
  
                    /* 0x4610  2  CheckPipeID */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  local_28 = WinUsb_Initialize(param_1,&local_30);
  if (local_28 == 0) {
    CloseHandle(param_1);
  }
  else {
    local_28 = WinUsb_QueryInterfaceSettings(local_30,0,local_20);
    if (local_28 != 0) {
      local_29 = local_1c;
      local_21 = 0;
      while ((local_21 < local_29 &&
             (local_28 = WinUsb_QueryPipe(local_30,0,local_21,local_14), local_28 != 0))) {
        if (local_10 == '\x01') {
          *param_3 = 1;
          local_34 = 5000;
          local_28 = WinUsb_SetPipePolicy(local_30,1,3,4,&local_34);
joined_r0x10004727:
          if (local_28 == 0) break;
        }
        else if (local_10 == -0x7f) {
          *param_2 = 0x81;
          local_38 = 5000;
          local_28 = WinUsb_SetPipePolicy(local_30,0x81,3,4,&local_38);
          goto joined_r0x10004727;
        }
        local_21 = local_21 + 1;
      }
    }
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* OutData @ 10004750 */


undefined4 __cdecl
OutData(undefined4 param_1,undefined1 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  undefined1 local_10 [4];
  undefined4 local_c;
  int local_8;
  
                    /* 0x4750  30  OutData */
  local_8 = WinUsb_Initialize(param_1,&local_c);
  if (local_8 == 0) {
    uVar1 = 0;
  }
  else {
    uVar1 = WinUsb_WritePipe(local_c,param_2,param_3,param_4,local_10,0);
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* ReadData @ 100047a0 */


undefined4 __cdecl
ReadData(undefined4 param_1,undefined1 param_2,undefined4 param_3,undefined4 param_4)

{
  undefined4 uVar1;
  undefined1 local_10 [4];
  undefined4 local_c;
  int local_8;
  
                    /* 0x47a0  31  ReadData */
  local_8 = WinUsb_Initialize(param_1,&local_c);
  if (local_8 == 0) {
    uVar1 = 0;
  }
  else {
    uVar1 = WinUsb_ReadPipe(local_c,param_2,param_3,param_4,local_10,0);
  }
  return uVar1;
}


/* ---------------------------------------------------------------------- */
/* HaveBT @ 100047f0 */


void __cdecl HaveBT(undefined4 *param_1,int *param_2,undefined4 *param_3)

{
  BOOL BVar1;
  int iVar2;
  DWORD local_ec8 [3];
  undefined4 local_ebc;
  undefined4 local_eb8;
  DWORD local_eb4;
  uint local_eb0;
  int local_eac;
  DWORD local_ea8;
  HDEVINFO local_ea4;
  char local_e9d;
  undefined4 local_e9c;
  undefined1 local_e94 [552];
  undefined4 local_c6c;
  undefined1 local_c64 [552];
  undefined4 local_a3c;
  undefined1 local_a34 [512];
  _SP_DEVINFO_DATA local_834;
  GUID local_818;
  BYTE local_808 [2048];
  uint local_8;
  
                    /* 0x47f0  25  HaveBT */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  *param_1 = 0;
  *param_2 = 0;
  *param_3 = 0;
  local_eac = 0;
  local_eb8 = 0;
  local_ec8[1] = 0;
  local_ebc = 4;
  local_a3c = 0x208;
  _memset(local_a34,0,0x200);
  local_c6c = 0x230;
  _memset(local_c64,0,0x228);
  local_e9c = 0x230;
  _memset(local_e94,0,0x228);
  local_818.Data1 = 0xe0cbf06c;
  local_818.Data2 = 0xcd8b;
  local_818.Data3 = 0x4647;
  local_818.Data4[0] = 0xbb;
  local_818.Data4[1] = 0x8a;
  local_818.Data4[2] = '&';
  local_818.Data4[3] = ';';
  local_818.Data4[4] = 'C';
  local_818.Data4[5] = 0xf0;
  local_818.Data4[6] = 0xf9;
  local_818.Data4[7] = 't';
  local_ea4 = SetupDiGetClassDevsW(&local_818,(PCWSTR)0x0,(HWND)0x0,2);
  local_834.ClassGuid.Data1 = 0;
  local_834.ClassGuid.Data2 = 0;
  local_834.ClassGuid.Data3 = 0;
  local_834.ClassGuid.Data4[0] = '\0';
  local_834.ClassGuid.Data4[1] = '\0';
  local_834.ClassGuid.Data4[2] = '\0';
  local_834.ClassGuid.Data4[3] = '\0';
  local_834.ClassGuid.Data4[4] = '\0';
  local_834.ClassGuid.Data4[5] = '\0';
  local_834.ClassGuid.Data4[6] = '\0';
  local_834.ClassGuid.Data4[7] = '\0';
  local_834.DevInst = 0;
  local_834.Reserved = 0;
  local_834.cbSize = 0x1c;
  local_ea8 = 0;
  while (BVar1 = SetupDiEnumDeviceInfo(local_ea4,local_ea8,&local_834), BVar1 != 0) {
    local_ea8 = local_ea8 + 1;
    *param_1 = 1;
    if (*param_2 == 0) {
      local_eac = BluetoothFindFirstRadio(&local_ebc,&local_eb8);
      local_e9d = local_eac != 0;
      local_eb0 = (uint)(byte)local_e9d;
      CStringT<>(local_ec8 + 2);
      if (local_e9d == '\0') {
        *param_2 = 0;
      }
      else {
        *param_2 = 1;
      }
      BluetoothFindRadioClose(local_eac);
      FUN_10005e20((int *)(local_ec8 + 2));
    }
    local_eb4 = 0x800;
    BVar1 = SetupDiGetDeviceRegistryPropertyW
                      (local_ea4,&local_834,4,local_ec8,local_808,0x800,&local_eb4);
    if ((BVar1 != 0) &&
       (iVar2 = FUN_10001d30((undefined1 (*) [16])local_808,(undefined1 (*) [16])"BthLEEnum"),
       iVar2 != 0)) {
      *param_3 = 1;
    }
  }
  if (local_ea4 != (HDEVINFO)0x0) {
    SetupDiDestroyDeviceInfoList(local_ea4);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* SetFeatureRpt @ 10004b30 */


void __cdecl
SetFeatureRpt(HANDLE param_1,undefined1 param_2,undefined1 param_3,undefined1 param_4,
             undefined1 param_5,undefined1 param_6,byte param_7,int param_8,int param_9,
             uint *param_10)

{
  undefined4 uVar1;
  uint uVar2;
  int local_68;
  undefined1 local_64;
  undefined1 local_63 [2];
  undefined1 local_61;
  undefined1 local_60;
  byte local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  uint local_5b [20];
  uint local_8;
  
                    /* 0x4b30  36  SetFeatureRpt */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  if ((param_1 == (HANDLE)0xffffffff) || (param_1 == (HANDLE)0x0)) {
    CloseHandle(param_1);
  }
  else {
    _memset(&local_64,0,0x5b);
    local_64 = param_2;
    local_63[0] = 0;
    local_61 = param_5;
    local_60 = param_6;
    local_5e = param_7;
    local_5d = param_3;
    local_5c = param_4;
    FUN_1013cd50(local_5b,param_10,(uint)param_7);
    uVar1 = 0;
    uVar2 = 0;
    for (local_68 = 0; local_68 < param_8; local_68 = local_68 + 1) {
      delay((float)param_9);
      razer_report_crc((int)local_63);
      uVar2 = HidD_SetFeature(param_1,&local_64,0x5b,uVar1,uVar2);
      uVar2 = uVar2 & 0xff;
      if ((uVar2 != 0) || (delay((float)param_9), local_68 == param_8)) break;
    }
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* GetFeatureRpt @ 10004c50 */


void __cdecl
GetFeatureRpt(HANDLE param_1,undefined1 param_2,char param_3,char param_4,int param_5,int param_6,
             undefined4 *param_7)

{
  char cVar1;
  int iVar2;
  undefined4 *puVar3;
  int local_70;
  undefined1 local_64;
  char local_63;
  char local_5d;
  char local_5c;
  undefined4 local_5b [20];
  uint local_8;
  
                    /* 0x4c50  22  GetFeatureRpt */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  if ((param_1 == (HANDLE)0xffffffff) || (param_1 == (HANDLE)0x0)) {
    CloseHandle(param_1);
  }
  else {
    _memset(&local_64,0,0x5b);
    local_64 = param_2;
    local_63 = '\0';
    local_70 = 0;
    do {
      if (param_5 <= local_70) break;
      delay((float)param_6);
      local_70 = local_70 + 1;
      cVar1 = HidD_GetFeature(param_1,&local_64,0x5b);
      if ((((cVar1 != '\0') && (param_4 == local_5c)) && (param_3 == local_5d)) &&
         ((local_63 != '\x01' && (local_63 != '\0')))) {
        if (local_63 == '\x02') {
          puVar3 = local_5b;
          for (iVar2 = 0x14; iVar2 != 0; iVar2 = iVar2 + -1) {
            *param_7 = *puVar3;
            puVar3 = puVar3 + 1;
            param_7 = param_7 + 1;
          }
        }
        break;
      }
    } while (local_70 != param_5);
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* DevExist @ 10004d90 */


void __cdecl DevExist(undefined4 param_1,undefined4 param_2,undefined1 (*param_3) [16],int param_4)

{
  char cVar1;
  bool bVar2;
  CSimpleStringT<wchar_t,0> *pCVar3;
  int *piVar4;
  undefined1 (*pauVar5) [16];
  int iVar6;
  uint uVar7;
  int local_98;
  int local_94;
  int local_90;
  int local_8c;
  DWORD local_88;
  int local_84;
  undefined4 local_80;
  int local_7c;
  int local_78;
  DWORD local_74;
  int local_70;
  int local_6c;
  HDEVINFO local_68;
  DWORD local_64;
  int local_60;
  int local_5c;
  PSP_DEVICE_INTERFACE_DETAIL_DATA_W local_58;
  CSimpleStringT<wchar_t,0> local_54 [4];
  _SP_DEVINFO_DATA local_50;
  _SP_DEVICE_INTERFACE_DATA local_34;
  GUID local_18;
  uint local_8;
  
                    /* 0x4d90  10  DevExist */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  CStringT<>(&local_70);
  CStringT<>(&local_6c);
  FUN_10006b30(&local_70,L"%04X");
  FUN_10006b30(&local_6c,L"%04X");
  local_80 = 0;
  local_84 = 1;
  local_50.cbSize = 0x1c;
  if (param_4 == 1) {
    local_18.Data1 = 0xa5dcbf10;
    local_18.Data2 = 0x6530;
    local_18.Data3 = 0x11d2;
    local_18.Data4[0] = 0x90;
    local_18.Data4[1] = '\x1f';
    local_18.Data4[2] = '\0';
    local_18.Data4[3] = 0xc0;
    local_18.Data4[4] = 'O';
    local_18.Data4[5] = 0xb9;
    local_18.Data4[6] = 'Q';
    local_18.Data4[7] = 0xed;
  }
  else if (param_4 == 2) {
    local_18.Data1 = 0x3abf6f2d;
    local_18.Data2 = 0x71c4;
    local_18.Data3 = 0x462a;
    local_18.Data4[0] = 0x8a;
    local_18.Data4[1] = 0x92;
    local_18.Data4[2] = '\x1e';
    local_18.Data4[3] = 'h';
    local_18.Data4[4] = 'a';
    local_18.Data4[5] = 0xe6;
    local_18.Data4[6] = 0xaf;
    local_18.Data4[7] = '\'';
  }
  else if (param_4 == 3) {
    local_18.Data1 = 0xe6f07b5f;
    local_18.Data2 = 0xee97;
    local_18.Data3 = 0x4a90;
    local_18.Data4[0] = 0xb0;
    local_18.Data4[1] = 'v';
    local_18.Data4[2] = '3';
    local_18.Data4[3] = 0xf5;
    local_18.Data4[4] = '{';
    local_18.Data4[5] = 0xf4;
    local_18.Data4[6] = 0xea;
    local_18.Data4[7] = 0xa7;
  }
  else {
    HidD_GetHidGuid(&local_18);
  }
  local_68 = SetupDiGetClassDevsW(&local_18,(PCWSTR)0x0,(HWND)0x0,0x12);
  local_74 = 0;
  do {
    if (local_84 != 1) {
LAB_100052f8:
      SetupDiDestroyDeviceInfoList(local_68);
      FUN_10005e20(&local_6c);
      FUN_10005e20(&local_70);
      __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
      return;
    }
    local_34.cbSize = 0x1c;
    local_88 = local_74;
    local_84 = SetupDiEnumDeviceInterfaces
                         (local_68,(PSP_DEVINFO_DATA)0x0,&local_18,local_74,&local_34);
    local_74 = local_74 + 1;
    local_64 = 0;
    SetupDiGetDeviceInterfaceDetailW
              (local_68,&local_34,(PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0,0,&local_64,&local_50);
    local_58 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)FUN_10143a83(local_64);
    local_58->cbSize = 6;
    SetupDiGetDeviceInterfaceDetailW(local_68,&local_34,local_58,local_64,&local_64,&local_50);
    CStringT<>(local_54,local_58->DevicePath);
    if (param_4 == 3) {
      iVar6 = 0;
      pauVar5 = param_3;
      pCVar3 = FUN_10005d10(local_54);
      iVar6 = FUN_10005d60(pCVar3,pauVar5,iVar6);
      if (0 < iVar6) {
        local_80 = 1;
        FUN_10143a68(local_58);
        local_58 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
        FUN_10005e20((int *)local_54);
        goto LAB_100052f8;
      }
      FUN_10143a68(local_58);
      local_58 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
    }
    else {
      CStringT<>(&local_60,(char *)L"");
      CStringT<>(&local_5c,(char *)((int)L"atlTraceControls" + 0x23));
      if (param_4 == 2) {
        iVar6 = 0;
        pauVar5 = (undefined1 (*) [16])&DAT_1019b424;
        pCVar3 = FUN_10005d10(local_54);
        local_7c = FUN_10005d60(pCVar3,pauVar5,iVar6);
        uVar7 = 4;
        iVar6 = local_7c + 4;
        piVar4 = &local_94;
        pCVar3 = FUN_10005d10(local_54);
        pCVar3 = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar3,piVar4,iVar6,uVar7);
        FUN_10005e00(&local_60,pCVar3);
        FUN_10005e20(&local_94);
        iVar6 = 0;
        pauVar5 = (undefined1 (*) [16])&DAT_1019b42c;
        pCVar3 = FUN_10005d10(local_54);
        local_7c = FUN_10005d60(pCVar3,pauVar5,iVar6);
        uVar7 = 4;
        iVar6 = local_7c + 4;
        piVar4 = &local_98;
        pCVar3 = FUN_10005d10(local_54);
        pCVar3 = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar3,piVar4,iVar6,uVar7);
        FUN_10005e00(&local_5c,pCVar3);
        FUN_10005e20(&local_98);
      }
      else {
        iVar6 = 0;
        pauVar5 = (undefined1 (*) [16])&DAT_1019b414;
        pCVar3 = FUN_10005d10(local_54);
        local_78 = FUN_10005d60(pCVar3,pauVar5,iVar6);
        uVar7 = 4;
        iVar6 = local_78 + 4;
        piVar4 = &local_8c;
        pCVar3 = FUN_10005d10(local_54);
        pCVar3 = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar3,piVar4,iVar6,uVar7);
        FUN_10005e00(&local_60,pCVar3);
        FUN_10005e20(&local_8c);
        iVar6 = 0;
        pauVar5 = (undefined1 (*) [16])&DAT_1019b41c;
        pCVar3 = FUN_10005d10(local_54);
        local_78 = FUN_10005d60(pCVar3,pauVar5,iVar6);
        uVar7 = 4;
        iVar6 = local_78 + 4;
        piVar4 = &local_90;
        pCVar3 = FUN_10005d10(local_54);
        pCVar3 = (CSimpleStringT<wchar_t,0> *)FUN_10005c30(pCVar3,piVar4,iVar6,uVar7);
        FUN_10005e00(&local_5c,pCVar3);
        FUN_10005e20(&local_90);
      }
      cVar1 = FUN_10005b10(&local_70,(char *)L"");
      if (cVar1 != '\0') {
        cVar1 = FUN_10005b10(&local_6c,(char *)((int)L"atlTraceDBClient" + 0x23));
        if (cVar1 != '\0') {
          bVar2 = FUN_10005bc0(&local_60,&local_70);
          if (bVar2) {
            bVar2 = FUN_10005bc0(&local_5c,&local_6c);
            if (bVar2) {
              local_80 = 1;
              FUN_10143a68(local_58);
              local_58 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
              FUN_10005e20(&local_5c);
              FUN_10005e20(&local_60);
              FUN_10005e20((int *)local_54);
              goto LAB_100052f8;
            }
          }
        }
      }
      FUN_10143a68(local_58);
      local_58 = (PSP_DEVICE_INTERFACE_DETAIL_DATA_W)0x0;
      FUN_10005e20(&local_5c);
      FUN_10005e20(&local_60);
    }
    FUN_10005e20((int *)local_54);
  } while( true );
}


/* ---------------------------------------------------------------------- */
/* GetEditionID @ 10005330 */


void __cdecl GetEditionID(int param_1,undefined1 *param_2,undefined1 *param_3)

{
  int iVar1;
  undefined4 local_64;
  undefined1 local_5e;
  undefined1 local_5d;
  undefined1 local_5c;
  undefined1 uStack_5b;
  undefined1 local_5a;
  uint local_8;
  
                    /* 0x5330  20  GetEditionID */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_64,0,0x5b);
  local_64._0_1_ = 0;
  local_64._1_1_ = 0;
  local_5e = 3;
  local_5d = 0;
  local_5c = 0x86;
  iVar1 = razer_feature_transact(param_1,&local_64,2,0x14);
  if (iVar1 == 2) {
    *param_2 = local_5a;
    *param_3 = uStack_5b;
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* stop_dependent_services @ 100053c0 */


/* EnumDependentServicesW + ControlService(STOP) on each (used by DoStopSvc) */

void stop_dependent_services(void)

{
  DWORD DVar1;
  BOOL BVar2;
  DWORD DVar3;
  HANDLE hHeap;
  int iVar4;
  LPENUM_SERVICE_STATUSW p_Var5;
  LPCWSTR *ppWVar6;
  SIZE_T dwBytes;
  DWORD local_7c;
  SC_HANDLE pSStack_78;
  SIZE_T local_74 [2];
  LPENUM_SERVICE_STATUSW local_6c;
  LPCWSTR apWStack_68 [9];
  _SERVICE_STATUS _Stack_44;
  uint local_20;
  void *local_14;
  code *pcStack_10;
  uint local_c;
  undefined4 local_8;
  
  local_8 = 0xfffffffe;
  pcStack_10 = __except_handler4;
  local_14 = ExceptionList;
  local_c = DAT_101b6f64 ^ 0x101a4620;
  local_20 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  ExceptionList = &local_14;
  local_6c = (LPENUM_SERVICE_STATUSW)0x0;
  DVar1 = GetTickCount();
  BVar2 = EnumDependentServicesW(DAT_101bf474,1,local_6c,0,local_74,&local_7c);
  if ((BVar2 == 0) && (DVar3 = GetLastError(), DVar3 == 0xea)) {
    DVar3 = 8;
    dwBytes = local_74[0];
    hHeap = GetProcessHeap();
    local_6c = (LPENUM_SERVICE_STATUSW)HeapAlloc(hHeap,DVar3,dwBytes);
    if (local_6c != (LPENUM_SERVICE_STATUSW)0x0) {
      local_8 = 0;
      BVar2 = EnumDependentServicesW(DAT_101bf474,1,local_6c,local_74[0],local_74,&local_7c);
      if (BVar2 == 0) {
        FUN_1013fb10(&DAT_101b6f64,&local_14,0xfffffffe);
      }
      else {
        local_74[1] = 0;
        if (local_7c == 0) {
          local_8 = 0xfffffffe;
          FUN_1000563c();
          FUN_10005650();
          return;
        }
        p_Var5 = local_6c;
        ppWVar6 = apWStack_68;
        for (iVar4 = 9; iVar4 != 0; iVar4 = iVar4 + -1) {
          *ppWVar6 = p_Var5->lpServiceName;
          p_Var5 = (LPENUM_SERVICE_STATUSW)&p_Var5->lpDisplayName;
          ppWVar6 = ppWVar6 + 1;
        }
        pSStack_78 = OpenServiceW(DAT_101bf478,apWStack_68[0],0x24);
        if (pSStack_78 == (SC_HANDLE)0x0) {
          FUN_1013fb10(&DAT_101b6f64,&local_14,0xfffffffe);
        }
        else {
          local_8 = 1;
          BVar2 = ControlService(pSStack_78,1,&_Stack_44);
          if (BVar2 == 0) {
            FUN_1013fb10(&DAT_101b6f64,&local_14,0xfffffffe);
          }
          else {
            do {
              if (_Stack_44.dwCurrentState == 1) {
LAB_10005610:
                local_8 = 0;
                FUN_1000561e();
                FUN_10005629();
                return;
              }
              Sleep(_Stack_44.dwWaitHint);
              BVar2 = QueryServiceStatusEx
                                (pSStack_78,SC_STATUS_PROCESS_INFO,(LPBYTE)&_Stack_44,0x24,local_74)
              ;
              if (BVar2 == 0) {
                FUN_1013fb10(&DAT_101b6f64,&local_14,0xfffffffe);
                goto LAB_10005655;
              }
              if (_Stack_44.dwCurrentState == 1) goto LAB_10005610;
              DVar3 = GetTickCount();
            } while (DVar3 - DVar1 < 0x7531);
            FUN_1013fb10(&DAT_101b6f64,&local_14,0xfffffffe);
          }
        }
      }
    }
  }
LAB_10005655:
  ExceptionList = local_14;
  __security_check_cookie(local_20 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_100054cd @ 100054cd */


void FUN_100054cd(void)

{
  SC_HANDLE pSVar1;
  BOOL BVar2;
  DWORD DVar3;
  int iVar4;
  uint unaff_EBP;
  undefined4 *puVar5;
  undefined4 *puVar6;
  undefined4 uStack0000000c;
  
  *(int *)(unaff_EBP - 0x6c) = *(int *)(unaff_EBP - 0x6c) + 1;
  if (*(uint *)(unaff_EBP - 0x78) <= *(uint *)(unaff_EBP - 0x6c)) {
    *(undefined4 *)(unaff_EBP - 4) = 0xfffffffe;
    FUN_1000563c();
    FUN_10005650();
    return;
  }
  puVar5 = (undefined4 *)(*(int *)(unaff_EBP - 0x6c) * 0x24 + *(int *)(unaff_EBP - 0x68));
  puVar6 = (undefined4 *)(unaff_EBP - 100);
  for (iVar4 = 9; iVar4 != 0; iVar4 = iVar4 + -1) {
    *puVar6 = *puVar5;
    puVar5 = puVar5 + 1;
    puVar6 = puVar6 + 1;
  }
  pSVar1 = OpenServiceW(DAT_101bf478,*(LPCWSTR *)(unaff_EBP - 100),0x24);
  *(SC_HANDLE *)(unaff_EBP - 0x74) = pSVar1;
  if (*(int *)(unaff_EBP - 0x74) == 0) {
    *(undefined4 *)(unaff_EBP - 0x80) = 0;
    FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
  }
  else {
    *(undefined4 *)(unaff_EBP - 4) = 1;
    BVar2 = ControlService(*(SC_HANDLE *)(unaff_EBP - 0x74),1,(LPSERVICE_STATUS)(unaff_EBP - 0x40));
    if (BVar2 == 0) {
      *(undefined4 *)(unaff_EBP - 0x84) = 0;
      FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
    }
    else {
      do {
        if (*(int *)(unaff_EBP - 0x3c) == 1) {
LAB_10005610:
          *(undefined4 *)(unaff_EBP - 4) = 0;
          FUN_1000561e();
          FUN_10005629();
          return;
        }
        Sleep(*(DWORD *)(unaff_EBP - 0x28));
        BVar2 = QueryServiceStatusEx
                          (*(SC_HANDLE *)(unaff_EBP - 0x74),SC_STATUS_PROCESS_INFO,
                           (LPBYTE)(unaff_EBP - 0x40),0x24,(LPDWORD)(unaff_EBP - 0x70));
        if (BVar2 == 0) {
          *(undefined4 *)(unaff_EBP - 0x88) = 0;
          FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
          goto LAB_10005655;
        }
        if (*(int *)(unaff_EBP - 0x3c) == 1) goto LAB_10005610;
        DVar3 = GetTickCount();
      } while (DVar3 - *(int *)(unaff_EBP - 0x8c) <= *(uint *)(unaff_EBP - 0x90));
      *(undefined4 *)(unaff_EBP - 0x94) = 0;
      FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
    }
  }
LAB_10005655:
  ExceptionList = *(void **)(unaff_EBP - 0x10);
  uStack0000000c = 0x1000566d;
  __security_check_cookie(*(uint *)(unaff_EBP - 0x1c) ^ unaff_EBP);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_1000561e @ 1000561e */


void FUN_1000561e(void)

{
  int unaff_EBP;
  
  CloseServiceHandle(*(SC_HANDLE *)(unaff_EBP + -0x74));
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_10005629 @ 10005629 */


void FUN_10005629(void)

{
  SC_HANDLE pSVar1;
  BOOL BVar2;
  DWORD DVar3;
  int iVar4;
  uint unaff_EBP;
  undefined4 *puVar5;
  undefined4 *puVar6;
  undefined4 uStack0000000c;
  
  *(int *)(unaff_EBP - 0x6c) = *(int *)(unaff_EBP - 0x6c) + 1;
  if (*(uint *)(unaff_EBP - 0x78) <= *(uint *)(unaff_EBP - 0x6c)) {
    *(undefined4 *)(unaff_EBP - 4) = 0xfffffffe;
    FUN_1000563c();
    FUN_10005650();
    return;
  }
  puVar5 = (undefined4 *)(*(int *)(unaff_EBP - 0x6c) * 0x24 + *(int *)(unaff_EBP - 0x68));
  puVar6 = (undefined4 *)(unaff_EBP - 100);
  for (iVar4 = 9; iVar4 != 0; iVar4 = iVar4 + -1) {
    *puVar6 = *puVar5;
    puVar5 = puVar5 + 1;
    puVar6 = puVar6 + 1;
  }
  pSVar1 = OpenServiceW(DAT_101bf478,*(LPCWSTR *)(unaff_EBP - 100),0x24);
  *(SC_HANDLE *)(unaff_EBP - 0x74) = pSVar1;
  if (*(int *)(unaff_EBP - 0x74) == 0) {
    *(undefined4 *)(unaff_EBP - 0x80) = 0;
    FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
  }
  else {
    *(undefined4 *)(unaff_EBP - 4) = 1;
    BVar2 = ControlService(*(SC_HANDLE *)(unaff_EBP - 0x74),1,(LPSERVICE_STATUS)(unaff_EBP - 0x40));
    if (BVar2 == 0) {
      *(undefined4 *)(unaff_EBP - 0x84) = 0;
      FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
    }
    else {
      do {
        if (*(int *)(unaff_EBP - 0x3c) == 1) {
LAB_10005610:
          *(undefined4 *)(unaff_EBP - 4) = 0;
          FUN_1000561e();
          FUN_10005629();
          return;
        }
        Sleep(*(DWORD *)(unaff_EBP - 0x28));
        BVar2 = QueryServiceStatusEx
                          (*(SC_HANDLE *)(unaff_EBP - 0x74),SC_STATUS_PROCESS_INFO,
                           (LPBYTE)(unaff_EBP - 0x40),0x24,(LPDWORD)(unaff_EBP - 0x70));
        if (BVar2 == 0) {
          *(undefined4 *)(unaff_EBP - 0x88) = 0;
          FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
          goto LAB_10005655;
        }
        if (*(int *)(unaff_EBP - 0x3c) == 1) goto LAB_10005610;
        DVar3 = GetTickCount();
      } while (DVar3 - *(int *)(unaff_EBP - 0x8c) <= *(uint *)(unaff_EBP - 0x90));
      *(undefined4 *)(unaff_EBP - 0x94) = 0;
      FUN_1013fb10(&DAT_101b6f64,unaff_EBP - 0x10,0xfffffffe);
    }
  }
LAB_10005655:
  ExceptionList = *(void **)(unaff_EBP - 0x10);
  uStack0000000c = 0x1000566d;
  __security_check_cookie(*(uint *)(unaff_EBP - 0x1c) ^ unaff_EBP);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_1000563c @ 1000563c */


void FUN_1000563c(void)

{
  HANDLE hHeap;
  int unaff_EBP;
  DWORD dwFlags;
  LPVOID lpMem;
  
  lpMem = *(LPVOID *)(unaff_EBP + -0x68);
  dwFlags = 0;
  hHeap = GetProcessHeap();
  HeapFree(hHeap,dwFlags,lpMem);
  return;
}


/* ---------------------------------------------------------------------- */
/* FUN_10005650 @ 10005650 */


void FUN_10005650(void)

{
  uint unaff_EBP;
  undefined4 uStack0000000c;
  
  ExceptionList = *(void **)(unaff_EBP - 0x10);
  uStack0000000c = 0x1000566d;
  __security_check_cookie(*(uint *)(unaff_EBP - 0x1c) ^ unaff_EBP);
  return;
}


/* ---------------------------------------------------------------------- */
/* DoStopSvc @ 10005680 */


void __cdecl DoStopSvc(LPCWSTR param_1)

{
  DWORD DVar1;
  BOOL BVar2;
  DWORD DVar3;
  DWORD local_34;
  DWORD local_30;
  _SERVICE_STATUS local_2c;
  uint local_8;
  
                    /* 0x5680  11  DoStopSvc */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  DVar1 = GetTickCount();
  DAT_101bf478 = OpenSCManagerW((LPCWSTR)0x0,(LPCWSTR)0x0,0xf003f);
  if (DAT_101bf478 == (SC_HANDLE)0x0) {
    GetLastError();
    FUN_10001dd0((wchar_t *)"OpenSCManager failed (%d)\n");
    goto LAB_10005911;
  }
  DAT_101bf474 = OpenServiceW(DAT_101bf478,param_1,0x2c);
  if (DAT_101bf474 == (SC_HANDLE)0x0) {
    GetLastError();
    FUN_10001dd0((wchar_t *)"OpenService failed (%d)\n");
    CloseServiceHandle(DAT_101bf478);
    goto LAB_10005911;
  }
  BVar2 = QueryServiceStatusEx(DAT_101bf474,SC_STATUS_PROCESS_INFO,(LPBYTE)&local_2c,0x24,&local_34)
  ;
  if (BVar2 == 0) {
    GetLastError();
    FUN_10001dd0((wchar_t *)"QueryServiceStatusEx failed (%d)\n");
  }
  else if (local_2c.dwCurrentState == 1) {
    FUN_10001dd0((wchar_t *)"Service is already stopped.\n");
  }
  else {
    do {
      if (local_2c.dwCurrentState != 3) {
        stop_dependent_services();
        BVar2 = ControlService(DAT_101bf474,1,&local_2c);
        if (BVar2 != 0) goto LAB_1000587d;
        GetLastError();
        FUN_10001dd0((wchar_t *)"ControlService failed (%d)\n");
        goto LAB_100058f8;
      }
      FUN_10001dd0((wchar_t *)"Service stop pending...\n");
      local_30 = local_2c.dwWaitHint / 10;
      if (local_30 < 1000) {
        local_30 = 1000;
      }
      else if (10000 < local_30) {
        local_30 = 10000;
      }
      Sleep(local_30);
      BVar2 = QueryServiceStatusEx
                        (DAT_101bf474,SC_STATUS_PROCESS_INFO,(LPBYTE)&local_2c,0x24,&local_34);
      if (BVar2 == 0) {
        GetLastError();
        FUN_10001dd0((wchar_t *)"QueryServiceStatusEx failed (%d)\n");
        goto LAB_100058f8;
      }
      if (local_2c.dwCurrentState == 1) {
        FUN_10001dd0((wchar_t *)"Service stopped successfully.\n");
        goto LAB_100058f8;
      }
      DVar3 = GetTickCount();
    } while (DVar3 - DVar1 < 0x7531);
    FUN_10001dd0((wchar_t *)"Service stop timed out.\n");
  }
  goto LAB_100058f8;
  while( true ) {
    if (local_2c.dwCurrentState == 1) goto LAB_100058eb;
    DVar3 = GetTickCount();
    if (30000 < DVar3 - DVar1) break;
LAB_1000587d:
    if (local_2c.dwCurrentState == 1) {
LAB_100058eb:
      FUN_10001dd0((wchar_t *)"Service stopped successfully\n");
      goto LAB_100058f8;
    }
    Sleep(local_2c.dwWaitHint);
    BVar2 = QueryServiceStatusEx
                      (DAT_101bf474,SC_STATUS_PROCESS_INFO,(LPBYTE)&local_2c,0x24,&local_34);
    if (BVar2 == 0) {
      GetLastError();
      FUN_10001dd0((wchar_t *)"QueryServiceStatusEx failed (%d)\n");
      goto LAB_100058f8;
    }
  }
  FUN_10001dd0((wchar_t *)"Wait timed out\n");
LAB_100058f8:
  CloseServiceHandle(DAT_101bf474);
  CloseServiceHandle(DAT_101bf478);
LAB_10005911:
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* ExistMonitor @ 10005920 */


void ExistMonitor(void)

{
  BOOL BVar1;
  DWORD local_69c;
  _DISPLAY_DEVICEW local_698;
  _DISPLAY_DEVICEW local_350;
  uint local_8;
  
                    /* 0x5920  14  ExistMonitor */
  local_8 = DAT_101b6f64 ^ (uint)&stack0xfffffffc;
  _memset(&local_350,0,0x348);
  _memset(&local_698,0,0x348);
  local_69c = 0;
  while( true ) {
    local_350.cb = 0x348;
    local_698.cb = 0x348;
    BVar1 = EnumDisplayDevicesW((LPCWSTR)0x0,local_69c,&local_350,0);
    if (BVar1 == 0) break;
    FUN_1000807d(local_350.DeviceName,0,0);
    BVar1 = EnumDisplayDevicesW(local_350.DeviceName,0,&local_698,0);
    if (BVar1 != 0) {
      FUN_1000807d(local_698.DeviceID,0,0);
    }
    _memset(&local_350,0,0x348);
    _memset(&local_698,0,0x348);
    local_69c = local_69c + 1;
  }
  __security_check_cookie(local_8 ^ (uint)&stack0xfffffffc);
  return;
}


/* ---------------------------------------------------------------------- */
/* ReadInputRptData @ 10005a40 */


BOOL __cdecl ReadInputRptData(HANDLE param_1,undefined4 *param_2,DWORD param_3)

{
  DWORD DVar1;
  BOOL BVar2;
  _OVERLAPPED local_24;
  DWORD local_10;
  DWORD local_c;
  BOOL local_8;
  
                    /* 0x5a40  32  ReadInputRptData */
  *param_2 = 0;
  param_2[1] = 0;
  param_2[2] = 0;
  *(undefined1 *)(param_2 + 3) = 0;
  local_8 = 0;
  local_24.u.s.Offset = 0;
  local_24.u.s.OffsetHigh = 0;
  local_24.hEvent = CreateEventW((LPSECURITY_ATTRIBUTES)0x0,1,0,(LPCWSTR)0x0);
  do {
    local_8 = ReadFile(param_1,param_2,param_3,&local_10,&local_24);
    if (local_8 != 0) {
      return local_8;
    }
    local_c = GetLastError();
  } while ((local_c != 0x3e5) ||
          (DVar1 = WaitForSingleObject(local_24.hEvent,0xffffffff), DVar1 != 0));
  BVar2 = GetOverlappedResult(param_1,&local_24,&param_3,0);
  return BVar2;
}


