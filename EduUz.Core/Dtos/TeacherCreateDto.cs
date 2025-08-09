namespace EduUz.Core.Dtos;

public class TeacherCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SubjectId { get; set; }
}
