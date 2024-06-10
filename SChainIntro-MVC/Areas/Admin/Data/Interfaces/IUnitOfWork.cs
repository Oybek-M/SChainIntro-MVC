using SChainIntro_MVC.BLL.Interfaces;

namespace SChainIntro_MVC.Data.Interfaces;

public interface IUnitOfWork
{
    IPostRepository Posts { get; }
    IServiceRepository Services { get; }
    IPartnerRepository Partners { get; }
    IUserRepository Users { get; }
    IVideoRepository Videos { get; }
    IStaticRepository Static { get; }
}