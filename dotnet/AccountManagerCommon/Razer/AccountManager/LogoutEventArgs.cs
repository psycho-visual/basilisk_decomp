using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LogoutEventArgs : EventArgs, IRazerSerializable
	{
		public RazerUser User { get; private set; }

		public LogoutReason Reason { get; private set; }

		public LogoutEventArgs(RazerUser user, LogoutReason reason)
		{
			User = user;
			Reason = reason;
		}

		public LogoutEventArgs(XDocument doc)
			: this(doc.Element("LogoutEventArgs"))
		{
		}

		public LogoutEventArgs(XElement element)
		{
			XElement xElement = element.Element("Reason");
			if (xElement != null)
			{
				Reason = (LogoutReason)(int)xElement;
			}
			else
			{
				Reason = LogoutReason.Unknown;
			}
			XElement xElement2 = element.Element("RazerUser");
			if (xElement2 != null)
			{
				User = new RazerUser(xElement2);
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("LogoutEventArgs", new XElement("Reason", (int)Reason));
			if (User != null)
			{
				xElement.Add(User.Serialize());
			}
			return xElement;
		}
	}
}
