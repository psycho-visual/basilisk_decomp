using System.Collections.Generic;
using System.IO;
using System.Linq;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class ConnectToAccountHandler : HandlerBase<object>
	{
		public ConnectToAccountHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.ConnectToAccount)
		{
		}

		public void Execute(ConnectedAccount account, IEnumerable<string> permissions, bool forceReauthentication)
		{
			if (permissions == null)
			{
				permissions = new List<string>();
			}
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((int)account);
					binaryWriter.Write(permissions.Count());
					foreach (string permission in permissions)
					{
						binaryWriter.Write(permission);
					}
					binaryWriter.Write(forceReauthentication);
				}
				data = memoryStream.ToArray();
			}
			Send(data);
		}

		protected override object Deserialize(byte[] data)
		{
			return null;
		}
	}
}
