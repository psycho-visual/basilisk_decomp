using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;

namespace CustomerFWU2Point5
{
	internal class CLocalize
	{
		public enum enumLocale
		{
			LOCALE_DEFAULT = 1,
			LOCALE_ENGLISH = 1,
			LOCALE_CHINESESIMPLIFIED = 2,
			LOCALE_CHINESETRADITIONAL = 3,
			LOCALE_FRENCH = 4,
			LOCALE_KOREAN = 5,
			LOCALE_JAPANESE = 6,
			LOCALE_GERMAN = 7,
			LOCALE_RUSSIAN = 8,
			LOCALE_SPANISH = 9,
			LOCALE_PORTUGUESE = 10
		}

		public struct structLocale
		{
			private enumLocale id;

			private string sLanguage;

			private string sResource;

			private string sFont;

			private short slanguagekey;

			public enumLocale Id => id;

			public string Language => sLanguage;

			public string Resource => sResource;

			public string Font => sFont;

			public short LanguageKey => slanguagekey;

			public structLocale(enumLocale id, string sLanguage, string sResource, string sFont, short slanguagekey)
			{
				this.id = id;
				this.sLanguage = sLanguage;
				this.sResource = sResource;
				this.sFont = sFont;
				this.slanguagekey = slanguagekey;
			}
		}

		private static readonly IList<structLocale> LocaleArray = new ReadOnlyCollection<structLocale>(new structLocale[10]
		{
			new structLocale(enumLocale.LOCALE_DEFAULT, "English", "", "Arial", 1033),
			new structLocale(enumLocale.LOCALE_CHINESESIMPLIFIED, "ChineseSimplified", "zh-CN", "Simhei", 2052),
			new structLocale(enumLocale.LOCALE_CHINESETRADITIONAL, "ChineseTraditional", "zh-CHT", "Simhei", 1028),
			new structLocale(enumLocale.LOCALE_FRENCH, "French", "fr-FR", "Arial", 1036),
			new structLocale(enumLocale.LOCALE_GERMAN, "German", "de-DE", "Arial", 1031),
			new structLocale(enumLocale.LOCALE_KOREAN, "Korean", "ko-KR", "", 1042),
			new structLocale(enumLocale.LOCALE_JAPANESE, "Japanese", "ja-JP", "", 1041),
			new structLocale(enumLocale.LOCALE_RUSSIAN, "Russian", "ru-RU", "", 1049),
			new structLocale(enumLocale.LOCALE_SPANISH, "Spanish", "es-ES", "", 1034),
			new structLocale(enumLocale.LOCALE_PORTUGUESE, "Portuguese", "pt-BR", "", 1046)
		});

		private const short LANGUAGE_DEFAULT = 1033;

		private static CLocalize instance = null;

		private static CultureInfo m_Culture = null;

		private static structLocale m_currentLocale = default(structLocale);

		[DllImport("kernel32.dll")]
		public static extern short GetSystemDefaultLangID();

		private CLocalize()
		{
			short systemDefaultLangID = GetSystemDefaultLangID();
			structLocale localeInfo = getLocaleInfo(systemDefaultLangID);
			if (localeInfo.LanguageKey == 0)
			{
				m_currentLocale = LocaleArray[0];
			}
			else
			{
				m_currentLocale = localeInfo;
			}
			setCulture(m_currentLocale.Resource);
		}

		private bool setCulture(string userCulture)
		{
			try
			{
				m_Culture = new CultureInfo(userCulture);
			}
			catch (Exception)
			{
				return false;
			}
			return true;
		}

		public CultureInfo getCulture()
		{
			return m_Culture;
		}

		public static CLocalize getInstance()
		{
			if (instance == null)
			{
				instance = new CLocalize();
			}
			return instance;
		}

		private structLocale getLocaleInfo(short language)
		{
			structLocale result = default(structLocale);
			byte[] bytes = BitConverter.GetBytes(language);
			int num = LocaleArray.Count();
			for (int i = 0; i < num; i++)
			{
				byte[] bytes2 = BitConverter.GetBytes(LocaleArray[i].LanguageKey);
				if (bytes[0] == bytes2[0])
				{
					result = ((bytes[0] != 4) ? LocaleArray[i] : ((bytes[1] != 4 && bytes[1] != 12) ? LocaleArray[1] : LocaleArray[2]));
				}
			}
			return result;
		}
	}
}
