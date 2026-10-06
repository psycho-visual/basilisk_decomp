using System;
using System.ComponentModel;
using System.Linq;

namespace Razer.ActionService
{
	public static class enumExtensions
	{
		public static string GetDescription(this Enum e)
		{
			try
			{
				e.GetType();
				return (!(e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), inherit: false)
					.SingleOrDefault() is DescriptionAttribute descriptionAttribute)) ? e.ToString() : descriptionAttribute.Description;
			}
			catch
			{
				return e.ToString();
			}
		}

		public static T ParseAs<T>(this string str) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
			{
				throw new ArgumentException("T must be an enumerated type");
			}
			T[] array = (T[])Enum.GetValues(typeof(T));
			foreach (T val in array)
			{
				Enum e = (Enum)(object)val;
				if (str.Equals(e.GetDescription(), StringComparison.OrdinalIgnoreCase))
				{
					return val;
				}
			}
			return default(T);
		}
	}
}
