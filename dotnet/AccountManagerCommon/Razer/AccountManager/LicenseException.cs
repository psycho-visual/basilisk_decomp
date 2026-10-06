using Razer.ActionService;

namespace Razer.AccountManager
{
	public class LicenseException : CopException
	{
		public LicenseResult Result { get; private set; }

		public LicenseException(string message, LicenseResult result)
			: base(message, 0)
		{
			Result = result;
		}
	}
}
