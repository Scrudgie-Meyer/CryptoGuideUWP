using CryptoGuideUWP.HelpTools;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace CryptoGuideUWP.Model
{
    [DataContract]
    public class CurrencyTableObject
    {
        [DataMember(Name = "id")]
        public string id { get; set; }


        [DataMember(Name = "rank")]
        public int rank { get; set; }


        [DataMember(Name = "symbol")]
        public string symbol { get; set; }


        [DataMember(Name = "name")]
        public string name { get; set; }


        [DataMember(Name = "marketCapUsd")]
        [JsonProperty("marketCapUsd")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? marketCapUsd { get; set; }


        [DataMember(Name = "volumeUsd24Hr")]
        [JsonProperty("volumeUsd24Hr")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? volumeUsd24Hr { get; set; }


        [DataMember(Name = "priceUSD")]
        [JsonProperty("priceUSD")]
        [JsonConverter(typeof(RoundedDecimalConverter))]
        public decimal? priceUSD { get; set; }
    }
}
