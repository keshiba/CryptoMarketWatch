using CryptoWatch.WebApi.Data;

namespace CryptoWatch.WebApi
{
    public static class Bootstrap
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ICoinDataProvider, CoinDataProvider>();
        }
    }
}
