using Microsoft.EntityFrameworkCore;
using Proj_APBD.Server.Models;

namespace Proj_APBD.Server.Contexts;

public class Context : DbContext
{
    public Context(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<UserStock> UserStocks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var admin = new User()
        {
            Id = Guid.NewGuid(),
            Username = "Admin",
            Password = "AQAAAAIAAYagAAAAEEJO4LuCMB1w3MPT/+ZpuSIsBse2HRuBfi01fS3Wnk9dlahVlaPT52diyojD3QsN7g==",
        };
        
        modelBuilder.Entity<User>().HasData(new List<User>()
        {
            admin
        });
    }
}