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
            throw new StatusCodeException(HttpStatusCode.NotFound, "Service is not found");
        }

        return (ServiceDto)service;
    }

    public async Task CreateAsync(AddServiceDto addServiceDto)
    {
        if (addServiceDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "AddServiceDto is null");
        }

        var service = (Service)addServiceDto;

        var imagePath = await _fileService.UploadFileAsync("Services", addServiceDto.ImagePath);
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
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Service is NotAcceptable");
        }

        await _unitOfWork.Services.CreateAsync(service);
        throw new StatusCodeException(HttpStatusCode.OK, "Service is Succesfully Created");
    }

    public Task UpdateAsync(UpdateServiceDto updateServiceDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}