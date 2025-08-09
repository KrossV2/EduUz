namespace EduUz.Core.Dtos;


public class TimetableResponseDto
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public string DayOfWeek { get; set; }
    public int LessonNumber { get; set; }
    public string SubjectName { get; set; }
    public string TeacherName { get; set; }
}
