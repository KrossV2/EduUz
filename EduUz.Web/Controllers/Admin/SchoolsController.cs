using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/schools")]
[Authorize(Roles = "Admin")]
public class SchoolsController : ControllerBase
{
    // GET /api/schools
    [HttpGet]
    public async Task<IActionResult> GetSchools([FromQuery] int? cityId, [FromQuery] int? regionId)
    {
        // TODO: Implement with service
        var schools = new List<SchoolDto>
        {
            new() 
            { 
                Id = 1, 
                Name = "1-son maktab", 
                Address = "Toshkent shahri, Yunusobod tumani",
                CityId = 1,
                CityName = "Toshkent",
                DirectorId = 1,
                DirectorName = "Akhmedov Akmal",
                StudentsCount = 500,
                TeachersCount = 30,
                ClassesCount = 20
            }
        };

        return Ok(schools);
    }

    // POST /api/schools
    [HttpPost]
    public async Task<IActionResult> CreateSchool([FromBody] CreateSchoolRequest request)
    {
        // TODO: Implement with service
        var school = new SchoolDto
        {
            Id = new Random().Next(1, 1000),
            Name = request.Name,
            Address = request.Address,
            CityId = request.CityId,
            CityName = "Sample City"
        };
        return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
    }

    // GET /api/schools/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSchool(int id)
    {
        // TODO: Implement with service
        var school = new SchoolDto
        {
            Id = id,
            Name = "Sample School",
            Address = "Sample Address",
            CityId = 1,
            CityName = "Sample City"
        };
        return Ok(school);
    }

    // PUT /api/schools/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchool(int id, [FromBody] UpdateSchoolRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "School updated successfully" });
    }

    // DELETE /api/schools/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchool(int id)
    {
        // TODO: Implement with service
        return Ok(new { message = "School deleted successfully" });
    }

    // POST /api/schools/{id}/director
    [HttpPost("{id}/director")]
    public async Task<IActionResult> AssignDirector(int id, [FromBody] AssignDirectorRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "Director assigned successfully" });
    }
}