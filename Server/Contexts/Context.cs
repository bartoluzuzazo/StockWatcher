using Microsoft.EntityFrameworkCore;
using Proj_APBD.Server.Models;

namespace Proj_APBD.Server.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new List<User>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                Username = "Admin",
                Password = "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==",
            }
        });
    }
}