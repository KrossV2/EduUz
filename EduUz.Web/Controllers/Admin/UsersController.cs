using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    // GET /api/users
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] int? schoolId, [FromQuery] string? role, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        // TODO: Implement with service
        var users = new List<UserDto>
        {
            new() { Id = 1, FirstName = "Akmal", LastName = "Akhmedov", Email = "akmal@test.com", Username = "akmal_director", Role = "Director", SchoolId = 1, SchoolName = "1-son maktab" },
            new() { Id = 2, FirstName = "Malika", LastName = "Karimova", Email = "malika@test.com", Username = "malika_teacher", Role = "Teacher", SchoolId = 1, SchoolName = "1-son maktab" }
        };
        
        return Ok(new { data = users, total = users.Count, page, pageSize });
    }

    // GET /api/users/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        // TODO: Implement with service
        var user = new UserDto
        {
            Id = id,
            FirstName = "Sample",
            LastName = "User",
            Email = "sample@test.com",
            Username = "sample_user",
            Role = "Teacher"
        };
        return Ok(user);
    }

    // POST /api/users/director
    [HttpPost("director")]
    public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorRequest request)
    {
        // TODO: Implement with service
        var user = new UserDto
        {
            Id = new Random().Next(1, 1000),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = "Director",
            SchoolId = request.SchoolId
        };
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // POST /api/users/teacher
    [HttpPost("teacher")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest request)
    {
        // TODO: Implement with service
        var user = new UserDto
        {
            Id = new Random().Next(1, 1000),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Role = "Teacher",
            SchoolId = request.SchoolId
        };
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "User updated successfully" });
    }

    // DELETE /api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        // TODO: Implement with service
        return Ok(new { message = "User deleted successfully" });
    }

    // GET /api/users/search
    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers([FromQuery] string q, [FromQuery] int? schoolId, [FromQuery] string? role)
    {
        // TODO: Implement with service
        var users = new List<UserDto>
        {
            new() { Id = 1, FirstName = "Test", LastName = "User", Email = "test@test.com", Role = "Teacher" }
        };
        return Ok(users);
    }
}