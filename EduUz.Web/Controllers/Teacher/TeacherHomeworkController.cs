using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Teacher;

[ApiController]
[Route("api/teacher/homeworks")]
[Authorize(Roles = "Teacher")]
public class TeacherHomeworkController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherHomeworkController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/teacher/homeworks
    [HttpGet]
    public async Task<IActionResult> GetMyHomeworks([FromQuery] int? classId, [FromQuery] int? subjectId)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetTeacherHomeworksQuery and Handler
        // var query = new GetTeacherHomeworksQuery(teacherId, classId, subjectId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeacherHomeworksQuery handler needed" });
    }

    // POST /api/teacher/homeworks
    [HttpPost]
    public async Task<IActionResult> CreateHomework([FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create CreateHomeworkCommand and Handler
        // var command = new CreateHomeworkCommand(request, teacherId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetHomework), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateHomeworkCommand handler needed" });
    }

    // GET /api/teacher/homeworks/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetHomework(int id)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetHomeworkByIdQuery and Handler
        // var query = new GetHomeworkByIdQuery(id, teacherId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetHomeworkByIdQuery handler needed" });
    }

    // PUT /api/teacher/homeworks/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateHomework(int id, [FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create UpdateHomeworkCommand and Handler
        // var command = new UpdateHomeworkCommand(id, request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateHomeworkCommand handler needed" });
    }

    // DELETE /api/teacher/homeworks/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHomework(int id)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create DeleteHomeworkCommand and Handler
        // var command = new DeleteHomeworkCommand(id, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteHomeworkCommand handler needed" });
    }

    // POST /api/teacher/homeworks/{id}/materials
    [HttpPost("{id}/materials")]
    public async Task<IActionResult> AddMaterial(int id, [FromForm] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create AddHomeworkMaterialCommand and Handler
        // var command = new AddHomeworkMaterialCommand(id, request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "AddHomeworkMaterialCommand handler needed" });
    }

    // GET /api/teacher/homeworks/{id}/submissions
    [HttpGet("{id}/submissions")]
    public async Task<IActionResult> GetHomeworkSubmissions(int id)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetHomeworkSubmissionsQuery and Handler
        // var query = new GetHomeworkSubmissionsQuery(id, teacherId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetHomeworkSubmissionsQuery handler needed" });
    }
}