namespace EduUz.Core.Dtos;

public class LessonScheduleCreateDto
{
    public int ClassId { get; set; }
    public string DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public int TeacherSubjectId { get; set; }
}
