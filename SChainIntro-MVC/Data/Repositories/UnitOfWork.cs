using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.Data.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public IPostRepository Post = new PostRepository(_appDbContext);
}

