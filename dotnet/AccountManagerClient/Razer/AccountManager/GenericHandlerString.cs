using System.IO;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandlerString : GenericBase<string>
	{
		public GenericHandlerString(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override string Deserialize(byte[] data)
		{
			if (data.Length < 4)
			{
				return null;
			}
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return binaryReader.ReadString();
				}
			}
		}
	}
}
