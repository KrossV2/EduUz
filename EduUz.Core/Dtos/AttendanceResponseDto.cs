namespace EduUz.Core.Dtos;

public record AttendanceResponseDto(
    int Id,
    string StudentName,
    string ClassName,
    string SubjectName,
    DateTime Date,
    string Status,
    string LessonTime);