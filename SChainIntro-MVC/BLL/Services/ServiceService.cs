using System.Net;
using System.Security.Claims;
using FluentValidation;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.ServiceDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.BLL.Services;

public class ServiceService(IUnitOfWork unitOfWork,
                            IFileService fileService,
                            IHttpContextAccessor httpContextAccessor,
                            IValidator<Service> validator)
    : IServiceService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IValidator<Service> _validator = validator;

    public async Task<List<ServiceDto>> GetAllAsync()
    {
        var services = await _unitOfWork.Services.GetAllAsync();
        return services.Select(s => (ServiceDto)s).ToList();
    }

    public async Task<ServiceDto> GetByIdAsync(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound,
                "Service is not found");
        }

        return (ServiceDto)service;
    }

    public async Task CreateAsync(AddServiceDto addServiceDto)
    {
        if (addServiceDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent,
                "AddServiceDto is null");
        }

        var service = (Service)addServiceDto;

        var imagePath = await _fileService
            .UploadFileAsync("Services", addServiceDto.Image);
        // Foydalanuvchi(Admin) ID sini olish
        var creatorId = _httpContextAccessor.HttpContext.User
            .Claims.First(u => u.Type == ClaimTypes.NameIdentifier)
            .Value;

        service.IsActive = true;
        service.CreatedAt = DateTime.Now;
        service.IsEdited = false;
        service.EditedAt = DateTime.Now;
        service.CreatorId = creatorId;
        service.ImagePath = imagePath;

        var validate = await _validator.ValidateAsync(service);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                "Service is NotAcceptable");
        }

        await _unitOfWork.Services.CreateAsync(service);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Service is Successfully Created");
    }

    public async Task UpdateAsync(UpdateServiceDto updateServiceDto)
    {
        if (updateServiceDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent,
                "UpdateServiceDto is null");
        }

        var servise = await _unitOfWork.Services.GetByIdAsync(updateServiceDto.Id);

        var newImagePath = "";
        if (updateServiceDto.Image != null)
        {
            var res = await _fileService.DeleteFileAsync(servise.ImagePath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest,
                    "Service`s old image is Dot Deletes");
            }

            newImagePath = await _fileService.UploadFileAsync("Services",
                updateServiceDto.Image);
        }
        else
        {
            newImagePath = servise.ImagePath;
        }

        servise.ImagePath = newImagePath;
        servise.IsActive = updateServiceDto.IsActive;
        servise.IsEdited = true;
        servise.EditedAt = DateTime.Now;

        var validate = _validator.Validate(servise);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable,
                "Service is NotAcceptable");
        }

        await _unitOfWork.Services.UpdateAsync(servise);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Service is Succesfully Updated");
    }

    public async Task DeleteAsync(int id)
    {
        var service = await _unitOfWork.Services.GetByIdAsync(id);
        if (service is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound,
                "Service is Not Found");
        }

        var res = await _fileService.DeleteFileAsync(service.ImagePath);
        if (!res)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest,
                "Service`s image is Not Deleted");
        }

        await _unitOfWork.Services.DeleteAsync(service);
        throw new StatusCodeException(HttpStatusCode.OK,
            "Service is Succesfully Deleted");
    }
}