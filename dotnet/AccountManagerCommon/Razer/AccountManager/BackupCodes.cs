using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class BackupCodes : IRazerSerializable
	{
		public List<BackupCode> Codes { get; set; }

		public DateTime CreatedDate { get; set; }

		public BackupCodes()
		{
		}

		public BackupCodes(XDocument doc)
			: this(doc.Element("BackupCodes"))
		{
		}

		public BackupCodes(XElement element)
		{
			List<BackupCode> list = new List<BackupCode>();
			foreach (XElement item in element.Descendants("BackupCode"))
			{
				list.Add(new BackupCode(item));
			}
			Codes = list;
			CreatedDate = (DateTime)element.Element("CreatedDate");
		}

		public XElement Serialize()
		{
			return new XElement("BackupCodes", new XElement("Codes", Codes.Select((BackupCode x) => x.Serialize())), new XElement("CreatedDate", CreatedDate));
		}
	}
}
