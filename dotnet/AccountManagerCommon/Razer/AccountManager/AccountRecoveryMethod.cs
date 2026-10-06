using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum AccountRecoveryMethod
	{
		[Description("RESET_LINK_PRIMARY")]
		ResetLinkPrimary,
		[Description("RESET_LINK_SECONDARY")]
		ResetLinkSecondary
	}
}
