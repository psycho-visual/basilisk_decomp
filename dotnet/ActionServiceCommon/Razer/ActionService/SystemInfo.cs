using System;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.Win32;
using log4net;

namespace Razer.ActionService
{
	[XmlType("Platform")]
	public class SystemInfo
	{
		private static readonly ILog Logger = LogManager.GetLogger("SystemInfo");

		private string m_osVersion;

		private string m_architecture;

		private string m_manufacturer;

		private string m_model;

		private string m_sku;

		private string m_serialNumber;

		[XmlElement(ElementName = "OS")]
		public string OsName
		{
			get
			{
				return "Windows";
			}
			set
			{
			}
		}

		[XmlElement(ElementName = "OSVer")]
		public string OsVersion
		{
			get
			{
				if (m_osVersion == null)
				{
					m_osVersion = "7";
					OperatingSystem oSVersion = Environment.OSVersion;
					switch (oSVersion.Version.Major)
					{
					case 5:
						m_osVersion = "XP";
						break;
					case 6:
						switch (oSVersion.Version.Minor)
						{
						case 0:
							m_osVersion = "Vista";
							break;
						case 1:
							m_osVersion = "7";
							break;
						case 2:
							m_osVersion = "8";
							break;
						case 3:
							m_osVersion = "8.1";
							break;
						}
						break;
					case 10:
						m_osVersion = "10";
						break;
					}
				}
				return m_osVersion;
			}
			set
			{
			}
		}

		[XmlIgnore]
		public string Locale
		{
			get
			{
				return Thread.CurrentThread.CurrentCulture.Name;
			}
			set
			{
			}
		}

		[XmlElement(ElementName = "Locale")]
		public string EnLocale
		{
			get
			{
				return "en";
			}
			set
			{
			}
		}

		[XmlElement(ElementName = "Arch")]
		public string Architecutre
		{
			get
			{
				if (m_architecture == null)
				{
					if (IntPtr.Size == 8)
					{
						m_architecture = "64";
					}
					if (m_architecture == null)
					{
						bool isWow = default(bool);
						bool flag = ModuleContainsFunction("kernel32.dll", "IsWow64Process") && IsWow64Process(GetCurrentProcess(), out isWow) && isWow;
						m_architecture = (flag ? "64" : "32");
					}
				}
				return m_architecture;
			}
			set
			{
			}
		}

		[XmlElement(ElementName = "Mfr")]
		public string Manufacturer
		{
			get
			{
				if (m_manufacturer == null)
				{
					m_manufacturer = GetBiosValue("SystemManufacturer");
					if (m_manufacturer == string.Empty)
					{
						m_manufacturer = GetMgmtPropertyValue("Win32_ComputerSystemProduct", "Vendor");
					}
					if (m_manufacturer == string.Empty)
					{
						m_manufacturer = "Generic-MFR";
					}
					if (m_manufacturer.Length > 20)
					{
						m_manufacturer = m_manufacturer.Substring(0, 20);
					}
				}
				return m_manufacturer;
			}
			set
			{
			}
		}

		public string Model
		{
			get
			{
				if (m_model == null)
				{
					m_model = GetBiosValue("SystemProductName");
					if (m_model == string.Empty)
					{
						m_model = GetMgmtPropertyValue("Win32_ComputerSystemProduct", "Name");
					}
					if (m_model == string.Empty)
					{
						m_model = "Generic-MDL";
					}
					if (m_model.Length > 20)
					{
						m_model = m_model.Substring(0, 20);
					}
				}
				return m_model;
			}
			set
			{
			}
		}

		public string SKU
		{
			get
			{
				if (m_sku == null)
				{
					m_sku = GetBiosValue("SystemSKU");
					if (m_sku == string.Empty)
					{
						m_sku = GetMgmtPropertyValue("Win32_ComputerSystemProduct", "SKUNumber");
					}
					if (m_sku == string.Empty)
					{
						m_sku = "Generic-SKU";
					}
					int num = 20;
					if (Manufacturer.ToUpper().Contains("RAZER") && Model.ToUpper().Contains("BLADE"))
					{
						num = 9;
					}
					if (m_sku.Length > num)
					{
						m_sku = m_sku.Substring(0, num);
					}
				}
				return m_sku;
			}
			set
			{
			}
		}

		[XmlElement(ElementName = "Sno")]
		public string SerialNumber
		{
			get
			{
				if (m_serialNumber == null)
				{
					m_serialNumber = GetMgmtPropertyValue("Win32_BIOS", "SerialNumber");
					if (m_serialNumber == string.Empty)
					{
						m_serialNumber = "Generic-SSN";
					}
					if (m_serialNumber.Length > 20)
					{
						m_serialNumber = m_serialNumber.Substring(0, 20);
					}
				}
				return m_serialNumber;
			}
			set
			{
			}
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool IsWow64Process(IntPtr hProcess, [MarshalAs(UnmanagedType.Bool)] out bool isWow64);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetCurrentProcess();

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
		private static extern IntPtr GetModuleHandle(string moduleName);

		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string methodName);

		public XElement Serialize()
		{
			try
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					new XmlWriterSettings
					{
						Indent = true,
						IndentChars = "  "
					};
					using (TextWriter textWriter = new StreamWriter(memoryStream))
					{
						new XmlSerializer(typeof(SystemInfo)).Serialize(textWriter, this);
						return XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Error("Serialization failed.", exception);
				return null;
			}
		}

		private static string GetBiosValue(string key)
		{
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\BIOS", writable: false);
				if (registryKey == null)
				{
					return string.Empty;
				}
				if (!registryKey.GetValueNames().Contains(key))
				{
					return string.Empty;
				}
				return registryKey.GetValue(key) as string;
			}
			catch (Exception exception)
			{
				Logger.Error("Failed to get value for BIOS key " + key, exception);
				return string.Empty;
			}
		}

		private static string GetMgmtPropertyValue(string strMgmtClass, string strPropertyName)
		{
			string result = string.Empty;
			try
			{
				foreach (ManagementObject instance in new ManagementClass(strMgmtClass).GetInstances())
				{
					if (instance.Properties[strPropertyName].Value != null)
					{
						result = instance.Properties[strPropertyName].Value.ToString();
						break;
					}
				}
			}
			catch (Exception exception)
			{
				Logger.Error("Failed to get Management value for property " + strPropertyName, exception);
			}
			return result;
		}

		private static bool ModuleContainsFunction(string moduleName, string methodName)
		{
			IntPtr moduleHandle = GetModuleHandle(moduleName);
			if (moduleHandle != IntPtr.Zero)
			{
				return GetProcAddress(moduleHandle, methodName) != IntPtr.Zero;
			}
			return false;
		}
	}
}
