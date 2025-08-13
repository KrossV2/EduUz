using EduUz.Application.Mediator.Attendance.GetClassAttendance;
using EduUz.Application.Mediator.Attendance.GetStudentAttendance;
using EduUz.Application.Mediator.Attendance.CreateAttendance;
using EduUz.Application.Mediator.Attendance.UpdateAttendance;
using EduUz.Application.Mediator.Statistics.GetAttendanceStatistics;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/attendance")]
public class AttendanceController(IMediator mediator) : ControllerBase
{
    /// <summary>
    /// Sinf davomati - Get class attendance
    /// </summary>
    /// <param name="classId">Class ID</param>
    /// <returns>List of attendance records for the class</returns>
    [HttpGet("class/{classId:int}")]
    public async Task<ActionResult<List<Attendance>>> GetClassAttendance(int classId)
    {
        try
        {
            var query = new GetClassAttendanceQuery(classId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving class attendance", error = ex.Message });
        }
    }

    /// <summary>
    /// O'quvchi davomati - Get student attendance
    /// </summary>
    /// <param name="studentId">Student ID</param>
    /// <returns>List of attendance records for the student</returns>
    [HttpGet("student/{studentId:int}")]
    public async Task<ActionResult<List<Attendance>>> GetStudentAttendance(int studentId)
    {
        try
        {
            var query = new GetStudentAttendanceQuery(studentId);
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving student attendance", error = ex.Message });
        }
    }

    /// <summary>
    /// Davomat belgilash - Create attendance record
    /// </summary>
    /// <param name="attendanceCreateDto">Attendance creation data</param>
    /// <returns>Created attendance record</returns>
    [HttpPost]
    public async Task<ActionResult<AttendanceResponseDto>> CreateAttendance([FromBody] AttendanceCreateDto attendanceCreateDto)
    {
        try
        {
            var command = new CreateAttendanceCommand(attendanceCreateDto);
            var result = await mediator.Send(command);
            return CreatedAtAction(nameof(GetStudentAttendance), new { studentId = attendanceCreateDto.StudentId }, result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error creating attendance", error = ex.Message });
        }
    }

    /// <summary>
    /// Davomat tahrirlash - Update attendance record
    /// </summary>
    /// <param name="id">Attendance ID</param>
    /// <param name="attendanceUpdateDto">Attendance update data</param>
    /// <returns>Updated attendance record</returns>
    [HttpPut("{id:int}")]
    public async Task<ActionResult<AttendanceResponseDto>> UpdateAttendance(int id, [FromBody] AttendanceUpdateDto attendanceUpdateDto)
    {
        try
        {
            var command = new UpdateAttendanceCommand(id, attendanceUpdateDto);
            var result = await mediator.Send(command);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error updating attendance", error = ex.Message });
        }
    }

    /// <summary>
    /// Davomat hisobotlari - Get attendance reports/statistics
    /// </summary>
    /// <returns>Attendance statistics</returns>
    [HttpGet("reports")]
    public async Task<ActionResult<List<AttendanceStatistics>>> GetAttendanceReports()
    {
        try
        {
            var query = new GetAttendanceStatisticsQuery();
            var result = await mediator.Send(query);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error retrieving attendance reports", error = ex.Message });
        }
    }
}