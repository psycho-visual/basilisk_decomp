namespace Razer.ServiceClientBase
{
	public delegate void DataReceivedDelegate(ClientPipeSocket socket, long packetId, byte[] data);
}
