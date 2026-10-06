using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class SetTfaAuthenticatorDetails : IRazerSerializable
	{
		public string QRCode { get; set; }

		public string ChartsQrCodeUrl { get; set; }

		public string AuthenticatorKey { get; set; }

		public SetTfaAuthenticatorDetails()
		{
		}

		public SetTfaAuthenticatorDetails(XElement element)
		{
			QRCode = (string)element.Element("qr_code");
			ChartsQrCodeUrl = (string)element.Element("google_charts_url");
			AuthenticatorKey = (string)element.Element("key");
		}

		public SetTfaAuthenticatorDetails(XDocument authDoc)
			: this(authDoc.Element("authenticator"))
		{
		}

		public XElement Serialize()
		{
			return new XElement("authenticator", new XElement("qr_code", QRCode), new XElement("google_charts_url", ChartsQrCodeUrl), new XElement("key", AuthenticatorKey));
		}
	}
}
