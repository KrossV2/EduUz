using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/system")]
[Authorize(Roles = "Admin")]
public class SystemController : ControllerBase
{
    private readonly IMediator _mediator;

    public SystemController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/system/stats
    [HttpGet("stats")]
    public async Task<IActionResult> GetSystemStats()
    {
        // TODO: Create GetSystemStatsQuery and Handler
        // var query = new GetSystemStatsQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSystemStatsQuery handler needed" });
    }

    // GET /api/system/health
    [HttpGet("health")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSystemHealth()
    {
        // TODO: Create GetSystemHealthQuery and Handler
        // var query = new GetSystemHealthQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSystemHealthQuery handler needed" });
    }

    // GET /api/system/version
    [HttpGet("version")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSystemVersion()
    {
        // TODO: Create GetSystemVersionQuery and Handler
        // var query = new GetSystemVersionQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSystemVersionQuery handler needed" });
    }
}