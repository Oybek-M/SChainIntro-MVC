using SChainIntro_MVC.BLL.DTOs.StaticDtos;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Interfaces;

public interface IStaticsService
{
    Task<Static> GetAsync();
    Task UpdateAsync(UpdateStaticDto updateStaticDto);
    Task UpdateMainAsync(UpdateAdditionalDto updateAdditionalDto, string password);
}