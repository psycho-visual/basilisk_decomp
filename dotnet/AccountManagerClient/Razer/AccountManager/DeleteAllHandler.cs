using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class DeleteAllHandler : HandlerBase<SaveResult>
	{
		public DeleteAllHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.SettingDeleteAll)
		{
		}

		public SaveResult Execute(string product, string path, SettingSaveType type)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write(path);
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
