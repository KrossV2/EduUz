namespace EduUz.Core.Dtos;

public record NotificationCreateDto(
    int ReceiverId,
    string Message,
    string NotificationType,
    int? RelatedEntityId);