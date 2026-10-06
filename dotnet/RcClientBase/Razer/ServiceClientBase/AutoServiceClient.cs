using System;
using System.ServiceProcess;
using Razer.ActionService;
using log4net;

namespace Razer.ServiceClientBase
{
	public abstract class AutoServiceClient : AutoClient
	{
		private static readonly ILog Logger = Common.GetLogger("AutoServiceClient");

		private ServiceController m_serviceController = new ServiceController("RzActionSvc");

		public AutoServiceClient(RzServiceType type, string pipeName)
			: base(type, pipeName)
		{
		}

		protected override bool OnConnectFailed(TimeSpan timeout)
		{
			try
			{
				RestartService(timeout);
				return true;
			}
			catch (Exception exception)
			{
				Logger.Error("Failed to start service", exception);
				return false;
			}
		}

		private void RestartService(TimeSpan timeout)
		{
			if (m_serviceController.Status != ServiceControllerStatus.Running)
			{
				Logger.Info("Service not started. Status is:  " + m_serviceController.Status);
				switch (m_serviceController.Status)
				{
				case ServiceControllerStatus.Stopped:
					m_serviceController.Start();
					break;
				case ServiceControllerStatus.StopPending:
					m_serviceController.WaitForStatus(ServiceControllerStatus.Stopped, timeout);
					m_serviceController.Start();
					break;
				case ServiceControllerStatus.Paused:
					m_serviceController.Continue();
					break;
				case ServiceControllerStatus.PausePending:
					m_serviceController.WaitForStatus(ServiceControllerStatus.Paused, timeout);
					m_serviceController.Continue();
					break;
				}
				m_serviceController.WaitForStatus(ServiceControllerStatus.Running, timeout);
				Logger.Info("Service started successfully");
			}
		}
	}
}
