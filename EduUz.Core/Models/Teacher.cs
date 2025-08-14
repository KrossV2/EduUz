using System.Xml;

namespace EduUz.Core.Models;

public class Teacher
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public bool IsHomeroomTeacher { get; set; }
    public virtual ICollection<Class> HomeroomClasses { get; set; } = new List<Class>();
    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    // Computed property
    public string FullName => $"{User?.FirstName} {User?.LastName}";
}