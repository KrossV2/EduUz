namespace EduUz.Core.Dtos;

public record HomeworkCreateDto(
    int TeacherSubjectId,
    int ClassId,
    string Description,
    DateTime DueDate);