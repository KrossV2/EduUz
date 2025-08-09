using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Subject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public LanguageType Language { get; set; }
}