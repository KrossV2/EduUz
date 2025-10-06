namespace EduUz.Core.Dtos;

public record UserCreateDto(
    string FirstName,
    string LastName,
    string Email,
    string Username,
    string PhoneNumber,
    string Password,
    int RoleId,
    int? SchoolId);