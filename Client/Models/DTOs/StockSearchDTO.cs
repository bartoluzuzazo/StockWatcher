namespace Proj_APBD.Client.Models.DTOs;

public class StockSearchDTO
{
    public string ticker { get; set; } = null!;
    public string name { get; set; } = null!;
    public string market{ get; set; } = null!;
    public string primary_exchange{ get; set; } = null!;
}