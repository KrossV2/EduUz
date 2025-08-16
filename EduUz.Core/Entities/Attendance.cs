using System;

namespace EduUz.Core.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int ClassId { get; set; }
        public DateTime Date { get; set; }
        public AttendanceStatus Status { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Class Class { get; set; }
    }

    public enum AttendanceStatus
    {
        Present = 1,
        Absent = 2,
        Late = 3
    }
}