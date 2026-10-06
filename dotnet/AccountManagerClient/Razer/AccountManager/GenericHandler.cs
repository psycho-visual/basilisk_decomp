using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandler : GenericBase<object>
	{
		public GenericHandler(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override object Deserialize(byte[] data)
		{
			return null;
		}
	}
	internal sealed class GenericHandler<T> : GenericBase<T> where T : class, IRazerSerializable
	{
		public GenericHandler(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override T Deserialize(byte[] data)
		{
			if (data.Length == 0)
			{
				return null;
			}
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<T>();
				}
			}
		}
	}
}
