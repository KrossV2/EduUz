namespace EduUz.Core.Models;

public class Notification
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public string Message { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }
    public string NotificationType { get; set; }
    public int? RelatedEntityId { get; set; } // For linking to grades, attendances etc
}