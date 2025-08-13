using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/teachers")]
[Authorize(Roles = "Director")]
public class DirectorTeachersController : ControllerBase
{
    private readonly IMediator _mediator;

    public DirectorTeachersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/teachers
    [HttpGet]
    public async Task<IActionResult> GetTeachers()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTeachersBySchoolQuery and Handler
        // var query = new GetTeachersBySchoolQuery(schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeachersBySchoolQuery handler needed" });
    }

    // POST /api/teachers
    [HttpPost]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create CreateTeacherByDirectorCommand and Handler
        // var command = new CreateTeacherByDirectorCommand(request, schoolId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetTeacher), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateTeacherByDirectorCommand handler needed" });
    }

    // GET /api/teachers/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTeacher(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTeacherByIdQuery and Handler
        // var query = new GetTeacherByIdQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeacherByIdQuery handler needed" });
    }

    // PUT /api/teachers/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, [FromBody] UpdateTeacherRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create UpdateTeacherCommand and Handler
        // var command = new UpdateTeacherCommand(id, request, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateTeacherCommand handler needed" });
    }

    // DELETE /api/teachers/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create DeleteTeacherCommand and Handler
        // var command = new DeleteTeacherCommand(id, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteTeacherCommand handler needed" });
    }

    // GET /api/teachers/{id}/subjects
    [HttpGet("{id}/subjects")]
    public async Task<IActionResult> GetTeacherSubjects(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTeacherSubjectsQuery and Handler
        // var query = new GetTeacherSubjectsQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeacherSubjectsQuery handler needed" });
    }

    // POST /api/teachers/{id}/subjects
    [HttpPost("{id}/subjects")]
    public async Task<IActionResult> AssignSubjectToTeacher(int id, [FromBody] AssignSubjectRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create AssignSubjectToTeacherCommand and Handler
        // var command = new AssignSubjectToTeacherCommand(id, request.SubjectId, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "AssignSubjectToTeacherCommand handler needed" });
    }

    // DELETE /api/teachers/{teacherId}/subjects/{subjectId}
    [HttpDelete("{teacherId}/subjects/{subjectId}")]
    public async Task<IActionResult> RemoveSubjectFromTeacher(int teacherId, int subjectId)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create RemoveSubjectFromTeacherCommand and Handler
        // var command = new RemoveSubjectFromTeacherCommand(teacherId, subjectId, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "RemoveSubjectFromTeacherCommand handler needed" });
    }
}