namespace SChainIntro_MVC.BLL.Interfaces;


public interface IFileService
{
    Task<string> UploadFileAsync(string folderName, IFormFile file);
    Task<bool> DeleteFileAsync(string filePath);
}