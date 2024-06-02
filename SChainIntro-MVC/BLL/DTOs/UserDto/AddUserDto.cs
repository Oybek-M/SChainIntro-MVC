using SChainIntro_MVC.Data.Enums;
using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.BLL.DTOs.UserDto;

public class AddUserDto
{
    public string ImagePath { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }


    // Mapper
    public static implicit operator User(AddUserDto addUserDto)
    {
        return new User()
        {
            ImagePath = addUserDto.ImagePath,
            FName = addUserDto.FName,
            LName = addUserDto.LName,
            Email = addUserDto.Email,
            Password = addUserDto.Password,
            Gender = addUserDto.Gender
        };
    }
}
