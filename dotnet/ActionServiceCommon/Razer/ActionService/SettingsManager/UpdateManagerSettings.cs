using System;
using System.IO;
using System.Xml.Serialization;

namespace Razer.ActionService.SettingsManager
{
	[Serializable]
	public class UpdateManagerSettings
	{
		public static readonly string FileName = "UpdateManager.xml";

		private int _updateInterval;

		private bool _downloadUpdatesAutomatically;

		private bool _checkForUpdatesAutomatically;

		private long _maxDownloadSpeed;

		[XmlElement("UpdateInterval")]
		public int UpdateInterval
		{
			get
			{
				return _updateInterval;
			}
			set
			{
				_updateInterval = value;
				Save();
			}
		}

		[XmlElement("DownloadUpdatesAutomatically")]
		public bool DownloadUpdatesAutomatically
		{
			get
			{
				return _downloadUpdatesAutomatically;
			}
			set
			{
				_downloadUpdatesAutomatically = value;
				Save();
			}
		}

		[XmlElement("CheckForUpdatesAutomatically")]
		public bool CheckForUpdatesAutomatically
		{
			get
			{
				return _checkForUpdatesAutomatically;
			}
			set
			{
				_checkForUpdatesAutomatically = value;
				Save();
			}
		}

		[XmlElement("MaxDownloadSpeed")]
		public long MaxDownloadSpeed
		{
			get
			{
				return _maxDownloadSpeed;
			}
			set
			{
				_maxDownloadSpeed = value;
				Save();
			}
		}

		private void Save()
		{
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(UpdateManagerSettings));
			string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			using (TextWriter textWriter = new StreamWriter(Path.Combine(Path.Combine(new string[4] { folderPath, "Razer", "Razer Central", "Update" }), FileName)))
			{
				xmlSerializer.Serialize(textWriter, this);
			}
		}
	}
}
