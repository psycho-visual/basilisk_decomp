using System;

namespace CustomerFWU2Point5
{
	public class DeviceListenerEvent : EventArgs
	{
		private Common.VidPid vidPid;

		private bool fConnected;

		public DeviceListenerEvent(Common.VidPid vidPid, bool fConnected)
		{
			this.vidPid = vidPid;
			this.fConnected = fConnected;
		}

		public Common.VidPid GetVidPid()
		{
			return vidPid;
		}

		public bool IsConnected()
		{
			return fConnected;
		}
	}
}
