using SChainIntro_MVC.Areas.Admin.Data.Repositories;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.Data.Repositories;


public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    public AppDbContext DbContext = appDbContext;


    public IPostRepository Posts => new PostRepository(DbContext);

    public IServiceRepository Services => new ServiceRepository(DbContext);

    public IPartnerRepository Partners => new PartnerRepository(DbContext);

    public IUserRepository Users => new UserRepository(DbContext);

    public IVideoRepository Videos => new VideoRepository(DbContext);
    public IStaticRepository Static => new StaticRepository(DbContext);
}

