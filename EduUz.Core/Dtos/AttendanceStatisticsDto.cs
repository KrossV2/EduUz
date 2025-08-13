namespace EduUz.Core.Dtos;

public class AttendanceStatisticsDto
{
    public string ClassName { get; set; }
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public double AttendanceRate { get; set; }
}