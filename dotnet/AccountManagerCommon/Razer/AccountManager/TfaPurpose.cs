using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum TfaPurpose
	{
		Undefined,
		[Description("tfa-login")]
		Login,
		[Description("tfa-opt-out")]
		OptOut,
		[Description("tfa-method-verification")]
		MethodVerification,
		[Description("tfa-adhoc-otp")]
		AdHoc,
		[Description("tfa-global-setting")]
		GlobalSetting,
		[Description("tfa-user-prefs")]
		UserSetting,
		[Description("tfa-method-change")]
		MethodChange,
		[Description("tfa-retrieve-codes")]
		RetrieveCodes
	}
}
