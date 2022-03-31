using CryptoWatch.CoinDataService;
using CryptoWatch.WebApi.Models;
using Grpc.Net.Client;
using System.Text.Json;

namespace CryptoWatch.WebApi.Data
{
    public class CoinDataProvider : ICoinDataProvider
    {
        private readonly IConfiguration _configuration;

        public CoinDataProvider(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<IEnumerable<CoinDetails>> GetAllCoinDetails()
        {
            var rpcClient = GetCoinDataServiceClient();
            var reply = await rpcClient.GetAllCoinsAsync(new CoinDataAllModel());

            if (reply.IsFound == false)
            {
                return Enumerable.Empty<CoinDetails>();
            }

            var coinDetailsCollection = 
                reply.Data.Select(coinData =>
                    new CoinDetails(id: coinData.Id, symbol: coinData.Name, name: coinData.Symbol)
                );

            return coinDetailsCollection;
        }

        public async Task<IEnumerable<CoinDetails>> GetCoinDetailsById(string coinId)
        {
            var rpcClient = GetCoinDataServiceClient();
            var reply = await rpcClient.GetCoinDataByIdAsync(new CoinDataLookupByIdModel
            {
                Id = coinId
            });

            if (reply.IsFound == false)
            {
                return Enumerable.Empty<CoinDetails>();
            }

            var coinDetailsCollection = 
                reply.Data.Select(coinData =>
                    new CoinDetails(id: coinData.Id, symbol: coinData.Name, name: coinData.Symbol)
                );

            return coinDetailsCollection;
        }

        public async Task<IEnumerable<CoinDetails>> GetCoinDetailsByName(string coinName)
        {
            var rpcClient = GetCoinDataServiceClient();
            var reply = await rpcClient.GetCoinDataByNameAsync(new CoinDataLookupByNameModel
            {
                Name = coinName
            });

            if (reply.IsFound == false)
            {
                return Enumerable.Empty<CoinDetails>();
            }

            var coinDetailsCollection = 
                reply.Data.Select(coinData =>
                    new CoinDetails(id: coinData.Id, symbol: coinData.Name, name: coinData.Symbol)
                );

            return coinDetailsCollection;
        }

        private CoinDataFetcher.CoinDataFetcherClient GetCoinDataServiceClient()
        {
            var grpcServerUrl = this._configuration.GetValue<string>("ExternalServiceURL.CoinDataServiceRPC");

            var channel = GrpcChannel.ForAddress(grpcServerUrl);
            var grpcClient = new CoinDataFetcher.CoinDataFetcherClient(channel);

            return grpcClient;
        }
    }
}
