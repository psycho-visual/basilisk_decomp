using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class LicensesAvailableHandler : HandlerBase<bool>
	{
		public LicensesAvailableHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.LicensesAvailable)
		{
		}

		public bool Execute(string appId, string serialNumber)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(appId);
					binaryWriter.Write(serialNumber);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override bool Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return binaryReader.ReadBoolean();
				}
			}
		}
	}
}
