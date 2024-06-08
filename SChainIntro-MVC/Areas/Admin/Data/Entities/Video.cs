namespace SChainIntro_MVC.Data.Entities;

public class Video : Base
{
    public string CreatorID { get; set; }
    public string Title { get; set; } = string.Empty; // Video`s title
    public string Description { get; set; } = string.Empty; // Video`s description
    public string VideoURL { get; set; } = string.Empty; // Video`s YouTube Link
}