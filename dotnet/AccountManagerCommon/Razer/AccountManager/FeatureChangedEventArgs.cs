using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class FeatureChangedEventArgs : EventArgs, IRazerSerializable
	{
		public string ClientId { get; private set; }

		public string Feature { get; private set; }

		public bool IsEnabled { get; private set; }

		public FeatureChangedEventArgs(string clientId, string feature, bool enabled)
		{
			ClientId = clientId;
			Feature = feature;
			IsEnabled = enabled;
		}

		public FeatureChangedEventArgs(XDocument doc)
			: this(doc.Element("FeatureChangedEventArgs"))
		{
		}

		private FeatureChangedEventArgs(XElement element)
		{
			Feature = (string)element.Element("Feature");
			IsEnabled = (bool)element.Element("IsEnabled");
			ClientId = (string)element.Element("ClientId");
		}

		public XElement Serialize()
		{
			return new XElement("FeatureChangedEventArgs", new XElement("Feature", Feature), new XElement("IsEnabled", IsEnabled), new XElement("ClientId", ClientId));
		}
	}
}
