namespace SChainIntro_MVC.Data.Entities;

public class AboutUs : Base
{
    // Other - OurWorkers
    public List<string> WorkerName { get; set; } = new List<string>();
    public List<string> WorkerImagePath { get; set; } = new List<string>();
    public List<string> WorkerRole { get; set; } = new List<string>();
}