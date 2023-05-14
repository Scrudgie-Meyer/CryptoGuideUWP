using CryptoGuideUWP.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CryptoGuideUWP.HelpTools
{
    internal static class RequestAPI
    {
        public static string CurrencyTableData()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";

            var responseBody = ClientConnection(apiUrl);
            return responseBody;
        }
        public static string CurrencyChartData(string id)
        {
            string apiUrl = $"https://api.coincap.io/v2/assets/{id}/history?interval=d1";
            var responseBody = ClientConnection(apiUrl);
            return responseBody;
        }
        public static string CurrencyObjectData(string id)
        {
            string apiUrl = $"https://api.coincap.io/v2/markets?baseId={id}&quoteSymbol=USD&limit=6";
            var responseBody = ClientConnection(apiUrl);
            return responseBody;
        }


        private static string ClientConnection(string apiUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    return responseBody;
                }
                else
                {
                    throw new Exception($"Failed to get currencies from {apiUrl}. StatusCode: {response.StatusCode}");
                }
            }
        }
    }
}
