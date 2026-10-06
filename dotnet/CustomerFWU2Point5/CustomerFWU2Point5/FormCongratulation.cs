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
	public class FormCongratulation : Form
	{
		private Point lastPoint = Point.Empty;

		private IContainer components;

		private Label labelHeader;

		private Label labelDevFWver;

		private Label label1;

		private Label labelCongratulation;

		private MyButton buttonClose;

		public FormCongratulation()
		{
			InitializeComponent();
		}

		private void FormCongratulation_Load(object sender, EventArgs e)
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			if (Common.background != null)
			{
				BackgroundImage = Common.background;
			}
			else
			{
				switch (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex))
				{
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
					string productNo = Common.GetProductNo();
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
					string productNo = Common.GetProductNo();
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
					BackgroundImage = CustomerFWU2Point5.Properties.Resources._17BladeDanaFHD;
					break;
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
				case "0255":
				{
					string productNo = Common.GetProductNo();
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
				case "0253":
				{
					string productNo = Common.GetProductNo();
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
				case "0256":
				{
					string productNo = Common.GetProductNo();
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
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Book13Margaret;
					break;
				case "0270":
					BackgroundImage = CustomerFWU2Point5.Properties.Resources.Blade14Piper;
					break;
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
			buttonClose.ForeColor = Common.btnfontcolor;
			buttonClose.Text = ResourceStr.close;
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			if (Common.IsBladeKB())
			{
				labelCongratulation.Text = ResourceStr.updatesuccessful;
				label1.Text = ResourceStr.bladekbupdatetonewest;
			}
			else
			{
				if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "007E")
				{
					labelCongratulation.Text = ResourceStr.updatesuccessful;
				}
				else
				{
					labelCongratulation.Text = ResourceStr.congratulations;
				}
				label1.Text = ResourceStr.devicewithnewver;
			}
			if (Common.fordummy)
			{
				labelHeader.Text = string.Format(ResourceStr.Title, Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper() + " (DUMMY)");
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
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			else
			{
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			Text = labelHeader.Text;
			labelDevFWver.ForeColor = Common.lightgray;
			if (Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0401" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A00" || Common.updateInfo.GetPID(Common.updateInfo.CurDevIndex) == "0A14")
			{
				labelDevFWver.Text = ResourceStr.devicever + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
			}
			else
			{
				labelDevFWver.Text = ResourceStr.devicever + Common.updateInfo.ActDevFWVer;
			}
			labelHeader.ForeColor = Common.greendarktheme;
			label1.ForeColor = Common.greendarktheme;
			labelCongratulation.ForeColor = Common.greendarktheme;
		}

		private void buttonClose_MouseEnter(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonClose_MouseLeave(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_click;
			Common.NextPage = PageIndex.Close;
			Close();
		}

		private void labelDevFWver_MouseDown(object sender, MouseEventArgs e)
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

		private void labelDevFWver_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void FormCongratulation_Shown(object sender, EventArgs e)
		{
			Common.IsExiting = true;
			float num = (float)base.Width / 730f;
			while ((float)labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				labelHeader.Font = new Font(labelHeader.Font.FontFamily, labelHeader.Font.Size - 1f);
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
			System.ComponentModel.ComponentResourceManager componentResourceManager = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.FormCongratulation));
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelDevFWver = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelCongratulation = new System.Windows.Forms.Label();
			this.buttonClose = new CustomerFirmwareUpdater.MyButton();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.labelHeader, "labelHeader");
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			componentResourceManager.ApplyResources(this.labelDevFWver, "labelDevFWver");
			this.labelDevFWver.BackColor = System.Drawing.Color.Transparent;
			this.labelDevFWver.Name = "labelDevFWver";
			this.labelDevFWver.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			this.labelDevFWver.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			this.label1.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			this.label1.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			this.label1.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			this.labelCongratulation.BackColor = System.Drawing.Color.Transparent;
			componentResourceManager.ApplyResources(this.labelCongratulation, "labelCongratulation");
			this.labelCongratulation.Name = "labelCongratulation";
			this.labelCongratulation.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			this.labelCongratulation.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			componentResourceManager.ApplyResources(this.buttonClose, "buttonClose");
			this.buttonClose.BackColor = System.Drawing.Color.White;
			this.buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			this.buttonClose.EnabledSet = true;
			this.buttonClose.FlatAppearance.BorderSize = 0;
			this.buttonClose.ForeColor = System.Drawing.Color.White;
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.TabStop = false;
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
			this.buttonClose.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			this.buttonClose.MouseEnter += new System.EventHandler(buttonClose_MouseEnter);
			this.buttonClose.MouseLeave += new System.EventHandler(buttonClose_MouseLeave);
			this.buttonClose.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.blank;
			base.Controls.Add(this.labelDevFWver);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.labelCongratulation);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.labelHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.MaximizeBox = false;
			base.Name = "FormCongratulation";
			base.Load += new System.EventHandler(FormCongratulation_Load);
			base.Shown += new System.EventHandler(FormCongratulation_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(labelDevFWver_MouseMove);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
