using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proj_APBD.Server.Models;

[Table(nameof(Stock))]
public class Stock
{
    [Key, MaxLength(10)] 
    public string Ticker { get; set; } = null!;

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;
    
    [Required, MaxLength(150)]
    public string LogoUrl { get; set; } = null!;
    
    [Required, MaxLength(50)]
    public string Country { get; set; } = null!;
    
    [Required, MaxLength(200)]
    public string Sector { get; set; } = null!;
    
    public virtual ICollection<UserStock> UserStocks { get; set; }  = null!;
}