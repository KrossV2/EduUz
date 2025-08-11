namespace EduUz.Core.Dtos;

public class LessonScheduleUpdateDto
{
    public string DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public int TeacherSubjectId { get; set; }
}