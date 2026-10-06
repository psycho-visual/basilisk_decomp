using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class OtpRequiredException : Exception, IRazerSerializable
	{
		public string OtpMethod { get; private set; }

		public TfaType TfaType { get; private set; }

		public List<TfaMethod> AlternateMethods { get; private set; }

		public string TransactionId { get; private set; }

		public AuthenticatorLoginResponse AuthDetails { get; private set; }

		public OtpRequiredException(string method, TfaType type, List<TfaMethod> altMethods, string transactionId, AuthenticatorLoginResponse authResponse, string message)
			: base(message)
		{
			OtpMethod = method;
			TfaType = type;
			TransactionId = transactionId;
			AlternateMethods = altMethods ?? new List<TfaMethod>();
			AuthDetails = authResponse;
		}

		public OtpRequiredException(XElement element)
		{
			OtpMethod = (string)element.Element("OtpMethod");
			TfaType = (TfaType)(int)element.Element("TfaType");
			TransactionId = (string)element.Element("TransactionId");
			AlternateMethods = new List<TfaMethod>();
			foreach (XElement item in element.Element("AlternateMethods").Elements("method"))
			{
				AlternateMethods.Add(new TfaMethod(item));
			}
			XElement xElement = element.Element("authenticator");
			if (xElement != null)
			{
				AuthDetails = new AuthenticatorLoginResponse(xElement);
			}
		}

		public XElement Serialize()
		{
			XElement xElement = new XElement("OtpRequiredException", new XElement("OtpMethod", OtpMethod), new XElement("TfaType", (int)TfaType), new XElement("AlternateMethods", AlternateMethods.Select((TfaMethod x) => x.Serialize())), new XElement("TransactionId", TransactionId));
			if (AuthDetails != null)
			{
				xElement.Add(AuthDetails.Serialize());
			}
			return xElement;
		}
	}
}
