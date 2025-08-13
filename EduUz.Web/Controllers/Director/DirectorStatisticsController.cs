using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/statistics")]
[Authorize(Roles = "Director")]
public class DirectorStatisticsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DirectorStatisticsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/statistics/classes
    [HttpGet("classes")]
    public async Task<IActionResult> GetClassesStatistics()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetClassesStatisticsQuery and Handler
        // var query = new GetClassesStatisticsQuery(schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassesStatisticsQuery handler needed" });
    }

    // GET /api/statistics/teachers
    [HttpGet("teachers")]
    public async Task<IActionResult> GetTeachersStatistics()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetTeachersStatisticsQuery and Handler
        // var query = new GetTeachersStatisticsQuery(schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeachersStatisticsQuery handler needed" });
    }

    // GET /api/statistics/attendance
    [HttpGet("attendance")]
    public async Task<IActionResult> GetAttendanceStatistics([FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetAttendanceStatisticsQuery and Handler
        // var query = new GetAttendanceStatisticsQuery(schoolId, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAttendanceStatisticsQuery handler needed" });
    }

    // GET /api/statistics/grades
    [HttpGet("grades")]
    public async Task<IActionResult> GetGradesStatistics([FromQuery] int? classId, [FromQuery] int? subjectId)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetGradesStatisticsQuery and Handler
        // var query = new GetGradesStatisticsQuery(schoolId, classId, subjectId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetGradesStatisticsQuery handler needed" });
    }
}