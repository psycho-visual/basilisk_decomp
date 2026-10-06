using System;
using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class IsLicensedHandler : HandlerBase<bool>
	{
		public IsLicensedHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.IsLicensed)
		{
		}

		public bool Execute(string appId)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(appId);
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override bool Deserialize(byte[] data)
		{
			return BitConverter.ToBoolean(data, 0);
		}
	}
}
