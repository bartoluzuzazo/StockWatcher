namespace Proj_APBD.Client.Models.DTOs;

public class StockSearchResultsDTO
{
    public List<StockSearchDTO> results { get; set; } = null!;
    public string? next_url { get; set; } = null!;
}