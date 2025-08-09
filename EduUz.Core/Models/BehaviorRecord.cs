using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class BehaviorRecord
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public BehaviorType BehaviorType { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
}

