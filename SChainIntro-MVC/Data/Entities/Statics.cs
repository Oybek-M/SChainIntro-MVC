namespace SChainIntro_MVC.Data.Entities;

public class Statics : Base
{
    public string MainBgVid { get; set; } = string.Empty; // Asosiy orqa-fon Video
    public string IntroVidImage { get; set; } = string.Empty; // Tanishtiruv Video ning rasmi
    public string IntroVidPath { get; set; } = string.Empty; // Tanishtiruv Video ning Url
    
    // Our Team - Types
    public List<string> WorkerTypes { get; set; } = new List<string>();
    
    // Main facts
    public int Economy { get; set; } // Qilingan iqtisod(ekonom)
    public int Direction { get; set; } // Yo'nalish turlari(umumiy)
    public int Experience { get; set; } // Tajriba(umumiy)
    public int Projects { get; set; } // Loyihalar(umumiy)
    
    // Additional
    public string PhoneNumber { get; set; } = string.Empty; // SChain Telefon raqami
    public string Email { get; set; } = string.Empty; // SChain Emaili
    public string LocationText { get; set; } = String.Empty; // SChain Manzili
    public string LocationUrl { get; set; } = string.Empty; // SChain Joylashuvi
}
