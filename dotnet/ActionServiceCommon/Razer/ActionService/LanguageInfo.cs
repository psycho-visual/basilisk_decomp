using System.Globalization;

namespace Razer.ActionService
{
	public class LanguageInfo
	{
		public Languages Language { get; private set; }

		public string LanguageKey
		{
			get
			{
				string text = "en-US";
				switch (Language)
				{
				case Languages.Undefined:
					return string.Empty;
				case Languages.English:
					return "en-US";
				case Languages.Chinese_Simplified:
					return "zh-CN";
				case Languages.Chinese_Traditional:
					return "zh-CHT";
				case Languages.French:
					return "fr-FR";
				case Languages.Korean:
					return "ko-KR";
				case Languages.Japanese:
					return "ja-JP";
				case Languages.German:
					return "de-DE";
				case Languages.Russian:
					return "ru-RU";
				case Languages.Spanish:
					return "es-ES";
				case Languages.Portuguese:
					return "pt-BR";
				default:
					return string.Empty;
				}
			}
		}

		public string CopLanguage
		{
			get
			{
				string empty = string.Empty;
				switch (Language)
				{
				case Languages.Undefined:
					return string.Empty;
				case Languages.English:
					return "en";
				case Languages.Chinese_Simplified:
					return "zh-CN";
				case Languages.Chinese_Traditional:
					return "zh-TW";
				case Languages.French:
					return "fr";
				case Languages.Korean:
					return "kr";
				case Languages.Japanese:
					return "ja";
				case Languages.German:
					return "de";
				case Languages.Russian:
					return "ru";
				case Languages.Spanish:
					return "es-ES";
				case Languages.Portuguese:
					return "pt-BR";
				default:
					return string.Empty;
				}
			}
		}

		public LanguageInfo(Languages language)
		{
			Language = language;
		}

		public override string ToString()
		{
			return $"LanguageInfo: \"LanguageKey\"=\"{LanguageKey}\", \"CopLanguage\"=\"{CopLanguage}\"";
		}

		public static Languages GetLanguage(CultureInfo cultureInfo)
		{
			return GetLanguage(cultureInfo.Name);
		}

		public static Languages GetLanguage(string name)
		{
			if (string.IsNullOrEmpty(name))
			{
				return Languages.English;
			}
			switch (name)
			{
			case "en-US":
				return Languages.English;
			case "zh-CN":
				return Languages.Chinese_Simplified;
			case "zh-CHT":
				return Languages.Chinese_Traditional;
			case "zh-TW":
				return Languages.Chinese_Traditional;
			case "de-DE":
				return Languages.German;
			case "fr-FR":
				return Languages.French;
			case "ko-KR":
				return Languages.Korean;
			case "es-ES":
				return Languages.Spanish;
			case "ja-JP":
				return Languages.Japanese;
			case "ru-RU":
				return Languages.Russian;
			case "pt-BR":
				return Languages.Portuguese;
			default:
				return Languages.English;
			}
		}
	}
}
