namespace EduUz.Core.Models;

public class AttendanceStatistics
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public double AttendanceRate { get; set; } // Foizda (0-100)
}