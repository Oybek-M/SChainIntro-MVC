namespace SChainIntro_MVC.BLL.DTOs.StaticDtos;


public class UpdateStaticDto
{
    // Files
    public IFormFile MainBgVid { get; set; }
    public IFormFile IntroVid { get; set; }
    public IFormFile IntroVidBg { get; set; }

    // Main 4 facts
    public int Economy { get; set; }
    public int Directory { get; set; }
    public int Experience { get; set; }
    public int Projects { get; set; }

    // Company`s contact
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string LocationTxt { get; set; } = string.Empty;
    public string LocationURL { get; set; } = string.Empty;
}