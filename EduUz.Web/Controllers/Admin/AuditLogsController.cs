using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/audit-logs")]
[Authorize(Roles = "Admin")]
public class AuditLogsController : ControllerBase
{
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
        // TODO: Implement with service
        var auditLogs = new List<object>
        {
            new 
            { 
                Id = 1, 
                Action = "CREATE", 
                EntityName = "User", 
                EntityId = "123",
                UserId = 1,
                UserName = "admin@test.com",
                Timestamp = DateTime.UtcNow.AddHours(-1),
                IpAddress = "192.168.1.1",
                SchoolId = 1,
                SchoolName = "1-son maktab"
            },
            new 
            { 
                Id = 2, 
                Action = "UPDATE", 
                EntityName = "Grade", 
                EntityId = "456",
                UserId = 2,
                UserName = "teacher@test.com",
                Timestamp = DateTime.UtcNow.AddHours(-2),
                IpAddress = "192.168.1.2",
                SchoolId = 1,
                SchoolName = "1-son maktab"
            }
        };
        
        return Ok(new { data = auditLogs, total = auditLogs.Count, page, pageSize });
    }
}