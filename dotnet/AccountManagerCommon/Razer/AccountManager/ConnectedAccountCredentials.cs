using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	[Serializable]
	public class ConnectedAccountCredentials : IRazerSerializable
	{
		[Serializable]
		public class UserDetails
		{
			public string Email { get; set; }

			public string Nickname { get; set; }

			public string DisplayName { get; set; }

			public string Id { get; set; }

			internal UserDetails()
			{
			}

			internal UserDetails(XElement element)
			{
				Email = (string)element.Element("Email");
				Nickname = (string)element.Element("Nickname");
				DisplayName = (string)element.Element("DisplayName");
				Id = (string)element.Element("Id");
			}

			internal XElement Serialize()
			{
				return new XElement("User", new XElement("Email", Email), new XElement("Nickname", Nickname), new XElement("DisplayName", DisplayName), new XElement("Id", Id));
			}

			public override string ToString()
			{
				return $"UserDetails: \"Nickname\"=\"{Nickname}\", \"DisplayName\"=\"{DisplayName}\"";
			}
		}

		public ConnectedAccount Account { get; set; }

		public string AccessToken { get; set; }

		public string AccessTokenSecret { get; set; }

		public string ClientKey { get; set; }

		public string ClientSecret { get; set; }

		public IEnumerable<string> Permissions { get; set; }

		public DateTime? ExpirationDate { get; set; }

		public string RefreshToken { get; set; }

		public UserDetails User { get; private set; }

		public string SsiToken { get; set; }

		public bool Expired
		{
			get
			{
				if (ExpirationDate.HasValue)
				{
					return ExpirationDate.Value < DateTime.Now;
				}
				return false;
			}
		}

		public ConnectedAccountCredentials()
		{
			Account = ConnectedAccount.Unknown;
			Permissions = new List<string>();
			User = new UserDetails();
		}

		public ConnectedAccountCredentials(XDocument doc)
			: this(doc.Element("ConnectedAccountCredentials"))
		{
		}

		public ConnectedAccountCredentials(XElement element)
		{
			Account = (ConnectedAccount)(int)element.Element("Account");
			AccessToken = (string)element.Element("AccessToken");
			AccessTokenSecret = (string)element.Element("AccessTokenSecret");
			ClientKey = (string)element.Element("ClientKey");
			ClientSecret = (string)element.Element("ClientSecret");
			RefreshToken = (string)element.Element("RefreshToken");
			Permissions = new List<string>();
			foreach (XElement item in element.Descendants("Permission"))
			{
				(Permissions as List<string>).Add((string)item);
			}
			if (element.Element("ExpirationDate") != null)
			{
				ExpirationDate = (DateTime)element.Element("ExpirationDate");
			}
			XElement xElement = element.Element("User");
			if (xElement != null)
			{
				User = new UserDetails(xElement);
			}
			else
			{
				User = new UserDetails();
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("ConnectedAccountCredentials", new XElement("Account", (int)Account), new XElement("AccessToken", AccessToken), new XElement("Permissions", (Permissions == null) ? null : Permissions.Select((string x) => new XElement("Permission", x))), new XElement("AccessTokenSecret", AccessTokenSecret), new XElement("ClientKey", ClientKey), new XElement("ClientSecret", ClientSecret), new XElement(User.Serialize()));
			if (ExpirationDate.HasValue)
			{
				xElement.Add(new XElement("ExpirationDate", ExpirationDate.Value));
			}
			if (RefreshToken != null)
			{
				xElement.Add(new XElement("RefreshToken", RefreshToken));
			}
			return xElement;
		}

		public override string ToString()
		{
			return $"ConnectedAccountCredentials: \"User\"=\"{User}\", \"ExpirationDate\"=\"{ExpirationDate}\"";
		}
	}
}
