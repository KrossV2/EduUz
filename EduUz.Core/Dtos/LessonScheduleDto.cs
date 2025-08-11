namespace EduUz.Core.Dtos;

public class LessonScheduleDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public int TeacherSubjectId { get; set; }
}