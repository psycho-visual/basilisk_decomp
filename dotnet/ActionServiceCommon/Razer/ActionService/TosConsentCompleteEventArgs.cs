using System;

namespace Razer.ActionService
{
	public class TosConsentCompleteEventArgs : EventArgs
	{
		public TosConsentDetails Details { get; set; }
	}
}
