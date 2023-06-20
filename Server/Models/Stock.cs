using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proj_APBD.Server.Models;

[Table(nameof(Stock))]
public class Stock
{
    [Key, MaxLength(10)] 
    public string Ticker { get; set; } = null!;
    
    public virtual ICollection<UserStock> UserStocks { get; set; }  = null!;
}