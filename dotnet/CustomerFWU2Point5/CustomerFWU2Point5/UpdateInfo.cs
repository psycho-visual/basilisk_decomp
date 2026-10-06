using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Windows.Forms;

namespace CustomerFWU2Point5
{
	public class UpdateInfo
	{
		private ResourceSet rs = new ResourceSet(Common.resfile);

		private bool internalengnieer;

		private ushort uDataPacketSize = 8;

		private ushort uPageSize = 512;

		private bool logfile;

		private int curdevidx = -1;

		private string strActDevFWVer;

		private string strActFlashFWVer;

		private int iSameDevVersion = -1;

		public const uint RETRY_TIMES = 3u;

		private int dongleupdateretry;

		private int headsetupdateretry;

		private int pairretry;

		private int iSameFlashVer = -1;

		private int supportdevnum;

		private bool backtodefault;

		public bool InternalEngnieer
		{
			get
			{
				return internalengnieer;
			}
			set
			{
				internalengnieer = value;
			}
		}

		public ushort DataPacketSize
		{
			get
			{
				return uDataPacketSize;
			}
			set
			{
				uDataPacketSize = value;
			}
		}

		public ushort PageSize
		{
			get
			{
				return uPageSize;
			}
			set
			{
				uPageSize = value;
			}
		}

		public bool LogFile
		{
			get
			{
				return logfile;
			}
			set
			{
				logfile = value;
			}
		}

		public int CurDevIndex
		{
			get
			{
				return curdevidx;
			}
			set
			{
				curdevidx = value;
			}
		}

		public string ActDevFWVer
		{
			get
			{
				return strActDevFWVer;
			}
			set
			{
				strActDevFWVer = value;
			}
		}

		public string ActFlashFWVer
		{
			get
			{
				return strActFlashFWVer;
			}
			set
			{
				strActFlashFWVer = value;
			}
		}

		public int DevSameVer
		{
			get
			{
				return iSameDevVersion;
			}
			set
			{
				iSameDevVersion = value;
			}
		}

		public int DongleRetry
		{
			get
			{
				return dongleupdateretry;
			}
			set
			{
				dongleupdateretry = value;
			}
		}

		public int HeadsetRetry
		{
			get
			{
				return headsetupdateretry;
			}
			set
			{
				headsetupdateretry = value;
			}
		}

		public int PairRetry
		{
			get
			{
				return pairretry;
			}
			set
			{
				pairretry = value;
			}
		}

		public int FlashSameVer
		{
			get
			{
				return iSameFlashVer;
			}
			set
			{
				iSameFlashVer = value;
			}
		}

		public int SupportDevCount => supportdevnum;

		public bool BackToDefault
		{
			get
			{
				return backtodefault;
			}
			set
			{
				backtodefault = value;
			}
		}

		public UpdateInfo()
		{
			if (rs.GetObject("BacktoDefault") == null)
			{
				backtodefault = false;
			}
			else if (Convert.ToInt32(rs.GetObject("BacktoDefault")) == 1)
			{
				backtodefault = true;
			}
			else
			{
				backtodefault = false;
			}
			if (rs.GetObject("DevBgSize") != null)
			{
				int num = Convert.ToInt32(rs.GetObject("DevBgSize"));
				string text = rs.GetObject("DevBgExtName").ToString();
				string text2 = Path.GetDirectoryName(Application.ExecutablePath) + "\\background" + text;
				BinaryWriter binaryWriter = new BinaryWriter(new FileInfo(text2).Create());
				int num2 = 0;
				while (num2 < num)
				{
					byte[] buffer = (byte[])rs.GetObject("DevBg" + num2++);
					binaryWriter.Write(buffer);
				}
				binaryWriter.Close();
				Common.background = Image.FromFile(text2);
			}
			else
			{
				Common.background = null;
			}
			if (rs.GetObject("DeviceNum") == null)
			{
				supportdevnum = 0;
			}
			else
			{
				supportdevnum = Convert.ToInt32(rs.GetObject("DeviceNum"));
			}
			if (rs.GetObject("Internal") != null)
			{
				internalengnieer = false;
			}
			else if (Convert.ToInt32(rs.GetObject("Internal")) == 1)
			{
				internalengnieer = true;
			}
			else
			{
				internalengnieer = false;
			}
			if (Convert.ToInt32(rs.GetObject("LogFile")) == 1)
			{
				logfile = true;
			}
			else
			{
				logfile = false;
			}
			if (rs.GetObject("DummyUpdater") != null)
			{
				Common.fordummy = Convert.ToBoolean(rs.GetObject("DummyUpdater"));
			}
			else
			{
				Common.fordummy = false;
			}
		}

		~UpdateInfo()
		{
			rs.Close();
		}

		public string GetVID(int devidx)
		{
			string text = "";
			if (devidx < 0)
			{
				return rs.GetObject("VID" + 1).ToString();
			}
			if (supportdevnum == 0)
			{
				return rs.GetObject("VID").ToString();
			}
			return rs.GetObject("VID" + devidx).ToString();
		}

		public string GetPID(int devidx)
		{
			string text = "";
			if (devidx < 0)
			{
				return rs.GetObject("PID" + 1).ToString();
			}
			if (supportdevnum == 0)
			{
				return rs.GetObject("PID").ToString();
			}
			return rs.GetObject("PID" + devidx).ToString();
		}

		public string GetBLVID(int devidx)
		{
			string text = "";
			if (devidx < 0)
			{
				return rs.GetObject("BLVID" + 1).ToString();
			}
			if (supportdevnum == 0)
			{
				return rs.GetObject("BLVID").ToString();
			}
			return rs.GetObject("BLVID" + devidx).ToString();
		}

		public string GetBLPID(int devidx)
		{
			string text = "";
			if (devidx < 0)
			{
				return rs.GetObject("BLPID" + 1).ToString();
			}
			if (supportdevnum == 0)
			{
				return rs.GetObject("BLPID").ToString();
			}
			return rs.GetObject("BLPID" + devidx).ToString();
		}

		public string GetBLBCDDevPID(int devidx)
		{
			string text = "";
			if (devidx < 0)
			{
				return rs.GetObject("BCDPID_BL" + 1).ToString();
			}
			if (supportdevnum == 0)
			{
				return rs.GetObject("BCDPID_BL").ToString();
			}
			return rs.GetObject("BCDPID_BL" + devidx).ToString();
		}

		public int GetDevType(int devidx)
		{
			int num = 0;
			if (devidx < 0)
			{
				return Convert.ToInt32(rs.GetObject("DevType" + 1));
			}
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("DevType"));
			}
			return Convert.ToInt32(rs.GetObject("DevType" + devidx));
		}

		public string GetDeviceName(int devidx)
		{
			string text = "";
			text = ((devidx < 0) ? rs.GetObject("DevName" + 1).ToString() : ((supportdevnum != 0) ? rs.GetObject("DevName" + devidx).ToString() : rs.GetObject("DevName").ToString()));
			if (Common.updateInfo.GetPID(devidx) == "0C00" && Common.devedition == 1)
			{
				return "烈焰神虫织物版";
			}
			if (Common.updateInfo.GetPID(devidx) == "0253")
			{
				string productNo = Common.GetProductNo();
				if (productNo.ElementAt(productNo.Length - 2) == 'M')
				{
					return "Blade 15 雷蛇灵刃 15 工作室版";
				}
			}
			return text;
		}

		public string GetModelNumber(string pid)
		{
			string result = "";
			switch (pid)
			{
			case "023A":
				result = "RZ09-0288";
				break;
			case "0234":
				result = "RZ09-0287";
				break;
			case "0245":
				result = "RZ09-0301";
				break;
			case "0255":
				result = "RZ09-0328";
				break;
			case "0253":
				result = "RZ09-0330";
				break;
			case "0256":
				result = "RZ09-0329";
				break;
			case "026A":
				result = "RZ09-0357";
				break;
			case "0270":
				result = "RZ09-0370";
				break;
			}
			return result;
		}

		public string GetProductName(int devidx)
		{
			string text = "";
			text = ((devidx < 0) ? rs.GetObject("ProductName" + 1).ToString() : ((supportdevnum != 0) ? rs.GetObject("ProductName" + devidx).ToString() : rs.GetObject("ProductName").ToString()));
			if (Common.newedition)
			{
				text = "Basilisk Essential Crossfire Edition";
			}
			if (Common.updateInfo.GetPID(devidx) == "0C00" && Common.devedition == 1)
			{
				return "Firefly Cloth Edition";
			}
			if (Common.updateInfo.GetPID(devidx) == "0253")
			{
				string productNo = Common.GetProductNo();
				if (productNo.ElementAt(productNo.Length - 2) == 'M')
				{
					return "Blade 15 Studio Edition (Early 2020)";
				}
			}
			return text;
		}

		public int GetFWType(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("FWType"));
			}
			return Convert.ToInt32(rs.GetObject("FWType" + devidx));
		}

		public int GetDevReportType(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("ReportType"));
			}
			return Convert.ToInt32(rs.GetObject("ReportType" + devidx));
		}

		public int GetFeatureRptLen(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("FeatureReportLen"));
			}
			return Convert.ToInt32(rs.GetObject("FeatureReportLen" + devidx));
		}

		public int GetInputRptLen(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				if (rs.GetObject("InputReportLen") != null && rs.GetObject("InputReportLen").ToString() != "")
				{
					return Convert.ToInt32(rs.GetObject("InputReportLen"));
				}
				return 0;
			}
			return Convert.ToInt32(rs.GetObject("InputReportLen" + devidx));
		}

		public int GetOutputRptLen(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				if (rs.GetObject("OutputReportLen") != null && rs.GetObject("OutputReportLen").ToString() != "")
				{
					return Convert.ToInt32(rs.GetObject("OutputReportLen"));
				}
				return 0;
			}
			return Convert.ToInt32(rs.GetObject("OutputReportLen" + devidx));
		}

		public int GetDevFWType(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("FWType"));
			}
			return Convert.ToInt32(rs.GetObject("FWType" + devidx));
		}

		public string GetDevFWVer(int devidx)
		{
			string text = "";
			if (supportdevnum == 0)
			{
				return rs.GetObject("DevFWVer").ToString();
			}
			return rs.GetObject("DevFWVer" + devidx).ToString();
		}

		public float GetBLVer(int devidx)
		{
			float num = 0f;
			CultureInfo provider = new CultureInfo("en-US");
			if (supportdevnum == 0)
			{
				return Convert.ToSingle(rs.GetObject("BLVER"), provider);
			}
			return Convert.ToSingle(rs.GetObject("BLVER" + devidx), provider);
		}

		public bool IsVerifyCheckSum(int devidx)
		{
			int num = 0;
			num = ((supportdevnum != 0) ? Convert.ToInt32(rs.GetObject("VerifyChecksum" + devidx)) : Convert.ToInt32(rs.GetObject("VerifyChecksum")));
			if (num == 1)
			{
				return true;
			}
			return false;
		}

		public bool IsUpdateFlashFW(int devidx)
		{
			int num = 0;
			num = ((supportdevnum != 0) ? Convert.ToInt32(rs.GetObject("FlashFWUpdate" + devidx)) : Convert.ToInt32(rs.GetObject("FlashFWUpdate")));
			if (num == 1)
			{
				return true;
			}
			return false;
		}

		public int GetFlashFWType(int devidx)
		{
			int num = 0;
			if (supportdevnum == 0)
			{
				return Convert.ToInt32(rs.GetObject("FlashFWType"));
			}
			return Convert.ToInt32(rs.GetObject("FlashFWType" + devidx));
		}

		public string GetFlashFWVer(int devidx)
		{
			string text = "";
			if (supportdevnum == 0)
			{
				return rs.GetObject("FlashFWVer").ToString();
			}
			return rs.GetObject("FlashFWVer" + devidx).ToString();
		}

		public uint GetDevFWLineNum(int devidx)
		{
			uint num = 0u;
			if (supportdevnum == 0)
			{
				return Convert.ToUInt32(rs.GetObject("DevFWLineNum"));
			}
			return Convert.ToUInt32(rs.GetObject("Dev" + devidx + "FWLineNum"));
		}

		public string GetDevFWLine(int devidx, int linenum)
		{
			string text = "";
			if (supportdevnum == 0)
			{
				return rs.GetObject("DevFWLine" + linenum).ToString();
			}
			return rs.GetObject("Dev" + devidx + "FWLine" + linenum).ToString();
		}

		public uint GetFlashFWLineNum(int devidx)
		{
			uint num = 0u;
			if (supportdevnum == 0)
			{
				return Convert.ToUInt32(rs.GetObject("FlashFWLineNum"));
			}
			return Convert.ToUInt32(rs.GetObject("Flash" + devidx + "FWLineNum"));
		}

		public string GetFlashFWLine(int devidx, int linenum)
		{
			string text = "";
			if (supportdevnum == 0)
			{
				return rs.GetObject("FlashFWLine" + linenum).ToString();
			}
			return rs.GetObject("Flash" + devidx + "FWLine" + linenum).ToString();
		}
	}
}
