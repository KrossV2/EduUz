using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface ITimetableRepository
    {
        Task<List<Timetable>> GetTimetableByClassAsync(int classId);
        Task<List<Timetable>> GetTimetableByTeacherAsync(int teacherId);
        Task<Timetable> GetByIdAsync(int id);
        Task<int> AddAsync(Timetable timetable);
        Task UpdateAsync(Timetable timetable);
        Task DeleteAsync(int id);
    }
}