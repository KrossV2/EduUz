using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Students.GetMyNotification;

public record GetMyNotificationsQuery(int UserId) : IRequest<List<NotificationDto>>;

public class GetMyNotificationsQueryHandler : IRequestHandler<GetMyNotificationsQuery, List<NotificationDto>>
{
    private readonly EduUzDbContext _context;

    public GetMyNotificationsQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<NotificationDto>> Handle(GetMyNotificationsQuery request, CancellationToken cancellationToken)
    {
        return await _context.Notifications
            .Where(n => n.UserId == request.UserId)
            .OrderByDescending(n => n.SentAt)
            .Select(n => new NotificationDto
            {
                Id = n.Id,
                UserId = n.UserId,
                Message = n.Message,
                SentAt = n.SentAt,
                IsRead = n.IsRead,
                NotificationType = n.NotificationType,
                RelatedEntityId = n.RelatedEntityId
            })
            .ToListAsync(cancellationToken);
    }
}
