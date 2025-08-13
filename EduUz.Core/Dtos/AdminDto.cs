namespace EduUz.Core.Dtos;

// Region DTOs
public class RegionDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CityDto> Cities { get; set; } = new();
}

public class CreateRegionRequest
{
    public string Name { get; set; }
}

public class UpdateRegionRequest
{
    public string Name { get; set; }
}

// City DTOs
public class CityDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public List<SchoolDto> Schools { get; set; } = new();
}

public class CreateCityRequest
{
    public string Name { get; set; }
    public int RegionId { get; set; }
}

public class UpdateCityRequest
{
    public string Name { get; set; }
    public int RegionId { get; set; }
}

// School DTOs
public class SchoolDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
    public string CityName { get; set; }
    public int? DirectorId { get; set; }
    public string DirectorName { get; set; }
    public int StudentsCount { get; set; }
    public int TeachersCount { get; set; }
    public int ClassesCount { get; set; }
}

public class CreateSchoolRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}

public class UpdateSchoolRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int CityId { get; set; }
}

public class AssignDirectorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}

// Subject DTOs
public class SubjectDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}

public class CreateSubjectRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}

public class UpdateSubjectRequest
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
}

// User Management DTOs
public class CreateDirectorRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
}

public class CreateTeacherRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int SchoolId { get; set; }
    public List<int> SubjectIds { get; set; } = new();
    public bool IsClassTeacher { get; set; }
}

public class UpdateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}

// System Statistics
public class SystemStatsDto
{
    public int TotalSchools { get; set; }
    public int TotalStudents { get; set; }
    public int TotalTeachers { get; set; }
    public int TotalDirectors { get; set; }
    public int TotalRegions { get; set; }
    public int TotalCities { get; set; }
    public int ActiveUsers { get; set; }
    public Dictionary<string, int> UsersByRole { get; set; } = new();
    public Dictionary<string, int> SchoolsByRegion { get; set; } = new();
}