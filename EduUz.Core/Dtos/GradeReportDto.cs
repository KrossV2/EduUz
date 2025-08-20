
namespace EduUz.Core.Dtos;

public class GradeReportDto
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public List<SubjectGradeReportDto> Subjects { get; set; } = new();
}