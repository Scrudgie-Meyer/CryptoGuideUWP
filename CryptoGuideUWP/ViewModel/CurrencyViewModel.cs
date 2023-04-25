using CryptoGuideUWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoGuideUWP.View
{
    public class CurrencyViewModel
    {
        public List<Currency> currencies=null;

        public CurrencyViewModel() 
        {
            currencies = CustomJSONparser.GetCurrencies();
        }
    }
}
