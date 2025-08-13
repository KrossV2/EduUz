using EduUz.Application.Mediator.Teachers.CreateTeacher;
using EduUz.Application.Mediator.Teachers.GetAllTeachers;
using EduUz.Application.Mediator.Teachers.GetTeacherSubjects;
using EduUz.Application.Mediator.Teachers.UpdateTeacher;
using EduUz.Application.Mediator.Teachers.DeleteTeacher;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/teachers")]
public class TeachersController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Barcha o'qituvchilar - Get all teachers
    /// </summary>
    /// <returns>List of all teachers</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
    {
        try
        {
            var query = new GetAllTeachersQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving teachers", error = ex.Message });
        }
    }

    /// <summary>
    /// O'qituvchi yaratish - Create teacher
    /// </summary>
    /// <param name="teacherCreateDto">Teacher creation data</param>
    /// <returns>Created teacher</returns>
    [HttpPost]
    public async Task<ActionResult<TeacherResponseDto>> CreateTeacher([FromBody] TeacherCreateDto teacherCreateDto)
    {
        try
        {
            var command = new CreateTeacherCommand(teacherCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetAllTeachers), new { id = result.Id }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating teacher", error = ex.Message });
        }
    }

    /// <summary>
    /// O'qituvchi fanlarini olish - Get teacher subjects
    /// </summary>
    /// <param name="teacherId">Teacher ID</param>
    /// <returns>Teacher's subjects</returns>
    [HttpGet("{teacherId:int}/subjects")]
    public async Task<ActionResult<List<TeacherSubject>>> GetTeacherSubjects(int teacherId)
    {
        try
        {
            var query = new GetTeacherSubjectQuery(teacherId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving teacher subjects", error = ex.Message });
        }
    }

    /// <summary>
    /// O'qituvchi ma'lumotlarini yangilash - Update teacher
    /// </summary>
    /// <param name="id">Teacher ID</param>
    /// <param name="teacherUpdateDto">Teacher update data</param>
    /// <returns>Updated teacher</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<TeacherResponseDto>> UpdateTeacher(int id, [FromBody] TeacherUpdateDto teacherUpdateDto)
    {
        try
        {
            var command = new UpdateTeacherCommand(teacherUpdateDto, id);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error updating teacher", error = ex.Message });
        }
    }

    /// <summary>
    /// O'qituvchini o'chirish - Delete teacher
    /// </summary>
    /// <param name="id">Teacher ID</param>
    /// <returns>Deletion result</returns>
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteTeacher(int id)
    {
        try
        {
            var command = new DeleteTeacherCommand(id);
            await mediator.Send(command);
            
            return Ok(new { message = "Teacher deleted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error deleting teacher", error = ex.Message });
        }
    }
}