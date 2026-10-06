using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class SettingReadResult : IRazerSerializable
	{
		public RzSetting Setting { get; private set; }

		public LoadResult ResultLocal { get; private set; }

		public LoadResult ResultServer { get; private set; }

		public bool HasConflict
		{
			get
			{
				if (ResultLocal != LoadResult.Conflicted)
				{
					return ResultServer == LoadResult.Conflicted;
				}
				return true;
			}
		}

		public bool Success
		{
			get
			{
				if (ResultLocal == LoadResult.Failed_DataNotFound && (ResultServer == LoadResult.Failed_DataNotFound || ResultServer == LoadResult.Not_Retrieved))
				{
					return false;
				}
				bool num = ResultLocal == LoadResult.Success || ResultLocal == LoadResult.Failed_DataNotFound;
				bool flag = ResultServer == LoadResult.Success || ResultServer == LoadResult.Failed_DataNotFound || ResultServer == LoadResult.Not_Retrieved;
				return num && flag;
			}
		}

		public bool NotFound
		{
			get
			{
				if (ResultLocal == LoadResult.Failed_DataNotFound)
				{
					if (ResultServer != LoadResult.Failed_DataNotFound)
					{
						return ResultServer == LoadResult.Not_Retrieved;
					}
					return true;
				}
				return false;
			}
		}

		public SettingReadResult(LoadResult localResult, LoadResult serverResult, RzSetting setting)
		{
			Setting = setting;
			ResultLocal = localResult;
			ResultServer = serverResult;
		}

		public SettingReadResult(XDocument doc)
			: this(doc.Element("SettingReadResult"))
		{
		}

		public SettingReadResult(XElement element)
		{
			Setting = new RzSetting(element.Element("Setting"));
			LoadResult result = LoadResult.Failed_Unknown;
			Enum.TryParse<LoadResult>((string)element.Element("ResultServer"), out result);
			ResultServer = result;
			LoadResult result2 = LoadResult.Failed_Unknown;
			Enum.TryParse<LoadResult>((string)element.Element("ResultLocal"), out result2);
			ResultLocal = result2;
		}

		public XElement Serialize()
		{
			return new XElement("SettingReadResult", Setting.Serialize(), new XElement("ResultLocal", ResultLocal), new XElement("ResultServer", ResultServer));
		}

		public override string ToString()
		{
			return $"SettingReadResult: \"Setting\"=\"{Setting}\", \"ResultLocal\"=\"{ResultLocal}\", \"ResultServer\"=\"{ResultServer}\"";
		}
	}
}
