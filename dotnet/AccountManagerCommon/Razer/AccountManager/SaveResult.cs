namespace Razer.AccountManager
{
	public enum SaveResult : uint
	{
		Success,
		ServerNotAvailable,
		ConflictDetected,
		Failed_Unknown,
		Failed_OfflineMode
	}
}
