using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class BillingAddressUpdatedEventArgs : IRazerSerializable
	{
		public BillingAddress Address { get; set; }

		public BillingAddressUpdatedEventArgs()
		{
		}

		public BillingAddressUpdatedEventArgs(BillingAddress address)
		{
			Address = address;
		}

		public BillingAddressUpdatedEventArgs(XDocument doc)
			: this(doc.Element("BillingAddressUpdatedEventArgs"))
		{
		}

		private BillingAddressUpdatedEventArgs(XElement element)
		{
			Address = new BillingAddress(element.Element("BillingAddress"));
		}

		public XElement Serialize()
		{
			return new XElement("BillingAddressUpdatedEventArgs", Address.Serialize());
		}
	}
}
