using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Common;

[ApiController]
[Route("api/behavior-records")]
[Authorize(Roles = "Teacher,Director,Admin")]
public class BehaviorRecordsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BehaviorRecordsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST /api/behavior-records
    [HttpPost]
    public async Task<IActionResult> CreateBehaviorRecord([FromBody] object request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        var schoolId = User.FindFirstValue("SchoolId");
        
        // TODO: Create CreateBehaviorRecordCommand and Handler
        // var command = new CreateBehaviorRecordCommand(request, userId, role, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "CreateBehaviorRecordCommand handler needed" });
    }

    // GET /api/behavior-records/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBehaviorRecord(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create GetBehaviorRecordByIdQuery and Handler
        // var query = new GetBehaviorRecordByIdQuery(id, userId, role);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetBehaviorRecordByIdQuery handler needed" });
    }

    // PUT /api/behavior-records/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBehaviorRecord(int id, [FromBody] object request)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create UpdateBehaviorRecordCommand and Handler
        // var command = new UpdateBehaviorRecordCommand(id, request, userId, role);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UpdateBehaviorRecordCommand handler needed" });
    }

    // GET /api/behavior-records/student/{studentId}
    [HttpGet("student/{studentId}")]
    public async Task<IActionResult> GetStudentBehaviorRecords(int studentId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create GetStudentBehaviorRecordsQuery and Handler
        // var query = new GetStudentBehaviorRecordsQuery(studentId, userId, role, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetStudentBehaviorRecordsQuery handler needed" });
    }

    // GET /api/behavior-records/class/{classId}
    [HttpGet("class/{classId}")]
    public async Task<IActionResult> GetClassBehaviorRecords(int classId, [FromQuery] DateTime? from, [FromQuery] DateTime? to)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create GetClassBehaviorRecordsQuery and Handler
        // var query = new GetClassBehaviorRecordsQuery(classId, userId, role, from, to);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetClassBehaviorRecordsQuery handler needed" });
    }

    // DELETE /api/behavior-records/{id}
    [HttpDelete("{id}")]
    [Authorize(Roles = "Director,Admin")]
    public async Task<IActionResult> DeleteBehaviorRecord(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create DeleteBehaviorRecordCommand and Handler
        // var command = new DeleteBehaviorRecordCommand(id, userId, role);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteBehaviorRecordCommand handler needed" });
    }
}