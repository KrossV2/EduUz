using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Grade
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public GradeType GradeType { get; set; }
    public int Value { get; set; }
    public DateTime Date { get; set; }
    public int TeacherId { get; set; }
    public User Teacher { get; set; }
    public bool IsPendingApproval { get; set; }
}