using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Attendance
{
    public int Id { get; set; }
    public int TimetableId { get; set; }
    public virtual Timetable Timetable { get; set; }
    public int StudentId { get; set; }
    public virtual Student Student { get; set; }  // This should exist
    public AttendanceStatus Status { get; set; }
}