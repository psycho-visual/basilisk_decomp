using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CustomerFWU2Point5.Properties;
using CustomerFWU2Point5.Resources;
using CustomerFirmwareUpdater;

namespace CustomerFWU2Point5
{
	public class FormGuide : Form
	{
		private Point lastPoint = Point.Empty;

		private DeviceInterface device;

		private IContainer components;

		private Label labelHeader;

		private MyButton buttonNext;

		private MyButton buttonCancel;

		private Label labelguidemessage;

		private LinkLabel linkcheckmodelno;

		private Label labelrecommandmessage;

		private BackgroundWorker backgroundWorkerCloseRazerApps;

		public FormGuide(DeviceInterface device)
		{
			InitializeComponent();
			this.device = device;
		}

		private void FormGuide_Load(object sender, EventArgs e)
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			if (Common.IsBladeKB())
			{
				linkcheckmodelno.Visible = true;
				labelrecommandmessage.Visible = false;
				linkcheckmodelno.Text = ResourceStr.showmodelno;
			}
			else
			{
				linkcheckmodelno.Visible = false;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				labelrecommandmessage.Text = ResourceStr.shutdownrazerapps;
			}
			if (Common.fordummy)
			{
				labelHeader.Text = string.Format(ResourceStr.Title, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper() + " (DUMMY)");
			}
			else if (Common.IsBladeKB())
			{
				if (Common.updateInfo.GetPID(1) == "0253" || Common.updateInfo.GetPID(1) == "0255" || Common.updateInfo.GetPID(1) == "0256")
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
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			else
			{
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			labelHeader.ForeColor = Common.greendarktheme;
			Text = labelHeader.Text;
			labelguidemessage.ForeColor = Color.White;
			buttonCancel.Text = ResourceStr.cancel;
			buttonNext.Text = ResourceStr.next;
			buttonCancel.ForeColor = Common.btnfontcolor;
			buttonNext.ForeColor = Common.btnfontcolor;
			if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
			{
				labelguidemessage.Text = string.Format(ResourceStr.guidemessage, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex));
			}
			else
			{
				labelguidemessage.Text = string.Format(ResourceStr.guidemessage, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex));
			}
			if (Common.background != null)
			{
				BackgroundImage = Common.background;
				return;
			}
			switch (Common.updateInfo.GetPID(1))
			{
			case "003F":
				break;
			case "0043":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.firmwareupdater_DAChroma;
				break;
			case "003E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.naga_epic_chroma_mouse;
				break;
			case "0220":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.firmware_hazel2;
				break;
			case "020F":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_14_r5_betty;
				break;
			case "023B":
			case "0240":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.bladekbupdateend;
				break;
			case "1000":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.raiju;
				break;
			case "0046":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.mambaTE;
				break;
			case "0401":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.panthera;
				break;
			case "0214":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.BWUlt2016_firware;
				break;
			case "005C":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.DA_Elite_drk;
				break;
			case "020E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.cynosa_dark;
				break;
			case "020D":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.cynosa_pro_dark;
				break;
			case "0221":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.BW_ChromaV2_dark;
				break;
			case "0209":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.BW_TEChroma_dark;
				break;
			case "0060":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.lancehead_Sophia;
				break;
			case "0A00":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.atrox_cong;
				break;
			case "0059":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.lancehead_Jill;
				break;
			case "005A":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.lancehead_Jill_mousedock;
				break;
			case "0037":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.deathadder2013;
				break;
			case "0064":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.basilisk;
				break;
			case "0A14":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.wolverine;
				break;
			case "0067":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.nagatrinity;
				break;
			case "0517":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.nommo_drk;
				break;
			case "0068":
			case "0069":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.hyperflux_firefly;
				break;
			case "0226":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.huntsman_elite_dark;
				break;
			case "0227":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.hunstman_dark;
				break;
			case "006E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.DA_Essential;
				break;
			case "0C01":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blank;
				break;
			case "0C02":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blank;
				break;
			case "006C":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.mambaelite;
				break;
			case "1007":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.RaijuTE_drk;
				break;
			case "1004":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Raiju_Patricia_T1;
				break;
			case "0705":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Claire_T1_Raiju_Mobile;
				break;
			case "0241":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.janet_t2;
				break;
			case "0065":
				if (Common.newedition)
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.basilisk_piper_lc;
				}
				else
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.basilisk_essential;
				}
				break;
			case "0245":
			{
				labelguidemessage.Text = ResourceStr.blade15mid2019message;
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.Text = ResourceStr.showmodelno;
				linkcheckmodelno.LinkColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == "RZ09-0301")
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_15_adv_c3_FHD;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '0':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_15_adv_c3_FHD;
					break;
				case 'M':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_15_adv_c3_FHD_merc;
					break;
				case '5':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_15_adv_c3_UHD_Touch;
					break;
				}
				break;
			}
			case "0243":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.huntsmanTE;
				break;
			case "0078":
			case "0091":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.viper;
				break;
			case "007E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.mousedock;
				break;
			case "023A":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade15c2message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("023A"));
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade15c2message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("023A"));
				}
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.Text = ResourceStr.showmodelno;
				linkcheckmodelno.LinkColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == "RZ09-0288")
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_15_charlotte2;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '9':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.c2FHD;
					break;
				case 'M':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.c2Merc;
					break;
				case '5':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.c2Touch;
					break;
				}
				break;
			}
			case "0234":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade15c2message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0234"));
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade15c2message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0234"));
				}
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.Text = ResourceStr.showmodelno;
				linkcheckmodelno.LinkColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == "RZ09-0287")
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources._17BladeDanaFHD;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '9':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources._17BladeDanaFHD;
					break;
				case '5':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources._17BladeDana4K;
					break;
				}
				break;
			}
			case "0C00":
				if (Common.devedition == 0)
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Firefly_Hard_2016;
				}
				else
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Firefly_Cloth_2016;
				}
				break;
			case "0085":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.basilisk_v2;
				break;
			case "0084":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.DA_V2;
				break;
			case "008A":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.vipermini;
				break;
			case "008C":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.deathadderv2mini;
				break;
			case "025D":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.ornata_carolinev2;
				break;
			case "0A24":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.bwjanet3v2chroma;
				break;
			case "0257":
				if (Common.devedition == 128 || Common.devedition == 130)
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.mayaminiUSMercury;
				}
				else
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.mayaminiUS;
				}
				break;
			case "0269":
				if (Common.devedition == 128 || Common.devedition == 130)
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.mayaminiJPMercury;
				}
				else
				{
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.mayaminiJP;
				}
				break;
			case "0253":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0253"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade 雷蛇灵刃");
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0253"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade");
				}
				labelguidemessage.Location = new Point(labelguidemessage.Location.X, labelguidemessage.Location.Y - 55);
				linkcheckmodelno.Location = new Point(linkcheckmodelno.Location.X, linkcheckmodelno.Location.Y - 55);
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.LinkColor = Color.White;
				labelrecommandmessage.Location = new Point(labelrecommandmessage.Location.X, labelrecommandmessage.Location.Y + 10);
				labelrecommandmessage.Text = ResourceStr.welcomenote + "\r\n●    " + ResourceStr.shutdownrazerapps + "\r\n●    " + ResourceStr.plugpoweroutletnote;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == Common.updateInfo.GetModelNumber("0253"))
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Charlotte5_Black_FHD;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '4':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Charlotte5_Black_FHD;
					break;
				case 'M':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Charlotte5_Mercury;
					break;
				case '5':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Charlotte5_Black_UHD;
					break;
				}
				break;
			}
			case "0255":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0255"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade 雷蛇灵刃");
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0255"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade");
				}
				labelguidemessage.Location = new Point(labelguidemessage.Location.X, labelguidemessage.Location.Y - 55);
				linkcheckmodelno.Location = new Point(linkcheckmodelno.Location.X, linkcheckmodelno.Location.Y - 55);
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.LinkColor = Color.White;
				labelrecommandmessage.Location = new Point(labelrecommandmessage.Location.X, labelrecommandmessage.Location.Y + 10);
				labelrecommandmessage.Text = ResourceStr.welcomenote + "\r\n●    " + ResourceStr.shutdownrazerapps + "\r\n●    " + ResourceStr.plugpoweroutletnote;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == Common.updateInfo.GetModelNumber("0255"))
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana5_Black;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '2':
				case 'Q':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana5_Black_FHD;
					break;
				case '7':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana5_Black_UHD;
					break;
				case 'M':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana5_Mercury;
					break;
				}
				break;
			}
			case "0256":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0256"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade 雷蛇灵刃");
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0256"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade");
				}
				labelguidemessage.Location = new Point(labelguidemessage.Location.X, labelguidemessage.Location.Y - 55);
				linkcheckmodelno.Location = new Point(linkcheckmodelno.Location.X, linkcheckmodelno.Location.Y - 55);
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.LinkColor = Color.White;
				labelrecommandmessage.Location = new Point(labelrecommandmessage.Location.X, labelrecommandmessage.Location.Y + 10);
				labelrecommandmessage.Text = ResourceStr.welcomenote + "\r\n●    " + ResourceStr.shutdownrazerapps + "\r\n●    " + ResourceStr.plugpoweroutletnote;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == Common.updateInfo.GetModelNumber("0256"))
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana17_5;
				switch (productNo.ElementAt(productNo.Length - 2))
				{
				case '4':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana17_5_FHD;
					break;
				case '6':
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Warranty_Dana17_5_UHD;
					break;
				}
				break;
			}
			case "0F20":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.LucyV2;
				break;
			case "0266":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.huntsmanV2Analog;
				break;
			case "0F12":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.raptor27;
				break;
			case "0F28":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.raptor272021;
				break;
			case "026A":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("026A"));
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("026A"));
				}
				labelguidemessage.Location = new Point(labelguidemessage.Location.X, labelguidemessage.Location.Y - 55);
				linkcheckmodelno.Location = new Point(linkcheckmodelno.Location.X, linkcheckmodelno.Location.Y - 55);
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Book");
				linkcheckmodelno.LinkColor = Color.White;
				labelrecommandmessage.Location = new Point(labelrecommandmessage.Location.X, labelrecommandmessage.Location.Y + 10);
				labelrecommandmessage.Text = ResourceStr.welcomenote + "\r\n●    " + ResourceStr.shutdownrazerapps + "\r\n●    " + ResourceStr.plugpoweroutletnote;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == Common.updateInfo.GetModelNumber("026A"))
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Book13Margaret;
				break;
			}
			case "0270":
			{
				if (Thread.CurrentThread.CurrentUICulture.Name == "zh-CN")
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0270"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade 雷蛇灵刃");
				}
				else
				{
					labelguidemessage.Text = string.Format(ResourceStr.blade2020message, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex), Common.updateInfo.GetModelNumber("0270"));
					linkcheckmodelno.Text = string.Format(ResourceStr.showmodelnoblade, "Blade");
				}
				labelguidemessage.Location = new Point(labelguidemessage.Location.X, labelguidemessage.Location.Y - 55);
				linkcheckmodelno.Location = new Point(linkcheckmodelno.Location.X, linkcheckmodelno.Location.Y - 55);
				linkcheckmodelno.Visible = true;
				linkcheckmodelno.LinkColor = Color.White;
				labelrecommandmessage.Location = new Point(labelrecommandmessage.Location.X, labelrecommandmessage.Location.Y + 10);
				labelrecommandmessage.Text = ResourceStr.welcomenote + "\r\n●    " + ResourceStr.shutdownrazerapps + "\r\n●    " + ResourceStr.plugpoweroutletnote;
				labelrecommandmessage.Visible = true;
				labelrecommandmessage.ForeColor = Color.White;
				string productNo = Common.GetProductNo();
				if (productNo.Substring(0, 9) == Common.updateInfo.GetModelNumber("0270"))
				{
					buttonNext.Enabled = true;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
				}
				else
				{
					buttonNext.Enabled = false;
					buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
				}
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Blade14Piper;
				break;
			}
			case "0C05":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.striderchroma;
				break;
			case "0C06":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.goliathuschroma;
				break;
			case "024E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.BW_V3;
				break;
			case "00B2":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.DeathAdder_V3;
				break;
			case "028F":
			case "02A1":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.OrnataV3;
				break;
			case "0294":
			case "02A2":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.OrnataV3X;
				break;
			case "0F3C":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.pwmfancontroller_fw;
				break;
			case "0099":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Basilisk_V3;
				break;
			case "00A4":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Zia;
				break;
			case "0F3E":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.Sneki;
				break;
			}
		}

		private void FormGuide_Shown(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			float num = (float)base.Width / 730f;
			while ((float)labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				labelHeader.Font = new Font(labelHeader.Font.FontFamily, labelHeader.Font.Size - 1f);
			}
			buttonNext.Location = new Point(base.Size.Width - buttonNext.Width - 40, base.Size.Height - buttonNext.Height - Common.hspacebtnbottom);
			buttonCancel.Location = new Point(buttonNext.Location.X - Common.wspacebutton - buttonCancel.Width, buttonNext.Location.Y);
		}

		private void buttonCancel_MouseEnter(object sender, EventArgs e)
		{
			Cursor = Cursors.Hand;
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_hover;
		}

		private void buttonCancel_MouseLeave(object sender, EventArgs e)
		{
			Cursor = Cursors.Arrow;
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_clicked;
			Common.NextPage = PageIndex.Close;
			Close();
		}

		private void buttonNext_MouseEnter(object sender, EventArgs e)
		{
			Cursor = Cursors.Hand;
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonNext_MouseLeave(object sender, EventArgs e)
		{
			Cursor = Cursors.Arrow;
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			if (!backgroundWorkerCloseRazerApps.IsBusy)
			{
				backgroundWorkerCloseRazerApps.RunWorkerAsync();
			}
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			buttonNext.Enabled = false;
		}

		private void FormGuider_MouseDown(object sender, MouseEventArgs e)
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

		private void FormGuider_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void linkcheckmodelno_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Common.NextPage = PageIndex.ShowModelNo;
			Close();
		}

		private void backgroundWorkerCloseRazerApps_DoWork(object sender, DoWorkEventArgs e)
		{
			device.StopSvc("RzActionSvc");
			device.StopSvc("Razer Chroma SDK Server");
			device.StopSvc("Razer Chroma SDK Service");
			device.StopSvc("Razer Game Manager Service");
			device.StopSvc("Razer Synapse Service");
		}

		private void backgroundWorkerCloseRazerApps_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Common.NextPage = PageIndex.FormFWUStep1;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.FormGuide));
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelguidemessage = new System.Windows.Forms.Label();
			this.linkcheckmodelno = new System.Windows.Forms.LinkLabel();
			this.labelrecommandmessage = new System.Windows.Forms.Label();
			this.buttonNext = new CustomerFirmwareUpdater.MyButton();
			this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
			this.backgroundWorkerCloseRazerApps = new System.ComponentModel.BackgroundWorker();
			base.SuspendLayout();
			this.labelHeader.AutoSize = true;
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
			this.labelHeader.ImageKey = "(none)";
			this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelHeader.Location = new System.Drawing.Point(35, 32);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(368, 22);
			this.labelHeader.TabIndex = 2;
			this.labelHeader.Text = "RAZER MANO'WAR FIRMWARE UPDATER";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseMove);
			this.labelguidemessage.BackColor = System.Drawing.Color.Transparent;
			this.labelguidemessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelguidemessage.ForeColor = System.Drawing.Color.White;
			this.labelguidemessage.ImageKey = "(none)";
			this.labelguidemessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelguidemessage.Location = new System.Drawing.Point(37, 388);
			this.labelguidemessage.Name = "labelguidemessage";
			this.labelguidemessage.Size = new System.Drawing.Size(638, 36);
			this.labelguidemessage.TabIndex = 26;
			this.labelguidemessage.Text = "This utility will pair your Razer Lancehead Wireless mouse with the wireless USB dongle.";
			this.labelguidemessage.MouseDown += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseDown);
			this.labelguidemessage.MouseMove += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseMove);
			this.linkcheckmodelno.ActiveLinkColor = System.Drawing.Color.Gray;
			this.linkcheckmodelno.AutoSize = true;
			this.linkcheckmodelno.BackColor = System.Drawing.Color.Transparent;
			this.linkcheckmodelno.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.linkcheckmodelno.LinkColor = System.Drawing.Color.White;
			this.linkcheckmodelno.Location = new System.Drawing.Point(37, 455);
			this.linkcheckmodelno.Margin = new System.Windows.Forms.Padding(0);
			this.linkcheckmodelno.Name = "linkcheckmodelno";
			this.linkcheckmodelno.Size = new System.Drawing.Size(73, 18);
			this.linkcheckmodelno.TabIndex = 29;
			this.linkcheckmodelno.TabStop = true;
			this.linkcheckmodelno.Text = "linkLabel1";
			this.linkcheckmodelno.Visible = false;
			this.linkcheckmodelno.VisitedLinkColor = System.Drawing.Color.LimeGreen;
			this.linkcheckmodelno.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkcheckmodelno_LinkClicked);
			this.labelrecommandmessage.BackColor = System.Drawing.Color.Transparent;
			this.labelrecommandmessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelrecommandmessage.ImageKey = "(none)";
			this.labelrecommandmessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelrecommandmessage.Location = new System.Drawing.Point(39, 437);
			this.labelrecommandmessage.Name = "labelrecommandmessage";
			this.labelrecommandmessage.Size = new System.Drawing.Size(666, 60);
			this.labelrecommandmessage.TabIndex = 30;
			this.buttonNext.AutoSize = true;
			this.buttonNext.BackColor = System.Drawing.Color.White;
			this.buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonNext.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonNext.EnabledSet = true;
			this.buttonNext.FlatAppearance.BorderSize = 0;
			this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonNext.ForeColor = System.Drawing.Color.White;
			this.buttonNext.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonNext.Location = new System.Drawing.Point(605, 511);
			this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(90, 28);
			this.buttonNext.TabIndex = 28;
			this.buttonNext.TabStop = false;
			this.buttonNext.Text = "NEXT";
			this.buttonNext.UseVisualStyleBackColor = false;
			this.buttonNext.Click += new System.EventHandler(buttonNext_Click);
			this.buttonNext.MouseEnter += new System.EventHandler(buttonNext_MouseEnter);
			this.buttonNext.MouseLeave += new System.EventHandler(buttonNext_MouseLeave);
			this.buttonCancel.AutoSize = true;
			this.buttonCancel.BackColor = System.Drawing.Color.White;
			this.buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
			this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonCancel.EnabledSet = true;
			this.buttonCancel.FlatAppearance.BorderSize = 0;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonCancel.ForeColor = System.Drawing.Color.White;
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(492, 511);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(90, 28);
			this.buttonCancel.TabIndex = 27;
			this.buttonCancel.TabStop = false;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			this.buttonCancel.MouseEnter += new System.EventHandler(buttonCancel_MouseEnter);
			this.buttonCancel.MouseLeave += new System.EventHandler(buttonCancel_MouseLeave);
			this.backgroundWorkerCloseRazerApps.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerCloseRazerApps_DoWork);
			this.backgroundWorkerCloseRazerApps.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerCloseRazerApps_RunWorkerCompleted);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.blank;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(730, 574);
			base.Controls.Add(this.labelrecommandmessage);
			base.Controls.Add(this.linkcheckmodelno);
			base.Controls.Add(this.buttonNext);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.labelguidemessage);
			base.Controls.Add(this.labelHeader);
			this.DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormGuide";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			base.Load += new System.EventHandler(FormGuide_Load);
			base.Shown += new System.EventHandler(FormGuide_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(FormGuider_MouseMove);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
