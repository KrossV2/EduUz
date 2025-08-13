using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admins;

[ApiController]
[Route("api/audit-logs")]
[Authorize(Roles = "Admin")]
public class AuditLogsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuditLogsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/audit-logs
    [HttpGet]
    public async Task<IActionResult> GetAuditLogs(
        [FromQuery] int? schoolId,
        [FromQuery] int? userId,
        [FromQuery] string? action,
        [FromQuery] string? entityName,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 50)
    {
        // TODO: Create GetAuditLogsQuery and Handler
        // var query = new GetAuditLogsQuery(schoolId, userId, action, entityName, from, to, page, pageSize);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAuditLogsQuery handler needed" });
    }
}