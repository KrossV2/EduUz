namespace EduUz.Core.Dtos;

public record GradeResponseDto(
    int Id,
    string StudentName,
    string SubjectName,
    string TeacherName,
    string GradeType,
    int Value,
    DateTime Date,
    bool IsPendingApproval,
    string ChangeReason);