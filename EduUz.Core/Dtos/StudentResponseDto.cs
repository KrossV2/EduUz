namespace EduUz.Core.Dtos;

public class StudentResponseDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string ClassName { get; set; }
    public string SchoolName { get; set; }
    public List<string> Parents { get; set; }
}