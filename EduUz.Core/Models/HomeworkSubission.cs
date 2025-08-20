namespace EduUz.Core.Models;

public class HomeworkSubmission
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public virtual Student Student { get; set; }

    public int HomeworkId { get; set; }
    public virtual Homework Homework { get; set; }

    public string FileUrl { get; set; }

    public string Comment { get; set; }

    public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

    public int? GradeId { get; set; }
    public virtual Grade Grade { get; set; }
}
