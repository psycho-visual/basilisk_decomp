namespace Razer.AccountManager
{
	public enum LogoutReason
	{
		Unknown,
		UserInitiated,
		Logoff,
		TokenRefreshFailed,
		NoConnections,
		AccountDeleted,
		RemoteLogout
	}
}
