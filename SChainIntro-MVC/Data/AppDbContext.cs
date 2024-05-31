using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<User> Users { get; set; }
}  