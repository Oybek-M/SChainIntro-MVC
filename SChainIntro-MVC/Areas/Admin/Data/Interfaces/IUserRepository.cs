using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.Data.Interfaces;


public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
}