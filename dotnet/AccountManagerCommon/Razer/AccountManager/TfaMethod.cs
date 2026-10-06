using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class TfaMethod : IRazerSerializable
	{
		public string Id { get; private set; }

		public string Alias { get; private set; }

		public string Name { get; private set; }

		public TfaType Type { get; private set; }

		public bool Verified { get; set; }

		public bool Active { get; set; }

		public bool Primary { get; set; }

		public TfaMethod(string name, TfaType type, bool verified, bool active)
		{
			Name = name;
			if (string.IsNullOrEmpty(Alias))
			{
				Alias = Name;
			}
			Type = type;
			Verified = verified;
			Active = active;
		}

		public TfaMethod(XDocument doc)
			: this(doc.Element("method"))
		{
		}

		public TfaMethod(XElement element)
		{
			Id = (string)element.Element("id");
			Name = (string)element.Element("name");
			string text = (string)element.Element("alias");
			Alias = (string.IsNullOrEmpty(text) ? Name : text);
			XElement xElement = element.Element("type");
			if (xElement != null)
			{
				if (xElement.Value.Equals("phone"))
				{
					Type = TfaType.Phone;
				}
				else if (xElement.Value.Equals("authenticator"))
				{
					Type = TfaType.Authenticator;
				}
				else
				{
					Type = TfaType.Undefined;
				}
			}
			xElement = element.Element("state");
			if (xElement != null)
			{
				Verified = xElement.Value.Equals("verified");
			}
			xElement = element.Element("status");
			if (xElement != null)
			{
				Active = xElement.Value.Equals("active");
			}
			xElement = element.Element("primary");
			if (xElement != null)
			{
				Primary = xElement.Value.Equals("1");
			}
		}

		public XElement Serialize()
		{
			return new XElement("method", new XElement("id", Id), new XElement("alias", Alias), new XElement("name", Name), new XElement("type", Type.ToString().ToLower()), new XElement("state", Verified ? "verified" : "new"), new XElement("status", Active ? "active" : "inactive"), new XElement("primary", Primary ? "1" : "0"));
		}
	}
}
