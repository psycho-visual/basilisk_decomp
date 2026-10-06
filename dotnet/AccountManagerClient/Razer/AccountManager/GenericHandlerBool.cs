using System;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GenericHandlerBool : GenericBase<bool>
	{
		public GenericHandlerBool(ClientPipeSocket socket, Commands command)
			: base(socket, command)
		{
		}

		protected override bool Deserialize(byte[] data)
		{
			return BitConverter.ToBoolean(data, 0);
		}
	}
}
