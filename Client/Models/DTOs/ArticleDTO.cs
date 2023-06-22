using Proj_APBD.Client.Models.DTOs;

namespace Proj_APBD.Client.Models;

public class ArticleDTO
{
    public string title { get; set; } = null!;
    public ArticlePublisherDTO publisher { get; set; } = null!;
    public string author { get; set; } = null!;
    public DateTime published_utc { get; set; }
    public string amp_url { get; set; } = null!;
    public string image_url { get; set; } = null!;
    public string description { get; set; } = null!;
}