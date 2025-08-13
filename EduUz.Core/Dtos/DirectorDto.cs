namespace EduUz.Core.Dtos;

// Class DTOs
public class ClassDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; } // Ertalab/Kechki
    public int? ClassTeacherId { get; set; }
    public string ClassTeacherName { get; set; }
    public int StudentsCount { get; set; }
    public int SchoolId { get; set; }
    public string SchoolName { get; set; }
}

public class CreateClassRequest
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
}

public class UpdateClassRequest
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
}

// Teacher DTOs
public class TeacherDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public bool IsClassTeacher { get; set; }
    public List<string> Subjects { get; set; } = new();
    public List<string> Classes { get; set; } = new();
    public int SchoolId { get; set; }
    public string SchoolName { get; set; }
    public bool IsActive { get; set; }
}

public class CreateTeacherRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public bool IsClassTeacher { get; set; }
    public List<int> SubjectIds { get; set; } = new();
}

public class UpdateTeacherRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsClassTeacher { get; set; }
    public bool IsActive { get; set; }
}

public class AssignSubjectRequest
{
    public int SubjectId { get; set; }
}

// Timetable DTOs
public class TimetableDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public string DayOfWeek { get; set; }
    public int Period { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string Room { get; set; }
}

public class CreateTimetableRequest
{
    public int ClassId { get; set; }
    public string DayOfWeek { get; set; }
    public int Period { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string Room { get; set; }
}

public class UpdateTimetableRequest
{
    public int ClassId { get; set; }
    public string DayOfWeek { get; set; }
    public int Period { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string Room { get; set; }
}

// Grade Change Request DTOs
public class GradeChangeRequestDto
{
    public int Id { get; set; }
    public int GradeId { get; set; }
    public string StudentName { get; set; }
    public string SubjectName { get; set; }
    public string ClassName { get; set; }
    public decimal OldValue { get; set; }
    public decimal NewValue { get; set; }
    public string Reason { get; set; }
    public string Status { get; set; }
    public string RequestedByName { get; set; }
    public DateTime RequestedAt { get; set; }
    public string ReviewComment { get; set; }
    public DateTime? ReviewedAt { get; set; }
}

public class ApproveGradeChangeRequest
{
    public string Comment { get; set; }
}

public class RejectGradeChangeRequest
{
    public string Comment { get; set; }
}

// Statistics DTOs
public class ClassStatisticsDto
{
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int StudentsCount { get; set; }
    public double AverageGrade { get; set; }
    public int AttendancePercentage { get; set; }
    public int BehaviorPoints { get; set; }
}

public class TeacherStatisticsDto
{
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public List<string> Subjects { get; set; } = new();
    public int ClassesCount { get; set; }
    public int StudentsCount { get; set; }
    public double AverageGrade { get; set; }
    public int GradesGiven { get; set; }
}

public class AttendanceStatisticsDto
{
    public string Period { get; set; }
    public int TotalStudents { get; set; }
    public int PresentCount { get; set; }
    public int AbsentCount { get; set; }
    public int LateCount { get; set; }
    public double AttendancePercentage { get; set; }
}

// Reports DTOs
public class GradeReportDto
{
    public string StudentName { get; set; }
    public string ClassName { get; set; }
    public string SubjectName { get; set; }
    public decimal Grade { get; set; }
    public string GradeType { get; set; }
    public DateTime Date { get; set; }
}