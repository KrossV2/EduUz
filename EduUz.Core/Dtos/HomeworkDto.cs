namespace EduUz.Core.Dtos;

public class HomeworkDto
{
    public int Id { get; set; }
    public int TeacherSubjectId { get; set; }
    public int ClassId { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string AttachmentPath { get; set; }
}