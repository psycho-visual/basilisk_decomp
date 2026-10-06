using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class OtpRequiredEventArgs : EventArgs, IRazerSerializable
	{
		public string OtpMethod { get; private set; }

		public TfaType OtpType { get; private set; }

		public List<TfaMethod> AltMethods { get; private set; }

		public string TransactionId { get; private set; }

		public AuthenticatorLoginResponse AuthDetails { get; private set; }

		public OtpRequiredEventArgs(OtpRequiredException otpEx)
		{
			OtpMethod = otpEx.OtpMethod;
			OtpType = otpEx.TfaType;
			AltMethods = otpEx.AlternateMethods;
			TransactionId = otpEx.TransactionId;
			AuthDetails = otpEx.AuthDetails;
		}

		public OtpRequiredEventArgs(XDocument doc)
			: this(doc.Element("OtpRequiredEventArgs"))
		{
		}

		private OtpRequiredEventArgs(XElement element)
		{
			OtpMethod = (string)element.Element("OtpMethod");
			OtpType = (TfaType)(uint)element.Element("TfaType");
			XElement xElement = element.Element("AltMethods");
			if (xElement != null)
			{
				AltMethods = new List<TfaMethod>();
				foreach (XElement item in xElement.Elements("tfa-method"))
				{
					AltMethods.Add(new TfaMethod(item));
				}
			}
			TransactionId = (string)element.Element("TransactionId");
			XElement xElement2 = element.Element("authenticator");
			if (xElement2 != null)
			{
				AuthDetails = new AuthenticatorLoginResponse(xElement2);
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("OtpRequiredEventArgs", new XElement("OtpMethod", OtpMethod), new XElement("TfaType", (uint)OtpType), new XElement("AltMethods", AltMethods.Select((TfaMethod a) => a)), new XElement("TransactionId", TransactionId));
			if (AuthDetails != null)
			{
				xElement.Add(AuthDetails.Serialize());
			}
			return xElement;
		}
	}
}
