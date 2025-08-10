
using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public record AttendanceCreateDto(
    int TimetableId,
    int StudentId,
    AttendanceStatus Status);