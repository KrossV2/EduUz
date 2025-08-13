using EduUz.Core.Dtos;
using EduUz.Core.Models;

namespace EduUz.Application.Repositories.Interfaces;

public interface IGradeRepository :  IRepository<Grade>
{
    Task<List<Grade>> GetFilteredGradesAsync(GradeFilterDto filter);
    Task<List<Grade>> GetGradesByStudentAsync(int studentId);
    Task<List<Grade>> GetPendingApprovalsAsync();
}
