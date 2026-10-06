using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using CustomShapedFormRegion;
using CustomerFWU2Point5;

namespace CustomerFirmwareUpdater
{
	internal class MyButton : Button
	{
		private bool enabled = true;

		protected override bool ShowFocusCues => false;

		public new Color ForeColor
		{
			get
			{
				return base.ForeColor;
			}
			set
			{
				if (enabled)
				{
					base.ForeColor = value;
				}
			}
		}

		public new bool Enabled
		{
			get
			{
				return enabled;
			}
			set
			{
				enabled = value;
				if (!value)
				{
					base.Cursor = Cursors.Arrow;
					base.ForeColor = Common.btnfontcolor;
				}
				else
				{
					base.ForeColor = Common.btnfontcolor;
					base.Cursor = Cursors.Hand;
				}
			}
		}

		public bool EnabledSet
		{
			get
			{
				return base.Enabled;
			}
			set
			{
				base.Enabled = value;
			}
		}

		public MyButton()
		{
			base.FlatStyle = FlatStyle.Flat;
			base.FlatAppearance.BorderSize = 0;
			base.FlatAppearance.MouseDownBackColor = Color.Transparent;
			base.FlatAppearance.MouseOverBackColor = Color.Transparent;
			BackColor = Color.Transparent;
			base.Size = new Size(90, 27);
		}

		public static Bitmap KiResizeImage(Bitmap bmp, int newW, int newH)
		{
			try
			{
				Bitmap bitmap = new Bitmap(newW, newH);
				Graphics graphics = Graphics.FromImage(bitmap);
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.DrawImage(bmp, new Rectangle(0, 0, newW, newH), new Rectangle(0, 0, bmp.Width, bmp.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				return bitmap;
			}
			catch
			{
				return null;
			}
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
			if (BackgroundImage != null)
			{
				Color btnBackImageColor = BitmapToRegion.GetBtnBackImageColor(new Bitmap(BackgroundImage));
				base.Region = BitmapToRegion.getRegionFast(base.Size, new Bitmap(BackgroundImage), btnBackImageColor, 1);
			}
		}

		protected override void OnClick(EventArgs e)
		{
			if (enabled)
			{
				base.OnClick(e);
			}
		}

		protected override void OnDoubleClick(EventArgs e)
		{
			if (enabled)
			{
				base.OnDoubleClick(e);
			}
		}

		protected override void OnMouseClick(MouseEventArgs e)
		{
			if (enabled)
			{
				base.OnMouseClick(e);
			}
		}

		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (enabled)
			{
				base.OnMouseDoubleClick(e);
			}
		}

		protected override void OnMouseEnter(EventArgs e)
		{
			if (enabled)
			{
				base.Cursor = Cursors.Hand;
				base.OnMouseEnter(e);
			}
			else
			{
				base.Cursor = Cursors.Arrow;
			}
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			if (enabled)
			{
				base.Cursor = Cursors.Arrow;
				base.OnMouseLeave(e);
			}
		}

		protected override void OnMouseHover(EventArgs e)
		{
			if (enabled)
			{
				base.OnMouseHover(e);
			}
		}

		protected override void OnChangeUICues(UICuesEventArgs e)
		{
			if (enabled)
			{
				base.OnChangeUICues(e);
			}
		}
	}
}
