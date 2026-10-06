using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace CustomShapedFormRegion
{
	internal class BitmapToRegion
	{
		private static int DPI_96 = 96;

		private static int DPI_120 = 120;

		private static Size IMAGE_SIZE_1 = new Size(615, 551);

		private static Size IMAGE_SIZE_2 = new Size(820, 678);

		private static Size IMAGE_SIZE_3 = new Size(925, 840);

		public static Region getRegion(Bitmap inputBmp, Color transperancyKey, int tolerance)
		{
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < inputBmp.Width; i++)
			{
				for (int j = 0; j < inputBmp.Height; j++)
				{
					if (!colorsMatch(inputBmp.GetPixel(i, j), transperancyKey, tolerance))
					{
						graphicsPath.AddRectangle(new Rectangle(i, j, 1, 1));
					}
				}
			}
			Region result = new Region(graphicsPath);
			graphicsPath.Dispose();
			return result;
		}

		private static bool colorsMatch(Color color1, Color color2, int tolerance)
		{
			if (tolerance < 0)
			{
				tolerance = 0;
			}
			if (Math.Abs(color1.R - color2.R) <= tolerance && Math.Abs(color1.G - color2.G) <= tolerance)
			{
				return Math.Abs(color1.B - color2.B) <= tolerance;
			}
			return false;
		}

		private unsafe static bool colorsMatch(uint* pixelPtr, Color color1, int tolerance)
		{
			if (tolerance < 0)
			{
				tolerance = 0;
			}
			byte alpha = (byte)(*pixelPtr >> 24);
			byte red = (byte)(*pixelPtr >> 16);
			byte green = (byte)(*pixelPtr >> 8);
			byte blue = (byte)(*pixelPtr);
			Color color2 = Color.FromArgb(alpha, red, green, blue);
			if (Math.Abs(color1.A - color2.A) <= tolerance && Math.Abs(color1.R - color2.R) <= tolerance && Math.Abs(color1.G - color2.G) <= tolerance)
			{
				return Math.Abs(color1.B - color2.B) <= tolerance;
			}
			return false;
		}

		public unsafe static Color GetBtnBackImageColor(Bitmap bitmap)
		{
			GraphicsUnit pageUnit = GraphicsUnit.Pixel;
			RectangleF bounds = bitmap.GetBounds(ref pageUnit);
			Rectangle rect = new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)bitmapData.Scan0.ToPointer();
			for (int i = 0; i < 15; i++)
			{
				byte* ptr2 = (byte*)ptr;
				ptr = (uint*)(ptr2 + bitmapData.Stride);
			}
			int num = 0;
			while (num < 15)
			{
				num++;
				ptr++;
			}
			byte alpha = (byte)(*ptr >> 24);
			byte red = (byte)(*ptr >> 16);
			byte green = (byte)(*ptr >> 8);
			byte blue = (byte)(*ptr);
			return Color.FromArgb(alpha, red, green, blue);
		}

		public unsafe static Region getRegionFast(Size size, Bitmap bitmap, Color transparencyKey, int tolerance)
		{
			GraphicsUnit pageUnit = GraphicsUnit.Pixel;
			RectangleF bounds = bitmap.GetBounds(ref pageUnit);
			Rectangle rect = new Rectangle((int)bounds.Left, (int)bounds.Top, (int)bounds.Width, (int)bounds.Height);
			int num = (int)bounds.Height;
			int num2 = (int)bounds.Width;
			if (tolerance <= 0)
			{
				tolerance = 1;
			}
			BitmapData bitmapData = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
			uint* ptr = (uint*)bitmapData.Scan0.ToPointer();
			GraphicsPath graphicsPath = new GraphicsPath();
			for (int i = 0; i < num; i++)
			{
				byte* ptr2 = (byte*)ptr;
				int num3 = 0;
				while (num3 < num2)
				{
					if (colorsMatch(ptr, transparencyKey, tolerance))
					{
						int num4 = num3;
						while (num3 < num2 && colorsMatch(ptr, transparencyKey, tolerance))
						{
							num3++;
							ptr++;
						}
						if (i == 15)
						{
							for (int j = 0; j < size.Height - num; j++)
							{
								graphicsPath.AddRectangle(new Rectangle(num4, i + j, size.Width - num4 * 2, 1));
							}
						}
						else if (i > 15)
						{
							graphicsPath.AddRectangle(new Rectangle(num4, i + size.Height - num - 1, size.Width - num4 * 2, 1));
						}
						else
						{
							graphicsPath.AddRectangle(new Rectangle(num4, i, size.Width - num4 * 2, 1));
						}
						break;
					}
					num3++;
					ptr++;
				}
				ptr = (uint*)(ptr2 + bitmapData.Stride);
			}
			Region result = new Region(graphicsPath);
			graphicsPath.Dispose();
			bitmap.UnlockBits(bitmapData);
			return result;
		}

		public static Size GetNewSize(int dpi)
		{
			if (dpi == DPI_96)
			{
				return IMAGE_SIZE_1;
			}
			if (dpi == DPI_120)
			{
				return IMAGE_SIZE_2;
			}
			return IMAGE_SIZE_3;
		}
	}
}
