namespace EduUz.Core.Dtos;

public record StudentResponseDto(
    int Id,
    string FullName,
    string ClassName,
    string SchoolName,
    List<string> Parents);