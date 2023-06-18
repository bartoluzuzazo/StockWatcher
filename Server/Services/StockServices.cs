using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models.DTOs;
using Proj_APBD.Shared.Services;

namespace Proj_APBD.Server.Services;

public class StockServices : IStockServices
{
    public async Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker)
    {
        var url =
            $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/0/{DateTime.Now.AddDays(-1).ToString("yyy-MM-dd")}?adjusted=true&sort=asc&limit=50000&apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a";
        Console.WriteLine(url);
        var response = await GetJsonParser<PolygonResponse>.Parse(url);
        return response;
    }
}