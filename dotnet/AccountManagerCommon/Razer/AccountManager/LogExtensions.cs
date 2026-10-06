using log4net;
using log4net.Appender;
using log4net.Repository.Hierarchy;

namespace Razer.AccountManager
{
	public static class LogExtensions
	{
		public static string LogFileName(this ILog logger)
		{
			string result = string.Empty;
			Logger root = (LogManager.GetRepository() as Hierarchy).Root;
			if (root.Appenders.Count > 0)
			{
				result = (root.Appenders[0] as FileAppender).File;
			}
			return result;
		}
	}
}
