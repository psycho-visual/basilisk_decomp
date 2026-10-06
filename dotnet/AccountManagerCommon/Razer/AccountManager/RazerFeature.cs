using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum RazerFeature
	{
		Undefined,
		[Description("dark_theme")]
		DarkTheme,
		[Description("ssi")]
		SocialSignIn,
		[Description("tfa")]
		Tfa,
		[Description("connected_accounts")]
		ConnectedAccounts
	}
}
