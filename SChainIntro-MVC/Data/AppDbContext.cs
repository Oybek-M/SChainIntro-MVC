using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Statics> Statics { get; set; }
    public DbSet<AboutUs> Aboutus { get; set; }
    public DbSet<OurService> OurServices { get; set; }
    public DbSet<Video> Videos { get; set; }
}