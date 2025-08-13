namespace EduUz.Core.Models;

public class TeacherStatistics
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public int TotalSubjects { get; set; }
    public int TotalClasses { get; set; }
    public double AverageStudentGrade { get; set; }
}