using System;
using System.Linq;

namespace Razer.ActionService
{
	public static class Extensions
	{
		public static long ToUnixTime(this DateTime time)
		{
			return Convert.ToInt64(time.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds);
		}

		public static DateTime AsUnixTime(this string timeString)
		{
			try
			{
				if (string.IsNullOrWhiteSpace(timeString))
				{
					return DateTime.MaxValue;
				}
				double result = 0.0;
				double.TryParse(timeString, out result);
				return new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).AddSeconds(result).ToLocalTime();
			}
			catch
			{
				return DateTime.MaxValue;
			}
		}

		public static string FixDirectoryTraversal(this string path)
		{
			if (string.IsNullOrEmpty(path))
			{
				return path;
			}
			path = path.Replace("../", string.Empty).Replace("..\\", string.Empty);
			path = (path.All((char c) => c == '\\' || c == '/') ? string.Empty : path);
			return path;
		}
	}
}
