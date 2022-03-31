
namespace CryptoWatch.WebApi.Models
{
    public class CoinDetails
    {
        public string Id { get; set; }

        public string Symbol { get; set; }

        public string Name { get; set; }

        public CoinDetails(string id, string symbol, string name)
        {
            this.Id = id;
            this.Symbol = symbol;
            this.Name = name;
        }
    }
}
