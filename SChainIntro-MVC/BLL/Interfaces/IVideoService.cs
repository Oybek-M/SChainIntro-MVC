using System.Net;
using SChainIntro_MVC.BLL.DTOs.ServiceDtos;
using SChainIntro_MVC.BLL.DTOs.VideoDtos;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Services;

public interface IVideoService
{
    Task<List<VideoDto>> GetAllAsync();
    Task<VideoDto> GetByIdAsync(int id);
    Task CreateAsync(AddVideoDto addVideoDto);
    Task UpdateAsync(UpdateServiceDto updateServiceDto);
    Task DeleteAsync(int id);
}