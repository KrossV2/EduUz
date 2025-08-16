using System;

namespace EduUz.Core.Entities
{
    public class ActivityHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string Action { get; set; }
        public string Description { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
    }
}