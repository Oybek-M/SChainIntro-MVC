namespace SChainIntro_MVC.Data.Entities;

public class Service : Base
{
    public int CreatorId { get; set; } // Service creator(admin)`s ID
    public string ImagePath { get; set; } // Service`s Image-path
    public string Title { get; set; } = string.Empty; // Service`s title
    public List<string> Description { get; set; } = new(); // Service`s Descriptions
    public string BgColor { get; set; } = "#c0ebf1"; // Background-color
}