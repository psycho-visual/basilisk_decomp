using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LicenseDevice : IRazerSerializable
	{
		public string SerialNumber { get; set; }

		public string ProductCode { get; set; }

		public string Edition { get; set; }

		public string Layout { get; set; }

		public LicenseDevice()
		{
		}

		public LicenseDevice(string serialNumber)
		{
			SerialNumber = serialNumber;
		}

		public LicenseDevice(XDocument doc)
			: this(doc.Element("LicenseDevice"))
		{
		}

		private LicenseDevice(XElement element)
		{
			SerialNumber = (string)element.Element("SerialNumber");
			ProductCode = (string)element.Element("ProdCode");
			Edition = (string)element.Element("Edition");
			Layout = (string)element.Element("Layout");
		}

		public XElement Serialize()
		{
			return new XElement("LicenseDevice", new XElement("SerialNumber", SerialNumber), new XElement("ProdCode", ProductCode), new XElement("Edition", Edition), new XElement("Layout", Layout));
		}

		public override string ToString()
		{
			return $"LicenseDevice: \"ProductCode\"=\"{ProductCode}\", \"Edition\"=\"{Edition}\", \"Layout\"=\"{Layout}\"";
		}
	}
}
