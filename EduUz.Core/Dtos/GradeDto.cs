namespace EduUz.Core.Dtos;

public class GradeDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int TeacherSubjectId { get; set; }
    public string GradeType { get; set; } // "Daily", "Quiz", "Quarter", "Yearly"
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public bool IsPendingApproval { get; set; }
}