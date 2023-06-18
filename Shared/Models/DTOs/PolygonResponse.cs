namespace Proj_APBD.Server.Models.DTOs;

public class PolygonResponse
{
    public string ticker { get; set; }
    public int queryCount { get; set; }
    public int resultsCount { get; set; }
    public bool adjusted { get; set; }
    public List<PolygonStock> results { get; set; }
    public string status { get; set; }
    public string request_Id { get; set; }
    public int count { get; set; }
}