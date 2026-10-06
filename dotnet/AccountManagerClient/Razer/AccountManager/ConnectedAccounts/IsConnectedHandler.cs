using System;
using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager.ConnectedAccounts
{
	internal sealed class IsConnectedHandler : HandlerBase<bool>
	{
		public IsConnectedHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.IsConnectedToAccount)
		{
		}

		public bool Execute(ConnectedAccount account)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((int)account);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override bool Deserialize(byte[] data)
		{
			return BitConverter.ToBoolean(data, 0);
		}
	}
}
