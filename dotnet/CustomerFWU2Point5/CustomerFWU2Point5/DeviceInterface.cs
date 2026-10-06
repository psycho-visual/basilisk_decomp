using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CustomerFWU2Point5
{
	public class DeviceInterface
	{
		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern IntPtr OpenDevice(uint VID, uint PID, ushort bcdpid, float blver, int reporttype, int featurelen, int inputlen, int outputlen);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern IntPtr GetBootloaderHandle(uint VID, uint PID, ushort bcdpid, float blver);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void CloseDevice(IntPtr handle);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern ushort GetDevPIDInBootloader(IntPtr handle, float blver);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int GetFWVersion(IntPtr handle, byte[] fwver, byte devtype);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int EnterDeviceMode(IntPtr handle, byte mode);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern void delay(float duration);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int DFUErase(IntPtr handle, uint startaddr, uint endaddr);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int DFUProgram(IntPtr handle, byte datasize, uint startaddr, int delaytime, byte[] data);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int DFUVerify(IntPtr handle, byte datasize, uint startaddr, int delaytime, byte[] data);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int DFUExit(IntPtr handle);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern bool BackToDefult(IntPtr handle);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern int SendCmd(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, byte pktmsb, byte pktlsb, byte paramlen, int getrepretry, int delay, byte[] param, byte[] retdata);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool SetFeatureRpt(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, byte pktmsb, byte pktlsb, byte paramlen, int setrepretry, int delay, byte[] param);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern int GetFeatureRpt(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, int getrepretry, int delay, byte[] param);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool ControlIn(IntPtr handle, byte bcommand, ushort uvalue, uint uindex, ushort ulength, byte[] rbBuffer);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool ControlOut(IntPtr handle, byte bcommand, ushort uvalue, uint uindex, ushort ulength, byte[] rbBuffer);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr GetPS4FWVerion(IntPtr handle, int featurelen, int protocolver, byte[] fwver);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void EnterPS4Bootloader(IntPtr handle, int featurelen, int protocolver);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int GetBLFWVERInBootloader(IntPtr handle, float blver, byte[] fwver);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern bool RebootSystem();

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsWow64Process([In] IntPtr hProcess, out bool lpSystemInfo);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern bool IsWindows10OrGreater();

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern bool IsWindows8BLUEOrGreater();

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void InstallBLDriver(string path);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int SetActiveProfile(IntPtr handle, byte proile);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool OutData(IntPtr handle, byte outpipe, byte[] buffer, ulong len);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern bool ReadData(IntPtr handle, byte inpipe, byte[] buffer, int len);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool CheckPipeID(IntPtr handle, ref byte inpipe, ref byte outpipe);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void HaveBT(ref bool havebt, ref bool bton, ref bool supportble);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "GetEditionID")]
		internal static extern bool GetEdition(IntPtr handle, ref byte edition, ref byte layout);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern byte GetDevManufacturer(IntPtr handle);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool DoStopSvc(string servicename);

		[DllImport("FWUpdaterDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Auto)]
		internal static extern bool DevExist(uint vid, uint pid, bool usborhid);

		[DllImport("HID.dll", CharSet = CharSet.Auto)]
		internal static extern bool HidD_GetFeature(IntPtr hndRef, [Out] byte[] ReportBuffer, int numberOfBytesToRead);

		[DllImport("HID.dll", CharSet = CharSet.Auto)]
		internal static extern bool HidD_SetFeature(IntPtr hndRef, byte[] ReportBuffer, int nNumberOfBytesToWrite);

		public bool IsExist(uint vid, uint pid, bool usborhid)
		{
			return DevExist(vid, pid, usborhid);
		}

		public bool StopSvc(string servicename)
		{
			return DoStopSvc(servicename);
		}

		public bool HidSetFeature(IntPtr hndRef, byte[] ReportBuffer, int nNumberOfBytesToWrite)
		{
			return HidD_SetFeature(hndRef, ReportBuffer, nNumberOfBytesToWrite);
		}

		public bool HidGetFeature(IntPtr hndRef, [Out] byte[] ReportBuffer, int numberOfBytesToRead)
		{
			return HidD_GetFeature(hndRef, ReportBuffer, numberOfBytesToRead);
		}

		public void haveBT(ref bool havebt, ref bool bton, ref bool supportble)
		{
			HaveBT(ref havebt, ref bton, ref supportble);
		}

		public bool Is64Bit()
		{
			IsWow64Process(Process.GetCurrentProcess().Handle, out var lpSystemInfo);
			return lpSystemInfo;
		}

		public bool IsWin10orGreater()
		{
			return IsWindows10OrGreater();
		}

		public bool IsWin8P1orGreater()
		{
			return IsWindows8BLUEOrGreater();
		}

		public void InstallBLDrv(string path)
		{
			InstallBLDriver(path);
		}

		public void Delay(float duration)
		{
			delay(duration);
		}

		public IntPtr OpenDev(uint vid, uint pid, ushort bcdpid, float blver, int reporttype, int featurelen, int inputlen, int outputlen)
		{
			return OpenDevice(vid, pid, bcdpid, blver, reporttype, featurelen, inputlen, outputlen);
		}

		public IntPtr OpenBootloader(uint vid, uint pid, ushort bcdpid, float blver)
		{
			return GetBootloaderHandle(vid, pid, bcdpid, blver);
		}

		public void CloseDev(IntPtr handle)
		{
			CloseDevice(handle);
		}

		public string GetBCDPID(IntPtr handle, float blver)
		{
			ushort devPIDInBootloader = GetDevPIDInBootloader(handle, blver);
			return $"{devPIDInBootloader:X4}";
		}

		public int EnterDevMode(IntPtr handle, byte mode)
		{
			if (Common.updateInfo.GetDevType(Common.updateInfo.CurDevIndex) == 7)
			{
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1000" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1100")
				{
					EnterPS4Bootloader(handle, 48, 1);
				}
				else
				{
					EnterPS4Bootloader(handle, 48, 2);
				}
				return 2;
			}
			return EnterDeviceMode(handle, mode);
		}

		public string GetDevFWVer(IntPtr handle, bool nxp)
		{
			if (Common.updateInfo.GetDevType(Common.updateInfo.CurDevIndex) == 7)
			{
				int num = 0;
				num = ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1000" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1100") ? 1 : 2);
				byte[] array = new byte[4];
				GetPS4FWVerion(handle, 48, num, array);
				return $"{array[0]:D}.{array[1]:D2}.{array[2]:D2}";
			}
			byte devtype = Convert.ToByte(Common.updateInfo.GetDevType(Common.updateInfo.CurDevIndex));
			byte[] array2 = new byte[9];
			if (2 == GetFWVersion(handle, array2, devtype))
			{
				if (nxp)
				{
					return $"{array2[0]:D}.{array2[1]:D2}.{array2[2]:D2}";
				}
				return $"{array2[4]:D}.{array2[5]:D2}.{array2[6]:D2}";
			}
			return "";
		}

		public bool GetEID(IntPtr handle, ref byte edition, ref byte layout)
		{
			return GetEdition(handle, ref edition, ref layout);
		}

		public int EraseFW(IntPtr handle, uint startaddr, uint endaddr)
		{
			return DFUErase(handle, startaddr, endaddr);
		}

		public int ProgramFW(IntPtr handle, byte datasize, uint startaddr, int delaytime, byte[] data)
		{
			return DFUProgram(handle, datasize, startaddr, delaytime, data);
		}

		public int VerifyFW(IntPtr handle, byte datasize, uint startaddr, int delaytime, byte[] data)
		{
			return DFUVerify(handle, datasize, startaddr, delaytime, data);
		}

		public int ExitBL(IntPtr handle, float blver)
		{
			if (blver == 3f)
			{
				byte outpipe = 0;
				byte inpipe = 0;
				if (GetPipeID(handle, ref inpipe, ref outpipe))
				{
					if (OutData(buffer: new byte[1] { 7 }, handle: handle, outpipe: outpipe, len: 1uL))
					{
						return 2;
					}
					return 0;
				}
				return 0;
			}
			if (blver == 2f)
			{
				return DFUExit(handle);
			}
			if (WinUSB_ControlOut(handle, 132, 0, 0u, 0, null))
			{
				return 2;
			}
			return 0;
		}

		public bool ClearVariableStorage(IntPtr handle)
		{
			return BackToDefult(handle);
		}

		public int SendCommand(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, byte pktmsb, byte pktlsb, byte paramlen, int getrepretry, int delay, byte[] param, byte[] retdata)
		{
			return SendCmd(handle, reportid, cmdcls, cmdid, pktmsb, pktlsb, paramlen, getrepretry, delay, param, retdata);
		}

		public bool WinUSB_ControlOut(IntPtr handle, byte bcommand, ushort uvalue, uint uindex, ushort ulength, byte[] rbBuffer)
		{
			return ControlOut(handle, bcommand, uvalue, uindex, ulength, rbBuffer);
		}

		public bool WinUSB_ControlIn(IntPtr handle, byte bcommand, ushort uvalue, uint uindex, ushort ulength, byte[] rbBuffer)
		{
			return ControlIn(handle, bcommand, uvalue, uindex, ulength, rbBuffer);
		}

		public string GetBLFWVer(IntPtr handle, float blver)
		{
			byte[] array = new byte[5];
			if (2 == GetBLFWVERInBootloader(handle, blver, array))
			{
				return $"{array[0]:D}.{array[1]:D2}.{array[2]:D2}.{array[3]:D2}";
			}
			return "";
		}

		public int ActiveProfile(IntPtr handle, byte activeprofile)
		{
			return SetActiveProfile(handle, activeprofile);
		}

		public bool RestartSystem()
		{
			return RebootSystem();
		}

		public bool GetPipeID(IntPtr handle, ref byte inpipe, ref byte outpipe)
		{
			return CheckPipeID(handle, ref inpipe, ref outpipe);
		}

		public bool ReadPipe(IntPtr handle, byte inpipe, byte[] buffer, int len)
		{
			return ReadData(handle, inpipe, buffer, len);
		}

		public bool WritePipe(IntPtr handle, byte outpipe, byte[] buffer, ulong len)
		{
			return OutData(handle, outpipe, buffer, len);
		}

		public bool SetFeatureReport(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, byte pktmsb, byte pktlsb, byte paramlen, int setretry, int delay, byte[] param)
		{
			return SetFeatureRpt(handle, reportid, cmdcls, cmdid, pktmsb, pktlsb, paramlen, setretry, delay, param);
		}

		public int GetFeatureReport(IntPtr handle, byte reportid, byte cmdcls, byte cmdid, int getretry, int delay, byte[] param)
		{
			return GetFeatureRpt(handle, reportid, cmdcls, cmdid, getretry, delay, param);
		}

		public byte GetManufacturer(IntPtr handle)
		{
			return GetDevManufacturer(handle);
		}
	}
}
