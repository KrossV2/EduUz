using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface IAttendanceRepository
    {
        Task<List<Attendance>> GetAttendanceByClassAndDateAsync(int classId, DateTime date);
        Task<List<Attendance>> GetAttendanceByStudentAsync(int studentId, DateTime? startDate = null, DateTime? endDate = null);
        Task<Attendance> GetByIdAsync(int id);
        Task<int> AddAsync(Attendance attendance);
        Task AddRangeAsync(List<Attendance> attendances);
        Task UpdateAsync(Attendance attendance);
        Task DeleteAsync(int id);
        Task<int> GetConsecutiveAbsencesAsync(int studentId);
    }
}