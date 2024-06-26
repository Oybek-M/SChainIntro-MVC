using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace CarsShopMVC.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(AuthenticationSchemes = "Admin")]
public class HomeController : Controller
{   

    public IActionResult Index()
    {
        var res = HttpContext.User;
        
        return View();
    }

    public IActionResult Error(string? url)
    {
        if (url == null)
        {
            url = "/";
        }
        return View("Error404", url);
    }
}