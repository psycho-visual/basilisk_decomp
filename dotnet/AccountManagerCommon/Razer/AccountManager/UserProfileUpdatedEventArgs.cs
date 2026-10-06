using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class UserProfileUpdatedEventArgs : EventArgs, IRazerSerializable
	{
		public UserProfile Profile { get; private set; }

		public IEnumerable<string> UpdatedItems { get; private set; }

		public UserProfileUpdatedEventArgs(UserProfile profile, IEnumerable<string> updatedItems)
		{
			Profile = profile;
			UpdatedItems = updatedItems;
		}

		public UserProfileUpdatedEventArgs(XDocument doc)
			: this(doc.Element("UserProfileUpdatedEventArgs"))
		{
		}

		private UserProfileUpdatedEventArgs(XElement element)
		{
			Profile = new UserProfile(element.Descendants("UserProfile").Single());
			XElement xElement = element.Element("UpdatedItems");
			if (xElement != null)
			{
				UpdatedItems = from x in xElement.Elements("Item")
					select (string)x;
			}
			else
			{
				UpdatedItems = new List<string>();
			}
		}

		public XElement Serialize()
		{
			return new XElement("UserProfileUpdatedEventArgs", Profile.Serialize(), new XElement("UpdatedItems", UpdatedItems.Select((string x) => new XElement("Item", x))));
		}
	}
}
