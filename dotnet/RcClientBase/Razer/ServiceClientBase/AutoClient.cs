using System;
using System.ComponentModel;
using System.Threading;
using Razer.ActionService;
using log4net;

namespace Razer.ServiceClientBase
{
	public abstract class AutoClient : RazerClientBase
	{
		private static readonly ILog Logger = Common.GetLogger("AutoClient");

		private Timer m_connectTimer;

		private bool m_wasConnected;

		protected AutoClient(RzServiceType type, string pipeName)
			: base(type, pipeName)
		{
			if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
			{
				return;
			}
			m_connectTimer = new Timer(TryConnect, null, 5000, 15000);
			base.ConnectComplete += delegate
			{
				m_connectTimer.Change(-1, -1);
				if (m_wasConnected)
				{
					OnReconnected();
				}
			};
		}

		public virtual void EnsureConnected()
		{
			EnsureConnected(TimeSpan.FromSeconds(5.0));
		}

		private void TryConnect(object state)
		{
			try
			{
				Logger.Debug("*** Trying to connect...");
				EnsureConnected(0);
				Logger.Debug("*** Connect attempt successful...");
			}
			catch
			{
				Logger.Debug("*** Attempt failed");
			}
		}

		protected virtual void OnReconnected()
		{
		}

		protected override void OnDisconnect()
		{
			try
			{
				base.OnDisconnect();
				if (m_connectTimer != null)
				{
					m_connectTimer.Change(5000, 15000);
				}
				m_wasConnected = true;
			}
			catch (Exception exception)
			{
				Logger.Warn("Exception in OnDisconnect.", exception);
			}
		}

		public override void Dispose()
		{
			try
			{
				if (m_connectTimer != null)
				{
					m_connectTimer.Dispose();
					m_connectTimer = null;
				}
				base.Dispose();
			}
			catch (Exception exception)
			{
				Logger.Warn("Exception in Dispose.", exception);
			}
		}
	}
}
