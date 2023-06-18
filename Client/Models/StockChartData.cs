namespace Proj_APBD.Server.Models;

public class StockChartData
{
    public DateTime date { get; set; }
    public double open { get; set; }
    public double low { get; set; }
    public double close { get; set; }
    public double high { get; set; }
    public double volume { get; set; }
}