using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proj_APBD.Server.Interfaces;

namespace Proj_APBD.Server.Controllers;

[Route("api/[controller]")]
[Authorize]
public class StocksController : ControllerBase
{
    private readonly IStockServices _stockServices;

    public StocksController(IStockServices stockServices)
    {
        _stockServices = stockServices;
    }
        
    [HttpGet]
    public async Task<IActionResult> GetStockData(string ticker)
    {
        var response = await _stockServices.GetStockPriceOnlineAsync(ticker);
        if (response is null) return NotFound();
        return Ok(response);
    }
}