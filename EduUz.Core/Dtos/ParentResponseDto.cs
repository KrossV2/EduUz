namespace EduUz.Core.Dtos;

public record ParentResponseDto(
    int Id,
    string FullName,
    List<string> Children,
    string Email);