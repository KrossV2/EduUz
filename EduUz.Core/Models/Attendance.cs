using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Attendance
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public DateTime Date { get; set; }
    public AttendanceStatus Status { get; set; }
    public int TeacherId { get; set; }
    public User Teacher { get; set; }
}
