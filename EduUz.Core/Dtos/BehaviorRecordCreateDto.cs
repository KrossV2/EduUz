namespace EduUz.Core.Dtos;

public record BehaviorRecordCreateDto(
    int StudentId,
    int TeacherId,
    string Description,
    int Points);
