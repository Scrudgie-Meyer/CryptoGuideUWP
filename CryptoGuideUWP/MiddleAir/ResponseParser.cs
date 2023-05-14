using CryptoGuideUWP.HelpTools;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CryptoGuideUWP.Model
{
    public static class ResponseParser
    {
        public static List<CurrencyTableObject> CurrencyTableData()
        {
            var responseBody = RequestAPI.CurrencyTableData();
            var jsonObject = JObject.Parse(responseBody);
            var result = jsonObject["data"].ToObject<List<CurrencyTableObject>>();
            return result;
        }
        public static List<CurrencyChartObject> CurrencyChartData(string id)
        {
            var responseBody = RequestAPI.CurrencyChartData(id);
            var jsonObject = JObject.Parse(responseBody);
            var result = jsonObject["data"].ToObject<List<CurrencyChartObject>>();
            return result;
        }
        public static List<CurrencyMarketsObject> CurrencyObjectData(string id)
        {
            var responseBody = RequestAPI.CurrencyObjectData(id);
            var jsonObject = JObject.Parse(responseBody);
            var result = jsonObject["data"].ToObject<List<CurrencyMarketsObject>>();
            return result;
        }
    }
}
