using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoGuideUWP.Model
{
    public class ExchangeData
    {
        public string exchangeId { get; set; }
        public string rank { get; set; }
        public string baseSymbol { get; set; }
        public string baseId { get; set; }
        public string quoteSymbol { get; set; }
        public string quoteId { get; set; }
        public decimal? priceQuote { get; set; }
        public decimal? priceUsd { get; set; }
        public decimal? volumeUsd24Hr { get; set; }
        public decimal? percentExchangeVolume { get; set; }
        public int? tradesCount24Hr { get; set; }
        public long? updated { get; set; }
    }
}
