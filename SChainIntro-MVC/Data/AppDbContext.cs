using Microsoft.EntityFrameworkCore;

namespace SChainIntro_MVC.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
}