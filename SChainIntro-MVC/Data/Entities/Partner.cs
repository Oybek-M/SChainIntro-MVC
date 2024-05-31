namespace SChainIntro_MVC.Data.Entities;

public class Partner : Base
{
    public int CreatorId { get; set; } // Partner creator(admin)`s ID
    public string ImagePath { get; set; } = string.Empty; // Logo of Partner
    public string Name { get; set; } = string.Empty; // Name of Partner
    public string Type { get; set; } = string.Empty; // Type of Partner: 'Hamkor'|'Mijoz'
    public bool IsActive { get; set; } = true; // This Partner is Active now ? 
}