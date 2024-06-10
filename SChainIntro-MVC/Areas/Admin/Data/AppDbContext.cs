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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(new User
        {
            ID = 1,
            ImagePath = ".\\wwwroot\\StaticFiles\\admin.png",
            FName = "Super",
            LName = "Admin",
            Email = "superadmin@gmail.com",
            Password = "240BE518FABD2724DDB6F04EEB1DA5967448D7E831C08C8FA822809F74C720A9", // 'admin123'
            UserRole = Role.SuperAdmin,
            IsTeam = true,
            TeamType = "SuperAdmin",
            IsActive = true
        });
    }
}
