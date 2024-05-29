namespace SChainIntro_MVC.Data.Entities;

public class AboutUs : Base
{
    // Our Team - Worker Types
    public List<string> WorkerTypes { get; set; } = new List<string>();
    
    // Out Team - OurWorkers
    public List<string> WorkerImagePath { get; set; } = new List<string>();
    public List<string> WorkerName { get; set; } = new List<string>();
    public List<string> WorkerRole { get; set; } = new List<string>();
}
