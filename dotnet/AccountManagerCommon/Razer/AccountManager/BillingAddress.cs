using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class BillingAddress : IRazerSerializable
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string PhoneNumber { get; set; }

		public string FaxNumber { get; set; }

		public string Company { get; set; }

		public string Address1 { get; set; }

		public string Address2 { get; set; }

		public string Address3 { get; set; }

		public string City { get; set; }

		public string CountryCode { get; set; }

		public string State { get; set; }

		public string PostalCode { get; set; }

		public bool IsEmpty
		{
			get
			{
				if (string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName) && string.IsNullOrEmpty(PhoneNumber) && string.IsNullOrEmpty(FaxNumber) && string.IsNullOrEmpty(Company) && string.IsNullOrEmpty(Address1) && string.IsNullOrEmpty(Address2) && string.IsNullOrEmpty(Address3) && string.IsNullOrEmpty(City) && string.IsNullOrEmpty(CountryCode) && string.IsNullOrEmpty(State))
				{
					return string.IsNullOrEmpty(PostalCode);
				}
				return false;
			}
		}

		public BillingAddress()
		{
		}

		public BillingAddress(BillingAddress copyFrom)
		{
			if (!(copyFrom == null))
			{
				if (copyFrom.FirstName != null)
				{
					FirstName = string.Copy(copyFrom.FirstName);
				}
				if (copyFrom.LastName != null)
				{
					LastName = string.Copy(copyFrom.LastName);
				}
				if (copyFrom.PhoneNumber != null)
				{
					PhoneNumber = string.Copy(copyFrom.PhoneNumber);
				}
				if (copyFrom.FaxNumber != null)
				{
					FaxNumber = string.Copy(copyFrom.FaxNumber);
				}
				if (copyFrom.Company != null)
				{
					Company = string.Copy(copyFrom.Company);
				}
				if (copyFrom.Address1 != null)
				{
					Address1 = string.Copy(copyFrom.Address1);
				}
				if (copyFrom.Address2 != null)
				{
					Address2 = string.Copy(copyFrom.Address2);
				}
				if (copyFrom.Address3 != null)
				{
					Address3 = string.Copy(copyFrom.Address3);
				}
				if (copyFrom.City != null)
				{
					City = string.Copy(copyFrom.City);
				}
				if (copyFrom.CountryCode != null)
				{
					CountryCode = string.Copy(copyFrom.CountryCode);
				}
				if (copyFrom.State != null)
				{
					State = string.Copy(copyFrom.State);
				}
				if (copyFrom.PostalCode != null)
				{
					PostalCode = string.Copy(copyFrom.PostalCode);
				}
			}
		}

		public XElement ToCopElement()
		{
			return new XElement("userInfo", new XElement("billingAddress", new XElement("name1", FirstName), new XElement("name2", LastName), new XElement("phoneNumber", PhoneNumber), new XElement("faxPhone", FaxNumber), new XElement("companyName", Company), new XElement("line1", Address1), new XElement("line2", Address2), new XElement("line3", Address3), new XElement("city", City), new XElement("country", CountryCode), new XElement("countryA2", CountryCode), new XElement("state", State), new XElement("postalCode", PostalCode)));
		}

		public override string ToString()
		{
			string[] source = new string[6]
			{
				string.Join(" ", FirstName, LastName).Trim(),
				Address1,
				Address2,
				City,
				State,
				PostalCode
			};
			return string.Join(", ", source.Where((string x) => !string.IsNullOrWhiteSpace(x)));
		}

		public BillingAddress(XDocument doc)
			: this(doc.Element("BillingAddress"))
		{
		}

		public BillingAddress(XElement element)
		{
			if (element != null)
			{
				if (element.Name == "BillingAddress")
				{
					FirstName = (string)element.Element("FirstName");
					LastName = (string)element.Element("LastName");
					PhoneNumber = (string)element.Element("PhoneNumber");
					FaxNumber = (string)element.Element("FaxNumber");
					Company = (string)element.Element("Company");
					Address1 = (string)element.Element("Address1");
					Address2 = (string)element.Element("Address2");
					Address3 = (string)element.Element("Address3");
					City = (string)element.Element("City");
					CountryCode = (string)element.Element("CountryCode");
					State = (string)element.Element("State");
					PostalCode = (string)element.Element("PostalCode");
				}
				else
				{
					FirstName = (string)element.Element("name1");
					LastName = (string)element.Element("name2");
					PhoneNumber = (string)element.Element("phoneNumber");
					Address1 = (string)element.Element("line1");
					Address2 = (string)element.Element("line2");
					City = (string)element.Element("city");
					CountryCode = (string)element.Element("country");
					State = (string)element.Element("state");
					PostalCode = (string)element.Element("postalCode");
				}
			}
		}

		public XElement Serialize()
		{
			return new XElement("BillingAddress", new XElement("FirstName", FirstName), new XElement("LastName", LastName), new XElement("PhoneNumber", PhoneNumber), new XElement("FaxNumber", FaxNumber), new XElement("Company", Company), new XElement("Address1", Address1), new XElement("Address2", Address2), new XElement("Address3", Address3), new XElement("City", City), new XElement("CountryCode", CountryCode), new XElement("State", State), new XElement("PostalCode", PostalCode));
		}

		public override int GetHashCode()
		{
			return (FirstName ?? string.Empty).GetHashCode() ^ (LastName ?? string.Empty).GetHashCode() ^ (PhoneNumber ?? string.Empty).GetHashCode() ^ (FaxNumber ?? string.Empty).GetHashCode() ^ (Company ?? string.Empty).GetHashCode() ^ (Address1 ?? string.Empty).GetHashCode() ^ (Address2 ?? string.Empty).GetHashCode() ^ (Address3 ?? string.Empty).GetHashCode() ^ (City ?? string.Empty).GetHashCode() ^ (CountryCode ?? string.Empty).GetHashCode() ^ (State ?? string.Empty).GetHashCode() ^ (PostalCode ?? string.Empty).GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is BillingAddress billingAddress))
			{
				return false;
			}
			if (FirstName != billingAddress.FirstName)
			{
				return false;
			}
			if (LastName != billingAddress.LastName)
			{
				return false;
			}
			if (PhoneNumber != billingAddress.PhoneNumber)
			{
				return false;
			}
			if (FaxNumber != billingAddress.FaxNumber)
			{
				return false;
			}
			if (Company != billingAddress.Company)
			{
				return false;
			}
			if (Address1 != billingAddress.Address1)
			{
				return false;
			}
			if (Address2 != billingAddress.Address2)
			{
				return false;
			}
			if (Address3 != billingAddress.Address3)
			{
				return false;
			}
			if (City != billingAddress.City)
			{
				return false;
			}
			if (CountryCode != billingAddress.CountryCode)
			{
				return false;
			}
			if (State != billingAddress.State)
			{
				return false;
			}
			if (PostalCode != billingAddress.PostalCode)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(BillingAddress lhs, BillingAddress rhs)
		{
			if ((object)lhs == rhs)
			{
				return true;
			}
			if ((object)lhs == null || (object)rhs == null)
			{
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(BillingAddress lhs, BillingAddress rhs)
		{
			return !(lhs == rhs);
		}
	}
}
