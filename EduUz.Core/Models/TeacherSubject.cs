namespace EduUz.Core.Models;

public class TeacherSubject
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
    public int SubjectId { get; set; }
    public virtual Subject Subject { get; set; }
}

