namespace EduUz.Core.Models;
public class Director
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public int SchoolId { get; set; }
    public virtual School School { get; set; }
}

