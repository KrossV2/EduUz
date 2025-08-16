using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IActivityHistoryRepository
    {
        Task<ActivityHistory> GetByIdAsync(int id);
        Task<List<ActivityHistory>> GetByUserIdAsync(int userId, UserType userType);
        Task<List<ActivityHistory>> GetBySchoolIdAsync(int schoolId);
        Task<int> AddAsync(ActivityHistory activity);
        Task UpdateAsync(ActivityHistory activity);
        Task DeleteAsync(int id);
    }
}