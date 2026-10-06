using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class UserProfile : IRazerSerializable
	{
		private const string AvatarTag = "Avatar";

		private const string RazerIdTag = "razer-id";

		private const string LastNameTag = "LastName";

		private const string FirstNameTag = "FirstName";

		private const string NicknameTag = "Nickname";

		private const string GenderTag = "Gender";

		private const string BirthYearTag = "BirthYear";

		private const string BirthMonthTag = "BirthMonth";

		private const string BirthDayTag = "BirthDay";

		private const string LanguageTag = "UserLanguage";

		private const string CityTag = "City";

		private const string CountryTag = "Country";

		private const string AboutMeTag = "AboutMe";

		private const string Address1Tag = "Address1";

		private const string Address2Tag = "Address2";

		private const string StateTag = "State";

		private const string PostalCodeTag = "Zipcode";

		private const string NewsletterTag = "Newsletter";

		private Bitmap m_avatar;

		private byte[] m_avatarBytes;

		private static string downloadHeaders = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

		private Dictionary<string, UserProfileItem> m_profileItems = new Dictionary<string, UserProfileItem>();

		public string AvatarUrl
		{
			get
			{
				return this["Avatar"];
			}
			set
			{
				SetProfileItem("Avatar", value);
			}
		}

		public string RazerId
		{
			get
			{
				return this["razer-id"];
			}
			internal set
			{
				SetProfileItem("razer-id", value);
			}
		}

		public string LastName
		{
			get
			{
				return this["LastName"];
			}
			set
			{
				SetProfileItem("LastName", value);
			}
		}

		public string FirstName
		{
			get
			{
				return this["FirstName"];
			}
			set
			{
				SetProfileItem("FirstName", value);
			}
		}

		public string Nickname
		{
			get
			{
				return this["Nickname"];
			}
			set
			{
				SetProfileItem("Nickname", value);
			}
		}

		public Gender Gender
		{
			get
			{
				Gender result = Gender.Unspecified;
				string text = this["Gender"];
				if (text != null)
				{
					result = text.ParseAs<Gender>();
				}
				return result;
			}
			set
			{
				SetProfileItem("Gender", value.GetDescription());
			}
		}

		public string BirthYear
		{
			get
			{
				return this["BirthYear"];
			}
			set
			{
				SetProfileItem("BirthYear", value);
			}
		}

		public string BirthMonth
		{
			get
			{
				return this["BirthMonth"];
			}
			set
			{
				SetProfileItem("BirthMonth", value);
			}
		}

		public string BirthDay
		{
			get
			{
				return this["BirthDay"];
			}
			set
			{
				SetProfileItem("BirthDay", value);
			}
		}

		public string Language
		{
			get
			{
				return this["UserLanguage"];
			}
			set
			{
				SetProfileItem("UserLanguage", value);
			}
		}

		public string City
		{
			get
			{
				return this["City"];
			}
			set
			{
				SetProfileItem("City", value);
			}
		}

		public string Country
		{
			get
			{
				return this["Country"];
			}
			set
			{
				SetProfileItem("Country", value);
			}
		}

		public string AboutMe
		{
			get
			{
				return this["AboutMe"];
			}
			set
			{
				SetProfileItem("AboutMe", value);
			}
		}

		public string Address1
		{
			get
			{
				return this["Address1"];
			}
			set
			{
				SetProfileItem("Address1", value);
			}
		}

		public string Address2
		{
			get
			{
				return this["Address2"];
			}
			set
			{
				SetProfileItem("Address2", value);
			}
		}

		public string State
		{
			get
			{
				return this["State"];
			}
			set
			{
				SetProfileItem("State", value);
			}
		}

		public string PostalCode
		{
			get
			{
				return this["Zipcode"];
			}
			set
			{
				SetProfileItem("Zipcode", value);
			}
		}

		public bool ReceiveMarketingCommunications
		{
			get
			{
				return this["Newsletter"] == "1";
			}
			set
			{
				SetProfileItem("Newsletter", value ? "1" : "0");
			}
		}

		public Dictionary<string, UserProfileItem> Items => m_profileItems;

		public int Count => m_profileItems.Count;

		public string this[string name]
		{
			get
			{
				UserProfileItem profileItem = GetProfileItem(name);
				if (!(profileItem != null))
				{
					return null;
				}
				return profileItem.Value;
			}
		}

		public Bitmap Avatar
		{
			get
			{
				if (m_avatar == null && m_avatarBytes != null)
				{
					using (MemoryStream stream = new MemoryStream(m_avatarBytes))
					{
						m_avatar = new Bitmap(stream);
					}
				}
				return m_avatar;
			}
			set
			{
				m_avatar = value;
				if (value != null)
				{
					using (MemoryStream memoryStream = new MemoryStream())
					{
						value.Save(memoryStream, ImageFormat.Png);
						m_avatarBytes = memoryStream.ToArray();
						return;
					}
				}
				m_avatarBytes = null;
			}
		}

		public UserProfile()
		{
		}

		public UserProfile(XDocument doc)
			: this(doc.Element("UserProfile"))
		{
		}

		public UserProfile(XElement element)
		{
			foreach (XElement item in element.Descendants("ProfileItem"))
			{
				AddProfileItem(new UserProfileItem(item));
			}
			XElement xElement = element.Element("Avatar");
			if (xElement != null)
			{
				m_avatarBytes = Convert.FromBase64String(xElement.Value);
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("UserProfile", m_profileItems.Values.Select((UserProfileItem x) => x.Serialize()));
			if (m_avatarBytes != null)
			{
				xElement.Add(new XElement("Avatar", Convert.ToBase64String(m_avatarBytes)));
			}
			return xElement;
		}

		public void AddProfileItem(UserProfileItem item)
		{
			if (item == null)
			{
				throw new ArgumentNullException("item");
			}
			m_profileItems[item.Name] = item;
		}

		public UserProfileItem GetProfileItem(string name)
		{
			UserProfileItem value = null;
			m_profileItems.TryGetValue(name, out value);
			return value;
		}

		private void SetProfileItem(string tag, string value)
		{
			if (value == null)
			{
				m_profileItems.Remove(tag);
				return;
			}
			UserProfileItem profileItem = GetProfileItem(tag);
			if (profileItem == null)
			{
				AddProfileItem(new UserProfileItem(tag, value));
			}
			else
			{
				profileItem.Value = value;
			}
		}

		public void DownloadAvatar()
		{
			if (string.IsNullOrEmpty(AvatarUrl))
			{
				return;
			}
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.Encoding = Encoding.UTF8;
					webClient.Headers["User-Agent"] = downloadHeaders;
					m_avatar = new Bitmap(webClient.OpenRead(AvatarUrl));
				}
				using (MemoryStream memoryStream = new MemoryStream())
				{
					m_avatar.Save(memoryStream, ImageFormat.Png);
					m_avatarBytes = memoryStream.ToArray();
				}
			}
			catch (WebException ex)
			{
				if (ex.Response is HttpWebResponse httpWebResponse && httpWebResponse.StatusCode == HttpStatusCode.NotFound)
				{
					AvatarUrl = null;
					return;
				}
				throw;
			}
		}
	}
}
