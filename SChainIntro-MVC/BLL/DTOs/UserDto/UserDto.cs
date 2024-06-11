using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Enums;


namespace SChainIntro_MVC.BLL.DTOs.UserDto;


public class UserDto
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsEdited { get; set; }
    public DateTime EditedAt { get; set; }

    public string ImagePath {  get; set; }
    public string FName { get; set; }
    public string LName { get; set; }
    public string Email { get; set; }
    public string Password {  get; set; }
    public Role UserRole {  get; set; }
    public Gender Gender { get; set; }
    public bool IsTeam { get; set; }
    public string TeamType { get; set; }


    // Mapper
    public static implicit operator UserDto(User user)
    {
        return new UserDto()
        {
            Id = user.ID,
            IsActive = user.IsActive,
            CreatedAt = user.CreatedAt,
            IsEdited = user.IsEdited,
            EditedAt = user.EditedAt,

            ImagePath = user.ImagePath,
            FName = user.FName,
            LName = user.LName,
            Email = user.Email,
            Password = user.Password,
            UserRole = user.UserRole,
            Gender = user.Gender,
            IsTeam = user.IsTeam,
            TeamType = user.TeamType
        };
    }
}
