using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class NewsletterDetails : IRazerSerializable
	{
		public string Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string Addition_Description { get; set; }

		public bool Default_Checked { get; set; }

		public int Order { get; set; }

		public NewsletterDetails()
		{
		}

		public NewsletterDetails(XDocument doc)
			: this(doc.Element("NewsletterDetails"))
		{
		}

		public NewsletterDetails(XElement element)
		{
			Id = (string)element.Element("Id");
			Name = (string)element.Element("Name");
			Description = (string)element.Element("Description");
			Addition_Description = (string)element.Element("Addition_Description");
			Default_Checked = (bool)element.Element("Default_Checked");
			Order = (int)element.Element("Order");
		}

		public XElement Serialize()
		{
			return new XElement("NewsletterDetails", new XElement("Id", Id), new XElement("Name", Name), new XElement("Description", Description), new XElement("Addition_Description", Addition_Description), new XElement("Default_Checked", Default_Checked), new XElement("Order", Order));
		}
	}
}
