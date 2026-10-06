using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Razer.ActionService
{
	public class PromptRequest : IRazerSerializable
	{
		public RazerApps RequestingApplication { get; set; }

		public PromptType Type { get; set; }

		public IDictionary<Languages, string> Message { get; set; } = new Dictionary<Languages, string>();

		public PromptRequest()
		{
		}

		public PromptRequest(XDocument doc)
			: this(doc.Element("PromptRequest"))
		{
		}

		private PromptRequest(XElement element)
		{
			RequestingApplication = (RazerApps)(int)element.Element("RequestingApplication");
			Type = (PromptType)(int)element.Element("Type");
			foreach (XElement item in element.Element("Message").Elements("Entry"))
			{
				Message.Add((Languages)(int)item.Element("Language"), (string)item.Element("Value"));
			}
		}

		public XElement Serialize()
		{
			return new XElement("PromptRequest", new XElement("RequestingApplication", (int)RequestingApplication), new XElement("Type", (int)Type), new XElement("Message", Message.Select((KeyValuePair<Languages, string> x) => new XElement("Entry", new XElement("Language", (int)x.Key), new XElement("Value", x.Value)))));
		}
	}
}
