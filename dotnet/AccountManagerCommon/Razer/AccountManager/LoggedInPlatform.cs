using System.Net;
using System.Xml.Linq;
using Newtonsoft.Json;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LoggedInPlatform : IRazerSerializable
	{
		public string Id { get; set; }

		[JsonProperty("ip_address")]
		[JsonConverter(typeof(IpConverter))]
		public IPAddress Address { get; set; }

		public string Country { get; set; }

		[JsonProperty("matched")]
		public bool IsCurrentDevice { get; set; }

		public LoggedInPlatform()
		{
		}

		public LoggedInPlatform(XDocument doc)
			: this(doc.Element("LoggedInPlatform"))
		{
		}

		public LoggedInPlatform(XElement element)
		{
			Id = (string)element.Element("Id");
			if (!string.IsNullOrEmpty((string)element.Element("Address")))
			{
				Address = IPAddress.Parse((string)element.Element("Address"));
			}
			Country = (string)element.Element("Country");
		}

		public XElement Serialize()
		{
			return new XElement("LoggedInPlatform", new XElement("Id", Id), new XElement("Address", Address?.ToString()), new XElement("Country", Country));
		}
	}
}
