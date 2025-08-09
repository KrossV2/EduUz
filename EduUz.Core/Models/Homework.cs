namespace EduUz.Core.Models;

public class Homework
{
    public int Id { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public string Description { get; set; }
    public string FileUrl { get; set; }
    public DateTime DueDate { get; set; }
}
