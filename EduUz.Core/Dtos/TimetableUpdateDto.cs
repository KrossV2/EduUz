namespace EduUz.Core.Dtos;

public record TimetableUpdateDto(
    int? TeacherSubjectId,
    DayOfWeek? DayOfWeek,
    int? LessonNumber,
    TimeSpan? StartTime,
    TimeSpan? EndTime);