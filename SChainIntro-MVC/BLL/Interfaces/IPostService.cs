using SChainIntro_MVC.BLL.DTOs.PostDtos;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.Interfaces;

public interface IPostService
{
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
    Task CreateAsync(AddPostDto addPostDto);
    Task UpdateAsync(UpdatePostDto updatePostDto);
    Task DeleteAsync(int id);
}