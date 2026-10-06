using System.IO;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class GetMyWarrantiesHandler : HandlerBase<WarrantyResponse>
	{
		public GetMyWarrantiesHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.GetMyWarranties)
		{
		}

		public WarrantyResponse Execute()
		{
			return Send(null);
		}

		protected override WarrantyResponse Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<WarrantyResponse>();
				}
			}
		}
	}
}
