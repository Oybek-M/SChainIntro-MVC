using SChainIntro_MVC.Data.Entities;
using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Enums;


namespace SChainIntro_MVC.Data;


public class AppDbContext(DbContextOptions<AppDbContext> options)
    : DbContext(options)
{
    public DbSet<Partner> Partners { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Video> Videos { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Static> Static { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User
            {
                ID = 1,
                ImagePath = ".\\wwwroot\\StaticFiles\\admin.png",
                FName = "Full",
                LName = "Owner",
                Email = "owner@gmail.com",
                Password = "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", // '2007yil04'
                UserRole = Role.Owner,
                Gender = Gender.Male,
                IsTeam = true,
                TeamType = "Owner/CEO",
                IsActive = true 
            });
    }
}