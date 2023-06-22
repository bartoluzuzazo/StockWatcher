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
    public async Task<IActionResult> GetStockChartData(string ticker)
    {
        var response = await _stockServices.GetStockPriceOnlineAsync(ticker);
        if (response is null) return NotFound();
        return Ok(response);
    }

    [HttpPost("watch/{ticker}")]
    public async Task<IActionResult> AddStockToWatchlist(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var stock = await _stockServices.GetOrAddStockAsync(ticker);
        await _stockServices.AddToWatchlistAsync(user, stock);
        await _stockServices.SaveChangesAsync();
        return Created("", stock.Ticker);
    }

    [HttpDelete("watch/{ticker}")]
    public async Task<IActionResult> RemoveStockFromWatchlist(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var stock = await _stockServices.GetOrAddStockAsync(ticker);
        await _stockServices.RemoveFromWatchlistAsync(user, stock);
        await _stockServices.RemoveStockIfNotWatchedAsync(stock);
        await _stockServices.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("watch/{ticker}")]
    public async Task<IActionResult> IsStockWatched(string ticker)
    {
        var user = await _accountServices.GetUserAsync(User);
        var response = await _stockServices.IsStockWatchedAsync(user, ticker);
        return Ok(response);
    }

    [HttpGet("watched")]
    public async Task<IActionResult> GetWatchedStocks()
    {
        var user = await _accountServices.GetUserAsync(User);
        var response = await _stockServices.GetWatchedStocks(user);
        return Ok(response);
    }

    [HttpGet("data/{ticker}")]
    public async Task<IActionResult> GetStockData(string ticker)
    {
        return Ok(await _stockServices.GetOrAddStockAsync(ticker));
    }
}