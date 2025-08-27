namespace EduUz.Core.Dtos;

public class TimetableCreateDto
{
    public int LessonScheduleId { get; set; }   // Qaysi jadval asosida
    public DateTime LessonDate { get; set; }    // Dars sanasi
    public TimeSpan StartTime { get; set; }     // Dars boshlanishi
    public TimeSpan EndTime { get; set; }       // Dars tugashi
};