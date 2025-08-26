namespace EduUz.Core.Models;

public class Excuse
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public  Student Student { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }
}