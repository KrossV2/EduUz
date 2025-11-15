using EduUz.Application.Mediatr.Students.GetAllAttendances;
using EduUz.Application.Mediatr.Students.GetAllGrades;
using EduUz.Application.Mediatr.Students.GetAllHomeworks;
using EduUz.Application.Mediatr.Students.GetAllTimetables;
using EduUz.Application.Mediatr.Students.GetMyBehavior;
using EduUz.Application.Mediatr.Students.GetMyNotification;
using EduUz.Application.Mediatr.Students.SubmitHomework;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/student")]
public class StudentsController(IMediator mediator , EduUzDbContext context) : ControllerBase
{
    [HttpGet("attendances")]
    public async Task<ActionResult<IEnumerable<Attendance>>> GetAllAttendances()
    {
        var result = await mediator.Send(new GetAllAttendancesQuery());
        return Ok(result);
    }

    [HttpGet("grades")]
    public async Task<ActionResult<IEnumerable<Grade>>> GetAllGrades()
    {
        var result = await mediator.Send(new GetAllGradesQuery());
        return Ok(result);
    }

    [HttpGet("homeworks")]
    public async Task<ActionResult<IEnumerable<Homework>>> GetAllHomeworks()
    {
        var result = await mediator.Send(new GetAllHomeworksQuery());
        return Ok(result);
    }

    [HttpGet("timetables")]
    public async Task<ActionResult<IEnumerable<Timetable>>> GetAllTimetables()
    {
        var result = await mediator.Send(new GetAllTimetablesQuery());
        return Ok(result);
    }

    [HttpGet("behaviors/{studentId:int}")]
    public async Task<ActionResult<List<BehaviorRecordDto>>> GetMyBehavior([FromRoute] int studentId)
    {
        var result = await mediator.Send(new GetMyBehaviorQuery(studentId));
        return Ok(result);
    }

    [HttpGet("notifications/{userId:int}")]
    public async Task<ActionResult<List<NotificationDto>>> GetMyNotifications([FromRoute] int userId)
    {
        var result = await mediator.Send(new GetMyNotificationsQuery(userId));
        return Ok(result);
    }

    [HttpPost("homeworks/{homeworkId:int}/submit")]
    public async Task<ActionResult<bool>> SubmitHomework([FromRoute] int homeworkId, [FromBody] SubmitHomeworkRequest request)
    {
        var result = await mediator.Send(new SubmitHomeworkCommand(homeworkId, request.StudentId, request.FileUrl, request.Comment));
        return Ok(result);
    }

    [HttpGet("students/getall")]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await context.Students.ToListAsync();

        return Ok(students);
    }

    [HttpGet("students/getbyid/{id}")]
    public async Task<IActionResult> GetStudentById([FromRoute] int id)
    {
        var student = await context.Students.FindAsync(id);

        return Ok(student);
    }

    [HttpGet("class/students/getbyid/{id}")]
    public async Task<IActionResult> GetClassStudentsById([FromRoute] int id)
    {
        var students = await context.Students
           .Where(s => s.ClassId == id)
           .ToListAsync();

        return Ok(students);
    }

    [HttpDelete("student/remove/{id}")]
    public async Task<IActionResult> StudentRemove([FromRoute] int id)
    {
        var student = await context.Students.FindAsync(id);

        if(student != null)
        {
            context.Students.Remove(student);
            await context.SaveChangesAsync();

            return Ok(student);
        }

        return BadRequest();
    }

    [HttpPut("student/update/{id}")]
    public async Task<IActionResult> UpdateStudent(StudentUpdateDto dto , [FromRoute] int id)
    {
        var student = await context.Students.FindAsync(id);

        if(student != null)
        {
            context.Students.Update(student);
            await context.SaveChangesAsync();
            return Ok(student);
        }

        return BadRequest();
    }
}

public class SubmitHomeworkRequest
{
    public int StudentId { get; set; }
    public string FileUrl { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}

