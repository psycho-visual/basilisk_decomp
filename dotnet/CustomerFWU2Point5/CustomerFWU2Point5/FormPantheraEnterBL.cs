using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using CustomerFWU2Point5.Properties;
using CustomerFWU2Point5.Resources;
using CustomerFirmwareUpdater;

namespace CustomerFWU2Point5
{
	public class FormPantheraEnterBL : Form
	{
		private Point lastPoint = Point.Empty;

		private DeviceInterface device;

		private bool checkend;

		private bool stopclosethread;

		private IContainer components;

		private Label labelplugfiber;

		private PictureBox pictureBox1;

		private Label labelswitchps4;

		private Label labelpressbtn1;

		private Label labeltargetver;

		private Label labelHeader;

		private MyButton buttonUpdate;

		private MyButton buttonCancel;

		private Label labelNote;

		private BackgroundWorker backgroundWorkerdetectbl;

		private BackgroundWorker backgroundWorkerCloseRestartDialog;

		private PictureBox pictureBox2;

		private Label labelpressbtn2;

		private Label labelpluginpc;

		public FormPantheraEnterBL()
		{
			InitializeComponent();
		}

		public FormPantheraEnterBL(DeviceInterface device)
		{
			this.device = device;
			InitializeComponent();
		}

		private void FormPantheraEnterBL_Load(object sender, EventArgs e)
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
			Text = labelHeader.Text;
			BackgroundImage = CustomerFWU2Point5.Properties.Resources.panthera_FWU;
			labelplugfiber.Text = ResourceStr.conndetachablecable;
			labelNote.Text = ResourceStr.pantheranote;
			labelNote.ForeColor = Common.lightgray;
			labelswitchps4.Text = ResourceStr.switchtops4;
			labelpressbtn1.Text = ResourceStr.pantherapressbtn1.Trim();
			labelpressbtn2.Text = ResourceStr.pantherapressbtn2.Trim();
			labelpluginpc.Text = ResourceStr.pantherapluginpc;
			labeltargetver.ForeColor = Common.greendarktheme;
			labeltargetver.Text = ResourceStr.newver + Common.updateInfo.GetDevFWVer(Common.updateInfo.CurDevIndex);
			labeltargetver.Visible = true;
			buttonCancel.Enabled = true;
			buttonCancel.Text = ResourceStr.cancel;
			buttonUpdate.Text = ResourceStr.update;
			buttonUpdate.Location = new Point(base.Width - 45 - buttonUpdate.Width, buttonUpdate.Location.Y);
			buttonCancel.Location = new Point(buttonUpdate.Location.X - 20 - buttonCancel.Width, buttonUpdate.Location.Y);
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			checkend = false;
			Thread.Sleep(100);
			Common.IsExiting = true;
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

		private void FormPantheraEnterBL_MouseDown(object sender, MouseEventArgs e)
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

		private void FormPantheraEnterBL_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				base.Left += e.X - lastPoint.X;
				base.Top += e.Y - lastPoint.Y;
			}
		}

		private void backgroundWorkerdetectbl_DoWork(object sender, DoWorkEventArgs e)
		{
			bool flag = false;
			while (checkend)
			{
				try
				{
					flag = false;
					IntPtr zero = IntPtr.Zero;
					zero = ((Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex) != 2f) ? device.OpenBootloader(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex)) : device.OpenDev(Convert.ToUInt32(Common.updateInfo.GetBLVID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt32(Common.updateInfo.GetBLPID(Common.updateInfo.CurDevIndex), 16), Convert.ToUInt16(Common.updateInfo.GetBLBCDDevPID(Common.updateInfo.CurDevIndex), 16), Common.updateInfo.GetBLVer(Common.updateInfo.CurDevIndex), 12, 91, 0, 0));
					if (zero != IntPtr.Zero)
					{
						flag = true;
						device.CloseDev(zero);
						zero = IntPtr.Zero;
					}
					if (flag)
					{
						checkend = false;
						break;
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
				}
			}
		}

		private void FormPantheraEnterBL_Shown(object sender, EventArgs e)
		{
			float num = (float)base.Width / 730f;
			while ((float)labelHeader.Width > (float)base.Width - (float)Common.logowidth * num - 50f)
			{
				labelHeader.Font = new Font(labelHeader.Font.FontFamily, labelHeader.Font.Size - 1f);
			}
			int width = labelpressbtn1.Width;
			int width2 = labelpressbtn2.Width;
			labelpressbtn1.AutoSize = false;
			labelpressbtn1.Size = new Size(width, 46);
			labelpressbtn1.TextAlign = ContentAlignment.MiddleCenter;
			pictureBox2.Location = new Point(labelpressbtn1.Location.X + width + 5, pictureBox2.Location.Y);
			labelpressbtn2.AutoSize = false;
			labelpressbtn2.Size = new Size(width2, 46);
			labelpressbtn2.TextAlign = ContentAlignment.MiddleCenter;
			labelpressbtn2.Location = new Point(pictureBox2.Location.X + pictureBox2.Width + 5, labelpressbtn2.Location.Y);
			if (!backgroundWorkerdetectbl.IsBusy)
			{
				checkend = true;
				backgroundWorkerdetectbl.RunWorkerAsync();
			}
			if (!backgroundWorkerCloseRestartDialog.IsBusy)
			{
				stopclosethread = true;
				backgroundWorkerCloseRestartDialog.RunWorkerAsync();
			}
		}

		private void buttonUpdate_MouseEnter(object sender, EventArgs e)
		{
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_hover;
		}

		private void buttonUpdate_MouseLeave(object sender, EventArgs e)
		{
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void backgroundWorkerdetectbl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			buttonUpdate.Enabled = true;
			buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_normal;
		}

		private void buttonUpdate_Click(object sender, EventArgs e)
		{
			checkend = false;
			Thread.Sleep(100);
			Common.NextPage = PageIndex.FormFWUStep1;
			Common.IsExiting = false;
			Close();
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerFWU2Point5.FormPantheraEnterBL));
			this.labelplugfiber = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.labelswitchps4 = new System.Windows.Forms.Label();
			this.labelpressbtn1 = new System.Windows.Forms.Label();
			this.labeltargetver = new System.Windows.Forms.Label();
			this.labelHeader = new System.Windows.Forms.Label();
			this.labelNote = new System.Windows.Forms.Label();
			this.backgroundWorkerdetectbl = new System.ComponentModel.BackgroundWorker();
			this.backgroundWorkerCloseRestartDialog = new System.ComponentModel.BackgroundWorker();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.labelpressbtn2 = new System.Windows.Forms.Label();
			this.labelpluginpc = new System.Windows.Forms.Label();
			this.buttonUpdate = new CustomerFirmwareUpdater.MyButton();
			this.buttonCancel = new CustomerFirmwareUpdater.MyButton();
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).BeginInit();
			base.SuspendLayout();
			this.labelplugfiber.BackColor = System.Drawing.Color.Transparent;
			this.labelplugfiber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelplugfiber.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelplugfiber.Location = new System.Drawing.Point(289, 114);
			this.labelplugfiber.Name = "labelplugfiber";
			this.labelplugfiber.Size = new System.Drawing.Size(382, 46);
			this.labelplugfiber.TabIndex = 16;
			this.labelplugfiber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelplugfiber.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labelplugfiber.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.pictureBox1.Image = CustomerFWU2Point5.Properties.Resources.tanhao;
			this.pictureBox1.InitialImage = (System.Drawing.Image)resources.GetObject("pictureBox1.InitialImage");
			this.pictureBox1.Location = new System.Drawing.Point(295, 173);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(23, 23);
			this.pictureBox1.TabIndex = 17;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.labelswitchps4.BackColor = System.Drawing.Color.Transparent;
			this.labelswitchps4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelswitchps4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelswitchps4.Location = new System.Drawing.Point(289, 297);
			this.labelswitchps4.Name = "labelswitchps4";
			this.labelswitchps4.Size = new System.Drawing.Size(382, 46);
			this.labelswitchps4.TabIndex = 18;
			this.labelswitchps4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelswitchps4.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labelswitchps4.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.labelpressbtn1.AutoSize = true;
			this.labelpressbtn1.BackColor = System.Drawing.Color.Transparent;
			this.labelpressbtn1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelpressbtn1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelpressbtn1.Location = new System.Drawing.Point(289, 454);
			this.labelpressbtn1.Name = "labelpressbtn1";
			this.labelpressbtn1.Size = new System.Drawing.Size(0, 18);
			this.labelpressbtn1.TabIndex = 19;
			this.labelpressbtn1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelpressbtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labelpressbtn1.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.labeltargetver.AutoSize = true;
			this.labeltargetver.BackColor = System.Drawing.Color.Transparent;
			this.labeltargetver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12f);
			this.labeltargetver.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labeltargetver.Location = new System.Drawing.Point(39, 734);
			this.labeltargetver.Name = "labeltargetver";
			this.labeltargetver.Size = new System.Drawing.Size(116, 20);
			this.labeltargetver.TabIndex = 22;
			this.labeltargetver.Text = "Latest Version:";
			this.labeltargetver.Visible = false;
			this.labeltargetver.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labeltargetver.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.labelHeader.AutoSize = true;
			this.labelHeader.BackColor = System.Drawing.Color.Transparent;
			this.labelHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 13f);
			this.labelHeader.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelHeader.Location = new System.Drawing.Point(35, 32);
			this.labelHeader.Name = "labelHeader";
			this.labelHeader.Size = new System.Drawing.Size(368, 22);
			this.labelHeader.TabIndex = 23;
			this.labelHeader.Text = "RAZER MANO'WAR FIRMWARE UPDATER";
			this.labelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labelHeader.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.labelNote.BackColor = System.Drawing.Color.Transparent;
			this.labelNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelNote.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelNote.Location = new System.Drawing.Point(334, 166);
			this.labelNote.Name = "labelNote";
			this.labelNote.Size = new System.Drawing.Size(337, 40);
			this.labelNote.TabIndex = 26;
			this.labelNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelNote.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.labelNote.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.backgroundWorkerdetectbl.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerdetectbl_DoWork);
			this.backgroundWorkerdetectbl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(backgroundWorkerdetectbl_RunWorkerCompleted);
			this.backgroundWorkerCloseRestartDialog.DoWork += new System.ComponentModel.DoWorkEventHandler(backgroundWorkerCloseRestartDialog_DoWork);
			this.pictureBox2.BackgroundImage = CustomerFWU2Point5.Properties.Resources.dot;
			this.pictureBox2.Location = new System.Drawing.Point(400, 471);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(12, 12);
			this.pictureBox2.TabIndex = 27;
			this.pictureBox2.TabStop = false;
			this.labelpressbtn2.AutoSize = true;
			this.labelpressbtn2.BackColor = System.Drawing.Color.Transparent;
			this.labelpressbtn2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelpressbtn2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelpressbtn2.Location = new System.Drawing.Point(418, 454);
			this.labelpressbtn2.Name = "labelpressbtn2";
			this.labelpressbtn2.Size = new System.Drawing.Size(0, 18);
			this.labelpressbtn2.TabIndex = 28;
			this.labelpressbtn2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.labelpluginpc.BackColor = System.Drawing.Color.Transparent;
			this.labelpluginpc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.labelpluginpc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelpluginpc.Location = new System.Drawing.Point(289, 611);
			this.labelpluginpc.Name = "labelpluginpc";
			this.labelpluginpc.Size = new System.Drawing.Size(395, 54);
			this.labelpluginpc.TabIndex = 29;
			this.labelpluginpc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.buttonUpdate.AutoSize = true;
			this.buttonUpdate.BackColor = System.Drawing.Color.White;
			this.buttonUpdate.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_update_disabled;
			this.buttonUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonUpdate.Enabled = false;
			this.buttonUpdate.EnabledSet = true;
			this.buttonUpdate.FlatAppearance.BorderSize = 0;
			this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonUpdate.ForeColor = System.Drawing.Color.White;
			this.buttonUpdate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonUpdate.Location = new System.Drawing.Point(592, 730);
			this.buttonUpdate.Margin = new System.Windows.Forms.Padding(0);
			this.buttonUpdate.Name = "buttonUpdate";
			this.buttonUpdate.Size = new System.Drawing.Size(90, 28);
			this.buttonUpdate.TabIndex = 25;
			this.buttonUpdate.TabStop = false;
			this.buttonUpdate.Text = "UPDATE";
			this.buttonUpdate.UseVisualStyleBackColor = false;
			this.buttonUpdate.Click += new System.EventHandler(buttonUpdate_Click);
			this.buttonUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.buttonUpdate.MouseEnter += new System.EventHandler(buttonUpdate_MouseEnter);
			this.buttonUpdate.MouseLeave += new System.EventHandler(buttonUpdate_MouseLeave);
			this.buttonUpdate.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			this.buttonCancel.AutoSize = true;
			this.buttonCancel.BackColor = System.Drawing.Color.White;
			this.buttonCancel.BackgroundImage = CustomerFWU2Point5.Properties.Resources.button_cancel_normal;
			this.buttonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonCancel.Enabled = false;
			this.buttonCancel.EnabledSet = true;
			this.buttonCancel.FlatAppearance.BorderSize = 0;
			this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25f);
			this.buttonCancel.ForeColor = System.Drawing.Color.White;
			this.buttonCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.buttonCancel.Location = new System.Drawing.Point(487, 730);
			this.buttonCancel.Margin = new System.Windows.Forms.Padding(0);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(90, 28);
			this.buttonCancel.TabIndex = 24;
			this.buttonCancel.TabStop = false;
			this.buttonCancel.Text = "CANCEL";
			this.buttonCancel.UseVisualStyleBackColor = false;
			this.buttonCancel.Click += new System.EventHandler(buttonCancel_Click);
			this.buttonCancel.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			this.buttonCancel.MouseEnter += new System.EventHandler(buttonCancel_MouseEnter);
			this.buttonCancel.MouseLeave += new System.EventHandler(buttonCancel_MouseLeave);
			this.buttonCancel.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			base.AutoScaleDimensions = new System.Drawing.SizeF(96f, 96f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
			this.AutoScroll = true;
			this.BackgroundImage = CustomerFWU2Point5.Properties.Resources.panthera_FWU;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new System.Drawing.Size(730, 787);
			base.Controls.Add(this.labelpluginpc);
			base.Controls.Add(this.labelpressbtn2);
			base.Controls.Add(this.pictureBox2);
			base.Controls.Add(this.labelNote);
			base.Controls.Add(this.buttonUpdate);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.labelHeader);
			base.Controls.Add(this.labeltargetver);
			base.Controls.Add(this.labelpressbtn1);
			base.Controls.Add(this.labelswitchps4);
			base.Controls.Add(this.pictureBox1);
			base.Controls.Add(this.labelplugfiber);
			this.DoubleBuffered = true;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "FormPantheraEnterBL";
			base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "FormRaijuEnterBL";
			base.Load += new System.EventHandler(FormPantheraEnterBL_Load);
			base.Shown += new System.EventHandler(FormPantheraEnterBL_Shown);
			base.MouseDown += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseDown);
			base.MouseMove += new System.Windows.Forms.MouseEventHandler(FormPantheraEnterBL_MouseMove);
			((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBox2).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
