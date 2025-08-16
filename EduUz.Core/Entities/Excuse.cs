using System;

namespace EduUz.Core.Entities
{
    public class Excuse
    {
        public int Id { get; set; }
        public int AttendanceId { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public string Reason { get; set; }
        public string DocumentUrl { get; set; }
        public ExcuseStatus Status { get; set; }
        public string TeacherComment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ProcessedAt { get; set; }

        // Navigation properties
        public virtual Attendance Attendance { get; set; }
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
    }

    public enum ExcuseStatus
    {
        Pending = 1,
        Approved = 2,
        Rejected = 3
    }
}