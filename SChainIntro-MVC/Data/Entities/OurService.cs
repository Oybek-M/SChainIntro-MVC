namespace SChainIntro_MVC.Data.Entities;

public class OurService : Base
{
    // Main
    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    
    // Background-color: RGB
    public byte R { get; set; }
    public byte G { get; set; }
    public byte B { get; set; }
    
    // Description
    public List<string> Description { get; set; } = new(); // Max: 5 item
}