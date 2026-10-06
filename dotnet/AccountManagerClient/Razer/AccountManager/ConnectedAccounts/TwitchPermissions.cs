namespace Razer.AccountManager.ConnectedAccounts
{
	public static class TwitchPermissions
	{
		public static class Channel
		{
			public static readonly string Read = "channel_read";

			public static readonly string Edit = "channel_editor";

			public static readonly string TriggerCommercials = "channel_commercial";

			public static readonly string ResetStream = "channel_stream";

			public static readonly string CheckSubscriptions = "channel_check_subscription";

			public static readonly string ReadSubscriptions = "channel_subscriptions";
		}

		public static readonly string Read = "user_read";

		public static readonly string EditIgnoreList = "user_blocks_edit";

		public static readonly string ReadIgnoreList = "user_blocks_read";

		public static readonly string EditFollowedChannels = "user_follows_edit";

		public static readonly string ReadSubscriptions = "user_subscriptions";

		public static readonly string ChatLogin = "chat_login";
	}
}
