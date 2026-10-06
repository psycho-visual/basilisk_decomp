using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LoginDetailsUpdatedEventArgs : IRazerSerializable
	{
		public List<LoginDetails> Logins { get; set; } = new List<LoginDetails>();

		public LoginDetailsUpdatedEventArgs()
		{
		}

		public LoginDetailsUpdatedEventArgs(List<LoginDetails> details)
		{
			Logins = details;
		}

		public LoginDetailsUpdatedEventArgs(XDocument doc)
			: this(doc.Element("LoginDetailsUpdatedEventArgs"))
		{
		}

		private LoginDetailsUpdatedEventArgs(XElement element)
		{
			Logins = new List<LoginDetails>();
			foreach (XElement item in element.Descendants("Detail"))
			{
				Logins.Add(new LoginDetails(item));
			}
		}

		public XElement Serialize()
		{
			return new XElement("LoginDetailsUpdatedEventArgs", new XElement("LoginDetails", Logins.Select((LoginDetails x) => x.Serialize())));
		}
	}
}
