using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomProgressBar
{
	public class CustomProgressBar : UserControl
	{
		private int min = 0;

		private int max = 100;

		private int val = 0;

		private Color BarColor = Color.FromArgb(118, 118, 118);

		private Color BarBackColor = Color.FromArgb(51, 51, 51);

		private Color BorderColor = Color.White;

		private Font BarFont = new Font("Arial", 10f);

		private Timer timer = new Timer();

		private int indeterminateval = 0;

		private bool indeterminate = false;

		private IContainer components = null;

		public int Minimum
		{
			get
			{
				return min;
			}
			set
			{
				if (value < 0)
				{
					min = 0;
				}
				if (value > max)
				{
					min = value;
					min = value;
				}
				if (val < min)
				{
					val = min;
				}
				Invalidate();
			}
		}

		public int Maximum
		{
			get
			{
				return max;
			}
			set
			{
				if (value < min)
				{
					min = value;
				}
				max = value;
				if (val > max)
				{
					val = max;
				}
				Invalidate();
			}
		}

		public bool IsIndeterminate
		{
			get
			{
				return indeterminate;
			}
			set
			{
				indeterminate = value;
				indeterminateval = min;
				if (indeterminate)
				{
					timer.Enabled = true;
					timer.Start();
				}
				else
				{
					timer.Enabled = false;
					timer.Stop();
					Invalidate();
				}
			}
		}

		public int Value
		{
			get
			{
				return val;
			}
			set
			{
				int num = val;
				if (value < min)
				{
					val = min;
				}
				else if (value > max)
				{
					val = max;
				}
				else
				{
					val = value;
				}
				Rectangle clientRectangle = base.ClientRectangle;
				Rectangle clientRectangle2 = base.ClientRectangle;
				float num2 = (float)(val - min) / (float)(max - min);
				clientRectangle.Width = (int)((float)clientRectangle.Width * num2);
				num2 = (float)(num - min) / (float)(max - min);
				clientRectangle2.Width = (int)((float)clientRectangle2.Width * num2);
				Rectangle rc = default(Rectangle);
				if (clientRectangle.Width > clientRectangle2.Width)
				{
					rc.X = clientRectangle2.Size.Width;
					rc.Width = clientRectangle.Width - clientRectangle2.Width;
				}
				else
				{
					rc.X = clientRectangle.Size.Width;
					rc.Width = clientRectangle2.Width - clientRectangle.Width;
				}
				rc.Height = base.Height;
				Invalidate(rc);
			}
		}

		public Color ProgressBarColor
		{
			get
			{
				return BarColor;
			}
			set
			{
				BarColor = value;
				Invalidate();
			}
		}

		public Color ProgressBarBorderColor
		{
			get
			{
				return BorderColor;
			}
			set
			{
				BorderColor = value;
				Invalidate();
			}
		}

		public Font ProgressFont
		{
			get
			{
				return BarFont;
			}
			set
			{
				BarFont = value;
			}
		}

		public CustomProgressBar()
		{
			InitializeComponent();
		}

		protected override void OnResize(EventArgs e)
		{
			Invalidate();
			timer.Interval = 100;
			timer.Enabled = false;
			timer.Tick += Timer_Tick;
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			indeterminateval++;
			Invalidate();
			if ((double)indeterminateval >= (double)max + (double)(max - min) * 0.2)
			{
				indeterminateval = 0;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (indeterminate)
			{
				Graphics graphics = e.Graphics;
				SolidBrush solidBrush = new SolidBrush(BarColor);
				SolidBrush brush = new SolidBrush(BarBackColor);
				float num = (float)(indeterminateval - min) / (float)(max - min);
				Rectangle clientRectangle = base.ClientRectangle;
				graphics.FillRectangle(brush, clientRectangle);
				if ((double)num - 0.2 < 0.0)
				{
					clientRectangle.Width = (int)((float)clientRectangle.Width * num);
					graphics.FillRectangle(solidBrush, clientRectangle);
				}
				else if (num - 1f > 0f)
				{
					graphics.FillRectangle(solidBrush, new Rectangle
					{
						X = (int)((double)clientRectangle.Width * ((double)num - 0.2)),
						Y = 0,
						Height = clientRectangle.Height,
						Width = (int)((double)clientRectangle.Width * (1.2 - (double)num))
					});
				}
				else
				{
					graphics.FillRectangle(solidBrush, new Rectangle
					{
						X = (int)((double)clientRectangle.Width * ((double)num - 0.2)),
						Y = 0,
						Height = clientRectangle.Height,
						Width = (int)((double)clientRectangle.Width * 0.2)
					});
				}
				Draw3DBorder(graphics);
				solidBrush.Dispose();
				graphics.Dispose();
			}
			else
			{
				Graphics graphics2 = e.Graphics;
				SolidBrush solidBrush2 = new SolidBrush(BarColor);
				SolidBrush brush2 = new SolidBrush(BarBackColor);
				float num2 = (float)(val - min) / (float)(max - min);
				Rectangle clientRectangle2 = base.ClientRectangle;
				graphics2.FillRectangle(brush2, clientRectangle2);
				if (num2 > 0f)
				{
					clientRectangle2.Width = (int)((float)clientRectangle2.Width * num2);
					graphics2.FillRectangle(solidBrush2, clientRectangle2);
				}
				Draw3DBorder(graphics2);
				solidBrush2.Dispose();
				graphics2.Dispose();
			}
		}

		private void Draw3DBorder(Graphics g)
		{
			int num = base.ClientRectangle.Height / 2;
			Pen pen = new Pen(BorderColor);
			int num2 = (int)pen.Width;
			g.DrawArc(pen, base.ClientRectangle.X, base.ClientRectangle.Y, num * 2, num * 2, 180, 90);
			g.DrawLine(pen, base.ClientRectangle.X + num, base.ClientRectangle.Y, base.ClientRectangle.Right - num * 2, base.ClientRectangle.Y);
			g.DrawArc(pen, base.ClientRectangle.X + base.ClientRectangle.Width - num * 2, base.ClientRectangle.Y, num * 2, num * 2, 270, 90);
			g.DrawLine(pen, base.ClientRectangle.Right, base.ClientRectangle.Y + num * 2, base.ClientRectangle.Right, base.ClientRectangle.Y + base.ClientRectangle.Height - num * 2);
			g.DrawArc(pen, base.ClientRectangle.X + base.ClientRectangle.Width - num * 2, base.ClientRectangle.Y + base.ClientRectangle.Height - num * 2, num * 2, num * 2, 0, 90);
			g.DrawLine(pen, base.ClientRectangle.Right - num * 2, base.ClientRectangle.Bottom, base.ClientRectangle.X + num * 2, base.ClientRectangle.Bottom);
			g.DrawArc(pen, base.ClientRectangle.X, base.ClientRectangle.Bottom - num * 2, num * 2, num * 2, 90, 90);
			g.DrawLine(pen, base.ClientRectangle.X, base.ClientRectangle.Bottom - num * 2, base.ClientRectangle.X, base.ClientRectangle.Y + num * 2);
		}

		public static void DrawRoundRectangle(Graphics g, Pen pen, Rectangle rect, int cornerRadius)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
			{
				g.DrawPath(pen, path);
			}
		}

		public static void FillRoundRectangle(Graphics g, Brush brush, Rectangle rect, int cornerRadius)
		{
			using (GraphicsPath path = CreateRoundedRectanglePath(rect, cornerRadius))
			{
				g.FillPath(brush, path);
			}
		}

		internal static GraphicsPath CreateRoundedRectanglePath(Rectangle rect, int cornerRadius)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			graphicsPath.AddArc(rect.X, rect.Y, cornerRadius * 2, cornerRadius * 2, 180f, 90f);
			graphicsPath.AddLine(rect.X + cornerRadius, rect.Y, rect.Right - cornerRadius * 2, rect.Y);
			graphicsPath.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y, cornerRadius * 2, cornerRadius * 2, 270f, 90f);
			graphicsPath.AddLine(rect.Right, rect.Y + cornerRadius * 2, rect.Right, rect.Y + rect.Height - cornerRadius * 2);
			graphicsPath.AddArc(rect.X + rect.Width - cornerRadius * 2, rect.Y + rect.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0f, 90f);
			graphicsPath.AddLine(rect.Right - cornerRadius * 2, rect.Bottom, rect.X + cornerRadius * 2, rect.Bottom);
			graphicsPath.AddArc(rect.X, rect.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90f, 90f);
			graphicsPath.AddLine(rect.X, rect.Bottom - cornerRadius * 2, rect.X, rect.Y + cornerRadius * 2);
			graphicsPath.CloseFigure();
			return graphicsPath;
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
			base.SuspendLayout();
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Name = "CustomProgressBar";
			base.Size = new System.Drawing.Size(488, 23);
			base.ResumeLayout(false);
		}
	}
}
