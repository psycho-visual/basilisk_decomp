using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager.ConnectedAccounts
{
	public class RefreshAccountTokenEventArgs : EventArgs, IRazerSerializable
	{
		public ConnectedAccount Account { get; private set; }

		public List<string> Permissions { get; private set; }

		public string RefreshToken { get; private set; }

		public RefreshAccountTokenEventArgs(ConnectedAccount account, string refreshToken, IEnumerable<string> permissions)
		{
			Account = account;
			RefreshToken = refreshToken;
			Permissions = new List<string>(permissions);
		}

		public RefreshAccountTokenEventArgs(XDocument doc)
			: this(doc.Element("RefreshAccountTokenEventArgs"))
		{
		}

		private RefreshAccountTokenEventArgs(XElement element)
		{
			Account = (ConnectedAccount)(int)element.Element("Account");
			RefreshToken = (string)element.Element("RefreshToken");
			Permissions = new List<string>();
			foreach (XElement item in element.Descendants("Permission"))
			{
				Permissions.Add((string)item);
			}
		}

		public XElement Serialize()
		{
			return new XElement("RefreshAccountTokenEventArgs", new XElement("Account", (int)Account), new XElement("RefreshToken", RefreshToken), new XElement("Permissions", Permissions.Select((string x) => new XElement("Permission", x))));
		}
	}
}
