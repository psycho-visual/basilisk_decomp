using System;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetUIThemeHandler : HandlerBase<UiTheme>
	{
		public GetUIThemeHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetUiTheme)
		{
		}

		public UiTheme Execute()
		{
			return Send(null);
		}

		protected override UiTheme Deserialize(byte[] data)
		{
			return (UiTheme)BitConverter.ToInt32(data, 0);
		}
	}
}
