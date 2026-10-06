using System.IO;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandlerDouble : GenericBase<double>
	{
		public GenericHandlerDouble(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override double Deserialize(byte[] data)
		{
			if (data.Length < 4)
			{
				return 0.0;
			}
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					return binaryReader.ReadDouble();
				}
			}
		}
	}
}
