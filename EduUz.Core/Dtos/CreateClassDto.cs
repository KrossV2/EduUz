using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public class ClassCreateDto
{
    public string Name { get; set; }
    public ShiftType Shift { get; set; }
    public int TeacherId { get; set; }
}