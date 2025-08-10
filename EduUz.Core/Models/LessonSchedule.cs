namespace EduUz.Core.Models;

public class LessonSchedule
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public int TeacherSubjectId { get; set; }
    public virtual TeacherSubject TeacherSubject { get; set; }
}