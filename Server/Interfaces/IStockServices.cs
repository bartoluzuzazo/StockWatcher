using Proj_APBD.Server.Models;
using Proj_APBD.Server.Models.DTOs;

namespace Proj_APBD.Server.Interfaces;

public interface IStockServices
{
    public Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker);
    public Task<bool> StockExists(string ticker);
    public Task<Stock> GetOrAddStock(string ticker);
    public Task SaveChanges();
    public Task AddToWatchlist(User user, Stock stock);
    public Task RemoveFromWatchlist(User user, Stock stock);
    public Task RemoveStockIfNotWatched(Stock stock);
    public Task<bool> IsStockWatched(User user, string ticker);
    public Task<List<string>> GetWatchedStocks(User user);

}