using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IGradeChangeRequestRepository
    {
        Task<GradeChangeRequest> GetByIdAsync(int id);
        Task<List<GradeChangeRequest>> GetByTeacherIdAsync(int teacherId);
        Task<List<GradeChangeRequest>> GetByDirectorIdAsync(int directorId);
        Task<int> AddAsync(GradeChangeRequest request);
        Task UpdateAsync(GradeChangeRequest request);
        Task DeleteAsync(int id);
    }
}