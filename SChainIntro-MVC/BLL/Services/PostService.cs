using System.Net;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Claims;
using FluentValidation;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.DTOs.PartnerDtos;
using SChainIntro_MVC.BLL.DTOs.PostDtos;
using SChainIntro_MVC.BLL.Interfaces;
using SChainIntro_MVC.Data.Entities;
using SChainIntro_MVC.Data.Interfaces;

namespace SChainIntro_MVC.BLL.Services;

public class PostService(IUnitOfWork unitOfWork,
                         IFileService fileService,
                         IHttpContextAccessor httpContextAccessor,
                         IValidator<Post> validator)
    : IPostService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IFileService _fileService = fileService;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IValidator<Post> _validator = validator;


    public async Task<List<PostDto>> GetAllAsync()
    {
        var posts = await _unitOfWork.Posts.GetAllAsync();
        return posts.Select(p => (PostDto)p).ToList();
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post is not found");
        }
        
        return (PostDto)post;
    }

    public async Task CreateAsync(AddPostDto addPostDto)
    {
        if (addPostDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "AddPostDto is null");
        }

        var post = (Post)addPostDto;

        var filePath = await _fileService.UploadFileAsync("Posts", addPostDto.File);
        // Foydalanuvchi(Admin) ID sini olish
        var creatorId = _httpContextAccessor.HttpContext.User
            .Claims.First(u => u.Type == ClaimTypes.NameIdentifier)
            .Value;

        post.IsActive = true;
        post.CreatedAt = DateTime.Now;
        post.IsEdited = false;
        post.EditedAt = DateTime.Now;
        post.CreatorID = creatorId;
        post.FilePath = filePath;
        
        var validate = await _validator.ValidateAsync(post);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Post is NotAcceptable");
        }

        await _unitOfWork.Posts.CreateAsync(post);
        throw new StatusCodeException(HttpStatusCode.OK, "Post is Succesfully Created");
    }

    public async Task UpdateAsync(UpdatePostDto updatePostDto)
    {
        if (updatePostDto is null)
        {
            throw new StatusCodeException(HttpStatusCode.NoContent, "UpdatePostDto is null");
        }

        var post = await _unitOfWork.Posts.GetByIdAsync(updatePostDto.Id);

        var newFilePath = "";
        if (updatePostDto.File != null)
        {
            var res = await _fileService.DeleteFileAsync(post.FilePath);
            if (!res)
            {
                throw new StatusCodeException(HttpStatusCode.BadRequest, "Post`s old file is Not Deleted");
            }
            newFilePath = await _fileService.UploadFileAsync("Posts", updatePostDto.File);
        }
        else
        {
            newFilePath = post.FilePath;
        }

        post.FilePath = newFilePath;
        post.IsActive = updatePostDto.IsActive;
        post.IsEdited = true;
        post.EditedAt = DateTime.Now;

        var validate = await _validator.ValidateAsync(post);
        if (!validate.IsValid)
        {
            throw new StatusCodeException(HttpStatusCode.NotAcceptable, "Post is NotAcceptable");
        }

        await _unitOfWork.Posts.UpdateAsync(post);  
        throw new StatusCodeException(HttpStatusCode.OK, "Post is Successfully Updated");
    }

    public async Task DeleteAsync(int id)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(id);
        if (post is null)
        {
            throw new StatusCodeException(HttpStatusCode.NotFound, "Post is not found");
        }
        
        var res = await _fileService.DeleteFileAsync(post.FilePath);
        if (!res)
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest, "Post`s file is Not Deleted");
        }
        await _unitOfWork.Posts.DeleteAsync(post);

        throw new StatusCodeException(HttpStatusCode.OK, "Post is Successfully deleted");
    }
}