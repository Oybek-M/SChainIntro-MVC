using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SChainIntro_MVC.Data.Entities;

public class OurService : Base
{
    // Main
    [Required(ErrorMessage = "Servis nomini kiriting")]
    [StringLength(maximumLength:32, MinimumLength = 1, ErrorMessage = "Uzunligi: [1, 32]")]
    public string Title { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Rasm kiritilmadi")]
    public string ImageUrl { get; set; } = string.Empty;
    
    // Background-color: HexCode | RGB
    [Required(ErrorMessage = "Orqafon uchun rang kiriting")]
    [StringLength(maximumLength: 7, ErrorMessage = "Uzunligi: [max: 7]")]
    public string HexCode { get; set; } = "#c0ebf1";
    
    // Description
    // Har bir 'item' alohida qilib chiqariladi
    [Required(ErrorMessage = "Kamida 1 ta kiriting")]
    public List<string> Description { get; set; } = new List<string>();
}