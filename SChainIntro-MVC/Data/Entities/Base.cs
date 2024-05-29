namespace SChainIntro_MVC.Data.Entities;

public class Base
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
