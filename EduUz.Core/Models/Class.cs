using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ShiftType Shift { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public int? HomeroomTeacherId { get; set; }
    public Teacher HomeroomTeacher { get; set; }
    public  ICollection<Student> Students { get; set; } = new List<Student>();
    public  ICollection<LessonSchedule> Schedules { get; set; } = new List<LessonSchedule>();
}