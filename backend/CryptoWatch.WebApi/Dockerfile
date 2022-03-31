#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CryptoWatch.WebApi/CryptoWatch.WebApi.csproj", "CryptoWatch.WebApi/"]
COPY ["CryptoWatch.Models/CryptoWatch.Models.csproj", "CryptoWatch.Models/"]
COPY ["CryptoWatch.CoinDataService/Protos/coindata.proto", "CryptoWatch.CoinDataService/Protos/"]
RUN dotnet restore "CryptoWatch.WebApi/CryptoWatch.WebApi.csproj"
COPY . .
WORKDIR "/src/CryptoWatch.WebApi"
RUN dotnet build "CryptoWatch.WebApi.csproj" -c Development -o /app/build

FROM build AS publish
RUN dotnet publish "CryptoWatch.WebApi.csproj" -c Development -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoWatch.WebApi.dll"]