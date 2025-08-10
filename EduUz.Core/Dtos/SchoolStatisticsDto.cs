namespace EduUz.Core.Dtos;

public record SchoolStatisticsDto(
    int SchoolId,
    string SchoolName,
    int TotalStudents,
    int TotalTeachers,
    double AverageGrade);