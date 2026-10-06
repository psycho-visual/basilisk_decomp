using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class FriendSearchResult : IRazerSerializable
	{
		public class UserInfo
		{
			public string RazerId { get; private set; }

			public string Nickname { get; private set; }

			public UserInfo()
				: this(string.Empty, string.Empty)
			{
			}

			public UserInfo(string razerId, string nickname)
			{
				RazerId = razerId;
				Nickname = nickname;
			}
		}

		public Dictionary<string, UserInfo> Result { get; private set; }

		public FriendSearchResult()
		{
			Result = new Dictionary<string, UserInfo>();
		}

		public FriendSearchResult(XDocument doc)
			: this(doc.Element("FriendSearchResult"))
		{
		}

		private FriendSearchResult(XElement element)
		{
			Result = new Dictionary<string, UserInfo>();
			foreach (XElement item in element.Elements("Result"))
			{
				string key = (string)item.Element("ExternalId");
				string razerId = (string)item.Element("RazerId");
				string nickname = (string)item.Element("Nickname");
				Result[key] = new UserInfo(razerId, nickname);
			}
		}

		public XElement Serialize()
		{
			return new XElement("FriendSearchResult", Result.Select((KeyValuePair<string, UserInfo> x) => new XElement("Result", new XElement("ExternalId", x.Key), new XElement("RazerId", x.Value.RazerId), new XElement("Nickname", x.Value.Nickname))));
		}
	}
}
