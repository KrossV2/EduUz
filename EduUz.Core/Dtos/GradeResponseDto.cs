namespace EduUz.Core.Dtos;

public class GradeResponseDto
{
    public int Id { get; set; }
    public string StudentName { get; set; }
    public string SubjectName { get; set; }
    public string GradeType { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }
}