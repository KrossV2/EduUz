using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public record ClassUpdateDto(
    string Name,
    ShiftType Shift,
    int? HomeroomTeacherId);
