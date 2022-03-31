using CryptoWatch.Models.DataContracts.Response;
using CryptoWatch.WebApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace CryptoWatch.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        private readonly ILogger<CoinController> _logger;
        private readonly ICoinDataProvider _coinDataProvider;

        public CoinController(ILogger<CoinController> logger, ICoinDataProvider coinDataProvider)
        {
            this._logger = logger;
            this._coinDataProvider = coinDataProvider;
        }

        // GET: api/<CoinController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var coinDetails = await this._coinDataProvider.GetAllCoinDetails();

                if (coinDetails.Any() == false)
                {
                    var error = new CoinQueryError("No coin data available");
                    return new JsonResult(error);
                }

                var coinDetailsCollection = 
                    coinDetails.Take(20).Select(coinData =>
                        new CoinDetails(id: coinData.Id, symbol: coinData.Name, name: coinData.Symbol)
                    );

                return new JsonResult(coinDetailsCollection);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurred while fetching all coin details");

                var errorResponse = new CoinQueryError("An error occurred");

                return new JsonResult(errorResponse);
            }
        }

        // GET api/<CoinController>/bitcoin
        [HttpGet("{coinId}")]
        public async Task<IActionResult> Get(string coinId)
        {
            try
            {
                var coinDetails = await this._coinDataProvider.GetCoinDetailsById(coinId);

                if (coinDetails.Any() == false)
                {
                    var error = new CoinQueryError("Coin data unavailable");
                    return new JsonResult(error);
                }

                var coinData = coinDetails.First();
                var response = new CoinDetails(id: coinData.Id, symbol: coinData.Name, name: coinData.Symbol);

                return new JsonResult(response);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, "Exception occurred fething coin data for coin {0}", coinId);

                var errorResponse = new CoinQueryError("An error occurred");

                return new JsonResult(errorResponse);
            }
        }
    }
}
