using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.Data.Repositories;


public class UserRepository(AppDbContext dbContext)
    : Repository<User>(dbContext), IUserRepository
{
    public async Task<User> GetByEmailAsync(string email)
    {
        var user =  await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        return user;
    }
}