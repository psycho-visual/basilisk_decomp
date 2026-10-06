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
	public class ShowModelNo : Form
	{
		private Point lastPoint = Point.Empty;

		private IContainer components;

		private Label labelHeader;

		private MyButton buttonBack;

		private Label labelguidemessage;

		public ShowModelNo()
		{
			InitializeComponent();
		}

		private void ShowModelNo_Load(object sender, EventArgs e)
		{
			DoubleBuffered = true;
			SetStyle(ControlStyles.UserPaint, value: true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, value: true);
			SetStyle(ControlStyles.DoubleBuffer, value: true);
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
			labelguidemessage.ForeColor = Color.White;
			labelguidemessage.Text = string.Format(ResourceStr.foundmodelnohere, Common.updateInfo.GetModelNumber(Common.updateInfo.GetPID(1)));
			buttonBack.Text = ResourceStr.back;
			buttonBack.ForeColor = Common.btnfontcolor;
		}

		private void buttonBack_Click(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.FormGuide;
			Close();
		}

		private void ShowModelNo_MouseDown(object sender, MouseEventArgs e)
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

		private void ShowModelNo_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void ShowModelNo_Shown(object sender, EventArgs e)
		{
			Common.NextPage = PageIndex.Close;
			float num = (float)base.Width / 730f;
			while ((float)labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				labelHeader.Font = new Font(labelHeader.Font.FontFamily, labelHeader.Font.Size - 1f);
			}
			buttonBack.Location = new Point(base.Size.Width - buttonBack.Width - 40, base.Size.Height - buttonBack.Height - Common.hspacebtnbottom);
		}

		private void buttonBack_MouseEnter(object sender, EventArgs e)
		{
			buttonBack.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonBack_MouseLeave(object sender, EventArgs e)
		{
			buttonBack.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.ShowModelNo));
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelguidemessage = new System.Windows.Forms.Label();
			this.buttonBack = new CustomerFirmwareUpdater.MyButton();
			base.SuspendLayout();
			this.labelHeader.AutoSize = true;
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
			this.labelHeader.ImageKey = "(none)";
			this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelHeader.Location = new System.Drawing.Point(35, 32);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(368, 22);
			this.labelHeader.TabIndex = 3;
			this.labelHeader.Text = "RAZER MANO'WAR FIRMWARE UPDATER";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseMove);
			this.labelguidemessage.BackColor = System.Drawing.Color.Transparent;
			this.labelguidemessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelguidemessage.ForeColor = System.Drawing.Color.White;
			this.labelguidemessage.ImageKey = "(none)";
			this.labelguidemessage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelguidemessage.Location = new System.Drawing.Point(45, 80);
			this.labelguidemessage.Name = "labelguidemessage";
			this.labelguidemessage.Size = new System.Drawing.Size(638, 36);
			this.labelguidemessage.TabIndex = 30;
			this.labelguidemessage.Text = "Your product's model number  (e.g. RZ09-0196) can usually be found here:";
			this.labelguidemessage.MouseDown += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseDown);
			this.labelguidemessage.MouseMove += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseMove);
			this.buttonBack.AutoSize = true;
			this.buttonBack.BackColor = System.Drawing.Color.White;
			this.buttonBack.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
			this.buttonBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonBack.Cursor = System.Windows.Forms.Cursors.Default;
			this.buttonBack.EnabledSet = true;
			this.buttonBack.FlatAppearance.BorderSize = 0;
			this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonBack.ForeColor = System.Drawing.Color.White;
			this.buttonBack.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonBack.Location = new System.Drawing.Point(603, 514);
			this.buttonBack.Margin = new System.Windows.Forms.Padding(0);
			this.buttonBack.Name = "buttonBack";
			this.buttonBack.Size = new System.Drawing.Size(90, 28);
			this.buttonBack.TabIndex = 29;
			this.buttonBack.TabStop = false;
			this.buttonBack.Text = "BACK";
			this.buttonBack.UseVisualStyleBackColor = false;
			this.buttonBack.Click += new System.EventHandler(buttonBack_Click);
			this.buttonBack.MouseEnter += new System.EventHandler(buttonBack_MouseEnter);
			this.buttonBack.MouseLeave += new System.EventHandler(buttonBack_MouseLeave);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.version_check;
			base.ClientSize = new System.Drawing.Size(730, 574);
			base.Controls.Add(this.labelguidemessage);
			base.Controls.Add(this.buttonBack);
			base.Controls.Add(this.labelHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "ShowModelNo";
			this.Text = "ShowModelNo";
			base.Load += new System.EventHandler(ShowModelNo_Load);
			base.Shown += new System.EventHandler(ShowModelNo_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(ShowModelNo_MouseMove);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
