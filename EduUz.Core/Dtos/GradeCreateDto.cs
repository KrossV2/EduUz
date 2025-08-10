using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public record GradeCreateDto(
    int StudentId,
    int TeacherSubjectId,
    GradeType GradeType,
    int Value,
    DateTime Date);
