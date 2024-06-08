using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class PartnerRepository(AppDbContext dbContext)
    : Repository<Partner>(dbContext), IPartnerRepository
{
    public async Task<List<Partner>> GetByNameAsync(string name)
    {
        var partners = await _dbContext.Partners.ToListAsync();
        var filteredPartners = partners.Where(p => p.Name.ToLower()
                                                  .Contains(name.ToLower()))
                                                  .ToList();
        
        partners.Clear(); // Save/cleare memory
        return filteredPartners;
    }
}