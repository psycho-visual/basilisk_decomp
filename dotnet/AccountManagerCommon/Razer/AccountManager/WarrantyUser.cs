using System;
using System.Net.Mail;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class WarrantyUser : IRazerSerializable
	{
		public class Address
		{
			private string m_city;

			private string m_country;

			private string m_addressLine1;

			private string m_addressLine2;

			private string m_addressLine3;

			private string m_nameLine1;

			private string m_nameLine2;

			private string m_phoneNumber;

			private string m_postalCode;

			private string m_state;

			private string m_faxNumber;

			private string m_companyName;

			private string m_email;

			public string City
			{
				get
				{
					return m_city;
				}
				set
				{
					if (value != null && value.Length > 128)
					{
						throw new ArgumentOutOfRangeException("City must be less than 129 characters.");
					}
					m_city = value;
				}
			}

			public string Country
			{
				get
				{
					return m_country;
				}
				set
				{
					if (value != null && value.Length != 2)
					{
						throw new ArgumentOutOfRangeException("Country must be exactly 2 characters.");
					}
					m_country = value;
				}
			}

			public string AddressLine1
			{
				get
				{
					return m_addressLine1;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("AddressLine1 must be less than 256 characters.");
					}
					m_addressLine1 = value;
				}
			}

			public string AddressLine2
			{
				get
				{
					return m_addressLine2;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("AddressLine2 must be less than 256 characters.");
					}
					m_addressLine2 = value;
				}
			}

			public string AddressLine3
			{
				get
				{
					return m_addressLine3;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("AddressLine3 must be less than 256 characters.");
					}
					m_addressLine3 = value;
				}
			}

			public string NameLine1
			{
				get
				{
					return m_nameLine1;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("NameLine1 must be less than 256 characters.");
					}
					m_nameLine1 = value;
				}
			}

			public string NameLine2
			{
				get
				{
					return m_nameLine2;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("NameLine2 must be less than 256 characters.");
					}
					m_nameLine2 = value;
				}
			}

			public string PhoneNumber
			{
				get
				{
					return m_phoneNumber;
				}
				set
				{
					if (value != null && value.Length > 64)
					{
						throw new ArgumentOutOfRangeException("PhoneNumber must be less than 65 characters.");
					}
					m_phoneNumber = value;
				}
			}

			public string PostalCode
			{
				get
				{
					return m_postalCode;
				}
				set
				{
					if (value != null && value.Length > 32)
					{
						throw new ArgumentOutOfRangeException("PostalCode must be less than 33 characters.");
					}
					m_postalCode = value;
				}
			}

			public string State
			{
				get
				{
					return m_state;
				}
				set
				{
					if (value != null && value.Length > 64)
					{
						throw new ArgumentOutOfRangeException("State must be less than 65 characters.");
					}
					m_state = value;
				}
			}

			public string FaxNumber
			{
				get
				{
					return m_faxNumber;
				}
				set
				{
					if (value != null && value.Length > 32)
					{
						throw new ArgumentOutOfRangeException("FaxNumber must be less than 33 characters.");
					}
					m_faxNumber = value;
				}
			}

			public string CompanyName
			{
				get
				{
					return m_companyName;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("CompanyName must be less than 256 characters.");
					}
					m_companyName = value;
				}
			}

			public string Email
			{
				get
				{
					return m_email;
				}
				set
				{
					if (value != null && value.Length > 255)
					{
						throw new ArgumentOutOfRangeException("Email must be less than 255 characters.");
					}
					if (new MailAddress(value).Address != value)
					{
						throw new FormatException("Email is not formatted as an email address.");
					}
					m_email = value;
				}
			}

			public Address()
			{
			}

			public Address(XElement element)
			{
				City = (string)element.Element("city");
				Country = (string)element.Element("country");
				AddressLine1 = (string)element.Element("line1");
				AddressLine2 = (string)element.Element("line2");
				AddressLine3 = (string)element.Element("line3");
				NameLine1 = (string)element.Element("name1");
				NameLine2 = (string)element.Element("name2");
				PhoneNumber = (string)element.Element("phoneNumber");
				PostalCode = (string)element.Element("postalCode");
				State = (string)element.Element("state");
				FaxNumber = (string)element.Element("faxPhone");
				CompanyName = (string)element.Element("companyName");
				Email = (string)element.Element("email");
			}

			public XElement Serialize()
			{
				return new XElement("shippingAddress", new XElement("city", City), new XElement("country", Country), new XElement("line1", AddressLine1), new XElement("line2", AddressLine2), new XElement("line3", AddressLine3), new XElement("name1", NameLine1), new XElement("name2", NameLine2), new XElement("phoneNumber", PhoneNumber), new XElement("postalCode", PostalCode), new XElement("state", State), new XElement("faxPhone", FaxNumber), new XElement("companyName", CompanyName), new XElement("email", Email));
			}
		}

		private string m_firstName;

		private string m_lastName;

		private Address m_shippingAddress;

		public string FirstName
		{
			get
			{
				return m_firstName;
			}
			set
			{
				if (value.Length > 255)
				{
					throw new ArgumentOutOfRangeException("FirstName must be less than 256 characters.");
				}
				m_firstName = value;
			}
		}

		public string LastName
		{
			get
			{
				return m_lastName;
			}
			set
			{
				if (value.Length > 255)
				{
					throw new ArgumentOutOfRangeException("LastName must be less than 256 characters.");
				}
				m_lastName = value;
			}
		}

		public Gender Gender { get; set; }

		public Address ShippingAddress
		{
			get
			{
				return m_shippingAddress;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentException("Address cannot be null");
				}
				m_shippingAddress = value;
			}
		}

		public WarrantyUser()
		{
			ShippingAddress = new Address();
		}

		public WarrantyUser(XDocument doc)
			: this(doc.Element("userInfo"))
		{
		}

		public WarrantyUser(XElement element)
		{
			FirstName = (string)element.Element("firstName");
			LastName = (string)element.Element("lastName");
			Gender = ((string)element.Element("gender")).ParseAs<Gender>();
			ShippingAddress = new Address(element.Element("shippingAddress"));
		}

		public XElement Serialize()
		{
			return new XElement("userInfo", new XElement("firstName", FirstName), new XElement("lastName", LastName), new XElement("gender", Gender.GetDescription()), ShippingAddress.Serialize());
		}
	}
}
