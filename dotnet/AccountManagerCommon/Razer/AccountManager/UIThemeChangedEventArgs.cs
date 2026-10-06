using System;

namespace Razer.AccountManager
{
	public class UIThemeChangedEventArgs : EventArgs
	{
		public UiTheme NewTheme { get; private set; }

		public UIThemeChangedEventArgs(UiTheme newTheme)
		{
			NewTheme = newTheme;
		}
	}
}
