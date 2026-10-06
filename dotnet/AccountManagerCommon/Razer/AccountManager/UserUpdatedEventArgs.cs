using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class UserUpdatedEventArgs : IRazerSerializable
	{
		public RazerUser CurrentUser { get; private set; }

		public UserUpdatedEventArgs()
		{
		}

		public UserUpdatedEventArgs(RazerUser currentUser)
		{
			CurrentUser = currentUser;
		}

		public UserUpdatedEventArgs(XDocument doc)
			: this(doc.Element("UserUpdatedEventArgs"))
		{
		}

		private UserUpdatedEventArgs(XElement element)
		{
			CurrentUser = new RazerUser(element.Element("RazerUser"));
		}

		public XElement Serialize()
		{
			return new XElement("UserUpdatedEventArgs", new XElement(CurrentUser.Serialize()));
		}
	}
}
