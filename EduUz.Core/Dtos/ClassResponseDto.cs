namespace EduUz.Core.Dtos;

public record ClassResponseDto(
    int Id,
    string Name,
    string Shift,
    string SchoolName,
    string HomeroomTeacherName,
    int StudentCount);