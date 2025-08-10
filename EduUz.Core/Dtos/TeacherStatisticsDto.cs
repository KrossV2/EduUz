namespace EduUz.Core.Dtos;

public record TeacherStatisticsDto(
    int TeacherId,
    string TeacherName,
    int TotalClasses,
    int TotalStudents,
    double AverageGrade);