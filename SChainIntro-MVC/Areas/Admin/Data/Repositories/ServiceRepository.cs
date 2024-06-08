using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class ServiceRepository(AppDbContext dbContext)
    : Repository<Service>(dbContext), IServiceRepository
{
    public async Task<List<Service>> GetByTitleAsync(string title)
    {
        var services = await _dbContext.Services.ToListAsync();
        var filteredServices = services.Where(s => s.Title.ToLower()
                                          .ToLower().Contains(title.ToLower()))
                                          .ToList();
        
        services.Clear(); // Save/clean memory
        return filteredServices;
    }
}