using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/timetables")]
[Authorize(Roles = "Director")]
public class TimetablesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TimetablesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/timetables
    [HttpGet]
    public async Task<IActionResult> GetTimetables([FromQuery] int? classId, [FromQuery] string? dayOfWeek)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTimetablesQuery and Handler
        // var query = new GetTimetablesQuery(schoolId, classId, dayOfWeek);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTimetablesQuery handler needed" });
    }

    // POST /api/timetables
    [HttpPost]
    public async Task<IActionResult> CreateTimetable([FromBody] CreateTimetableRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create CreateTimetableCommand and Handler
        // var command = new CreateTimetableCommand(request, schoolId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetTimetable), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateTimetableCommand handler needed" });
    }

    // GET /api/timetables/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTimetable(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTimetableByIdQuery and Handler
        // var query = new GetTimetableByIdQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTimetableByIdQuery handler needed" });
    }

    // PUT /api/timetables/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTimetable(int id, [FromBody] UpdateTimetableRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create UpdateTimetableCommand and Handler
        // var command = new UpdateTimetableCommand(id, request, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateTimetableCommand handler needed" });
    }

    // DELETE /api/timetables/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimetable(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create DeleteTimetableCommand and Handler
        // var command = new DeleteTimetableCommand(id, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteTimetableCommand handler needed" });
    }

    // GET /api/timetables/class/{classId}/week
    [HttpGet("class/{classId}/week")]
    public async Task<IActionResult> GetWeeklyTimetable(int classId)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetWeeklyTimetableQuery and Handler
        // var query = new GetWeeklyTimetableQuery(classId, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetWeeklyTimetableQuery handler needed" });
    }
}