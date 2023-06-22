using Microsoft.EntityFrameworkCore;
using Proj_APBD.Client.Models.DTOs;
using Proj_APBD.Server.Contexts;
using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models;
using Proj_APBD.Server.Models.DTOs;
using Proj_APBD.Shared.Models.DTOs;
using Proj_APBD.Shared.Services;

namespace Proj_APBD.Server.Services;

public class StockServices : IStockServices
{
    private readonly Context _context;

    public StockServices(Context context)
    {
        _context = context;
    }
    
    public async Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker)
    {
        var url = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/0/{DateTime.Now.AddDays(-1):yyy-MM-dd}?adjusted=true&sort=asc&limit=50000&apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a";
        var response = await GetJsonParser<PolygonResponse>.Parse(url);
        return response;
    }

    public async Task AddToWatchlistAsync(User user, Stock stock)
    {
        await _context.UserStocks.AddAsync(new UserStock()
        {
            StockTicker = stock.Ticker,
            UserId = user.Id,
            AddedAt = DateTime.Now
        });
    }
    
    public async Task RemoveFromWatchlistAsync(User user, Stock stock)
    {
        var association = await _context.UserStocks.FirstOrDefaultAsync(us => us.UserId == user.Id && us.StockTicker == stock.Ticker);

        if (association is not null)
        {
            _context.UserStocks.Remove(association);
        }
    }

    public async Task RemoveStockIfNotWatchedAsync(Stock stock)
    {
        var stockInstances = await _context.UserStocks.CountAsync(us => us.StockTicker == stock.Ticker);
        if (stockInstances == 0)
        {
            _context.Stocks.Remove(stock);
        }
    }

    public async Task<Stock> GetOrAddStockAsync(string ticker)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Ticker == ticker);

        if (stock is null)
        {
            var dto = await GetJsonParser<PolygonTickerDetailsDTO>.Parse($"https://api.polygon.io/v3/reference/tickers/{ticker}?apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a");
            stock = new Stock()
            {
                Ticker = ticker,
                Name = dto.results.name,
                Country = dto.results.locale.ToUpper(),
                Sector = dto.results.sic_description,
                LogoUrl = dto.results.branding.icon_url + "?apiKey=HGcdymSzKJINAJplybiYm7S6bVrcSe3a"
            };
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
        }
        return stock;
    }

    public async Task<bool> IsStockWatchedAsync(User user, string ticker)
    {
        return await _context.UserStocks.FirstOrDefaultAsync(us => us.StockTicker == ticker && us.UserId == user.Id) is not null;
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<StockDataDTO>> GetWatchedStocks(User user)
    {
        return await _context.UserStocks.Where(us => us.User.Username == user.Username).Select(us => new StockDataDTO()
        {
            Ticker = us.Stock.Ticker,
            Name = us.Stock.Name,
            Country = us.Stock.Country,
            Sector = us.Stock.Sector,
            LogoUrl = us.Stock.LogoUrl
        }).ToListAsync();
    }
}