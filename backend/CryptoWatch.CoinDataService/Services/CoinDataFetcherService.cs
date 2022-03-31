using DataProviderModels = CryptoWatch.CoinDataService.Models.DataProvider;
using Grpc.Core;
using System.Text.Json;

namespace CryptoWatch.CoinDataService.Services
{
    public class CoinDataFetcherService : CoinDataFetcher.CoinDataFetcherBase
    {
        private readonly ILogger<CoinDataFetcherService> _logger;

        public CoinDataFetcherService(ILogger<CoinDataFetcherService> logger)
        {
            this._logger = logger;
        }

        public override async Task<CoinDataResponseModel> GetCoinDataById(CoinDataLookupByIdModel request, ServerCallContext context)
        {
            _logger.LogInformation("GetCoinDataById invoked for id {0}", request.Id);

            var rpcResponse = new CoinDataResponseModel();
            var coinsData = await GetCoinDataAsync(id: request.Id);

            var rpcCoinModelCollection = ConstructDataModelCollection(coinsData);
            rpcResponse.IsFound = rpcCoinModelCollection.Any();
            rpcResponse.Data.AddRange(rpcCoinModelCollection);

            return rpcResponse;
        }

        public override async Task<CoinDataResponseModel> GetCoinDataByName(CoinDataLookupByNameModel request, ServerCallContext context)
        {
            _logger.LogInformation("GetCoinDataByName invoked for name {0}", request.Name);

            var coinsData = await GetCoinDataAsync(name: request.Name);
            var rpcResponse = new CoinDataResponseModel();

            var rpcCoinModelCollection = ConstructDataModelCollection(coinsData);
            rpcResponse.IsFound = rpcCoinModelCollection.Any();
            rpcResponse.Data.AddRange(rpcCoinModelCollection);

            return rpcResponse;
        }

        public override async Task<CoinDataResponseModel> GetAllCoins(CoinDataAllModel request, ServerCallContext context)
        {
            _logger.LogInformation("GetAllCoins invoked");

            var coinsData = await GetCoinDataAsync();
            var rpcResponse = new CoinDataResponseModel();

            var rpcCoinModelCollection = ConstructDataModelCollection(coinsData);
            rpcResponse.IsFound = rpcCoinModelCollection.Any();
            rpcResponse.Data.AddRange(rpcCoinModelCollection);

            return rpcResponse;
        }

        private static IEnumerable<CoinDataModel> ConstructDataModelCollection(
                IEnumerable<DataProviderModels.CoinGecko.CoinDetails> coinDetails)
        {
            foreach(var coin in coinDetails)
            {
                var rpcCoinModel = new CoinDataModel
                {
                    Id = coin.Id,
                    Name = coin.Name,
                    Symbol = coin.Symbol
                };
                
                yield return rpcCoinModel;
            }
        }

        private static async Task<IEnumerable<DataProviderModels.CoinGecko.CoinDetails>> GetCoinDataAsync(
                string? id = null, string? name = null)
        {
            var coinsDataStr = string.Empty;
            var coinsJsonFileName = "content/data/coinslist.json";

            coinsDataStr = await File.ReadAllTextAsync(coinsJsonFileName);

            IEnumerable<DataProviderModels.CoinGecko.CoinDetails> coinsData = 
                JsonSerializer.Deserialize<List<DataProviderModels.CoinGecko.CoinDetails>>(coinsDataStr);

            if (id != null)
            {
                coinsData = coinsData.Where(coin => coin.Id == id);
            }

            if (name != null)
            {
                coinsData = coinsData.Where(coin => coin.Name == name);
            }

            return coinsData;
        }
    }
}
