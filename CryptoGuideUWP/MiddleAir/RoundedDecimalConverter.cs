using Newtonsoft.Json;
using System;

namespace CryptoGuideUWP.HelpTools
{
    internal class RoundedDecimalConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(decimal);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value == null)
            {
                return 0m;
            }

            return Math.Round(Convert.ToDecimal(reader.Value), 4, MidpointRounding.AwayFromZero);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Math.Round((decimal)value, 4, MidpointRounding.AwayFromZero));
        }
    }
}
