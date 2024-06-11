using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.BLL.DTOs.PartnerDtos;


public class AddPartnerDto
{
    public IFormFile Image;
    public string Name { get; set; }
    public string Type { get; set; }


    // Mapper
    public static implicit operator Partner(AddPartnerDto partnerDto)
    {
        return new Partner
        {
            Name = partnerDto.Name,
            Type = partnerDto.Type
        };
    }
}
