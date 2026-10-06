using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public struct BackupCode : IRazerSerializable
	{
		public int Index { get; set; }

		public string Code { get; set; }

		public bool IsUsed { get; set; }

		public BackupCode(int index, string code, bool isUsed = false)
		{
			Index = index;
			Code = code;
			IsUsed = isUsed;
		}

		public BackupCode(XDocument doc)
			: this(doc.Element("BackupCode"))
		{
		}

		public BackupCode(XElement element)
		{
			Index = (int)element.Element("Index");
			Code = (string)element.Element("Code");
			IsUsed = (bool)element.Element("IsUsed");
		}

		public XElement Serialize()
		{
			return new XElement("BackupCode", new XElement("Index", Index), new XElement("Code", Code), new XElement("IsUsed", IsUsed));
		}
	}
}
