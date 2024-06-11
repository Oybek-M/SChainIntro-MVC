using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.DTOs.VideoDtos;


public class AddVideoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoURL { get; set; }


    // Mapper
    public static implicit operator Video(AddVideoDto addVideoDto)
    {
        return new AddVideoDto {
            Title = addVideoDto.Title,
            Description = addVideoDto.Description,
            VideoURL = addVideoDto.VideoURL
        };
    }
}
