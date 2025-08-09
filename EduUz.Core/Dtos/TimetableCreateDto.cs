namespace EduUz.Core.Dtos;

public class TimetableCreateDto
{
    public int ClassId { get; set; }
    public DayOfWeek DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
}