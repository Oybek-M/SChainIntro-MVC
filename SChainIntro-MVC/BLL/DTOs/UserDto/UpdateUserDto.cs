using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Enums;


namespace SChainIntro_MVC.BLL.DTOs.UserDto;


public class UpdateUserDto : UserDto
{
    public string ImagePath { get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public Gender Gender { get; set; }


    // Mapper
    public static implicit operator User(UpdateUserDto updateUserDto)
    {
        return new User()
        {
            ImagePath = updateUserDto.ImagePath,
            FName = updateUserDto.FName,
            LName = updateUserDto.LName,
            Email = updateUserDto.Email,
            Password = updateUserDto.Password,
            Gender = updateUserDto.Gender
        };
    }
}
