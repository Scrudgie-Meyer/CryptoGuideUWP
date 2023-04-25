﻿
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage.Streams;

namespace CryptoGuideUWP.Model
{
    public static class CustomJSONparser
    {
        public static List<Currency> GetCurrencies()
        {
            string apiUrl = "https://api.coincap.io/v2/assets";

            using (var client = new HttpClient())
            {
                // Set the headers and make the request
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                var response = client.GetAsync(apiUrl).Result;

                // If the request was successful, parse the response
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = response.Content.ReadAsStringAsync().Result;
                    var jsonObject = JObject.Parse(responseBody);
                    var currencies = jsonObject["data"].ToObject<List<Currency>>();

                    return currencies;
                }
                else
                {
                    throw new Exception($"Failed to get currencies from {apiUrl}. StatusCode: {response.StatusCode}");
                }
            }
        }
    }
}
