
namespace EduUz.Core.Dtos;

public record TeacherUpdateDto(
    bool IsHomeroomTeacher,
    string Email,
    string PhoneNumber,
    string FirstName , string LastName,
    List<int> SubjectIds);