using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.Data.Repositories;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _dbCcontext = appDbContext;


    public IPostRepository Posts => new PostRepository(_dbCcontext);

    public IServiceRepository Services => new ServiceRepository(_dbCcontext);

    public IPartnerRepository Partners => new PartnerRepository(_dbCcontext);

    public IUserRepository Users => new UserRepository(_dbCcontext);

    public IVideoRepository Videos => new VideoRepository(_dbCcontext);
    public IStaticRepository Statics => new StaticRepository(_dbCcontext);
}

