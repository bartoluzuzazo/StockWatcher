using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Proj_APBD.Server.Models;

[PrimaryKey(nameof(UserId), nameof(StockTicker)), Table("User_Stock")]
public class UserStock
{
    public Guid UserId { get; set; }
    
    public string StockTicker { get; set; }
    
    [ForeignKey(nameof(StockTicker))]
    public virtual Stock Stock { get; set; } = null!;
    
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }  = null!;
}