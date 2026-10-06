using System;
using System.Xml.Linq;

namespace Razer.AccountManager
{
	public class AccountNotLinkedException : Exception
	{
		public string Email { get; set; }

		public string LinkKey { get; set; }

		public string RazerID { get; set; }

		public string AvatarUrl { get; set; }

		public bool AccountExists { get; set; }

		public AccountNotLinkedException()
			: base("This account is not linked to an existing Razer account.")
		{
		}

		public AccountNotLinkedException(string message, XDocument doc)
			: base(message)
		{
			XElement xElement = doc.Element("AccountNotLinkedException");
			Email = (string)xElement.Element("Email");
			LinkKey = (string)xElement.Element("LinkKey");
			RazerID = (string)xElement.Element("RazerID");
			AvatarUrl = (string)xElement.Element("AvatarUrl");
			AccountExists = (bool)xElement.Element("AccountExists");
		}

		public XElement Serialize()
		{
			return new XElement("AccountNotLinkedException", new XElement("Email", Email), new XElement("LinkKey", LinkKey), new XElement("RazerID", RazerID), new XElement("AvatarUrl", AvatarUrl), new XElement("AccountExists", AccountExists));
		}
	}
}
