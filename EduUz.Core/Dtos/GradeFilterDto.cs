using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public record GradeFilterDto(
    int? ClassId,
    int? SubjectId,
    int? StudentId,
    GradeType? GradeType,
    DateTime? FromDate,
    DateTime? ToDate);