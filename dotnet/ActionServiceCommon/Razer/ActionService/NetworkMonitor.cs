using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using log4net;

namespace Razer.ActionService
{
	public class NetworkMonitor : IDisposable
	{
		private static readonly ILog Logger = LogManager.GetLogger("NetworkMonitor");

		private object m_networkChangedLock = new object();

		private bool m_lastNetworkState;

		public static bool NetworkIsUp => true;

		private static bool NetworkIsUpInternal
		{
			get
			{
				bool result = false;
				try
				{
					List<ManagementObject> list = new ManagementObjectSearcher("SELECT * \r\n                                                                                    FROM  Win32_NetworkAdapter \r\n                                                                                    WHERE Manufacturer != 'Microsoft' \r\n                                                                                        AND NOT PNPDeviceID LIKE 'ROOT\\\\%'").Get().Cast<ManagementObject>().ToList();
					if (list != null && list.Count > 0)
					{
						NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
						foreach (NetworkInterface n in allNetworkInterfaces)
						{
							IPv4InterfaceStatistics iPv4Statistics = n.GetIPv4Statistics();
							if ((n.OperationalStatus == OperationalStatus.Up || n.OperationalStatus == OperationalStatus.Unknown) && iPv4Statistics.BytesReceived > 0 && iPv4Statistics.BytesSent > 0 && list.Any((ManagementObject mo) => mo != null && mo["GUID"] != null && mo["GUID"].ToString() == n.Id))
							{
								result = true;
								break;
							}
						}
					}
				}
				catch (Exception exception)
				{
					Logger.Warn("Exception in NetworkIsUpInternal.", exception);
					result = true;
				}
				return result;
			}
		}

		public event EventHandler<NetworkChangedEventArgs> NetworkChanged;

		public NetworkMonitor()
		{
			NetworkChange.NetworkAddressChanged += AddressChangedCallback;
			m_lastNetworkState = NetworkIsUpInternal;
		}

		public void Dispose()
		{
			NetworkChange.NetworkAddressChanged -= AddressChangedCallback;
		}

		private void AddressChangedCallback(object sender, EventArgs e)
		{
			lock (m_networkChangedLock)
			{
				try
				{
					bool networkIsUpInternal = NetworkIsUpInternal;
					if (networkIsUpInternal != m_lastNetworkState)
					{
						m_lastNetworkState = networkIsUpInternal;
						this.NetworkChanged?.Invoke(this, new NetworkChangedEventArgs(networkIsUpInternal));
					}
				}
				catch
				{
				}
			}
		}
	}
}
