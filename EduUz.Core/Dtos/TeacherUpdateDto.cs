
using Microsoft.AspNetCore.Http;

namespace EduUz.Core.Dtos;

public record TeacherUpdateDto(
    bool IsHomeroomTeacher,
    string Email,
    string PhoneNumber,
    IFormFile Image,
    string FirstName , string LastName,
    List<int> SubjectIds);