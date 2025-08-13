using EduUz.Application.Mediator.Statistics.GetClassStatistics;
using EduUz.Application.Mediator.Statistics.GetTeacherStatistics;
using EduUz.Application.Mediator.Statistics.GetAttendanceStatistics;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/statistics")]
public class StatisticsController(IMediator mediator) : ControllerBase
{

    [HttpGet("classes")]
    public async Task<ActionResult<List<ClassStatistics>>> GetClassStatistics()
    {
        try
        {
            var query = new GetClassStatisticsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving class statistics", error = ex.Message });
        }
    }

    [HttpGet("teachers")]
    public async Task<ActionResult<List<TeacherStatistics>>> GetTeacherStatistics()
    {
        try
        {
            var query = new GetTeacherStatisticsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving teacher statistics", error = ex.Message });
        }
    }

    [HttpGet("attendance")]
    public async Task<ActionResult<List<AttendanceStatistics>>> GetAttendanceStatistics()
    {
        try
        {
            var query = new GetAttendanceStatisticsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving attendance statistics", error = ex.Message });
        }
    }
}