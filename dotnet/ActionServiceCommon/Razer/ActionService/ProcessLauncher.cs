using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using log4net;

namespace Razer.ActionService
{
	public class ProcessLauncher
	{
		private static readonly ILog Logger = LogManager.GetLogger("ProcessLauncher");

		public static int LaunchProcess(string fullPath, string arguments, bool bWaitForProcessExit = true)
		{
			int num = -1;
			if (!string.IsNullOrEmpty(fullPath) && File.Exists(fullPath))
			{
				Logger.InfoFormat("Launching {0} {1}", fullPath, arguments);
				ProcessStartInfo processStartInfo = new ProcessStartInfo(fullPath, arguments);
				processStartInfo.CreateNoWindow = false;
				processStartInfo.UseShellExecute = false;
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				DirectoryInfo directory = new FileInfo(fullPath).Directory;
				if (directory != null)
				{
					processStartInfo.WorkingDirectory = directory.FullName;
					try
					{
						using (Process process = Process.Start(processStartInfo))
						{
							if (bWaitForProcessExit)
							{
								process.WaitForExit();
								num = process.ExitCode;
								Logger.InfoFormat("{0}: {1} [{2}] completed with return code {3}", MethodBase.GetCurrentMethod().Name, fullPath, arguments, num);
							}
							else
							{
								num = 0;
								Logger.InfoFormat("{0}: Not waiting for the process {1} [{2}]", MethodBase.GetCurrentMethod().Name, fullPath, arguments);
							}
						}
					}
					catch (Exception exception)
					{
						Logger.Error($"{MethodBase.GetCurrentMethod().Name}: Error executing {fullPath}", exception);
					}
				}
			}
			else
			{
				Logger.ErrorFormat("{0}: Launch file does not exist {1}", MethodBase.GetCurrentMethod().Name, fullPath);
			}
			return num;
		}

		public static int LaunchProcessAsUser(int sessionId, string fileName, string arguments, string workingDir = null)
		{
			string directoryName = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
			string text = "\"" + Path.Combine(directoryName, fileName) + "\"";
			Logger.Debug($"{MethodBase.GetCurrentMethod().Name}: Launching {text} {arguments}");
			if (workingDir != null)
			{
				Logger.Debug("\tWorking Directory: " + workingDir);
			}
			if (Environment.UserInteractive)
			{
				Logger.DebugFormat("{0}: Launching process interactively", MethodBase.GetCurrentMethod().Name);
				return Process.Start(new ProcessStartInfo
				{
					FileName = text,
					Arguments = arguments,
					CreateNoWindow = true,
					ErrorDialog = false,
					UseShellExecute = Environment.UserInteractive,
					Verb = "runas"
				})?.Id ?? (-1);
			}
			Logger.DebugFormat("{0}: Launching process NON-interactively", MethodBase.GetCurrentMethod().Name);
			IntPtr phNewToken = IntPtr.Zero;
			IntPtr TokenHandle = IntPtr.Zero;
			IntPtr zero = IntPtr.Zero;
			Win32.PROCESS_INFORMATION lpProcessInformation = default(Win32.PROCESS_INFORMATION);
			uint dwSessionId = (uint)sessionId;
			if (sessionId == -1)
			{
				dwSessionId = Win32.WTSGetActiveConsoleSessionId();
			}
			uint dwProcessId = (from p in Process.GetProcessesByName("winlogon")
				where p.SessionId == (int)dwSessionId
				select (uint)p.Id).FirstOrDefault();
			zero = Win32.OpenProcess(33554432u, bInheritHandle: false, dwProcessId);
			if (!Win32.OpenProcessToken(zero, 2u, ref TokenHandle))
			{
				Logger.DebugFormat("{0}: Failed to open user process token", MethodBase.GetCurrentMethod().Name);
				Win32.CloseHandle(zero);
				return -1;
			}
			Win32.SECURITY_ATTRIBUTES lpTokenAttributes = default(Win32.SECURITY_ATTRIBUTES);
			lpTokenAttributes.nLength = Marshal.SizeOf(lpTokenAttributes);
			if (!Win32.DuplicateTokenEx(TokenHandle, 33554432u, ref lpTokenAttributes, Win32.SecurityImpersonationLevel.SecurityIdentification, Win32.TOKEN_TYPE.TokenPrimary, out phNewToken))
			{
				Logger.DebugFormat("{0}: Failed to duplicate user process token", MethodBase.GetCurrentMethod().Name);
				Win32.CloseHandle(zero);
				Win32.CloseHandle(TokenHandle);
				return -1;
			}
			Win32.STARTUPINFO lpStartupInfo = default(Win32.STARTUPINFO);
			lpStartupInfo.cb = Marshal.SizeOf(lpStartupInfo);
			lpStartupInfo.lpDesktop = "winsta0\\default";
			uint dwCreationFlags = 48u;
			Logger.DebugFormat("{0}: Launching NAC process", MethodBase.GetCurrentMethod().Name);
			if (!Win32.CreateProcessAsUser(phNewToken, null, text + " " + arguments, ref lpTokenAttributes, ref lpTokenAttributes, bInheritHandles: false, dwCreationFlags, IntPtr.Zero, workingDir, ref lpStartupInfo, out lpProcessInformation))
			{
				Logger.Error($"{MethodBase.GetCurrentMethod().Name}: Failed to create process for this user");
				int lastWin32Error = Marshal.GetLastWin32Error();
				throw new InvalidOperationException("Failed to create " + fileName + " process: " + lastWin32Error);
			}
			Win32.CloseHandle(zero);
			Win32.CloseHandle(TokenHandle);
			Win32.CloseHandle(phNewToken);
			return lpProcessInformation.dwProcessId;
		}
	}
}
