using System;
using System.Xml.Linq;

namespace Razer.AccountManager
{
	public class DataSyncItem
	{
		public enum SyncAction
		{
			Unknown,
			None,
			Upload,
			Download,
			Add,
			DeleteServer,
			DeleteLocal,
			Conflicted
		}

		public string Path { get; private set; }

		public string Name { get; private set; }

		public DateTime? ServerTime { get; set; }

		internal string DownloadUrl { get; set; }

		public DateTime? LocalTime { get; set; }

		public SyncAction Action { get; set; }

		public DataSyncItem(string path, string name)
		{
			Path = path;
			Name = name;
			Action = SyncAction.Unknown;
			DownloadUrl = string.Empty;
		}

		public DataSyncItem(XElement element)
		{
			Path = (string)element.Element("Path");
			Name = (string)element.Element("Name");
			DownloadUrl = (string)element.Element("DownloadUrl");
			XElement xElement = element.Element("ServerTime");
			if (xElement != null)
			{
				ServerTime = (DateTime)xElement;
			}
			xElement = element.Element("LocalTime");
			if (xElement != null)
			{
				LocalTime = (DateTime)xElement;
			}
			if (Enum.TryParse<SyncAction>(((string)element.Element("Action")) ?? string.Empty, ignoreCase: true, out var result))
			{
				Action = result;
			}
			else
			{
				Action = SyncAction.Unknown;
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("DataSyncItem", new XElement("Path", Path), new XElement("Name", Name), new XElement("DownloadUrl", DownloadUrl), new XElement("Action", Action));
			if (ServerTime.HasValue)
			{
				xElement.Add(new XElement("ServerTime", ServerTime.Value));
			}
			if (LocalTime.HasValue)
			{
				xElement.Add(new XElement("LocalTime", LocalTime.Value));
			}
			return xElement;
		}

		public override string ToString()
		{
			return $"DataSyncItem: \"Path\"=\"{Path}\", \"Name\"=\"{Name}\", \"DownloadUrl\"=\"{DownloadUrl}\", \"Action\"=\"{Action}\"";
		}

		public override int GetHashCode()
		{
			return Path.GetHashCode() ^ Name.GetHashCode() ^ ((!ServerTime.HasValue) ? DateTime.MinValue.GetHashCode() : ServerTime.GetHashCode()) ^ DownloadUrl.GetHashCode() ^ ((!LocalTime.HasValue) ? DateTime.MinValue.GetHashCode() : LocalTime.GetHashCode()) ^ (int)Action;
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is DataSyncItem dataSyncItem))
			{
				return false;
			}
			if (Path != dataSyncItem.Path)
			{
				return false;
			}
			if (Name != dataSyncItem.Name)
			{
				return false;
			}
			if (ServerTime != dataSyncItem.ServerTime)
			{
				return false;
			}
			if (DownloadUrl != dataSyncItem.DownloadUrl)
			{
				return false;
			}
			if (LocalTime != dataSyncItem.LocalTime)
			{
				return false;
			}
			if (Action != dataSyncItem.Action)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(DataSyncItem lhs, DataSyncItem rhs)
		{
			if ((object)lhs == rhs)
			{
				return true;
			}
			if ((object)lhs == null || (object)rhs == null)
			{
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(DataSyncItem lhs, DataSyncItem rhs)
		{
			return !(lhs == rhs);
		}
	}
}
