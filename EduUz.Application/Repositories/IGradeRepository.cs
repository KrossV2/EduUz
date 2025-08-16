using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetGradesByClassAsync(int classId);
        Task<List<Grade>> GetGradesByStudentAsync(int studentId, int? subjectId = null, GradeType? gradeType = null);
        Task<List<Grade>> GetGradesBySubjectAsync(int subjectId);
        Task<Grade> GetByIdAsync(int id);
        Task<int> AddAsync(Grade grade);
        Task UpdateAsync(Grade grade);
        Task DeleteAsync(int id);
    }
}