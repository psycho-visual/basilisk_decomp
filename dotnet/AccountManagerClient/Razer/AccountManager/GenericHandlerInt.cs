using System.IO;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandlerInt : GenericBase<int>
	{
		public GenericHandlerInt(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override int Deserialize(byte[] data)
		{
			if (data.Length < 4)
			{
				return 0;
			}
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return binaryReader.ReadInt32();
				}
			}
		}
	}
}
