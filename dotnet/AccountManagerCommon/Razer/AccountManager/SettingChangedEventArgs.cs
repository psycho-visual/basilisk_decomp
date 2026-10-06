using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class SettingChangedEventArgs : EventArgs, IRazerSerializable
	{
		public GlobalSetting Name { get; private set; }

		public RzSetting Setting { get; private set; }

		public SettingChangedEventArgs(RzSetting setting)
		{
			Setting = setting;
			Name = setting.Name.ParseAs<GlobalSetting>();
		}

		public SettingChangedEventArgs(XDocument doc)
			: this(doc.Element("SettingChangedEventArgs"))
		{
		}

		private SettingChangedEventArgs(XElement element)
		{
			Setting = new RzSetting(element.Element("Setting"));
			string str = (string)element.Element("Name");
			Name = str.ParseAs<GlobalSetting>();
		}

		public XElement Serialize()
		{
			return new XElement("SettingChangedEventArgs", new XElement("Name", Name.GetDescription()), Setting.Serialize());
		}
	}
}
