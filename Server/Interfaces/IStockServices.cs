using Proj_APBD.Server.Models;
using Proj_APBD.Server.Models.DTOs;
using Proj_APBD.Shared.Models.DTOs;

namespace Proj_APBD.Server.Interfaces;

public interface IStockServices
{
    public Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker);
    public Task<Stock> GetOrAddStockAsync(string ticker);
    public Task SaveChangesAsync();
    public Task AddToWatchlistAsync(User user, Stock stock);
    public Task RemoveFromWatchlistAsync(User user, Stock stock);
    public Task RemoveStockIfNotWatchedAsync(Stock stock);
    public Task<bool> IsStockWatchedAsync(User user, string ticker);
    public Task<List<StockDataDTO>> GetWatchedStocks(User user);
}