using System.Runtime.Serialization;

namespace CryptoGuideUWP.Model
{
    [DataContract]
    public class CurrencyChartObject
    {
        [DataMember(Name = "priceUsd")]
        public string priceUsd { get; set; }


        [DataMember(Name = "time")]
        public long time { get; set; }


        [DataMember(Name = "date")]
        public string date { get; set; }
    }
}
