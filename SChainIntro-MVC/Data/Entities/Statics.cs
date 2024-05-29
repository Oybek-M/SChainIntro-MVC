using System.ComponentModel.DataAnnotations;

namespace SChainIntro_MVC.Data.Entities;

public class Statics : Base
{
    // General
    [Required]
    public string MainBgVid { get; set; } = string.Empty; // Asosiy orqa-fon Video
    
    [Required]
    public string IntroVidImage { get; set; } = string.Empty; // Tanishtiruv Video ning rasmi
    
    [Required]
    public string IntroVidPath { get; set; } = string.Empty; // Tanishtiruv Video ning Url
    
    
    // Main facts
    [Required]
    public int Economy { get; set; } // Qilingan iqtisod(ekonom)
    
    [Required]
    public int Direction { get; set; } // Yo'nalish turlari(umumiy)
    
    [Required]
    public int Experience { get; set; } // Tajriba(umumiy)
    
    [Required]
    public int Projects { get; set; } // Loyihalar(umumiy)
    
    
    // Additional
    [Required]
    public string PhoneNumber { get; set; } = string.Empty; // SChain Telefon raqami
    
    [Required]
    public string Email { get; set; } = string.Empty; // SChain Emaili
    
    [Required]
    public string LocationText { get; set; } = String.Empty; // SChain Manzili
    
    [Required]
    public string LocationUrl { get; set; } = string.Empty; // SChain Joylashuvi
}