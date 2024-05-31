using Microsoft.EntityFrameworkCore;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class VideoRepository(AppDbContext dbContext)
    : Repository<Video>(dbContext), IVideoRepository
{
    public async Task<List<Video>> GetByTitleAsync(string title)
    {
        var videos = await _dbContext.Videos.ToListAsync();
        var filteredVideos = videos.Where(v => v.Title.ToLower()
                                              .Contains(title.ToLower()))
                                              .ToList();

        videos.Clear(); // Save/clear memory
        return filteredVideos;
    }
}