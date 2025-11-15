namespace EduUz.Core.Models;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int? ClassId { get; set; }
    public Class Class { get; set; }
    public ICollection<Homework> Homework { get; set; } = new List<Homework>();
    public ICollection<ParentStudent> Parents { get; set; } = new List<ParentStudent>();
    public ICollection<BehaviorRecord> BehaviorRecords { get; set; } = new List<BehaviorRecord>();
    public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    public ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();
}