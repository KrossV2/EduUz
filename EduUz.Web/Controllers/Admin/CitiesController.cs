using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/cities")]
[Authorize(Roles = "Admin")]
public class CitiesController : ControllerBase
{
    // GET /api/cities
    [HttpGet]
    public async Task<IActionResult> GetCities([FromQuery] int? regionId)
    {
        // TODO: Implement with service
        var cities = new List<CityDto>
        {
            new() { Id = 1, Name = "Toshkent", RegionId = 1, RegionName = "Toshkent shahri" },
            new() { Id = 2, Name = "Angren", RegionId = 2, RegionName = "Toshkent viloyati" }
        };

        if (regionId.HasValue)
        {
            cities = cities.Where(c => c.RegionId == regionId.Value).ToList();
        }

        return Ok(cities);
    }

    // POST /api/cities
    [HttpPost]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityRequest request)
    {
        // TODO: Implement with service
        var city = new CityDto
        {
            Id = new Random().Next(1, 1000),
            Name = request.Name,
            RegionId = request.RegionId,
            RegionName = "Sample Region"
        };
        return CreatedAtAction(nameof(GetCity), new { id = city.Id }, city);
    }

    // GET /api/cities/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id)
    {
        // TODO: Implement with service
        var city = new CityDto 
        { 
            Id = id, 
            Name = "Sample City", 
            RegionId = 1, 
            RegionName = "Sample Region" 
        };
        return Ok(city);
    }

    // PUT /api/cities/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityRequest request)
    {
        // TODO: Implement with service
        return Ok(new { message = "City updated successfully" });
    }

    // DELETE /api/cities/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        // TODO: Implement with service
        return Ok(new { message = "City deleted successfully" });
    }
}