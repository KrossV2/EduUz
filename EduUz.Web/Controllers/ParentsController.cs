using EduUz.Application.Mediatr.Parents.GetChildAttendances;
using EduUz.Application.Mediatr.Parents.GetChildBehaviors;
using EduUz.Application.Mediatr.Parents.GetChildGrades;
using EduUz.Application.Mediatr.Parents.GetChildTimetables;
using EduUz.Application.Mediatr.Parents.AddExecuse;
using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/parent")]
public class ParentsController(IMediator mediator) : ControllerBase
{
    [HttpGet("children/{childId:int}/attendances")]
    public async Task<ActionResult<List<AttendanceDto>>> GetChildAttendances([FromRoute] int childId)
    {
        var result = await mediator.Send(new GetChildAttendanceQuery(childId));
        return Ok(result);
    }

    [HttpGet("children/{childId:int}/behaviors")]
    public async Task<ActionResult<List<BehaviorRecordDto>>> GetChildBehaviors([FromRoute] int childId)
    {
        var result = await mediator.Send(new GetChildBehaviorQuery(childId));
        return Ok(result);
    }

    [HttpGet("children/{childId:int}/grades")]
    public async Task<ActionResult<List<GradeDto>>> GetChildGrades([FromRoute] int childId)
    {
        var result = await mediator.Send(new GetChildGradesQuery(childId));
        return Ok(result);
    }

    [HttpGet("children/{childId:int}/timetables")]
    public async Task<ActionResult<List<TimetableDto>>> GetChildTimetables([FromRoute] int childId)
    {
        var result = await mediator.Send(new GetChildTimetableQuery(childId));
        return Ok(result);
    }

    [HttpPost("children/{childId:int}/excuses")]
    public async Task<ActionResult<bool>> AddExcuse([FromRoute] int childId, [FromBody] AddExcuseRequest request)
    {
        var result = await mediator.Send(new AddExcuseCommand(childId, request.Reason, request.Date));
        return Ok(result);
    }
}

public class AddExcuseRequest
{
    public string Reason { get; set; } = string.Empty;
    public DateTime Date { get; set; }
}

