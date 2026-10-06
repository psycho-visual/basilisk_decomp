using System;
using System.IO;
using Razer.ActionService;
using log4net;

namespace Razer.ServiceClientBase
{
	public abstract class RazerClientBase : IDisposable
	{
		private static readonly ILog Logger = Common.GetLogger("RazerClientBase");

		protected ClientPipeSocket m_socket;

		private string m_pipeName;

		private RzServiceType m_serviceType;

		private readonly object m_connectLock = new object();

		public bool Connected
		{
			get
			{
				if (m_socket != null)
				{
					return m_socket.IsConnected;
				}
				return false;
			}
		}

		public string PipeName
		{
			get
			{
				return m_pipeName;
			}
			set
			{
				m_pipeName = value;
				if (Connected)
				{
					m_socket = null;
				}
			}
		}

		public event EventHandler ConnectComplete;

		public event EventHandler Disconnected;

		protected RazerClientBase(RzServiceType serviceType, string pipeName)
		{
			m_pipeName = pipeName;
			m_serviceType = serviceType;
		}

		public bool Connect(TimeSpan timeout)
		{
			lock (m_connectLock)
			{
				try
				{
					Logger.Debug("*** Connecting...");
					if (Connected)
					{
						return true;
					}
					OnPreConnect(timeout);
					m_socket = new ClientPipeSocket(m_pipeName);
					m_socket.Connect(timeout);
					m_socket.OnDisconnect += SocketDisconnect;
					m_socket.AddReceiveHandler(m_serviceType, OnReceive);
					OnConnectComplete();
					Logger.Debug("*** Connected!");
				}
				catch (Exception exception)
				{
					Logger.Debug("*** Exception!", exception);
					m_socket = null;
					return false;
				}
				return true;
			}
		}

		protected virtual void OnPreConnect(TimeSpan timeout)
		{
		}

		protected virtual bool OnConnectFailed(TimeSpan timeout)
		{
			return false;
		}

		public virtual void EnsureConnected(int timeoutInMilliseconds)
		{
			EnsureConnected(TimeSpan.FromMilliseconds(timeoutInMilliseconds));
		}

		public virtual void EnsureConnected(TimeSpan timeout)
		{
			if (Connected || Connect(timeout) || (OnConnectFailed(timeout) && Connect(timeout)))
			{
				return;
			}
			throw new IOException("Could not establish the connection.");
		}

		protected abstract void OnReceive(ClientPipeSocket sock, long packetId, byte[] data);

		private void SocketDisconnect(ClientPipeSocket socket)
		{
			OnDisconnect();
			m_socket = null;
		}

		protected virtual void OnDisconnect()
		{
			this.Disconnected?.Invoke(this, new EventArgs());
		}

		private void OnConnectComplete()
		{
			try
			{
				this.ConnectComplete?.Invoke(this, new EventArgs());
			}
			catch (Exception)
			{
			}
		}

		public virtual void Dispose()
		{
			if (m_socket != null)
			{
				m_socket.RemoveReceiveHandler(m_serviceType, OnReceive);
				m_socket.OnDisconnect -= SocketDisconnect;
				m_socket.Disconnect();
			}
		}
	}
}
