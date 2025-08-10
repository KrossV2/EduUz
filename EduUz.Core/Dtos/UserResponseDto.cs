namespace EduUz.Core.Dtos;

public record UserResponseDto(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string RoleName,
    string SchoolName);