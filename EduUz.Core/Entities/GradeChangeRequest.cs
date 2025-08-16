using System;

namespace EduUz.Core.Entities
{
    public class GradeChangeRequest
    {
        public int Id { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        public int DirectorId { get; set; }
        public int OldValue { get; set; }
        public int NewValue { get; set; }
        public string Reason { get; set; }
        public GradeChangeStatus Status { get; set; }
        public string DirectorComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }

        // Navigation properties
        public virtual Grade Grade { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Director Director { get; set; }
    }

    public enum GradeChangeStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}