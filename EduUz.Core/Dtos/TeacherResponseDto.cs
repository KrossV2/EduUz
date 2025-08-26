namespace EduUz.Core.Dtos;

public class TeacherResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public bool IsHomeroomteacher { get; set; }
    public string SchoolName { get; set; }
    public List<string> Subjects { get; set; }
}

