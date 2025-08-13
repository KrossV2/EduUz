using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Students;

[ApiController]
[Route("api/my")]
[Authorize(Roles = "Student")]
public class MyController : ControllerBase
{
    private readonly IMediator _mediator;

    public MyController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/my/grades
    [HttpGet("grades")]
    public async Task<IActionResult> GetMyGrades([FromQuery] int? subjectId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentGradesQuery and Handler
        // var query = new GetStudentGradesQuery(studentId, subjectId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentGradesQuery handler needed" });
    }

    // GET /api/my/attendance
    [HttpGet("attendance")]
    public async Task<IActionResult> GetMyAttendance([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentAttendanceQuery and Handler
        // var query = new GetStudentAttendanceQuery(studentId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentAttendanceQuery handler needed" });
    }

    // GET /api/my/timetable
    [HttpGet("timetable")]
    public async Task<IActionResult> GetMyTimetable([FromQuery] string? dayOfWeek)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentTimetableQuery and Handler
        // var query = new GetStudentTimetableQuery(studentId, dayOfWeek);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentTimetableQuery handler needed" });
    }

    // GET /api/my/homeworks
    [HttpGet("homeworks")]
    public async Task<IActionResult> GetMyHomeworks([FromQuery] int? subjectId, [FromQuery] bool? completed)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentHomeworksQuery and Handler
        // var query = new GetStudentHomeworksQuery(studentId, subjectId, completed);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentHomeworksQuery handler needed" });
    }

    // GET /api/my/materials
    [HttpGet("materials")]
    public async Task<IActionResult> GetMyMaterials([FromQuery] int? subjectId)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentMaterialsQuery and Handler
        // var query = new GetStudentMaterialsQuery(studentId, subjectId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentMaterialsQuery handler needed" });
    }

    // GET /api/my/behavior
    [HttpGet("behavior")]
    public async Task<IActionResult> GetMyBehaviorRecords([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentBehaviorRecordsQuery and Handler
        // var query = new GetStudentBehaviorRecordsQuery(studentId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentBehaviorRecordsQuery handler needed" });
    }

    // POST /api/my/homeworks/{id}/submit
    [HttpPost("homeworks/{id}/submit")]
    public async Task<IActionResult> SubmitHomework(int id, [FromForm] object request)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create SubmitHomeworkCommand and Handler
        // var command = new SubmitHomeworkCommand(id, request, studentId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "SubmitHomeworkCommand handler needed" });
    }

    // GET /api/my/notifications
    [HttpGet("notifications")]
    public async Task<IActionResult> GetMyNotifications([FromQuery] bool? unreadOnly)
    {
        var studentId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentNotificationsQuery and Handler
        // var query = new GetStudentNotificationsQuery(studentId, unreadOnly);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentNotificationsQuery handler needed" });
    }
}