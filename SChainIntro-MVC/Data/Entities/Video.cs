using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SChainIntro_MVC.Data.Entities;

public class Video : Base
{
    [Required(ErrorMessage = "Video uchun nomni kiriting")]
    [StringLength(maximumLength: 140, MinimumLength = 1, ErrorMessage = "Uzunligi: [1, 140]")]
    public string VideoTitle { get; set; } = string.Empty;
    
    [StringLength(maximumLength:280, ErrorMessage = "Uzunligi: 280 belgidan oshmasin")]
    public string VideoDescription { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Video ning URL ini kiriting")]
    public string VideoPath { get; set; } = string.Empty;
}
