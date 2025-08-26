namespace EduUz.Core.Models;

public class HomeworkSubmission
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public  Student Student { get; set; }

    public int HomeworkId { get; set; }
    public Homework Homework { get; set; }

    public string FileUrl { get; set; }

    public string Comment { get; set; }

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public int? GradeId { get; set; }
    public Grade Grade { get; set; }
}
