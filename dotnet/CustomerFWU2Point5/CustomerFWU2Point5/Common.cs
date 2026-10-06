using System;
using System.Drawing;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace CustomerFWU2Point5
{
	public class Common
	{
		public struct VidPid
		{
			private string strVID;

			private string strPID;

			private bool bconnect;

			public VidPid(string strVID, string strPID, bool bconnect)
			{
				this.strVID = strVID;
				this.strPID = strPID;
				this.bconnect = bconnect;
			}

			public VidPid(string strVID, string strPID)
			{
				this.strVID = strVID;
				this.strPID = strPID;
				bconnect = true;
			}

			public string GetVID()
			{
				return strVID;
			}

			public string GetPID()
			{
				return strPID;
			}

			public bool GetDevType()
			{
				return bconnect;
			}

			public void SetDevType(bool bconnect)
			{
				this.bconnect = bconnect;
			}

			public static bool operator ==(VidPid vidPid1, VidPid vidPid2)
			{
				if (vidPid1.strVID == vidPid2.strVID)
				{
					return vidPid1.strPID == vidPid2.strPID;
				}
				return false;
			}

			public static bool operator !=(VidPid vidPid1, VidPid vidPid2)
			{
				return !(vidPid1 == vidPid2);
			}

			public override bool Equals(object obj)
			{
				if (obj is VidPid)
				{
					return this == (VidPid)obj;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		public static bool forsynapseuse = false;

		public static bool fordummy = true;

		public static PageIndex NextPage = PageIndex.FormFWUStep1;

		public static string resfile = Path.GetDirectoryName(Application.ExecutablePath) + "\\DeviceUpdater.resources";

		public static bool fExiting = false;

		public static UpdateInfo updateInfo = null;

		public const int FIRMWARE_DELAY = 0;

		public static long filelen = 0L;

		public static ushort PACKLEN = 64;

		public static ushort FlashPACKLEN = 16;

		public static ushort PAGESIZE = 4096;

		public static Color lightgray = Color.FromArgb(7763574);

		public static bool IsExiting = true;

		public static uint StartAddr = 0u;

		public static uint EndAddr = 0u;

		public static bool IsLowBattery = false;

		public static bool LogEnabled = false;

		public static bool DevFWNeedUpdate = false;

		public static bool FlashFWNeedUpdate = false;

		public static Image background = null;

		public static Color btnfontcolor = Color.FromArgb(2236962);

		public static Color greendarktheme = Color.FromArgb(4511276);

		public static ushort LPreMinX = 0;

		public static ushort LPreMinY = 0;

		public static ushort LPreMidX = 0;

		public static ushort LPreMidY = 0;

		public static ushort LPreMaxX = 0;

		public static ushort LPreMaxY = 0;

		public static ushort RPreMinX = 0;

		public static ushort RPreMinY = 0;

		public static ushort RPreMidX = 0;

		public static ushort RPreMidY = 0;

		public static ushort RPreMaxX = 0;

		public static ushort RPreMaxY = 0;

		public static ushort LPreTMin = 0;

		public static ushort LPreTMax = 0;

		public static ushort RPreTMin = 0;

		public static ushort RPreTMax = 0;

		public static ushort LNewMinX = 0;

		public static ushort LNewMinY = 0;

		public static ushort LNewMidX = 0;

		public static ushort LNewMidY = 0;

		public static ushort LNewMaxX = 0;

		public static ushort LNewMaxY = 0;

		public static ushort RNewMinX = 0;

		public static ushort RNewMinY = 0;

		public static ushort RNewMidX = 0;

		public static ushort RNewMidY = 0;

		public static ushort RNewMaxX = 0;

		public static ushort RNewMaxY = 0;

		public static ushort LNewTMin = 0;

		public static ushort LNewTMax = 0;

		public static ushort RNewTMin = 0;

		public static ushort RNewTMax = 0;

		public static string DevSN = "";

		public static bool CalibrationFunction = false;

		public static bool NeedCalibration = false;

		public static int centraltolerance = 5;

		public static int SNFlag = -1;

		public static string PatriciaCalibrationlogFileName = Path.Combine("C:\\", string.Format("PatrciaCalibration_{0}.log", DateTime.Now.ToShortDateString().Replace("/", "_")));

		public static bool newedition = false;

		public static byte devedition = 0;

		public static byte layout = 1;

		public static int hspacebtnbottom = 33;

		public static int wspacebutton = 15;

		public static int logowidth = 130;

		public static string curdevver = "";

		public static byte RegionID = 0;

		public static byte total = 0;

		public static byte type = 0;

		public static uint regionsize = 0u;

		public static byte packetsize = 0;

		public static long flashfwlen = 0L;

		public static int MAX_RETRY = 10;

		public static ushort crc;

		public static byte[] CRC16(byte[] data)
		{
			int num = data.Length;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					crc = (ushort)((byte)(crc >> 8) | (crc << 8));
					crc ^= data[i];
					crc ^= (ushort)((byte)(crc & 0xFF) >> 4);
					crc ^= (ushort)(crc << 8 << 4);
					crc ^= (ushort)((crc & 0xFF) << 4 << 1);
				}
				byte b = (byte)((crc & 0xFF00) >> 8);
				byte b2 = (byte)(crc & 0xFF);
				return new byte[2] { b, b2 };
			}
			return new byte[2];
		}

		public static string GetProductNo()
		{
			string result = "";
			foreach (ManagementObject item in new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem").Get())
			{
				foreach (PropertyData property in item.Properties)
				{
					if (property.Name == "SystemSKUNumber")
					{
						result = property.Value.ToString();
					}
				}
			}
			return result;
		}

		public static bool IsBladeKB()
		{
			int num = ((updateInfo.CurDevIndex >= 0) ? updateInfo.GetDevType(updateInfo.CurDevIndex) : updateInfo.GetDevType(1));
			if (num == 10)
			{
				return true;
			}
			return false;
		}
	}
}
