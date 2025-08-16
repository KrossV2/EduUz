using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface ITeacherRepository
    {
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetBySchoolIdAsync(int schoolId);
        Task<bool> HasAccessToClassAsync(int teacherId, int classId);
        Task<bool> HasAccessToStudentAsync(int teacherId, int studentId);
        Task<bool> HasAccessToSubjectAsync(int teacherId, int subjectId);
        Task<bool> HasAccessToStudentAndSubjectAsync(int teacherId, int studentId, int subjectId);
        Task<bool> IsClassTeacherAsync(int teacherId, int classId);
        Task<bool> IsClassTeacherForStudentAsync(int teacherId, int studentId);
        Task<int> AddAsync(Teacher teacher);
        Task UpdateAsync(Teacher teacher);
        Task DeleteAsync(int id);
    }
}