using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LoginEventArgs : EventArgs, IRazerSerializable
	{
		public RazerUser User { get; private set; }

		public LoginResult Result { get; private set; }

		public LoginEventArgs(RazerUser user, LoginResult result)
		{
			User = user;
			Result = result;
		}

		public LoginEventArgs(XDocument doc)
			: this(doc.Element("LoginEventArgs"))
		{
		}

		public LoginEventArgs(XElement element)
		{
			if (!Enum.TryParse<LoginResult>((string)element.Element("Result"), out var result))
			{
				result = LoginResult.Failed;
			}
			Result = result;
			XElement xElement = element.Element("RazerUser");
			if (xElement != null)
			{
				User = new RazerUser(xElement);
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("LoginEventArgs", new XElement("Result", Result));
			if (User != null)
			{
				xElement.Add(User.Serialize());
			}
			return xElement;
		}
	}
}
