using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class WarrantyDevice : WarrantyItem
	{
		public uint Vid { get; private set; }

		public uint Pid { get; private set; }

		public string ProductName { get; private set; }

		public DateTime ExpirationDate { get; private set; }

		public bool ReceiptRequired { get; private set; }

		public WarrantyResult Result { get; private set; }

		public string Message { get; private set; }

		public WarrantyDevice(XDocument doc)
			: this(doc.Element("Item") ?? doc.Element("Device"))
		{
		}

		public WarrantyDevice(XElement element)
			: base(element)
		{
			XElement xElement = element.Element("VID");
			if (xElement != null)
			{
				Vid = (uint)xElement;
			}
			XElement xElement2 = element.Element("PID");
			if (xElement2 != null)
			{
				Pid = (uint)xElement2;
			}
			ProductName = (string)element.Element("ProdName");
			ExpirationDate = ((string)element.Element("WarrantyExpire")).AsUnixTime();
			ReceiptRequired = (string)element.Element("Beyond-S-Time") == "1";
			Result = (WarrantyResult)(int)element.Element("ResultCode");
			Message = (string)element.Element("ResultMsg");
		}

		public override XElement Serialize()
		{
			XElement xElement = base.Serialize();
			if (Vid != 0)
			{
				xElement.Add(new XElement("VID", Vid));
			}
			if (Pid != 0)
			{
				xElement.Add(new XElement("PID", Pid));
			}
			xElement.Add(new XElement("ProdName", ProductName));
			xElement.Add(new XElement("WarrantyExpire", ExpirationDate.ToUnixTime()));
			xElement.Add(new XElement("Beyond-S-Time", ReceiptRequired ? "1" : "0"));
			xElement.Add(new XElement("ResultCode", (int)Result));
			xElement.Add(new XElement("ResultMsg", Message));
			return xElement;
		}

		public override string ToString()
		{
			return $"WarrantyDevice: \"Vid\"=\"{Vid}\", \"Pid\"=\"{Pid}\", \"ProductName\"=\"{ProductName}\"";
		}
	}
}
