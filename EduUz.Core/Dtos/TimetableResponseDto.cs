namespace EduUz.Core.Dtos;

public record TimetableResponseDto(
    int Id,
    string ClassName,
    string SubjectName,
    string TeacherName,
    string DayOfWeek,
    int LessonNumber,
    string StartTime,
    string EndTime);