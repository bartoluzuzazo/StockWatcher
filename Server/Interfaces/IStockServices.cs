using Proj_APBD.Server.Models.DTOs;

namespace Proj_APBD.Server.Interfaces;

public interface IStockServices
{
    public Task<PolygonResponse?> GetStockPriceOnlineAsync(string ticker);
}