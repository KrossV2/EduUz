using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }  
    public int TeacherSubjectId { get; set; }
    public TeacherSubject TeacherSubject { get; set; }
    public GradeType GradeType { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public bool IsPendingApproval { get; set; }
    public string ChangeReason { get; set; }
    public int? OriginalGradeId { get; set; }
    public Grade OriginalGrade { get; set; }
}