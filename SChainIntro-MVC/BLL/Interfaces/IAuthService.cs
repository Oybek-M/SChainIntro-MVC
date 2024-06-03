using Microsoft.AspNetCore.Authentication;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.UserDto;
using SChainIntro_MVC.Data;

namespace SChainIntro_MVC.BLL.Interfaces;

public interface IAuthService
{
    Task<AuthResult> CreateUserAsync(AddUserDto addUserDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto, Role role);
    Task<bool> IsLoggedInAsync();
    Task LogoutAsync(Role role);
    Task<string> GetFullNameAsync(Role role);
    Task<string> GetEmailAsync(Role role);
}