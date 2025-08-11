namespace EduUz.Core.Dtos;
public class BehaviorRecordDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public int TeacherId { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public DateTime RecordDate { get; set; }
}
