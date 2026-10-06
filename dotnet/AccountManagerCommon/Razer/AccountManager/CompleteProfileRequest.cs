using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class CompleteProfileRequest : IRazerSerializable
	{
		public string RazerId { get; set; }

		public List<NewsletterSubscription> Subscriptions { get; set; } = new List<NewsletterSubscription>();

		public CompleteProfileRequest()
		{
		}

		public CompleteProfileRequest(string razerId)
		{
			RazerId = razerId;
		}

		public CompleteProfileRequest(XDocument doc)
			: this(doc.Element("CompleteProfileRequest"))
		{
		}

		private CompleteProfileRequest(XElement element)
		{
			RazerId = (string)element.Element("RazerId");
			foreach (XElement item in element.Element("Subscriptions").Elements())
			{
				Subscriptions.Add(new NewsletterSubscription(item));
			}
		}

		public XElement Serialize()
		{
			return new XElement("CompleteProfileRequest", new XElement("RazerId", RazerId), new XElement("Subscriptions", Subscriptions.Select((NewsletterSubscription x) => x.Serialize())));
		}
	}
}
