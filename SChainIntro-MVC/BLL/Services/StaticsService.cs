using System.Net;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.BLL.Services;

public class StaticsService(IUnitOfWork unitOfWork, IFileService fileService, IHttpContextAccessor httpContextAccessor) : IStaticsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<Static> GetAsync()
    {
        var statics = await _unitOfWork.Statics.GetAsync();
        return statics;
    }

    public Task<Static> UpdateAsync(Static staticThings)
    {
        throw new NotImplementedException();
        // Updateni yaxshilab o'ylab qilish kk
    }
}