using System;
using System.Runtime.InteropServices;
using log4net;

namespace Razer.ActionService
{
	public sealed class Impersonator : IDisposable
	{
		private static readonly ILog Logger = LogManager.GetLogger("Impersonator");

		private int m_sessionId = -1;

		private IntPtr CurrentUserToken
		{
			get
			{
				uint num = (uint)m_sessionId;
				if (m_sessionId == -1)
				{
					num = Win32.WTSGetActiveConsoleSessionId();
					if (num == uint.MaxValue)
					{
						throw new InvalidOperationException("No session attached to the physical console.");
					}
				}
				if (!Win32.WTSQueryUserToken(num, out var Token))
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					throw new InvalidOperationException("Failed to query user token: " + lastWin32Error);
				}
				if (!Win32.DuplicateToken(Token, 2, out var DuplicateTokenHandle))
				{
					int lastWin32Error2 = Marshal.GetLastWin32Error();
					Logger.Error("Duplicate token failed: " + lastWin32Error2);
					return Token;
				}
				return DuplicateTokenHandle;
			}
		}

		public Impersonator(int sessionId)
		{
			m_sessionId = sessionId;
			if (!Environment.UserInteractive && !Win32.SetThreadToken(IntPtr.Zero, CurrentUserToken))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				Logger.Error("Failed to set thread token: " + lastWin32Error);
			}
		}

		public void Dispose()
		{
			if (!Environment.UserInteractive)
			{
				Win32.RevertToSelf();
			}
		}
	}
}
