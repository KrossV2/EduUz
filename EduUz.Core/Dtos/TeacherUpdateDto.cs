
namespace EduUz.Core.Dtos;

public record TeacherUpdateDto(
    bool IsHomeroomTeacher,
    List<int> SubjectIds);