using System;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetUILanguageHandler : HandlerBase<LanguageInfo>
	{
		public GetUILanguageHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetUiLanguage)
		{
		}

		public LanguageInfo Execute()
		{
			return Send(null);
		}

		protected override LanguageInfo Deserialize(byte[] data)
		{
			return new LanguageInfo((Languages)BitConverter.ToInt32(data, 0));
		}
	}
}
