namespace EduUz.Core.Dtos;

public record UserUpdateDto(
    string FirstName,
    string LastName,
    string Email,
    int RoleId,
    int? SchoolId);