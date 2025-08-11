namespace EduUz.Core.Dtos;

public class TimetableDto
{
    public int Id { get; set; }
    public int LessonScheduleId { get; set; }
    public DateTime LessonDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}