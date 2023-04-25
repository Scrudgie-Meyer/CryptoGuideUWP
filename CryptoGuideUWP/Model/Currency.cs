﻿using System;
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
        public double? marketCapUsd { get; set; }
        public double? volumeUsd24Hr { get; set; }
        public double? priceUSD { get; set; }
        public double? changePercent24Hr { get; set; }
        public double? vwap24Hr { get; set; }

    }
}