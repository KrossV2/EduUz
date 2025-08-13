using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/grades")]
[Authorize(Roles = "Teacher,Director,Admin")]
public class GradesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GradesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/grades/class/{classId}
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetClassGrades(int classId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        var schoolId = User.FindFirstValue("SchoolId");
        
        // TODO: Create GetClassGradesQuery and Handler
        // var query = new GetClassGradesQuery(classId, userId, role, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassGradesQuery handler needed" });
    }

    // GET /api/grades/student/{studentId}
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudentGrades(int studentId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create GetStudentGradesQuery and Handler
        // var query = new GetStudentGradesQuery(studentId, userId, role);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentGradesQuery handler needed" });
    }

    // GET /api/grades/subject/{subjectId}
    [HttpGet("subject/{subjectId}")]
    public async Task<IActionResult> GetSubjectGrades(int subjectId)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create GetSubjectGradesQuery and Handler
        // var query = new GetSubjectGradesQuery(subjectId, userId, role);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSubjectGradesQuery handler needed" });
    }

    // POST /api/grades
    [HttpPost]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> CreateGrade([FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create CreateGradeCommand and Handler
        // var command = new CreateGradeCommand(request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "CreateGradeCommand handler needed" });
    }

    // PUT /api/grades/{id}
    [HttpPut("{id}")]
    [Authorize(Roles = "Teacher")]
    public async Task<IActionResult> RequestGradeChange(int id, [FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create RequestGradeChangeCommand and Handler
        // var command = new RequestGradeChangeCommand(id, request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "RequestGradeChangeCommand handler needed" });
    }

    // GET /api/grades/reports
    [HttpGet("reports")]
    public async Task<IActionResult> GetGradeReports([FromQuery] int? classId, [FromQuery] int? subjectId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        var schoolId = User.FindFirstValue("SchoolId");
        
        // TODO: Create GetGradeReportsQuery and Handler
        // var query = new GetGradeReportsQuery(classId, subjectId, from, to, userId, role, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetGradeReportsQuery handler needed" });
    }
}