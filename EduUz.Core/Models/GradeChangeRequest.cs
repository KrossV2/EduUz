namespace EduUz.Core.Models;

public class GradeChangeRequest
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    public int NewValue { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; } = "Pending"; // Pending, Approved, Rejected
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public virtual Grade Grade { get; set; }
}
