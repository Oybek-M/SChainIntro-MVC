namespace SChainIntro_MVC.Data.Entities;

public class Post : Base
{
    public int CreatorID { get; set; } // Post`s creator
    public string FilePath { get; set; } // Video or Image (not both in one time)
    public string Title { get; set; } = string.Empty; // Post`s title
    public string Body { get; set; } = string.Empty; // Post`s body
    public int Views { get; set; } // Views-count
    public int Likes { get; set; } // Likes-count
    public int DisLikes { get; set; } // Dislikes-count
    public bool IsActive { get; set; } = true; // This Post is Active ?
}
