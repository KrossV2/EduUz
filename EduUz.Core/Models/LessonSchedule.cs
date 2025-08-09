namespace EduUz.Core.Models;

public class LessonSchedule
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int LessonNumber { get; set; } // 1-dars, 2-dars
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int TeacherId { get; set; }
    public User Teacher { get; set; }
}
