namespace EduUz.Core.Dtos;

public record TeacherResponseDto(
    int Id,
    string FullName,
    bool IsHomeroomTeacher,
    string SchoolName,
    List<string> Subjects,
    string ClassName);