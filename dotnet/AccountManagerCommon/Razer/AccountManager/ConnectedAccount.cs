using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum ConnectedAccount
	{
		[Description("UNKNOWN")]
		Unknown = 0,
		[Description("FACEBOOK")]
		Facebook = 1,
		[Description("TWITTER")]
		Twitter = 3,
		[Description("GOOGLE")]
		Google = 4,
		[Description("TWITCH")]
		Twitch = 7,
		[Description("SMASHCAST")]
		HitboxTv = 13,
		[Description("STEAM")]
		Steam = 14,
		[Description("QQ")]
		Qq = 15
	}
}
