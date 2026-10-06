using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class RefreshAccountTokenHandler : HandlerBase<object>
	{
		public RefreshAccountTokenHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.RefreshAccountToken)
		{
		}

		public void Execute(ConnectedAccount account, string refreshToken)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((int)account);
					binaryWriter.Write(refreshToken);
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
