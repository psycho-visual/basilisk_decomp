using System.Xml.Linq;
using Newtonsoft.Json;

namespace Razer.ActionService
{
	public class TosConsentDetails : IRazerSerializable
	{
		[JsonProperty("has_consent")]
		public bool Consented { get; set; }

		public string Scope { get; set; }

		[JsonProperty("consent_url")]
		public string ConsentUrl { get; set; }

		public string ServiceCode { get; set; }

		public RazerApps App { get; set; }

		public TosConsentDetails()
		{
		}

		public TosConsentDetails(XDocument doc)
			: this(doc.Element("TosConsentDetails"))
		{
		}

		public TosConsentDetails(XElement element)
		{
			Consented = (bool)element.Element("Consented");
			Scope = (string)element.Element("Scope");
			ConsentUrl = (string)element.Element("ConsentUrl");
			ServiceCode = (string)element.Element("ServiceCode");
			App = (RazerApps)(int)element.Element("App");
		}

		public XElement Serialize()
		{
			return new XElement("TosConsentDetails", new XElement("Consented", Consented), new XElement("Scope", Scope), new XElement("ConsentUrl", ConsentUrl), new XElement("ServiceCode", ServiceCode), new XElement("App", (int)App));
		}
	}
}
