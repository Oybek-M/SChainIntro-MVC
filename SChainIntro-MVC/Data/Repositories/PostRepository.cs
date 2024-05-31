using Microsoft.EntityFrameworkCore;
using System.Linq;

using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class PostRepository(AppDbContext dbContext)
    : Repository<Post>(dbContext), IPostRepository
{
    public async Task<List<Post>> GetByTitleAsync(string title)
    {
        var posts = await _dbContext.Posts.ToListAsync();
        var filteredPosts = posts.Where(p => p.Title.ToLower()
                                          .Contains(title.ToLower()))
                                          .ToList();
        
        posts.Clear(); // Save/cleare memory
        return filteredPosts;
    }
}