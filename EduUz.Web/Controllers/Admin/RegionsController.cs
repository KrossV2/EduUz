using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/regions")]
[Authorize(Roles = "Admin")]
public class RegionsController : ControllerBase
{
    // GET /api/regions
    [HttpGet]
    public async Task<IActionResult> GetRegions()
    {
        // TODO: Implement with service
        var regions = new List<RegionDto>
        {
            new() { Id = 1, Name = "Toshkent shahri" },
            new() { Id = 2, Name = "Toshkent viloyati" }
        };
        return Ok(regions);
    }

    // POST /api/regions
    [HttpPost]
    public async Task<IActionResult> CreateRegion([FromBody] CreateRegionRequest request)
    {
        // TODO: Implement with service
        var region = new RegionDto
        {
            Id = new Random().Next(1, 1000),
            Name = request.Name
        };
        return CreatedAtAction(nameof(GetRegion), new { id = region.Id }, region);
    }

    // GET /api/regions/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegion(int id)
    {
        // TODO: Implement with service
        var region = new RegionDto { Id = id, Name = "Sample Region" };
        return Ok(region);
    }

    // PUT /api/regions/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegion(int id, [FromBody] UpdateRegionRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "Region updated successfully" });
    }

    // DELETE /api/regions/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegion(int id)
    {
        // TODO: Implement with service
        return Ok(new { message = "Region deleted successfully" });
    }
}