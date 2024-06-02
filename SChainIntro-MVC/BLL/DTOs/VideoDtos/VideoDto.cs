namespace SChainIntro_MVC.BLL.DTOs.VideoDtos;

public class VideoDto
{
    public int Id { get; set; }
    public bool IsActive {  get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }


    public int CreatorId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoURL { get; set; }
}