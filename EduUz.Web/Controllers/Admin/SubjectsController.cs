using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/subjects")]
[Authorize(Roles = "Admin")]
public class SubjectsController : ControllerBase
{
    // GET /api/subjects
    [HttpGet]
    public async Task<IActionResult> GetSubjects()
    {
        // TODO: Implement with service
        var subjects = new List<SubjectDto>
        {
            new() { Id = 1, Name = "Matematika", Code = "MATH", Description = "Matematika fani" },
            new() { Id = 2, Name = "Ona tili", Code = "UZB", Description = "O'zbek tili fani" },
            new() { Id = 3, Name = "Adabiyot", Code = "LIT", Description = "Adabiyot fani" },
            new() { Id = 4, Name = "Tarix", Code = "HIST", Description = "Tarix fani" },
            new() { Id = 5, Name = "Fizika", Code = "PHYS", Description = "Fizika fani" },
            new() { Id = 6, Name = "Kimyo", Code = "CHEM", Description = "Kimyo fani" },
            new() { Id = 7, Name = "Biologiya", Code = "BIO", Description = "Biologiya fani" },
            new() { Id = 8, Name = "Ingliz tili", Code = "ENG", Description = "Ingliz tili fani" }
        };
        return Ok(subjects);
    }

    // POST /api/subjects
    [HttpPost]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectRequest request)
    {
        // TODO: Implement with service
        var subject = new SubjectDto
        {
            Id = new Random().Next(1, 1000),
            Name = request.Name,
            Code = request.Code,
            Description = request.Description
        };
        return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subject);
    }

    // GET /api/subjects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubject(int id)
    {
        // TODO: Implement with service
        var subject = new SubjectDto
        {
            Id = id,
            Name = "Sample Subject",
            Code = "SAMP",
            Description = "Sample Description"
        };
        return Ok(subject);
    }

    // PUT /api/subjects/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubject(int id, [FromBody] UpdateSubjectRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "Subject updated successfully" });
    }

    // DELETE /api/subjects/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        // TODO: Implement with service
        return Ok(new { message = "Subject deleted successfully" });
    }
}