using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class AddLicenseCodeHandler : HandlerBase<AppLicense>
	{
		public AddLicenseCodeHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.AddLicenseCode)
		{
		}

		public AppLicense Execute(string appId, string licensCode)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(appId);
					binaryWriter.Write(licensCode);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override AppLicense Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<AppLicense>();
				}
			}
		}
	}
}
