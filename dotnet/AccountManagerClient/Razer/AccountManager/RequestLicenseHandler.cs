using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class RequestLicenseHandler : HandlerBase<AppLicense>
	{
		public RequestLicenseHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.RequestLicense)
		{
		}

		public AppLicense Execute(string appId, LicenseLanguageCode language, LicenseDevice device)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(appId);
					binaryWriter.Write((int)language);
					binaryWriter.Write((IRazerSerializable)device);
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
