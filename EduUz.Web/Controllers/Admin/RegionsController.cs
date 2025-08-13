using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/regions")]
[Authorize(Roles = "Admin")]
public class RegionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RegionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/regions
    [HttpGet]
    public async Task<IActionResult> GetRegions()
    {
        // TODO: Create GetAllRegionsQuery and Handler
        // var query = new GetAllRegionsQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAllRegionsQuery handler needed" });
    }

    // POST /api/regions
    [HttpPost]
    public async Task<IActionResult> CreateRegion([FromBody] CreateRegionRequest request)
    {
        // TODO: Create CreateRegionCommand and Handler
        // var command = new CreateRegionCommand(request.Name);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetRegion), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateRegionCommand handler needed" });
    }

    // GET /api/regions/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetRegion(int id)
    {
        // TODO: Create GetRegionByIdQuery and Handler
        // var query = new GetRegionByIdQuery(id);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetRegionByIdQuery handler needed" });
    }

    // PUT /api/regions/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRegion(int id, [FromBody] UpdateRegionRequest request)
    {
        // TODO: Create UpdateRegionCommand and Handler
        // var command = new UpdateRegionCommand(id, request.Name);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateRegionCommand handler needed" });
    }

    // DELETE /api/regions/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRegion(int id)
    {
        // TODO: Create DeleteRegionCommand and Handler
        // var command = new DeleteRegionCommand(id);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteRegionCommand handler needed" });
    }
}