using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class RazerUser : IRazerSerializable
	{
		public static readonly string OFFLINE_TOKEN = "TOK_OFFLINE";

		public string Id { get; private set; }

		public string Token { get; private set; }

		public string LoginId { get; private set; }

		public string ServerIp { get; private set; }

		public string AccessToken { get; private set; }

		public DateTime AccessTokenExpirationDate { get; set; }

		internal string RefreshToken { get; set; }

		public bool Verified { get; set; }

		public bool Online => Token != OFFLINE_TOKEN;

		public bool AccessTokenExpired => DateTime.Now > AccessTokenExpirationDate;

		internal string OtpToken { get; set; }

		public RazerUser(string id, string token, string loginId, string serverIp, string accessToken)
		{
			Id = id;
			Token = token;
			LoginId = loginId;
			ServerIp = serverIp;
			AccessToken = accessToken;
		}

		public RazerUser(XDocument doc)
			: this(doc.Element("RazerUser"))
		{
		}

		internal RazerUser(XElement element)
		{
			Id = (string)element.Element("ID");
			Token = (string)element.Element("Token");
			LoginId = (string)element.Element("LoginId");
			ServerIp = (string)element.Element("ServerIp");
			AccessToken = (string)element.Element("AccessToken");
			if (element.Element("Verified") != null)
			{
				Verified = (bool)element.Element("Verified");
			}
			if (element.Element("AccessTokenExpirationDate") != null)
			{
				AccessTokenExpirationDate = (DateTime)element.Element("AccessTokenExpirationDate");
			}
			else
			{
				AccessTokenExpirationDate = DateTime.MinValue;
			}
		}

		public XElement Serialize()
		{
			return new XElement("RazerUser", new XElement("ID", Id), new XElement("Token", Token), new XElement("LoginId", LoginId), new XElement("ServerIp", ServerIp), new XElement("AccessToken", AccessToken), new XElement("Verified", Verified), new XElement("AccessTokenExpirationDate", AccessTokenExpirationDate));
		}

		public override int GetHashCode()
		{
			return Id.GetHashCode() ^ Token.GetHashCode() ^ LoginId.GetHashCode() ^ ServerIp.GetHashCode() ^ AccessToken.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is RazerUser razerUser))
			{
				return false;
			}
			if (Id != razerUser.Id)
			{
				return false;
			}
			if (Token != razerUser.Token)
			{
				return false;
			}
			if (LoginId != razerUser.LoginId)
			{
				return false;
			}
			if (ServerIp != razerUser.ServerIp)
			{
				return false;
			}
			if (AccessToken != razerUser.AccessToken)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(RazerUser lhs, RazerUser rhs)
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

		public static bool operator !=(RazerUser lhs, RazerUser rhs)
		{
			return !(lhs == rhs);
		}
	}
}
