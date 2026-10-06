namespace Razer.ActionService
{
	public enum ExceptionTypes : uint
	{
		General = 0u,
		Cop = 1u,
		NotImplemented = 2u,
		InvalidOperation = 3u,
		ArgumentOutOfRange = 4u,
		FileLoad = 5u,
		OtpRequired = 4096u,
		OtpFailed = 4097u,
		License = 4098u,
		ProfileIncomplete = 4099u,
		AccountNotLinked = 4100u,
		ConsentRequired = 4101u
	}
}
