using SChainIntro_MVC.BLL.DTOs.ServiceDtos;


namespace SChainIntro_MVC.BLL.Interfaces;


public interface IServiceService
{
    Task<List<ServiceDto>> GetAllAsync();
    Task<ServiceDto> GetByIdAsync(int id);
    Task CreateAsync(AddServiceDto addServiceDto);
    Task UpdateAsync(UpdateServiceDto updateServiceDto);
    Task DeleteAsync(int id);
}