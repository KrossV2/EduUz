using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IHomeworkRepository
    {
        Task<List<Homework>> GetHomeworksByTeacherAsync(int teacherId, int? classId = null, int? subjectId = null);
        Task<List<Homework>> GetHomeworksByClassAsync(int classId, int? subjectId = null);
        Task<Homework> GetByIdAsync(int id);
        Task<int> AddAsync(Homework homework);
        Task UpdateAsync(Homework homework);
        Task DeleteAsync(int id);
        Task AddMaterialsAsync(List<HomeworkMaterial> materials);
        Task<HomeworkSubmission> GetHomeworkSubmissionAsync(int homeworkId, int studentId);
        Task<int> AddSubmissionAsync(HomeworkSubmission submission);
        Task AddSubmissionFilesAsync(List<HomeworkSubmissionFile> files);
    }
}