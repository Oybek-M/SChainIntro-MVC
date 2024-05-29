namespace SChainIntro_MVC.Data.Entities;

public class Videos : Base
{
    // All of Videos path (in 1 List)
    public List<string> VideoPath { get; set; } = new List<string>();
    
    // All of Videos title (in 1 List)
    public List<string> VideoTitle { get; set; } = new List<string>();
    
    // All of Videos description (in 1 List)
    public List<string> VideoDescription { get; set; } = new List<string>();
}