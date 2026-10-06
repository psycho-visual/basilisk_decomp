using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using log4net;

namespace Razer.ActionService.SettingsManager
{
	public class SettingsManager
	{
		private static readonly ILog Logger = LogManager.GetLogger("Updater.SettingsManager");

		private static SettingsManager _instance = null;

		private UpdateManagerSettings _updateManager;

		public static SettingsManager Instance => _instance ?? (_instance = new SettingsManager());

		public UpdateManagerSettings UpdateManager
		{
			get
			{
				if (_updateManager == null)
				{
					string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
					string text = Path.Combine(new string[4] { folderPath, "Razer", "Razer Central", "Update" });
					string path = Path.Combine(text, UpdateManagerSettings.FileName);
					if (File.Exists(path))
					{
						try
						{
							XmlSerializer xmlSerializer = new XmlSerializer(typeof(UpdateManagerSettings));
							using (XmlTextReader xmlTextReader = new XmlTextReader(new StringReader(File.ReadAllText(path))))
							{
								xmlTextReader.DtdProcessing = DtdProcessing.Ignore;
								_updateManager = (UpdateManagerSettings)xmlSerializer.Deserialize(xmlTextReader);
							}
						}
						catch (Exception exception)
						{
							Logger.Warn("Failed to read settings file: Reverting to default.", exception);
						}
					}
					if (_updateManager == null)
					{
						Directory.CreateDirectory(text);
						using (Stream stream = GetType().Assembly.GetManifestResourceStream("Razer.ActionService.SettingsManager.DefaultSettings.xml"))
						{
							if (stream != null)
							{
								_updateManager = (UpdateManagerSettings)new XmlSerializer(typeof(UpdateManagerSettings)).Deserialize(stream);
								stream.Seek(0L, SeekOrigin.Begin);
								string contents;
								using (StreamReader streamReader = new StreamReader(stream))
								{
									contents = streamReader.ReadToEnd();
								}
								File.WriteAllText(path, contents);
							}
						}
					}
				}
				return _updateManager;
			}
		}

		private SettingsManager()
		{
		}
	}
}
