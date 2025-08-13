using EduUz.Core.Models;

namespace EduUz.Application.Repositories.Interfaces;

public interface IStatisticsRepository
{
    Task<List<ClassStatistics>> GetClassStatisticsAsync();
    Task<List<TeacherStatistics>> GetTeacherStatisticsAsync();
    Task<List<AttendanceStatistics>> GetAttendanceStatisticsAsync();
}