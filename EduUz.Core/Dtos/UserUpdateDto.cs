using Microsoft.AspNetCore.Http;

namespace EduUz.Core.Dtos;

public record UserUpdateDto(
    string FirstName,
    string LastName,
    string Email,
    string PhoneNumber,
    int RoleId,
    IFormFile Image,
    int? SchoolId);