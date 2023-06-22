namespace Proj_APBD.Shared.Models.DTOs;

public class StockDataDTO
{
    public string Ticker { get; set; } = null!;

    public string Name { get; set; } = null!;
    
    public string LogoUrl { get; set; } = null!;
    
    public string Country { get; set; } = null!;
    
    public string Sector { get; set; } = null!;
}