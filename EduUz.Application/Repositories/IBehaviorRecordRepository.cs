using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IBehaviorRecordRepository
    {
        Task<BehaviorRecord> GetByIdAsync(int id);
        Task<List<BehaviorRecord>> GetByStudentIdAsync(int studentId);
        Task<List<BehaviorRecord>> GetByTeacherIdAsync(int teacherId);
        Task<int> AddAsync(BehaviorRecord record);
        Task UpdateAsync(BehaviorRecord record);
        Task DeleteAsync(int id);
        Task<int> GetTotalBehaviorPointsAsync(int studentId);
    }
}