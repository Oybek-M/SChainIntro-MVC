namespace SChainIntro_MVC.BLL.DTOs.PartnerDtos;


public class UpdatePartnerDto : PartnerDto
{
    public IFormFile Image;
    public string Name { get; set; }
    public string Type { get; set; }
}
