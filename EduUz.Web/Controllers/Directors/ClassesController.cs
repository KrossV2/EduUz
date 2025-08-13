using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Directors;

[ApiController]
[Route("api/classes")]
[Authorize(Roles = "Director")]
public class ClassesController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClassesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/classes
    [HttpGet]
    public async Task<IActionResult> GetClasses()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetClassesBySchoolQuery and Handler
        // var query = new GetClassesBySchoolQuery(schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassesBySchoolQuery handler needed", schoolId });
    }

    // POST /api/classes
    [HttpPost]
    public async Task<IActionResult> CreateClass([FromBody] CreateClassRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create CreateClassCommand and Handler
        // var command = new CreateClassCommand(request.Name, request.Grade, request.Section, request.Shift, request.ClassTeacherId, schoolId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetClass), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateClassCommand handler needed" });
    }

    // GET /api/classes/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetClass(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetClassByIdQuery and Handler
        // var query = new GetClassByIdQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassByIdQuery handler needed" });
    }

    // PUT /api/classes/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateClass(int id, [FromBody] UpdateClassRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create UpdateClassCommand and Handler
        // var command = new UpdateClassCommand(id, request.Name, request.Grade, request.Section, request.Shift, request.ClassTeacherId, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateClassCommand handler needed" });
    }

    // DELETE /api/classes/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClass(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create DeleteClassCommand and Handler
        // var command = new DeleteClassCommand(id, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteClassCommand handler needed" });
    }

    // GET /api/classes/{id}/students
    [HttpGet("{id}/students")]
    public async Task<IActionResult> GetClassStudents(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetClassStudentsQuery and Handler
        // var query = new GetClassStudentsQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassStudentsQuery handler needed" });
    }

    // POST /api/classes/{id}/students
    [HttpPost("{id}/students")]
    public async Task<IActionResult> AddStudentToClass(int id, [FromBody] object request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create AddStudentToClassCommand and Handler
        // var command = new AddStudentToClassCommand(id, request, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "AddStudentToClassCommand handler needed" });
    }
}