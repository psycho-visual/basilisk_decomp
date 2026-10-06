using System.Xml.Linq;
using Newtonsoft.Json;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class NewsletterSubscription : IRazerSerializable
	{
		[JsonProperty("app_id")]
		public string Id { get; set; }

		[JsonProperty("app_name")]
		public string Name { get; set; }

		[JsonProperty("newsletter")]
		[JsonConverter(typeof(BoolConverter))]
		public bool Subscribed { get; set; }

		[JsonProperty("check")]
		[JsonConverter(typeof(BoolConverter))]
		private bool Check => Subscribed;

		public NewsletterSubscription()
		{
		}

		public NewsletterSubscription(string name, bool subscribed)
		{
			Name = name;
			Subscribed = subscribed;
		}

		public bool ShouldSerializeSubscribed()
		{
			return false;
		}

		public bool ShouldSerializeId()
		{
			return false;
		}

		public NewsletterSubscription(XDocument doc)
			: this(doc.Element("NewsletterSubscription"))
		{
		}

		public NewsletterSubscription(XElement element)
		{
			Id = (string)element.Element("Id");
			Name = (string)element.Element("Name");
			Subscribed = (bool)element.Element("Subscribed");
		}

		public XElement Serialize()
		{
			return new XElement("NewsletterSubscription", new XElement("Id", Id), new XElement("Name", Name), new XElement("Subscribed", Subscribed));
		}
	}
}
