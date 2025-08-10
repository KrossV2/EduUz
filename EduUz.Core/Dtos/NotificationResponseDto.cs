namespace EduUz.Core.Dtos;

public record NotificationResponseDto(
    int Id,
    string Message,
    string Sender,
    DateTime SentAt,
    bool IsRead,
    string NotificationType);