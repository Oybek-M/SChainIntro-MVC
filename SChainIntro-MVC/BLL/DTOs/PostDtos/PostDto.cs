using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.PostDtos;

public class PostDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }


    public int CreatorId { get; set; }
    public string FilePath { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Views {  get; set; }
    public int Likes { get; set; }
    public int DisLikes {  get; set; }


    // Mapper
    public static implicit operator PostDto(Post post)
    {
        return new PostDto()
        {
            Id = post.ID,
            IsActive = post.IsActive,
            CreatedAt = post.CreatedAt,
            IsEdited = post.IsEdited,
            EditedAt = post.EditedAt,

            CreatorId = post.CreatorID,
            FilePath = post.FilePath,   
            Title = post.Title,
            Content = post.Content,
            Views = post.Views,
            Likes = post.Likes,
            DisLikes = post.DisLikes
        };
    }
}
