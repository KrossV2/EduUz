using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public class ClassCreateDto
{
    public string Name { get; set; }
    public ShiftType ShiftType { get; set; }
    public int SchoolId { get; set; }
    public int? HomeroomTeacherId { get; set; }
}


