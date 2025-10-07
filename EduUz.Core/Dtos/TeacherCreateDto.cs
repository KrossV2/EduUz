using Microsoft.AspNetCore.Http;

namespace EduUz.Core.Dtos;

public record TeacherCreateDto(
    int UserId,
    bool IsHomeroomTeacher,
    IFormFile Image,
    List<int> SubjectIds);