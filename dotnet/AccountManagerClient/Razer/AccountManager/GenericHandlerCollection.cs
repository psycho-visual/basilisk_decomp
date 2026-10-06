using System.Collections.Generic;
using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandlerCollection<T> : GenericBase<IEnumerable<T>> where T : class, IRazerSerializable
	{
		public GenericHandlerCollection(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override IEnumerable<T> Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.ReadAll<T>();
				}
			}
		}
	}
}
