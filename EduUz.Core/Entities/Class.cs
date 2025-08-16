using System;

namespace EduUz.Core.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SchoolId { get; set; }
        public int ClassTeacherId { get; set; }
        public ClassShift Shift { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual School School { get; set; }
        public virtual Teacher ClassTeacher { get; set; }
    }

    public enum ClassShift
    {
        Morning = 1,
        Evening = 2
    }
}