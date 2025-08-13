using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/cities")]
[Authorize(Roles = "Admin")]
public class CitiesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CitiesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/cities
    [HttpGet]
    public async Task<IActionResult> GetCities([FromQuery] int? regionId)
    {
        // TODO: Create GetAllCitiesQuery and Handler
        // var query = new GetAllCitiesQuery(regionId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAllCitiesQuery handler needed" });
    }

    // POST /api/cities
    [HttpPost]
    public async Task<IActionResult> CreateCity([FromBody] CreateCityRequest request)
    {
        // TODO: Create CreateCityCommand and Handler
        // var command = new CreateCityCommand(request.Name, request.RegionId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetCity), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateCityCommand handler needed" });
    }

    // GET /api/cities/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCity(int id)
    {
        // TODO: Create GetCityByIdQuery and Handler
        // var query = new GetCityByIdQuery(id);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetCityByIdQuery handler needed" });
    }

    // PUT /api/cities/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCity(int id, [FromBody] UpdateCityRequest request)
    {
        // TODO: Create UpdateCityCommand and Handler
        // var command = new UpdateCityCommand(id, request.Name, request.RegionId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateCityCommand handler needed" });
    }

    // DELETE /api/cities/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCity(int id)
    {
        // TODO: Create DeleteCityCommand and Handler
        // var command = new DeleteCityCommand(id);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteCityCommand handler needed" });
    }
}