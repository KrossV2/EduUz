using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/system")]
[Authorize(Roles = "Admin")]
public class SystemController : ControllerBase
{
    // GET /api/system/stats
    [HttpGet("stats")]
    public async Task<IActionResult> GetSystemStats()
    {
        // TODO: Implement with service
        var stats = new SystemStatsDto
        {
            TotalSchools = 1250,
            TotalStudents = 125000,
            TotalTeachers = 8500,
            TotalDirectors = 1250,
            TotalRegions = 14,
            TotalCities = 180,
            ActiveUsers = 133750,
            UsersByRole = new Dictionary<string, int>
            {
                { "Admin", 5 },
                { "Director", 1250 },
                { "Teacher", 8500 },
                { "Student", 125000 },
                { "Parent", 100000 }
            },
            SchoolsByRegion = new Dictionary<string, int>
            {
                { "Toshkent shahri", 150 },
                { "Toshkent viloyati", 120 },
                { "Samarqand viloyati", 100 },
                { "Andijon viloyati", 90 }
            }
        };
        
        return Ok(stats);
    }

    // GET /api/system/health
    [HttpGet("health")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSystemHealth()
    {
        // TODO: Implement with service - check database, external services etc.
        var health = new
        {
            Status = "Healthy",
            Timestamp = DateTime.UtcNow,
            Version = "1.0.0",
            Database = new { Status = "Connected", ResponseTime = "15ms" },
            Services = new { Auth = "Healthy", FileStorage = "Healthy" }
        };
        
        return Ok(health);
    }

    // GET /api/system/version
    [HttpGet("version")]
    [AllowAnonymous]
    public async Task<IActionResult> GetSystemVersion()
    {
        var version = new
        {
            Version = "1.0.0",
            BuildDate = DateTime.UtcNow.AddDays(-30),
            Environment = "Production"
        };
        
        return Ok(version);
    }
}