using System;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using log4net;

namespace Razer.ActionService
{
	public class Win32
	{
		public enum SecurityImpersonationLevel
		{
			SecurityAnonymous,
			SecurityIdentification,
			SecurityImpersonation,
			SecurityDelegation
		}

		public enum TOKEN_TYPE
		{
			TokenPrimary = 1,
			TokenImpersonation
		}

		[Flags]
		public enum CreateProcessFlags : uint
		{
			DEBUG_PROCESS = 1u,
			DEBUG_ONLY_THIS_PROCESS = 2u,
			CREATE_SUSPENDED = 4u,
			DETACHED_PROCESS = 8u,
			CREATE_NEW_CONSOLE = 0x10u,
			NORMAL_PRIORITY_CLASS = 0x20u,
			IDLE_PRIORITY_CLASS = 0x40u,
			HIGH_PRIORITY_CLASS = 0x80u,
			REALTIME_PRIORITY_CLASS = 0x100u,
			CREATE_NEW_PROCESS_GROUP = 0x200u,
			CREATE_UNICODE_ENVIRONMENT = 0x400u,
			CREATE_SEPARATE_WOW_VDM = 0x800u,
			CREATE_SHARED_WOW_VDM = 0x1000u,
			CREATE_FORCE_DOS = 0x2000u,
			BELOW_NORMAL_PRIORITY_CLASS = 0x4000u,
			ABOVE_NORMAL_PRIORITY_CLASS = 0x8000u,
			INHERIT_PARENT_AFFINITY = 0x10000u,
			INHERIT_CALLER_PRIORITY = 0x20000u,
			CREATE_PROTECTED_PROCESS = 0x40000u,
			EXTENDED_STARTUPINFO_PRESENT = 0x80000u,
			PROCESS_MODE_BACKGROUND_BEGIN = 0x100000u,
			PROCESS_MODE_BACKGROUND_END = 0x200000u,
			CREATE_BREAKAWAY_FROM_JOB = 0x1000000u,
			CREATE_PRESERVE_CODE_AUTHZ_LEVEL = 0x2000000u,
			CREATE_DEFAULT_ERROR_MODE = 0x4000000u,
			CREATE_NO_WINDOW = 0x8000000u
		}

		public enum WTSInfoClass
		{
			WTSInitialProgram,
			WTSApplicationName,
			WTSWorkingDirectory,
			WTSOEMId,
			WTSSessionId,
			WTSUserName,
			WTSWinStationName,
			WTSDomainName,
			WTSConnectState,
			WTSClientBuildNumber,
			WTSClientName,
			WTSClientDirectory,
			WTSClientProductId,
			WTSClientHardwareId,
			WTSClientAddress,
			WTSClientDisplay,
			WTSClientProtocolType,
			WTSIdleTime,
			WTSLogonTime,
			WTSIncomingBytes,
			WTSOutgoingBytes,
			WTSIncomingFrames,
			WTSOutgoingFrames,
			WTSClientInfo,
			WTSSessionInfo
		}

		public enum WTSConnectState
		{
			Active,
			Connected,
			ConnectQuery,
			Shadow,
			Disconnected,
			Idle,
			Listen,
			Reset,
			Down,
			Init
		}

		public enum JobObjectInfoType
		{
			AssociateCompletionPortInformation = 7,
			BasicLimitInformation = 2,
			BasicUIRestrictions = 4,
			EndOfJobTimeInformation = 6,
			ExtendedLimitInformation = 9,
			SecurityLimitInformation = 5,
			GroupInformation = 11
		}

		[Flags]
		public enum JOBOBJECTLIMIT : uint
		{
			JOB_OBJECT_LIMIT_WORKINGSET = 1u,
			JOB_OBJECT_LIMIT_PROCESS_TIME = 2u,
			JOB_OBJECT_LIMIT_JOB_TIME = 4u,
			JOB_OBJECT_LIMIT_ACTIVE_PROCESS = 8u,
			JOB_OBJECT_LIMIT_AFFINITY = 0x10u,
			JOB_OBJECT_LIMIT_PRIORITY_CLASS = 0x20u,
			JOB_OBJECT_LIMIT_PRESERVE_JOB_TIME = 0x40u,
			JOB_OBJECT_LIMIT_SCHEDULING_CLASS = 0x80u,
			JOB_OBJECT_LIMIT_PROCESS_MEMORY = 0x100u,
			JOB_OBJECT_LIMIT_JOB_MEMORY = 0x200u,
			JOB_OBJECT_LIMIT_DIE_ON_UNHANDLED_EXCEPTION = 0x400u,
			JOB_OBJECT_LIMIT_BREAKAWAY_OK = 0x800u,
			JOB_OBJECT_LIMIT_SILENT_BREAKAWAY_OK = 0x1000u,
			JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x2000u,
			JOB_OBJECT_LIMIT_SUBSET_AFFINITY = 0x4000u
		}

		public struct PROCESS_INFORMATION
		{
			public IntPtr hProcess;

			public IntPtr hThread;

			public int dwProcessId;

			public int dwThreadId;
		}

		public struct SECURITY_ATTRIBUTES
		{
			public int nLength;

			public IntPtr lpSecurityDescriptor;

			public int bInheritHandle;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct STARTUPINFO
		{
			public int cb;

			public string lpReserved;

			public string lpDesktop;

			public string lpTitle;

			public int dwX;

			public int dwY;

			public int dwXSize;

			public int dwYSize;

			public int dwXCountChars;

			public int dwYCountChars;

			public int dwFillAttribute;

			public int dwFlags;

			public short wShowWindow;

			public short cbReserved2;

			public IntPtr lpReserved2;

			public IntPtr hStdInput;

			public IntPtr hStdOutput;

			public IntPtr hStdError;
		}

		public struct POINT
		{
			public int X;

			public int Y;

			public POINT(int x, int y)
			{
				X = x;
				Y = y;
			}

			public POINT(Point pt)
				: this(pt.X, pt.Y)
			{
			}

			public static implicit operator Point(POINT p)
			{
				return new Point(p.X, p.Y);
			}

			public static implicit operator POINT(Point p)
			{
				return new POINT(p.X, p.Y);
			}
		}

		public struct MINMAXINFO
		{
			public POINT ptReserved;

			public POINT ptMaxSize;

			public POINT ptMaxPosition;

			public POINT ptMinTrackSize;

			public POINT ptMaxTrackSize;
		}

		public struct RECT
		{
			public int Left;

			public int Top;

			public int Right;

			public int Bottom;

			public int X
			{
				get
				{
					return Left;
				}
				set
				{
					Right -= Left - value;
					Left = value;
				}
			}

			public int Y
			{
				get
				{
					return Top;
				}
				set
				{
					Bottom -= Top - value;
					Top = value;
				}
			}

			public int Height
			{
				get
				{
					return Bottom - Top;
				}
				set
				{
					Bottom = value + Top;
				}
			}

			public int Width
			{
				get
				{
					return Right - Left;
				}
				set
				{
					Right = value + Left;
				}
			}

			public Point Location
			{
				get
				{
					return new Point(Left, Top);
				}
				set
				{
					X = value.X;
					Y = value.Y;
				}
			}

			public Size Size
			{
				get
				{
					return new Size(Width, Height);
				}
				set
				{
					Width = value.Width;
					Height = value.Height;
				}
			}

			public RECT(int left, int top, int right, int bottom)
			{
				Left = left;
				Top = top;
				Right = right;
				Bottom = bottom;
			}

			public RECT(Rectangle r)
				: this(r.Left, r.Top, r.Right, r.Bottom)
			{
			}

			public static implicit operator Rectangle(RECT r)
			{
				return new Rectangle(r.Left, r.Top, r.Width, r.Height);
			}

			public static implicit operator RECT(Rectangle r)
			{
				return new RECT(r);
			}

			public static bool operator ==(RECT r1, RECT r2)
			{
				return r1.Equals(r2);
			}

			public static bool operator !=(RECT r1, RECT r2)
			{
				return !r1.Equals(r2);
			}

			public bool Equals(RECT r)
			{
				if (r.Left == Left && r.Top == Top && r.Right == Right)
				{
					return r.Bottom == Bottom;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is RECT)
				{
					return Equals((RECT)obj);
				}
				if (obj is Rectangle)
				{
					return Equals(new RECT((Rectangle)obj));
				}
				return false;
			}

			public override int GetHashCode()
			{
				return ((Rectangle)this/*cast due to .constrained prefix*/).GetHashCode();
			}

			public override string ToString()
			{
				return string.Format(CultureInfo.CurrentCulture, "{{Left={0},Top={1},Right={2},Bottom={3}}}", Left, Top, Right, Bottom);
			}
		}

		public struct MONITORINFO
		{
			public int cbSize;

			public RECT rcMonitor;

			public RECT rcWork;

			public uint dwFlags;
		}

		public struct JOBOBJECT_BASIC_LIMIT_INFORMATION
		{
			public long PerProcessUserTimeLimit;

			public long PerJobUserTimeLimit;

			public JOBOBJECTLIMIT LimitFlags;

			public uint MinimumWorkingSetSize;

			public uint MaximumWorkingSetSize;

			public short ActiveProcessLimit;

			public long Affinity;

			public short PriorityClass;

			public short SchedulingClass;
		}

		public struct IO_COUNTERS
		{
			public ulong ReadOperationCount;

			public ulong WriteOperationCount;

			public ulong OtherOperationCount;

			public ulong ReadTransferCount;

			public ulong WriteTransferCount;

			public ulong OtherTransferCount;
		}

		public struct JOBOBJECT_EXTENDED_LIMIT_INFORMATION
		{
			public JOBOBJECT_BASIC_LIMIT_INFORMATION BasicLimitInformation;

			public IO_COUNTERS IoInfo;

			public uint ProcessMemoryLimit;

			public uint JobMemoryLimit;

			public uint PeakProcessMemoryUsed;

			public uint PeakJobMemoryUsed;
		}

		public const uint STANDARD_RIGHTS_REQUIRED = 983040u;

		public const uint STANDARD_RIGHTS_READ = 131072u;

		public const uint TOKEN_ASSIGN_PRIMARY = 1u;

		public const uint TOKEN_DUPLICATE = 2u;

		public const uint TOKEN_IMPERSONATE = 4u;

		public const uint TOKEN_QUERY = 8u;

		public const uint TOKEN_QUERY_SOURCE = 16u;

		public const uint TOKEN_ADJUST_PRIVILEGES = 32u;

		public const uint TOKEN_ADJUST_GROUPS = 64u;

		public const uint TOKEN_ADJUST_DEFAULT = 128u;

		public const uint TOKEN_ADJUST_SESSIONID = 256u;

		public const uint TOKEN_READ = 131080u;

		public const uint TOKEN_ALL_ACCESS = 983551u;

		public const int WTS_CURRENT_SESSION = -1;

		public const uint MAXIMUM_ALLOWED = 33554432u;

		public const int CREATE_NEW_CONSOLE = 16;

		public const int NORMAL_PRIORITY_CLASS = 32;

		public const uint MONITOR_DEFAULTTONULL = 0u;

		public const uint MONITOR_DEFAULTTOPRIMARY = 1u;

		public const uint MONITOR_DEFAULTTONEAREST = 2u;

		[DllImport("userenv.dll", SetLastError = true)]
		public static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, IntPtr hToken, bool bInherit);

		[DllImport("userenv.dll", SetLastError = true)]
		public static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);

		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool DuplicateToken(IntPtr ExistingTokenHandle, int SECURITY_IMPERSONATION_LEVEL, out IntPtr DuplicateTokenHandle);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, ref SECURITY_ATTRIBUTES lpTokenAttributes, SecurityImpersonationLevel ImpersonationLevel, TOKEN_TYPE TokenType, out IntPtr phNewToken);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool SetThreadToken(IntPtr handle, IntPtr token);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool ImpersonateNamedPipeClient(IntPtr handle);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool ImpersonateLoggedOnUser(IntPtr handle);

		[DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool RevertToSelf();

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern uint WTSGetActiveConsoleSessionId();

		[DllImport("kernel32.dll")]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

		[DllImport("advapi32", SetLastError = true)]
		[SuppressUnmanagedCodeSecurity]
		public static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, ref IntPtr TokenHandle);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hSnapshot);

		[DllImport("Wtsapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern bool WTSQueryUserToken(uint sessionId, out IntPtr Token);

		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool CreateProcessAsUser(IntPtr hToken, string lpApplicationName, string lpCommandLine, ref SECURITY_ATTRIBUTES lpProcessAttributes, ref SECURITY_ATTRIBUTES lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, ref STARTUPINFO lpStartupInfo, out PROCESS_INFORMATION lpProcessInformation);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, uint VolumeNameSize, ref uint VolumeSerialNumber, ref uint MaximumComponentLength, ref uint FileSystemFlags, StringBuilder FileSystemNameBuffer, uint FileSystemNameSize);

		[DllImport("gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("Wtsapi32.dll")]
		public static extern bool WTSQuerySessionInformation(IntPtr hServer, int sessionId, WTSInfoClass wtsInfoClass, out IntPtr ppBuffer, out int pBytesReturned);

		[DllImport("wtsapi32.dll", ExactSpelling = true)]
		public static extern void WTSFreeMemory(IntPtr memory);

		[DllImport("user32.dll")]
		public static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

		[DllImport("user32.dll")]
		public static extern bool GetMonitorInfo(IntPtr hMonitor, ref MONITORINFO lpmi);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetNamedPipeClientSessionId(IntPtr hPipe, out int ClientSessionId);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

		[DllImport("kernel32.dll")]
		public static extern bool SetInformationJobObject(IntPtr hJob, JobObjectInfoType infoType, IntPtr lpJobObjectInfo, uint cbJobObjectInfoLength);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool AssignProcessToJobObject(IntPtr job, IntPtr process);

		[DllImport("kernel32.dll")]
		public static extern int GetUserDefaultLCID();

		public static bool IsSessionActive(int sessionId)
		{
			int pBytesReturned = 0;
			if (!WTSQuerySessionInformation(IntPtr.Zero, sessionId, WTSInfoClass.WTSConnectState, out var ppBuffer, out pBytesReturned))
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				throw new InvalidOperationException("WTSQuerySessionInformation failed with error code " + lastWin32Error);
			}
			int[] array = new int[1];
			Marshal.Copy(ppBuffer, array, 0, 1);
			WTSConnectState wTSConnectState = (WTSConnectState)array[0];
			WTSFreeMemory(ppBuffer);
			ppBuffer = IntPtr.Zero;
			LogManager.GetLogger("Win32").Debug("Current session state is " + wTSConnectState);
			return wTSConnectState == WTSConnectState.Active;
		}

		public static string GetUsername(int sessionId)
		{
			string result = "SYSTEM";
			if (WTSQuerySessionInformation(IntPtr.Zero, sessionId, WTSInfoClass.WTSUserName, out var ppBuffer, out var _))
			{
				result = Marshal.PtrToStringAnsi(ppBuffer);
			}
			return result;
		}
	}
}
