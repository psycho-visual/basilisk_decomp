using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Razer.AccountManager
{
	internal sealed class IpConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(IPAddress);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (string.IsNullOrEmpty((string)reader.Value))
			{
				return null;
			}
			return IPAddress.Parse((string)reader.Value);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			JToken.FromObject((object)value.ToString()).WriteTo(writer, (JsonConverter[])(object)new JsonConverter[0]);
		}
	}
}
