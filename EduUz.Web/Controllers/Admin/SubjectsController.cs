using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/subjects")]
[Authorize(Roles = "Admin")]
public class SubjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SubjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/subjects
    [HttpGet]
    public async Task<IActionResult> GetSubjects()
    {
        // TODO: Create GetAllSubjectsQuery and Handler
        // var query = new GetAllSubjectsQuery();
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAllSubjectsQuery handler needed" });
    }

    // POST /api/subjects
    [HttpPost]
    public async Task<IActionResult> CreateSubject([FromBody] CreateSubjectRequest request)
    {
        // TODO: Create CreateSubjectCommand and Handler
        // var command = new CreateSubjectCommand(request.Name, request.Code, request.Description);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetSubject), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateSubjectCommand handler needed" });
    }

    // GET /api/subjects/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetSubject(int id)
    {
        // TODO: Create GetSubjectByIdQuery and Handler
        // var query = new GetSubjectByIdQuery(id);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetSubjectByIdQuery handler needed" });
    }

    // PUT /api/subjects/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSubject(int id, [FromBody] UpdateSubjectRequest request)
    {
        // TODO: Create UpdateSubjectCommand and Handler
        // var command = new UpdateSubjectCommand(id, request.Name, request.Code, request.Description);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateSubjectCommand handler needed" });
    }

    // DELETE /api/subjects/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubject(int id)
    {
        // TODO: Create DeleteSubjectCommand and Handler
        // var command = new DeleteSubjectCommand(id);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteSubjectCommand handler needed" });
    }
}