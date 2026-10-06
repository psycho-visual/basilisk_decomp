namespace Razer.ActionService
{
	public enum NacCommands : uint
	{
		Undefined = 0u,
		Register = 1u,
		Show = 2u,
		ShowNotification = 3u,
		ShowUpdates = 4u,
		Shutdown = 5u,
		Unused = 6u,
		SetSystemTray = 7u,
		SystemTrayItemRemoved = 8u,
		SystemTrayItemAdded = 9u,
		SystemTrayItemTextUpdated = 10u,
		SystemTrayItemCheckedChanged = 11u,
		SystemTrayItemCountChanged = 12u,
		SystemTrayDisplayImageChanged = 13u,
		SystemTrayItemColorChanged = 14u,
		ShowPage = 15u,
		SetFeedbackTemplate = 16u,
		ShowSystemTrayMessage = 17u,
		SystemTrayItemSubTextUpdated = 18u,
		AddFeedbackDevice = 19u,
		RemoveFeedbackDevice = 20u,
		ClearFeedbackDevices = 21u,
		ShowUserPrompt = 22u,
		RequestTosConsent = 23u,
		Event_SystemTray_Clicked = 65536u,
		Event_ExitApp = 65537u,
		Event_StartLogin = 65538u,
		Event_Update_InstallComplete = 65539u,
		Callback_PromptComplete = 65540u,
		Event_TosConsented = 65541u,
		Exception = 1073741824u,
		Response = 2147483648u
	}
}
