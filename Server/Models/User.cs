using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj_APBD.Server.Models;

[Table(nameof(User))]
public class User
{
    [Key]
    public Guid Id { get; set; }
    
    [Required, MaxLength(50)]
    public string Username { get; set; } = null!;
    
    [Required, MaxLength(300)]
    public string Password { get; set; } = null!;

    // public virtual ICollection<Stock> Stocks { get; set; } = null!;
}