namespace EduUz.Core.Models;

public class Parent
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public virtual ICollection<ParentStudent> Students { get; set; } = new List<ParentStudent>();
}