using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class SetSettingHandler : HandlerBase<SaveResult>
	{
		public SetSettingHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.SetSetting)
		{
		}

		public SaveResult Execute(string product, RzSetting setting, SettingSaveType type)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write((IRazerSerializable)setting);
					binaryWriter.Write((uint)type);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override SaveResult Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return (SaveResult)binaryReader.ReadUInt32();
				}
			}
		}
	}
}
