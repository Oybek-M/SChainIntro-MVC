namespace SChainIntro_MVC.Data.Entities;


public class Partner : Base
{
    public string CreatorId { get; set; } // Partner creator(admin)`s ID
    public string ImagePath { get; set; } = string.Empty; // Logo of Partner
    public string Name { get; set; } = string.Empty; // Name of Partner
    public string Type { get; set; } = string.Empty; // Type of Partner: 'Hamkor'|'Mijoz'
}