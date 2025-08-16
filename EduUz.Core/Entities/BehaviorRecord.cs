using System;

namespace EduUz.Core.Entities
{
    public class BehaviorRecord
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public BehaviorType Type { get; set; }
        public int Points { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Evidence { get; set; } // Optional evidence/documentation
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Student Student { get; set; }
        public virtual Teacher Teacher { get; set; }
    }

    public enum BehaviorType
    {
        Positive = 1,
        Negative = 2
    }
}