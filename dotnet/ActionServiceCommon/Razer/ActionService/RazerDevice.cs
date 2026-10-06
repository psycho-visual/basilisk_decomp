using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Linq;

namespace Razer.ActionService
{
	[DataContract]
	public class RazerDevice : IRazerSerializable
	{
		public const uint RazerVid = 5426u;

		public const uint BootloaderPid = 4365u;

		[DataMember]
		public uint Vid { get; set; }

		[DataMember]
		public uint Pid { get; set; }

		[DataMember]
		public byte Edition { get; set; }

		[DataMember]
		public string DeviceName { get; set; }

		[DataMember]
		public string SerialNumber { get; set; }

		[DataMember]
		public Version FirmwareVersion { get; set; }

		[DataMember]
		public IDictionary<Languages, string> DeviceNameLanguages { get; set; } = new Dictionary<Languages, string>();

		public bool InBootloader => Pid == 4365;

		public uint EditionPid => (uint)(Edition << 16) + Pid;

		public RazerDevice()
			: this(0u)
		{
		}

		public RazerDevice(uint pid)
			: this(pid, 0)
		{
		}

		public RazerDevice(uint pid, byte edition)
			: this(pid, edition, 5426u)
		{
		}

		public RazerDevice(uint pid, byte edition, uint vid)
		{
			Vid = vid;
			Pid = pid;
			Edition = edition;
		}

		public RazerDevice(uint pid, byte edition, uint vid, string deviceName, IDictionary<Languages, string> deviceNameLanguages = null)
			: this(pid, edition, vid)
		{
			if (!string.IsNullOrEmpty(deviceName))
			{
				DeviceName = deviceName;
			}
			DeviceNameLanguages = deviceNameLanguages;
		}

		public override string ToString()
		{
			return $"RazerDevice: \"Vid\"=\"{Vid}\", \"Pid\"=\"{Pid}\", \"Edition\"=\"{Edition}\", \"DeviceName\"=\"{DeviceName}\", \"FirmwareVersion\"=\"{FirmwareVersion}\"";
		}

		public RazerDevice(XDocument doc)
			: this(doc.Element("RazerDevice"))
		{
		}

		public RazerDevice(XElement element)
		{
			Vid = (uint)element.Element("Vid");
			Pid = (uint)element.Element("Pid");
			Edition = (byte)(uint)element.Element("Edition");
			DeviceName = (string)element.Element("DeviceName");
			SerialNumber = (string)element.Element("SerialNumber");
		}

		public XElement Serialize()
		{
			return new XElement("RazerDevice", new XElement("Vid", Vid), new XElement("Pid", Pid), new XElement("Edition", (uint)Edition), new XElement("DeviceName", DeviceName), new XElement("SerialNumber", SerialNumber));
		}

		public override int GetHashCode()
		{
			return (int)(EditionPid ^ Vid);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (!(obj is RazerDevice razerDevice))
			{
				return false;
			}
			if (Vid != razerDevice.Vid)
			{
				return false;
			}
			if (Pid != razerDevice.Pid)
			{
				return false;
			}
			if (Edition != razerDevice.Edition)
			{
				return false;
			}
			return true;
		}

		public static bool operator ==(RazerDevice lhs, RazerDevice rhs)
		{
			if ((object)lhs == rhs)
			{
				return true;
			}
			if ((object)lhs == null || (object)rhs == null)
			{
				return false;
			}
			return lhs.Equals(rhs);
		}

		public static bool operator !=(RazerDevice lhs, RazerDevice rhs)
		{
			return !(lhs == rhs);
		}
	}
}
