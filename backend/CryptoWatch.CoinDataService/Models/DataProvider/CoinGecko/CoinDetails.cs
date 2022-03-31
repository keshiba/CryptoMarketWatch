using System.Text.Json.Serialization;

namespace CryptoWatch.CoinDataService.Models.DataProvider.CoinGecko
{
    /// <summary>
    /// CoinDetails class represents the data model returned by the 
    /// CoinGecko data provider
    /// </summary>
    public class CoinDetails
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        public CoinDetails(string id, string symbol, string name)
        {
            this.Id = id;
            this.Symbol = symbol;
            this.Name = name;
        }
    }
}