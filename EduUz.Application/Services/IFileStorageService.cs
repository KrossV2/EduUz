using System.Threading.Tasks;

namespace EduUz.Application.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(string fileName, byte[] fileContent, string fileType);
        Task<byte[]> DownloadFileAsync(string fileUrl);
        Task DeleteFileAsync(string fileUrl);
        Task<bool> FileExistsAsync(string fileUrl);
    }
}