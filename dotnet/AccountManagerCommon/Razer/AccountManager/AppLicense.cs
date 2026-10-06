using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class AppLicense : IRazerSerializable
	{
		public string AppId { get; private set; }

		public string LicenseCode { get; private set; }

		public DateTime ExpirationDate { get; private set; }

		public LicenseResult Status { get; private set; }

		public string StatusMessage { get; private set; }

		public AppLicense(string id, string code, DateTime expires, LicenseResult status, string message)
		{
			AppId = id;
			LicenseCode = code;
			ExpirationDate = expires;
			Status = status;
			StatusMessage = message;
		}

		public AppLicense(XDocument doc)
			: this(doc.Element("App"))
		{
		}

		public AppLicense(XElement element)
		{
			AppId = (string)element.Element("AppID");
			LicenseCode = (string)element.Element("LicenseCode");
			ExpirationDate = ((string)element.Element("LicenseExpire")).AsUnixTime();
			Status = (LicenseResult)(int)element.Element("ResultCode");
			StatusMessage = (string)element.Element("ResultMsg");
		}

		public XElement Serialize()
		{
			return new XElement("App", new XElement("AppID", AppId), new XElement("LicenseCode", LicenseCode), new XElement("LicenseExpire", ExpirationDate.ToUnixTime()), new XElement("ResultCode", (int)Status), new XElement("ResultMsg", StatusMessage));
		}

		public override string ToString()
		{
			return $"AppLicense: \"AppId\"=\"{AppId}\", \"LicenseCode\"=\"{LicenseCode}\", \"ExpirationDate\"=\"{ExpirationDate.ToUnixTime()}\", " + $"\"Status\"=\"{Status}\", \"StatusMessage\"=\"{StatusMessage}\"";
		}
	}
}
