using EduUz.Application.Mediator.Homeworks.GetAllHomeworks;
using EduUz.Application.Mediator.Homeworks.CreateHomework;
using EduUz.Application.Mediator.Homeworks.GetHomeworkById;
using EduUz.Application.Mediator.Homeworks.UpdateHomework;
using EduUz.Application.Mediator.Homeworks.DeleteHomework;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/homeworks")]
public class HomeworksController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Uy vazifalari ro'yxati - Get list of homeworks
    /// </summary>
    /// <param name="teacherId">Filter by teacher ID</param>
    /// <param name="classId">Filter by class ID</param>
    /// <param name="subjectId">Filter by subject ID</param>
    /// <returns>List of homeworks</returns>
    [HttpGet]
    public async Task<ActionResult<List<Homework>>> GetHomeworks([FromQuery] int? teacherId = null, [FromQuery] int? classId = null, [FromQuery] int? subjectId = null)
    {
        try
        {
            var query = new GetAllHomeworksQuery
            {
                TeacherId = teacherId,
                ClassId = classId,
                SubjectId = subjectId
            };
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving homeworks", error = ex.Message });
        }
    }

    /// <summary>
    /// Uy vazifasi yaratish - Create homework
    /// </summary>
    /// <param name="homeworkCreateDto">Homework creation data</param>
    /// <returns>Created homework</returns>
    [HttpPost]
    public async Task<ActionResult<HomeworkResponseDto>> CreateHomework([FromBody] HomeworkCreateDto homeworkCreateDto)
    {
        try
        {
            var command = new CreateHomeworkCommand(homeworkCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetHomeworkById), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating homework", error = ex.Message });
        }
    }

    /// <summary>
    /// Uy vazifasi detallari - Get homework details
    /// </summary>
    /// <param name="id">Homework ID</param>
    /// <returns>Homework details</returns>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Homework>> GetHomeworkById(int id)
    {
        try
        {
            var query = new GetHomeworkByIdQuery(id);
            var result = await mediator.Send(query);
            
            if (result == null)
            {
                return NotFound(new { message = "Homework not found" });
            }
            
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving homework", error = ex.Message });
        }
    }

    /// <summary>
    /// Uy vazifasi tahrirlash - Update homework
    /// </summary>
    /// <param name="id">Homework ID</param>
    /// <param name="homeworkUpdateDto">Homework update data</param>
    /// <returns>Updated homework</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<HomeworkResponseDto>> UpdateHomework(int id, [FromBody] HomeworkUpdateDto homeworkUpdateDto)
    {
        try
        {
            var command = new UpdateHomeworkCommand(id, homeworkUpdateDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error updating homework", error = ex.Message });
        }
    }

    /// <summary>
    /// Uy vazifasi o'chirish - Delete homework
    /// </summary>
    /// <param name="id">Homework ID</param>
    /// <returns>Deletion result</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteHomework(int id)
    {
        try
        {
            var command = new DeleteHomeworkCommand(id);
            var result = await mediator.Send(command);
            
            if (!result)
            {
                return NotFound(new { message = "Homework not found" });
            }
            
            return Ok(new { message = "Homework deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error deleting homework", error = ex.Message });
        }
    }

    /// <summary>
    /// Material qo'shish - Add material to homework (placeholder for file upload)
    /// </summary>
    /// <param name="id">Homework ID</param>
    /// <param name="file">File to upload</param>
    /// <returns>Upload result</returns>
    [HttpPost("{id:int}/materials")]
    public async Task<ActionResult> AddMaterial(int id, IFormFile file)
    {
        try
        {
            // This is a placeholder - actual file upload logic would need to be implemented
            // based on your file storage requirements (local storage, cloud storage, etc.)
            
            if (file == null || file.Length == 0)
            {
                return BadRequest(new { message = "No file provided" });
            }

            // Verify homework exists
            var homework = await mediator.Send(new GetHomeworkByIdQuery(id));
            if (homework == null)
            {
                return NotFound(new { message = "Homework not found" });
            }

            // TODO: Implement actual file upload logic
            // For now, just return success
            return Ok(new { message = "Material uploaded successfully", fileName = file.FileName });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error uploading material", error = ex.Message });
        }
    }
}