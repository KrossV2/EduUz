namespace EduUz.Core.Dtos;

public record HomeworkResponseDto(
    int Id,
    string SubjectName,
    string TeacherName,
    string ClassName,
    string Description,
    string DueDate,
    List<string> Attachments);