namespace EduUz.Core.Dtos;

public class DirectorResponseDto
{
    public int Id { get; set; }

    // User info
    public int UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Username { get; set; }

    // School info
    public int? SchoolId { get; set; }
    public string? SchoolName { get; set; }
}
