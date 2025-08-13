using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Commons;

[ApiController]
[Route("api/files")]
[Authorize]
public class FilesController : ControllerBase
{
    private readonly IMediator _mediator;

    public FilesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST /api/files/upload
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromForm] IFormFile file, [FromForm] string fileType)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var schoolId = User.FindFirstValue("SchoolId");
        
        // TODO: Create UploadFileCommand and Handler
        // var command = new UploadFileCommand(file, fileType, userId, schoolId);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "UploadFileCommand handler needed" });
    }

    // GET /api/files/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> DownloadFile(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create DownloadFileQuery and Handler
        // var query = new DownloadFileQuery(id, userId, role);
        // var result = await _mediator.Send(query);
        // return File(result.Content, result.ContentType, result.FileName);
        
        return Ok(new { message = "DownloadFileQuery handler needed" });
    }

    // DELETE /api/files/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFile(int id)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        var role = User.FindFirstValue(ClaimTypes.Role)!;
        
        // TODO: Create DeleteFileCommand and Handler
        // var command = new DeleteFileCommand(id, userId, role);
        // var result = await _mediator.Send(command);
        // return Ok(result);
        
        return Ok(new { message = "DeleteFileCommand handler needed" });
    }

    // GET /api/files/my
    [HttpGet("my")]
    public async Task<IActionResult> GetMyFiles([FromQuery] string? fileType)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        
        // TODO: Create GetUserFilesQuery and Handler
        // var query = new GetUserFilesQuery(userId, fileType);
        // var result = await _mediator.Send(query);
        // return Ok(result);
        
        return Ok(new { message = "GetUserFilesQuery handler needed" });
    }
}