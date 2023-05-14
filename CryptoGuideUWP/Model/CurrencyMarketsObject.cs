using System.Runtime.Serialization;

namespace CryptoGuideUWP.Model
{
    [DataContract]
    public class CurrencyMarketsObject
    {
        [DataMember(Name = "exchangeId")]
        public string exchangeId { get; set; }


        [DataMember(Name = "quoteSymbol")]
        public string quoteSymbol { get; set; }


        [DataMember(Name = "priceQuote")]
        public decimal? priceQuote { get; set; }


        [DataMember(Name = "volumeUsd24Hr")]
        public decimal? volumeUsd24Hr { get; set; }


        [DataMember(Name = "tradesCount24Hr")]
        public int? tradesCount24Hr { get; set; }
    }
}
