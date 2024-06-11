using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;
using SChainIntro_MVC.Data.Repositories;

namespace SChainIntro_MVC.Areas.Admin.Data.Repositories;

public class StaticRepository(AppDbContext dbContext)
    : Repository<Static>(dbContext), IStaticRepository
{
    public async Task<Static> GetAsync()
    {
        var res = await _dbContext.Static.FirstOrDefaultAsync();
        return res;
    }
}