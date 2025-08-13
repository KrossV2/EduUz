using EduUz.Application.Mediator.Grades.CreateGrade;
using EduUz.Application.Mediator.Grades.UpdateGrade;
using EduUz.Application.Mediator.Grades.GradeFilter;
using EduUz.Application.Mediator.Grades.RequestGradeChange;
using EduUz.Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/grades")]
public class GradesController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Sinf baholari - Get grades by class ID
    /// </summary>
    /// <param name="classId">Class ID</param>
    /// <returns>List of grades for the class</returns>
    [HttpGet("class/{classId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetClassGrades(int classId)
    {
        try
        {
            var query = new GetFilteredGradesQuery(new GradeFilterDto(classId, null, null, null, null, null));
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving class grades", error = ex.Message });
        }
    }

    /// <summary>
    /// O'quvchi baholari - Get grades by student ID
    /// </summary>
    /// <param name="studentId">Student ID</param>
    /// <returns>List of grades for the student</returns>
    [HttpGet("student/{studentId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetStudentGrades(int studentId)
    {
        try
        {
            var query = new GetFilteredGradesQuery(new GradeFilterDto(null, null, studentId, null, null, null));
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving student grades", error = ex.Message });
        }
    }

    /// <summary>
    /// Fan baholari - Get grades by subject ID
    /// </summary>
    /// <param name="subjectId">Subject ID</param>
    /// <returns>List of grades for the subject</returns>
    [HttpGet("subject/{subjectId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetSubjectGrades(int subjectId)
    {
        try
        {
            var query = new GetFilteredGradesQuery(new GradeFilterDto(null, subjectId, null, null, null, null));
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving subject grades", error = ex.Message });
        }
    }

    /// <summary>
    /// Baho qo'yish - Create a new grade
    /// </summary>
    /// <param name="gradeCreateDto">Grade creation data</param>
    /// <returns>Created grade</returns>
    [HttpPost]
    public async Task<ActionResult<GradeResponseDto>> CreateGrade([FromBody] GradeCreateDto gradeCreateDto)
    {
        try
        {
            var command = new CreateGradeCommand(gradeCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentGrades), new { studentId = gradeCreateDto.StudentId }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating grade", error = ex.Message });
        }
    }

    /// <summary>
    /// Baho tahrirlash (so'rov yuboradi) - Request grade change
    /// </summary>
    /// <param name="id">Grade ID</param>
    /// <param name="gradeChangeRequest">Grade change request data</param>
    /// <returns>Change request result</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult> RequestGradeChange(int id, [FromBody] GradeChangeRequestDto gradeChangeRequest)
    {
        try
        {
            var command = new RequestGradeChangeCommand(gradeChangeRequest);
            await mediator.Send(command);
            return Ok(new { message = "Grade change request submitted successfully" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error submitting grade change request", error = ex.Message });
        }
    }

    /// <summary>
    /// Get filtered grades with multiple criteria
    /// </summary>
    /// <param name="filter">Filter criteria</param>
    /// <returns>Filtered grades</returns>
    [HttpPost("filter")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetFilteredGrades([FromBody] GradeFilterDto filter)
    {
        try
        {
            var query = new GetFilteredGradesQuery(filter);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving filtered grades", error = ex.Message });
        }
    }
}