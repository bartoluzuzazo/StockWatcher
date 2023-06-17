using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models.DTOs;
using Proj_APBD.Shared.Services;

namespace Proj_APBD.Server.Services;

public class StockServices : IStockServices
{
    public async Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker)
    {
        var url =
            $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/2023-01-01/2023-01-09?adjusted=true&sort=asc&limit=120&apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a";
        var response = await GetJsonParser<PolygonResponse>.Parse(url);
        return response;
    }
}