using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Enums;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Repositories;

public class StatisticsRepository(EduUzDbContext context) : IStatisticsRepository
{
    public async Task<List<ClassStatistics>> GetClassStatisticsAsync()
    {
        return await context.Classes
            .Include(c => c.Students) // Students ni include qilish kerak
            .Include(c => c.Students).ThenInclude(s => s.Grades) // Grades ni ham
            .Select(c => new ClassStatistics
            {
                ClassId = c.Id,
                ClassName = c.Name,
                TotalStudents = c.Students.Count,
                AverageGrade = c.Students
                    .Where(s => s.Grades.Any()) // Faqat bahosi bor o'quvchilarni hisobga olamiz
                    .Average(s => s.Grades.Average(g => g.Value)),
                AttendancePercentage = c.Students.Any() && c.Students.First().AttendanceRecords.Any()
                    ? (int)(c.Students
                        .SelectMany(s => s.AttendanceRecords)
                        .Count(a => a.Status == AttendanceStatus.Present) * 100.0 /
                        c.Students.SelectMany(s => s.AttendanceRecords).Count())
                    : 0
            })
            .ToListAsync();
    }

    public async Task<List<TeacherStatistics>> GetTeacherStatisticsAsync()
    {
        return await context.Teachers
            .Include(t => t.User) // User ma'lumotlari kerak
            .Include(t => t.TeacherSubjects) // TeacherSubjects
            .Select(t => new TeacherStatistics
            {
                TeacherId = t.Id,
                TeacherName = t.User.FirstName + " " + t.User.LastName, // To'g'ri ism
                TotalSubjects = t.TeacherSubjects.Count,
                TotalClasses = context.LessonSchedules
                    .Where(ls => t.TeacherSubjects.Select(ts => ts.Id).Contains(ls.TeacherSubjectId))
                    .Select(ls => ls.ClassId)
                    .Distinct()
                    .Count(),
                AverageStudentGrade = context.Grades
                    .Where(g => t.TeacherSubjects.Select(ts => ts.Id).Contains(g.TeacherSubjectId))
                    .DefaultIfEmpty() // Agar baho bo'lmasa
                    .Average(g => g != null ? g.Value : 0)
            })
            .ToListAsync();
    }

    public async Task<List<AttendanceStatistics>> GetAttendanceStatisticsAsync()
    {
        return await context.Classes
            .Include(c => c.Students)
                .ThenInclude(s => s.AttendanceRecords) // Davomat ma'lumotlari
            .Select(c => new AttendanceStatistics
            {
                ClassId = c.Id,
                ClassName = c.Name,
                PresentCount = c.Students
                    .SelectMany(s => s.AttendanceRecords)
                    .Count(a => a.Status == AttendanceStatus.Present),
                AbsentCount = c.Students
                    .SelectMany(s => s.AttendanceRecords)
                    .Count(a => a.Status == AttendanceStatus.Absent),
                LateCount = c.Students
                    .SelectMany(s => s.AttendanceRecords)
                    .Count(a => a.Status == AttendanceStatus.Late),
                AttendanceRate = c.Students.SelectMany(s => s.AttendanceRecords).Any()
                    ? (c.Students
                        .SelectMany(s => s.AttendanceRecords)
                        .Count(a => a.Status == AttendanceStatus.Present) * 100.0 /
                        c.Students.SelectMany(s => s.AttendanceRecords).Count())
                    : 0
            })
            .ToListAsync();
    }
}