using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/teachers")]
[Authorize(Roles = "Director")]
public class DirectorTeachersController : ControllerBase
{
    // GET /api/teachers
    [HttpGet]
    public async Task<IActionResult> GetTeachers()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var teachers = new List<TeacherDto>
        {
            new() 
            { 
                Id = 1, 
                FirstName = "Malika", 
                LastName = "Karimova", 
                Email = "malika@test.com", 
                Username = "malika_teacher",
                IsClassTeacher = true,
                Subjects = new List<string> { "Matematika", "Fizika" },
                Classes = new List<string> { "7-A", "8-B" },
                SchoolId = schoolId,
                IsActive = true
            },
            new() 
            { 
                Id = 2, 
                FirstName = "Akmal", 
                LastName = "Akhmedov", 
                Email = "akmal@test.com", 
                Username = "akmal_teacher",
                IsClassTeacher = false,
                Subjects = new List<string> { "Ona tili", "Adabiyot" },
                Classes = new List<string> { "7-A", "7-B", "8-A" },
                SchoolId = schoolId,
                IsActive = true
            }
        };
        
        return Ok(teachers);
    }

    // POST /api/teachers
    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var teacher = new TeacherDto
        {
            Id = new Random().Next(1, 1000),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            IsClassTeacher = request.IsClassTeacher,
            SchoolId = schoolId,
            IsActive = true
        };
        
        return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
    }

    // GET /api/teachers/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify teacher belongs to school
        var teacher = new TeacherDto
        {
            Id = id,
            FirstName = "Sample",
            LastName = "Teacher",
            Email = "teacher@test.com",
            SchoolId = schoolId,
            IsActive = true
        };
        
        return Ok(teacher);
    }

    // PUT /api/teachers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify teacher belongs to school
        return Ok(new { message = "Teacher updated successfully" });
    }

    // DELETE /api/teachers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify teacher belongs to school
        return Ok(new { message = "Teacher deleted successfully" });
    }

    // GET /api/teachers/{id}/subjects
    [HttpGet("{id}/subjects")]
    public async Task<IActionResult> GetTeacherSubjects(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var subjects = new List<SubjectDto>
        {
            new() { Id = 1, Name = "Matematika", Code = "MATH" },
            new() { Id = 2, Name = "Fizika", Code = "PHYS" }
        };
        
        return Ok(subjects);
    }

    // POST /api/teachers/{id}/subjects
    [HttpPost("{id}/subjects")]
    public async Task<IActionResult> AssignSubjectToTeacher(int id, [FromBody] AssignSubjectRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        return Ok(new { message = "Subject assigned to teacher successfully" });
    }

    // DELETE /api/teachers/{teacherId}/subjects/{subjectId}
    [HttpDelete("{teacherId}/subjects/{subjectId}")]
    public async Task<IActionResult> RemoveSubjectFromTeacher(int teacherId, int subjectId)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        return Ok(new { message = "Subject removed from teacher successfully" });
    }
}