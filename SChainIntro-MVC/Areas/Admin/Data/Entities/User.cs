using SChainIntro_MVC.Data.Enums;


namespace SChainIntro_MVC.Data.Entities;


public class User : Base
{
    public string ImagePath { get; set; } = string.Empty; // Image-path
    public string FName { get; set; } = string.Empty; // First-name
    public string LName { get; set; } = string.Empty; // Last-name
    public string Email { get; set; } = string.Empty; // Email
    public string Password { get; set; } = string.Empty; // Password with HASH
    public Role UserRole { get; set; } = Role.User; // Become a creating
    public Gender Gender { get; set; } = Gender.Male; // Become a creating
    public bool IsTeam { get; set; } = false; // Is Our Team
    public string TeamType { get; set; } = string.Empty; // IsTeam ? 'team name' : 'User'
}