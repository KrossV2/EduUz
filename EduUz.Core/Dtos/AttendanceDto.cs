namespace EduUz.Core.Dtos;

public class AttendanceDto
{
    public int Id { get; set; }
    public int TimetableId { get; set; }
    public int StudentId { get; set; }
    public string Status { get; set; } // "Present", "Absent", "Late"
}