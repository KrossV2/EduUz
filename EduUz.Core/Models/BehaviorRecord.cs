using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class BehaviorRecord
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }  
    public int TeacherId { get; set; }
    public virtual Teacher Teacher { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public DateTime RecordDate { get; set; }
}