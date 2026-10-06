namespace Razer.AccountManager
{
	public enum SyncStatus
	{
		Pending,
		Complete,
		Failed_OfflineMode,
		Failed_NetworkError,
		Failed_Unknown,
		Conflicted,
		Cancelled
	}
}
