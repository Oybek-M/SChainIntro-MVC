using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class StaticRepository(AppDbContext dbContext)
    : Repository<Service>(dbContext), IStaticRepository
{
    public async Task<Static> GetAsync()
    {
        var res = await _dbContext.Static.FirstOrDefaultAsync();
        return res;
    }
}