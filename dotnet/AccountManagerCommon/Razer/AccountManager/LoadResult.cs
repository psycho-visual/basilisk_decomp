namespace Razer.AccountManager
{
	public enum LoadResult : uint
	{
		Success,
		Failed_DataNotFound,
		Failed_ServerNotAvailable,
		Failed_Unknown,
		Conflicted,
		Not_Retrieved,
		Failed_OfflineMode
	}
}
