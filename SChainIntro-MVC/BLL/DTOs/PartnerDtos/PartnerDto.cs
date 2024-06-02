using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.PartnerDtos;

public class PartnerDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public bool IsEdited {  get; set; }
    public DateTime EditedTime { get; set; }


    public int CreatorId { get; set; }
    public string ImagePath { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }


    // Mapper
    public static implicit operator PartnerDto(Partner partner)
    {
        return new PartnerDto()
        {
            Id = partner.ID,
            IsActive = partner.IsActive,
            CreatedAt = partner.CreatedAt,
            IsEdited = partner.IsEdited,
            EditedTime = partner.EditedAt,

            CreatorId = partner.CreatorId,
            ImagePath = partner.ImagePath,
            Name = partner.Name,
            Type = partner.Type
        };
    }
}
