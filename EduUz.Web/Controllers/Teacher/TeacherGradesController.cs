using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Teachers;

[ApiController]
[Route("api/teacher/grades")]
[Authorize(Roles = "Teacher")]
public class TeacherGradesController : ControllerBase
{
    private readonly IMediator _mediator;

    public TeacherGradesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/teacher/grades/my-classes
    [HttpGet("my-classes")]
    public async Task<IActionResult> GetMyClassesGrades()
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetTeacherClassesGradesQuery and Handler
        // var query = new GetTeacherClassesGradesQuery(teacherId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetTeacherClassesGradesQuery handler needed" });
    }

    // GET /api/teacher/grades/class/{classId}/subject/{subjectId}
    [HttpGet("class/{classId}/subject/{subjectId}")]
    public async Task<IActionResult> GetClassSubjectGrades(int classId, int subjectId)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetClassSubjectGradesQuery and Handler
        // var query = new GetClassSubjectGradesQuery(classId, subjectId, teacherId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassSubjectGradesQuery handler needed" });
    }

    // POST /api/teacher/grades
    [HttpPost]
    public async Task<IActionResult> CreateGrade([FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create CreateGradeByTeacherCommand and Handler
        // var command = new CreateGradeByTeacherCommand(request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "CreateGradeByTeacherCommand handler needed" });
    }

    // PUT /api/teacher/grades/{id}/request-change
    [HttpPut("{id}/request-change")]
    public async Task<IActionResult> RequestGradeChange(int id, [FromBody] object request)
    {
        var teacherId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create TeacherRequestGradeChangeCommand and Handler
        // var command = new TeacherRequestGradeChangeCommand(id, request, teacherId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "TeacherRequestGradeChangeCommand handler needed" });
    }
}