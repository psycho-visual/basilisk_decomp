using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class TfaDetails : IRazerSerializable
	{
		public List<TfaMethod> TfaMethods { get; private set; } = new List<TfaMethod>();

		public DateTime CreatedDate { get; set; }

		public int RemainingCodes { get; set; }

		public int TotalCodes { get; set; }

		public TfaDetails()
		{
		}

		public TfaDetails(XDocument doc)
			: this(doc.Element("auth-opts"))
		{
		}

		public TfaDetails(XElement response)
		{
			IEnumerable<XElement> enumerable = response?.Element("tfa-methods")?.Elements("method");
			if (response == null || enumerable == null)
			{
				return;
			}
			foreach (XElement item in enumerable)
			{
				TfaMethods.Add(new TfaMethod(item));
			}
			XElement xElement = response.Element("recovery");
			if (xElement == null)
			{
				return;
			}
			string text = (string)xElement.Element("create_ts");
			if (text != null)
			{
				CreatedDate = text.AsUnixTime();
			}
			else
			{
				CreatedDate = DateTime.Now;
			}
			RemainingCodes = (int)xElement.Element("remaining_codes");
			XElement xElement2 = xElement.Element("total_codes");
			if (xElement2 != null)
			{
				TotalCodes = (int)xElement2;
				return;
			}
			xElement2 = xElement.Element("used_codes");
			if (xElement2 != null)
			{
				TotalCodes = RemainingCodes + (int)xElement2;
			}
		}

		public XElement Serialize()
		{
			return new XElement("auth-opts", new XElement("tfa-methods", TfaMethods.Select((TfaMethod na) => na.Serialize())), new XElement("recovery", new XElement("create_ts", CreatedDate.ToUnixTime()), new XElement("remaining_codes", RemainingCodes), new XElement("total_codes", TotalCodes)));
		}
	}
}
