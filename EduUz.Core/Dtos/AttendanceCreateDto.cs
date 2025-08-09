using EduUz.Core.Enums;

namespace EduUz.Core.Dtos;

public class AttendanceCreateDto
{
    public int StudentId { get; set; }
    public AttendanceStatus Status { get; set; }
}