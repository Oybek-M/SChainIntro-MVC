using System.Net;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.Common.Security;
using SChainIntro_MVC.BLL.DTOs.StaticDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.BLL.Services;


public class StaticsService(IUnitOfWork unitOfWork,
                            IFileService fileService,
                            IHttpContextAccessor httpContextAccessor)
    : IStaticsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<Static> GetAsync()
    {
        var statics = await _unitOfWork.Static.GetAsync();
        return statics;
    }

    public async Task UpdateAsync(UpdateStaticDto updateStaticDto)
    {
        if (updateStaticDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                "Informations are null");
        }

        var staticFile = await GetAsync();

        var newVidPath = "";
        var newIntroVidBg = "";
        var newIntroVidPath = "";

        // Changing: Main Background Video
        if (updateStaticDto.MainBgVid != null)
        {
            var res = await _fileService.DeleteFileAsync(staticFile.MainBgVidPath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadGateway,
                    "Video is Not Deleted");
            }

            newVidPath = await _fileService.UploadFileAsync("StaticFiles",
                updateStaticDto.MainBgVid);
        }
        else
        {
            newVidPath = staticFile.MainBgVidPath;
        }

        // Changing: Intro Video
        if (updateStaticDto.IntroVid != null)
        {
            var res = await _fileService.DeleteFileAsync(staticFile.IntroVidPath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadGateway,
                    "IntroVideo is Not Deleted");
            }

            newIntroVidPath = await _fileService.UploadFileAsync("StaticFiles",
                updateStaticDto.IntroVid);
        }
        else
        {
            newIntroVidPath = staticFile.IntroVidPath;
        }

        // Changing: Intro Video`s Background
        if (updateStaticDto.IntroVidBg != null)
        {
            var res = await _fileService.DeleteFileAsync(staticFile.IntroVidBgPath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadGateway,
                    "IntroVideo`s background image is Not Deleted");
            }

            newIntroVidBg = await _fileService.UploadFileAsync("StaticFiles",
                updateStaticDto.IntroVidBg);
        }
        else
        {
            newIntroVidBg = staticFile.IntroVidBgPath;
        }

        // Manual copying
        staticFile.MainBgVidPath = newVidPath;
        staticFile.IntroVidPath = newIntroVidPath;
        staticFile.IntroVidBgPath = newIntroVidBg;

        staticFile.Ecocnomy = updateStaticDto.Economy;
        staticFile.Directory = updateStaticDto.Directory;
        staticFile.Experience = updateStaticDto.Experience;
        staticFile.Projects = updateStaticDto.Projects;

        staticFile.PhoneNumber = updateStaticDto.PhoneNumber;
        staticFile.Email = updateStaticDto.Email;
        staticFile.LocationTxt = updateStaticDto.LocationTxt;
        staticFile.LocationURL = updateStaticDto.LocationURL;
        // _______________

        await _unitOfWork.Static.UpdateAsync(staticFile);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Statics is Successfully Updated");
    }

    public async Task UpdateMainAsync(UpdateAdditionalDto updateAdditionalDto,
                                      string password)
    {
        var staticFile = await GetAsync();

        var isOwner = PasswordHasher.VerifyPassword(password,
            staticFile.OwnerPassword);
        if (!isOwner)
        {
            throw new StatusCodeException(HttpStatusCode.Unauthorized,
                "Bu amal uchun parol kerak. DB ni qo'lda boshqarishingiz mumkin");
        }

        // Manual copying
        staticFile.OwnerPassword = PasswordHasher
            .GetHashPassword(updateAdditionalDto.OwnerPassword);
        staticFile.DevNickName = updateAdditionalDto.DevNickName;
        staticFile.DevUrl = updateAdditionalDto.DevUrl;
        staticFile.AppearWaterMark = updateAdditionalDto.AppearWaterMark;
        // _______________

        await _unitOfWork.Static.UpdateAsync(staticFile);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Statics is Successfully Updated");
    }
}