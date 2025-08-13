using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/classes")]
[Authorize(Roles = "Director")]
public class ClassesController : ControllerBase
{
    // GET /api/classes
    [HttpGet]
    public async Task<IActionResult> GetClasses()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var classes = new List<ClassDto>
        {
            new() { Id = 1, Name = "7-A", Grade = 7, Section = "A", Shift = "Ertalab", ClassTeacherId = 1, ClassTeacherName = "Malika Karimova", StudentsCount = 25, SchoolId = schoolId, SchoolName = "1-son maktab" },
            new() { Id = 2, Name = "8-B", Grade = 8, Section = "B", Shift = "Kechki", ClassTeacherId = 2, ClassTeacherName = "Akmal Akhmedov", StudentsCount = 23, SchoolId = schoolId, SchoolName = "1-son maktab" }
        };
        
        return Ok(classes);
    }

    // POST /api/classes
    [HttpPost]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var classDto = new ClassDto
        {
            Id = new Random().Next(1, 1000),
            Name = request.Name,
            Grade = request.Grade,
            Section = request.Section,
            Shift = request.Shift,
            ClassTeacherId = request.ClassTeacherId,
            SchoolId = schoolId
        };
        
        return CreatedAtAction(nameof(GetClass), new { id = classDto.Id }, classDto);
    }

    // GET /api/classes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClass(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify class belongs to school
        var classDto = new ClassDto
        {
            Id = id,
            Name = "7-A",
            Grade = 7,
            Section = "A",
            Shift = "Ertalab",
            StudentsCount = 25,
            SchoolId = schoolId
        };
        
        return Ok(classDto);
    }

    // PUT /api/classes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, [FromBody] UpdateClassRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify class belongs to school
        return Ok(new { message = "Class updated successfully" });
    }

    // DELETE /api/classes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify class belongs to school
        return Ok(new { message = "Class deleted successfully" });
    }

    // GET /api/classes/{id}/students
    [HttpGet("{id}/students")]
    public async Task<IActionResult> GetClassStudents(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var students = new List<object>
        {
            new { Id = 1, FirstName = "Ali", LastName = "Akbarov", Username = "Ali_Akbarov_7A", Email = "ali@test.com" },
            new { Id = 2, FirstName = "Malika", LastName = "Rahimova", Username = "Malika_Rahimova_7A", Email = "malika@test.com" }
        };
        
        return Ok(students);
    }

    // POST /api/classes/{id}/students
    [HttpPost("{id}/students")]
    public async Task<IActionResult> AddStudentToClass(int id, [FromBody] object request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        return Ok(new { message = "Student added to class successfully" });
    }
}