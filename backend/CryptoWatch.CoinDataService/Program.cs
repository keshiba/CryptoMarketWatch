using CryptoWatch.CoinDataService.Services;

namespace CryptoWatch.WebApi
{
    public class Program
    {
        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddGrpc();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            app.MapGrpcService<CoinDataFetcherService>();
            app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

            app.Run();
        }
    }
}
