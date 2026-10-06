using System;
using Razer.ActionService;

namespace Razer.AccountManager
{
	public class UILanguageChangedEventArgs : EventArgs
	{
		public LanguageInfo NewLanguage { get; private set; }

		public UILanguageChangedEventArgs(LanguageInfo newLanguage)
		{
			NewLanguage = newLanguage;
		}
	}
}
