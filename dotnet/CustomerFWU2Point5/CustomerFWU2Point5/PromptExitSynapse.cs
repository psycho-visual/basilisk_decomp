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
	public class PromptExitSynapse : Form
	{
		private Point lastPoint = Point.Empty;

		private IContainer components;

		private MyButton buttonNext;

		private MyButton buttonCancel;

		private Label labellaptoppower;

		private Label labelexitsynapse;

		private Label labelreminder;

		private Label labelHeader;

		public PromptExitSynapse()
		{
			InitializeComponent();
		}

		private void PromptExitSynapse_Load(object sender, EventArgs e)
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
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetDeviceName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			else
			{
				labelHeader.Text = string.Format(ResourceStr.Title.ToUpper(), Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex).ToUpper());
			}
			labelHeader.ForeColor = Common.greendarktheme;
			Text = labelHeader.Text;
			labelreminder.ForeColor = Color.White;
			labellaptoppower.ForeColor = Color.White;
			labelexitsynapse.ForeColor = Color.White;
			buttonCancel.Text = ResourceStr.cancel;
			buttonNext.Text = ResourceStr.next;
			buttonCancel.ForeColor = Common.btnfontcolor;
			buttonNext.ForeColor = Common.btnfontcolor;
			labelexitsynapse.Text = ResourceStr.exitsynapse;
			labelreminder.Text = ResourceStr.reminder;
			if (Common.IsBladeKB())
			{
				labellaptoppower.Text = ResourceStr.connectpoweroutlet;
			}
			else
			{
				labellaptoppower.Text = ResourceStr.laptoppower;
			}
		}

		private void buttonCancel_MouseEnter(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_hover;
		}

		private void buttonCancel_MouseLeave(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
		}

		private void buttonNext_MouseEnter(object sender, EventArgs e)
		{
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonNext_MouseLeave(object sender, EventArgs e)
		{
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_clicked;
			Common.NextPage = PageIndex.Close;
			Close();
		}

		private void buttonNext_Click(object sender, EventArgs e)
		{
			buttonNext.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_click;
			Common.NextPage = PageIndex.FormFWUStep1;
			Close();
		}

		private void PromptExitSynapse_MouseDown(object sender, MouseEventArgs e)
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

		private void PromptExitSynapse_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void PromptExitSynapse_Shown(object sender, EventArgs e)
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.PromptExitSynapse));
			this.buttonNext = new CustomerFirmwareUpdater.MyButton();
			this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
			this.labellaptoppower = new System.Windows.Forms.Label();
			this.labelexitsynapse = new System.Windows.Forms.Label();
			this.labelreminder = new System.Windows.Forms.Label();
			this.labelHeader = new System.Windows.Forms.Label();
			base.SuspendLayout();
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
			this.buttonNext.Location = new System.Drawing.Point(605, 509);
			this.buttonNext.Margin = new System.Windows.Forms.Padding(0);
			this.buttonNext.Name = "buttonNext";
			this.buttonNext.Size = new System.Drawing.Size(90, 28);
			this.buttonNext.TabIndex = 27;
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
			this.buttonCancel.Location = new System.Drawing.Point(492, 509);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(90, 28);
			this.buttonCancel.TabIndex = 26;
			this.buttonCancel.TabStop = false;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			this.buttonCancel.MouseEnter += new System.EventHandler(buttonCancel_MouseEnter);
			this.buttonCancel.MouseLeave += new System.EventHandler(buttonCancel_MouseLeave);
			this.labellaptoppower.BackColor = System.Drawing.Color.Transparent;
			this.labellaptoppower.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labellaptoppower.ImageKey = "(none)";
			this.labellaptoppower.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labellaptoppower.Location = new System.Drawing.Point(45, 441);
			this.labellaptoppower.Name = "labellaptoppower";
			this.labellaptoppower.Size = new System.Drawing.Size(638, 26);
			this.labellaptoppower.TabIndex = 25;
			this.labellaptoppower.Text = "If using a laptop, ensure that it is plugged into a power outlet.";
			this.labellaptoppower.MouseDown += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseDown);
			this.labellaptoppower.MouseMove += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseMove);
			this.labelexitsynapse.BackColor = System.Drawing.Color.Transparent;
			this.labelexitsynapse.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelexitsynapse.ImageKey = "(none)";
			this.labelexitsynapse.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelexitsynapse.Location = new System.Drawing.Point(45, 112);
			this.labelexitsynapse.Margin = new System.Windows.Forms.Padding(0);
			this.labelexitsynapse.Name = "labelexitsynapse";
			this.labelexitsynapse.Size = new System.Drawing.Size(638, 57);
			this.labelexitsynapse.TabIndex = 24;
			this.labelexitsynapse.Text = "Please close all applications under Razer Central before proceeding. Right mouse click on the Razer icon in the Systray and choose ‘Exit All Apps’.";
			this.labelexitsynapse.MouseDown += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseDown);
			this.labelexitsynapse.MouseMove += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseMove);
			this.labelreminder.AutoSize = true;
			this.labelreminder.BackColor = System.Drawing.Color.Transparent;
			this.labelreminder.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelreminder.ImageKey = "(none)";
			this.labelreminder.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelreminder.Location = new System.Drawing.Point(45, 80);
			this.labelreminder.Margin = new System.Windows.Forms.Padding(0);
			this.labelreminder.Name = "labelreminder";
			this.labelreminder.Size = new System.Drawing.Size(96, 20);
			this.labelreminder.TabIndex = 23;
			this.labelreminder.Text = "REMINDER";
			this.labelreminder.MouseDown += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseDown);
			this.labelreminder.MouseMove += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseMove);
			this.labelHeader.AutoSize = true;
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
			this.labelHeader.ImageKey = "(none)";
			this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelHeader.Location = new System.Drawing.Point(35, 32);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(368, 22);
			this.labelHeader.TabIndex = 22;
			this.labelHeader.Text = "RAZER MANO'WAR FIRMWARE UPDATER";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseMove);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.exitsynapse;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			base.ClientSize = new System.Drawing.Size(730, 574);
			base.Controls.Add(this.buttonNext);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.labellaptoppower);
			base.Controls.Add(this.labelexitsynapse);
			base.Controls.Add(this.labelreminder);
			base.Controls.Add(this.labelHeader);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "PromptExitSynapse";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "PromptExitSynapse";
			base.Load += new System.EventHandler(PromptExitSynapse_Load);
			base.Shown += new System.EventHandler(PromptExitSynapse_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(PromptExitSynapse_MouseMove);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
