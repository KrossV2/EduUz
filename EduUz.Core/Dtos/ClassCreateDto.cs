using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public record ClassCreateDto(
    string Name,
    ShiftType Shift,
    int SchoolId,
    int? HomeroomTeacherId);
