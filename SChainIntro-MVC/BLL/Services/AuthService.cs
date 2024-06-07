using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;

using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.Common.Security;
using SChainIntro_MVC.BLL.DTOs.UserDto;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.BLL.Services;

public class AuthService(IUnitOfWork unitOfWork,
                         IHttpContextAccessor httpContextAccessor)
    : IAuthService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<AuthResult> CreateUserAsync(AddUserDto addUserDto)
    {
        if (addUserDto == null)
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "AddUserDto is null"
            };
        }

        var users = await _unitOfWork.Users.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Email == addUserDto.Email);
        if (user != null)
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "Email already exists"
            };
        }

        var newUser = new User()
        {
            ImagePath = addUserDto.ImagePath ?? "~/wwwroot/UserImages/user.png",
            FName = addUserDto.FName,
            LName = addUserDto.LName,
            Email = addUserDto.Email,
            Password = PasswordHasher.GetHashPassword(addUserDto.Password),
            UserRole = Role.User,
            Gender = addUserDto.Gender,
            IsTeam = false,
            TeamType = "user"
        };

        await _unitOfWork.Users.CreateAsync(newUser);

        return new AuthResult()
        {
            IsSucces = true
        };
    }

    public async Task<AuthResult> LoginAsync(LoginDto loginDto, Role role)
    {
        if (loginDto == null)
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "LoginDto is null"
            };
        }
        
        var users = await _unitOfWork.Users.GetAllAsync();
        var user = users.FirstOrDefault(u => u.Email == loginDto.Email);
        if (user == null)
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "user is not found"
            };
        }

        if (!PasswordHasher.VerifyPassword(loginDto.Password, user.Password))
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "Password is incorrect"
            };
        }

        if (user.UserRole != role && role != Role.User)
        {
            return new AuthResult()
            {
                IsSucces = false,
                ErrorMessage = "You have not a permission for this page"
            };
        }
        
        // Write User date to Cookies
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FName + user.LName),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, role.ToString())
        };

        var identity = new ClaimsIdentity(claims, role.ToString());
        var principal = new ClaimsPrincipal(identity);

        if (loginDto.RememberMe)
        {
            await _httpContextAccessor.HttpContext!.SignInAsync(role.ToString(), principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.Now.AddDays(1)
            });
        }
        else
        {
            await _httpContextAccessor.HttpContext!.SignInAsync(role.ToString(), principal);
        }

        return new AuthResult()
        {
            IsSucces = true
        };
    }

    public async Task<bool> IsLoggedInAsync()
    {
        var res = _httpContextAccessor.HttpContext!.AuthenticateAsync(Role.User.ToString());
        return res.Result.Succeeded;
    }

    public async Task LogoutAsync(Role role)
    {
        await _httpContextAccessor.HttpContext.SignOutAsync(role.ToString());
    }

    public async Task<string> GetFullNameAsync(Role role)
    {
        var name = _httpContextAccessor.HttpContext.AuthenticateAsync(role.ToString());
        return name.Result.Principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;
    }

    public async Task<string> GetEmailAsync(Role role)
    {
        var email = _httpContextAccessor.HttpContext.AuthenticateAsync(ToString());
        return email.Result.Principal!.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
    }
}