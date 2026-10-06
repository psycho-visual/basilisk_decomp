using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LoginDetails : IRazerSerializable
	{
		public string Id { get; private set; }

		public LoginTypes Type { get; private set; }

		public bool Verified { get; set; }

		public bool Primary { get; private set; }

		public DateTime CreateDate { get; set; }

		public LoginDetails(string id, LoginTypes type)
			: this(id, type, verified: true, primary: true)
		{
		}

		public LoginDetails(string id, LoginTypes type, bool verified, bool primary)
		{
			Id = id;
			Type = type;
			Verified = verified;
			Primary = primary;
		}

		public LoginDetails(XDocument doc)
			: this(doc.Element("Detail"))
		{
		}

		public LoginDetails(XElement element)
		{
			Id = (string)element.Element("Id");
			Type = (LoginTypes)(uint)element.Element("Type");
			Verified = (bool)element.Element("Verified");
			Primary = (bool)element.Element("Primary");
			CreateDate = ((string)element.Element("CreateDate")).AsUnixTime();
		}

		public XElement Serialize()
		{
			return new XElement("Detail", new XElement("Id", Id), new XElement("Type", (uint)Type), new XElement("Verified", Verified), new XElement("Primary", Primary), new XElement("CreateDate", CreateDate.ToUnixTime()));
		}

		public override string ToString()
		{
			return $"LoginDetails: \"Type\"=\"{Type}\", \"Verified\"=\"{Verified}\", \"Primary\"=\"{Primary}\"";
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode() ^ Type.GetHashCode() ^ Verified.GetHashCode() ^ Primary.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is LoginDetails loginDetails))
			{
				return false;
			}
			if (Id != loginDetails.Id)
			{
				return false;
			}
			if (Type != loginDetails.Type)
			{
				return false;
			}
			if (Verified != loginDetails.Verified)
			{
				return false;
			}
			if (Primary != loginDetails.Primary)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(LoginDetails lhs, LoginDetails rhs)
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

		public static bool operator !=(LoginDetails lhs, LoginDetails rhs)
		{
			return !(lhs == rhs);
		}
	}
}
