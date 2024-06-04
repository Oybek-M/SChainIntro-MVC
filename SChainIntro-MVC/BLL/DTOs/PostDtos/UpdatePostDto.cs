namespace SChainIntro_MVC.BLL.DTOs.PostDtos;

public class UpdatePostDto : PostDto
{
    public IFormFile File { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
}
