using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class WarrantyResponse : IRazerSerializable
	{
		public WarrantyUser User { get; private set; }

		public string UserId { get; private set; }

		public List<WarrantyDevice> Devices { get; private set; }

		public WarrantyResponse(string userId, WarrantyUser user, WarrantyDevice device)
		{
			UserId = userId;
			User = user;
			Devices = new List<WarrantyDevice>();
			Devices.Add(device);
		}

		public WarrantyResponse(string userId, WarrantyUser user, List<WarrantyDevice> devices)
		{
			UserId = userId;
			User = user;
			Devices = devices;
		}

		public WarrantyResponse(XDocument doc)
			: this(doc.Element("WarrantyResponse"))
		{
		}

		public WarrantyResponse(XElement element)
		{
			UserId = (string)element.Element("UserId");
			User = new WarrantyUser(element.Element("userInfo"));
			Devices = new List<WarrantyDevice>();
			foreach (XElement item in element.Element("Devices").Elements("Item"))
			{
				Devices.Add(new WarrantyDevice(item));
			}
		}

		public XElement Serialize()
		{
			return new XElement("WarrantyResponse", new XElement("UserId", UserId), User.Serialize(), new XElement("Devices", Devices.Select((WarrantyDevice x) => x.Serialize())));
		}
	}
}
