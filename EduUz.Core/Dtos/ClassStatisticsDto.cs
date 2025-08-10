
namespace EduUz.Core.Dtos;

public record ClassStatisticsDto(
    int ClassId,
    string ClassName,
    double AverageGrade,
    int TotalStudents,
    int AttendancePercentage);