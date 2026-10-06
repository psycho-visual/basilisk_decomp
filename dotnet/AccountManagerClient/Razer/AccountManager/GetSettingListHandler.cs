using System.Collections.Generic;
using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetSettingListHandler : HandlerBase<List<SettingDefinition>>
	{
		public GetSettingListHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetSettingList)
		{
		}

		public List<SettingDefinition> Execute(string product, string pathExpression, string nameExpression, SettingSource source)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(product);
					binaryWriter.Write(pathExpression);
					binaryWriter.Write(nameExpression);
					binaryWriter.Write((uint)source);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override List<SettingDefinition> Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.ReadSettingDefinitionList();
				}
			}
		}
	}
}
