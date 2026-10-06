using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetSettingHandler : HandlerBase<SettingReadResult>
	{
		public GetSettingHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetSetting)
		{
		}

		public SettingReadResult Execute(string product, string path, string name, SettingSource source)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write(path);
					binaryWriter.Write(name);
					binaryWriter.Write((uint)source);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override SettingReadResult Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<SettingReadResult>();
				}
			}
		}
	}
}
