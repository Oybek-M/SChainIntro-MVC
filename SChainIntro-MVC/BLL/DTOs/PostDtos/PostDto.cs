using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.DTOs.PostDtos;


public class PostDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }


    public string CreatorId { get; set; }
    public string FilePath { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Views {  get; set; }
    public int Likes { get; set; }
    public int DisLikes {  get; set; }


    // Mapper
    public static implicit operator PostDto(Post postDto)
    {
        return new PostDto()
        {
            Id = postDto.ID,
            IsActive = postDto.IsActive,
            CreatedAt = postDto.CreatedAt,
            IsEdited = postDto.IsEdited,
            EditedAt = postDto.EditedAt,

            CreatorId = postDto.CreatorID,
            FilePath = postDto.FilePath,   
            Title = postDto.Title,
            Content = postDto.Content,
            Views = postDto.Views,
            Likes = postDto.Likes,
            DisLikes = postDto.DisLikes
        };
    }
}
