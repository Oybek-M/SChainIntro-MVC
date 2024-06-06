using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.Data.Interfaces;

public interface IStaticRepository : IRepository<Static>
{
    Task<Static> GetAsync();
}