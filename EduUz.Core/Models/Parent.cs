namespace EduUz.Core.Models;

public class Parent
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}