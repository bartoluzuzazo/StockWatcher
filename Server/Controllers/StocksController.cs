using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Proj_APBD.Server.Interfaces;
using Proj_APBD.Shared.Models.DTOs;

namespace Proj_APBD.Server.Controllers;

[Authorize]
[Route("api/[controller]")]
public class StocksController : ControllerBase
{
    private readonly IStockServices _stockServices;
    private readonly IAccountServices _accountServices;

    public StocksController(IStockServices stockServices, IAccountServices accountServices)
    {
        _stockServices = stockServices;
        _accountServices = accountServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetStockData(string ticker)
    {
        var response = await _stockServices.GetStockPriceOnlineAsync(ticker);
        if (response is null) return NotFound();
        return Ok(response);
    }

    [HttpPost("watch/{ticker}")]
    public async Task<IActionResult> AddStockToWatchlist(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var stock = await _stockServices.GetOrAddStock(ticker);
        await _stockServices.AddToWatchlist(user, stock);
        await _stockServices.SaveChanges();
        return Created("", stock.Ticker);
    }

    [HttpDelete("watch/{ticker}")]
    public async Task<IActionResult> RemoveStockFromWatchlist(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var stock = await _stockServices.GetOrAddStock(ticker);
        await _stockServices.RemoveFromWatchlist(user, stock);
        await _stockServices.RemoveStockIfNotWatched(stock);
        await _stockServices.SaveChanges();
        return Ok();
    }

    [HttpGet("watch/{ticker}")]
    public async Task<IActionResult> IsStockWatched(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var response = await _stockServices.IsStockWatched(user, ticker);
        return Ok(response);
    }

    [HttpGet("watched")]
    public async Task<IActionResult> GetWatchedStocks()
    {
        var user = await _accountServices.GetUserAsync(User);
        var response = await _stockServices.GetWatchedStocks(user);
        return Ok(response);
    }
}