namespace EduUz.Core.Models;
public class Director
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
}

