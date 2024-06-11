using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.Data.Interfaces;


public interface IPartnerRepository : IRepository<Partner>
{
    Task<List<Partner>> GetByNameAsync(string name);
}