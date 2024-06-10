namespace SChainIntro_MVC.Data.Entities;

public class Static : Base
{
    // Background Video/Images
    public string MainBgVidPath { get; set; } = string.Empty;
    public string IntroVidBgPath { get; set; } = string.Empty;
    public string IntroVidPath { get; set; } = string.Empty;
    
    // Main 4 facts
    public int Ecocnomy { get; set; }
    public int Directory { get; set; }
    public int Experience { get; set; }
    public int Projects { get; set; }
    
    // Company`s contact
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string LocationTxt { get; set; } = string.Empty;
    public string LocationURL { get; set; } = string.Empty;
    
    // Additional
    public string OwnerPassword { get; set; } = "045737cb215b00e7d78787c0cc29d92c50d5d4918e8c1b0184e5cf6b7ff3d340";
    public string DevNickName { get; set; } = "M.O";
    public string DevUrl { get; set; } = "https://www.linkedin.com/in/oybek-muxtaraliyev";
    public bool AppearWaterMark { get; set; } = true;
}