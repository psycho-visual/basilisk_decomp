namespace Razer.AccountManager
{
	public enum LoginResult : uint
	{
		Success,
		Canceled,
		Failed,
		RefreshFailed,
		FailedNoCredentials,
		OtpRequired,
		RefreshSucceeded
	}
}
