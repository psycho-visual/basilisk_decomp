using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Threading;
using Razer.ActionService;
using log4net;

namespace Razer.ServiceClientBase
{
	public class ClientPipeSocket
	{
		private static readonly ILog Logger = LogManager.GetLogger("ClientPipeSocket");

		private NamedPipeClientStream m_pipeStream;

		private readonly string m_pipeName;

		private static readonly int HEADER_LEN = 24;

		private static readonly int MIN_HEADER_LEN = 16;

		private byte[] m_headerBuf;

		private long m_packetId;

		private Dictionary<RzServiceType, HashSet<DataReceivedDelegate>> m_receiveEvents;

		public NamedPipeClientStream PipeStream => m_pipeStream;

		public string PipeName => m_pipeName;

		public IntPtr Handle => m_pipeStream.SafePipeHandle.DangerousGetHandle();

		public bool IsConnected => m_pipeStream.IsConnected;

		public event DisconnectDelegate OnDisconnect;

		public ClientPipeSocket(string pipeName)
		{
			m_pipeName = pipeName;
			m_pipeStream = new NamedPipeClientStream(".", m_pipeName, PipeDirection.InOut, PipeOptions.Asynchronous);
			m_receiveEvents = new Dictionary<RzServiceType, HashSet<DataReceivedDelegate>>();
		}

		public void Connect(TimeSpan timeout)
		{
			m_pipeStream.Connect(Convert.ToInt32(timeout.TotalMilliseconds));
			BeginRead();
		}

		public void Disconnect()
		{
			m_pipeStream.Dispose();
		}

		public long Send(RzServiceType target, byte[] data)
		{
			long num = Interlocked.Increment(ref m_packetId);
			if (num == 0L)
			{
				num = Interlocked.Increment(ref m_packetId);
			}
			Send(target, data, num);
			return num;
		}

		public void Send(RzServiceType target, byte[] data, long packetId)
		{
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(2);
					binaryWriter.Write((int)target);
					binaryWriter.Write(data.Length);
					binaryWriter.Write(HEADER_LEN);
					binaryWriter.Write(packetId);
					binaryWriter.Write(data);
				}
				array = memoryStream.ToArray();
			}
			m_pipeStream.Write(array, 0, array.Length);
		}

		public void AddReceiveHandler(RzServiceType target, DataReceivedDelegate handler)
		{
			lock (m_receiveEvents)
			{
				if (!m_receiveEvents.ContainsKey(target))
				{
					m_receiveEvents[target] = new HashSet<DataReceivedDelegate>();
				}
				m_receiveEvents[target].Add(handler);
			}
		}

		public void RemoveReceiveHandler(RzServiceType target, DataReceivedDelegate handler)
		{
			lock (m_receiveEvents)
			{
				if (m_receiveEvents[target] != null)
				{
					m_receiveEvents[target].Remove(handler);
				}
			}
		}

		private void BeginRead()
		{
			m_headerBuf = new byte[MIN_HEADER_LEN];
			m_pipeStream.BeginRead(m_headerBuf, 0, MIN_HEADER_LEN, ReadAsyncCallback, this);
		}

		private void ReadAsyncCallback(IAsyncResult ar)
		{
			try
			{
				int num = 0;
				num = m_pipeStream.EndRead(ar);
				if (num == 0)
				{
					throw new IOException("Pipe closed");
				}
				int num2;
				for (; num < MIN_HEADER_LEN; num += num2)
				{
					num2 = m_pipeStream.Read(m_headerBuf, num, MIN_HEADER_LEN - num);
					if (num2 == 0)
					{
						throw new IOException("Pipe closed");
					}
				}
				BinaryReader binaryReader = new BinaryReader(new MemoryStream(m_headerBuf));
				int num3 = binaryReader.ReadInt32();
				RzServiceType target = (RzServiceType)binaryReader.ReadInt32();
				int len = binaryReader.ReadInt32();
				int num4 = binaryReader.ReadInt32();
				long packetId = 0L;
				if (num3 > 1)
				{
					packetId = BitConverter.ToInt64(ReadAll(8), 0);
				}
				if (num4 > HEADER_LEN)
				{
					ReadAll(num4 - HEADER_LEN);
				}
				byte[] data = ReadAll(len);
				new Thread((ThreadStart)delegate
				{
					FireDataReceived(target, packetId, data);
				}).Start();
				BeginRead();
			}
			catch (IOException)
			{
				if (this.OnDisconnect != null)
				{
					this.OnDisconnect(this);
				}
			}
			catch (ObjectDisposedException)
			{
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in pipe read callback", exception);
			}
		}

		private byte[] ReadAll(int len)
		{
			byte[] array = new byte[len];
			int num = 0;
			do
			{
				int num2 = m_pipeStream.Read(array, num, len - num);
				if (num2 == 0)
				{
					throw new IOException("Pipe closed");
				}
				num += num2;
			}
			while (num < len);
			return array;
		}

		private void FireDataReceived(RzServiceType target, long packetId, byte[] data)
		{
			HashSet<DataReceivedDelegate> hashSet = null;
			lock (m_receiveEvents)
			{
				if (m_receiveEvents.Count == 0)
				{
					Logger.Warn("No listeners registered");
				}
				if (!m_receiveEvents.ContainsKey(target) || m_receiveEvents[target] == null)
				{
					return;
				}
				hashSet = new HashSet<DataReceivedDelegate>(m_receiveEvents[target]);
			}
			foreach (DataReceivedDelegate item in hashSet)
			{
				try
				{
					item(this, packetId, data);
				}
				catch (Exception exception)
				{
					Logger.Warn("Exception in receive handler", exception);
				}
			}
		}

		private void FireDisconnect()
		{
			foreach (KeyValuePair<RzServiceType, HashSet<DataReceivedDelegate>> receiveEvent in m_receiveEvents)
			{
				foreach (DataReceivedDelegate item in receiveEvent.Value)
				{
					try
					{
						item(this, 0L, null);
					}
					catch (Exception exception)
					{
						Logger.Warn("Exception in disconnect handler", exception);
					}
				}
			}
		}
	}
}
