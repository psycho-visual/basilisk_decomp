using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetCredentialsHandler : HandlerBase<ConnectedAccountCredentials>
	{
		public GetCredentialsHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetAccountCredentials)
		{
		}

		public ConnectedAccountCredentials Execute(ConnectedAccount account)
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

		protected override ConnectedAccountCredentials Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					if (!binaryReader.ReadBoolean())
					{
						return null;
					}
					return binaryReader.Read<ConnectedAccountCredentials>();
				}
			}
		}
	}
}
