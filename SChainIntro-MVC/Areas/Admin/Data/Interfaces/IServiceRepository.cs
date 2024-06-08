using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.Data.Interfaces;

public interface IServiceRepository : IRepository<Service>
{
    Task<List<Service>> GetByTitleAsync(string title);
}