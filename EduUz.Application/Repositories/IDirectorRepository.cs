using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IDirectorRepository
    {
        Task<Director> GetByIdAsync(int id);
        Task<Director> GetBySchoolIdAsync(int schoolId);
        Task<int> AddAsync(Director director);
        Task UpdateAsync(Director director);
        Task DeleteAsync(int id);
    }
}