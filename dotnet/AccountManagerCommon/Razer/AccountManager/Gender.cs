using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum Gender
	{
		[Description("human")]
		Unspecified,
		[Description("male")]
		Male,
		[Description("female")]
		Female
	}
}
