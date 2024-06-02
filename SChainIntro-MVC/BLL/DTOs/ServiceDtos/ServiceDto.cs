namespace SChainIntro_MVC.BLL.DTOs.ServiceDtos;

public class ServiceDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }

    public int CreaorId { get; set; }
    public string ImagePath {  get; set; }
    public string Title {  get; set; }
    public List<string> Description { get; set; }
    public string BgColor { get; set; }
}
