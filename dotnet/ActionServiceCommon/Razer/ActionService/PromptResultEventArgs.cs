using System;
using System.Xml.Linq;

namespace Razer.ActionService
{
	public class PromptResultEventArgs : EventArgs, IRazerSerializable
	{
		public PromptType Type { get; set; }

		public PromptResult Result { get; set; }

		public PromptResultEventArgs()
		{
		}

		public PromptResultEventArgs(XDocument doc)
			: this(doc.Element("PromptResultEventArgs"))
		{
		}

		private PromptResultEventArgs(XElement element)
		{
			Result = (PromptResult)(int)element.Element("Result");
			Type = (PromptType)(int)element.Element("Type");
		}

		public XElement Serialize()
		{
			return new XElement("PromptResultEventArgs", new XElement("Result", (int)Result), new XElement("Type", (int)Type));
		}
	}
}
