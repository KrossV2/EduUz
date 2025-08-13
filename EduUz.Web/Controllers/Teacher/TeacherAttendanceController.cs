using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Teachers;

[ApiController]
[Route("api/teacher/attendance")]
[Authorize(Roles = "Teacher")]
public class TeacherAttendanceController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherAttendanceController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/teacher/attendance/class/{classId}
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetClassAttendance(int classId, [FromQuery] DateTime? date)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetClassAttendanceQuery and Handler
        // var query = new GetClassAttendanceQuery(classId, teacherId, date);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassAttendanceQuery handler needed" });
    }

    // GET /api/teacher/attendance/student/{studentId}
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudentAttendance(int studentId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetStudentAttendanceByTeacherQuery and Handler
        // var query = new GetStudentAttendanceByTeacherQuery(studentId, teacherId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentAttendanceByTeacherQuery handler needed" });
    }

    // POST /api/teacher/attendance
    [HttpPost]
    public async Task<IActionResult> MarkAttendance([FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create MarkAttendanceCommand and Handler
        // var command = new MarkAttendanceCommand(request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "MarkAttendanceCommand handler needed" });
    }

    // PUT /api/teacher/attendance/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAttendance(int id, [FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create UpdateAttendanceCommand and Handler
        // var command = new UpdateAttendanceCommand(id, request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateAttendanceCommand handler needed" });
    }

    // GET /api/teacher/attendance/reports
    [HttpGet("reports")]
    public async Task<IActionResult> GetAttendanceReports([FromQuery] int? classId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetAttendanceReportsByTeacherQuery and Handler
        // var query = new GetAttendanceReportsByTeacherQuery(teacherId, classId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAttendanceReportsByTeacherQuery handler needed" });
    }
}