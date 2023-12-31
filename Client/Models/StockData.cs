﻿namespace Proj_APBD.Client.Models;

public class StockData
{
    public string Ticker { get; set; } = null!;
    public string LogoUrl { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Sector { get; set; } = null!;
}