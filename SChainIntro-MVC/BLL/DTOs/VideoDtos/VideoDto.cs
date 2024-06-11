using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.DTOs.VideoDtos;


public class VideoDto
{
    public int Id { get; set; }
    public bool IsActive {  get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }


    public string CreatorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoURL { get; set; }


    // Mapper
    public static implicit operator VideoDto(Video video)
    {
        return new VideoDto()
        {
            Id = video.ID,
            IsActive = video.IsActive,
            CreatedAt = video.CreatedAt,
            IsEdited = video.IsEdited,
            EditedAt = video.EditedAt,

            CreatorId = video.CreatorID,
            Title = video.Title,
            Description = video.Description,
            VideoURL = video.VideoURL
        };
    }
}