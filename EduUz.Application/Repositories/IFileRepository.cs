using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IFileRepository
    {
        Task<FileRecord> GetByIdAsync(int id);
        Task<List<FileRecord>> GetByUserIdAsync(int userId, UserType userType);
        Task<int> AddAsync(FileRecord file);
        Task UpdateAsync(FileRecord file);
        Task DeleteAsync(int id);
    }
}