using System.Threading.Tasks;

namespace EduUz.Application.Services
{
    public interface INotificationService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendTelegramMessageAsync(string chatId, string message);
        Task SendSmsAsync(string phoneNumber, string message);
    }
}