namespace SChainIntro_MVC.BLL.Interfaces;

public interface IFileService
{
    Task<string> UploadFile(string folderName, IFormFile file);
    Task<bool> DeleteFile(string filePath);
}