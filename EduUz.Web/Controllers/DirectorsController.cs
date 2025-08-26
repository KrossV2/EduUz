using EduUz.Application.Mediatr.Classes.CreateClasses;
using EduUz.Application.Mediatr.Directors.Classes.DeleteClass;
using EduUz.Application.Mediatr.Directors.Classes.UpdateClass;
using EduUz.Application.Mediatr.Directors.Classes.GetAllClasses;
using EduUz.Application.Mediatr.Directors.Classes.GetAllStudents;
using EduUz.Application.Mediatr.Statistics.GetAttendanceStatistics;
using EduUz.Application.Mediatr.Statistics.GetClassStatistics;
using EduUz.Application.Mediatr.Statistics.GetTeacherStatistics;
using EduUz.Application.Mediatr.Timetables.CreateTimetable;
using EduUz.Application.Mediatr.Timetables.DeleteTimetable;
using EduUz.Application.Mediatr.Timetables.UpdateTimetable;
using EduUz.Application.Mediatr.Timetables.GetAllTimetable;
using EduUz.Application.Mediatr.Directors.RequestGrades.GetGradeChangeRequests;
using EduUz.Application.Mediatr.Directors.RequestGrades.GetGradesReports;
using EduUz.Application.Mediatr.Directors.RequestGrades.ApproveGradeChangeRequest;
using EduUz.Application.Mediatr.Directors.RequestGrades.RejectGradeChangeRequest;
using EduUz.Application.Mediatr.Directors.Teachers.CreateTeacher;
using EduUz.Application.Mediatr.Teachers.UpdateTeacher;
using EduUz.Application.Mediatr.Teachers.DeleteTeacher;
using EduUz.Application.Mediatr.Teachers.GetAllTeachers;
using EduUz.Application.Mediatr.Teachers.GetTeacherSubjects;
using EduUz.Application.Mediatr.Directors.Teachers.AddSubjectToTeacher;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/director")]
public class DirectorsController(IMediator mediator) : ControllerBase
{
    [HttpGet("classes")]
    public async Task<ActionResult<IEnumerable<Class>>> GetAllClasses()
    {
        var result = await mediator.Send(new GetAllClassesQuery());
        return Ok(result);
    }

    [HttpPost("classes")]
    public async Task<ActionResult<ClassResponseDto>> CreateClass([FromBody] ClassCreateDto dto)
    {
        var result = await mediator.Send(new CreateClassCommand(dto));
        return Ok(result);
    }

    [HttpPut("classes/{id:int}")]
    public async Task<ActionResult<ClassResponseDto>> UpdateClass([FromBody] ClassUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateClassCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("classes/{id:int}")]
    public async Task<IActionResult> DeleteClass([FromRoute] int id)
    {
        await mediator.Send(new DeleteClassCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpGet("classes/{id:int}/students")]
    public async Task<ActionResult<IEnumerable<Student>>> GetAllStudents([FromRoute] int id)
    {
        var result = await mediator.Send(new GetAllStudentsQuery(id));
        return Ok(result);
    }

    // Timetables
    [HttpGet("timetables")]
    public async Task<ActionResult<IEnumerable<Timetable>>> GetAllTimetables()
    {
        var result = await mediator.Send(new GetAllTimetablesQuery());
        return Ok(result);
    }

    [HttpPost("timetables")]
    public async Task<ActionResult<TimetableResponseDto>> CreateTimetable([FromBody] TimetableCreateDto dto)
    {
        var result = await mediator.Send(new CreateTimetableCommand(dto));
        return Ok(result);
    }

    [HttpPut("timetables/{id:int}")]
    public async Task<ActionResult<TimetableResponseDto>> UpdateTimetable([FromBody] TimetableUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateTimetableCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("timetables/{id:int}")]
    public async Task<IActionResult> DeleteTimetable([FromRoute] int id)
    {
        await mediator.Send(new DeleteTimetableCommand(id));
        return NoContent();
    }

    // Grade change requests and reports
    [HttpGet("grade-requests")]
    public async Task<ActionResult<List<GradeChangeRequest>>> GetGradeChangeRequests()
    {
        var result = await mediator.Send(new GetAllGradeChangeRequestsQuery());
        return Ok(result);
    }

    [HttpPost("grade-requests/{id:int}/approve")]
    public async Task<ActionResult<bool>> ApproveGradeChange([FromRoute] int id)
    {
        var result = await mediator.Send(new ApproveGradeChangeRequestCommand(id));
        return Ok(result);
    }

    [HttpPost("grade-requests/{id:int}/reject")]
    public async Task<ActionResult<bool>> RejectGradeChange([FromRoute] int id)
    {
        var result = await mediator.Send(new RejectGradeChangeRequestCommand(id));
        return Ok(result);
    }

    [HttpGet("grade-reports/{studentId:int}")]
    public async Task<ActionResult<GradeReportDto>> GetGradeReport([FromRoute] int studentId)
    {
        var result = await mediator.Send(new GetGradeReportQuery(studentId));
        return Ok(result);
    }

    // Teachers management
    [HttpGet("teachers")]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetAllTeachers()
    {
        var result = await mediator.Send(new GetAllTeachersQuery());
        return Ok(result);
    }

    [HttpPost("teachers")]
    public async Task<ActionResult<TeacherResponseDto>> CreateTeacher([FromBody] TeacherCreateDto dto)
    {
        var result = await mediator.Send(new CreateTeacherCommand(dto));
        return Ok(result);
    }

    [HttpPut("teachers/{id:int}")]
    public async Task<ActionResult<TeacherResponseDto>> UpdateTeacher([FromBody] TeacherUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateTeacherCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("teachers/{id:int}")]
    public async Task<IActionResult> DeleteTeacher([FromRoute] int id)
    {
        await mediator.Send(new DeleteTeacherCommand(id));
        return NoContent();
    }

    [HttpGet("teachers/{id:int}/subjects")]
    public async Task<ActionResult<List<int>>> GetTeacherSubjects([FromRoute] int id)
    {
        var result = await mediator.Send(new GetTeacherSubjectQuery(id));
        return Ok(result);
    }

    [HttpPost("teachers/subjects")]
    public async Task<ActionResult<TeacherResponseDto>> AddSubjectToTeacher([FromBody] TeacherSubjectCreateDto dto)
    {
        var result = await mediator.Send(new AddSubjectToTeacherCommand(dto));
        return Ok(result);
    }

    // Statistics
    [HttpGet("statistics/classes")]
    public async Task<ActionResult<List<ClassStatistics>>> GetClassStatistics()
    {
        var result = await mediator.Send(new GetClassStatisticsQuery());
        return Ok(result);
    }

    [HttpGet("statistics/teachers")]
    public async Task<ActionResult<List<TeacherStatistics>>> GetTeacherStatistics()
    {
        var result = await mediator.Send(new GetTeacherStatisticsQuery());
        return Ok(result);
    }

    [HttpGet("statistics/attendance")]
    public async Task<ActionResult<List<AttendanceStatistics>>> GetAttendanceStatistics()
    {
        var result = await mediator.Send(new GetAttendanceStatisticsQuery());
        return Ok(result);
    }
}
