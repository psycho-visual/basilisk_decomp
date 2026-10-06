namespace Razer.AccountManager
{
	public enum LicenseResult
	{
		RequestFailed = -99999,
		SerialDoesNotMatch = -11,
		MaxLicensesReached = -10,
		UnknownSerialNumber = -9,
		UnableToSend = -8,
		InvalidAppId = -7,
		LicenseInactive = -6,
		LookupFailed = -5,
		Expired = -4,
		LicenseTaken = -3,
		InvalidLicense = -2,
		RegistrationFailed = -1,
		AlreadyRegistered = 0,
		Success = 1,
		UserNotRegistered = 2,
		RegistrationPending = 3,
		SendSuccessful = 4,
		Deactivated = 5,
		LicensesAvailable = 6
	}
}
