using System.Net;
using System.Security.Claims;
using System.Security.Cryptography;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Update.Internal;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.ServiceDtos;
using SChainIntro_MVC.BLL.DTOs.VideoDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.BLL.Services;

public class VideoService(IUnitOfWork unitOfWork,
                          IFileService fileService,
                          IHttpContextAccessor httpContextAccessor,
                          IValidator<Video> validator)
    : IVideoService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IValidator<Video> _validator = validator;

    public async Task<List<VideoDto>> GetAllAsync()
    {
        var videos = await _unitOfWork.Videos.GetAllAsync();
        return videos.Select(s => (VideoDto)s).ToList();
    }

    public async Task<VideoDto> GetByIdAsync(int id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);
        if (video is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Video is Not Found");
        }

        return (VideoDto)video;
    }

    public async Task CreateAsync(AddVideoDto addVideoDto)
    {
        if (addVideoDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent,
                "AddVideoDto is null");
        }

        var video = (Video)addVideoDto;

        var creatorId = _httpContextAccessor.HttpContext.User
            .Claims.First(v => v.Type == ClaimTypes.NameIdentifier)
            .Value;

        video.IsActive = true;
        video.CreatedAt = DateTime.Now;
        video.IsEdited = false;
        video.EditedAt = DateTime.Now;
        video.CreatorID = creatorId;

        var validate = await _validator.ValidateAsync(video);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                "Vide is NotAcceptable");
        }

        await _unitOfWork.Videos.CreateAsync(video);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Video is Successfully Created");
    }

    public async Task UpdateAsync(UpdateServiceDto updateServiceDto)
    {
        if (updateServiceDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent,
                "UpdateVideoDto is null");
        }

        var video = await _unitOfWork.Videos.GetByIdAsync(updateServiceDto.Id);

        var validate = _validator.Validate(video);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                "Video is NotAcceptable");
        }

        await _unitOfWork.Videos.UpdateAsync(video);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Service is Successfully Updated");
    }

    public async Task DeleteAsync(int id)
    {
        var video = await _unitOfWork.Videos.GetByIdAsync(id);
        if (video is null)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest,
                "Video is Not Found");
        }

        await _unitOfWork.Videos.DeleteAsync(video);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Video is Successfully Deleted");
    }
}