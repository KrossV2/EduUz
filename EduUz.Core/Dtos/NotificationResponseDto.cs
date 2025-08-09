namespace EduUz.Core.Dtos;

public class NotificationResponseDto
{
    public int Id { get; set; }
    public string ReceiverName { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SentAt { get; set; }
}
