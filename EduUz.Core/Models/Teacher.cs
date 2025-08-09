using System.Xml;

namespace EduUz.Core.Models;

public class Teacher
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public bool IsHomeroomTeacher { get; set; }
    public ICollection<Timetable> Timetables { get; set; }
}
