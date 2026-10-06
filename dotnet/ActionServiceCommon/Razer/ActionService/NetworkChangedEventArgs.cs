using System;

namespace Razer.ActionService
{
	public class NetworkChangedEventArgs : EventArgs
	{
		public bool NetworkIsUp { get; private set; }

		public NetworkChangedEventArgs(bool isUp)
		{
			NetworkIsUp = isUp;
		}
	}
}
