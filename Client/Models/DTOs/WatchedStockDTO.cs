namespace Proj_APBD.Client.Models.DTOs;

public class WatchedStockDTO
{
    public string ticker { get; set; }
    public string name { get; set; }
    public string locale { get; set; }
    public string sic_description { get; set; }
    public PolygonTickerDetailsIconDTO branding { get; set; }
}