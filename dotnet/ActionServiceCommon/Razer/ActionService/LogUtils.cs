using System;
using System.Diagnostics;
using System.IO;
using log4net;
using log4net.Config;

namespace Razer.ActionService
{
	public static class LogUtils
	{
		public static void SetupLogging(string appName)
		{
			Common.UseSeperateLogging = false;
			SetupLogging(appName, "config.log4net");
		}

		public static void SetupLogging(string appName, string configFile)
		{
			GlobalContext.Properties["LogPath"] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			GlobalContext.Properties["Application"] = appName;
			GlobalContext.Properties["LogFileName"] = appName + "_" + Environment.UserName + ".log";
			string text = Path.Combine(new FileInfo(Process.GetCurrentProcess().MainModule.FileName).DirectoryName, configFile);
			if (File.Exists(text))
			{
				XmlConfigurator.ConfigureAndWatch(new FileInfo(text));
			}
		}
	}
}
