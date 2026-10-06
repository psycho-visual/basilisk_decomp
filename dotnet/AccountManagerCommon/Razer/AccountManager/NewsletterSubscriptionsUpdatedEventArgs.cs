using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class NewsletterSubscriptionsUpdatedEventArgs : EventArgs, IRazerSerializable
	{
		public IEnumerable<NewsletterSubscription> Subscriptions { get; set; }

		public NewsletterSubscriptionsUpdatedEventArgs(IEnumerable<NewsletterSubscription> subscriptions)
		{
			Subscriptions = subscriptions;
		}

		public NewsletterSubscriptionsUpdatedEventArgs(XDocument doc)
			: this(doc.Element("NewsletterSubscriptionsUpdatedEventArgs"))
		{
		}

		private NewsletterSubscriptionsUpdatedEventArgs(XElement element)
		{
			List<NewsletterSubscription> list = new List<NewsletterSubscription>();
			foreach (XElement item in element.Element("Subscriptions").Elements("NewsletterSubscription"))
			{
				list.Add(new NewsletterSubscription(item));
			}
			Subscriptions = list;
		}

		public XElement Serialize()
		{
			return new XElement("NewsletterSubscriptionsUpdatedEventArgs", new XElement("Subscriptions", Subscriptions.Select((NewsletterSubscription x) => x.Serialize())));
		}
	}
}
