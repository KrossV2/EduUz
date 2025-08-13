using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Parent;

[ApiController]
[Route("api/children")]
[Authorize(Roles = "Parent")]
public class ParentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ParentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/children
    [HttpGet]
    public async Task<IActionResult> GetMyChildren()
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetParentChildrenQuery and Handler
        // var query = new GetParentChildrenQuery(parentId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetParentChildrenQuery handler needed" });
    }

    // GET /api/children/{childId}/grades
    [HttpGet("{childId}/grades")]
    public async Task<IActionResult> GetChildGrades(int childId, [FromQuery] int? subjectId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetChildGradesQuery and Handler
        // var query = new GetChildGradesQuery(childId, parentId, subjectId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetChildGradesQuery handler needed" });
    }

    // GET /api/children/{childId}/attendance
    [HttpGet("{childId}/attendance")]
    public async Task<IActionResult> GetChildAttendance(int childId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetChildAttendanceQuery and Handler
        // var query = new GetChildAttendanceQuery(childId, parentId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetChildAttendanceQuery handler needed" });
    }

    // GET /api/children/{childId}/timetable
    [HttpGet("{childId}/timetable")]
    public async Task<IActionResult> GetChildTimetable(int childId, [FromQuery] string? dayOfWeek)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetChildTimetableQuery and Handler
        // var query = new GetChildTimetableQuery(childId, parentId, dayOfWeek);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetChildTimetableQuery handler needed" });
    }

    // GET /api/children/{childId}/behavior
    [HttpGet("{childId}/behavior")]
    public async Task<IActionResult> GetChildBehaviorRecords(int childId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetChildBehaviorRecordsQuery and Handler
        // var query = new GetChildBehaviorRecordsQuery(childId, parentId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetChildBehaviorRecordsQuery handler needed" });
    }

    // GET /api/children/{childId}/homeworks
    [HttpGet("{childId}/homeworks")]
    public async Task<IActionResult> GetChildHomeworks(int childId, [FromQuery] int? subjectId, [FromQuery] bool? completed)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetChildHomeworksQuery and Handler
        // var query = new GetChildHomeworksQuery(childId, parentId, subjectId, completed);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetChildHomeworksQuery handler needed" });
    }

    // POST /api/children/{childId}/excuses
    [HttpPost("{childId}/excuses")]
    public async Task<IActionResult> SubmitExcuse(int childId, [FromBody] object request)
    {
        var parentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create SubmitExcuseCommand and Handler
        // var command = new SubmitExcuseCommand(childId, parentId, request);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "SubmitExcuseCommand handler needed" });
    }
}