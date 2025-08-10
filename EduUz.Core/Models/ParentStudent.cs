namespace EduUz.Core.Models;

public class ParentStudent
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public virtual Parent Parent { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }
}
