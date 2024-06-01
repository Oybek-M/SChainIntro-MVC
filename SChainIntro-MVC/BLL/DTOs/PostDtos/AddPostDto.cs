using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.PostDtos;

public class AddPostDto
{
    public IFormFile File { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;


    public static implicit operator Post(AddPostDto dto)
    {
        return new Post
        {
            Title = dto.Title,
            Content = dto.Content,
        };
    }
}
