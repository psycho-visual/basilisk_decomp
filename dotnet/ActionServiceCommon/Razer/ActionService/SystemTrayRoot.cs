using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Xml.Linq;

namespace Razer.ActionService
{
	public class SystemTrayRoot
	{
		private Dictionary<string, SystemTrayItem> m_items = new Dictionary<string, SystemTrayItem>();

		public RazerApps Application { get; private set; }

		public string LaunchPath { get; set; }

		public string LaunchArguments { get; set; }

		internal SystemTrayAddedDelegate ItemAdded { get; set; }

		internal SystemTrayRemovedDelegate ItemRemoved { get; set; }

		internal SystemTrayTextChangedDelegate TextUpdated { get; set; }

		internal SystemTraySubTextChangedDelegate SubTextUpdated { get; set; }

		internal SystemTrayCheckedChangedDelegate CheckedChanged { get; set; }

		internal SystemTrayCountChangedDelegate CountChanged { get; set; }

		internal SystemTrayImageChangedDelegate DisplayImageChanged { get; set; }

		internal SystemTrayColorChangedDelegate ColorChanged { get; set; }

		internal SystemTrayTypeChangedDelegate TypeChanged { get; set; }

		public SystemTrayRoot(RazerApps application)
		{
			Application = application;
		}

		public void AddItem(SystemTrayItem subitem)
		{
			subitem.ItemAdded = OnItemAdded;
			subitem.ItemRemoved = OnItemRemoved;
			subitem.TextUpdated = OntextUpdated;
			subitem.SubTextUpdated = OnSubTextUpdated;
			subitem.CheckedChanged = OnCheckedChanged;
			subitem.CountChanged = OnCountChanged;
			subitem.DisplayImageChanged = OnDisplayImageChanged;
			subitem.ColorChanged = OnColorChanged;
			subitem.TypeChanged = OnTypeChanged;
			subitem.RemoveMethod = RemoveItem;
			m_items.Add(subitem.Id, subitem);
			if (ItemAdded != null)
			{
				ItemAdded(string.Empty, subitem);
			}
		}

		public void RemoveItem(string id)
		{
			if (ItemRemoved != null)
			{
				ItemRemoved(string.Empty, id);
			}
			m_items.Remove(id);
		}

		public List<SystemTrayItem> GetItems()
		{
			return m_items.Values.ToList();
		}

		public void OnClick(string id)
		{
			using (Dictionary<string, SystemTrayItem>.ValueCollection.Enumerator enumerator = m_items.Values.GetEnumerator())
			{
				while (enumerator.MoveNext() && !enumerator.Current.OnClick(id))
				{
				}
			}
		}

		public SystemTrayRoot(XElement element)
		{
			Application = (RazerApps)(int)element.Element("Application");
			LaunchPath = (string)element.Element("LaunchPath");
			LaunchArguments = (string)element.Element("LaunchArguments");
			foreach (XElement item in element.Element("Items").Elements("SystemTrayItem"))
			{
				AddItem(new SystemTrayItem(item));
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("SystemTrayRoot", new XElement("Application", (int)Application), new XElement("Items", m_items.Values.Select((SystemTrayItem x) => x.Serialize())));
			xElement.Add(new XElement("LaunchPath", LaunchPath));
			xElement.Add(new XElement("LaunchArguments", LaunchArguments));
			return xElement;
		}

		private void OnItemAdded(string parentId, SystemTrayItem newItem)
		{
			ItemAdded?.Invoke(parentId, newItem);
		}

		private void OnItemRemoved(string parentId, string itemId)
		{
			ItemRemoved?.Invoke(parentId, itemId);
		}

		private void OntextUpdated(string itemId, string updatedText)
		{
			TextUpdated?.Invoke(itemId, updatedText);
		}

		private void OnSubTextUpdated(string itemId, string updatedText)
		{
			SubTextUpdated?.Invoke(itemId, updatedText);
		}

		private void OnCheckedChanged(string itemId, bool isChecked)
		{
			CheckedChanged?.Invoke(itemId, isChecked);
		}

		private void OnCountChanged(string itemId, int count)
		{
			CountChanged?.Invoke(itemId, count);
		}

		private void OnDisplayImageChanged(string itemId, Bitmap image)
		{
			DisplayImageChanged?.Invoke(itemId, image);
		}

		private void OnColorChanged(string itemId, int argbColor)
		{
			ColorChanged?.Invoke(itemId, argbColor);
		}

		private void OnTypeChanged(string itemId, SystemTrayItem.SpecialType type)
		{
			TypeChanged?.Invoke(itemId, type);
		}
	}
}
