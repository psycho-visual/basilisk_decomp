using System;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class SyncProgressEventArgs : EventArgs, IRazerSerializable
	{
		public int CompleteItems { get; set; }

		public int TotalItems { get; private set; }

		public DataSyncItem CurrentItem { get; set; }

		public SyncProgressEventArgs(int toalItems)
		{
			TotalItems = toalItems;
		}

		public SyncProgressEventArgs(XDocument doc)
			: this(doc.Element("SyncProgressEventArgs"))
		{
		}

		public SyncProgressEventArgs(XElement element)
		{
			CompleteItems = (int)element.Element("CompleteItems");
			TotalItems = (int)element.Element("TotalItems");
			XElement element2 = element.Element("DataSyncItem");
			CurrentItem = new DataSyncItem(element2);
		}

		public XElement Serialize()
		{
			return new XElement("SyncProgressEventArgs", new XElement("CompleteItems", CompleteItems), new XElement("TotalItems", TotalItems), CurrentItem.Serialize());
		}
	}
}
