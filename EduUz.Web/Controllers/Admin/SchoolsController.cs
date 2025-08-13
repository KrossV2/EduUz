using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/schools")]
[Authorize(Roles = "Admin")]
public class SchoolsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SchoolsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/schools
    [HttpGet]
    public async Task<IActionResult> GetSchools([FromQuery] int? cityId, [FromQuery] int? regionId)
    {
        // TODO: Create GetAllSchoolsQuery and Handler
        // var query = new GetAllSchoolsQuery(cityId, regionId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAllSchoolsQuery handler needed" });
    }

    // POST /api/schools
    [HttpPost]
    public async Task<IActionResult> CreateSchool([FromBody] CreateSchoolRequest request)
    {
        // TODO: Create CreateSchoolCommand and Handler
        // var command = new CreateSchoolCommand(request.Name, request.Address, request.CityId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetSchool), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateSchoolCommand handler needed" });
    }

    // GET /api/schools/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSchool(int id)
    {
        // TODO: Create GetSchoolByIdQuery and Handler
        // var query = new GetSchoolByIdQuery(id);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSchoolByIdQuery handler needed" });
    }

    // PUT /api/schools/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSchool(int id, [FromBody] UpdateSchoolRequest request)
    {
        // TODO: Create UpdateSchoolCommand and Handler
        // var command = new UpdateSchoolCommand(id, request.Name, request.Address, request.CityId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateSchoolCommand handler needed" });
    }

    // DELETE /api/schools/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSchool(int id)
    {
        // TODO: Create DeleteSchoolCommand and Handler
        // var command = new DeleteSchoolCommand(id);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteSchoolCommand handler needed" });
    }

    // POST /api/schools/{id}/director
    [HttpPost("{id}/director")]
    public async Task<IActionResult> AssignDirector(int id, [FromBody] AssignDirectorRequest request)
    {
        // TODO: Create AssignDirectorCommand and Handler
        // var command = new AssignDirectorCommand(id, request.FirstName, request.LastName, request.Email, request.Password);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "AssignDirectorCommand handler needed" });
    }
}