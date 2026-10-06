using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class CreateAccountRequest : IRazerSerializable
	{
		public string Email { get; set; }

		public string Phone { get; set; }

		public string Password { get; set; }

		public bool TransferPhone { get; set; }

		public string TosReadToken { get; set; }

		public string ToSConsentToken { get; set; }

		public CreateAccountRequest()
		{
		}

		public CreateAccountRequest(XDocument doc)
			: this(doc.Element("CreateAccountRequest"))
		{
		}

		public CreateAccountRequest(XElement element)
		{
			Email = (string)element.Element("Email");
			Phone = (string)element.Element("Phone");
			Password = (string)element.Element("Password");
			TransferPhone = (bool)element.Element("TransferPhone");
			TosReadToken = (string)element.Element("TosReadToken");
			ToSConsentToken = (string)element.Element("ToSConsentToken");
		}

		public XElement Serialize()
		{
			return new XElement("CreateAccountRequest", new XElement("Email", Email), new XElement("Phone", Phone), new XElement("Password", Password), new XElement("TransferPhone", TransferPhone), new XElement("TosReadToken", TosReadToken), new XElement("ToSConsentToken", ToSConsentToken));
		}
	}
}
