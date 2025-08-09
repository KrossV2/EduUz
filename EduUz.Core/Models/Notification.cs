namespace EduUz.Core.Models;

public class Notification
{
    public int Id { get; set; }
    public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
}