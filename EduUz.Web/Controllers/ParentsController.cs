using EduUz.Application.Mediator.Parents.CreateParent;
using EduUz.Application.Mediator.Parents.LinkParentStudent;
using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/parents")]
public class ParentsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Ota-ona qo'shish - Create parent (for class teachers)
    /// </summary>
    /// <param name="parentCreateDto">Parent creation data</param>
    /// <returns>Created parent</returns>
    [HttpPost]
    public async Task<ActionResult<ParentResponseDto>> CreateParent([FromBody] ParentCreateDto parentCreateDto)
    {
        try
        {
            var command = new CreateParentCommand(parentCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(CreateParent), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating parent", error = ex.Message });
        }
    }

    /// <summary>
    /// Ota-onani o'quvchiga biriktirish - Link parent to student
    /// </summary>
    /// <param name="parentStudentCreateDto">Parent-student link data</param>
    /// <returns>Created link</returns>
    [HttpPost("link")]
    public async Task<ActionResult<ParentStudentDto>> LinkParentToStudent([FromBody] ParentStudentCreateDto parentStudentCreateDto)
    {
        try
        {
            var command = new LinkParentStudentCommand(parentStudentCreateDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error linking parent to student", error = ex.Message });
        }
    }
}