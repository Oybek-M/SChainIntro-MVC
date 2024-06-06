namespace SChainIntro_MVC.BLL.DTOs.ServiceDtos;

public class UpdateServiceDto : ServiceDto
{
    public IFormFile Image { get; set; }
    public string Title { get; set; }
    public List<string> Description { get; set; }
    public string BgColor { get; set; }
    public bool IsActive { get; set; }
}
