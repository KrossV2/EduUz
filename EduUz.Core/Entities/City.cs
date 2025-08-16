using System;

namespace EduUz.Core.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        // Navigation properties
        public virtual Region Region { get; set; }
    }
}