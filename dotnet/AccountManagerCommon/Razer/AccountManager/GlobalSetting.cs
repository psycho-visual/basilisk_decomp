using System.ComponentModel;

namespace Razer.AccountManager
{
	public enum GlobalSetting : uint
	{
		[Description("Undefined")]
		Undefined,
		[Description("CollectGameData")]
		CollectGameData,
		[Description("OverlayEnabled")]
		OverlayEnabled
	}
}
