using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Razer.AccountManager;
using Razer.ActionService;

namespace CustomerFWU2Point5
{
	internal class appContextDevice : ApplicationContext
	{
		protected DeviceInterface device;

		protected List<Form> deviceForms;

		protected Form currForm;

		private string strPID;

		public static bool RunSilent = true;

		private Image m_Product_Image;

		protected Image PRODUCT_IMAGE
		{
			get
			{
				return m_Product_Image;
			}
			set
			{
				m_Product_Image = value;
			}
		}

		public appContextDevice()
		{
			InitializeDevice();
		}

		public void InstallBL()
		{
			bool flag = false;
			bool flag2 = device.Is64Bit();
			flag = device.IsWin10orGreater();
			string directoryName = Path.GetDirectoryName(Application.ExecutablePath);
			directoryName = ((flag2 && flag) ? (directoryName.Trim('\\') + "\\BootLoader\\Win10\\amd64\\DPInst_amd64.exe") : ((!flag2 && flag) ? (directoryName.Trim('\\') + "\\BootLoader\\Win10\\i386\\DPInst_x86.exe") : ((flag2 || flag) ? (directoryName.Trim('\\') + "\\BootLoader\\Win81below\\amd64\\DPInst_amd64.exe") : (directoryName.Trim('\\') + "\\BootLoader\\Win81below\\i386\\DPInst_x86.exe"))));
			Logger.getInstance().writeLog("install Bl driver, Path is" + directoryName, 1);
			device.InstallBLDrv(directoryName);
		}

		public virtual void InitializeDevice()
		{
			try
			{
				if (!Common.forsynapseuse)
				{
					CLocalize instance = CLocalize.getInstance();
					Thread.CurrentThread.CurrentUICulture = instance.getCulture();
				}
				else
				{
					AccountManagerClient accountManagerClient = new AccountManagerClient(string.Empty, string.Empty);
					accountManagerClient.UILanguageChanged += _accounts_UILanguageChanged;
					LanguageInfo uILanguage = accountManagerClient.GetUILanguage();
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(uILanguage.LanguageKey);
				}
			}
			catch (Exception)
			{
				CLocalize instance2 = CLocalize.getInstance();
				Thread.CurrentThread.CurrentUICulture = instance2.getCulture();
			}
			device = new DeviceInterface();
			if (Common.updateInfo.CurDevIndex < 0)
			{
				strPID = Common.updateInfo.GetPID(1);
			}
			else
			{
				strPID = Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex);
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f)
			{
				InstallBL();
			}
			try
			{
				if (Common.forsynapseuse)
				{
					IntPtr zero = IntPtr.Zero;
					zero = ((Common.updateInfo.CurDevIndex >= 0) ? device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(1), 16), Convert.ToUInt32(Common.updateInfo.GetPID(1), 16), 0, 0f, Common.updateInfo.GetDevReportType(1), Common.updateInfo.GetFeatureRptLen(1), Common.updateInfo.GetInputRptLen(1), Common.updateInfo.GetOutputRptLen(1)));
					if (zero != IntPtr.Zero)
					{
						if (string.Compare(device.GetDevFWVer(zero, nxp: true), Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex)) >= 0)
						{
							Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
							return;
						}
						device.CloseDev(zero);
					}
				}
				IntPtr zero2 = IntPtr.Zero;
				zero2 = ((Common.updateInfo.CurDevIndex >= 0) ? device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(1), 16), Convert.ToUInt32(Common.updateInfo.GetPID(1), 16), 0, 0f, Common.updateInfo.GetDevReportType(1), Common.updateInfo.GetFeatureRptLen(1), Common.updateInfo.GetInputRptLen(1), Common.updateInfo.GetOutputRptLen(1)));
				if (zero2 != IntPtr.Zero)
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0065")
					{
						byte edition = byte.MaxValue;
						if (device.GetEID(zero2, ref edition, ref Common.layout) && edition == 128)
						{
							Common.newedition = true;
						}
					}
					if ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C00" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0269") && !device.GetEID(zero2, ref Common.devedition, ref Common.layout))
					{
						Common.devedition = 0;
					}
					device.CloseDev(zero2);
				}
				deviceForms = new List<Form>();
				deviceForms.Add(new FormGuide(device));
				deviceForms.Add(new PromptExitSynapse());
				deviceForms.Add(new FormRaijuEnterBL(device));
				deviceForms.Add(new FormPantheraEnterBL(device));
				deviceForms.Add(new FormFWUStep1(device));
				deviceForms.Add(new FormCongratulation());
				deviceForms.Add(new ShowModelNo());
				if (strPID == "0A00" || strPID == "0A14")
				{
					Common.NextPage = PageIndex.FormRaijuEnterBL;
				}
				else if (strPID == "0401")
				{
					Common.NextPage = PageIndex.FormPantheraEnterBL;
				}
				else
				{
					Common.NextPage = PageIndex.FormGuide;
				}
				currForm = deviceForms.ElementAt((int)Common.NextPage);
				currForm.Closed += OnFormClosed;
				currForm.Show();
			}
			catch (Exception ex2)
			{
				MessageBox.Show(ex2.Message);
				Logger.getInstance().writeLog("when add page, encountr exception", 2);
			}
		}

		private void _accounts_UILanguageChanged(object sender, UILanguageChangedEventArgs e)
		{
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(e.NewLanguage.LanguageKey);
		}

		protected void OnFormClosed(object sender, EventArgs e)
		{
			Point location = currForm.Location;
			currForm.Dispose();
			if (Common.NextPage < PageIndex.Close)
			{
				currForm = deviceForms.ElementAt((int)Common.NextPage);
				if (currForm == null || currForm.IsDisposed)
				{
					switch (Common.NextPage)
					{
					case PageIndex.FormGuide:
						currForm = new FormGuide(device);
						break;
					case PageIndex.ShowModelNo:
						currForm = new ShowModelNo();
						break;
					case PageIndex.PromptExitSynapse:
						currForm = new PromptExitSynapse();
						break;
					case PageIndex.FormRaijuEnterBL:
						currForm = new FormRaijuEnterBL(device);
						break;
					case PageIndex.FormPantheraEnterBL:
						currForm = new FormPantheraEnterBL(device);
						break;
					case PageIndex.FormFWUStep1:
						currForm = new FormFWUStep1(device);
						break;
					case PageIndex.FormCongratulation:
						currForm = new FormCongratulation();
						break;
					}
				}
				if (currForm != null && !currForm.IsDisposed)
				{
					currForm.Closed += OnFormClosed;
					currForm.StartPosition = FormStartPosition.Manual;
					currForm.Location = location;
					currForm.Show();
					return;
				}
				ExitThread();
			}
			ExitThread();
		}
	}
}
