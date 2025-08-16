using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EduUz.Application.Repositories;
using EduUz.Core.Entities;

namespace EduUz.Application.Mediator.Common.Notifications
{
    public class MarkNotificationAsReadCommand : IRequest<bool>
    {
        public int NotificationId { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
    }

    public class MarkNotificationAsReadCommandHandler : IRequestHandler<MarkNotificationAsReadCommand, bool>
    {
        private readonly INotificationRepository _notificationRepository;

        public MarkNotificationAsReadCommandHandler(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }

        public async Task<bool> Handle(MarkNotificationAsReadCommand request, CancellationToken cancellationToken)
        {
            var notification = await _notificationRepository.GetByIdAsync(request.NotificationId);
            if (notification == null)
                throw new ArgumentException("Notification not found");

            // Check if notification belongs to the user
            if (notification.UserId != request.UserId || notification.UserType != request.UserType)
                throw new UnauthorizedAccessException("Notification does not belong to this user");

            notification.IsRead = true;
            notification.ReadAt = DateTime.UtcNow;

            await _notificationRepository.UpdateAsync(notification);

            return true;
        }
    }
}