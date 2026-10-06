using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class ExternalIdInfo : IRazerSerializable
	{
		public string ExternalId { get; set; }

		public IdSource Source { get; set; }

		public ExternalIdInfo()
			: this(string.Empty, IdSource.Undefined)
		{
		}

		public ExternalIdInfo(string id, IdSource source)
		{
			ExternalId = id;
			Source = source;
		}

		public ExternalIdInfo(XDocument doc)
			: this(doc.Element("FriendIdInfo"))
		{
		}

		private ExternalIdInfo(XElement element)
		{
			ExternalId = (string)element.Element("ExternalId");
			Source = (IdSource)(int)element.Element("Source");
		}

		public XElement Serialize()
		{
			return new XElement("FriendIdInfo", new XElement("ExternalId", ExternalId), new XElement("Source", (int)Source));
		}
	}
}
