using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IExcuseRepository
    {
        Task<Excuse> GetByIdAsync(int id);
        Task<Excuse> GetByAttendanceIdAsync(int attendanceId);
        Task<List<Excuse>> GetByStudentIdAsync(int studentId);
        Task<List<Excuse>> GetByParentIdAsync(int parentId);
        Task<int> AddAsync(Excuse excuse);
        Task UpdateAsync(Excuse excuse);
        Task DeleteAsync(int id);
    }
}