using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CryptoWatch.Models.DataContracts.Response
{
    /// <summary>
    /// CoinDetails represents the data model that
    /// the API uses to return data out to the world
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
