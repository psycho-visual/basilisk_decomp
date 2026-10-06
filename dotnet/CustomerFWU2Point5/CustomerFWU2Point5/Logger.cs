using System;
using System.IO;
using System.Windows.Forms;

namespace CustomerFWU2Point5
{
	internal class Logger
	{
		public const short LOG_NULL = 0;

		public const short LOG_INFO = 1;

		public const short LOG_ERROR = 2;

		public const short LOG_WARNING = 3;

		private static Logger instance = null;

		private static string logFile = null;

		private static string logFileName = string.Format("DeviceUpdater_{0}.log", DateTime.Now.ToShortDateString().Replace("/", "_"));

		private Logger()
		{
			logFile = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), logFileName);
		}

		public static Logger getInstance()
		{
			if (instance == null)
			{
				instance = new Logger();
				if (Common.LogEnabled)
				{
					try
					{
						using (StreamWriter streamWriter = File.CreateText(logFile))
						{
							streamWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} : ------------ Starting {Common.updateInfo.GetProductName(Common.updateInfo.CurDevIndex)} Update ------------");
						}
					}
					catch
					{
						try
						{
							Directory.CreateDirectory("D:\\temp\\log");
							logFile = Path.Combine("D:\\temp\\log", logFileName);
							using (StreamWriter streamWriter2 = File.CreateText(logFile))
							{
								streamWriter2.WriteLine(DateTime.Now.ToLongTimeString() + " : ------------ Starting Update ------------");
							}
						}
						catch
						{
						}
					}
				}
			}
			return instance;
		}

		public void setLogFile(string fileName)
		{
			logFile = fileName;
		}

		public void writeLog(string msg, short msgType)
		{
			if (!Common.LogEnabled)
			{
				return;
			}
			string text = DateTime.Now.ToLongTimeString();
			using (StreamWriter streamWriter = File.AppendText(logFile))
			{
				switch (msgType)
				{
				case 1:
					streamWriter.WriteLine(text + " : Info >> " + msg);
					break;
				case 2:
					streamWriter.WriteLine(text + " : ERROR >> " + msg);
					break;
				case 3:
					streamWriter.WriteLine(text + " : Warning >> " + msg);
					break;
				default:
					streamWriter.WriteLine(msg);
					break;
				}
				streamWriter.Close();
			}
		}
	}
}
