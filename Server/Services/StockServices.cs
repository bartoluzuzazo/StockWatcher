using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models.DTOs;
using Proj_APBD.Shared.Services;

namespace Proj_APBD.Server.Services;

public class StockServices : IStockServices
{
    public async Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker)
    {
        var url =
            $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/2022-06-18/2023-06-18?adjusted=true&sort=asc&limit=120&apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a";
        var response = await GetJsonParser<PolygonResponse>.Parse(url);
        return response;
    }
}