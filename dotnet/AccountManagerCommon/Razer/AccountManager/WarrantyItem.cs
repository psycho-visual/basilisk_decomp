using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class WarrantyItem : IRazerSerializable
	{
		private string m_productCode;

		private string m_serialNumber;

		private string m_purchaseLocation;

		private string m_purchaseCountry;

		private string m_extendedWarrantyCode;

		public string ProductCode
		{
			get
			{
				return m_productCode;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("ProductCode cannot be null.");
				}
				if (value.Length > 25)
				{
					throw new ArgumentOutOfRangeException("ProductCode must be less than 26 characters.");
				}
				m_productCode = value;
			}
		}

		public string SerialNumber
		{
			get
			{
				return m_serialNumber;
			}
			set
			{
				if (value == null)
				{
					m_serialNumber = null;
					return;
				}
				if (value.Length < 8 || value.Length > 29)
				{
					throw new ArgumentOutOfRangeException("SerialNumber must be greater than 7 characters, and less than 30 characters.");
				}
				m_serialNumber = value;
			}
		}

		public string PurchaseLocation
		{
			get
			{
				return m_purchaseLocation;
			}
			set
			{
				if (value != null && value.Length > 255)
				{
					throw new ArgumentOutOfRangeException("PurchaseLocation must be less than 256 characters.");
				}
				m_purchaseLocation = value;
			}
		}

		public string PurchaseCountry
		{
			get
			{
				return m_purchaseCountry;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("PurchaseCountry cannot be null.");
				}
				if (value.Length != 2)
				{
					throw new ArgumentOutOfRangeException("PurchaseCountry must be exactly 2 characters.");
				}
				m_purchaseCountry = value;
			}
		}

		public DateTime PurchaseDate { get; set; }

		public string ExtendedWarrantyCode
		{
			get
			{
				return m_extendedWarrantyCode;
			}
			set
			{
				if (value != null && value.Length > 255)
				{
					throw new ArgumentOutOfRangeException("ExtendedWarrantyCode must be less than 256 characters.");
				}
				m_extendedWarrantyCode = value;
			}
		}

		public WarrantyItem()
		{
		}

		public WarrantyItem(XDocument doc)
			: this(doc.Element("Item"))
		{
		}

		public WarrantyItem(XElement element)
		{
			m_productCode = (string)element.Element("ProdCode");
			m_serialNumber = (string)element.Element("SN");
			m_purchaseLocation = (string)element.Element("PurchaseLoc");
			m_purchaseCountry = (string)element.Element("PurchaseCountry");
			PurchaseDate = ((string)element.Element("PurchaseDate")).AsUnixTime();
			m_extendedWarrantyCode = (string)element.Element("X-Warranty-Code");
		}

		public virtual XElement Serialize()
		{
			return new XElement("Item", new XElement("ProdCode", ProductCode), new XElement("SN", SerialNumber), new XElement("PurchaseLoc", PurchaseLocation), new XElement("PurchaseCountry", PurchaseCountry), new XElement("PurchaseDate", PurchaseDate.ToUnixTime()), new XElement("X-Warranty-Code", ExtendedWarrantyCode));
		}

		public override string ToString()
		{
			return $"WarrantyItem: \"ProductCode\"=\"{ProductCode}\", \"PurchaseLocation\"=\"{PurchaseLocation}\", \"PurchaseCountry\"=\"{PurchaseCountry}\", " + $"\"PurchaseDate\"=\"{PurchaseDate.ToUnixTime()}\"";
		}
	}
}
