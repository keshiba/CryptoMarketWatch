using System.Text.Json.Serialization;

namespace CryptoWatch.Models.Response
{
    public class CoinData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("block_time_in_minutes")]
        public string BlockTimeInMinutes { get; set; }

        [JsonPropertyName("image")]
        public Dictionary<string, string> Image { get; set; }

        [JsonPropertyName("market_data")]
        public dynamic MarketData { get; set; }
    }
}