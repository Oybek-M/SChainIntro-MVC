namespace SChainIntro_MVC.BLL.DTOs.UserDto;


public class LoginDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    
    public bool RememberMe { get; set; }
    public string Error { get; set; }
}
