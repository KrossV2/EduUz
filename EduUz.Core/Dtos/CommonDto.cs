namespace EduUz.Core.Dtos;

// User DTOs
public class UserCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public int RoleId { get; set; }
    public int? SchoolId { get; set; }
}

public class UserUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public int RoleId { get; set; }
    public int? SchoolId { get; set; }
    public bool IsActive { get; set; }
}

// Region DTOs
public class RegionCreateDto
{
    public string Name { get; set; }
}

public class RegionUpdateDto
{
    public string Name { get; set; }
}

// City DTOs
public class CityCreateDto
{
    public string Name { get; set; }
    public int RegionId { get; set; }
}

public class CityUpdateDto
{
    public string Name { get; set; }
    public int RegionId { get; set; }
}

// School DTOs
public class SchoolCreateDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}

public class SchoolUpdateDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}

// Class DTOs
public class ClassCreateDto
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
    public int SchoolId { get; set; }
}

public class ClassUpdateDto
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
}

// Student DTOs
public class StudentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

public class StudentCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int ClassId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

public class StudentUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int ClassId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

// Teacher DTOs (additional)
public class TeacherCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
    public bool IsClassTeacher { get; set; }
    public List<int> SubjectIds { get; set; } = new();
}

public class TeacherUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsClassTeacher { get; set; }
    public bool IsActive { get; set; }
}

// Subject DTOs (additional)
public class SubjectCreateDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}

public class SubjectUpdateDto
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}

// TeacherSubject DTOs
public class TeacherSubjectDto
{
    public int Id { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
}

public class TeacherSubjectCreateDto
{
    public int TeacherId { get; set; }
    public int SubjectId { get; set; }
}

// Attendance DTOs
public class AttendanceDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}

public class AttendanceCreateDto
{
    public int StudentId { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; }
    public string Notes { get; set; }
}

public class AttendanceUpdateDto
{
    public string Status { get; set; }
    public string Notes { get; set; }
}

// BehaviorRecord DTOs
public class BehaviorRecordDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public DateTime Date { get; set; }
    public string RecordedByName { get; set; }
}

public class BehaviorRecordCreateDto
{
    public int StudentId { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
    public DateTime Date { get; set; }
}

public class BehaviorRecordUpdateDto
{
    public string Type { get; set; }
    public string Description { get; set; }
    public int Points { get; set; }
}

// Grade DTOs
public class GradeDto
{
    public int Id { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public decimal Value { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string GivenByName { get; set; }
}

public class GradeCreateDto
{
    public int StudentId { get; set; }
    public int SubjectId { get; set; }
    public decimal Value { get; set; }
    public string Type { get; set; }
    public DateTime Date { get; set; }
    public string Description { get; set; }
}

public class GradeUpdateDto
{
    public decimal Value { get; set; }
    public string Description { get; set; }
}

// Homework DTOs
public class HomeworkDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public DateTime DueDate { get; set; }
    public string CreatedByName { get; set; }
}

public class HomeworkCreateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public int SubjectId { get; set; }
    public int ClassId { get; set; }
    public DateTime DueDate { get; set; }
}

public class HomeworkUpdateDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
}

// Other DTOs
public class LessonScheduleDto
{
    public int Id { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public int TeacherId { get; set; }
    public string TeacherName { get; set; }
    public string DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public class LessonScheduleCreateDto
{
    public int ClassId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public class LessonScheduleUpdateDto
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public class NotificationDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool IsRead { get; set; }
}

public class NotificationCreateDto
{
    public string Title { get; set; }
    public string Message { get; set; }
    public int UserId { get; set; }
}

public class NotificationUpdateDto
{
    public bool IsRead { get; set; }
}

public class ParentDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class ParentCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
}

public class ParentUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
}

public class ParentStudentDto
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public int StudentId { get; set; }
    public string StudentName { get; set; }
}

public class ParentStudentCreateDto
{
    public int ParentId { get; set; }
    public int StudentId { get; set; }
}

public class TimetableCreateDto
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

public class TimetableUpdateDto
{
    public string DayOfWeek { get; set; }
    public int Period { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string Room { get; set; }
}

public class DirectorCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
}

public class DirectorUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

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