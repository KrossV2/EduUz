using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ShiftType Shift { get; set; }
    public int SchoolId { get; set; }
    public virtual School School { get; set; }
    public int? HomeroomTeacherId { get; set; }
    public virtual Teacher HomeroomTeacher { get; set; }
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    public virtual ICollection<LessonSchedule> Schedules { get; set; } = new List<LessonSchedule>();
}