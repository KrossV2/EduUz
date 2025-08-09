using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public class GradeCreateDto
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public GradeType GradeType { get; set; }
    public int Value { get; set; }
}