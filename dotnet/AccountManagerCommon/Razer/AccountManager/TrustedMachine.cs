using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class TrustedMachine : IRazerSerializable
	{
		public string Fingerprint { get; private set; }

		public string Nickname { get; set; }

		public DateTime DateAdded { get; private set; }

		public bool IsThisMachine { get; set; }

		public TrustedMachine(string fingerprint, string nickname, DateTime added)
		{
			Fingerprint = fingerprint;
			Nickname = nickname;
			DateAdded = added;
			IsThisMachine = false;
		}

		public TrustedMachine(XDocument doc)
			: this(doc.Element("machine"))
		{
		}

		public TrustedMachine(XElement element)
		{
			Fingerprint = (string)element.Element("fingerprint");
			Nickname = (string)element.Element("nickname");
			DateAdded = ((string)element.Element("trusted-since")).AsUnixTime();
			if (element.Element("IsThisMachine") != null)
			{
				IsThisMachine = (bool)element.Element("IsThisMachine");
			}
			else
			{
				IsThisMachine = false;
			}
		}

		public XElement Serialize()
		{
			return new XElement("machine", new XElement("fingerprint", Fingerprint), new XElement("nickname", Nickname), new XElement("trusted-since", DateAdded.ToUnixTime()), new XElement("IsThisMachine", IsThisMachine));
		}

		public override int GetHashCode()
		{
			return Fingerprint.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is TrustedMachine trustedMachine))
			{
				return false;
			}
			if (Fingerprint != trustedMachine.Fingerprint)
			{
				return false;
			}
			if (Nickname != trustedMachine.Nickname)
			{
				return false;
			}
			if (DateAdded != trustedMachine.DateAdded)
			{
				return false;
			}
			if (IsThisMachine != trustedMachine.IsThisMachine)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(TrustedMachine lhs, TrustedMachine rhs)
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

		public static bool operator !=(TrustedMachine lhs, TrustedMachine rhs)
		{
			return !(lhs == rhs);
		}
	}
}
