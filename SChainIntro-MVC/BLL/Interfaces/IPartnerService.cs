using SChainIntro_MVC.BLL.DTOs.PartnerDtos;

namespace SChainIntro_MVC.BLL.Interfaces;

public interface IPartnerService
{
    Task<List<PartnerDto>> GetAllAsync();
    Task<PartnerDto> GetByIdAsync(int id);
    Task<List<string>> GetAllImagesAsync(); // Get All Partners Image
    Task<string> GetImageAsync(int id); // Get Partner`s Image
    Task CreateAsync(AddPartnerDto addPartnerDto);
    Task UpdateAsync(UpdatePartnerDto updatePartnerDto);
    Task DeleteAsync(int id);
}
