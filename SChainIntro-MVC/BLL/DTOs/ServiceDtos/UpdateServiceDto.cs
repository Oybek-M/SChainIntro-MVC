﻿namespace SChainIntro_MVC.BLL.DTOs.ServiceDtos;

public class UpdateServiceDto
{
    public IFormFile ImagePath { get; set; }
    public string Title { get; set; }
    public List<string> Description { get; set; }
    public string BgColor { get; set; }
}
