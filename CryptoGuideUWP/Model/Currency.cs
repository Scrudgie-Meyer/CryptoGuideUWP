using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoGuideUWP.Model
{
    public class Currency
    {
        public string id { get; set; }
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public double? supply { get; set; }
        public double? maxSupply { get; set; }
        [JsonProperty("marketCapUsd")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? marketCapUsd { get; set; }
        [JsonProperty("volumeUsd24Hr")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? volumeUsd24Hr { get; set; }
        [JsonProperty("priceUSD")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? priceUSD { get; set; }
        [JsonProperty("changePercent24Hr")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? changePercent24Hr { get; set; }
        [JsonProperty("vwap24Hr")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? vwap24Hr { get; set; }

    }
    public class RoundedDecimalConverter : JsonConverter
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
