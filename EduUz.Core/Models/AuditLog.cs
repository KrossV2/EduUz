namespace EduUz.Core.Models;

public class AuditLog
{
    public int Id { get; set; }
    public string Action { get; set; }
    public string EntityName { get; set; }
    public string EntityId { get; set; }
    public string OldValues { get; set; }
    public string NewValues { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string IpAddress { get; set; }
    public string UserAgent { get; set; }
    public int? SchoolId { get; set; }
    public virtual School School { get; set; }
}