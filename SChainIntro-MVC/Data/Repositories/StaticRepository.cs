using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class StaticRepository(AppDbContext dbContext)
    : Repository<Static>(dbContext), IStaticRepository
{
    public async Task<Static> GetAsync()
    {
        return await _dbContext.Static.SingleOrDefaultAsync();
    }
}