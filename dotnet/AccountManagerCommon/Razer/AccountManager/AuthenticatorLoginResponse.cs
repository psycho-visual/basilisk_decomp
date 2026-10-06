using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class AuthenticatorLoginResponse : IRazerSerializable
	{
		public string Id { get; set; }

		public string Account { get; set; }

		public string Issuer { get; set; }

		public AuthenticatorLoginResponse()
		{
			Id = string.Empty;
			Account = string.Empty;
			Issuer = string.Empty;
		}

		public AuthenticatorLoginResponse(XElement element)
		{
			Id = (string)element.Element("auth_id");
			Account = (string)element.Element("account");
			Issuer = (string)element.Element("issuer");
		}

		public XElement Serialize()
		{
			return new XElement("authenticator", new XElement("auth_id", Id), new XElement("account", Account), new XElement("issuer", Issuer));
		}
	}
}
