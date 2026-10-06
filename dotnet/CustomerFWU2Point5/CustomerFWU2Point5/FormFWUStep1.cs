using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CustomProgressBar;
using CustomerFWU2Point5.Properties;
using CustomerFWU2Point5.Resources;
using CustomerFirmwareUpdater;
using Microsoft.Win32;

namespace CustomerFWU2Point5
{
	public class FormFWUStep1 : Form
	{
		private struct SYSTEM_POWER_STATUS
		{
			public byte ACLineStatus;

			public byte BatteryFlag;

			public byte BatteryLifePercent;

			public byte Reserved1;

			public int BatteryLifeTime;

			public int BatteryFullLifeTime;
		}

		private bool synapsemessageclose;

		public bool checkbattery;

		private List<string> B5SKU = new List<string>();

		private ushort m_uPageSize = Common.updateInfo.PageSize;

		private ushort m_uDataPacketSize = Common.updateInfo.DataPacketSize;

		private string m_strFormattedData = "";

		private uint m_uAddressBegin;

		private uint m_uAddressEnd;

		private bool m_fAddressBeginSet;

		private string m_LastError = string.Empty;

		private const byte COMMAND_WRITE = 129;

		private const byte COMMAND_ERASE = 130;

		private const byte COMMAND_CHECKSUM = 131;

		private const byte COMMAND_EXITBL = 132;

		private const byte COMMAND_VERIFY = 135;

		private const byte COMMAND_STATUS = 143;

		private const byte COMMAND_BOOTLOADER_DOWNLOAD = 128;

		private const int MAX_RETRY_GET = 50;

		private const int MAX_RETRY_SET = 50;

		private bool stopclosethread;

		private eState curstate;

		private Point lastPoint = Point.Empty;

		private DeviceInterface device;

		private bool devconnect;

		private bool blconnect;

		private DeviceListener devlistener = new DeviceListener();

		public bool checkingretry;

		private bool devreconnect;

		private Common.VidPid deviceVidPid;

		private Common.VidPid BLVidPid;

		private const int WINUSB_DATA_SIZE = 8;

		private const byte CONTROL_REQUEST = 131;

		private byte[] DevSN = new byte[22];

		private IContainer components;

		private Label labelHeader;

		private Label labelpluginDevice;

		private Label labelPromptMessage;

		private Label labelUpdateprogress;

		private Label labelUpdateInfor;

		private global::CustomProgressBar.CustomProgressBar progressBarupdate;

		private MyButton buttonUpdate;

		private MyButton buttonCancel;

		private Label labeltargetver;

		private Label labelCurFWver;

		private BackgroundWorker backgroundWorkerProcessFWData;

		private BackgroundWorker backgroundWorkerCheckVer;

		private BackgroundWorker backgroundWorkerEraseFlash;

		private BackgroundWorker backgroundWorkerProgramFW;

		private BackgroundWorker backgroundWorkerVerify;

		private System.Windows.Forms.Timer timerbllistener;

		private System.Windows.Forms.Timer timerblentersuccess;

		private BackgroundWorker backgroundWorkerCloseRestartDialog;

		private BackgroundWorker backgroundWorkercheckbattery;

		private BackgroundWorker backgroundWorkerCheckFlashFWVer;

		private BackgroundWorker backgroundWorkerNordicENTERBL;

		private BackgroundWorker backgroundWorkerGetRegionInfor;

		private BackgroundWorker backgroundWorkerNordicProgram;

		private BackgroundWorker backgroundWorkerVerifyNordicFW;

		private Label labelpressandholdpwrbtn;

		private Label labelkeepholdprompt;

		private BackgroundWorker backgroundWorkerProcessFlashFW;

		private BackgroundWorker backgroundWorkerSetFlashRegionIDList;

		private BackgroundWorker backgroundWorkerProgramSTMFlashFW;

		private Label labelupdaterstatus;

		private System.Windows.Forms.Timer timerexitbldetect;

		[DllImport("kernel32")]
		private static extern void GetSystemPowerStatus(ref SYSTEM_POWER_STATUS lpSystemPowerStatus);

		private bool callWinusbChecksumControl(IntPtr handle, int mode, ref int checksumMCU)
		{
			curstate = eState.STATE_VERIFYING_FIRMWARE;
			byte[] array = new byte[8];
			backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE);
			device.Delay(1000f);
			if (device.WinUSB_ControlOut(handle, 131, (ushort)mode, 0u, 0, array))
			{
				backgroundWorkerVerify.ReportProgress(50);
				device.Delay(100f);
				device.WinUSB_ControlIn(handle, 131, 0, 0u, 2, array);
				checksumMCU = array[0] * 256 + array[1];
				backgroundWorkerVerify.ReportProgress(100);
				return true;
			}
			backgroundWorkerVerify.ReportProgress(50);
			return false;
		}

		public FormFWUStep1()
		{
			InitializeComponent();
		}

		public FormFWUStep1(DeviceInterface device)
		{
			this.device = device;
			InitializeComponent();
		}

		private string GetSystemSKUID()
		{
			RegistryKey registryKey = null;
			try
			{
				registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS", writable: false);
			}
			catch (Exception)
			{
				MessageBox.Show("Can't Get System SKU ID");
				return "";
			}
			if (registryKey != null)
			{
				if (registryKey.GetValueNames().Contains("SystemSKU"))
				{
					return registryKey.GetValue("SystemSKU").ToString();
				}
				return "";
			}
			return "";
		}

		private void HandleDeviceListenerEvent(object sender, DeviceListenerEvent e)
		{
			if (e.IsConnected())
			{
				Thread.Sleep(200);
				if (Common.updateInfo.CurDevIndex < 0)
				{
					for (int i = 1; i <= Common.updateInfo.SupportDevCount; i++)
					{
						Common.VidPid vidPid = new Common.VidPid(Common.updateInfo.GetVID(i), Common.updateInfo.GetPID(i));
						if (e.GetVidPid() == vidPid && e.IsConnected())
						{
							Common.updateInfo.CurDevIndex = i;
							devlistener.RemoveAll();
							deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), bconnect: false);
							BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), bconnect: false);
							devlistener.AddDevice(deviceVidPid);
							devlistener.AddDevice(BLVidPid);
						}
					}
					if (Common.updateInfo.CurDevIndex == -1)
					{
						for (int j = 1; j <= Common.updateInfo.SupportDevCount; j++)
						{
							IntPtr zero = IntPtr.Zero;
							zero = ((Common.updateInfo.GetBLVer(j) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(j), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(j), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(j), 16), Common.updateInfo.GetBLVer(j)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(j), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(j), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(j), 16), Common.updateInfo.GetBLVer(j), 12, 91, 0, 0));
							if (!(zero != IntPtr.Zero))
							{
								continue;
							}
							if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
							{
								if (device.GetManufacturer(zero) == 128)
								{
									Common.updateInfo.CurDevIndex = 1;
								}
								else
								{
									Common.updateInfo.CurDevIndex = 2;
								}
							}
							else
							{
								Common.updateInfo.CurDevIndex = j;
							}
							blconnect = true;
							device.CloseDev(zero);
							zero = IntPtr.Zero;
							break;
						}
					}
				}
			}
			if (deviceVidPid == e.GetVidPid())
			{
				if (!e.IsConnected())
				{
					devconnect = false;
					if (curstate != eState.STATE_EXIT_NordicBL && curstate != eState.STATE_ENTER_BL)
					{
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
						{
							BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
							labelpluginDevice.ForeColor = Common.greendarktheme;
							labelkeepholdprompt.ForeColor = Color.Red;
							labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
						}
						progressBarupdate.Visible = false;
						labelCurFWver.Visible = false;
						labelPromptMessage.Visible = false;
						labeltargetver.Visible = false;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) != "0517")
						{
							labelpluginDevice.ForeColor = Common.greendarktheme;
						}
						buttonUpdate.Enabled = false;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					}
					if (Common.updateInfo.SupportDevCount >= 2 && curstate == eState.STATE_NULL)
					{
						Common.updateInfo.CurDevIndex = -1;
						devlistener.RemoveAll();
						for (int k = 1; k <= Common.updateInfo.SupportDevCount; k++)
						{
							new Common.VidPid(Common.updateInfo.GetVID(k), Common.updateInfo.GetPID(k));
							deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(k), Common.updateInfo.GetPID(k), bconnect: false);
							BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(k), Common.updateInfo.GetBLPID(k), bconnect: false);
							devlistener.AddDevice(deviceVidPid);
							devlistener.AddDevice(BLVidPid);
						}
					}
					return;
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
				{
					ForceEnterUSBMode();
				}
				if (checkingretry)
				{
					devreconnect = true;
				}
				if (curstate == eState.STATE_EXIT_NordicBL)
				{
					curstate = eState.STATE_FLASHFW_AFTER;
					if (!backgroundWorkerCheckFlashFWVer.IsBusy)
					{
						backgroundWorkerCheckFlashFWVer.RunWorkerAsync();
					}
					return;
				}
				Thread.Sleep(1100);
				devconnect = true;
				if (curstate == eState.STATE_EXIT_BL)
				{
					timerexitbldetect.Enabled = false;
					timerexitbldetect.Stop();
				}
				timerblentersuccess.Enabled = false;
				timerblentersuccess.Stop();
				timerbllistener.Enabled = false;
				timerbllistener.Stop();
				if (curstate != eState.STATE_EXIT_BL)
				{
					curstate = eState.STATE_NULL;
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) != "0401" && Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) != "0A00" && Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) != "0A14")
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
					{
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.presspowerbtn_drk;
						labelkeepholdprompt.ForeColor = Color.Red;
						labelpressandholdpwrbtn.ForeColor = Color.White;
					}
					labelpluginDevice.ForeColor = Color.White;
					if (!backgroundWorkerCheckVer.IsBusy)
					{
						backgroundWorkerCheckVer.RunWorkerAsync();
					}
				}
				else if (curstate == eState.STATE_EXIT_BL)
				{
					buttonUpdate.Enabled = true;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
			}
			else
			{
				if (!(BLVidPid == e.GetVidPid()))
				{
					return;
				}
				if (!e.IsConnected())
				{
					blconnect = false;
					stopclosethread = true;
					if (curstate == eState.STATE_NULL)
					{
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
						{
							BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
							labelpluginDevice.ForeColor = Common.greendarktheme;
							labelkeepholdprompt.ForeColor = Color.Red;
							labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
						}
						progressBarupdate.Visible = false;
						labelCurFWver.Visible = false;
						labelPromptMessage.Visible = false;
						labeltargetver.Visible = false;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
						labelpluginDevice.ForeColor = Common.greendarktheme;
						buttonUpdate.Enabled = false;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
						if (Common.updateInfo.SupportDevCount >= 2)
						{
							Common.updateInfo.CurDevIndex = -1;
							devlistener.RemoveAll();
							for (int l = 1; l <= Common.updateInfo.SupportDevCount; l++)
							{
								new Common.VidPid(Common.updateInfo.GetVID(l), Common.updateInfo.GetPID(l));
								deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(l), Common.updateInfo.GetPID(l), bconnect: false);
								BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(l), Common.updateInfo.GetBLPID(l), bconnect: false);
								devlistener.AddDevice(deviceVidPid);
								devlistener.AddDevice(BLVidPid);
							}
						}
					}
					else if (curstate == eState.STATE_EXIT_BL && !Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
					{
						progressBarupdate.Visible = false;
						labelPromptMessage.Visible = false;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
					}
					return;
				}
				Thread.Sleep(1000);
				IntPtr zero2 = IntPtr.Zero;
				zero2 = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
				if (!(zero2 != IntPtr.Zero))
				{
					return;
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
				{
					if (device.GetManufacturer(zero2) == 128)
					{
						Common.updateInfo.CurDevIndex = 1;
					}
					else
					{
						Common.updateInfo.CurDevIndex = 2;
					}
				}
				device.CloseDev(zero2);
				zero2 = IntPtr.Zero;
				blconnect = true;
				Common.DevFWNeedUpdate = true;
				if (checkingretry)
				{
					devreconnect = true;
				}
				if (checkingretry)
				{
					return;
				}
				if (curstate == eState.STATE_ENTER_BL)
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
					{
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothgray_drk;
					}
					timerblentersuccess.Stop();
					timerblentersuccess.Enabled = false;
					timerbllistener.Stop();
					timerbllistener.Enabled = false;
					if (!backgroundWorkerCloseRestartDialog.IsBusy)
					{
						backgroundWorkerCloseRestartDialog.RunWorkerAsync();
					}
					if (!backgroundWorkerProcessFWData.IsBusy)
					{
						backgroundWorkerProcessFWData.RunWorkerAsync();
					}
					return;
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0401" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A00" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A14")
				{
					backgroundWorkerProgramFW.RunWorkerAsync();
				}
				else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007")
				{
					labelCurFWver.Visible = false;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = false;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonCancel.Enabled = true;
					buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.noupdaterequired;
					labeltargetver.ForeColor = Common.lightgray;
					labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257")
				{
					labelCurFWver.Visible = false;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = false;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonCancel.Enabled = true;
					buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.noupdaterequired;
					labeltargetver.ForeColor = Common.lightgray;
					labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
					return;
				}
				if (!synapsemessageclose)
				{
					labelCurFWver.Text = ResourceStr.devicever;
					labelCurFWver.Visible = true;
					labeltargetver.Visible = true;
					labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
					labelCurFWver.ForeColor = Common.lightgray;
					labelpluginDevice.ForeColor = Color.White;
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = true;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					buttonUpdate.Enabled = true;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
					if (Common.IsBladeKB())
					{
						labelupdaterstatus.Visible = true;
						labelupdaterstatus.ForeColor = Common.greendarktheme;
						labelupdaterstatus.Text = ResourceStr.anupdaterequired;
					}
					else
					{
						labelupdaterstatus.Visible = false;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						labelPromptMessage.Text = ResourceStr.anupdaterequired;
					}
					return;
				}
				labelupdaterstatus.Visible = false;
				labelPromptMessage.Visible = true;
				if (Common.IsBladeKB())
				{
					labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
				}
				else
				{
					labelPromptMessage.Text = ResourceStr.Nounplug;
				}
				labelpluginDevice.ForeColor = Color.White;
				labelCurFWver.Text = ResourceStr.devicever;
				labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
				labelCurFWver.ForeColor = Common.lightgray;
				labeltargetver.ForeColor = Common.greendarktheme;
				labeltargetver.Visible = true;
				labelCurFWver.Visible = true;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_click;
				buttonUpdate.Enabled = false;
				buttonCancel.Enabled = false;
				labelUpdateInfor.Visible = true;
				labelUpdateprogress.Visible = true;
				progressBarupdate.Visible = true;
				if (!backgroundWorkerProcessFWData.IsBusy)
				{
					backgroundWorkerProcessFWData.RunWorkerAsync();
				}
			}
		}

		protected override void WndProc(ref Message m)
		{
			devlistener.Process(ref m);
			base.WndProc(ref m);
		}

		private void FormFWUStep1_Load(object sender, EventArgs e)
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			try
			{
				if (Common.forsynapseuse)
				{
					buttonCancel.Visible = false;
				}
				else
				{
					buttonCancel.Visible = true;
				}
				buttonCancel.Text = ResourceStr.cancel;
				buttonUpdate.Text = ResourceStr.update;
				devlistener.RaiseDeviceEvent += HandleDeviceListenerEvent;
				buttonCancel.Enabled = true;
				labelCurFWver.Text = ResourceStr.devicever;
				labeltargetver.Text = ResourceStr.newver;
				if (Common.updateInfo.SupportDevCount >= 2)
				{
					for (int i = 1; i <= Common.updateInfo.SupportDevCount; i++)
					{
						IntPtr zero = IntPtr.Zero;
						zero = ((Common.updateInfo.GetBLVer(i) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(i), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(i), 16), Common.updateInfo.GetBLVer(i)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(i), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(i), 16), Common.updateInfo.GetBLVer(i), 12, 91, 0, 0));
						if (zero != IntPtr.Zero)
						{
							if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
							{
								if (device.GetManufacturer(zero) == 128)
								{
									Common.updateInfo.CurDevIndex = 1;
								}
								else
								{
									Common.updateInfo.CurDevIndex = 2;
								}
							}
							else
							{
								Common.updateInfo.CurDevIndex = i;
							}
							blconnect = true;
							device.CloseDev(zero);
							zero = IntPtr.Zero;
							break;
						}
						IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(i), 16), Convert.ToUInt32(Common.updateInfo.GetPID(i), 16), 0, 0f, Common.updateInfo.GetDevReportType(i), Common.updateInfo.GetFeatureRptLen(i), Common.updateInfo.GetInputRptLen(i), Common.updateInfo.GetOutputRptLen(i));
						if (intPtr != IntPtr.Zero)
						{
							devconnect = true;
							if (Common.updateInfo.GetPID(i) != "005A" && Common.updateInfo.GetPID(i) != "1004" && Common.updateInfo.GetPID(i) != "1007")
							{
								Common.updateInfo.CurDevIndex = i;
							}
							device.CloseDev(intPtr);
							intPtr = IntPtr.Zero;
							break;
						}
					}
					if (Common.updateInfo.CurDevIndex == -1)
					{
						for (int j = 1; j <= Common.updateInfo.SupportDevCount; j++)
						{
							deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(j), Common.updateInfo.GetPID(j), bconnect: false);
							BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(j), Common.updateInfo.GetBLPID(j), bconnect: false);
							devlistener.AddDevice(deviceVidPid);
							devlistener.AddDevice(BLVidPid);
						}
						devlistener.Start(base.Handle);
					}
					else
					{
						deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), bconnect: false);
						BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), bconnect: false);
						devlistener.AddDevice(deviceVidPid);
						devlistener.AddDevice(BLVidPid);
						devlistener.Start(base.Handle);
					}
				}
				else
				{
					deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), bconnect: false);
					BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), bconnect: false);
					Common.updateInfo.CurDevIndex = 1;
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) != "0A14")
					{
						IntPtr zero2 = IntPtr.Zero;
						zero2 = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
						if (zero2 != IntPtr.Zero)
						{
							blconnect = true;
							device.GetBLFWVer(zero2, Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex));
							device.CloseDev(zero2);
							zero2 = IntPtr.Zero;
						}
						else
						{
							IntPtr intPtr2 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
							if (intPtr2 != IntPtr.Zero)
							{
								if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
								{
									device.EnterDevMode(intPtr2, 7);
								}
								devconnect = true;
								device.CloseDev(intPtr2);
								intPtr2 = IntPtr.Zero;
							}
						}
						devlistener.AddDevice(deviceVidPid);
						devlistener.AddDevice(BLVidPid);
						devlistener.Start(base.Handle);
					}
				}
				int num = 0;
				num = ((Common.updateInfo.CurDevIndex < 0) ? 1 : Common.updateInfo.CurDevIndex);
				if (Common.fordummy)
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
					{
						labelHeader.Text = string.Format(ResourceStr.Title, Common.updateInfo.GetProductName(1).ToUpper() + " (DUMMY)");
					}
					else
					{
						labelHeader.Text = string.Format(ResourceStr.Title, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper() + " (DUMMY)");
					}
				}
				else if (Common.IsBladeKB())
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0253" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0255" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0256")
					{
						if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
						{
							labelHeader.Text = string.Format(ResourceStr.TitleBladeKB.ToUpper(), "雷蛇灵刃".ToUpper());
						}
						else
						{
							labelHeader.Text = string.Format(ResourceStr.TitleBladeKB.ToUpper(), "BLADE".ToUpper());
						}
					}
					else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "026A")
					{
						labelHeader.Text = string.Format(ResourceStr.TitleBladeKB.ToUpper(), "BOOK".ToUpper());
					}
					else if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
					{
						labelHeader.Text = string.Format(ResourceStr.TitleBladeKB.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex).ToUpper());
					}
					else
					{
						labelHeader.Text = string.Format(ResourceStr.TitleBladeKB.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
					}
				}
				else if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
					{
						labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(1).ToUpper());
					}
					else
					{
						labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex).ToUpper());
					}
				}
				else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
				{
					labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(1).ToUpper());
				}
				else
				{
					labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
				}
				labelHeader.ForeColor = Common.greendarktheme;
				Text = labelHeader.Text;
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.fwupdaterBackground;
				if (Common.updateInfo.GetPID(num) == "0A14")
				{
					buttonCancel.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonUpdate.Text = ResourceStr.Done;
					if (Common.updateInfo.GetPID(num) == "0A14")
					{
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.wolverine;
						labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 65);
						labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 65);
						labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 65);
						progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 65);
					}
					labelCurFWver.Visible = false;
					labeltargetver.Visible = true;
					labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(num);
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = true;
					labelUpdateprogress.Visible = true;
					progressBarupdate.Visible = true;
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
					labelPromptMessage.ForeColor = Common.greendarktheme;
					backgroundWorkerProcessFWData.RunWorkerAsync();
					return;
				}
				if (Common.updateInfo.GetPID(num) == "0A00")
				{
					buttonCancel.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonUpdate.Text = ResourceStr.Done;
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.atrox_cong;
					labelCurFWver.Visible = false;
					labeltargetver.Visible = true;
					labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(num);
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = true;
					labelUpdateprogress.Visible = true;
					progressBarupdate.Visible = true;
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 65);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 65);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 65);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 65);
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
					backgroundWorkerProcessFWData.RunWorkerAsync();
					return;
				}
				if (Common.updateInfo.GetPID(num) == "0401")
				{
					buttonCancel.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonUpdate.Text = ResourceStr.Done;
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.panthera;
					labelpluginDevice.Visible = false;
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 30);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 30);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 30);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 30);
					labelCurFWver.Visible = false;
					labeltargetver.Visible = true;
					labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(num);
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = true;
					labelUpdateprogress.Visible = true;
					progressBarupdate.Visible = true;
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 50);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 50);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 50);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 50);
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
					labelPromptMessage.ForeColor = Common.greendarktheme;
					backgroundWorkerProcessFWData.RunWorkerAsync();
					return;
				}
				labelpluginDevice.Visible = true;
				if (Common.updateInfo.GetPID(num) == "1000")
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.raiju;
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 50);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 50);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 50);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 50);
				}
				else if (Common.updateInfo.GetPID(num) == "0F12" || Common.updateInfo.GetPID(num) == "0F28")
				{
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 90);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 90);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 90);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 90);
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.connraptor;
					labelpressandholdpwrbtn.Text = ResourceStr.turnondev;
					labelpressandholdpwrbtn.Location = new Point(labelpluginDevice.Location.X - 30, labelpluginDevice.Location.Y + 5);
					labelpressandholdpwrbtn.Size = new Size(417, 29);
					labelpressandholdpwrbtn.Visible = true;
					labelpressandholdpwrbtn.ForeColor = Color.White;
					labelpressandholdpwrbtn.TextAlign = ContentAlignment.MiddleLeft;
					labelkeepholdprompt.Text = ResourceStr.typecnote;
					labelkeepholdprompt.Visible = true;
					labelkeepholdprompt.ForeColor = Color.White;
					labelkeepholdprompt.Location = new Point(labelkeepholdprompt.Location.X - 30, labelkeepholdprompt.Location.Y - 21);
					labelkeepholdprompt.TextAlign = ContentAlignment.MiddleLeft;
					labelkeepholdprompt.Size = new Size(417, 64);
					labelpluginDevice.Text = ResourceStr.connbytypec;
					labelpluginDevice.Size = new Size(417, 35);
					labelpluginDevice.Location = new Point(labelkeepholdprompt.Location.X, labelkeepholdprompt.Location.Y - 35);
					labelpluginDevice.TextAlign = ContentAlignment.MiddleLeft;
					labelupdaterstatus.Visible = false;
				}
				else if (Common.updateInfo.GetPID(num) == "0220" || Common.updateInfo.GetPID(num) == "020F" || Common.updateInfo.GetPID(num) == "023B" || Common.updateInfo.GetPID(num) == "0240" || Common.updateInfo.GetPID(num) == "0245" || Common.updateInfo.GetPID(num) == "023A" || Common.updateInfo.GetPID(num) == "0234" || Common.updateInfo.GetPID(num) == "0253" || Common.updateInfo.GetPID(num) == "0255" || Common.updateInfo.GetPID(num) == "0256" || Common.updateInfo.GetPID(num) == "026A" || Common.updateInfo.GetPID(num) == "0270")
				{
					if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
					{
						labelpluginDevice.Text = string.Format(ResourceStr.bladekbdetect, Common.updateInfo.GetDeviceName(num));
					}
					else
					{
						labelpluginDevice.Text = string.Format(ResourceStr.bladekbdetect, Common.updateInfo.GetProductName(num));
					}
					if (Common.updateInfo.GetPID(num) == "0220")
					{
						labelpluginDevice.Location = new Point(labelpluginDevice.Location.X - 50, labelpluginDevice.Location.Y + 50);
						labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 30);
						labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 30);
						labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 30);
						progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 30);
					}
					else if (Common.updateInfo.GetPID(num) == "020F")
					{
						labelpluginDevice.Location = new Point(labelpluginDevice.Location.X - 50, labelpluginDevice.Location.Y + 50);
						labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 30);
						labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 30);
						labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 30);
						progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 30);
					}
					else if (Common.updateInfo.GetPID(num) == "023B" || Common.updateInfo.GetPID(num) == "0240" || Common.updateInfo.GetPID(num) == "0245" || Common.updateInfo.GetPID(num) == "023A" || Common.updateInfo.GetPID(num) == "0234" || Common.updateInfo.GetPID(num) == "0253" || Common.updateInfo.GetPID(num) == "0255" || Common.updateInfo.GetPID(num) == "0256" || Common.updateInfo.GetPID(num) == "026A" || Common.updateInfo.GetPID(num) == "0270")
					{
						labelpluginDevice.Location = new Point(labelpluginDevice.Location.X - 50, labelpluginDevice.Location.Y + 10);
					}
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.bladekb;
				}
				else if (Common.updateInfo.GetPID(num) == "0517")
				{
					labelkeepholdprompt.Visible = true;
					labelpressandholdpwrbtn.Visible = true;
					labelpluginDevice.Text = ResourceStr.pluginspeaker;
					labelkeepholdprompt.Text = ResourceStr.keepholdingprompt;
					labelpressandholdpwrbtn.Text = ResourceStr.plugandholdpwrbtn;
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
					labelupdaterstatus.Visible = false;
					labelupdaterstatus.Location = new Point(labelupdaterstatus.Location.X, labelupdaterstatus.Location.Y + 85);
					labelPromptMessage.Location = new Point(labelPromptMessage.Location.X, labelPromptMessage.Location.Y + 85);
					labelUpdateInfor.Location = new Point(labelUpdateInfor.Location.X, labelUpdateInfor.Location.Y + 80);
					labelUpdateprogress.Location = new Point(labelUpdateprogress.Location.X, labelUpdateprogress.Location.Y + 80);
					progressBarupdate.Location = new Point(progressBarupdate.Location.X, progressBarupdate.Location.Y + 80);
				}
				else if (Common.updateInfo.GetPID(num) == "007E")
				{
					if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
					{
						labelpluginDevice.Text = string.Format(ResourceStr.pluginmousedock, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex));
					}
					else
					{
						labelpluginDevice.Text = string.Format(ResourceStr.pluginmousedock, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex));
					}
				}
				else
				{
					labelpluginDevice.Text = ResourceStr.updatestep;
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.fwupdaterBackground;
				}
				if (!blconnect && !devconnect)
				{
					if (Common.forsynapseuse)
					{
						Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
						return;
					}
					if (Common.updateInfo.GetPID(num) == "0220" || Common.updateInfo.GetPID(num) == "020F")
					{
						Close();
						new FormNoDetectSupport().Show();
						return;
					}
					if (Common.updateInfo.GetPID(num) == "023B" || Common.updateInfo.GetPID(num) == "0240" || Common.updateInfo.GetPID(num) == "023A" || Common.updateInfo.GetPID(num) == "0234" || Common.updateInfo.GetPID(num) == "0253" || Common.updateInfo.GetPID(num) == "0255" || Common.updateInfo.GetPID(num) == "0256" || Common.updateInfo.GetPID(num) == "026A" || Common.updateInfo.GetPID(num) == "0270")
					{
						labelpluginDevice.ForeColor = Color.Red;
						labelpluginDevice.Text = string.Format(ResourceStr.bladekbnotdetect, Common.updateInfo.GetProductName(num));
						labelPromptMessage.Text = string.Format(ResourceStr.updatebladekbonly, Common.updateInfo.GetProductName(num));
						labelPromptMessage.Visible = true;
						labelPromptMessage.ForeColor = Common.greendarktheme;
					}
					else if (Common.updateInfo.GetPID(num) == "0245")
					{
						labelpluginDevice.ForeColor = Color.Red;
						labelpluginDevice.Text = string.Format(ResourceStr.bladekbnotdetect, Common.updateInfo.GetProductName(num));
						labelPromptMessage.Text = string.Format(ResourceStr.updatebladec3kbonly, Common.updateInfo.GetProductName(num));
						labelPromptMessage.Visible = true;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						labelPromptMessage.Size = new Size(labelPromptMessage.Size.Width, labelPromptMessage.Size.Height + 20);
					}
					else
					{
						labelpluginDevice.ForeColor = Common.greendarktheme;
					}
					if (Common.updateInfo.GetPID(num) == "0517")
					{
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
						labelpluginDevice.ForeColor = Common.greendarktheme;
						labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
						labelkeepholdprompt.ForeColor = Color.Red;
					}
					return;
				}
				if (Common.updateInfo.GetPID(num) == "020F")
				{
					B5SKU.Add("RZ09-01952E32");
					B5SKU.Add("RZ09-01952E31");
					B5SKU.Add("RZ09-01952E33");
					B5SKU.Add("RZ09-01952K31");
					B5SKU.Add("RZ09-01952K32");
					B5SKU.Add("RZ09-01952K33");
					B5SKU.Add("RZ09-01952T31");
					B5SKU.Add("RZ09-01952T32");
					B5SKU.Add("RZ09-01952T33");
					B5SKU.Add("RZ09-01952J31");
					B5SKU.Add("RZ09-01952J32");
					B5SKU.Add("RZ09-01952J33");
					B5SKU.Add("RZ09-01952N31");
					B5SKU.Add("RZ09-01952N32");
					B5SKU.Add("RZ09-01952N33");
					B5SKU.Add("RZ09-01952F31");
					B5SKU.Add("RZ09-01952F32");
					B5SKU.Add("RZ09-01952F33");
					B5SKU.Add("RZ09-01952G31");
					B5SKU.Add("RZ09-01952G32");
					B5SKU.Add("RZ09-01952G33");
					B5SKU.Add("RZ09-01952W31");
					B5SKU.Add("RZ09-01952W32");
					B5SKU.Add("RZ09-01952W33");
					B5SKU.Add("RZ09-01952E71");
					B5SKU.Add("RZ09-01952E72");
					B5SKU.Add("RZ09-01952E73");
					B5SKU.Add("RZ09-01952K71");
					B5SKU.Add("RZ09-01952K72");
					B5SKU.Add("RZ09-01952K73");
					B5SKU.Add("RZ09-01952T71");
					B5SKU.Add("RZ09-01952T72");
					B5SKU.Add("RZ09-01952T73");
					B5SKU.Add("RZ09-01952J71");
					B5SKU.Add("RZ09-01952J72");
					B5SKU.Add("RZ09-01952J73");
					B5SKU.Add("RZ09-01952N71");
					B5SKU.Add("RZ09-01952N72");
					B5SKU.Add("RZ09-01952N73");
					B5SKU.Add("RZ09-01952F71");
					B5SKU.Add("RZ09-01952F72");
					B5SKU.Add("RZ09-01952F73");
					B5SKU.Add("RZ09-01952G71");
					B5SKU.Add("RZ09-01952G72");
					B5SKU.Add("RZ09-01952G73");
					B5SKU.Add("RZ09-01952W71");
					B5SKU.Add("RZ09-01952W72");
					B5SKU.Add("RZ09-01952W73");
					string systemSKUID = GetSystemSKUID();
					if (!B5SKU.Contains(systemSKUID))
					{
						Close();
						new FormNoDetectSupport().Show();
						return;
					}
				}
				else if (Common.updateInfo.GetPID(num) == "0517")
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.presspowerbtn_drk;
					labelpluginDevice.ForeColor = Color.White;
					labelpressandholdpwrbtn.ForeColor = Color.White;
					labelkeepholdprompt.ForeColor = Color.Red;
				}
				labelpluginDevice.ForeColor = Color.White;
				if (blconnect)
				{
					Common.DevFWNeedUpdate = true;
					if (Common.updateInfo.GetPID(num) == "0517")
					{
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothgray_drk;
						labelpluginDevice.ForeColor = Color.White;
						labelpressandholdpwrbtn.ForeColor = Color.White;
						labelkeepholdprompt.ForeColor = Color.Red;
					}
					else if (Common.updateInfo.GetPID(num) == "1004" || Common.updateInfo.GetPID(num) == "1007")
					{
						labelCurFWver.Visible = false;
						labelPromptMessage.Visible = true;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
						progressBarupdate.Visible = false;
						buttonUpdate.Enabled = false;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
						buttonCancel.Enabled = true;
						buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						labelPromptMessage.Text = ResourceStr.noupdaterequired;
						labeltargetver.ForeColor = Common.lightgray;
						labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
					}
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257")
					{
						labelCurFWver.Visible = false;
						labelPromptMessage.Visible = true;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
						progressBarupdate.Visible = false;
						buttonUpdate.Enabled = false;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
						buttonCancel.Enabled = true;
						buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						labelPromptMessage.Text = ResourceStr.noupdaterequired;
						labeltargetver.ForeColor = Common.lightgray;
						labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
						return;
					}
					labelCurFWver.Text = ResourceStr.devicever;
					labelCurFWver.Visible = true;
					labeltargetver.Visible = true;
					labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(num);
					labelCurFWver.ForeColor = Common.lightgray;
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = true;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					buttonUpdate.Enabled = true;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.anupdaterequired;
					if (Common.IsBladeKB())
					{
						labelupdaterstatus.Visible = true;
					}
					else
					{
						labelupdaterstatus.Visible = false;
					}
				}
				else if (devconnect && !backgroundWorkerCheckVer.IsBusy)
				{
					backgroundWorkerCheckVer.RunWorkerAsync();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private static string Mid(string strSource, int iStart, int iLength)
		{
			int num = ((iStart > strSource.Length) ? strSource.Length : iStart);
			return strSource.Substring(num, (num + iLength > strSource.Length) ? (strSource.Length - num) : iLength);
		}

		private static void DataDefault(byte[] data)
		{
			for (int i = 0; i < data.Length; i++)
			{
				data[i] = byte.MaxValue;
			}
		}

		private void backgroundWorkerProcessFWData_DoWork(object sender, DoWorkEventArgs e)
		{
			int devFWType = Common.updateInfo.GetDevFWType(Common.updateInfo.CurDevIndex);
			float bLVer = Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex);
			m_fAddressBeginSet = false;
			uint num = 0u;
			num = Common.updateInfo.GetDevFWLineNum(Common.updateInfo.CurDevIndex);
			curstate = eState.STATE_PROCESSING_DATA;
			backgroundWorkerProcessFWData.ReportProgress(0, eState.STATE_PROCESSING_DATA);
			_ = 1f / (float)num;
			if (bLVer != 1f)
			{
				if (devFWType != 2)
				{
					return;
				}
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Create);
				BinaryWriter binaryWriter = new BinaryWriter(fileStream);
				byte[] array = new byte[512];
				DataDefault(array);
				string text = "";
				int num2 = 0;
				ushort num3 = 0;
				uint num4 = 0u;
				ushort num5 = 0;
				int num6 = 0;
				long num7 = 0L;
				while (num7 < num)
				{
					text = Common.updateInfo.GetDevFWLine(Common.updateInfo.CurDevIndex, (int)num7);
					backgroundWorkerProcessFWData.ReportProgress((int)(num7++ * 100 / num));
					if (text.ElementAt(0) != ':')
					{
						MessageBox.Show("Hex File was corrupt!");
						backgroundWorkerProcessFWData.ReportProgress(0, eState.STATE_PROCESSINGDATA_FAIL);
						e.Result = eState.STATE_PROCESSINGDATA_FAIL;
						return;
					}
					num3 = Convert.ToUInt16(text.Substring(3, 4), 16);
					switch (Convert.ToInt32(text.Substring(7, 2), 16))
					{
					case 4:
					{
						string value = text.Substring(1, 2);
						num5 = Convert.ToUInt16(text.Substring(9, Convert.ToInt32(value, 16) * 2), 16);
						break;
					}
					case 0:
					{
						uint num8 = (uint)(num5 * 64 * 1024 + num3);
						if (!m_fAddressBeginSet && (num8 != 0 || (!(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "023B") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0240") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "023A"))))
						{
							m_fAddressBeginSet = true;
							Common.StartAddr = num8;
						}
						if (num4 == 0)
						{
							num4 = num8;
						}
						else if (num8 - num4 != 0)
						{
							if (num6 + num8 - num4 >= 512)
							{
								binaryWriter.Write(array);
								DataDefault(array);
								num4 = (uint)(num4 + 512 - num6);
								num6 = (int)(num8 - num4);
								for (int i = 0; i < num6 / 512; i++)
								{
									binaryWriter.Write(array);
								}
								num6 %= 512;
							}
							else
							{
								num6 = (int)(num6 + num8 - num4);
							}
						}
						string value = text.Substring(1, 2);
						num2 = Convert.ToInt32(value, 16);
						for (int j = 0; j < num2; j++)
						{
							if (num6 == 512)
							{
								binaryWriter.Write(array);
								DataDefault(array);
								num6 = 0;
								array[num6] = Convert.ToByte(text.Substring(9 + j * 2, 2), 16);
								num6++;
								num8++;
							}
							else
							{
								num8++;
								array[num6] = Convert.ToByte(text.Substring(9 + j * 2, 2), 16);
								num6++;
							}
						}
						num4 = num8;
						Common.EndAddr = num8;
						break;
					}
					}
				}
				if (num6 > 0)
				{
					binaryWriter.Write(array, 0, num6);
					DataDefault(array);
				}
				Common.filelen = fileStream.Length;
				backgroundWorkerProcessFWData.ReportProgress(100);
				binaryWriter.Close();
				fileStream.Close();
				e.Result = eState.STATE_PROCESSING_DATA_PASS;
				return;
			}
			if (num == 0)
			{
				e.Result = eState.STATE_PROCESSINGDATA_FAIL;
				return;
			}
			uint num9 = 0u;
			uint num10 = 0u;
			uint num11 = 0u;
			uint num12 = 0u;
			string text2 = "";
			m_strFormattedData = "";
			m_uAddressBegin = 0u;
			m_uAddressEnd = 0u;
			try
			{
				for (int k = 0; k < num; k++)
				{
					backgroundWorkerProcessFWData.ReportProgress((int)((k + 1) * 100 / num));
					text2 = "";
					text2 = Common.updateInfo.GetDevFWLine(Common.updateInfo.CurDevIndex, k);
					uint num13 = 0u;
					uint num14 = 0u;
					string text3 = "";
					int num15 = 0;
					if ('\n' == text2[text2.Length - 1])
					{
						num15++;
					}
					switch (devFWType)
					{
					case 1:
						if ('S' == text2[0])
						{
							if ('1' != text2[1])
							{
								continue;
							}
							num9 = Convert.ToUInt32(Mid(text2, 4, 2), 16);
							num10 = Convert.ToUInt32(Mid(text2, 6, 2), 16);
							text3 = Mid(text2, 8, text2.Length - (10 + num15));
						}
						else
						{
							MessageBox.Show("S19 FW corrupt!");
						}
						break;
					case 2:
						if (text2.ElementAt(0) != ':')
						{
							MessageBox.Show("Hex File was corrupt!");
							return;
						}
						if ('0' != text2[7] || '0' != text2[8])
						{
							continue;
						}
						num9 = Convert.ToUInt32(Mid(text2, 3, 2), 16);
						num10 = Convert.ToUInt32(Mid(text2, 5, 2), 16);
						text3 = Mid(text2, 9, text2.Length - (11 + num15));
						break;
					}
					num13 = num9 * 256 + num10;
					num14 = num13;
					if (!m_fAddressBeginSet)
					{
						m_uAddressBegin = num13;
						m_fAddressBeginSet = true;
					}
					uint num16 = 0u;
					string text4 = "";
					while (text3.Length > 0)
					{
						text4 += Mid(text3, 0, 2);
						text3 = Mid(text3, 2, text3.Length);
						num14++;
						num16++;
						if (num16 >= m_uDataPacketSize)
						{
							num9 = num13 / 256;
							num10 = num13 % 256;
							num11 = (num14 - 1) / 256;
							num12 = (num14 - 1) % 256;
							m_strFormattedData += $"{num16:X2}";
							m_strFormattedData += $"{num9:X2}";
							m_strFormattedData += $"{num10:X2}";
							m_strFormattedData += $"{num11:X2}";
							m_strFormattedData += $"{num12:X2}";
							m_strFormattedData = m_strFormattedData.ToUpper();
							m_strFormattedData = m_strFormattedData + text4 + " ";
							num13 = num14;
							m_uAddressEnd = num14 - 1;
							num16 = 0u;
							text4 = "";
						}
					}
					if (num16 != 0)
					{
						num9 = num13 / 256;
						num10 = num13 % 256;
						num11 = (num14 - 1) / 256;
						num12 = (num14 - 1) % 256;
						m_strFormattedData += $"{num16:X2}";
						m_strFormattedData += $"{num9:X2}";
						m_strFormattedData += $"{num10:X2}";
						m_strFormattedData += $"{num11:X2}";
						m_strFormattedData += $"{num12:X2}";
						m_strFormattedData = m_strFormattedData.ToUpper();
						m_strFormattedData = m_strFormattedData + text4 + " ";
						num13 = num14;
						m_uAddressEnd = num14 - 1;
					}
				}
				e.Result = eState.STATE_PROCESSING_DATA_PASS;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				e.Result = eState.STATE_PROCESSINGDATA_FAIL;
			}
		}

		private void backgroundWorkerProcessFWData_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			labelUpdateprogress.ForeColor = Common.lightgray;
			labelPromptMessage.ForeColor = Common.greendarktheme;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.FlashFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.05);
				}
				else
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.05 * 2.5);
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
				labelUpdateInfor.Text = ResourceStr.updatefw;
				labelupdaterstatus.Visible = false;
				if (Common.IsBladeKB())
				{
					labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
				}
				else
				{
					labelPromptMessage.Text = ResourceStr.Nounplug;
				}
			}
			else
			{
				progressBarupdate.Value = e.ProgressPercentage;
				labelUpdateprogress.Text = e.ProgressPercentage + "%";
			}
			if (e.UserState != null)
			{
				eState eState2 = (eState)e.UserState;
				if (eState2 == eState.STATE_PROCESSING_DATA)
				{
					labelUpdateInfor.Text = ResourceStr.processfwdata;
				}
			}
		}

		private void backgroundWorkerProcessFWData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((eState)e.Result == eState.STATE_PROCESSING_DATA_PASS)
			{
				buttonCancel.Enabled = false;
				buttonUpdate.Enabled = false;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_disabled;
				if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 3f)
				{
					if (!backgroundWorkerProgramFW.IsBusy)
					{
						backgroundWorkerProgramFW.RunWorkerAsync();
					}
				}
				else if (!backgroundWorkerEraseFlash.IsBusy)
				{
					backgroundWorkerEraseFlash.RunWorkerAsync();
				}
			}
			else if ((eState)e.Result == eState.STATE_PROCESSINGDATA_FAIL)
			{
				MessageBox.Show("FW Data Corrupt!");
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
			}
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			Common.IsExiting = true;
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_clicked;
			Close();
		}

		private void buttonCancel_MouseEnter(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_hover;
		}

		private void buttonCancel_MouseLeave(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
		}

		private void labelpluginDevice_MouseDown(object sender, MouseEventArgs e)
		{
			try
			{
				if (lastPoint.IsEmpty)
				{
					lastPoint = new Point(e.X, e.Y);
					return;
				}
				lastPoint.X = e.X;
				lastPoint.Y = e.Y;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void labelpluginDevice_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private bool EnterTestMode(IntPtr handle)
		{
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 0;
			_ = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			return device.HidSetFeature(handle, array, array.Length);
		}

		private bool StartCalibration(IntPtr handle)
		{
			StreamWriter streamWriter = new StreamWriter(Common.PatriciaCalibrationlogFileName, append: true);
			streamWriter.WriteLine("Start Get Cetral Data after update:");
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 4;
			byte[] array2 = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			for (int i = 0; i < 3; i++)
			{
				device.HidSetFeature(handle, array, array.Length);
				device.Delay(200f);
				Array.Clear(array2, 0, array2.Length);
				array2[0] = 3;
				int num = 0;
				while (num < 30)
				{
					if (device.HidGetFeature(handle, array2, array2.Length) && array2[0] == 4)
					{
						Common.LNewMidX = (ushort)(array2[1] * 256 + array2[2]);
						Common.LNewMidY = (ushort)(array2[3] * 256 + array2[4]);
						Common.RNewMidX = (ushort)(array2[5] * 256 + array2[6]);
						Common.RNewMidY = (ushort)(array2[7] * 256 + array2[8]);
						if (Math.Abs(Common.LNewMidX - Common.LPreMidX) * 100 / Common.LPreMidX <= Common.centraltolerance && Math.Abs(Common.LNewMidY - Common.LPreMidY) * 100 / Common.LPreMidY <= Common.centraltolerance && Math.Abs(Common.RNewMidX - Common.RPreMidX) * 100 / Common.RPreMidX <= Common.centraltolerance && Math.Abs(Common.RNewMidY - Common.RPreMidY) * 100 / Common.LPreMidY <= Common.centraltolerance)
						{
							streamWriter.WriteLine("LNewMidX: " + Common.LNewMidX);
							streamWriter.WriteLine("LNewMidY: " + Common.LNewMidY);
							streamWriter.WriteLine("RNewMidX: " + Common.LNewMidX);
							streamWriter.WriteLine("RNewMidY: " + Common.LNewMidY);
							streamWriter.WriteLine();
							streamWriter.WriteLine("L X offset:" + (Common.LNewMidX - Common.LPreMidX));
							streamWriter.WriteLine("L Y offset:" + (Common.LNewMidY - Common.LPreMidY));
							streamWriter.WriteLine("R X offset:" + (Common.RNewMidX - Common.RPreMidX));
							streamWriter.WriteLine("R Y offset:" + (Common.RNewMidY - Common.RPreMidY));
						}
						streamWriter.Close();
						return true;
					}
				}
				MessageBox.Show("Please release the Joy Stick!");
				device.Delay(100f);
			}
			streamWriter.WriteLine("Get Central Data Fail!");
			streamWriter.Close();
			return false;
		}

		private bool SetPatriciaCalibrationData(IntPtr handle, int lxoffset, int lyoffset, int rxoffset, int ryoffset)
		{
			EnterTestMode(handle);
			device.Delay(100f);
			StreamWriter streamWriter = new StreamWriter(Common.PatriciaCalibrationlogFileName, append: true);
			streamWriter.WriteLine("Send Re-Calibration Data:");
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 5;
			array[4] = (byte)((Common.LNewMidX >> 8) & 0xFF);
			array[5] = (byte)(Common.LNewMidX & 0xFF);
			array[6] = (byte)((Common.LPreMinX + lxoffset >> 8) & 0xFF);
			array[7] = (byte)((Common.LPreMinX + lxoffset) & 0xFF);
			array[8] = (byte)((Common.LPreMaxX + lxoffset >> 8) & 0xFF);
			array[9] = (byte)((Common.LPreMaxX + lxoffset) & 0xFF);
			array[10] = (byte)((Common.LNewMidY >> 8) & 0xFF);
			array[11] = (byte)(Common.LNewMidY & 0xFF);
			array[12] = (byte)((Common.LPreMinY + lyoffset >> 8) & 0xFF);
			array[13] = (byte)((Common.LPreMinY + lyoffset) & 0xFF);
			array[14] = (byte)((Common.LPreMaxY + lyoffset >> 8) & 0xFF);
			array[15] = (byte)((Common.LPreMaxY + lyoffset) & 0xFF);
			array[16] = (byte)((Common.RNewMidX >> 8) & 0xFF);
			array[17] = (byte)(Common.RNewMidX & 0xFF);
			array[18] = (byte)((Common.RPreMinX + rxoffset >> 8) & 0xFF);
			array[19] = (byte)((Common.RPreMinX + rxoffset) & 0xFF);
			array[20] = (byte)((Common.RPreMaxX + rxoffset >> 8) & 0xFF);
			array[21] = (byte)((Common.RPreMaxX + rxoffset) & 0xFF);
			array[22] = (byte)((Common.RNewMidY >> 8) & 0xFF);
			array[23] = (byte)(Common.RNewMidY & 0xFF);
			array[24] = (byte)((Common.RPreMinY + rxoffset >> 8) & 0xFF);
			array[25] = (byte)((Common.RPreMinY + rxoffset) & 0xFF);
			array[26] = (byte)((Common.RPreMaxY + ryoffset >> 8) & 0xFF);
			array[27] = (byte)((Common.RPreMaxY + ryoffset) & 0xFF);
			array[28] = (byte)((Common.LPreTMin >> 8) & 0xFF);
			array[29] = (byte)(Common.LPreTMin & 0xFF);
			array[30] = (byte)((Common.LPreTMax >> 8) & 0xFF);
			array[31] = (byte)(Common.LPreTMax & 0xFF);
			array[32] = (byte)((Common.RPreTMin >> 8) & 0xFF);
			array[33] = (byte)(Common.RPreTMin & 0xFF);
			array[34] = (byte)((Common.RPreTMax >> 8) & 0xFF);
			array[35] = (byte)(Common.RPreTMax & 0xFF);
			for (int i = 4; i < 36; i++)
			{
				if ((i - 4) % 16 == 0)
				{
					streamWriter.WriteLine();
				}
				else if ((i - 4) % 8 == 0)
				{
					streamWriter.Write("   ");
				}
				streamWriter.Write($"{array[i]:X2} ");
			}
			byte[] array2 = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			for (int j = 0; j < 3; j++)
			{
				device.HidSetFeature(handle, array, array.Length);
				device.Delay(200f);
				Array.Clear(array2, 0, array2.Length);
				array2[0] = 3;
				if (device.HidGetFeature(handle, array2, array2.Length))
				{
					streamWriter.WriteLine();
					streamWriter.WriteLine();
					streamWriter.WriteLine("LMidX:" + (array[4] * 256 + array[5]));
					streamWriter.WriteLine("LMinX:" + (array[6] * 256 + array[7]));
					streamWriter.WriteLine("LMaxX:" + (array[8] * 256 + array[9]));
					streamWriter.WriteLine("LMidY:" + (array[10] * 256 + array[11]));
					streamWriter.WriteLine("LMinY:" + (array[12] * 256 + array[13]));
					streamWriter.WriteLine("LMaxY:" + (array[14] * 256 + array[15]));
					streamWriter.WriteLine("RMidX:" + (array[16] * 256 + array[17]));
					streamWriter.WriteLine("RMinX:" + (array[18] * 256 + array[19]));
					streamWriter.WriteLine("RMaxX:" + (array[20] * 256 + array[21]));
					streamWriter.WriteLine("RMidY:" + (array[22] * 256 + array[23]));
					streamWriter.WriteLine("RMinY:" + (array[24] * 256 + array[25]));
					streamWriter.WriteLine("RMaxY:" + (array[26] * 256 + array[27]));
					streamWriter.WriteLine("LTMin:" + (array[28] * 256 + array[29]));
					streamWriter.WriteLine("LTMax:" + (array[30] * 256 + array[31]));
					streamWriter.WriteLine("RTMin:" + (array[32] * 256 + array[33]));
					streamWriter.WriteLine("RTMax:" + (array[34] * 256 + array[35]));
					streamWriter.WriteLine("Send Re-Calibration Data PASS!");
					streamWriter.Close();
					return true;
				}
				device.Delay(500f);
			}
			streamWriter.WriteLine("Send Re-Calibration Data Fail!");
			streamWriter.Close();
			return false;
		}

		private bool GetPatriciaCalibrationData(IntPtr handle)
		{
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 6;
			byte[] array2 = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			for (int i = 0; i < 3; i++)
			{
				device.HidSetFeature(handle, array, array.Length);
				device.Delay(200f);
				Array.Clear(array2, 0, array2.Length);
				array2[0] = 3;
				if (device.HidGetFeature(handle, array2, array2.Length) && array2[0] == 6)
				{
					Common.LPreMidX = (ushort)(array2[1] * 256 + array2[2]);
					Common.LPreMinX = (ushort)(array2[3] * 256 + array2[4]);
					Common.LPreMaxX = (ushort)(array2[5] * 256 + array2[6]);
					Common.LPreMidY = (ushort)(array2[7] * 256 + array2[8]);
					Common.LPreMinY = (ushort)(array2[9] * 256 + array2[10]);
					Common.LPreMaxY = (ushort)(array2[11] * 256 + array2[12]);
					Common.RPreMidX = (ushort)(array2[13] * 256 + array2[14]);
					Common.RPreMinX = (ushort)(array2[15] * 256 + array2[16]);
					Common.RPreMaxX = (ushort)(array2[17] * 256 + array2[18]);
					Common.RPreMidY = (ushort)(array2[19] * 256 + array2[20]);
					Common.RPreMinY = (ushort)(array2[21] * 256 + array2[22]);
					Common.RPreMaxY = (ushort)(array2[23] * 256 + array2[24]);
					Common.LPreTMin = (ushort)(array2[25] * 256 + array2[26]);
					Common.LPreTMax = (ushort)(array2[27] * 256 + array2[28]);
					Common.RPreTMin = (ushort)(array2[29] * 256 + array2[30]);
					Common.RPreTMax = (ushort)(array2[31] * 256 + array2[32]);
					return true;
				}
				device.Delay(500f);
			}
			return false;
		}

		private string GetSN(IntPtr handle)
		{
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			byte[] array2 = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 3;
			for (int i = 0; i < 3; i++)
			{
				device.HidSetFeature(handle, array, array.Length);
				device.Delay(200f);
				Array.Clear(array2, 0, array2.Length);
				array2[0] = 3;
				if (device.HidGetFeature(handle, array2, array2.Length) && array2[0] == 3)
				{
					Array.Clear(DevSN, 0, DevSN.Length);
					Array.Copy(array2, 1, DevSN, 0, DevSN.Length);
					string text = Encoding.ASCII.GetString(DevSN);
					text = text.Substring(0, text.IndexOf('\0'));
					Common.SNFlag = array2[22];
					return text;
				}
				device.Delay(500f);
			}
			return "";
		}

		private bool SetSNandSNFlag(IntPtr handle)
		{
			byte[] array = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			byte[] array2 = new byte[Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex)];
			Array.Clear(array, 0, array.Length);
			array[0] = 3;
			array[1] = 90;
			array[2] = 165;
			array[3] = 2;
			Array.Copy(Encoding.Default.GetBytes(Common.DevSN), 0, array, 4, Common.DevSN.Length);
			array[25] = (byte)Common.SNFlag;
			int i = 0;
			bool flag = false;
			for (; i < 3; i++)
			{
				flag = device.HidSetFeature(handle, array, array.Length);
				device.Delay(200f);
				Array.Clear(array2, 0, array2.Length);
				array2[0] = 3;
				if (flag)
				{
					break;
				}
				device.Delay(500f);
			}
			return flag;
		}

		private void backgroundWorkerCheckVer_DoWork(object sender, DoWorkEventArgs e)
		{
			int num = 0;
			IntPtr zero = IntPtr.Zero;
			while (true)
			{
				num++;
				zero = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (!(zero == IntPtr.Zero))
				{
					break;
				}
				if (num == 100)
				{
					e.Result = eState.STATE_WAITING_DEVICE;
					return;
				}
				device.Delay(1000f);
			}
			string text = "";
			if (!(zero != IntPtr.Zero))
			{
				return;
			}
			num = 0;
			while (true)
			{
				switch (text)
				{
				case "":
				case "0.00.00":
				case "0":
					if (num >= 15)
					{
						break;
					}
					text = device.GetDevFWVer(zero, nxp: true);
					if (Common.CalibrationFunction && curstate == eState.STATE_NULL && (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004"))
					{
						StreamWriter streamWriter = ((!File.Exists(Common.PatriciaCalibrationlogFileName) || curstate == eState.STATE_NULL) ? File.CreateText(Common.PatriciaCalibrationlogFileName) : new StreamWriter(Common.PatriciaCalibrationlogFileName, append: true));
						streamWriter.WriteLine("\r\nTime:" + DateTime.Now.ToLongTimeString());
						if (curstate == eState.STATE_NULL)
						{
							Common.DevSN = GetSN(zero);
							if (Common.DevSN != "")
							{
								streamWriter.WriteLine("SN Flag:" + Common.SNFlag);
								streamWriter.WriteLine("Device SN: " + Common.DevSN);
								streamWriter.WriteLine("Device FW Version: " + text);
							}
						}
						if (GetPatriciaCalibrationData(zero))
						{
							streamWriter.WriteLine("Orginal Calibration Data:");
							streamWriter.WriteLine("LPreMidX:" + Common.LPreMidX);
							streamWriter.WriteLine("LPreMinX:" + Common.LPreMinX);
							streamWriter.WriteLine("LPreMaxX:" + Common.LPreMaxX);
							streamWriter.WriteLine("LPreMidY:" + Common.LPreMidY);
							streamWriter.WriteLine("LPreMinY:" + Common.LPreMinY);
							streamWriter.WriteLine("LPreMaxY:" + Common.LPreMaxY);
							streamWriter.WriteLine("RPreMidX:" + Common.RPreMidX);
							streamWriter.WriteLine("RPreMinX:" + Common.RPreMinX);
							streamWriter.WriteLine("RPreMaxX:" + Common.RPreMaxX);
							streamWriter.WriteLine("RPreMidY:" + Common.RPreMidY);
							streamWriter.WriteLine("RPreMinY:" + Common.RPreMinY);
							streamWriter.WriteLine("RPreMaxY:" + Common.RPreMaxY);
							streamWriter.WriteLine("LPreTMin:" + Common.LPreTMin);
							streamWriter.WriteLine("LPreTMax:" + Common.LPreTMax);
							streamWriter.WriteLine("RPreTMin:" + Common.RPreTMin);
							streamWriter.WriteLine("RPreTMax:" + Common.RPreTMax);
						}
						streamWriter.Close();
					}
					if (text != "" && text != "0.00.00" && text != "0")
					{
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "005A")
						{
							if (text.ElementAt(0) == '1')
							{
								Common.updateInfo.CurDevIndex = 1;
							}
							else if (text.ElementAt(0) >= '2')
							{
								Common.updateInfo.CurDevIndex = 2;
							}
						}
						else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C01" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C02")
						{
							if (text.ElementAt(0) == '1')
							{
								Common.updateInfo.CurDevIndex = 2;
							}
							else if (text.ElementAt(0) >= '2')
							{
								Common.updateInfo.CurDevIndex = 1;
							}
						}
						else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007")
						{
							switch (text)
							{
							case "1.04.00":
							case "1.05.00":
							case "1.06.00":
								Common.updateInfo.CurDevIndex = 1;
								break;
							default:
								Common.updateInfo.CurDevIndex = 2;
								break;
							}
						}
						Common.updateInfo.ActDevFWVer = text;
						Common.updateInfo.CurDevIndex = 1;
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257" && device.GetEID(zero, ref Common.devedition, ref Common.layout) && Common.layout == 7)
						{
							Common.updateInfo.CurDevIndex = 2;
						}
						Common.updateInfo.DevSameVer = string.Compare(text, Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex));
						if (curstate != eState.STATE_EXIT_BL)
						{
							if (Common.updateInfo.DevSameVer < 0)
							{
								if ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004") && Common.CalibrationFunction && Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex) == "1.04.00")
								{
									Common.NeedCalibration = true;
								}
								Common.DevFWNeedUpdate = true;
							}
							else
							{
								if (Common.fordummy && Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
								{
									Common.updateInfo.DevSameVer = -1;
									Common.DevFWNeedUpdate = true;
								}
								else
								{
									Common.DevFWNeedUpdate = false;
								}
								if ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004") && Common.CalibrationFunction && Common.SNFlag == 1)
								{
									Common.NeedCalibration = true;
								}
							}
						}
					}
					if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
					{
						device.Delay(10f);
						text = "";
						text = device.GetDevFWVer(zero, nxp: false);
						if (text != "" && text != "0")
						{
							if (text == "0.00.00")
							{
								Common.updateInfo.ActFlashFWVer = "";
								Common.updateInfo.FlashSameVer = string.Compare(text, Common.updateInfo.GetFlashFWVer(Common.updateInfo.CurDevIndex));
							}
							else if (text.StartsWith("177."))
							{
								Common.updateInfo.FlashSameVer = -1;
							}
							else
							{
								Common.updateInfo.ActFlashFWVer = text;
								Common.updateInfo.FlashSameVer = string.Compare(text, Common.updateInfo.GetFlashFWVer(Common.updateInfo.CurDevIndex));
							}
							if (Common.updateInfo.FlashSameVer < 0)
							{
								Common.FlashFWNeedUpdate = true;
							}
							else if (curstate != eState.STATE_EXIT_NordicBL)
							{
								if (Common.fordummy && Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
								{
									Common.FlashFWNeedUpdate = true;
									Common.updateInfo.FlashSameVer = -1;
								}
								else
								{
									Common.FlashFWNeedUpdate = false;
								}
							}
							break;
						}
					}
					if (text == "")
					{
						device.Delay(1000f);
						num++;
					}
					continue;
				}
				break;
			}
			device.CloseDev(zero);
		}

		private void backgroundWorkerCheckVer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Result != null)
			{
				if (MessageBox.Show(ResourceStr.checkverfail, "Update Failed", MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
				{
					backgroundWorkerCheckVer.RunWorkerAsync();
					return;
				}
				labelUpdateInfor.Text = ResourceStr.checkverfail;
				labelUpdateInfor.ForeColor = Color.Red;
				buttonCancel.Enabled = true;
				return;
			}
			if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "005A" && curstate < eState.STATE_ENTER_BL)
			{
				labelHeader.Text = string.Format(ResourceStr.Title, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
				Text = labelHeader.Text;
				devlistener.RemoveAll();
				deviceVidPid = new Common.VidPid(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), bconnect: false);
				BLVidPid = new Common.VidPid(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), bconnect: false);
				devlistener.AddDevice(deviceVidPid);
				devlistener.AddDevice(BLVidPid);
			}
			int devSameVer = Common.updateInfo.DevSameVer;
			labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
			labeltargetver.Visible = true;
			labelCurFWver.ForeColor = Common.lightgray;
			buttonUpdate.Visible = true;
			buttonCancel.Text = ResourceStr.cancel;
			if (curstate == eState.STATE_NULL)
			{
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				buttonCancel.Enabled = true;
			}
			if (devSameVer < 0)
			{
				labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0220" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "020F" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "023B" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0240")
				{
					SYSTEM_POWER_STATUS lpSystemPowerStatus = default(SYSTEM_POWER_STATUS);
					GetSystemPowerStatus(ref lpSystemPowerStatus);
					if (lpSystemPowerStatus.ACLineStatus != 1 && lpSystemPowerStatus.BatteryLifePercent < 50)
					{
						MessageBox.Show(ResourceStr.lowbattery);
						Common.IsLowBattery = true;
					}
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257")
				{
					IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
					if (intPtr != IntPtr.Zero && device.GetEID(intPtr, ref Common.devedition, ref Common.layout))
					{
						device.CloseDev(intPtr);
						intPtr = IntPtr.Zero;
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0257")
						{
							labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
							labelCurFWver.Visible = true;
							labeltargetver.Visible = true;
							labelCurFWver.ForeColor = Common.lightgray;
							labelpluginDevice.ForeColor = Color.White;
							if (Common.layout == 7)
							{
								Common.updateInfo.CurDevIndex = 2;
								labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
							}
							else
							{
								Common.updateInfo.CurDevIndex = 1;
								labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
							}
							labeltargetver.ForeColor = Common.greendarktheme;
							labelPromptMessage.Visible = true;
							labelUpdateInfor.Visible = true;
							labelUpdateprogress.Visible = false;
							progressBarupdate.Visible = false;
							buttonUpdate.Enabled = true;
							buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
							labelupdaterstatus.Visible = false;
							labelPromptMessage.ForeColor = Common.greendarktheme;
							labelPromptMessage.Text = ResourceStr.anupdaterequired;
							return;
						}
					}
					labelCurFWver.Visible = false;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = false;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					buttonCancel.Enabled = true;
					buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.noupdaterequired;
					labeltargetver.ForeColor = Common.lightgray;
					labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
				}
				else
				{
					labelCurFWver.Visible = true;
					labeltargetver.ForeColor = Common.greendarktheme;
					labelPromptMessage.Visible = true;
					labelUpdateInfor.Visible = false;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					if (curstate == eState.STATE_NULL)
					{
						buttonCancel.Enabled = true;
						buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
					}
					if (Common.IsLowBattery)
					{
						buttonUpdate.Enabled = false;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
						checkbattery = true;
						backgroundWorkercheckbattery.RunWorkerAsync();
					}
					else
					{
						buttonUpdate.Enabled = true;
						buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
					}
					if (Common.IsBladeKB())
					{
						labelupdaterstatus.Visible = true;
						labelupdaterstatus.ForeColor = Common.greendarktheme;
						labelupdaterstatus.Text = ResourceStr.anupdaterequired;
					}
					else
					{
						labelupdaterstatus.Visible = false;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						labelPromptMessage.Text = ResourceStr.anupdaterequired;
					}
				}
				return;
			}
			if (curstate == eState.STATE_EXIT_BL || curstate >= eState.STATE_VERIFYING_FIRMWARE)
			{
				if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex) && Common.FlashFWNeedUpdate)
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
					{
						if (!backgroundWorkerGetRegionInfor.IsBusy)
						{
							backgroundWorkerGetRegionInfor.RunWorkerAsync();
						}
					}
					else if (!backgroundWorkerNordicENTERBL.IsBusy)
					{
						backgroundWorkerNordicENTERBL.RunWorkerAsync();
					}
					return;
				}
				labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
				labeltargetver.ForeColor = Common.lightgray;
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "005C")
				{
					int i = 0;
					IntPtr intPtr2 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
					for (; i < 5; i++)
					{
						if (intPtr2 != IntPtr.Zero && device.ActiveProfile(intPtr2, 1) == 2)
						{
							break;
						}
						Thread.Sleep(50);
					}
					device.CloseDev(intPtr2);
				}
				else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0078" || Common.updateInfo.BackToDefault)
				{
					int j = 0;
					IntPtr intPtr3 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
					for (; j < 5; j++)
					{
						if (intPtr3 != IntPtr.Zero && device.ClearVariableStorage(intPtr3))
						{
							break;
						}
						Thread.Sleep(50);
					}
					device.CloseDev(intPtr3);
				}
				if ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004") && Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex) == "1.04.00" && Common.NeedCalibration)
				{
					int k = 0;
					IntPtr intPtr4 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
					for (; k < 5; k++)
					{
						if (intPtr4 != IntPtr.Zero)
						{
							StartCalibration(intPtr4);
							int lxoffset = Common.LNewMidX - Common.LPreMidX;
							int lyoffset = Common.LNewMidY - Common.LPreMidY;
							int rxoffset = Common.RNewMidX - Common.RPreMidX;
							int ryoffset = Common.RNewMidY - Common.RPreMidY;
							device.Delay(100f);
							if (SetPatriciaCalibrationData(intPtr4, lxoffset, lyoffset, rxoffset, ryoffset))
							{
								Common.SNFlag = 2;
								break;
							}
							Common.SNFlag = 1;
						}
						Thread.Sleep(50);
					}
					SetSNandSNFlag(intPtr4);
					device.CloseDev(intPtr4);
				}
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0065")
				{
					IntPtr intPtr5 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
					if (intPtr5 != IntPtr.Zero)
					{
						byte edition = byte.MaxValue;
						if (device.GetEID(intPtr5, ref edition, ref Common.layout))
						{
							if (edition == 128)
							{
								Common.newedition = true;
							}
							else
							{
								Common.newedition = false;
							}
						}
					}
				}
				labelCurFWver.Visible = true;
				labeltargetver.Visible = true;
				Common.IsExiting = false;
				Common.NextPage = PageIndex.FormCongratulation;
				Application.DoEvents();
				device.Delay(1000f);
				Close();
				return;
			}
			if (curstate == eState.STATE_NULL && Common.forsynapseuse)
			{
				Process.GetProcessById(Process.GetCurrentProcess().Id).Kill();
				return;
			}
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex) && Common.FlashFWNeedUpdate)
			{
				labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActFlashFWVer;
				labelCurFWver.Visible = true;
				labeltargetver.ForeColor = Common.greendarktheme;
				labelPromptMessage.Visible = true;
				labelUpdateInfor.Visible = false;
				labelUpdateprogress.Visible = false;
				progressBarupdate.Visible = false;
				if (Common.IsLowBattery)
				{
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					checkbattery = true;
					backgroundWorkercheckbattery.RunWorkerAsync();
				}
				else
				{
					buttonUpdate.Enabled = true;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				if (Common.IsBladeKB())
				{
					labelupdaterstatus.Visible = true;
					labelupdaterstatus.ForeColor = Common.greendarktheme;
					labelupdaterstatus.Text = ResourceStr.anupdaterequired;
				}
				else
				{
					labelupdaterstatus.Visible = false;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.anupdaterequired;
				}
				return;
			}
			if ((Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1007" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "1004") && Common.CalibrationFunction && Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex) == "1.04.00" && Common.NeedCalibration)
			{
				int l = 0;
				IntPtr intPtr6 = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				for (; l < 5; l++)
				{
					if (intPtr6 != IntPtr.Zero)
					{
						StartCalibration(intPtr6);
						int lxoffset2 = Common.LNewMidX - Common.LPreMidX;
						int lyoffset2 = Common.LNewMidY - Common.LPreMidY;
						int rxoffset2 = Common.RNewMidX - Common.RPreMidX;
						int ryoffset2 = Common.RNewMidY - Common.RPreMidY;
						device.Delay(100f);
						if (SetPatriciaCalibrationData(intPtr6, lxoffset2, lyoffset2, rxoffset2, ryoffset2))
						{
							Common.SNFlag = 1;
							break;
						}
						Common.SNFlag = 1;
					}
					Thread.Sleep(50);
				}
				SetSNandSNFlag(intPtr6);
				device.CloseDev(intPtr6);
			}
			labelCurFWver.Visible = false;
			labelPromptMessage.Visible = true;
			labelUpdateInfor.Visible = false;
			labelUpdateprogress.Visible = false;
			progressBarupdate.Visible = false;
			buttonUpdate.Enabled = false;
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			buttonCancel.Enabled = true;
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
			if (Common.IsBladeKB())
			{
				labelupdaterstatus.Visible = true;
				labelupdaterstatus.Text = ResourceStr.docknoupdate;
				labelupdaterstatus.ForeColor = Common.greendarktheme;
				labelPromptMessage.Text = ResourceStr.devhavelatestfw;
				labelPromptMessage.ForeColor = Color.White;
			}
			else
			{
				labelupdaterstatus.Visible = false;
				labelPromptMessage.Text = ResourceStr.noupdaterequired;
				labelPromptMessage.ForeColor = Common.greendarktheme;
			}
			labeltargetver.ForeColor = Common.lightgray;
			labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
		}

		private void buttonUpdate_MouseEnter(object sender, EventArgs e)
		{
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonUpdate_MouseLeave(object sender, EventArgs e)
		{
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void ForceEnterUSBMode()
		{
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (!(intPtr == IntPtr.Zero))
			{
				device.EnterDevMode(intPtr, 7);
				device.CloseDev(intPtr);
			}
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			if (buttonUpdate.Text == ResourceStr.Done)
			{
				Common.NextPage = PageIndex.FormCongratulation;
				Common.IsExiting = false;
				Close();
				return;
			}
			labelupdaterstatus.Visible = false;
			if (Common.IsBladeKB())
			{
				labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
			}
			else
			{
				labelPromptMessage.Text = ResourceStr.Nounplug;
			}
			labelPromptMessage.ForeColor = Common.greendarktheme;
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			buttonUpdate.Enabled = false;
			buttonCancel.Enabled = false;
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_disabled;
			labelUpdateInfor.Visible = true;
			labelUpdateprogress.Visible = true;
			progressBarupdate.Visible = true;
			progressBarupdate.Value = 0;
			labelUpdateprogress.Text = "0%";
			labelUpdateprogress.ForeColor = Common.lightgray;
			if (Common.DevFWNeedUpdate)
			{
				if (blconnect)
				{
					if (!backgroundWorkerProcessFWData.IsBusy)
					{
						backgroundWorkerProcessFWData.RunWorkerAsync();
					}
					return;
				}
				curstate = eState.STATE_ENTER_BL;
				IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (!(intPtr == IntPtr.Zero))
				{
					device.EnterDevMode(intPtr, 1);
					device.CloseDev(intPtr);
					timerbllistener.Enabled = true;
					timerbllistener.Start();
					timerblentersuccess.Enabled = true;
					timerblentersuccess.Start();
					labelUpdateInfor.Text = ResourceStr.enterbootloadering;
					labelUpdateInfor.ForeColor = Common.lightgray;
					labelUpdateprogress.ForeColor = Common.lightgray;
				}
			}
			else if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
			{
				if (!backgroundWorkerGetRegionInfor.IsBusy)
				{
					backgroundWorkerGetRegionInfor.RunWorkerAsync();
				}
			}
			else if (!backgroundWorkerNordicENTERBL.IsBusy)
			{
				backgroundWorkerNordicENTERBL.RunWorkerAsync();
			}
		}

		private void backgroundWorkerEraseFlash_DoWork(object sender, DoWorkEventArgs e)
		{
			IntPtr zero = IntPtr.Zero;
			zero = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
			if (zero == IntPtr.Zero)
			{
				e.Result = eState.STATE_WAITING_BOOTLOADER;
				return;
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 2f)
			{
				backgroundWorkerEraseFlash.ReportProgress(0, eState.STATE_ERASING_FLASH_PASS);
				if (device.EraseFW(zero, Common.StartAddr, Common.EndAddr) == 2)
				{
					e.Result = eState.STATE_ERASING_FLASH_PASS;
				}
				else
				{
					e.Result = eState.STATE_ERASING_FLASH_FAIL;
				}
				device.CloseDev(zero);
				return;
			}
			_ = m_uAddressEnd;
			_ = m_uPageSize;
			float num = 1f / (float)(m_uAddressEnd - m_uAddressBegin);
			try
			{
				curstate = eState.STATE_ERASING_FLASH;
				backgroundWorkerEraseFlash.ReportProgress(0, eState.STATE_ERASING_FLASH);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 1.1f)
			{
				byte[] array = new byte[8];
				long num2 = 0L;
				long filelen = Common.filelen;
				num = 1f / (float)(filelen - 1 - num2);
				array[0] = byte.MaxValue;
				for (long num3 = 0L; num3 < Common.filelen; num3 += Common.PAGESIZE)
				{
					float num4 = (float)(num3 - num2) * num;
					backgroundWorkerEraseFlash.ReportProgress((int)(100f * num4));
					if (!device.WinUSB_ControlIn(zero, 130, (ushort)(Common.StartAddr + num3), (ushort)((Common.StartAddr + num3 >> 16) & 0xFFFF), 0, null))
					{
						e.Result = eState.STATE_ERASING_FLASH_FAIL;
						device.CloseDev(zero);
						return;
					}
					if (!device.WinUSB_ControlIn(zero, 143, 0, 0u, 1, array) || array[0] != 1)
					{
						e.Result = eState.STATE_ERASING_FLASH_FAIL;
						device.CloseDev(zero);
						return;
					}
				}
				backgroundWorkerEraseFlash.ReportProgress(100);
				e.Result = eState.STATE_ERASING_FLASH_PASS;
			}
			else
			{
				uint num5 = m_uAddressBegin;
				while (num5 <= m_uAddressEnd + 1)
				{
					ushort uvalue = (ushort)num5;
					ushort uindex = (ushort)(num5 + (m_uPageSize - 1));
					bool flag = false;
					byte[] array2 = new byte[8];
					float num6 = (float)(num5 - m_uAddressBegin) * num;
					backgroundWorkerEraseFlash.ReportProgress((int)(100f * num6));
					int num7 = 0;
					while (true)
					{
						if (num7 < 3 && !flag)
						{
							if (!device.WinUSB_ControlIn(zero, 130, uvalue, uindex, 0, array2))
							{
								device.Delay(100f);
								if (num7 == 2)
								{
									break;
								}
								num7++;
								continue;
							}
							device.Delay(2f);
							for (int i = 0; i < 3; i++)
							{
								if (flag)
								{
									break;
								}
								array2[0] = byte.MaxValue;
								if (device.WinUSB_ControlIn(zero, 143, 0, 0u, 1, array2) && byte.MaxValue != array2[0])
								{
									flag = true;
									break;
								}
								device.Delay(100f);
							}
							if (!flag)
							{
								break;
							}
						}
						num5 += m_uPageSize;
						goto IL_040d;
					}
					break;
					IL_040d:;
				}
				if (num5 >= m_uAddressEnd)
				{
					backgroundWorkerEraseFlash.ReportProgress(100);
					e.Result = eState.STATE_ERASING_FLASH_PASS;
				}
				else
				{
					e.Result = eState.STATE_ERASING_FLASH_FAIL;
				}
			}
			device.CloseDev(zero);
		}

		private void backgroundWorkerEraseFlash_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.FlashFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.05) + 5;
				}
				else
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.05 * 2.5 + 12.5);
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
				return;
			}
			progressBarupdate.Value = e.ProgressPercentage;
			labelUpdateprogress.Text = e.ProgressPercentage + "%";
			if (e.UserState != null)
			{
				eState eState2 = (eState)e.UserState;
				if (eState2 == eState.STATE_ERASING_FLASH)
				{
					labelUpdateInfor.Text = ResourceStr.eraseflash;
				}
			}
		}

		private void processupdatefail()
		{
			devreconnect = false;
			checkingretry = true;
			while (true)
			{
				string text = "";
				text = ((!Common.IsBladeKB()) ? ResourceStr.updatefail : ((!(Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")) ? string.Format(ResourceStr.bladekbupdatefail, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex)) : string.Format(ResourceStr.bladekbupdatefail, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex))));
				if (MessageBox.Show(text, labelHeader.Text, MessageBoxButtons.RetryCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.Retry)
				{
					if (Common.IsBladeKB())
					{
						buttonUpdate_Click(null, null);
						break;
					}
					if (devreconnect)
					{
						checkingretry = false;
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0401" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A00" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A14")
						{
							backgroundWorkerProgramFW.RunWorkerAsync();
						}
						else
						{
							buttonUpdate_Click(null, null);
						}
						break;
					}
					if (devconnect && blconnect)
					{
						continue;
					}
					checkingretry = false;
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0401" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A00" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A14")
					{
						labelPromptMessage.Text = ResourceStr.reconnectdev;
						labelPromptMessage.ForeColor = Common.greendarktheme;
						break;
					}
					labelPromptMessage.Visible = false;
					labelUpdateInfor.Visible = false;
					labelUpdateprogress.Visible = false;
					progressBarupdate.Visible = false;
					labelpluginDevice.ForeColor = Common.greendarktheme;
					buttonCancel.Enabled = true;
					buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
					{
						devconnect = false;
						blconnect = false;
						BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
						labelpluginDevice.ForeColor = Common.greendarktheme;
						labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
						labelkeepholdprompt.ForeColor = Color.Red;
						labelPromptMessage.Visible = false;
						labelUpdateInfor.Visible = false;
						labelUpdateprogress.Visible = false;
						progressBarupdate.Visible = false;
					}
					break;
				}
				labelUpdateInfor.Text = ResourceStr.updatefail;
				labelUpdateInfor.ForeColor = Color.Red;
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				if (Common.forsynapseuse)
				{
					buttonCancel.Visible = false;
				}
				else
				{
					buttonCancel.Visible = true;
				}
				checkingretry = false;
				break;
			}
		}

		private void backgroundWorkerEraseFlash_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((eState)e.Result == eState.STATE_ERASING_FLASH_PASS)
			{
				backgroundWorkerProgramFW.RunWorkerAsync();
			}
			else if ((eState)e.Result == eState.STATE_ERASING_FLASH_FAIL || (eState)e.Result == eState.STATE_WAITING_BOOTLOADER)
			{
				processupdatefail();
			}
		}

		private bool ProgramFW(BackgroundWorker bk, IntPtr handle, byte bCommand)
		{
			bool flag = true;
			ushort num = (ushort)m_uAddressBegin;
			ushort num2 = (ushort)m_uAddressEnd;
			float num3 = 1f / (float)(num2 - 1 - num);
			string text = string.Copy(m_strFormattedData);
			byte[] array = new byte[m_uDataPacketSize];
			byte[] array2 = new byte[m_uDataPacketSize];
			if (135 == bCommand)
			{
				curstate = eState.STATE_VERIFYING_FIRMWARE;
				bk.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE);
			}
			else
			{
				curstate = eState.STATE_DOWNLOADING_DATA;
				bk.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
			}
			while (text.Length > 2)
			{
				string strSource = "";
				int num4 = text.IndexOf(" ");
				if (num4 != 0)
				{
					strSource = Mid(text, 0, num4);
					text = Mid(text, num4 + 1, text.Length);
				}
				uint num5 = Convert.ToUInt32(Mid(strSource, 0, 2), 16);
				uint num6 = Convert.ToUInt32(Mid(strSource, 2, 2), 16) * 256;
				num6 += Convert.ToUInt32(Mid(strSource, 4, 2), 16);
				uint num7 = Convert.ToUInt32(Mid(strSource, 6, 2), 16) * 256;
				num7 += Convert.ToUInt32(Mid(strSource, 8, 2), 16);
				float num8 = (float)(num6 - num) * num3;
				bk.ReportProgress((int)(100f * num8));
				int num9 = array2.Length;
				for (int i = 0; i < num9; i++)
				{
					array2[i] = byte.MaxValue;
				}
				for (int j = 0; j < num5; j++)
				{
					string text2 = Mid(strSource, j * 2 + 10, 2);
					if ("" != text2)
					{
						array2[j] = byte.Parse(text2, NumberStyles.AllowHexSpecifier);
					}
				}
				flag = true;
				int num10 = 0;
				while (num10 < 3)
				{
					device.Delay(0f);
					bool flag2 = false;
					if (device.WinUSB_ControlOut(handle, bCommand, (ushort)num6, (ushort)num7, (ushort)num5, array2))
					{
						for (int k = 0; k < 3; k++)
						{
							if (129 == bCommand)
							{
								device.Delay(2f);
							}
							array[0] = byte.MaxValue;
							flag = device.WinUSB_ControlIn(handle, 143, 0, 0u, 1, array);
							if (flag && byte.MaxValue != array[0])
							{
								flag2 = true;
								break;
							}
							device.Delay(100f);
						}
						if (!flag2)
						{
							string msg = string.Format("Address: {0} to {1}, WinUsbReturnValue: {2}, ReturnedData: {3}, PacketSize: {4}", num6.ToString("X"), num7.ToString("X"), flag, array[0].ToString("X"), m_uDataPacketSize);
							Logger.getInstance().writeLog(msg, 2);
							flag = false;
						}
						else
						{
							flag = true;
						}
						break;
					}
					num10++;
					device.Delay(100f);
					if (num10 >= 2)
					{
						flag = false;
						break;
					}
					if (num10 != 1)
					{
						break;
					}
				}
				if (!flag)
				{
					break;
				}
			}
			if (flag && text.Length < 2)
			{
				bk.ReportProgress(100);
				return true;
			}
			return false;
		}

		private void backgroundWorkerProgramFW_DoWork(object sender, DoWorkEventArgs e)
		{
			IntPtr zero = IntPtr.Zero;
			zero = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
			if (zero == IntPtr.Zero)
			{
				e.Result = eState.STATE_WAITING_BOOTLOADER;
			}
			else if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 3f)
			{
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Position = 0L;
				byte[] array = new byte[2];
				byte[] array2 = new byte[1];
				byte[] array3 = new byte[64];
				curstate = eState.STATE_DOWNLOADING_DATA;
				backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
				float num = 1f / 59f;
				byte outpipe = 0;
				byte inpipe = 0;
				if (!device.GetPipeID(zero, ref inpipe, ref outpipe))
				{
					e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
					device.CloseDev(zero);
					fileStream.Close();
					binaryReader.Close();
					return;
				}
				for (byte b = 1; b < 60; b++)
				{
					fileStream.Position = b * 512;
					float num2 = (float)(int)b * num;
					backgroundWorkerProgramFW.ReportProgress((int)(num2 * 100f));
					array[0] = 2;
					array[1] = b;
					device.WritePipe(zero, outpipe, array, 2uL);
					device.ReadPipe(zero, inpipe, array2, 1);
					if (array2[0] != 0)
					{
						backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA_FAIL);
						e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
						MessageBox.Show("Error ret code is not 00");
						device.CloseDev(zero);
						fileStream.Close();
						binaryReader.Close();
						return;
					}
					for (byte b2 = 0; b2 < 8; b2++)
					{
						if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
						{
							array3 = binaryReader.ReadBytes(64);
							if (array3.Length < 64)
							{
								byte[] array4 = new byte[array3.Length];
								array3.CopyTo(array4, 0);
								array3 = new byte[64];
								DataDefault(array3);
								array4.CopyTo(array3, 0);
							}
						}
						else
						{
							array3 = new byte[64];
							DataDefault(array3);
						}
						device.WritePipe(zero, outpipe, array3, 64uL);
						device.ReadPipe(zero, inpipe, array2, 1);
						if (array2[0] != 0)
						{
							backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA_FAIL);
							e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
							device.CloseDev(zero);
							fileStream.Close();
							binaryReader.Close();
							return;
						}
					}
				}
				backgroundWorkerProgramFW.ReportProgress(100);
				e.Result = eState.STATE_DOWNLOADING_DATA_PASS;
				device.CloseDev(zero);
				fileStream.Close();
				binaryReader.Close();
			}
			else if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 2f)
			{
				FileStream fileStream2 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader2 = new BinaryReader(fileStream2);
				backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
				fileStream2.Position = 0L;
				byte[] array5 = new byte[8];
				long num3 = 0L;
				long length = fileStream2.Length;
				float num4 = 1f / (float)(length - 1 - num3);
				array5[0] = byte.MaxValue;
				uint num5 = 0u;
				while (num5 < fileStream2.Length)
				{
					float num6 = (float)(num5 - num3) * num4;
					backgroundWorkerProgramFW.ReportProgress((int)(num6 * 100f));
					byte[] array6 = binaryReader2.ReadBytes(Common.PACKLEN);
					int num7 = 0;
					while (num7 < Common.MAX_RETRY)
					{
						int num8 = ((!(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "007E") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C04") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F1D") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F20") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F21")) ? device.ProgramFW(zero, (byte)array6.Length, Common.StartAddr + num5, 2, array6) : device.ProgramFW(zero, (byte)array6.Length, Common.StartAddr + num5, 10, array6));
						num7++;
						if (num8 == 2)
						{
							break;
						}
						if (num7 < Common.MAX_RETRY)
						{
							device.Delay(1f);
							continue;
						}
						backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_PROCESSINGDATA_FAIL);
						e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
						device.CloseDev(zero);
						fileStream2.Close();
						binaryReader2.Close();
						return;
					}
					num5 = (uint)(num5 + array6.Length);
				}
				backgroundWorkerProgramFW.ReportProgress(100);
				e.Result = eState.STATE_DOWNLOADING_DATA_PASS;
				device.CloseDev(zero);
				fileStream2.Close();
				binaryReader2.Close();
			}
			else if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 1.1f)
			{
				FileStream fileStream3 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader3 = new BinaryReader(fileStream3);
				curstate = eState.STATE_DOWNLOADING_DATA;
				backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
				fileStream3.Position = 0L;
				byte[] array7 = new byte[8];
				long num9 = 0L;
				long length2 = fileStream3.Length;
				float num10 = 1f / (float)(length2 - 1 - num9);
				array7[0] = byte.MaxValue;
				long num11 = 0L;
				while (num11 < fileStream3.Length)
				{
					device.Delay(1f);
					float num12 = (float)(num11 - num9) * num10;
					backgroundWorkerProgramFW.ReportProgress((int)(num12 * 100f));
					byte[] array8 = binaryReader3.ReadBytes(Common.PACKLEN);
					if (array8.Length < Common.PACKLEN)
					{
						int num13 = 0;
						while (num13 < Common.MAX_RETRY)
						{
							bool num14 = device.WinUSB_ControlOut(zero, 129, (ushort)(Common.StartAddr + num11), (ushort)((Common.StartAddr + num11 >> 16) & 0xFFFF), (ushort)array8.Length, array8);
							num13++;
							if (num14)
							{
								break;
							}
							if (num13 < Common.MAX_RETRY)
							{
								device.Delay(1f);
								continue;
							}
							e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
							device.CloseDev(zero);
							fileStream3.Close();
							binaryReader3.Close();
							return;
						}
						num11 += array8.Length;
					}
					else
					{
						int num15 = 0;
						while (num15 < Common.MAX_RETRY)
						{
							bool num16 = device.WinUSB_ControlOut(zero, 129, (ushort)num11, (ushort)((num11 >> 16) & 0xFFFF), Common.PACKLEN, array8);
							num15++;
							if (num16)
							{
								break;
							}
							if (num15 < Common.MAX_RETRY)
							{
								device.Delay(1f);
								continue;
							}
							e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
							device.CloseDev(zero);
							fileStream3.Close();
							binaryReader3.Close();
							return;
						}
						num11 += Common.PACKLEN;
					}
					device.Delay(1f);
					int num17 = 0;
					while (num17 < Common.MAX_RETRY)
					{
						bool num18 = device.WinUSB_ControlIn(zero, 143, 0, 0u, 1, array7);
						num17++;
						if (num18 && array7[0] == 1)
						{
							break;
						}
						if (num17 < Common.MAX_RETRY)
						{
							device.Delay(1f);
							continue;
						}
						e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
						device.CloseDev(zero);
						fileStream3.Close();
						binaryReader3.Close();
						return;
					}
				}
				backgroundWorkerProgramFW.ReportProgress(100);
				e.Result = eState.STATE_DOWNLOADING_DATA_PASS;
				device.CloseDev(zero);
				fileStream3.Close();
				binaryReader3.Close();
			}
			else
			{
				curstate = eState.STATE_DOWNLOADING_DATA;
				backgroundWorkerProgramFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
				if (ProgramFW(backgroundWorkerProgramFW, zero, 129))
				{
					e.Result = eState.STATE_DOWNLOADING_DATA_PASS;
				}
				else
				{
					e.Result = eState.STATE_DOWNLOADING_DATA_FAIL;
				}
				device.CloseDev(zero);
			}
		}

		private void backgroundWorkerProgramFW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.FlashFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.15) + 10;
				}
				else
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.15 * 2.5 + 25.0);
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
				return;
			}
			progressBarupdate.Value = e.ProgressPercentage;
			labelUpdateprogress.Text = e.ProgressPercentage + "%";
			if (e.UserState != null)
			{
				eState eState2 = (eState)e.UserState;
				if (eState2 == eState.STATE_DOWNLOADING_DATA)
				{
					labelUpdateInfor.Text = ResourceStr.updatefw;
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
					labelPromptMessage.ForeColor = Common.greendarktheme;
				}
			}
			Application.DoEvents();
		}

		private void backgroundWorkerProgramFW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((eState)e.Result == eState.STATE_DOWNLOADING_DATA_PASS)
			{
				Invoke((Action)delegate
				{
					progressBarupdate.Refresh();
					labelUpdateprogress.Refresh();
				});
				backgroundWorkerVerify.RunWorkerAsync();
			}
			else if ((eState)e.Result == eState.STATE_DOWNLOADING_DATA_FAIL)
			{
				processupdatefail();
			}
			else if ((eState)e.Result == eState.STATE_WAITING_BOOTLOADER)
			{
				switch (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex))
				{
				case "0A00":
				case "0A14":
					Common.IsExiting = false;
					Common.NextPage = PageIndex.FormRaijuEnterBL;
					Close();
					break;
				case "0401":
					Common.IsExiting = false;
					Common.NextPage = PageIndex.FormPantheraEnterBL;
					Close();
					break;
				default:
					labelPromptMessage.Text = ResourceStr.reconnectdev;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					break;
				}
			}
		}

		private bool ArrayCompare(byte[] array1, byte[] array2)
		{
			if (array1.Length != array2.Length)
			{
				return false;
			}
			for (int i = 0; i < array1.Length; i++)
			{
				if (array1[i] != array2[i])
				{
					return false;
				}
			}
			return true;
		}

		private void backgroundWorkerVerify_DoWork(object sender, DoWorkEventArgs e)
		{
			IntPtr zero = IntPtr.Zero;
			zero = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
			if (zero == IntPtr.Zero)
			{
				e.Result = eState.STATE_WAITING_BOOTLOADER;
				return;
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 3f)
			{
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				fileStream.Position = 0L;
				byte[] array = new byte[2];
				byte[] array2 = new byte[1];
				byte[] array3 = new byte[64];
				byte outpipe = 0;
				byte inpipe = 0;
				if (!device.GetPipeID(zero, ref inpipe, ref outpipe))
				{
					e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
					device.CloseDev(zero);
					fileStream.Close();
					binaryReader.Close();
					return;
				}
				curstate = eState.STATE_VERIFYING_FIRMWARE;
				float num = 0.002118644f;
				backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE);
				for (ushort num2 = 0; num2 < 480; num2++)
				{
					if (num2 * 64 < binaryReader.BaseStream.Length)
					{
						fileStream.Position = num2 * 64;
					}
					else
					{
						fileStream.Position = binaryReader.BaseStream.Length;
					}
					if (num2 >= 8)
					{
						byte[] bytes = BitConverter.GetBytes(num2);
						byte[] buffer = new byte[2]
						{
							6,
							bytes[1]
						};
						device.WritePipe(zero, outpipe, buffer, 2uL);
						device.ReadPipe(zero, inpipe, array2, 1);
						if (array2[0] != 0)
						{
							backgroundWorkerVerify.ReportProgress(0, eState.STATE_FAILED);
							e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
							MessageBox.Show("Error ret code is not 00");
							device.CloseDev(zero);
							fileStream.Close();
							binaryReader.Close();
							return;
						}
						byte[] buffer2 = new byte[2]
						{
							3,
							bytes[0]
						};
						byte[] buffer3 = new byte[64];
						device.WritePipe(zero, outpipe, buffer2, 2uL);
						device.ReadPipe(zero, inpipe, buffer3, 64);
						if (binaryReader.BaseStream.Position != binaryReader.BaseStream.Length)
						{
							array3 = binaryReader.ReadBytes(64);
							if (array3.Length < 64)
							{
								byte[] array4 = new byte[array3.Length];
								array3.CopyTo(array4, 0);
								array3 = new byte[64];
								DataDefault(array3);
								array4.CopyTo(array3, 0);
							}
						}
						else
						{
							array3 = new byte[64];
							DataDefault(array3);
						}
						float num3 = (float)(num2 - 7) * num;
						backgroundWorkerVerify.ReportProgress((int)(num3 * 100f));
					}
				}
				array[0] = 2;
				array[1] = 0;
				device.WritePipe(zero, outpipe, array, 2uL);
				device.ReadPipe(zero, inpipe, array2, 1);
				if (array2[0] != 0)
				{
					backgroundWorkerVerify.ReportProgress(0, eState.STATE_FAILED);
					e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
					MessageBox.Show("Error ret code is not 00");
					device.CloseDev(zero);
					fileStream.Close();
					binaryReader.Close();
					return;
				}
				fileStream.Position = 0L;
				for (byte b = 0; b < 8; b++)
				{
					array3 = binaryReader.ReadBytes(64);
					device.WritePipe(zero, outpipe, array3, 64uL);
					device.ReadPipe(zero, inpipe, array2, 1);
					if (array2[0] != 0)
					{
						backgroundWorkerVerify.ReportProgress(0, eState.STATE_FAILED);
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
						MessageBox.Show("Error ret code is not 00");
						device.CloseDev(zero);
						fileStream.Close();
						binaryReader.Close();
						return;
					}
				}
				fileStream.Position = 0L;
				for (ushort num4 = 0; num4 < 8; num4++)
				{
					byte[] bytes2 = BitConverter.GetBytes(num4);
					byte[] buffer4 = new byte[2]
					{
						6,
						bytes2[1]
					};
					device.WritePipe(zero, outpipe, buffer4, 2uL);
					device.ReadPipe(zero, inpipe, array2, 1);
					if (array2[0] != 0)
					{
						backgroundWorkerVerify.ReportProgress(0, eState.STATE_FAILED);
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
						MessageBox.Show("Error ret code is not 00");
						device.CloseDev(zero);
						fileStream.Close();
						binaryReader.Close();
						return;
					}
					byte[] buffer5 = new byte[2]
					{
						3,
						bytes2[0]
					};
					byte[] array5 = new byte[64];
					device.WritePipe(zero, outpipe, buffer5, 2uL);
					device.ReadPipe(zero, inpipe, array5, 64);
					if (!ArrayCompare(array5, binaryReader.ReadBytes(64)))
					{
						backgroundWorkerVerify.ReportProgress(0, eState.STATE_FAILED);
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
						MessageBox.Show($"offset: {num4} fw data verifier fail");
						device.CloseDev(zero);
						fileStream.Close();
						binaryReader.Close();
						return;
					}
				}
				backgroundWorkerVerify.ReportProgress(100);
				e.Result = eState.STATE_VERIFYING_FIRMWARE_PASS;
				device.CloseDev(zero);
				fileStream.Close();
				binaryReader.Close();
				return;
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 2f)
			{
				FileStream fileStream2 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader2 = new BinaryReader(fileStream2);
				backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE);
				fileStream2.Position = 0L;
				byte[] array6 = new byte[8];
				long num5 = 0L;
				long length = fileStream2.Length;
				float num6 = 1f / (float)(length - 1 - num5);
				array6[0] = byte.MaxValue;
				uint num7 = 0u;
				while (num7 < fileStream2.Length)
				{
					float num8 = (float)(num7 - num5) * num6;
					backgroundWorkerVerify.ReportProgress((int)(num8 * 100f));
					byte[] array7 = binaryReader2.ReadBytes(Common.PACKLEN);
					byte[] array8 = new byte[(byte)array7.Length];
					int num9 = 0;
					while (num9 < Common.MAX_RETRY)
					{
						int num10 = ((!(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "007E") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0C04") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F1D") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F20") && !(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0F21")) ? device.VerifyFW(zero, (byte)array7.Length, Common.StartAddr + num7, 2, array8) : device.VerifyFW(zero, (byte)array7.Length, Common.StartAddr + num7, 10, array8));
						num9++;
						if (num10 == 2)
						{
							for (int i = 0; i < array7.Length; i++)
							{
								if (array7[i] != array8[i])
								{
									backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE_FAIL);
									e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
									device.CloseDev(zero);
									fileStream2.Close();
									binaryReader2.Close();
									return;
								}
							}
							break;
						}
						if (num9 < Common.MAX_RETRY)
						{
							device.Delay(1f);
							continue;
						}
						backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE_FAIL);
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
						device.CloseDev(zero);
						fileStream2.Close();
						binaryReader2.Close();
						return;
					}
					num7 = (uint)(num7 + array7.Length);
				}
				backgroundWorkerVerify.ReportProgress(100);
				e.Result = eState.STATE_VERIFYING_FIRMWARE_PASS;
				device.CloseDev(zero);
				fileStream2.Close();
				binaryReader2.Close();
				return;
			}
			if (Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) == 1.1f)
			{
				FileStream fileStream3 = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin", FileMode.Open);
				BinaryReader binaryReader3 = new BinaryReader(fileStream3);
				curstate = eState.STATE_VERIFYING_FIRMWARE;
				backgroundWorkerVerify.ReportProgress(0, eState.STATE_VERIFYING_FIRMWARE);
				fileStream3.Position = 0L;
				byte[] array9 = new byte[8];
				long num11 = 0L;
				long length2 = fileStream3.Length;
				float num12 = 1f / (float)(length2 - 1 - num11);
				array9[0] = byte.MaxValue;
				long num13 = 0L;
				while (num13 < fileStream3.Length)
				{
					device.Delay(1f);
					float num14 = (float)(num13 - num11) * num12;
					backgroundWorkerVerify.ReportProgress((int)(num14 * 100f));
					byte[] array10 = binaryReader3.ReadBytes(Common.PACKLEN);
					if (array10.Length < Common.PACKLEN)
					{
						int num15 = 0;
						while (num15 < Common.MAX_RETRY)
						{
							bool num16 = device.WinUSB_ControlOut(zero, 135, (ushort)(Common.StartAddr + num13), (ushort)((Common.StartAddr + num13 >> 16) & 0xFFFF), (ushort)array10.Length, array10);
							num15++;
							if (num16)
							{
								break;
							}
							if (num15 < Common.MAX_RETRY)
							{
								device.Delay(1f);
								continue;
							}
							e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
							device.CloseDev(zero);
							fileStream3.Close();
							binaryReader3.Close();
							return;
						}
						num13 += array10.Length;
					}
					else
					{
						int num17 = 0;
						while (num17 < Common.MAX_RETRY)
						{
							bool num18 = device.WinUSB_ControlOut(zero, 135, (ushort)num13, (ushort)((num13 >> 16) & 0xFFFF), Common.PACKLEN, array10);
							num17++;
							if (num18)
							{
								break;
							}
							if (num17 < Common.MAX_RETRY)
							{
								device.Delay(1f);
								continue;
							}
							e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
							device.CloseDev(zero);
							fileStream3.Close();
							binaryReader3.Close();
							return;
						}
						num13 += Common.PACKLEN;
					}
					device.Delay(1f);
					int num19 = 0;
					while (num19 < Common.MAX_RETRY)
					{
						bool num20 = device.WinUSB_ControlIn(zero, 143, 0, 0u, 1, array9);
						num19++;
						if (num20 && array9[0] == 1)
						{
							break;
						}
						if (num19 < Common.MAX_RETRY)
						{
							device.Delay(1f);
							continue;
						}
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
						device.CloseDev(zero);
						fileStream3.Close();
						binaryReader3.Close();
						return;
					}
				}
				backgroundWorkerVerify.ReportProgress(100);
				e.Result = eState.STATE_VERIFYING_FIRMWARE_PASS;
				device.CloseDev(zero);
				fileStream3.Close();
				binaryReader3.Close();
				return;
			}
			int checksumMCU = 255;
			if (Common.updateInfo.IsVerifyCheckSum(Common.updateInfo.CurDevIndex))
			{
				if (callWinusbChecksumControl(zero, 1, ref checksumMCU))
				{
					if (checksumMCU == 0)
					{
						e.Result = eState.STATE_VERIFYING_FIRMWARE_PASS;
					}
					else
					{
						e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
					}
				}
				else
				{
					e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
				}
			}
			else if (ProgramFW(backgroundWorkerVerify, zero, 135))
			{
				e.Result = eState.STATE_VERIFYING_FIRMWARE_PASS;
			}
			else
			{
				e.Result = eState.STATE_VERIFYING_FIRMWARE_FAIL;
			}
			device.CloseDev(zero);
		}

		private void backgroundWorkerVerify_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.FlashFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.15) + 25;
				}
				else
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.15 * 2.5 + 62.5);
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
				return;
			}
			progressBarupdate.Value = e.ProgressPercentage;
			labelUpdateprogress.Text = e.ProgressPercentage + "%";
			if (e.UserState != null)
			{
				eState eState2 = (eState)e.UserState;
				if (eState2 == eState.STATE_VERIFYING_FIRMWARE)
				{
					labelUpdateInfor.Text = ResourceStr.verifyfw;
				}
			}
		}

		private void backgroundWorkerVerify_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if ((eState)e.Result == eState.STATE_VERIFYING_FIRMWARE_PASS)
			{
				Invoke((Action)delegate
				{
					progressBarupdate.Refresh();
					labelUpdateprogress.Refresh();
				});
				curstate = eState.STATE_EXIT_BL;
				IntPtr zero = IntPtr.Zero;
				zero = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
				if (!(zero == IntPtr.Zero))
				{
					device.ExitBL(zero, Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex));
					timerexitbldetect.Enabled = true;
					timerexitbldetect.Start();
					device.CloseDev(zero);
				}
			}
			else if ((eState)e.Result == eState.STATE_VERIFYING_FIRMWARE_FAIL)
			{
				processupdatefail();
			}
			else if ((eState)e.Result == eState.STATE_WAITING_BOOTLOADER)
			{
				switch (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex))
				{
				case "0A00":
				case "0A14":
					Common.IsExiting = false;
					Common.NextPage = PageIndex.FormRaijuEnterBL;
					Close();
					break;
				case "0401":
					Common.IsExiting = false;
					Common.NextPage = PageIndex.FormPantheraEnterBL;
					Close();
					break;
				default:
					labelPromptMessage.Text = ResourceStr.reconnectdev;
					labelPromptMessage.ForeColor = Common.greendarktheme;
					break;
				}
			}
		}

		private void timerbllistener_Tick(object sender, EventArgs e)
		{
			timerbllistener.Stop();
			timerbllistener.Enabled = false;
			if (blconnect)
			{
				return;
			}
			if (Common.IsBladeKB())
			{
				labelPromptMessage.Text = ResourceStr.BLfailretry;
				if (MessageBox.Show(labelPromptMessage.Text, "Please restart system", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					device.RestartSystem();
					return;
				}
				Thread.Sleep(10000);
				Application.Exit();
				return;
			}
			MessageBox.Show(ResourceStr.reconnectdev);
			if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
			{
				devconnect = false;
				blconnect = false;
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
				labelpluginDevice.ForeColor = Common.greendarktheme;
				labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
				labelkeepholdprompt.ForeColor = Color.Red;
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				labelPromptMessage.Visible = false;
				labelUpdateInfor.Visible = false;
				labelUpdateprogress.Visible = false;
				progressBarupdate.Visible = false;
			}
		}

		private void timerblentersuccess_Tick(object sender, EventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			if (!(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517") && devconnect)
			{
				timerbllistener.Stop();
				timerbllistener.Enabled = false;
				timerblentersuccess.Stop();
				timerblentersuccess.Enabled = false;
				MessageBox.Show(ResourceStr.closesynapseandotherapp);
				curstate = eState.STATE_ENTER_BL;
				IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (!(intPtr == IntPtr.Zero))
				{
					device.EnterDevMode(intPtr, 1);
					timerbllistener.Enabled = true;
					timerbllistener.Start();
					timerblentersuccess.Enabled = true;
					timerblentersuccess.Start();
					timerblentersuccess.Interval = 2000;
					labelUpdateInfor.Text = ResourceStr.enterbootloadering;
				}
			}
			else
			{
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				timerblentersuccess.Stop();
				timerblentersuccess.Enabled = false;
			}
		}

		private void backgroundWorkerCloseRestartDialog_DoWork(object sender, DoWorkEventArgs e)
		{
			while (!stopclosethread)
			{
				Process[] processesByName = Process.GetProcessesByName("taskhostw");
				for (int i = 0; i < processesByName.Length; i++)
				{
					if (processesByName[i].MainWindowHandle.ToInt32() != 0)
					{
						processesByName[i].CloseMainWindow();
					}
				}
				processesByName = Process.GetProcessesByName("taskhost");
				for (int j = 0; j < processesByName.Length; j++)
				{
					if (processesByName[j].MainWindowHandle.ToInt32() != 0)
					{
						processesByName[j].CloseMainWindow();
					}
				}
			}
		}

		private void backgroundWorkerCloseRestartDialog_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void FormFWUStep1_Shown(object sender, EventArgs e)
		{
			buttonUpdate.Location = new Point(base.Size.Width - buttonUpdate.Width - 40, base.Size.Height - buttonUpdate.Height - Common.hspacebtnbottom);
			buttonCancel.Location = new Point(buttonUpdate.Location.X - Common.wspacebutton - buttonCancel.Width, buttonUpdate.Location.Y);
			Common.NextPage = PageIndex.Close;
			float num = (float)base.Width / 730f;
			while ((float)labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				labelHeader.Font = new Font(labelHeader.Font.FontFamily, labelHeader.Font.Size - 1f);
			}
			if (Common.updateInfo.CurDevIndex >= 0)
			{
				_ = Common.updateInfo.CurDevIndex;
			}
		}

		private void FormFWUStep1_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "flashfw.bin");
				File.Delete(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "FW.bin");
			}
			catch (Exception)
			{
			}
		}

		private void backgroundWorkercheckbattery_DoWork(object sender, DoWorkEventArgs e)
		{
			while (checkbattery)
			{
				SYSTEM_POWER_STATUS lpSystemPowerStatus = default(SYSTEM_POWER_STATUS);
				GetSystemPowerStatus(ref lpSystemPowerStatus);
				Thread.Sleep(100);
				if (lpSystemPowerStatus.ACLineStatus != 1 && lpSystemPowerStatus.BatteryLifePercent < 50)
				{
					backgroundWorkercheckbattery.ReportProgress(0, true);
					Common.IsLowBattery = true;
				}
				else
				{
					Common.IsLowBattery = false;
					backgroundWorkercheckbattery.ReportProgress(0, false);
				}
			}
		}

		private void backgroundWorkercheckbattery_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void backgroundWorkercheckbattery_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			if (Convert.ToBoolean(e.UserState))
			{
				buttonUpdate.Enabled = false;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			}
			else
			{
				buttonUpdate.Enabled = true;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			}
		}

		private void backgroundWorkerCheckFlashFWVer_DoWork(object sender, DoWorkEventArgs e)
		{
			int num = 0;
			IntPtr zero = IntPtr.Zero;
			while (true)
			{
				num++;
				zero = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (!(zero == IntPtr.Zero))
				{
					break;
				}
				if (num == 10)
				{
					e.Result = eState.STATE_WAITING_DEVICE;
					return;
				}
				device.Delay(1000f);
			}
			string text = "";
			if (!(zero != IntPtr.Zero))
			{
				return;
			}
			num = 0;
			while (text == "" && num < 15)
			{
				text = device.GetDevFWVer(zero, nxp: false);
				if (text != "")
				{
					break;
				}
				device.Delay(1000f);
				num++;
			}
			device.CloseDev(zero);
			Common.curdevver = text;
			Common.updateInfo.ActFlashFWVer = text;
			Common.updateInfo.FlashSameVer = string.Compare(text, Common.updateInfo.GetFlashFWVer(Common.updateInfo.CurDevIndex));
		}

		private void backgroundWorkerCheckFlashFWVer_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (e.Result != null)
			{
				curstate = eState.STATE_NULL;
				labelUpdateInfor.Text = "Get FW Version Fail!";
				labelUpdateInfor.ForeColor = Color.Red;
				return;
			}
			int flashSameVer = Common.updateInfo.FlashSameVer;
			labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetFlashFWVer(Common.updateInfo.CurDevIndex);
			labeltargetver.Visible = true;
			labelCurFWver.ForeColor = Color.FromArgb(7763574);
			if (flashSameVer < 0)
			{
				if (Common.DevFWNeedUpdate)
				{
					if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
					{
						if (!backgroundWorkerGetRegionInfor.IsBusy)
						{
							backgroundWorkerGetRegionInfor.RunWorkerAsync();
						}
					}
					else if (!backgroundWorkerNordicENTERBL.IsBusy)
					{
						backgroundWorkerNordicENTERBL.RunWorkerAsync();
					}
					return;
				}
				labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActFlashFWVer;
				labelCurFWver.Visible = true;
				labeltargetver.ForeColor = Color.FromArgb(7584512);
				labelPromptMessage.Visible = true;
				labelUpdateInfor.Visible = false;
				labelUpdateprogress.Visible = false;
				progressBarupdate.Visible = false;
				if (Common.IsLowBattery)
				{
					buttonUpdate.Enabled = false;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
					checkbattery = true;
					backgroundWorkercheckbattery.RunWorkerAsync();
				}
				else
				{
					buttonUpdate.Enabled = true;
					buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				labelupdaterstatus.ForeColor = Common.greendarktheme;
				labelupdaterstatus.Text = ResourceStr.anupdaterequired;
			}
			else if (curstate == eState.STATE_FLASHFW_AFTER)
			{
				curstate = eState.STATE_NULL;
				labelCurFWver.Text = ResourceStr.devicever + Common.updateInfo.ActFlashFWVer;
				labeltargetver.ForeColor = Color.FromArgb(7763574);
				labelCurFWver.Visible = true;
				labeltargetver.Visible = true;
				Common.IsExiting = false;
				Common.NextPage = PageIndex.FormCongratulation;
				Application.DoEvents();
				device.Delay(1000f);
				Close();
			}
			else
			{
				labelCurFWver.Visible = false;
				labelPromptMessage.Visible = true;
				labelUpdateInfor.Visible = false;
				labelUpdateprogress.Visible = false;
				progressBarupdate.Visible = false;
				buttonUpdate.Enabled = false;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				if (Common.IsBladeKB())
				{
					labelupdaterstatus.Visible = true;
					labelupdaterstatus.Text = ResourceStr.docknoupdate;
					labelupdaterstatus.ForeColor = Common.greendarktheme;
					labelPromptMessage.Text = ResourceStr.devhavelatestfw;
					labelPromptMessage.ForeColor = Color.White;
				}
				else
				{
					labelupdaterstatus.Visible = false;
					labelPromptMessage.Text = ResourceStr.noupdaterequired;
					labelPromptMessage.ForeColor = Common.greendarktheme;
				}
				labeltargetver.ForeColor = Common.lightgray;
				labeltargetver.Text = ResourceStr.devicever + Common.updateInfo.GetFlashFWVer(Common.updateInfo.CurDevIndex);
			}
		}

		private void backgroundWorkerNordicENTERBL_DoWork(object sender, DoWorkEventArgs e)
		{
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				byte[] retdata = new byte[80];
				int num = device.SendCommand(intPtr, 0, 10, 0, 0, 0, 0, 5, 100, null, retdata);
				if (num != 2)
				{
					MessageBox.Show("Enter bootloader Fail!");
				}
				e.Result = num;
				device.CloseDev(intPtr);
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerNordicENTERBL_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Convert.ToInt32(e.Result.ToString()) != 2)
			{
				return;
			}
			for (int i = 0; i < 20; i++)
			{
				device.Delay(1000f);
				IntPtr zero = IntPtr.Zero;
				zero = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (zero != IntPtr.Zero)
				{
					if (device.GetDevFWVer(zero, nxp: false).StartsWith("177."))
					{
						device.CloseDev(zero);
						break;
					}
					device.CloseDev(zero);
				}
			}
			device.Delay(1000f);
			if (!backgroundWorkerGetRegionInfor.IsBusy)
			{
				backgroundWorkerGetRegionInfor.RunWorkerAsync();
			}
		}

		private void backgroundWorkerGetRegionInfor_DoWork(object sender, DoWorkEventArgs e)
		{
			device.Delay(3000f);
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				byte[] array = new byte[80];
				byte[] array2 = new byte[80];
				Array.Clear(array2, 0, 80);
				int num = device.SendCommand(intPtr, 0, 10, 128, 0, 0, 80, 5, 100, array2, array);
				if (num != 2)
				{
					e.Result = 0;
					MessageBox.Show("Get Region Information Fail!");
				}
				else
				{
					Common.total = array[0];
					Common.RegionID = array[1];
					Common.type = array[2];
					Common.packetsize = array[3];
					Common.regionsize = (uint)(array[4] * 256 * 256 * 256 + array[5] * 256 * 256 + array[6] * 256 + array[7]);
				}
				e.Result = num;
				device.CloseDev(intPtr);
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerGetRegionInfor_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Convert.ToInt32(e.Result.ToString()) == 2)
			{
				if (Common.total > 0)
				{
					if (Common.type == 2 || Common.type == 3)
					{
						if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A19")
						{
							if (!backgroundWorkerSetFlashRegionIDList.IsBusy)
							{
								backgroundWorkerSetFlashRegionIDList.RunWorkerAsync();
							}
						}
						else if (!backgroundWorkerNordicProgram.IsBusy)
						{
							backgroundWorkerNordicProgram.RunWorkerAsync();
						}
					}
					else
					{
						MessageBox.Show("Your Region can't write!");
					}
				}
				else
				{
					MessageBox.Show("Sorry, your device have no region id!");
				}
			}
			else
			{
				curstate = eState.STATE_FAILED;
			}
		}

		private void backgroundWorkerNordicProgram_DoWork(object sender, DoWorkEventArgs e)
		{
			Common.crc = ushort.MaxValue;
			e.Result = 1;
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				Thread.Sleep(1000);
				string text = "";
				byte b = 0;
				byte[] array = new byte[80];
				byte[] array2 = new byte[80];
				int num = 0;
				backgroundWorkerNordicProgram.ReportProgress(0);
				int num2 = 0;
				uint flashFWLineNum = Common.updateInfo.GetFlashFWLineNum(Common.updateInfo.CurDevIndex);
				while (num2 < flashFWLineNum)
				{
					Array.Clear(array, 0, 80);
					Array.Clear(array2, 0, 80);
					b = 0;
					text = "";
					text = Common.updateInfo.GetFlashFWLine(Common.updateInfo.CurDevIndex, num2++);
					text = text.Trim('\r');
					text = text.Trim('\n');
					byte[] array3 = new byte[92];
					Array.Clear(array3, 0, 92);
					for (int i = 0; i < text.Length; i++)
					{
						array3[i] = (byte)text.ElementAt(i);
					}
					Common.CRC16(array3);
					b = (byte)text.Length;
					array[0] = Common.RegionID;
					array[1] = 0;
					array[2] = 0;
					array[3] = 0;
					array[4] = 0;
					array[5] = 0;
					array[6] = b;
					for (int j = 0; j < text.Length; j++)
					{
						array[j + 7] = (byte)text.ElementAt(j);
					}
					if (device.SendCommand(intPtr, 0, 10, 2, byte.MaxValue, byte.MaxValue, (byte)(b + 7), 5, 2, array, array2) == 2 && array2[5] == 0)
					{
						num = (int)(num2 * 100 / flashFWLineNum);
						backgroundWorkerNordicProgram.ReportProgress(num);
						Thread.Sleep(10);
						continue;
					}
					e.Result = 0;
					break;
				}
				device.CloseDev(intPtr);
				if (Convert.ToInt32(e.Result) == 1)
				{
					backgroundWorkerNordicProgram.ReportProgress(100);
				}
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerNordicProgram_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.DevFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.6) + 40;
				}
				else
				{
					progressBarupdate.Value = e.ProgressPercentage;
					labelUpdateInfor.Text = ResourceStr.updatefw;
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
			}
			else
			{
				progressBarupdate.Value = e.ProgressPercentage;
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
			}
		}

		private void backgroundWorkerNordicProgram_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Convert.ToInt32(e.Result) == 0)
			{
				MessageBox.Show("Flash FW Program Fail!");
				curstate = eState.STATE_FAILED;
			}
			else if (!backgroundWorkerVerifyNordicFW.IsBusy)
			{
				backgroundWorkerVerifyNordicFW.RunWorkerAsync();
			}
		}

		private void backgroundWorkerVerifyNordicFW_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = 1;
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				Common.updateInfo.GetFlashFWLineNum(Common.updateInfo.CurDevIndex);
				byte b = 0;
				byte[] array = new byte[80];
				byte[] array2 = new byte[80];
				b = 3;
				array[0] = Common.RegionID;
				array[1] = 0;
				array[2] = 0;
				array[3] = 0;
				array[4] = 0;
				array[5] = 0;
				array[6] = b;
				array[7] = 60;
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0059")
				{
					array[8] = 0;
					array[9] = 0;
				}
				else
				{
					byte[] bytes = BitConverter.GetBytes(Common.crc);
					array[8] = bytes[1];
					array[9] = bytes[0];
				}
				if (device.SendCommand(intPtr, 0, 10, 2, 0, 0, (byte)(b + 7), 5, 2, array, array2) == 2 && array2[5] == 0)
				{
					e.Result = 1;
				}
				else
				{
					e.Result = 0;
				}
				device.CloseDev(intPtr);
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerVerifyNordicFW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Convert.ToInt32(e.Result.ToString()) == 0)
			{
				MessageBox.Show("Verify Nordic FW Fail!");
				curstate = eState.STATE_FAILED;
				return;
			}
			Thread.Sleep(100);
			curstate = eState.STATE_EXIT_NordicBL;
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (!(intPtr != IntPtr.Zero))
			{
				return;
			}
			for (int i = 0; i < 10; i++)
			{
				byte[] retdata = new byte[80];
				if (device.SendCommand(intPtr, 0, 12, 0, 0, 0, 0, 5, 10, null, retdata) == 2)
				{
					break;
				}
			}
			Thread.Sleep(1000);
		}

		private void backgroundWorkerProcessFlashFW_DoWork(object sender, DoWorkEventArgs e)
		{
			curstate = eState.STATE_PROCESSING_DATA;
			FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "flashfw.bin", FileMode.Create);
			BinaryWriter binaryWriter = new BinaryWriter(fileStream);
			ResourceSet resourceSet = new ResourceSet(Common.resfile);
			Common.flashfwlen = Convert.ToInt64(resourceSet.GetObject("FlashFWFileSize"));
			long num = 0L;
			int num2 = 0;
			int num3 = 0;
			while (num < Common.flashfwlen)
			{
				byte[] array = (byte[])resourceSet.GetObject("FlashFWSector" + num2++);
				num += array.Length;
				binaryWriter.Write(array);
				num3++;
			}
			binaryWriter.Close();
			fileStream.Close();
			resourceSet.Close();
			e.Result = 1;
		}

		private void backgroundWorkerSetFlashRegionIDList_DoWork(object sender, DoWorkEventArgs e)
		{
			byte[] bytes = BitConverter.GetBytes(Common.flashfwlen);
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				byte[] array = new byte[80];
				byte[] array2 = new byte[80];
				Array.Clear(array2, 0, 80);
				array2[0] = Common.total;
				array2[1] = Common.RegionID;
				array2[2] = Common.type;
				array2[3] = Common.packetsize;
				Array.Copy(bytes, 0, array2, 4, 4);
				if (device.SendCommand(intPtr, 0, 10, 0, 0, 0, 80, 5, 100, array2, array) != 2)
				{
					e.Result = 0;
				}
				else
				{
					e.Result = 1;
					Common.total = array[0];
					Common.RegionID = array[1];
					Common.type = array[2];
					Common.regionsize = (uint)(array[4] * 256 * 256 * 256 + array[5] * 256 * 256 + array[6] * 256 + array[7]);
					device.Delay(1000f);
				}
				device.CloseDev(intPtr);
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerSetFlashRegionData_DoWork(object sender, DoWorkEventArgs e)
		{
			e.Result = 0;
			IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
			if (intPtr != IntPtr.Zero)
			{
				FileStream fileStream = new FileStream(AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "flashfw.bin", FileMode.Open);
				BinaryReader binaryReader = new BinaryReader(fileStream);
				backgroundWorkerProgramSTMFlashFW.ReportProgress(0, eState.STATE_DOWNLOADING_DATA);
				fileStream.Position = 0L;
				byte[] array = new byte[8];
				long num = 0L;
				long length = fileStream.Length;
				float num2 = 1f / (float)(length - 1 - num);
				array[0] = byte.MaxValue;
				uint num3 = 0u;
				byte[] array2 = new byte[80];
				while (num3 < fileStream.Length)
				{
					Array.Clear(array2, 0, 80);
					float num4 = (float)(num3 - num) * num2;
					backgroundWorkerProgramSTMFlashFW.ReportProgress((int)(num4 * 100f));
					byte[] array3 = binaryReader.ReadBytes(Common.FlashPACKLEN);
					if (device.SendCommand(intPtr, 0, 10, 2, byte.MaxValue, byte.MaxValue, Convert.ToByte(array3.Length), 5, 10, array3, array2) != 2)
					{
						device.CloseDev(intPtr);
						fileStream.Close();
						binaryReader.Close();
						return;
					}
					num3 = (uint)(num3 + array3.Length);
				}
				backgroundWorkerProgramSTMFlashFW.ReportProgress(100);
				e.Result = 1;
				device.CloseDev(intPtr);
				fileStream.Close();
				binaryReader.Close();
			}
			else
			{
				e.Result = 0;
			}
		}

		private void backgroundWorkerProcessFlashFW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			switch (Convert.ToInt32(e.Result))
			{
			case 1:
				buttonCancel.Enabled = false;
				buttonUpdate.Enabled = false;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_disabled;
				if (!backgroundWorkerProgramSTMFlashFW.IsBusy)
				{
					backgroundWorkerProgramSTMFlashFW.RunWorkerAsync();
				}
				break;
			case 0:
				processupdatefail();
				break;
			}
		}

		private void backgroundWorkerSetFlashRegionIDList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			switch (Convert.ToInt32(e.Result))
			{
			case 1:
				buttonCancel.Enabled = false;
				buttonUpdate.Enabled = false;
				buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_disabled;
				if (Common.total <= 0)
				{
					break;
				}
				if (Common.type == 2 || Common.type == 3)
				{
					if (!backgroundWorkerProcessFlashFW.IsBusy)
					{
						backgroundWorkerProcessFlashFW.RunWorkerAsync();
					}
				}
				else
				{
					MessageBox.Show("Your Region can't write!");
				}
				break;
			case 0:
				processupdatefail();
				break;
			}
		}

		private void backgroundWorkerProgramSTMFlashFW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			switch (Convert.ToInt32(e.Result))
			{
			case 1:
			{
				IntPtr intPtr = device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex), 16), 0, 0f, Common.updateInfo.GetDevReportType(Common.updateInfo.CurDevIndex), Common.updateInfo.GetFeatureRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetInputRptLen(Common.updateInfo.CurDevIndex), Common.updateInfo.GetOutputRptLen(Common.updateInfo.CurDevIndex));
				if (!(intPtr == IntPtr.Zero))
				{
					byte[] retdata = new byte[80];
					byte[] array = new byte[80];
					Array.Clear(array, 0, 80);
					device.SendCommand(intPtr, 0, 12, 0, 0, 0, 0, 5, 100, array, retdata);
					device.CloseDev(intPtr);
					curstate = eState.STATE_EXIT_NordicBL;
				}
				break;
			}
			case 0:
				processupdatefail();
				break;
			}
		}

		private void backgroundWorkerProgramSTMFlashFW_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			labelUpdateInfor.ForeColor = Common.lightgray;
			labelUpdateprogress.ForeColor = Common.lightgray;
			if (Common.updateInfo.IsUpdateFlashFW(Common.updateInfo.CurDevIndex))
			{
				if (Common.DevFWNeedUpdate)
				{
					progressBarupdate.Value = (int)((double)e.ProgressPercentage * 0.6) + 40;
				}
				else
				{
					progressBarupdate.Value = e.ProgressPercentage;
					labelUpdateInfor.Text = ResourceStr.updatefw;
					labelupdaterstatus.Visible = false;
					if (Common.IsBladeKB())
					{
						labelPromptMessage.Text = ResourceStr.NoPCPowerOff;
					}
					else
					{
						labelPromptMessage.Text = ResourceStr.Nounplug;
					}
				}
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
			}
			else
			{
				progressBarupdate.Value = e.ProgressPercentage;
				labelUpdateprogress.Text = progressBarupdate.Value + "%";
			}
		}

		private void timerexitbldetect_Tick(object sender, EventArgs e)
		{
			timerexitbldetect.Stop();
			timerexitbldetect.Enabled = false;
			if (blconnect || devconnect)
			{
				return;
			}
			if (Common.IsBladeKB())
			{
				labelPromptMessage.Text = ResourceStr.BLfailretry;
				if (MessageBox.Show(labelPromptMessage.Text, "Please restart system", MessageBoxButtons.OKCancel) == DialogResult.OK)
				{
					device.RestartSystem();
					return;
				}
				Thread.Sleep(10000);
				Application.Exit();
				return;
			}
			MessageBox.Show(ResourceStr.reconnectdev);
			if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0517")
			{
				devconnect = false;
				blconnect = false;
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.bothlight_drk;
				labelpluginDevice.ForeColor = Common.greendarktheme;
				labelpressandholdpwrbtn.ForeColor = Common.greendarktheme;
				labelkeepholdprompt.ForeColor = Color.Red;
				buttonCancel.Enabled = true;
				buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
				labelPromptMessage.Visible = false;
				labelUpdateInfor.Visible = false;
				labelUpdateprogress.Visible = false;
				progressBarupdate.Visible = false;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.FormFWUStep1));
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelpluginDevice = new System.Windows.Forms.Label();
			this.labelPromptMessage = new System.Windows.Forms.Label();
			this.labelUpdateprogress = new System.Windows.Forms.Label();
			this.labelUpdateInfor = new System.Windows.Forms.Label();
			this.labeltargetver = new System.Windows.Forms.Label();
			this.labelCurFWver = new System.Windows.Forms.Label();
			this.backgroundWorkerProcessFWData = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerCheckVer = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerEraseFlash = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerProgramFW = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerVerify = new System.ComponentModel.BackgroundWorker();
			this.timerbllistener = new System.Windows.Forms.Timer(this.components);
			this.timerblentersuccess = new System.Windows.Forms.Timer(this.components);
			this.backgroundWorkerCloseRestartDialog = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkercheckbattery = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerCheckFlashFWVer = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerNordicENTERBL = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerGetRegionInfor = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerNordicProgram = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerVerifyNordicFW = new System.ComponentModel.BackgroundWorker();
			this.labelpressandholdpwrbtn = new System.Windows.Forms.Label();
			this.labelkeepholdprompt = new System.Windows.Forms.Label();
			this.backgroundWorkerProcessFlashFW = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerSetFlashRegionIDList = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerProgramSTMFlashFW = new System.ComponentModel.BackgroundWorker();
			this.labelupdaterstatus = new System.Windows.Forms.Label();
			this.timerexitbldetect = new System.Windows.Forms.Timer(this.components);
			this.progressBarupdate = new global::CustomProgressBar.CustomProgressBar();
			this.buttonUpdate = new CustomerFirmwareUpdater.MyButton();
			this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.labelHeader, "labelHeader");
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			this.labelpluginDevice.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelpluginDevice, "labelpluginDevice");
			this.labelpluginDevice.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelpluginDevice.Name = "labelpluginDevice";
			this.labelpluginDevice.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelpluginDevice.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			this.labelPromptMessage.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelPromptMessage, "labelPromptMessage");
			this.labelPromptMessage.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelPromptMessage.Name = "labelPromptMessage";
			this.labelPromptMessage.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelPromptMessage.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			this.labelUpdateprogress.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelUpdateprogress, "labelUpdateprogress");
			this.labelUpdateprogress.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelUpdateprogress.Name = "labelUpdateprogress";
			this.labelUpdateprogress.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelUpdateprogress.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			this.labelUpdateInfor.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelUpdateInfor, "labelUpdateInfor");
			this.labelUpdateInfor.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelUpdateInfor.Name = "labelUpdateInfor";
			this.labelUpdateInfor.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelUpdateInfor.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			componentResourceManager.ApplyResources(this.labeltargetver, "labeltargetver");
			this.labeltargetver.BackColor = System.Drawing.Color.Transparent;
			this.labeltargetver.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labeltargetver.Name = "labeltargetver";
			this.labeltargetver.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labeltargetver.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			componentResourceManager.ApplyResources(this.labelCurFWver, "labelCurFWver");
			this.labelCurFWver.BackColor = System.Drawing.Color.Transparent;
			this.labelCurFWver.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelCurFWver.Name = "labelCurFWver";
			this.labelCurFWver.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.labelCurFWver.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			this.backgroundWorkerProcessFWData.WorkerReportsProgress = true;
			this.backgroundWorkerProcessFWData.WorkerSupportsCancellation = true;
			this.backgroundWorkerProcessFWData.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerProcessFWData_DoWork);
			this.backgroundWorkerProcessFWData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerProcessFWData_ProgressChanged);
			this.backgroundWorkerProcessFWData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerProcessFWData_RunWorkerCompleted);
			this.backgroundWorkerCheckVer.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerCheckVer_DoWork);
			this.backgroundWorkerCheckVer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerCheckVer_RunWorkerCompleted);
			this.backgroundWorkerEraseFlash.WorkerReportsProgress = true;
			this.backgroundWorkerEraseFlash.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerEraseFlash_DoWork);
			this.backgroundWorkerEraseFlash.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerEraseFlash_ProgressChanged);
			this.backgroundWorkerEraseFlash.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerEraseFlash_RunWorkerCompleted);
			this.backgroundWorkerProgramFW.WorkerReportsProgress = true;
			this.backgroundWorkerProgramFW.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerProgramFW_DoWork);
			this.backgroundWorkerProgramFW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerProgramFW_ProgressChanged);
			this.backgroundWorkerProgramFW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerProgramFW_RunWorkerCompleted);
			this.backgroundWorkerVerify.WorkerReportsProgress = true;
			this.backgroundWorkerVerify.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerVerify_DoWork);
			this.backgroundWorkerVerify.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerVerify_ProgressChanged);
			this.backgroundWorkerVerify.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerVerify_RunWorkerCompleted);
			this.timerbllistener.Interval = 50000;
			this.timerbllistener.Tick += new System.EventHandler(timerbllistener_Tick);
			this.timerblentersuccess.Interval = 20000;
			this.timerblentersuccess.Tick += new System.EventHandler(timerblentersuccess_Tick);
			this.backgroundWorkerCloseRestartDialog.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerCloseRestartDialog_DoWork);
			this.backgroundWorkerCloseRestartDialog.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerCloseRestartDialog_RunWorkerCompleted);
			this.backgroundWorkercheckbattery.WorkerReportsProgress = true;
			this.backgroundWorkercheckbattery.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkercheckbattery_DoWork);
			this.backgroundWorkercheckbattery.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkercheckbattery_ProgressChanged);
			this.backgroundWorkercheckbattery.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkercheckbattery_RunWorkerCompleted);
			this.backgroundWorkerCheckFlashFWVer.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerCheckFlashFWVer_DoWork);
			this.backgroundWorkerCheckFlashFWVer.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerCheckFlashFWVer_RunWorkerCompleted);
			this.backgroundWorkerNordicENTERBL.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerNordicENTERBL_DoWork);
			this.backgroundWorkerNordicENTERBL.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerNordicENTERBL_RunWorkerCompleted);
			this.backgroundWorkerGetRegionInfor.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerGetRegionInfor_DoWork);
			this.backgroundWorkerGetRegionInfor.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerGetRegionInfor_RunWorkerCompleted);
			this.backgroundWorkerNordicProgram.WorkerReportsProgress = true;
			this.backgroundWorkerNordicProgram.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerNordicProgram_DoWork);
			this.backgroundWorkerNordicProgram.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerNordicProgram_ProgressChanged);
			this.backgroundWorkerNordicProgram.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerNordicProgram_RunWorkerCompleted);
			this.backgroundWorkerVerifyNordicFW.WorkerReportsProgress = true;
			this.backgroundWorkerVerifyNordicFW.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerVerifyNordicFW_DoWork);
			this.backgroundWorkerVerifyNordicFW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerVerifyNordicFW_RunWorkerCompleted);
			this.labelpressandholdpwrbtn.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelpressandholdpwrbtn, "labelpressandholdpwrbtn");
			this.labelpressandholdpwrbtn.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelpressandholdpwrbtn.Name = "labelpressandholdpwrbtn";
			this.labelkeepholdprompt.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelkeepholdprompt, "labelkeepholdprompt");
			this.labelkeepholdprompt.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelkeepholdprompt.Name = "labelkeepholdprompt";
			this.backgroundWorkerProcessFlashFW.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerProcessFlashFW_DoWork);
			this.backgroundWorkerProcessFlashFW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerProcessFlashFW_RunWorkerCompleted);
			this.backgroundWorkerSetFlashRegionIDList.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerSetFlashRegionIDList_DoWork);
			this.backgroundWorkerSetFlashRegionIDList.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerSetFlashRegionIDList_RunWorkerCompleted);
			this.backgroundWorkerProgramSTMFlashFW.WorkerReportsProgress = true;
			this.backgroundWorkerProgramSTMFlashFW.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerSetFlashRegionData_DoWork);
			this.backgroundWorkerProgramSTMFlashFW.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(backgroundWorkerProgramSTMFlashFW_ProgressChanged);
			this.backgroundWorkerProgramSTMFlashFW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerProgramSTMFlashFW_RunWorkerCompleted);
			this.labelupdaterstatus.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelupdaterstatus, "labelupdaterstatus");
			this.labelupdaterstatus.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.labelupdaterstatus.Name = "labelupdaterstatus";
			this.timerexitbldetect.Interval = 50000;
			this.timerexitbldetect.Tick += new System.EventHandler(timerexitbldetect_Tick);
			this.progressBarupdate.BackColor = System.Drawing.Color.Transparent;
			this.progressBarupdate.IsIndeterminate = false;
			componentResourceManager.ApplyResources(this.progressBarupdate, "progressBarupdate");
			this.progressBarupdate.Maximum = 100;
			this.progressBarupdate.Minimum = 0;
			this.progressBarupdate.Name = "progressBarupdate";
			this.progressBarupdate.ProgressBarBorderColor = System.Drawing.Color.Transparent;
			this.progressBarupdate.ProgressBarColor = System.Drawing.Color.FromArgb(68, 214, 44);
			this.progressBarupdate.ProgressFont = new System.Drawing.Font("Arial", 10f);
			this.progressBarupdate.Value = 0;
			this.progressBarupdate.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.progressBarupdate.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			componentResourceManager.ApplyResources(this.buttonUpdate, "buttonUpdate");
			this.buttonUpdate.BackColor = System.Drawing.Color.White;
			this.buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonUpdate.EnabledSet = true;
			this.buttonUpdate.FlatAppearance.BorderSize = 0;
			this.buttonUpdate.ForeColor = System.Drawing.Color.White;
			this.buttonUpdate.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.TabStop = false;
			this.buttonUpdate.UseVisualStyleBackColor = false;
			this.buttonUpdate.Click += new System.EventHandler(buttonUpdate_Click);
			this.buttonUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.buttonUpdate.MouseEnter += new System.EventHandler(buttonUpdate_MouseEnter);
			this.buttonUpdate.MouseLeave += new System.EventHandler(buttonUpdate_MouseLeave);
			this.buttonUpdate.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			componentResourceManager.ApplyResources(this.buttonCancel, "buttonCancel");
			this.buttonCancel.BackColor = System.Drawing.Color.White;
			this.buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
			this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonCancel.EnabledSet = true;
			this.buttonCancel.FlatAppearance.BorderSize = 0;
			this.buttonCancel.ForeColor = System.Drawing.Color.White;
			this.buttonCancel.ImageKey = CustomerFWU2Point5.Resources.ResourceStr.pantherapressbtn1;
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.TabStop = false;
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			this.buttonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			this.buttonCancel.MouseEnter += new System.EventHandler(buttonCancel_MouseEnter);
			this.buttonCancel.MouseLeave += new System.EventHandler(buttonCancel_MouseLeave);
			this.buttonCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.fwupdaterBackground;
			base.Controls.Add(this.labelupdaterstatus);
			base.Controls.Add(this.labelkeepholdprompt);
			base.Controls.Add(this.labelpressandholdpwrbtn);
			base.Controls.Add(this.labeltargetver);
			base.Controls.Add(this.labelCurFWver);
			base.Controls.Add(this.buttonUpdate);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.progressBarupdate);
			base.Controls.Add(this.labelPromptMessage);
			base.Controls.Add(this.labelUpdateprogress);
			base.Controls.Add(this.labelUpdateInfor);
			base.Controls.Add(this.labelpluginDevice);
			base.Controls.Add(this.labelHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.Name = "FormFWUStep1";
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(FormFWUStep1_FormClosed);
			base.Load += new System.EventHandler(FormFWUStep1_Load);
			base.Shown += new System.EventHandler(FormFWUStep1_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(labelpluginDevice_MouseMove);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
