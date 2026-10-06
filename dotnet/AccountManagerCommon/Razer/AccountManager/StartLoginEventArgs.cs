using System;

namespace Razer.AccountManager
{
	public class StartLoginEventArgs : EventArgs
	{
		public string LastLoggedInUser { get; private set; }

		public StartLoginEventArgs(string lastLoggedInUser)
		{
			LastLoggedInUser = lastLoggedInUser;
		}
	}
}
