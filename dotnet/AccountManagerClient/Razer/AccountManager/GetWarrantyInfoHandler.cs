using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetWarrantyInfoHandler : HandlerBase<WarrantyResponse>
	{
		public GetWarrantyInfoHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetWarrantyInfo)
		{
		}

		public WarrantyResponse Execute(RazerDevice device)
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

		protected override WarrantyResponse Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<WarrantyResponse>();
				}
			}
		}
	}
}
