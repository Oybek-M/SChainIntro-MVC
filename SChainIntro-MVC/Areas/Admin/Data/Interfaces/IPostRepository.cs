using SChainIntro_MVC.Data.Entities;

namespace SChainIntro_MVC.Data.Interfaces;

public interface IPostRepository : IRepository<Post>
{
    Task<List<Post>> GetByTitleAsync(string title);
}