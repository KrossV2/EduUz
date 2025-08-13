namespace EduUz.Core.Dtos;

public class TeacherDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string FullName { get; set; } // Qo'shamiz
    public bool IsHomeroomTeacher { get; set; }
    public int TotalSubjects { get; set; } // Qo'shimcha statistikalar
    public int TotalClasses { get; set; }
}