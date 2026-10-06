using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager.ConnectedAccounts
{
	public class ConnectionRequestEventArgs : EventArgs, IRazerSerializable
	{
		public ConnectedAccount Account { get; private set; }

		public List<string> Permissions { get; private set; }

		public ConnectionRequestEventArgs(ConnectedAccount account, IEnumerable<string> permissions)
		{
			Account = account;
			Permissions = new List<string>(permissions);
		}

		public ConnectionRequestEventArgs(XDocument doc)
			: this(doc.Element("ConnectionRequestEventArgs"))
		{
		}

		private ConnectionRequestEventArgs(XElement element)
		{
			Account = (ConnectedAccount)(int)element.Element("Account");
			Permissions = new List<string>();
			foreach (XElement item in element.Descendants("Permission"))
			{
				Permissions.Add((string)item);
			}
		}

		public XElement Serialize()
		{
			return new XElement("ConnectionRequestEventArgs", new XElement("Account", (int)Account), new XElement("Permissions", Permissions.Select((string x) => new XElement("Permission", x))));
		}
	}
}
