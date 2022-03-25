using CryptoWatch.Models.Response;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoinController : ControllerBase
    {
        // GET: api/<CoinController>
        [HttpGet]
        public JsonResult Get()
        {
            var coinsData = GetCoinData();

            return new JsonResult(coinsData.Take(2));
        }

        // GET api/<CoinController>/bitcoin
        [HttpGet("{coinId}")]
        public JsonResult Get(string coinId)
        {
            var coinsData = GetCoinData();

            var coinData = coinsData.Where(c => c.Id == coinId);

            return new JsonResult(coinData);
        }

        private IEnumerable<CoinData> GetCoinData()
        {
            var coinsDataStr = string.Empty;

            using(var stream = new StreamReader("content/data/coinslist.json"))
            {
                coinsDataStr = stream.ReadToEnd();
            }

            var coinsData = JsonSerializer.Deserialize<List<CoinData>>(coinsDataStr);

            return coinsData;
        }
    }
}
