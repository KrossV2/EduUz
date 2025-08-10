namespace EduUz.Core.Dtos;

public record GradeChangeRequestDto(
    int GradeId,
    int NewValue,
    string Reason);