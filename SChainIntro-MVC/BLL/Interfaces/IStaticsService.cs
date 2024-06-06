using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Interfaces;

public interface IStaticsService
{
    Task<Static> GetAsync();
    Task<Static> UpdateAsync(Static staticThings);
}