using System;
using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetLastSyncDateHandler : HandlerBase<DateTime>
	{
		public GetLastSyncDateHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetLastSyncDate)
		{
		}

		public DateTime Execute(string product)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override DateTime Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return DateTime.FromBinary(binaryReader.ReadInt64());
				}
			}
		}
	}
}
