namespace EduUz.Core.Dtos;

public record TeacherCreateDto(
    int UserId,
    bool IsHomeroomTeacher,
    List<int> SubjectIds);