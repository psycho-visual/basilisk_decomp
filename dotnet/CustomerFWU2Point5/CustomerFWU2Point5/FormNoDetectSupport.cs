using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CustomerFWU2Point5.Properties;
using CustomerFWU2Point5.Resources;
using CustomerFirmwareUpdater;

namespace CustomerFWU2Point5
{
	public class FormNoDetectSupport : Form
	{
		private IContainer components;

		private Label labeltryagain;

		private Label labelnodetect;

		private LinkLabel linkLabelSupport;

		private MyButton buttonClose;

		private Label labelHeader;

		public FormNoDetectSupport()
		{
			InitializeComponent();
		}

		private void FormNoDetectSupport_Load(object sender, EventArgs e)
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
			int num = 0;
			num = ((Common.updateInfo.CurDevIndex < 0) ? 1 : Common.updateInfo.CurDevIndex);
			switch (Common.updateInfo.GetPID(num))
			{
			case "0220":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.firmware_hazel2_notdetected;
				break;
			case "020F":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_14_r5_betty_not_detected;
				break;
			case "0401":
				BackgroundImage = CustomerFWU2Point5.Properties.Resources.panthera_notdetected;
				break;
			}
			labelnodetect.Text = ResourceStr.nodevdetect;
			labelnodetect.ForeColor = Common.greendarktheme;
			labeltryagain.Text = ResourceStr.tryagain;
			labeltryagain.ForeColor = Color.Red;
			linkLabelSupport.Text = ResourceStr.support;
			linkLabelSupport.ForeColor = Color.Red;
			linkLabelSupport.LinkArea = new LinkArea(ResourceStr.support.IndexOf("support"), "support@razerzone.com".Length);
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
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex));
			}
			else
			{
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			labelHeader.ForeColor = Common.greendarktheme;
			Text = labelHeader.Text;
		}

		private void buttonClose_Click(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_click;
			Application.Exit();
		}

		private void buttonClose_MouseEnter(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonClose_MouseLeave(object sender, EventArgs e)
		{
			buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void labelnodetect_Click(object sender, EventArgs e)
		{
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.FormNoDetectSupport));
			this.labeltryagain = new System.Windows.Forms.Label();
			this.labelnodetect = new System.Windows.Forms.Label();
			this.linkLabelSupport = new System.Windows.Forms.LinkLabel();
			this.labelHeader = new System.Windows.Forms.Label();
			this.buttonClose = new CustomerFirmwareUpdater.MyButton();
			base.SuspendLayout();
			this.labeltryagain.BackColor = System.Drawing.Color.Transparent;
			this.labeltryagain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.labeltryagain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labeltryagain.Location = new System.Drawing.Point(0, 414);
			this.labeltryagain.Name = "labeltryagain";
			this.labeltryagain.Size = new System.Drawing.Size(730, 30);
			this.labeltryagain.TabIndex = 17;
			this.labeltryagain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelnodetect.BackColor = System.Drawing.Color.Transparent;
			this.labelnodetect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.labelnodetect.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelnodetect.Location = new System.Drawing.Point(0, 384);
			this.labelnodetect.Name = "labelnodetect";
			this.labelnodetect.Size = new System.Drawing.Size(730, 30);
			this.labelnodetect.TabIndex = 16;
			this.labelnodetect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelnodetect.Click += new System.EventHandler(labelnodetect_Click);
			this.linkLabelSupport.BackColor = System.Drawing.Color.Transparent;
			this.linkLabelSupport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.linkLabelSupport.LinkColor = System.Drawing.Color.Red;
			this.linkLabelSupport.Location = new System.Drawing.Point(0, 444);
			this.linkLabelSupport.Name = "linkLabelSupport";
			this.linkLabelSupport.Size = new System.Drawing.Size(730, 30);
			this.linkLabelSupport.TabIndex = 18;
			this.linkLabelSupport.TabStop = true;
			this.linkLabelSupport.Text = "linkLabel1";
			this.linkLabelSupport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.labelHeader.AutoSize = true;
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
			this.labelHeader.ImageKey = "(none)";
			this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelHeader.Location = new System.Drawing.Point(35, 32);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(368, 22);
			this.labelHeader.TabIndex = 21;
			this.labelHeader.Text = "RAZER MANO'WAR FIRMWARE UPDATER";
			this.buttonClose.AutoSize = true;
			this.buttonClose.BackColor = System.Drawing.Color.White;
			this.buttonClose.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.buttonClose.EnabledSet = true;
			this.buttonClose.FlatAppearance.BorderSize = 0;
			this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonClose.ForeColor = System.Drawing.Color.White;
			this.buttonClose.Location = new System.Drawing.Point(588, 513);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(90, 28);
			this.buttonClose.TabIndex = 20;
			this.buttonClose.TabStop = false;
			this.buttonClose.Text = "CLOSE";
			this.buttonClose.UseVisualStyleBackColor = false;
			this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
			this.buttonClose.MouseEnter += new System.EventHandler(buttonClose_MouseEnter);
			this.buttonClose.MouseLeave += new System.EventHandler(buttonClose_MouseLeave);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.blade_14_r5_betty_not_detected;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(730, 574);
			base.Controls.Add(this.labelHeader);
			base.Controls.Add(this.buttonClose);
			base.Controls.Add(this.linkLabelSupport);
			base.Controls.Add(this.labeltryagain);
			base.Controls.Add(this.labelnodetect);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormNoDetectSupport";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FormNoDetectSupport";
			base.Load += new System.EventHandler(FormNoDetectSupport_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
