namespace EduUz.Core.Dtos;

public class AttendanceResponseDto
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string Status { get; set; }
    public DateTime Date { get; set; }
}