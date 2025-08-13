using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers.Admin;

[ApiController]
[Route("api/users")]
[Authorize(Roles = "Admin")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/users
    [HttpGet]
    public async Task<IActionResult> GetUsers([FromQuery] int? schoolId, [FromQuery] string? role, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        // TODO: Create GetAllUsersQuery and Handler
        // var query = new GetAllUsersQuery(schoolId, role, page, pageSize);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetAllUsersQuery handler needed" });
    }

    // GET /api/users/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        // TODO: Create GetUserByIdQuery and Handler
        // var query = new GetUserByIdQuery(id);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetUserByIdQuery handler needed" });
    }

    // POST /api/users/director
    [HttpPost("director")]
    public async Task<IActionResult> CreateDirector([FromBody] CreateDirectorRequest request)
    {
        // TODO: Create CreateDirectorCommand and Handler
        // var command = new CreateDirectorCommand(request.FirstName, request.LastName, request.Email, request.Password, request.SchoolId);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateDirectorCommand handler needed" });
    }

    // POST /api/users/teacher
    [HttpPost("teacher")]
    public async Task<IActionResult> CreateTeacher([FromBody] CreateTeacherRequest request)
    {
        // TODO: Create CreateTeacherCommand and Handler
        // var command = new CreateTeacherCommand(request.FirstName, request.LastName, request.Email, request.Password, request.SchoolId, request.SubjectIds, request.IsClassTeacher);
        // var result = await _mediator.Send(command);
        // return CreatedAtAction(nameof(GetUser), new { id = result.Id }, result);
        
        return Ok(new { message = "CreateTeacherCommand handler needed" });
    }

    // PUT /api/users/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        // TODO: Create UpdateUserCommand and Handler
        // var command = new UpdateUserCommand(id, request.FirstName, request.LastName, request.Email, request.IsActive);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateUserCommand handler needed" });
    }

    // DELETE /api/users/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        // TODO: Create DeleteUserCommand and Handler
        // var command = new DeleteUserCommand(id);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteUserCommand handler needed" });
    }

    // GET /api/users/search
    [HttpGet("search")]
    public async Task<IActionResult> SearchUsers([FromQuery] string q, [FromQuery] int? schoolId, [FromQuery] string? role)
    {
        // TODO: Create SearchUsersQuery and Handler
        // var query = new SearchUsersQuery(q, schoolId, role);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "SearchUsersQuery handler needed" });
    }
}