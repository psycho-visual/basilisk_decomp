using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager.Tfa
{
	public class OtpDetails : IRazerSerializable
	{
		public TfaType OtpType { get; set; }

		public string TransactionId { get; set; }

		public string Token { get; set; }

		public bool IsBackupCode { get; set; }

		public OtpDetails()
		{
		}

		public XElement CreateAuthElement()
		{
			XElement xElement = new XElement("auth-opts");
			if (OtpType == TfaType.Authenticator)
			{
				xElement.Add(new XElement("authenticator", new XElement("auth_id", TransactionId), new XElement(IsBackupCode ? "code" : "token", Token)));
			}
			else if (OtpType == TfaType.Phone || OtpType == TfaType.Email)
			{
				xElement.Add(CreateTransactionElement());
			}
			return xElement;
		}

		public XElement CreateTransactionElement()
		{
			return new XElement("transaction", new XElement("id", TransactionId), new XElement(IsBackupCode ? "code" : "totp", Token));
		}

		public OtpDetails(XDocument doc)
			: this(doc.Element("OtpDetails"))
		{
		}

		public OtpDetails(XElement element)
		{
			OtpType = (TfaType)(int)element.Element("OtpType");
			TransactionId = (string)element.Element("TransactionId");
			Token = (string)element.Element("Token");
			IsBackupCode = (bool)element.Element("IsBackupCode");
		}

		public XElement Serialize()
		{
			return new XElement("OtpDetails", new XElement("OtpType", (int)OtpType), new XElement("TransactionId", TransactionId), new XElement("Token", Token), new XElement("IsBackupCode", IsBackupCode));
		}
	}
}
