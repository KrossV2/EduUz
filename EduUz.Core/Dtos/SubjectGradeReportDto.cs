namespace EduUz.Core.Dtos;

public class SubjectGradeReportDto
{
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public double AverageGrade { get; set; }
    public List<GradeDetailDto> Grades { get; set; } = new();
}