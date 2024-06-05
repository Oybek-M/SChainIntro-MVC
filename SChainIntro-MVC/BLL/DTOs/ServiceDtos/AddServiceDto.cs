using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.ServiceDtos;

public class AddServiceDto
{
    public IFormFile ImagePath { get; set; }
    public string Title {  get; set; }
    public List<string> Description { get; set; }
    public string BgColor {  get; set; }


    // Mapper
    public static implicit operator Service(AddServiceDto addServiceDto)
    {
        return new Service()
        {
            Title = addServiceDto.Title,
            Description = addServiceDto.Description,
            BgColor = addServiceDto.BgColor
        };
    }
}
