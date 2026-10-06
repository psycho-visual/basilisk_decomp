using System;
using System.Threading;
using System.Windows.Forms;

namespace CustomerFWU2Point5
{
	internal static class Program
	{
		private static Mutex deviceMutex;

		[STAThread]
		private static void Main()
		{
			Logger.getInstance().writeLog("Enter Main...", 1);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(defaultValue: false);
			try
			{
				Common.updateInfo = new UpdateInfo();
				Logger.getInstance().writeLog("update info object open success", 1);
				if (!CheckFirstInstance())
				{
					new DeviceInterface();
					string productName = Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex);
					MessageBox.Show("Another instance is already running.", $"Razer {productName} Device Updater");
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			Application.Run(new appContextDevice());
		}

		private static bool CheckFirstInstance()
		{
			Logger.getInstance().writeLog("CheckFirstInstance start...", 1);
			DeviceInterface deviceInterface = new DeviceInterface();
			Logger.getInstance().writeLog("Common.updateInfo.SupportDevCount is " + Common.updateInfo.SupportDevCount, 1);
			if (Common.updateInfo.SupportDevCount >= 2)
			{
				for (int i = 1; i <= Common.updateInfo.SupportDevCount; i++)
				{
					IntPtr zero = IntPtr.Zero;
					zero = ((Common.updateInfo.GetBLVer(i) != 2f) ? deviceInterface.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(i), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(i), 16), Common.updateInfo.GetBLVer(i)) : deviceInterface.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(i), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(i), 16), Common.updateInfo.GetBLVer(i), 12, 91, 0, 0));
					if (zero != IntPtr.Zero)
					{
						Common.updateInfo.CurDevIndex = i;
						deviceInterface.CloseDev(zero);
						zero = IntPtr.Zero;
						break;
					}
					IntPtr intPtr = deviceInterface.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetPID(i), 16), 0, 0f, Common.updateInfo.GetDevReportType(i), Common.updateInfo.GetFeatureRptLen(i), Common.updateInfo.GetInputRptLen(i), Common.updateInfo.GetOutputRptLen(i));
					if (intPtr != IntPtr.Zero)
					{
						Common.updateInfo.CurDevIndex = i;
						deviceInterface.CloseDev(intPtr);
						intPtr = IntPtr.Zero;
						break;
					}
				}
			}
			else
			{
				Common.updateInfo.CurDevIndex = 1;
			}
			string text = "";
			text = ((Common.updateInfo.CurDevIndex != -1) ? Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex) : Common.updateInfo.GetProductName(1));
			Logger.getInstance().writeLog("deviceName is " + text, 1);
			string name = $"Razer{text}DeviceUpdater";
			deviceMutex = new Mutex(initiallyOwned: true, name, out var createdNew);
			return createdNew;
		}
	}
}
