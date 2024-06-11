using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.DTOs.ServiceDtos;


public class ServiceDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }

    public string CreaorId { get; set; }
    public string ImagePath {  get; set; }
    public string Title {  get; set; }
    public List<string> Description { get; set; }
    public string BgColor { get; set; }


    // Mapper
    public static implicit operator ServiceDto(Service service)
    {
        return new ServiceDto()
        {
            Id = service.ID,
            IsActive = service.IsActive,
            CreatedAt = service.CreatedAt,
            IsEdited = service.IsEdited,
            EditedAt = service.EditedAt,

            CreaorId = service.CreatorId,
            ImagePath = service.ImagePath,
            Title = service.Title,
            Description = service.Description,
            BgColor = service.BgColor
        };
    }
}
