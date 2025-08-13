using EduUz.Application.Mediator.Sutudents.CreateStudent;
using EduUz.Application.Mediator.Sutudents.GetStudentsByClassId;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// O'quvchi qo'shish - Create student (for class teachers)
    /// </summary>
    /// <param name="studentCreateDto">Student creation data</param>
    /// <returns>Created student</returns>
    [HttpPost]
    public async Task<ActionResult<StudentResponseDto>> CreateStudent([FromBody] StudentCreateDto studentCreateDto)
    {
        try
        {
            var command = new CreateStudentCommand(studentCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentsByClass), new { classId = studentCreateDto.ClassId }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating student", error = ex.Message });
        }
    }

    /// <summary>
    /// Sinfdagi o'quvchilar - Get students by class ID
    /// </summary>
    /// <param name="classId">Class ID</param>
    /// <returns>List of students in the class</returns>
    [HttpGet("class/{classId:int}")]
    public async Task<ActionResult<List<Student>>> GetStudentsByClass(int classId)
    {
        try
        {
            var query = new GetStudentsByClassIdQuery(classId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving students", error = ex.Message });
        }
    }
}