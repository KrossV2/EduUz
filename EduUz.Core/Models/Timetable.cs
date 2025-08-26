using System;
using EduUz.Core.Enums;

namespace EduUz.Core.Models;

public class Timetable
{
    public int Id { get; set; }
    public int LessonScheduleId { get; set; }
    public LessonSchedule LessonSchedule { get; set; }
    public DateTime LessonDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public   ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
}