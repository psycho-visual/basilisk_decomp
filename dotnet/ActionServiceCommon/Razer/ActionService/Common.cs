using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using log4net;
using log4net.Config;
using log4net.Repository;

namespace Razer.ActionService
{
	public class Common
	{
		private static readonly string m_productionPipeName = "{CD7C71F0-A5B9-4F24-897A-DF6E20E43B96}";

		private static readonly string m_debugPipeName = "{DBG-CD7C71F0-A5B9-4F24-897A-DF6E20E43B96}";

		private static readonly string m_nacClientProductionPipeName = "{E7A6CCA9-FF3F-4741-8E66-1127EE39471D}";

		private static readonly string m_nacClientDebugPipeName = "{DBG-E7A6CCA9-FF3F-4741-8E66-1127EE39471D}";

		private static readonly string m_nacProductionPipeName = "{FC828A97-C116-453D-BD88-AD471496E03C}";

		private static readonly string m_nacDebugPipeName = "{DBG-FC828A97-C116-453D-BD88-AD471496E03C}";

		private static readonly object setupLock = new object();

		private static bool UseDebugPipes => false;

		public static string PipeName
		{
			get
			{
				if (UseDebugPipes)
				{
					return m_debugPipeName;
				}
				return m_productionPipeName;
			}
		}

		public static string NacClientPipeName
		{
			get
			{
				if (UseDebugPipes)
				{
					return m_nacClientDebugPipeName;
				}
				return m_nacClientProductionPipeName;
			}
		}

		public static string NacPipeName
		{
			get
			{
				if (UseDebugPipes)
				{
					return m_nacDebugPipeName;
				}
				return m_nacProductionPipeName;
			}
		}

		public static bool UseSeperateLogging { get; set; } = true;

		public static ILog GetLogger(string name)
		{
			if (UseSeperateLogging)
			{
				SetupLogging();
				return LogManager.GetLogger("Razer Central", name);
			}
			return LogManager.GetLogger(name);
		}

		public static void SetupLogging()
		{
			try
			{
				ILoggerRepository loggerRepository = LogManager.CreateRepository("Razer Central");
				if (!loggerRepository.Configured)
				{
					string fileName = Process.GetCurrentProcess().MainModule.FileName;
					string directoryName = new FileInfo(fileName).DirectoryName;
					string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
					string text = Path.Combine(directoryName, "config.log4net");
					GlobalContext.Properties["LogPath"] = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
					GlobalContext.Properties["Application"] = "Razer Central";
					GlobalContext.Properties["LogFileName"] = $"{fileNameWithoutExtension}_{Environment.UserName} Client.log";
					if (File.Exists(text))
					{
						XmlConfigurator.ConfigureAndWatch(loggerRepository, new FileInfo(text));
						return;
					}
					string xml = "<log4net> \r\n<appender name='RollingLogFileAppender' type='log4net.Appender.RollingFileAppender,log4net'>\r\n<file type='log4net.Util.PatternString' value='%property{LogPath}\\Razer\\%property{Application}\\Logs\\%property{LogFileName}' />\r\n<param name='AppendToFile' value='true' /> \r\n<param name='MaxSizeRollBackups' value='3' /> \r\n<param name='MaximumFileSize' value='5MB' /> \r\n<param name='RollingStyle' value='Size' /> \r\n<param name='StaticLogFileName' value='true' /> \r\n<lockingModel type='log4net.Appender.FileAppender+MinimalLock' />\r\n\r\n    \r\n<layout type='log4net.Layout.PatternLayout,log4net'> \r\n    <param name='ConversionPattern' value='%d [%t] %-5p %c [%x] - %m%n' /> \r\n</layout> \r\n</appender> \r\n  \r\n<root> \r\n<level value='DEBUG' /> \r\n<appender-ref ref='RollingLogFileAppender' /> \r\n</root> \r\n</log4net>   \r\n";
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.XmlResolver = null;
					xmlDocument.LoadXml(xml);
					XmlConfigurator.Configure(loggerRepository, xmlDocument.DocumentElement);
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
