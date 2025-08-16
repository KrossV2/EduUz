using System;

namespace EduUz.Core.Entities
{
    public class FileRecord
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserType UserType { get; set; }
        public string FileName { get; set; }
        public string FileUrl { get; set; }
        public string FileType { get; set; }
        public long FileSize { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
    }
}