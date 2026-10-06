using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Razer.AccountManager
{
	public static class SerializationExtensions
	{
		public static void Write(this BinaryWriter writer, List<SettingDefinition> defs)
		{
			XDocument xDocument = new XDocument(new XElement("SettingDefinitionList", defs.Select((SettingDefinition x) => x.Serialize())));
			writer.Write(xDocument.ToString());
		}

		public static List<SettingDefinition> ReadSettingDefinitionList(this BinaryReader reader)
		{
			XDocument xDocument = XDocument.Parse(reader.ReadString());
			List<SettingDefinition> list = new List<SettingDefinition>();
			foreach (XElement item in xDocument.Descendants("Setting"))
			{
				list.Add(new SettingDefinition(item));
			}
			return list;
		}
	}
}
