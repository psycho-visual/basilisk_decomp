using System;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class RzSetting : IRazerSerializable
	{
		public enum SettingEncoding
		{
			Unknown = -1,
			Text,
			Binary
		}

		private string m_name;

		private string m_path;

		private byte[] m_value;

		public string Name
		{
			get
			{
				try
				{
					return string.IsNullOrEmpty(m_name) ? m_name : System.IO.Path.GetFileName(m_name);
				}
				catch (Exception)
				{
					return string.Empty;
				}
			}
			set
			{
				try
				{
					m_name = System.IO.Path.GetFileName(value);
				}
				catch (Exception)
				{
					m_name = string.Empty;
				}
			}
		}

		public string Path
		{
			get
			{
				try
				{
					return m_path.FixDirectoryTraversal();
				}
				catch (Exception)
				{
					return string.Empty;
				}
			}
			set
			{
				try
				{
					m_path = value.FixDirectoryTraversal();
				}
				catch (Exception)
				{
					m_path = string.Empty;
				}
			}
		}

		public byte[] Value
		{
			get
			{
				return m_value;
			}
			set
			{
				m_value = value;
				Encoding = SettingEncoding.Binary;
			}
		}

		public string StringValue
		{
			get
			{
				if (Value == null)
				{
					return null;
				}
				using (MemoryStream stream = new MemoryStream(Value))
				{
					return new StreamReader(stream).ReadToEnd();
				}
			}
			set
			{
				m_value = System.Text.Encoding.UTF8.GetBytes(value);
				Encoding = SettingEncoding.Text;
			}
		}

		public int IntValue
		{
			get
			{
				int result = 0;
				int.TryParse(StringValue, out result);
				return result;
			}
			set
			{
				StringValue = value.ToString();
			}
		}

		public double DoubleValue
		{
			get
			{
				double result = 0.0;
				double.TryParse(StringValue, out result);
				return result;
			}
			set
			{
				StringValue = value.ToString();
			}
		}

		public bool BoolValue
		{
			get
			{
				return IntValue != 0;
			}
			set
			{
				IntValue = (value ? 1 : 0);
			}
		}

		public SettingEncoding Encoding { get; internal set; }

		public SettingDefinition Definition => new SettingDefinition(Path, Name);

		public RzSetting()
		{
			Encoding = SettingEncoding.Binary;
		}

		public RzSetting(SettingDefinition def)
			: this(def.Path, def.Name)
		{
		}

		public RzSetting(string path, string name)
			: this(path, name, (byte[])null)
		{
		}

		public RzSetting(string path, string name, byte[] value)
		{
			Path = path;
			Name = name;
			Value = value;
		}

		public RzSetting(string path, string name, string value)
		{
			Path = path;
			Name = name;
			StringValue = value;
		}

		public RzSetting(string path, string name, int value)
		{
			Path = path;
			Name = name;
			IntValue = value;
		}

		public RzSetting(string path, string name, double value)
		{
			Path = path;
			Name = name;
			DoubleValue = value;
		}

		public RzSetting(string path, string name, bool value)
		{
			Path = path;
			Name = name;
			BoolValue = value;
		}

		public RzSetting(XDocument doc)
			: this(doc.Element("Setting"))
		{
		}

		public RzSetting(XElement element)
		{
			Name = (string)element.Element("Name");
			Path = (string)element.Element("Path");
			Value = null;
			XElement xElement = element.Element("Value");
			if (xElement != null)
			{
				Value = Convert.FromBase64String((string)xElement);
			}
			SettingEncoding result = SettingEncoding.Text;
			if (Enum.TryParse<SettingEncoding>((string)element.Element("Encoding"), out result))
			{
				Encoding = result;
			}
			else
			{
				Encoding = SettingEncoding.Unknown;
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("Setting", new XElement("Path", Path), new XElement("Name", Name), new XElement("Encoding", Encoding));
			if (Value != null)
			{
				xElement.Add(new XElement("Value", Convert.ToBase64String(Value)));
			}
			return xElement;
		}

		public override string ToString()
		{
			string text = ((Value == null) ? null : Convert.ToBase64String(Value));
			if (text != null && text.Length > 100)
			{
				text = "[DATA TOO LARGE]";
			}
			return $"RzSetting: \"Path\"=\"{Path}\", \"Name\"=\"{Name}\", \"Encoding\"=\"{Encoding}\", \"Value\"=\"{text}\"";
		}

		public override int GetHashCode()
		{
			return (Path + Name).GetHashCode() ^ Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is RzSetting rzSetting))
			{
				return false;
			}
			if (Path != rzSetting.Path)
			{
				return false;
			}
			if (Name != rzSetting.Name)
			{
				return false;
			}
			if (Value != rzSetting.Value)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(RzSetting lhs, RzSetting rhs)
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

		public static bool operator !=(RzSetting lhs, RzSetting rhs)
		{
			return !(lhs == rhs);
		}
	}
}
