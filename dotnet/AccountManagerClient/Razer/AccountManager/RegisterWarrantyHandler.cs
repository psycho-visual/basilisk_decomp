using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class RegisterWarrantyHandler : HandlerBase<WarrantyDevice>
	{
		public RegisterWarrantyHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.RegisterWarranty)
		{
		}

		public WarrantyDevice Execute(WarrantyUser user, WarrantyItem device)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter writer = new BinaryWriter(memoryStream))
				{
					writer.Write((IRazerSerializable)user);
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
