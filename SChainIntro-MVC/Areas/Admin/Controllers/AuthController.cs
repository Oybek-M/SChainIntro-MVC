using SChainIntro_MVC.BLL.DTOs.UserDto;
using Microsoft.AspNetCore.Mvc;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data;

namespace SChainIntro_MVC.Areas.Admin.Controllers;

[Area("admin")]
public class AuthController(IAuthService authService)
    : Controller
{
    private readonly IAuthService _authService = authService;

    public IActionResult Login()
    {
        LoginDto dto = new();
        return View(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        var result = await _authService.LoginAsync(dto, Role.Admin);
        if (result.IsSucces)
        {
            return RedirectToAction("index", "home");
        }

        dto.Error = result.ErrorMessage;
        return View(dto);
    }

    public IActionResult Logout()
    {
        _authService.LogoutAsync(Role.Admin);
        return RedirectToAction("login");
    }
}