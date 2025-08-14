namespace EduUz.Core.Models;

public class Student
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int ClassId { get; set; }
    public virtual Class Class { get; set; }
    public virtual ICollection<ParentStudent> Parents { get; set; } = new List<ParentStudent>();

    // Navigation properties
    public virtual ICollection<Attendance> AttendanceRecords { get; set; } = new List<Attendance>();
    public virtual ICollection<BehaviorRecord> BehaviorRecords { get; set; } = new List<BehaviorRecord>();
    public virtual ICollection<Grade> Grades { get; set; } = new List<Grade>();
}