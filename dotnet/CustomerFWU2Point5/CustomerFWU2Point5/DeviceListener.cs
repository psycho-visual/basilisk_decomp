using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CustomerFWU2Point5
{
	public class DeviceListener
	{
		public struct DEV_BROADCAST_HANDLE
		{
			public int dbcc_size;

			public int dbcc_devicetype;

			public int dbcc_reserved;

			public Guid dbcc_classguid;

			public char dbch_name0;

			public char dbch_name1;

			public char dbch_name2;

			public char dbch_name3;

			public char dbch_name4;

			public char dbch_name5;

			public char dbch_name6;

			public char dbch_name7;

			public char dbch_name8;

			public char dbch_name9;

			public char dbch_name10;

			public char dbch_name11;

			public char dbch_name12;

			public char dbch_name13;

			public char dbch_name14;

			public char dbch_name15;

			public char dbch_name16;

			public char dbch_name17;

			public char dbch_name18;

			public char dbch_name19;

			public char dbch_name20;

			public char dbch_name21;

			public char dbch_name22;

			public char dbch_name23;

			public char dbch_name24;

			public char dbch_name25;

			public char dbch_name26;

			public char dbch_name27;

			public char dbch_name28;

			public char dbch_name29;

			public char dbch_name30;

			public char dbch_name31;

			public char dbch_name32;

			public char dbch_name33;

			public char dbch_name34;

			public char dbch_name35;

			public char dbch_name36;

			public char dbch_name37;

			public char dbch_name38;

			public char dbch_name39;

			public char dbch_name40;

			public char dbch_name41;

			public char dbch_name42;

			public char dbch_name43;

			public char dbch_name44;

			public char dbch_name45;

			public char dbch_name46;

			public char dbch_name47;

			public char dbch_name48;

			public char dbch_name49;

			public char dbch_name50;
		}

		public struct DEV_BROADCAST_HDR
		{
			public int dbch_size;

			public int dbch_devicetype;

			public int dbch_reserved;
		}

		private class Native
		{
			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern IntPtr RegisterDeviceNotification(IntPtr hRecipient, IntPtr NotificationFilter, uint Flags);

			[DllImport("user32.dll", CharSet = CharSet.Auto)]
			public static extern uint UnregisterDeviceNotification(IntPtr hHandle);
		}

		private static Guid rawUsbGUID = new Guid("A5DCBF10-6530-11D2-901F-00C04FB951ED");

		public const int WM_DEVICECHANGE = 537;

		public const int DBT_DEVICEARRIVAL = 32768;

		public const int DBT_CONFIGCHANGECANCELED = 25;

		public const int DBT_CONFIGCHANGED = 24;

		public const int DBT_CUSTOMEVENT = 32774;

		public const int DBT_DEVICEQUERYREMOVE = 32769;

		public const int DBT_DEVICEQUERYREMOVEFAILED = 32770;

		public const int DBT_DEVICEREMOVECOMPLETE = 32772;

		public const int DBT_DEVICEREMOVEPENDING = 32771;

		public const int DBT_DEVICETYPESPECIFIC = 32773;

		public const int DBT_DEVNODES_CHANGED = 7;

		public const int DBT_QUERYCHANGECONFIG = 23;

		public const int DBT_USERDEFINED = 65535;

		public const int DBT_DEVTYP_DEVICEINTERFACE = 5;

		public const int DBT_DEVTYP_HANDLE = 6;

		public const int BROADCAST_QUERY_DENY = 1112363332;

		private List<Common.VidPid> deviceList;

		private static bool fRunning = false;

		private IntPtr hCtrl = IntPtr.Zero;

		public event EventHandler<DeviceListenerEvent> RaiseDeviceEvent;

		public void DoDeviceEvent(Common.VidPid vidPid, bool fConnected)
		{
			OnRaiseDeviceEvent(new DeviceListenerEvent(vidPid, fConnected));
		}

		private unsafe static string DBHToString(DEV_BROADCAST_HANDLE* pDBH)
		{
			return (pDBH->dbch_name0.ToString() + pDBH->dbch_name1 + pDBH->dbch_name2 + pDBH->dbch_name3 + pDBH->dbch_name4 + pDBH->dbch_name5 + pDBH->dbch_name6 + pDBH->dbch_name7 + pDBH->dbch_name8 + pDBH->dbch_name9 + pDBH->dbch_name10 + pDBH->dbch_name11 + pDBH->dbch_name12 + pDBH->dbch_name13 + pDBH->dbch_name14 + pDBH->dbch_name15 + pDBH->dbch_name16 + pDBH->dbch_name17 + pDBH->dbch_name18 + pDBH->dbch_name19 + pDBH->dbch_name20 + pDBH->dbch_name21 + pDBH->dbch_name22 + pDBH->dbch_name23 + pDBH->dbch_name24 + pDBH->dbch_name25 + pDBH->dbch_name26 + pDBH->dbch_name27 + pDBH->dbch_name28 + pDBH->dbch_name29 + pDBH->dbch_name30 + pDBH->dbch_name31 + pDBH->dbch_name32 + pDBH->dbch_name33 + pDBH->dbch_name34 + pDBH->dbch_name35 + pDBH->dbch_name36 + pDBH->dbch_name37 + pDBH->dbch_name38 + pDBH->dbch_name39 + pDBH->dbch_name40 + pDBH->dbch_name41 + pDBH->dbch_name42 + pDBH->dbch_name43 + pDBH->dbch_name44).ToUpper();
		}

		public DeviceListener()
		{
			deviceList = new List<Common.VidPid>();
		}

		~DeviceListener()
		{
		}

		public void AddDevice(Common.VidPid vidPid)
		{
			deviceList.Add(vidPid);
		}

		public void RemoveAll()
		{
			deviceList.Clear();
		}

		public void Start(IntPtr handle)
		{
			Logger.getInstance().writeLog("DeviceListener:Start: RegisterForDeviceChange()", 1);
			DEV_BROADCAST_HANDLE dEV_BROADCAST_HANDLE = new DEV_BROADCAST_HANDLE
			{
				dbcc_devicetype = 5,
				dbcc_classguid = rawUsbGUID
			};
			IntPtr intPtr = Marshal.AllocHGlobal(dEV_BROADCAST_HANDLE.dbcc_size = Marshal.SizeOf(typeof(DEV_BROADCAST_HANDLE)));
			Marshal.StructureToPtr(dEV_BROADCAST_HANDLE, intPtr, fDeleteOld: true);
			if (!Native.RegisterDeviceNotification(handle, intPtr, 0u).Equals(null))
			{
				fRunning = true;
			}
		}

		public void Stop()
		{
			if (fRunning)
			{
				Native.UnregisterDeviceNotification(hCtrl);
			}
			fRunning = false;
		}

		public unsafe void Process(ref Message msg)
		{
			if (!fRunning || 537 != msg.Msg)
			{
				return;
			}
			int num = msg.WParam.ToInt32();
			if (32768 != num && 32772 != num)
			{
				return;
			}
			DEV_BROADCAST_HDR* ptr = (DEV_BROADCAST_HDR*)msg.LParam.ToPointer();
			DEV_BROADCAST_HANDLE* ptr2 = (DEV_BROADCAST_HANDLE*)ptr;
			if (null == ptr2)
			{
				return;
			}
			for (int i = 0; i < deviceList.Count; i++)
			{
				Common.VidPid vidPid = deviceList[i];
				string text = DBHToString(ptr2);
				Logger.getInstance().writeLog($"DeviceListener:: VID: {vidPid.GetVID()}, PID: {vidPid.GetPID()}", 1);
				if (-1 != text.IndexOf(vidPid.GetVID()) && -1 != text.IndexOf(vidPid.GetPID()))
				{
					DoDeviceEvent(vidPid, (32768 == num) ? true : false);
					break;
				}
			}
		}

		private void OnRaiseDeviceEvent(DeviceListenerEvent evt)
		{
			this.RaiseDeviceEvent?.Invoke(this, evt);
		}
	}
}
