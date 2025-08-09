namespace EduUz.Core.Dtos;

public class StudentCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int ClassId { get; set; }
}