using System;
using System.IO;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class SettingDefinition : IRazerSerializable
	{
		public string Name { get; set; }

		public string Path { get; set; }

		public DateTime Timestamp { get; set; }

		internal string DownloadUrl { get; set; }

		public SettingDefinition(string path, string name)
			: this(path, name, DateTime.Now)
		{
		}

		public SettingDefinition(string path, string name, DateTime timestamp)
		{
			Path = path;
			Name = name;
			Timestamp = timestamp;
		}

		public SettingDefinition(FileInfo info)
		{
			Name = info.Name;
			Timestamp = info.LastWriteTime;
		}

		public SettingDefinition(XDocument doc)
			: this(doc.Element("Setting"))
		{
		}

		public SettingDefinition(XElement element)
		{
			Name = (string)element.Element("Name");
			Path = (string)element.Element("Path");
			DownloadUrl = (string)element.Element("Data");
			Timestamp = ((string)element.Element("SaveTimestamp")).AsUnixTime();
		}

		public XElement Serialize()
		{
			return new XElement("Setting", new XElement("Name", Name), new XElement("Path", Path), new XElement("Data", DownloadUrl), new XElement("SaveTimestamp", Timestamp.ToUnixTime()));
		}

		public override string ToString()
		{
			return $"SettingDefinition: \"Name\"=\"{Name}\", \"Path\"=\"{Path}\", \"DownloadUrl\"=\"{DownloadUrl}\", \"Timestamp\"=\"{Timestamp.ToUnixTime()}\"";
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is SettingDefinition settingDefinition))
			{
				return false;
			}
			if (Name != settingDefinition.Name)
			{
				return false;
			}
			if (Path != settingDefinition.Path)
			{
				return false;
			}
			if ((int)Timestamp.Subtract(settingDefinition.Timestamp).TotalSeconds != 0)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(SettingDefinition lhs, SettingDefinition rhs)
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

		public static bool operator !=(SettingDefinition lhs, SettingDefinition rhs)
		{
			return !(lhs == rhs);
		}
	}
}
