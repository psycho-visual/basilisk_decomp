using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager.ConnectedAccounts
{
	public class DisconnectEventArgs : EventArgs, IRazerSerializable
	{
		public ConnectedAccount Account { get; private set; }

		public DisconnectEventArgs(ConnectedAccount account)
		{
			Account = account;
		}

		public DisconnectEventArgs(XDocument doc)
			: this(doc.Element("DisconnectEventArgs"))
		{
		}

		private DisconnectEventArgs(XElement element)
		{
			Account = (ConnectedAccount)(int)element.Element("Account");
		}

		public XElement Serialize()
		{
			return new XElement("DisconnectEventArgs", new XElement("Account", (int)Account));
		}
	}
}
