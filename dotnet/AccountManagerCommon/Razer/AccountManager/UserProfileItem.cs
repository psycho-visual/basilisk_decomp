using System;
using System.Xml.Linq;

namespace Razer.AccountManager
{
	public class UserProfileItem
	{
		public enum AccessTypes
		{
			Undefined,
			Public,
			Friends,
			Private
		}

		public string Name { get; private set; }

		public string Value { get; set; }

		public AccessTypes Access { get; set; }

		public UserProfileItem(string name, string value = "", AccessTypes access = AccessTypes.Undefined)
		{
			Name = name;
			Value = value;
			Access = access;
		}

		public UserProfileItem(XElement element)
		{
			Name = (string)element.Element("Name");
			Value = (string)element.Element("Value");
			AccessTypes result = AccessTypes.Undefined;
			Enum.TryParse<AccessTypes>((string)element.Element("Access"), out result);
			Access = result;
		}

		public XElement Serialize()
		{
			return new XElement("ProfileItem", new XElement("Name", Name), new XElement("Value", Value), new XElement("Access", Access));
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is UserProfileItem userProfileItem))
			{
				return false;
			}
			if (Name != userProfileItem.Name)
			{
				return false;
			}
			if (Value != userProfileItem.Value)
			{
				return false;
			}
			if (Access != userProfileItem.Access)
			{
				return false;
			}
			return true;
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		public static bool operator ==(UserProfileItem lhs, UserProfileItem rhs)
		{
			if ((object)lhs == rhs)
			{
				return true;
			}
			if ((object)lhs == null || (object)rhs == null)
			{
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(UserProfileItem lhs, UserProfileItem rhs)
		{
			return !(lhs == rhs);
		}
	}
}
