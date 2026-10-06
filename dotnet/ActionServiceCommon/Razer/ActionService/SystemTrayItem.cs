using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using log4net;

namespace Razer.ActionService
{
	public class SystemTrayItem
	{
		public enum SpecialType
		{
			Normal,
			BoostButton,
			StartStopButton,
			RefreshButton
		}

		private static readonly ILog Logger = LogManager.GetLogger("SystemTrayItem");

		private string _text;

		private string _subText;

		private Bitmap m_displayImage;

		private int _count;

		private bool _checked;

		private int _argbColor;

		private SpecialType m_itemType;

		private Dictionary<string, SystemTrayItem> m_subitems = new Dictionary<string, SystemTrayItem>();

		public string Id { get; private set; }

		public string ParentId { get; private set; }

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				OntextUpdated(Id, value);
				_text = value;
			}
		}

		public string SubText
		{
			get
			{
				return _subText;
			}
			set
			{
				OnSubTextUpdated(Id, value);
				_subText = value;
			}
		}

		public Bitmap DisplayImage
		{
			get
			{
				return m_displayImage;
			}
			set
			{
				OnDisplayImageChanged(Id, value);
				m_displayImage = value;
			}
		}

		public int Count
		{
			get
			{
				return _count;
			}
			set
			{
				OnCountChanged(Id, value);
				_count = value;
			}
		}

		public bool IsCheckable { get; set; }

		public bool Checked
		{
			get
			{
				return _checked;
			}
			set
			{
				OnCheckedChanged(Id, value);
				_checked = value;
			}
		}

		public int ArgbColor
		{
			get
			{
				return _argbColor;
			}
			set
			{
				OnColorChanged(Id, value);
				_argbColor = value;
			}
		}

		public Color Color
		{
			get
			{
				return Color.FromArgb(ArgbColor);
			}
			set
			{
				ArgbColor = value.ToArgb();
			}
		}

		public SpecialType Type
		{
			get
			{
				return m_itemType;
			}
			set
			{
				OnTypeChanged(Id, value);
				m_itemType = value;
			}
		}

		internal RemoveItemDelegate RemoveMethod { get; set; }

		internal SystemTrayAddedDelegate ItemAdded { get; set; }

		internal SystemTrayRemovedDelegate ItemRemoved { get; set; }

		internal SystemTrayTextChangedDelegate TextUpdated { get; set; }

		internal SystemTraySubTextChangedDelegate SubTextUpdated { get; set; }

		internal SystemTrayCheckedChangedDelegate CheckedChanged { get; set; }

		internal SystemTrayCountChangedDelegate CountChanged { get; set; }

		internal SystemTrayImageChangedDelegate DisplayImageChanged { get; set; }

		internal SystemTrayColorChangedDelegate ColorChanged { get; set; }

		internal SystemTrayTypeChangedDelegate TypeChanged { get; set; }

		public event EventHandler Clicked;

		public SystemTrayItem(string text, string subText = "")
		{
			Text = text;
			SubText = (string.IsNullOrEmpty(subText) ? string.Empty : subText);
			Color = Color.Black;
			Id = Guid.NewGuid().ToString();
		}

		public SystemTrayItem()
		{
			Color = Color.Black;
			Id = Guid.NewGuid().ToString();
		}

		public void Remove()
		{
			RemoveMethod?.Invoke(Id);
		}

		public void AddSubItem(SystemTrayItem subitem)
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
			subitem.RemoveMethod = RemoveSubItem;
			subitem.ParentId = Id;
			m_subitems.Add(subitem.Id, subitem);
			ItemAdded?.Invoke(Id, subitem);
		}

		public void RemoveSubItem(string subId)
		{
			ItemRemoved?.Invoke(Id, subId);
			m_subitems.Remove(subId);
		}

		public SystemTrayItem GetSubItem(string id)
		{
			SystemTrayItem value = null;
			m_subitems.TryGetValue(id, out value);
			return value;
		}

		public IEnumerable<SystemTrayItem> ListSubItems()
		{
			return m_subitems.Values;
		}

		internal bool OnClick(string id)
		{
			if (id == Id)
			{
				EventHandler eventHandler = this.Clicked;
				if (eventHandler != null)
				{
					try
					{
						eventHandler(this, null);
					}
					catch (Exception exception)
					{
						Logger.Error("Exception from click handler", exception);
					}
				}
				return true;
			}
			foreach (SystemTrayItem value in m_subitems.Values)
			{
				if (value.OnClick(id))
				{
					return true;
				}
			}
			return false;
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

		private void OnColorChanged(string itemId, int status)
		{
			ColorChanged?.Invoke(itemId, status);
		}

		private void OnTypeChanged(string itemId, SpecialType type)
		{
			TypeChanged?.Invoke(itemId, type);
		}

		public SystemTrayItem(XElement element)
		{
			Id = (string)element.Element("Id");
			Text = (string)element.Element("Text");
			SubText = (string)element.Element("SubText");
			Count = (int)element.Element("Count");
			IsCheckable = (bool)element.Element("IsCheckable");
			Checked = (bool)element.Element("Checked");
			if (element.Element("Color") != null)
			{
				ArgbColor = (int)element.Element("Color");
			}
			if (element.Element("Type") != null)
			{
				Type = (SpecialType)(int)element.Element("Type");
			}
			foreach (XElement item in element.Element("SubItems").Elements("SystemTrayItem"))
			{
				AddSubItem(new SystemTrayItem(item));
			}
			XElement xElement = element.Element("DisplayImage");
			if (xElement != null)
			{
				using (MemoryStream stream = new MemoryStream(Convert.FromBase64String(xElement.Value)))
				{
					DisplayImage = new Bitmap(stream);
				}
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("SystemTrayItem", new XElement("Id", Id), new XElement("Text", Text), new XElement("SubText", SubText), new XElement("Count", Count), new XElement("IsCheckable", IsCheckable), new XElement("Checked", Checked), new XElement("Color", ArgbColor), new XElement("Type", (int)Type), new XElement("SubItems", m_subitems.Values.Select((SystemTrayItem x) => x.Serialize())));
			if (DisplayImage != null)
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					DisplayImage.Save(memoryStream, ImageFormat.Png);
					byte[] inArray = memoryStream.ToArray();
					xElement.Add(new XElement("DisplayImage", Convert.ToBase64String(inArray)));
				}
			}
			return xElement;
		}

		public override string ToString()
		{
			return $"SystemTrayItem: \"Id\"=\"{Id}\", \"Text\"=\"{Text}\", \"SubText\"=\"{SubText}\", \"Count\"=\"{Count}\", " + $"\"IsCheckable\"=\"{IsCheckable}\", \"Checked\"=\"{Checked}\", \"ArgbColor\"=\"{ArgbColor}\", \"Type\"=\"{Type}\"";
		}
	}
}
