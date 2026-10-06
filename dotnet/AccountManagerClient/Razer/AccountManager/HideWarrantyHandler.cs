using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class HideWarrantyHandler : HandlerBase<WarrantyDevice>
	{
		public HideWarrantyHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.HideWarranty)
		{
		}

		public WarrantyDevice Execute(WarrantyItem device)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write((IRazerSerializable)device);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override WarrantyDevice Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<WarrantyDevice>();
				}
			}
		}
	}
}
