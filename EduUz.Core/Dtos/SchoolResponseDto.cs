namespace EduUz.Core.Dtos;

public record SchoolResponseDto(
    int Id,
    string Name,
    string CityName,
    string RegionName,
    string DirectorName);