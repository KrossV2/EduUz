namespace EduUz.Core.Models;

public class ClassStatistics
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int TotalStudents { get; set; }
    public double AverageGrade { get; set; }
    public int AttendancePercentage { get; set; }
}