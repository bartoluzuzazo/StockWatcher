namespace Proj_APBD.Client.Models;

public class StockSearchAutocompleteEntry
{
    public string Ticker { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public string Exchange { get; set; } = null!;
    public string Joined { get; set; } = null!;
}