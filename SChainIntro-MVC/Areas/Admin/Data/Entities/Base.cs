namespace SChainIntro_MVC.Data.Entities;


public class Base
{
    public int ID { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public bool IsEdited { get; set; } = false;
    public DateTime EditedAt { get; set; } = DateTime.Now;
}