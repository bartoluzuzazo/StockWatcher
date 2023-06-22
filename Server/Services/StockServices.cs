using Microsoft.EntityFrameworkCore;
using Proj_APBD.Server.Contexts;
using Proj_APBD.Server.Interfaces;
using Proj_APBD.Server.Models;
using Proj_APBD.Server.Models.DTOs;
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

    public async Task AddToWatchlist(User user, Stock stock)
    {
        await _context.UserStocks.AddAsync(new UserStock()
        {
            StockTicker = stock.Ticker,
            UserId = user.Id
        });
    }
    
    public async Task RemoveFromWatchlist(User user, Stock stock)
    {
        var association = await _context.UserStocks.FirstOrDefaultAsync(us => us.UserId == user.Id && us.StockTicker == stock.Ticker);

        if (association is not null)
        {
            _context.UserStocks.Remove(association);
        }
    }

    public async Task RemoveStockIfNotWatched(Stock stock)
    {
        var stockInstances = await _context.UserStocks.CountAsync(us => us.StockTicker == stock.Ticker);
        if (stockInstances == 0)
        {
            _context.Stocks.Remove(stock);
        }
    }

    public async Task<bool> StockExists(string ticker)
    {
        return await _context.Stocks.FirstOrDefaultAsync(s => s.Ticker == ticker) is not null;
    }
    
    public async Task<Stock> GetOrAddStock(string ticker)
    {
        var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Ticker == ticker);

        if (stock is null)
        {
            stock = new Stock()
            {
                Ticker = ticker
            };
            await _context.Stocks.AddAsync(stock);
        }
        return stock;
    }

    public async Task<bool> IsStockWatched(User user, string ticker)
    {
        return await _context.UserStocks.FirstOrDefaultAsync(us => us.StockTicker == ticker && us.UserId == user.Id) is not null;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<List<string>> GetWatchedStocks(User user)
    {
        return await _context.UserStocks.Where(us => us.User.Username == user.Username).Select(us => us.StockTicker).ToListAsync();
    }
}