﻿namespace SChainIntro_MVC.BLL.DTOs.VideoDtos;


public class UpdateVideoDto : VideoDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string VideoURL { get; set; }
}
