using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager.ConnectedAccounts
{
	internal sealed class DisconnectFromAccountHandler : HandlerBase<object>
	{
		public DisconnectFromAccountHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.DisconnectFromAccount)
		{
		}

		public void Execute(ConnectedAccount account)
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
			Send(data);
		}

		protected override object Deserialize(byte[] data)
		{
			return null;
		}
	}
}
