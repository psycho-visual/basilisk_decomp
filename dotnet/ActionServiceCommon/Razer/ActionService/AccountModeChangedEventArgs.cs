using System;
using System.Xml.Linq;

namespace Razer.ActionService
{
	public class AccountModeChangedEventArgs : EventArgs, IRazerSerializable
	{
		public AccountMode NewMode { get; private set; }

		public AccountMode PreviousMode { get; private set; }

		public AccountModeChangedEventArgs(AccountMode from, AccountMode to)
		{
			NewMode = to;
			PreviousMode = from;
		}

		public AccountModeChangedEventArgs(XDocument doc)
			: this(doc.Element("AccountModeChangedEventArgs"))
		{
		}

		private AccountModeChangedEventArgs(XElement element)
		{
			NewMode = (AccountMode)(int)element.Element("NewMode");
			PreviousMode = (AccountMode)(int)element.Element("PreviousMode");
		}

		public XElement Serialize()
		{
			return new XElement("AccountModeChangedEventArgs", new XElement("NewMode", (int)NewMode), new XElement("PreviousMode", (int)PreviousMode));
		}
	}
}
