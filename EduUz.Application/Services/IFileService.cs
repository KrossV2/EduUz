using Microsoft.AspNetCore.Http;

namespace EduUz.Application.Services;

public interface IFileService
{
    Task<string> SaveFileAsync(IFormFile file, string folderName);
    void DeleteFile(string filePath);
}