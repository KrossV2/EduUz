using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Directors;

[ApiController]
[Route("api/grade-change-requests")]
[Authorize(Roles = "Director")]
public class GradeChangeRequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GradeChangeRequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET /api/grade-change-requests
    [HttpGet]
    public async Task<IActionResult> GetGradeChangeRequests([FromQuery] string? status, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetGradeChangeRequestsQuery and Handler
        // var query = new GetGradeChangeRequestsQuery(schoolId, status, page, pageSize);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetGradeChangeRequestsQuery handler needed" });
    }

    // GET /api/grade-change-requests/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGradeChangeRequest(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetGradeChangeRequestByIdQuery and Handler
        // var query = new GetGradeChangeRequestByIdQuery(id, schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetGradeChangeRequestByIdQuery handler needed" });
    }

    // PUT /api/grade-change-requests/{id}/approve
    [HttpPut("{id}/approve")]
    public async Task<IActionResult> ApproveGradeChangeRequest(int id, [FromBody] ApproveGradeChangeRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        var directorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create ApproveGradeChangeRequestCommand and Handler
        // var command = new ApproveGradeChangeRequestCommand(id, directorId, schoolId, request.Comment);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "ApproveGradeChangeRequestCommand handler needed" });
    }

    // PUT /api/grade-change-requests/{id}/reject
    [HttpPut("{id}/reject")]
    public async Task<IActionResult> RejectGradeChangeRequest(int id, [FromBody] RejectGradeChangeRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        var directorId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create RejectGradeChangeRequestCommand and Handler
        // var command = new RejectGradeChangeRequestCommand(id, directorId, schoolId, request.Comment);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "RejectGradeChangeRequestCommand handler needed" });
    }

    // GET /api/grade-change-requests/pending
    [HttpGet("pending")]
    public async Task<IActionResult> GetPendingGradeChangeRequests()
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Create GetPendingGradeChangeRequestsQuery and Handler
        // var query = new GetPendingGradeChangeRequestsQuery(schoolId);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetPendingGradeChangeRequestsQuery handler needed" });
    }
}