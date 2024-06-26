using System.Net;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.PartnerDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;
using System.Security.Claims;


namespace SChainIntro_MVC.BLL.Services;


public class PartnerService(IUnitOfWork unitOfWork,
                                IFileService fileService,
                                IHttpContextAccessor httpContextAccessor)
        : IPartnerService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public async Task<List<PartnerDto>> GetAllAsync()
    {
        var partners = await _unitOfWork.Partners.GetAllAsync();
        return partners.Select(p => new PartnerDto
        {
            Id = p.ID,
            IsActive = p.IsActive,
            CreatedAt = p.CreatedAt,
            IsEdited = p.IsEdited,
            EditedTime = p.EditedAt,

            CreatorId = p.CreatorId,
            ImagePath = p.ImagePath,
            Name = p.Name,
            Type = p.Type

        }).ToList();
    }

    public async Task<PartnerDto> GetByIdAsync(int id)
    {
        var partner = await _unitOfWork.Partners.GetByIdAsync(id);
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
            throw new StatusCodeException(HttpStatusCode.NotImplemented,
                "AddPartnerDto is null");
        }


        var imagePath = await _fileService
            .UploadFileAsync("Partners", addPartnerDto.Image);

        // Foydalanuvchi ID sini 
        var creatorId = _httpContextAccessor.HttpContext.User
            .Claims.First(u => u.Type == ClaimTypes.NameIdentifier).Value;

        Partner newPartner = new Partner()
        {
            IsActive = true,
            CreatedAt = DateTime.UtcNow,
            CreatorId = creatorId, // Fix qilish kk
            IsEdited = false,
            EditedAt = DateTime.UtcNow,
            ImagePath = imagePath,
            Name = addPartnerDto.Name,
            Type = addPartnerDto.Type
        };

        await _unitOfWork.Partners.CreateAsync(newPartner);
    }

    public async Task UpdateAsync(UpdatePartnerDto updatePartnerDto)
    {
        if (updatePartnerDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotImplemented,
                "UpdatePartnerDto is null");
        }

        var partner = await _unitOfWork.Partners.GetByIdAsync(updatePartnerDto.Id);

        var newImagePath = updatePartnerDto.Image != null && updatePartnerDto.Image.Length > 0
            ? await _fileService.UploadFileAsync("Partners", updatePartnerDto.Image)
            : partner.ImagePath;

        partner.ImagePath = newImagePath;
        partner.Name = updatePartnerDto.Name;
        partner.Type = updatePartnerDto.Type;
        partner.IsEdited = true;
        partner.EditedAt = DateTime.UtcNow;

        await _unitOfWork.Partners.UpdateAsync(partner);
    }

    public async Task DeleteAsync(int id)
    {
        var partner = await _unitOfWork.Partners.GetByIdAsync(id);
        if (partner == null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound,
                "Partner is not found");
        }

        await _fileService.DeleteFileAsync(partner.ImagePath);
        await _unitOfWork.Partners.DeleteAsync(partner);
    }
}