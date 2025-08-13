using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class GradeChangeRequest
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    public virtual Grade Grade { get; set; }
    public int RequestedById { get; set; }
    public virtual User RequestedBy { get; set; }
    public decimal OldValue { get; set; }
    public decimal NewValue { get; set; }
    public string Reason { get; set; }
    public RequestStatus Status { get; set; } = RequestStatus.Pending;
    public int? ReviewedById { get; set; }
    public virtual User ReviewedBy { get; set; }
    public string ReviewComment { get; set; }
    public DateTime RequestedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ReviewedAt { get; set; }
}