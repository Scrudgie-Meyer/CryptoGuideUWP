using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.WebSockets;
using System.Text;
public class Currency
{
    public string id { get; set; }
    public int rank { get; set; }
    public string symbol { get; set; }
    public string name { get; set; }
    public double supply { get; set; }
    public double? maxSupply { get; set; }
    public double marketCapUsd { get; set; }
    public double volumeUsd24Hr { get; set; }
    public double priceUSD { get; set; }
    public double changePercent24Hr { get; set; }
    public double? vwap24Hr { get; set; }

}


public static class Program
{
    public static async Task<List<Currency>> GetCurrenciesSocket()
    {
        string socketUrl = "wss://api.coincap.io/v2/assets";

        using (var socket = new ClientWebSocket())
        {
            // Connect to the WebSocket
            await socket.ConnectAsync(new Uri(socketUrl), CancellationToken.None);

            // Send a message to the WebSocket to subscribe to currency prices
            var message = new { method = "subscribe", channel = "prices", options = new { exchange = "CoinCap" } };
            var messageJson = JsonConvert.SerializeObject(message);
            var messageBytes = Encoding.UTF8.GetBytes(messageJson);
            await socket.SendAsync(new ArraySegment<byte>(messageBytes), WebSocketMessageType.Text, true, CancellationToken.None);

            // Create a buffer to receive messages from the WebSocket
            var buffer = new byte[1024 * 4];

            // Read messages from the WebSocket until the connection is closed
            var currencies = new List<Currency>();
            while (socket.State == WebSocketState.Open)
            {
                var result = await socket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);

                if (result.MessageType == WebSocketMessageType.Text)
                {
                    var json = Encoding.UTF8.GetString(buffer, 0, result.Count);
                    var prices = JObject.Parse(json);
                    foreach (var pair in prices)
                    {
                        var currency = new Currency
                        {
                            id = pair.Key,
                            priceUSD = (double)pair.Value
                        };
                        currencies.Add(currency);
                    }
                }
                else if (result.MessageType == WebSocketMessageType.Close)
                {
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, "", CancellationToken.None);
                }
            }

            return currencies;
        }
    }
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
    public static async void Test()
    {
        var curr=GetCurrencies();
        Console.WriteLine(curr[0].name);
    }
    public static void Main(string[] args)
    {
        Test();
    }
}
