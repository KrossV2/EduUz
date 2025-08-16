using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetByClassIdAsync(int classId);
        Task<List<Student>> GetBySchoolIdAsync(int schoolId);
        Task<int> AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(int id);
        Task<List<Parent>> GetParentsByStudentIdAsync(int studentId);
    }
}