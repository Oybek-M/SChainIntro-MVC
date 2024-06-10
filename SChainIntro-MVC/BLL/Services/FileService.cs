using System.Net;
using SChainIntro_MVC.BLL.Common.Exceptions;
using SChainIntro_MVC.BLL.Interfaces;


namespace SChainIntro_MVC.BLL.Services;

public class FileService(IWebHostEnvironment webHostEnvironment) : IFileService
{
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<string> UploadFileAsync(string folderName, IFormFile file)
    {
        if (file == null || string.IsNullOrEmpty(folderName))
            throw new ArgumentNullException(nameof(file), "File or folder name cannot be null.");

        var wwwRootFolder = _webHostEnvironment.WebRootPath;
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        var filePath = Path.Combine(wwwRootFolder, folderName, uniqueFileName);

        Directory.CreateDirectory(Path.Combine(wwwRootFolder, folderName));

        using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(fileStream);
        }

        return $"~/{folderName}/{uniqueFileName}";
    }

    public async Task<bool> DeleteFileAsync(string filePath)
    {
        if (string.IsNullOrEmpty(filePath))
            throw new ArgumentNullException(nameof(filePath), "File path cannot be null.");

        var fullPath = Path.Combine(_webHostEnvironment.WebRootPath, filePath.TrimStart('~', '/'));

        if (File.Exists(fullPath))
        {
            File.Delete(fullPath);
            throw new StatusCodeException(HttpStatusCode.OK,
                "File is Successfully Deleted");
        }
        else
        {
            throw new StatusCodeException(HttpStatusCode.BadRequest,
                "File is Not Found or Not Deleted");
        }
    }
}