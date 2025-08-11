
namespace EduUz.Core.Dtos;

public class NotificationDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Message { get; set; }
    public DateTime SentAt { get; set; }
    public bool IsRead { get; set; }
    public string NotificationType { get; set; }
    public int? RelatedEntityId { get; set; }
}

