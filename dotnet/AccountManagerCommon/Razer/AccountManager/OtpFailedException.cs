using System.Collections.Generic;
using System.Linq;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class OtpFailedException : CopException
	{
		public IEnumerable<TfaMethod> AlternateMethods { get; private set; }

		public string TransactionId { get; private set; }

		public bool AltMethodAvailable => AlternateMethods.Count() > 0;

		public OtpFailedException(string transactionId, IEnumerable<TfaMethod> altMethods)
			: base("Invalid OTP", ExceptionCode.TfaInvalidTotp)
		{
			TransactionId = transactionId ?? string.Empty;
			AlternateMethods = altMethods;
		}
	}
}
