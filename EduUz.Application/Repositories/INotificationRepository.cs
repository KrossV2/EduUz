using System.Collections.Generic;
using System.Threading.Tasks;
using EduUz.Core.Entities;

namespace EduUz.Application.Repositories
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(int id);
        Task<List<Notification>> GetNotificationsByUserAsync(int userId, UserType userType, bool? isRead = null, int? page = null, int? pageSize = null);
        Task<int> AddAsync(Notification notification);
        Task UpdateAsync(Notification notification);
        Task DeleteAsync(int id);
    }
}