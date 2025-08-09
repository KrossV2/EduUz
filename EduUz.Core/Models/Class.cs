using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Class
{
    public int Id { get; set; }
    public string Name { get; set; } // Masalan: 7A
    public ShiftType Shift { get; set; }
    public int SchoolId { get; set; }
    public School School { get; set; }
    public int ClassTeacherId { get; set; }
    public User ClassTeacher { get; set; }
}
