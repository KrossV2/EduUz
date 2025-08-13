namespace EduUz.Core.Dtos;

// Missing DTOs for AutoMapper compatibility

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

public class StudentFullCreateDto
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

public class StudentFullUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int ClassId { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
}

public class TeacherFullCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
    public bool IsClassTeacher { get; set; }
    public List<int> SubjectIds { get; set; } = new();
}

public class TeacherFullUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsClassTeacher { get; set; }
    public bool IsActive { get; set; }
}

public class DirectorCreateFullDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
}

public class DirectorUpdateFullDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
}

public class LessonScheduleCreateFullDto
{
    public int ClassId { get; set; }
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string DayOfWeek { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public class LessonScheduleUpdateFullDto
{
    public int SubjectId { get; set; }
    public int TeacherId { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
}

public class ClassCreateFullDto
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
    public int SchoolId { get; set; }
}

public class ClassUpdateFullDto
{
    public string Name { get; set; }
    public int Grade { get; set; }
    public string Section { get; set; }
    public string Shift { get; set; }
    public int? ClassTeacherId { get; set; }
}