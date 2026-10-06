using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager.ConnectedAccounts
{
	public class ConnectCompletedEventArgs : EventArgs, IRazerSerializable
	{
		public LoginResult Result { get; private set; }

		public ConnectedAccount Account { get; private set; }

		public ConnectedAccountCredentials Credentals { get; private set; }

		public ConnectCompletedEventArgs(LoginResult result, ConnectedAccount account, ConnectedAccountCredentials creds)
		{
			Result = result;
			Account = account;
			Credentals = creds;
		}

		public ConnectCompletedEventArgs(XDocument doc)
			: this(doc.Element("ConnectCompletedEventArgs"))
		{
		}

		private ConnectCompletedEventArgs(XElement element)
		{
			Result = (LoginResult)(int)element.Element("Result");
			if (element.Element("ConnectedAccountCredentials") != null)
			{
				Credentals = new ConnectedAccountCredentials(element.Element("ConnectedAccountCredentials"));
			}
			Account = (ConnectedAccount)(int)element.Element("Account");
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("ConnectCompletedEventArgs", new XElement("Result", (int)Result));
			if (Credentals != null)
			{
				xElement.Add(Credentals.Serialize());
			}
			xElement.Add(new XElement("Account", (int)Account));
			return xElement;
		}
	}
}
