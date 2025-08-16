using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EduUz.Application.Mediator.Common.Notifications
{
    public class GetNotificationsQuery : IRequest<List<NotificationDto>>
    {
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public bool? IsRead { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
    }

    public class GetNotificationsQueryHandler : IRequestHandler<GetNotificationsQuery, List<NotificationDto>>
    {
        private readonly INotificationRepository _notificationRepository;

        public GetNotificationsQueryHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<List<NotificationDto>> Handle(GetNotificationsQuery request, CancellationToken cancellationToken)
        {
            var notifications = await _notificationRepository.GetNotificationsByUserAsync(
                request.UserId, request.UserType, request.IsRead, request.Page, request.PageSize);

            return notifications.Select(n => new NotificationDto
            {
                Id = n.Id,
                Title = n.Title,
                Message = n.Message,
                Type = n.Type,
                IsRead = n.IsRead,
                CreatedAt = n.CreatedAt,
                Data = n.Data // Additional data in JSON format
            }).ToList();
        }
    }

    public class NotificationDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Data { get; set; }
    }

    public enum NotificationType
    {
        Info = 1,
        Warning = 2,
        Error = 3,
        Success = 4,
        Grade = 5,
        Attendance = 6,
        Homework = 7,
        Behavior = 8
    }
}