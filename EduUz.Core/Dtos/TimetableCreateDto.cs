namespace EduUz.Core.Dtos;

public record TimetableCreateDto(
    int ClassId,
    int TeacherSubjectId,
    DayOfWeek DayOfWeek,
    int LessonNumber,
    TimeSpan StartTime,
    TimeSpan EndTime);