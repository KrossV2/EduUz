namespace EduUz.Core.Dtos;

public record BehaviorRecordResponseDto(
    int Id,
    string StudentName,
    string TeacherName,
    string Description,
    int Points,
    DateTime RecordDate);
