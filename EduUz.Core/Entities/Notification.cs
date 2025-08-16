using System;

namespace EduUz.Core.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public NotificationType Type { get; set; }
        public bool IsRead { get; set; }
        public string Data { get; set; } // JSON data for additional information
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
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