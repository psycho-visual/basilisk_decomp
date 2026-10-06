using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetDeviceInfoHandler : HandlerBase<string>
	{
		public GetDeviceInfoHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetDeviceInfo)
		{
		}

		public string Execute(RazerDevice device)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write(device);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override string Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return binaryReader.ReadString();
				}
			}
		}
	}
}
