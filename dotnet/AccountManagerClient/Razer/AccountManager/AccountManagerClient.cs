using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Razer.AccountManager.ConnectedAccounts;
using Razer.ActionService;
using Razer.ServiceClientBase;
using log4net;

namespace Razer.AccountManager
{
	public class AccountManagerClient : AutoServiceClient
	{
		private sealed class TosConsentData
		{
			public bool Consented { get; set; }

			public Exception ConsentException { get; set; }

			public string ServiceCode { get; set; }

			public SemaphoreSlim TosConsentEvent { get; set; } = new SemaphoreSlim(0, 20);
		}

		private static readonly ILog Logger = Common.GetLogger("AccountManagerClient");

		private static readonly string SettingsGlobalProject = "Razer Central";

		private static readonly string SettingsGlobalPath = "Global";

		private Dictionary<string, SyncProgressDelegate> m_syncProgressDelegates = new Dictionary<string, SyncProgressDelegate>();

		private Dictionary<string, SyncCompleteDelegate> m_syncCompleteDelegates = new Dictionary<string, SyncCompleteDelegate>();

		private TosConsentData m_consentData;

		private readonly object m_currentUserLock = new object();

		private RazerUser m_currentUser;

		private string m_projectName;

		private string m_serviceCode;

		private bool m_isLoggedIn;

		public TimeSpan AutoRegistrationInterval
		{
			get
			{
				TimeSpan timeSpan = TimeSpan.FromSeconds(0.0);
				try
				{
					Logger.Debug("==>AutoRegistrationInterval_get()");
					EnsureConnected();
					timeSpan = TimeSpan.FromSeconds(new GenericHandlerDouble(m_socket, Commands.AutoRegistrationInterval_get).Execute());
					return timeSpan;
				}
				finally
				{
					Logger.DebugFormat("<==AutoRegistrationInterval_get({0})", timeSpan);
				}
			}
			set
			{
				try
				{
					Logger.DebugFormat("==>AutoRegistrationInterval_set({0})", value);
					if (value.TotalMinutes < 5.0)
					{
						throw new ArgumentOutOfRangeException("Interval must be greater than five minutes");
					}
					EnsureConnected();
					new GenericHandler(m_socket, Commands.AutoRegistrationInterval_set).Execute(value.TotalSeconds);
				}
				finally
				{
					Logger.Debug("<==AutoRegistrationInterval_set()");
				}
			}
		}

		public ConnectedAccountClient ConnectedAccounts { get; private set; }

		public bool OverlayEnabled
		{
			get
			{
				try
				{
					Logger.Debug("==>get_OverlayEnabled");
					return GetGlobalSetting(GlobalSetting.OverlayEnabled, defaultValue: true);
				}
				finally
				{
					Logger.Debug("<==get_OverlayEnabled");
				}
			}
			set
			{
				try
				{
					Logger.DebugFormat("==>set_OverlayEnabled({0})", value);
					SetSetting(GlobalSetting.OverlayEnabled, value, SettingSaveType.Application);
				}
				finally
				{
					Logger.Debug("<==set_OverlayEnabled");
				}
			}
		}

		internal ClientPipeSocket Socket => m_socket;

		public event EventHandler<LoginEventArgs> LoginComplete;

		public event EventHandler<LogoutEventArgs> LogoutStarted;

		public event EventHandler<LogoutEventArgs> LogoutComplete;

		public event EventHandler<UserProfileUpdatedEventArgs> UserProfileUpdated;

		public event EventHandler<UILanguageChangedEventArgs> UILanguageChanged;

		public event EventHandler<UIThemeChangedEventArgs> UIThemeChanged;

		public event EventHandler<FeatureChangedEventArgs> FeatureChanged;

		public event EventHandler<UserUpdatedEventArgs> UserUpdated;

		public event EventHandler<SettingChangedEventArgs> GlobalSettingChanged;

		public AccountManagerClient(string projectName, string serviceCode)
			: this(projectName, serviceCode, Common.PipeName)
		{
		}

		public AccountManagerClient(string projectName, string serviceCode, string pipeName)
			: base(RzServiceType.AccountManager, pipeName)
		{
			try
			{
				Logger.DebugFormat("==>AccountManagerClient({0}, {1})", projectName, serviceCode);
				m_projectName = projectName;
				m_serviceCode = serviceCode;
				ConnectedAccounts = new ConnectedAccountClient(this);
				base.ConnectComplete += delegate
				{
					try
					{
						RegisterSocket();
					}
					catch (Exception exception)
					{
						Logger.Warn("Exception regiserting socket", exception);
					}
				};
			}
			finally
			{
				Logger.DebugFormat("<==AccountManagerClient");
			}
		}

		public void RegisterServiceCode()
		{
			try
			{
				Logger.DebugFormat("==>RegisterServiceCode({0})", m_serviceCode);
				EnsureConnected(TimeSpan.FromSeconds(60.0));
				new GenericHandler(m_socket, Commands.RegisterServiceCode).Execute(m_serviceCode);
			}
			finally
			{
				Logger.Debug("<==RegisterServiceCode()");
			}
		}

		public void StartAutoRegistration()
		{
			try
			{
				Logger.Debug("==>StartAutoRegistration()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.StartAutoRegistration).Execute(m_serviceCode);
			}
			finally
			{
				Logger.Debug("<==StartAutoRegistration()");
			}
		}

		public void StopAutoRegistration()
		{
			try
			{
				Logger.Debug("==>StopAutoRegistration()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.StopAutoRegistration).Execute(m_serviceCode);
			}
			finally
			{
				Logger.Debug("<==StopAutoRegistration()");
			}
		}

		public void StartLogin()
		{
			try
			{
				Logger.Debug("==>StartLogin()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.StartLogin).Execute();
			}
			finally
			{
				Logger.Debug("<==StartLogin");
			}
		}

		public LoginResult TryLogin()
		{
			try
			{
				Logger.Debug("==>TryLogin()");
				EnsureConnected();
				return (LoginResult)new GenericHandlerInt(m_socket, Commands.TryLogin).Execute();
			}
			finally
			{
				Logger.Debug("<==TryLogin");
			}
		}

		public bool IsLoggedIn()
		{
			try
			{
				Logger.Debug("==>IsLoggedIn()");
				return GetCurrentUser() != null;
			}
			finally
			{
				Logger.DebugFormat("<==IsLoggedIn - {0}", m_isLoggedIn);
			}
		}

		public RazerUser GetCurrentUser()
		{
			EnsureConnected();
			RazerUser razerUser = new GenericHandler<RazerUser>(m_socket, Commands.GetCurrentUser).Execute();
			m_isLoggedIn = razerUser != null;
			return razerUser;
		}

		public void RefreshToken()
		{
			try
			{
				Logger.Debug("==>RefreshToken()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.RefreshToken).Execute();
			}
			finally
			{
				Logger.Debug("<==RefreshToken");
			}
		}

		public void StartLogout()
		{
			try
			{
				Logger.Debug("==>StartLogout()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.StartLogout).Execute();
			}
			finally
			{
				Logger.Debug("<==StartLogout");
			}
		}

		public UserProfile GetUserProfile()
		{
			try
			{
				Logger.Debug("==>GetUserProfile()");
				EnsureConnected();
				return new GenericHandler<UserProfile>(m_socket, Commands.GetUserProfile).Execute();
			}
			finally
			{
				Logger.Debug("<==GetUserProfile");
			}
		}

		public UserProfile RefreshUserProfile()
		{
			try
			{
				Logger.Debug("==>RefreshUserProfile()");
				EnsureConnected();
				return new GenericHandler<UserProfile>(m_socket, Commands.RefreshUserProfile).Execute();
			}
			finally
			{
				Logger.Debug("<==RefreshUserProfile");
			}
		}

		public void UpdateUserProfile(UserProfile profile)
		{
			try
			{
				Logger.Debug("==>UpdateUserProfile()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.PutUserProfile).Execute(profile);
			}
			finally
			{
				Logger.Debug("<==UpdateUserProfile");
			}
		}

		public void UpdateUserProfile(string item, string newValue)
		{
			try
			{
				Logger.DebugFormat($"==>UpdateUserProfile({item}, {newValue})");
				UserProfile userProfile = new UserProfile();
				userProfile.AddProfileItem(new UserProfileItem(item, newValue));
				UpdateUserProfile(userProfile);
			}
			finally
			{
				Logger.Debug("<==UpdateUserProfile");
			}
		}

		public void DeleteProfileItem(string name)
		{
			try
			{
				Logger.DebugFormat("==>DeleteProfileItem({0})", name);
				EnsureConnected();
				new GenericHandler(m_socket, Commands.DeleteUserProfile).Execute(name);
			}
			finally
			{
				Logger.Debug("<==DeleteProfileItem");
			}
		}

		public int SubmitFeedback(FeedbackData feedback)
		{
			try
			{
				Logger.Debug("==>SubmitFeedback()");
				EnsureConnected();
				if (string.IsNullOrEmpty(feedback.ServiceCode))
				{
					feedback.ServiceCode = m_serviceCode;
				}
				return new GenericHandlerInt(m_socket, Commands.SubmitFeedback).WithTimeout(120000).Execute(feedback);
			}
			finally
			{
				Logger.Debug("<==SubmitFeedback");
			}
		}

		public BigDataPushStatus PushBigData(string[] dataFiles)
		{
			try
			{
				Logger.Debug("==>PushBigData()");
				EnsureConnected();
				return (BigDataPushStatus)new GenericHandlerInt(m_socket, Commands.PushBigData).Execute(dataFiles);
			}
			finally
			{
				Logger.Debug("<==PushBigData");
			}
		}

		public void SetSettingBaseAddress(string url)
		{
			try
			{
				Logger.DebugFormat("==>SetSettingBaseAddress({0})", url);
				EnsureConnected();
				new GenericHandler(m_socket, Commands.SetSettingBaseAddress).Execute(m_projectName, url);
			}
			finally
			{
				Logger.Debug("<==SetSettingBaseAddress");
			}
		}

		public List<SettingDefinition> GetSettingList(string pathExpression, string nameExpression, SettingSource source)
		{
			try
			{
				Logger.DebugFormat("==>GetSettingList({0}, {1}, {2})", pathExpression, nameExpression, source);
				return new GetSettingListHandler(m_socket).Execute(m_projectName, pathExpression, nameExpression, source);
			}
			finally
			{
				Logger.Debug("<==GetSettingList");
			}
		}

		public List<SettingDefinition> GetSettingList(string pathExpression, SettingSource source)
		{
			try
			{
				Logger.DebugFormat("==>GetSettingList({0}, {1})", pathExpression, source);
				return GetSettingList(pathExpression, string.Empty, source);
			}
			finally
			{
				Logger.Debug("<==GetSettingList");
			}
		}

		public SettingReadResult GetSetting(string path, string name, SettingSource source, SettingSource autoResolvePolicy = SettingSource.Undefined)
		{
			SettingReadResult settingReadResult = null;
			try
			{
				Logger.DebugFormat("==>GetSetting({0}, {1}, {2}, {3})", path, name, source, autoResolvePolicy);
				EnsureConnected();
				settingReadResult = new GenericHandler<SettingReadResult>(m_socket, Commands.GetSetting).Execute(m_projectName, path, name, source, autoResolvePolicy);
				return settingReadResult;
			}
			finally
			{
				Logger.DebugFormat("<==GetSetting - {0}", (settingReadResult == null) ? "(null)" : $"{settingReadResult.ResultLocal}:{settingReadResult.ResultServer}");
			}
		}

		public SettingReadResult GetSetting(SettingDefinition def, SettingSource source, SettingSource autoResolvePolicy = SettingSource.Undefined)
		{
			try
			{
				Logger.DebugFormat("==>GetSetting(({0}, {1}), {2}, {3})", def.Path, def.Name, source, autoResolvePolicy);
				return GetSetting(def.Path, def.Name, source, autoResolvePolicy);
			}
			finally
			{
				Logger.Debug("<==GetSetting");
			}
		}

		public T GetSetting<T>(string path, string name, SettingSource source, T defaultValue)
		{
			try
			{
				Logger.DebugFormat("==>GetSetting({0}, {1}, {2}, ({3}){4})", path, name, source, typeof(T), defaultValue);
				SettingReadResult setting = GetSetting(path, name, source);
				if (!setting.Success)
				{
					return defaultValue;
				}
				if (typeof(T) == typeof(int))
				{
					return (T)(object)setting.Setting.IntValue;
				}
				if (typeof(T) == typeof(double))
				{
					return (T)(object)setting.Setting.DoubleValue;
				}
				if (typeof(T) == typeof(string))
				{
					return (T)(object)setting.Setting.StringValue;
				}
				if (typeof(T) == typeof(bool))
				{
					return (T)(object)setting.Setting.BoolValue;
				}
				if (typeof(T) == typeof(byte[]))
				{
					return (T)(object)setting.Setting.Value;
				}
				throw new ArgumentException("Unsupported setting type: " + typeof(T));
			}
			catch
			{
				return defaultValue;
			}
			finally
			{
				Logger.Debug("<==GetSetting");
			}
		}

		public T GetSetting<T>(SettingDefinition def, SettingSource source, T defaultValue)
		{
			try
			{
				Logger.DebugFormat("==>GetSetting(({0}, {1}), {2}, ({3}){4})", def.Path, def.Name, source, typeof(T), defaultValue);
				return GetSetting(def.Path, def.Name, source, defaultValue);
			}
			finally
			{
				Logger.Debug("<==GetSetting");
			}
		}

		public T GetGlobalSetting<T>(GlobalSetting setting, T defaultValue)
		{
			try
			{
				Logger.DebugFormat("==>GetGlobalSetting({0}, ({1}){2})", setting, typeof(T), defaultValue);
				SettingReadResult setting2 = GetSetting(setting, SettingSource.Application);
				if (!setting2.Success)
				{
					return defaultValue;
				}
				if (typeof(T) == typeof(int))
				{
					return (T)(object)setting2.Setting.IntValue;
				}
				if (typeof(T) == typeof(double))
				{
					return (T)(object)setting2.Setting.DoubleValue;
				}
				if (typeof(T) == typeof(string))
				{
					return (T)(object)setting2.Setting.StringValue;
				}
				if (typeof(T) == typeof(bool))
				{
					return (T)(object)setting2.Setting.BoolValue;
				}
				if (typeof(T) == typeof(byte[]))
				{
					return (T)(object)setting2.Setting.Value;
				}
				throw new ArgumentException("Unsupported setting type: " + typeof(T));
			}
			catch
			{
				return defaultValue;
			}
			finally
			{
				Logger.Debug("<==GetGlobalSetting");
			}
		}

		public SaveResult SetSetting(RzSetting setting, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>SetSetting(({0}, {1}), {2})", setting.Path, setting.Name, type);
				EnsureConnected();
				return (SaveResult)new GenericHandlerInt(m_socket, Commands.SetSetting).Execute(m_projectName, setting, type);
			}
			finally
			{
				Logger.Debug("<==SetSetting");
			}
		}

		public SaveResult DeleteSetting(RzSetting setting, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>DeleteSetting(({0}, {1}), {2})", setting.Path, setting.Name, type);
				EnsureConnected();
				return new DeleteSettingHandler(m_socket).Execute(m_projectName, setting, type);
			}
			finally
			{
				Logger.Debug("<==DeleteSetting");
			}
		}

		public SaveResult DeleteSetting(SettingDefinition def, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>DeleteSetting(({0}, {1}), {2})", def.Path, def.Name, type);
				return DeleteSetting(new RzSetting(def), type);
			}
			finally
			{
				Logger.Debug("<==DeleteSetting");
			}
		}

		public SaveResult DeleteAll(string path, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>DeleteAll({0}, {1})", path, type);
				EnsureConnected();
				return new DeleteAllHandler(m_socket).Execute(m_projectName, path, type);
			}
			finally
			{
				Logger.Debug("<==DeleteAll");
			}
		}

		public SettingReadResult GetSetting(GlobalSetting setting, SettingSource source, SettingSource autoResolvePolicy = SettingSource.Undefined)
		{
			SettingReadResult settingReadResult = null;
			try
			{
				Logger.DebugFormat("==>GetSetting({0}, {1}, {2})", setting, source, autoResolvePolicy);
				EnsureConnected();
				settingReadResult = new GenericHandler<SettingReadResult>(m_socket, Commands.GetSetting).Execute(SettingsGlobalProject, SettingsGlobalPath, setting.GetDescription(), source, autoResolvePolicy);
				return settingReadResult;
			}
			finally
			{
				Logger.DebugFormat("<==GetSetting - {0}", (settingReadResult == null) ? "(null)" : $"{settingReadResult.ResultLocal}:{settingReadResult.ResultServer}");
			}
		}

		public SaveResult SetSetting(GlobalSetting setting, byte[] value, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>SetSetting<byte>({0}, {1})", setting, type);
				EnsureConnected();
				return new SetSettingHandler(m_socket).Execute(SettingsGlobalProject, new RzSetting(SettingsGlobalPath, setting.GetDescription(), value), type);
			}
			finally
			{
				Logger.Debug("<==SetSetting");
			}
		}

		public SaveResult SetSetting(GlobalSetting setting, string value, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>SetSetting<string>({0}, {1})", setting, type);
				EnsureConnected();
				return new SetSettingHandler(m_socket).Execute(SettingsGlobalProject, new RzSetting(SettingsGlobalPath, setting.GetDescription(), value), type);
			}
			finally
			{
				Logger.Debug("<==SetSetting");
			}
		}

		public SaveResult SetSetting(GlobalSetting setting, int value, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>SetSetting<int>({0}, {1})", setting, type);
				EnsureConnected();
				return new SetSettingHandler(m_socket).Execute(SettingsGlobalProject, new RzSetting(SettingsGlobalPath, setting.GetDescription(), value), type);
			}
			finally
			{
				Logger.Debug("<==SetSetting");
			}
		}

		public SaveResult SetSetting(GlobalSetting setting, bool value, SettingSaveType type)
		{
			try
			{
				Logger.DebugFormat("==>SetSetting<bool>({0}, {1})", setting, type);
				EnsureConnected();
				return new SetSettingHandler(m_socket).Execute(SettingsGlobalProject, new RzSetting(SettingsGlobalPath, setting.GetDescription(), value), type);
			}
			finally
			{
				Logger.Debug("<==SetSetting");
			}
		}

		public SaveResult ResolveConflict(string path, string name, SettingSource source)
		{
			try
			{
				Logger.DebugFormat("==>ResolveConflict({0}, {1}, {2})", path, name, source);
				EnsureConnected();
				return new ResolveConflictHandler(m_socket).Execute(m_projectName, path, name, source);
			}
			finally
			{
				Logger.Debug("<==ResolveConflict");
			}
		}

		public SaveResult ResolveConflict(GlobalSetting setting, SettingSource source)
		{
			try
			{
				Logger.DebugFormat("==>ResolveConflict({0}, {1})", setting, source);
				EnsureConnected();
				return new ResolveConflictHandler(m_socket).Execute(SettingsGlobalProject, SettingsGlobalPath, setting.GetDescription(), source);
			}
			finally
			{
				Logger.Debug("<==ResolveConflict");
			}
		}

		public void StartSync(IEnumerable<string> paths, SyncProgressDelegate onSyncProgress, SyncCompleteDelegate onSyncComplete)
		{
			try
			{
				Logger.DebugFormat("==>StartSync({0})", (paths == null) ? "null" : string.Join(", ", paths));
				EnsureConnected();
				Guid guid = Guid.NewGuid();
				if (onSyncProgress != null)
				{
					m_syncProgressDelegates[guid.ToString()] = onSyncProgress;
				}
				if (onSyncComplete != null)
				{
					m_syncCompleteDelegates[guid.ToString()] = onSyncComplete;
				}
				new GenericHandler(m_socket, Commands.StartSync).Execute(paths, m_projectName, guid.ToString());
			}
			finally
			{
				Logger.Debug("<==StartSync");
			}
		}

		public void StartSync(string path, SyncProgressDelegate onSyncProgress, SyncCompleteDelegate onSyncComplete)
		{
			try
			{
				Logger.DebugFormat("==>StartSync({0})", path);
				EnsureConnected();
				List<string> list = new List<string>();
				list.Add(path);
				StartSync(list, onSyncProgress, onSyncComplete);
			}
			finally
			{
				Logger.Debug("<==StartSync");
			}
		}

		public void StartSync(IEnumerable<SettingDefinition> settings, SyncProgressDelegate onSyncProgress, SyncCompleteDelegate onSyncComplete)
		{
			try
			{
				Logger.DebugFormat("==>StartSync({0})", (settings == null) ? "null" : string.Join(", ", settings.Select((SettingDefinition x) => x.Path + "\\" + x.Name)));
				EnsureConnected();
				Guid guid = Guid.NewGuid();
				if (onSyncProgress != null)
				{
					m_syncProgressDelegates[guid.ToString()] = onSyncProgress;
				}
				if (onSyncComplete != null)
				{
					m_syncCompleteDelegates[guid.ToString()] = onSyncComplete;
				}
				new GenericHandler(m_socket, Commands.StartFileSync).Execute(settings, m_projectName, guid.ToString());
			}
			finally
			{
				Logger.Debug("<==StartSync");
			}
		}

		public void CancelSync()
		{
			try
			{
				Logger.Debug("==>CancelSync()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.CancelSync).Execute(m_projectName);
			}
			finally
			{
				Logger.Debug("<==CancelSync");
			}
		}

		public DateTime GetLastSyncDate()
		{
			try
			{
				Logger.Debug("==>GetLastSyncDate()");
				EnsureConnected();
				return new GetLastSyncDateHandler(m_socket).Execute(m_projectName);
			}
			finally
			{
				Logger.Debug("<==GetLastSyncDate");
			}
		}

		public LanguageInfo GetUILanguage()
		{
			LanguageInfo languageInfo = null;
			try
			{
				Logger.Debug("==>GetUILanguage()");
				EnsureConnected();
				languageInfo = new GetUILanguageHandler(m_socket).Execute();
				return languageInfo;
			}
			finally
			{
				if (languageInfo == null)
				{
					Logger.Error("<==GetUILanguage(null)");
				}
				else
				{
					Logger.Debug($"<==GetUILanguage({languageInfo.Language}:{languageInfo.LanguageKey})");
				}
			}
		}

		public void SetUILanguage(Languages newLanguage)
		{
			try
			{
				Logger.DebugFormat("==>SetUILanguage({0})", newLanguage);
				EnsureConnected();
				new GenericHandler(m_socket, Commands.UI_SetLanguage).Execute((int)newLanguage);
			}
			finally
			{
				Logger.Debug("<==SetUILanguage");
			}
		}

		public UiTheme GetUITheme()
		{
			UiTheme uiTheme = UiTheme.Undefined;
			try
			{
				Logger.Debug("==>GetUITheme()");
				EnsureConnected();
				uiTheme = new GetUIThemeHandler(m_socket).Execute();
				return uiTheme;
			}
			finally
			{
				Logger.Debug($"<==GetUITheme({uiTheme})");
			}
		}

		public void SetUITheme(UiTheme newTheme)
		{
			try
			{
				Logger.DebugFormat("==>SetUITheme({0})", newTheme);
				EnsureConnected();
				new GenericHandler(m_socket, Commands.SetUiTheme).Execute((int)newTheme);
			}
			finally
			{
				Logger.Debug("<==SetUITheme");
			}
		}

		public AppLicense AddLicenseCode(string appId, string licenseCode)
		{
			try
			{
				Logger.DebugFormat("==>AddLicenseCode({0}, {1})", appId, licenseCode);
				EnsureConnected();
				return new AddLicenseCodeHandler(m_socket).Execute(appId, licenseCode);
			}
			finally
			{
				Logger.Debug("<==AddLicenseCode");
			}
		}

		public bool IsLicensed(string appId)
		{
			try
			{
				Logger.DebugFormat("==>IsLicensed({0})", appId);
				EnsureConnected();
				return new IsLicensedHandler(m_socket).Execute(appId);
			}
			finally
			{
				Logger.Debug("<==IsLicensed");
			}
		}

		public AppLicense RequestLicense(string appId, LicenseLanguageCode language, LicenseDevice device)
		{
			try
			{
				Logger.DebugFormat("==>RequestLicense({0}, {1}, {2})", appId, language, device.SerialNumber);
				EnsureConnected();
				return new RequestLicenseHandler(m_socket).Execute(appId, language, device);
			}
			finally
			{
				Logger.Debug("<==RequestLicense");
			}
		}

		public bool LicensesAvailable(string appId, string serialNumber)
		{
			try
			{
				Logger.DebugFormat("==>LicensesAvailable({0}, {1})", appId, serialNumber);
				EnsureConnected();
				return new LicensesAvailableHandler(m_socket).Execute(appId, serialNumber);
			}
			finally
			{
				Logger.Debug("<==LicensesAvailable");
			}
		}

		public void RegisterPlugin(IEnumerable<RazerDevice> devices)
		{
			try
			{
				Logger.DebugFormat("==>RegisterPlugin({0})", string.Join(", ", devices?.Select((RazerDevice x) => x.Pid.ToString())));
				EnsureConnected();
				new GenericHandler(m_socket, Commands.RegisterPlugin).Execute(devices);
			}
			finally
			{
				Logger.Debug("<==RegisterPlugin");
			}
		}

		public void RegisterUnplug(IEnumerable<RazerDevice> devices)
		{
			try
			{
				Logger.DebugFormat("==>RegisterUnplug({0})", string.Join(", ", devices?.Select((RazerDevice x) => x.Pid.ToString())));
				EnsureConnected();
				new GenericHandler(m_socket, Commands.RegisterUnplug).Execute(devices);
			}
			finally
			{
				Logger.Debug("<==RegisterUnplug");
			}
		}

		public string GetDeviceInfo(RazerDevice device)
		{
			try
			{
				Logger.DebugFormat("==>GetDeviceInfo({0})", device.Pid);
				EnsureConnected();
				return new GetDeviceInfoHandler(m_socket).Execute(device);
			}
			finally
			{
				Logger.Debug("<==GetDeviceInfo");
			}
		}

		public WarrantyDevice RegisterWarranty(WarrantyUser user, WarrantyItem device)
		{
			try
			{
				Logger.DebugFormat("==>RegisterWarranty(*******, {0})", device.SerialNumber);
				EnsureConnected();
				return new RegisterWarrantyHandler(m_socket).Execute(user, device);
			}
			finally
			{
				Logger.Debug("<==RegisterWarranty");
			}
		}

		public WarrantyResponse GetMyWarranties()
		{
			try
			{
				Logger.Debug("==>GetMyWarranties()");
				EnsureConnected();
				return new GetMyWarrantiesHandler(m_socket).Execute();
			}
			finally
			{
				Logger.Debug("<==GetMyWarranties");
			}
		}

		public WarrantyResponse GetWarrantyInfo(RazerDevice device)
		{
			try
			{
				Logger.DebugFormat("==>GetWarrantyInfo({0})", device.SerialNumber);
				EnsureConnected();
				return new GetWarrantyInfoHandler(m_socket).Execute(device);
			}
			finally
			{
				Logger.Debug("<==GetWarrantyInfo");
			}
		}

		public WarrantyDevice HideWarranty(WarrantyItem device)
		{
			try
			{
				Logger.DebugFormat("==>HideWarranty({0})", device.SerialNumber);
				EnsureConnected();
				return new HideWarrantyHandler(m_socket).Execute(device);
			}
			finally
			{
				Logger.Debug("<==HideWarranty");
			}
		}

		public void AddFriendIds(IEnumerable<ExternalIdInfo> friendIds)
		{
			EnsureConnected();
			new GenericHandler(m_socket, Commands.AddFriendIds).Execute(friendIds);
		}

		public FriendSearchResult SearchFriends(IdSource source, IEnumerable<string> externalIds)
		{
			EnsureConnected();
			return new SearchFriendsHandler(m_socket).Execute(source, externalIds);
		}

		public void StartUi()
		{
			try
			{
				Logger.Debug("==>StartUi()");
				EnsureConnected();
				new GenericHandler(m_socket, Commands.StartUi).Execute();
			}
			finally
			{
				Logger.Debug("<==StartUi");
			}
		}

		public bool FeatureEnabled(string clientId, string feature)
		{
			try
			{
				Logger.Debug($"==>FeatureEnabled({clientId}, {feature})");
				EnsureConnected();
				return new GenericHandlerBool(m_socket, Commands.FeatureEnabled).Execute(clientId, feature);
			}
			finally
			{
				Logger.Debug("<==FeatureEnabled");
			}
		}

		public async Task<bool> VerifyTosConsent(string serviceCode, RazerApps app)
		{
			try
			{
				Logger.Debug($"==>VerifyTosConsent({serviceCode})");
				return true;
			}
			finally
			{
				m_consentData = null;
				Logger.Debug("<==VerifyTosConsent");
			}
		}

		private void HandleTosConsentCompleted(ClientPipeSocket socket, byte[] data)
		{
			TosConsentDetails tosConsentDetails;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					tosConsentDetails = binaryReader.Read<TosConsentDetails>();
				}
			}
			if (m_consentData != null && tosConsentDetails.ServiceCode == m_consentData.ServiceCode)
			{
				m_consentData.Consented = tosConsentDetails.Consented;
				m_consentData.TosConsentEvent.Release(20);
			}
		}

		protected override void OnDisconnect()
		{
			base.OnDisconnect();
			if (m_consentData != null)
			{
				m_consentData.Consented = false;
				m_consentData.ConsentException = new IOException("Service disconnected waiting for consent.");
				m_consentData.TosConsentEvent.Release(20);
			}
		}

		private void HandleSyncProgressEvent(ClientPipeSocket socket, byte[] data)
		{
			string text = null;
			SyncProgressEventArgs e = null;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					text = binaryReader.ReadString();
					e = binaryReader.Read<SyncProgressEventArgs>();
				}
			}
			try
			{
				Logger.Debug($"==>Event: SyncProgress({text}, {e.CompleteItems}/{e.TotalItems})");
				if (m_syncProgressDelegates.TryGetValue(text, out var value))
				{
					value(e);
				}
			}
			catch (Exception exception)
			{
				Logger.Warn("Exception in sync progress handler", exception);
			}
			finally
			{
				Logger.Debug("<==Event: SyncProgress");
			}
			byte[] data2 = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(2147549186u);
					binaryWriter.Write((IRazerSerializable)e);
				}
				data2 = memoryStream.ToArray();
			}
			socket.Send(RzServiceType.AccountManager, data2);
		}

		private void HandleSyncCompleteEvent(ClientPipeSocket socket, byte[] data)
		{
			string text = null;
			SyncStatus status = SyncStatus.Failed_Unknown;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					text = binaryReader.ReadString();
					status = (SyncStatus)binaryReader.ReadInt32();
				}
			}
			try
			{
				Logger.Debug($"==>Event: SyncCompleteSyncComplete({text})");
				if (m_syncCompleteDelegates.TryGetValue(text, out var value))
				{
					value(status);
				}
			}
			finally
			{
				m_syncProgressDelegates.Remove(text);
				m_syncCompleteDelegates.Remove(text);
				Logger.Debug("<==Event: SyncComplete");
			}
		}

		protected override void OnReceive(ClientPipeSocket socket, long packetId, byte[] data)
		{
			try
			{
				switch ((Commands)BitConverter.ToUInt32(data, 0))
				{
				case Commands.Event_Login:
					HandleLoginEvent(socket, data);
					break;
				case Commands.Event_LogoutStarted:
					HandleLogoutStartedEvent(socket, data);
					break;
				case Commands.Event_LogoutComplete:
					HandleLogoutEvent(socket, data);
					break;
				case Commands.Event_SyncProgress:
					HandleSyncProgressEvent(socket, data);
					break;
				case Commands.Event_SyncComplete:
					HandleSyncCompleteEvent(socket, data);
					break;
				case Commands.Event_ProfileUpdated:
					HandleProfileUpdatedEvent(socket, data);
					break;
				case Commands.Event_UiLanguageChanged:
					HandleUILanguageChanged(socket, data);
					break;
				case Commands.Event_UiThemeChanged:
					HandleUIThemeChanged(socket, data);
					break;
				case Commands.Event_ConnectedAccountConnected:
					HandleConnectedAccountConnected(socket, data);
					break;
				case Commands.Event_DisconnectFromAccountComplete:
					HandleDisconnectFromAccountComplete(socket, data);
					break;
				case Commands.Event_GlobalSettingChanged:
					HandleGlobalSettingChanged(socket, data);
					break;
				case Commands.Event_FeatureChanged:
					HandleFeatureChanged(socket, data);
					break;
				case Commands.Event_UserUpdated:
					HandleUserUpdated(socket, data);
					break;
				case Commands.Event_TosConsentCompleted:
					HandleTosConsentCompleted(socket, data);
					break;
				case Commands.Event_AccountModeChanged:
					break;
				}
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in OnReceive", exception);
			}
		}

		private void HandleLoginEvent(ClientPipeSocket socket, byte[] data)
		{
			LoginEventArgs args = null;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<LoginEventArgs>();
				}
			}
			OnLoginComplete(args);
		}

		protected virtual void OnLoginComplete(LoginEventArgs args)
		{
			try
			{
				lock (m_currentUserLock)
				{
					if (m_currentUser != null && m_currentUser == args.User)
					{
						Logger.Debug("Supressing login complete event for same user.");
						return;
					}
					m_currentUser = args.User;
				}
				m_isLoggedIn = args.User != null;
				Logger.Debug("==>Event: LoginComplete()");
				this.LoginComplete?.Invoke(this, args);
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in LoginComplete callback", exception);
			}
			finally
			{
				Logger.Debug("<==Event: LoginComplete");
			}
		}

		private void HandleLogoutStartedEvent(ClientPipeSocket socket, byte[] data)
		{
			LogoutEventArgs args = null;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<LogoutEventArgs>();
				}
			}
			OnLogoutStarted(args);
			byte[] data2 = null;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (BinaryWriter binaryWriter = new BinaryWriter(memoryStream))
				{
					binaryWriter.Write(2147549194u);
				}
				data2 = memoryStream.ToArray();
			}
			socket.Send(RzServiceType.AccountManager, data2);
		}

		private void OnLogoutStarted(LogoutEventArgs args)
		{
			try
			{
				Logger.Debug($"==>Event: LogoutStarted({args.Reason})");
				if (m_consentData != null)
				{
					m_consentData.Consented = false;
					m_consentData.TosConsentEvent.Release(20);
				}
				this.LogoutStarted?.Invoke(this, args);
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in LogoutStarted callback", exception);
			}
			finally
			{
				Logger.Debug("<==Event: LogoutStarted");
			}
		}

		private void HandleLogoutEvent(ClientPipeSocket socket, byte[] data)
		{
			lock (m_currentUserLock)
			{
				m_currentUser = null;
			}
			LogoutEventArgs args = null;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<LogoutEventArgs>();
				}
			}
			m_isLoggedIn = false;
			OnLogoutComplete(args);
		}

		private void OnLogoutComplete(LogoutEventArgs args)
		{
			try
			{
				Logger.Debug($"==>Event: LogoutComplete({args.Reason})");
				this.LogoutComplete?.Invoke(this, args);
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in LogoutComplete callback", exception);
			}
			finally
			{
				Logger.Debug("<==Event: LogoutComplete");
			}
		}

		private void HandleProfileUpdatedEvent(ClientPipeSocket socket, byte[] data)
		{
			UserProfileUpdatedEventArgs args = null;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<UserProfileUpdatedEventArgs>();
				}
			}
			OnUserProfileUpdated(args);
		}

		private void OnUserProfileUpdated(UserProfileUpdatedEventArgs args)
		{
			try
			{
				Logger.Debug(string.Format("==>Event: UserProfileUpdated([{0}])", string.Join(",", args.UpdatedItems)));
				this.UserProfileUpdated?.Invoke(this, args);
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in UserProfileUpdated callback", exception);
			}
			finally
			{
				Logger.Debug("<==Event: UserProfileUpdated");
			}
		}

		private void HandleUILanguageChanged(ClientPipeSocket socket, byte[] data)
		{
			Languages language;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					language = (Languages)binaryReader.ReadInt32();
				}
			}
			LanguageInfo info = new LanguageInfo(language);
			OnUiLanguageChanged(info);
		}

		private void HandleUIThemeChanged(ClientPipeSocket socket, byte[] data)
		{
			UiTheme uiTheme;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					uiTheme = (UiTheme)binaryReader.ReadInt32();
				}
			}
			try
			{
				Logger.Debug($"==>Event: UIThemeChanged({uiTheme})");
				this.UIThemeChanged?.Invoke(this, new UIThemeChangedEventArgs(uiTheme));
			}
			finally
			{
				Logger.Debug("<==Event: UIThemeChanged");
			}
		}

		private void OnUiLanguageChanged(LanguageInfo info)
		{
			try
			{
				Logger.Debug($"==>Event: UILanguageChanged({info.Language})");
				this.UILanguageChanged?.Invoke(this, new UILanguageChangedEventArgs(info));
			}
			catch (Exception exception)
			{
				Logger.Error("Exception in UILanguageChanged callback", exception);
			}
			finally
			{
				Logger.Debug("<==Event: UILanguageChanged");
			}
		}

		private void HandleConnectedAccountConnected(ClientPipeSocket socket, byte[] data)
		{
			ConnectCompletedEventArgs args;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<ConnectCompletedEventArgs>();
				}
			}
			ConnectedAccounts.OnConnectComplete(args);
		}

		private void HandleDisconnectFromAccountComplete(ClientPipeSocket socket, byte[] data)
		{
			DisconnectEventArgs args;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					args = binaryReader.Read<DisconnectEventArgs>();
				}
			}
			ConnectedAccounts.OnDisconnectComplete(args);
		}

		private void HandleGlobalSettingChanged(ClientPipeSocket socket, byte[] data)
		{
			SettingChangedEventArgs e;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					e = binaryReader.Read<SettingChangedEventArgs>();
				}
			}
			try
			{
				Logger.Debug($"==>Event: GlobalSettingChanged({e.Name})");
				this.GlobalSettingChanged?.Invoke(this, e);
			}
			finally
			{
				Logger.Debug("<==Event: GlobalSettingChanged");
			}
		}

		private void HandleFeatureChanged(ClientPipeSocket socket, byte[] data)
		{
			FeatureChangedEventArgs e;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					e = binaryReader.Read<FeatureChangedEventArgs>();
				}
			}
			try
			{
				Logger.Debug(string.Format("==>Event: FeatureChanged({0}, {1})", e.Feature, e.IsEnabled ? "Enabled" : "Disabled"));
				this.FeatureChanged?.Invoke(this, e);
			}
			finally
			{
				Logger.Debug("<==Event: FeatureChanged");
			}
		}

		private void HandleUserUpdated(ClientPipeSocket socket, byte[] data)
		{
			UserUpdatedEventArgs e;
			using (MemoryStream input = new MemoryStream(data))
			{
				using (BinaryReader binaryReader = new BinaryReader(input))
				{
					binaryReader.ReadInt32();
					e = binaryReader.Read<UserUpdatedEventArgs>();
				}
			}
			try
			{
				Logger.Debug("==>Event: UserUpdated()");
				this.UserUpdated?.Invoke(this, e);
			}
			finally
			{
				Logger.Debug("<==Event: UserUpdated");
			}
		}

		private void RegisterSocket()
		{
			if (!string.IsNullOrEmpty(m_serviceCode))
			{
				EnsureConnected();
				new GenericHandler(m_socket, Commands.RegisterSocket).Execute(m_serviceCode);
			}
		}

		protected override void OnReconnected()
		{
			if (m_isLoggedIn)
			{
				StartLogin();
			}
		}
	}
}
