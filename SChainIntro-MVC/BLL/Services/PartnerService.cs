using System.Net;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Security.Claims;
using FluentValidation;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.PartnerDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;


namespace SChainIntro_MVC.BLL.Services;

public class PartnerService(IUnitOfWork unitOfWork,
                            IFileService fileService,
                            IHttpContextAccessor httpContextAccessor,
                            IValidator<Partner> validator) 
    : IPartnerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IValidator<Partner> _validator = validator;

    public async Task<List<PartnerDto>> GetAllAsync()
    {
        var partners = await _unitOfWork.Partners.GetAllAsync();
        return partners.Select(p => (PartnerDto)p).ToList();
    }

    public async Task<PartnerDto> GetByIdAsync(int id)
    {
        var partner = await _unitOfWork.Partners.GetByIdAsync(id);
        if (partner is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Partner is not found");
        }
        
        return (PartnerDto)partner;
    }

    public async Task<List<string>> GetAllImagesAsync()
    {
        var partners = await _unitOfWork.Partners.GetAllAsync();
        return partners.Select(p => p.ImagePath).ToList();
    }

    public async Task<string> GetImageAsync(int id)
    {
        var partner = await _unitOfWork.Partners.GetByIdAsync(id);
        return partner.ImagePath;
    }

    public async Task CreateAsync(AddPartnerDto addPartnerDto)
    {
        if (addPartnerDto == null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "AddPartnerDto is null");
        }

        var partner = (Partner)addPartnerDto;
        var validate = await _validator.ValidateAsync(partner);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "Partner is empty");
        }

        var imagePath = await _fileService.UploadFileAsync("Partners", addPartnerDto.Image);
        // Foydalanuvchi(Admin) ID sini olish
        var creatorId = _httpContextAccessor.HttpContext.User
            .Claims.First(u => u.Type == ClaimTypes.NameIdentifier)
            .Value;

        partner.IsActive = true;
        partner.CreatedAt = DateTime.Now;
        partner.IsEdited = false;
        partner.EditedAt = DateTime.Now;
        partner.CreatorId = creatorId;
        partner.ImagePath = imagePath;

        await _unitOfWork.Partners.CreateAsync(partner);
    }

    public async Task UpdateAsync(UpdatePartnerDto updatePartnerDto)
    {
        if (updatePartnerDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "UpdatePartnerDto is null");
        }

        var partner = await _unitOfWork.Partners.GetByIdAsync(updatePartnerDto.Id);

        var newImagePath = "";
        if (updatePartnerDto.Image != null)
        {
            var res = await _fileService.DeleteFileAsync(partner.ImagePath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Partner`s old image is Not Deleted");
            }
            newImagePath = await _fileService.UploadFileAsync("Partners", updatePartnerDto.Image);
        }
        else
        {
            newImagePath = partner.ImagePath;
        }

        partner.ImagePath = newImagePath;
        partner.IsActive = updatePartnerDto.IsActive;
        partner.Name = updatePartnerDto.Name;
        partner.Type = updatePartnerDto.Type;
        partner.IsEdited = true;
        partner.EditedAt = DateTime.UtcNow;

        var validate = await _validator.ValidateAsync(partner);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Partner is NotAcceptable");
        }

        await _unitOfWork.Partners.UpdateAsync(partner);
        throw new StatusCodeException(HttpStatusCode.OK, "Partner is Succesfully Created");
    }

    public async Task DeleteAsync(int id)
    {
        var partner = await _unitOfWork.Partners.GetByIdAsync(id);
        if (partner == null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound,
                "Partner is not found");
        }

        var res = await _fileService.DeleteFileAsync(partner.ImagePath);
        if (!res)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Partner image is Not Deleted");
        }
        await _unitOfWork.Partners.DeleteAsync(partner);
    }
}
