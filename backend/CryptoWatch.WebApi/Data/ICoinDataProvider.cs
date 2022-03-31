using CryptoWatch.WebApi.Models;

namespace CryptoWatch.WebApi.Data
{
    public interface ICoinDataProvider
    {
        public Task<IEnumerable<CoinDetails>> GetAllCoinDetails();

        public Task<IEnumerable<CoinDetails>> GetCoinDetailsById(string coinId);

        public Task<IEnumerable<CoinDetails>> GetCoinDetailsByName(string coinName);
    }
}