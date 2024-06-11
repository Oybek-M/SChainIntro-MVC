using SChainIntro_MVC.Data.Entities;


namespace SChainIntro_MVC.Data.Interfaces;


public interface IVideoRepository : IRepository<Video>
{
    Task<List<Video>> GetByTitleAsync(string title);
}