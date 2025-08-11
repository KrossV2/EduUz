namespace EduUz.Core.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public int RoleId { get; set; }
    public int? SchoolId { get; set; }
}