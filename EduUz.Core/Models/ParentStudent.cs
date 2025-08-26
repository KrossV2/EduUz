namespace EduUz.Core.Models;

public class ParentStudent
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public  Parent Parent { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
}
