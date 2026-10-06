using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class ResolveConflictHandler : HandlerBase<SaveResult>
	{
		public ResolveConflictHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.ResolveConflict)
		{
		}

		public SaveResult Execute(string product, string path, string name, SettingSource source)
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
