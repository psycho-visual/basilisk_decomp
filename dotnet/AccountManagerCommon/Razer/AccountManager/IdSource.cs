using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum IdSource
	{
		[Description("Undefined")]
		Undefined,
		[Description("fb")]
		Facebook,
		[Description("skype")]
		Skype,
		[Description("steam")]
		Steam,
		[Description("lol")]
		LoL
	}
}
