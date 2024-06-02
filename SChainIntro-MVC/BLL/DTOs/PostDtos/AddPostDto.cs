using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.PostDtos;

public class AddPostDto
{
    public IFormFile File { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }


    // Mapper
    public static implicit operator Post(AddPostDto postDto)
    {
        return new Post
        {
            Title = postDto.Title,
            Content = postDto.Content,
        };
    }
}
