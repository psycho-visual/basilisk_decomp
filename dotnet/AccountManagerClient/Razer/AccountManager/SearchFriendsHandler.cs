using System.Collections.Generic;
using System.IO;
using System.Linq;
using Razer.ActionService;
using Razer.ServiceClientBase;

namespace Razer.AccountManager
{
	internal sealed class SearchFriendsHandler : HandlerBase<FriendSearchResult>
	{
		public SearchFriendsHandler(ClientPipeSocket socket)
			: base(socket, RzServiceType.AccountManager, Commands.SearchFriends)
		{
		}

		public FriendSearchResult Execute(IdSource source, IEnumerable<string> externalIds)
		{
			byte[] data;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write((int)source);
					binaryWriter.Write(externalIds.Count());
					foreach (string externalId in externalIds)
					{
						binaryWriter.Write(externalId);
					}
				}
				data = memoryStream.ToArray();
			}
			return Send(data);
		}

		protected override FriendSearchResult Deserialize(byte[] data)
		{
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader reader = new BinaryReader(input))
				{
					return reader.Read<FriendSearchResult>();
				}
			}
		}
	}
}
