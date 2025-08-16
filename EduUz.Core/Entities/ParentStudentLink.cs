using System;

namespace EduUz.Core.Entities
{
    public class ParentStudentLink
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int StudentId { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual Parent Parent { get; set; }
        public virtual Student Student { get; set; }
    }
}