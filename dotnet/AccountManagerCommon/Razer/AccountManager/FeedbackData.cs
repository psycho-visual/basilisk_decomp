using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class FeedbackData : IRazerSerializable
	{
		public class SupplementalItem
		{
			public string Name { get; set; }

			public string ArchiveName { get; set; }

			public SupplementalItem()
			{
			}

			public SupplementalItem(string name, string archiveName)
			{
				Name = name;
				ArchiveName = archiveName;
			}

			internal SupplementalItem(XElement element)
			{
				Name = (string)element.Element("Name");
				ArchiveName = (string)element.Element("ArchiveName");
			}

			internal XElement Serialize()
			{
				return new XElement("SupplementalItem", new XElement("Name", Name), new XElement("ArchiveName", ArchiveName));
			}

			public override string ToString()
			{
				return $"SupplementalItem: \"Name\"=\"{Name}\", \"ArchiveName\"=\"{ArchiveName}\"";
			}

			public override bool Equals(object obj)
			{
				if (obj == null)
				{
					return false;
				}
				if (!(obj is SupplementalItem supplementalItem))
				{
					return false;
				}
				if (Name == supplementalItem.Name)
				{
					return ArchiveName == supplementalItem.ArchiveName;
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Name.GetHashCode() ^ ArchiveName.GetHashCode();
			}

			public static bool operator ==(SupplementalItem lhs, SupplementalItem rhs)
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

			public static bool operator !=(SupplementalItem lhs, SupplementalItem rhs)
			{
				return !(lhs == rhs);
			}
		}

		public enum FeedbackCategory
		{
			Undefined,
			General,
			FeatureRequest,
			BugReport
		}

		public string ServiceCode { get; set; }

		public FeedbackCategory Category { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public bool IncludeLogs { get; set; }

		public string SupplementalData { get; set; }

		public string LogDirectory { get; set; }

		public RazerDevice Device { get; set; }

		public List<string> SupplementalFiles { get; set; }

		public List<SupplementalItem> SupplementalLogs { get; set; }

		public FeedbackData()
		{
			SupplementalFiles = new List<string>();
			SupplementalLogs = new List<SupplementalItem>();
		}

		public FeedbackData(XDocument doc)
			: this(doc.Element("FeedbackData"))
		{
		}

		private FeedbackData(XElement element)
		{
			ServiceCode = (string)element.Element("ServiceCode");
			FeedbackCategory result = FeedbackCategory.General;
			if (!Enum.TryParse<FeedbackCategory>((string)element.Element("Category"), out result))
			{
				result = FeedbackCategory.General;
			}
			Category = result;
			Title = (string)element.Element("Title");
			Description = (string)element.Element("Description");
			IncludeLogs = (bool)element.Element("IncludeLogs");
			SupplementalData = (string)element.Element("SupplementalData");
			LogDirectory = (string)element.Element("LogDirectory");
			SupplementalFiles = new List<string>();
			foreach (XElement item in element.Element("SupplementalFiles").Descendants("SupplementalFile"))
			{
				SupplementalFiles.Add((string)item);
			}
			SupplementalLogs = new List<SupplementalItem>();
			foreach (XElement item2 in element.Element("SupplementalLogs").Descendants("SupplementalItem"))
			{
				SupplementalLogs.Add(new SupplementalItem(item2));
			}
			XElement xElement = element.Element("Device");
			if (xElement != null)
			{
				uint vid = (uint)xElement.Element("VID");
				uint pid = (uint)xElement.Element("PID");
				byte edition = Convert.ToByte((uint)xElement.Element("Edition"));
				string serialNumber = (string)xElement.Element("SerialNumber");
				string text = (string)xElement.Element("FirmwareVersion");
				Device = new RazerDevice(pid, edition, vid);
				Device.SerialNumber = serialNumber;
				if (!string.IsNullOrWhiteSpace(text))
				{
					Device.FirmwareVersion = new Version(text);
				}
			}
		}

		public XElement Serialize()
		{
			if (SupplementalFiles == null)
			{
				SupplementalFiles = new List<string>();
			}
			if (SupplementalLogs == null)
			{
				SupplementalLogs = new List<SupplementalItem>();
			}
			XElement xElement = new XElement("FeedbackData", new XElement("ServiceCode", ServiceCode), new XElement("Category", Category), new XElement("Title", Title), new XElement("Description", Description), new XElement("IncludeLogs", IncludeLogs), new XElement("SupplementalData", SupplementalData), new XElement("LogDirectory", LogDirectory), new XElement("SupplementalFiles", SupplementalFiles.Select((string x) => new XElement("SupplementalFile", x))), new XElement("SupplementalLogs", SupplementalLogs.Select((SupplementalItem x) => x.Serialize())));
			if (Device != null)
			{
				xElement.Add(new XElement("Device", new XElement("VID", Device.Vid), new XElement("PID", Device.Pid), new XElement("Edition", Convert.ToUInt32(Device.Edition)), new XElement("SerialNumber", Device.SerialNumber), new XElement("FirmwareVersion", Device.FirmwareVersion)));
			}
			return xElement;
		}

		public override string ToString()
		{
			return $"FeedbackData: \"ServiceCode\"=\"{ServiceCode}\", \"Category\"=\"{Category}\", \"Title\"=\"{Title}\", " + $"\"Description\"=\"{Description}\", \"IncludeLogs\"=\"{IncludeLogs}\", \"SupplementalData\"=\"{SupplementalData}\", " + $"\"LogDirectory\"=\"{LogDirectory}\", \"Device\"=\"{Device}\"";
		}

		public void AddLogs(string name, string archiveName)
		{
			if (string.IsNullOrEmpty(archiveName))
			{
				archiveName = name;
			}
			SupplementalLogs.Add(new SupplementalItem(name, archiveName));
		}
	}
}
