using EduUz.Application.Mediatr.Teachers.Homeworks.CreateHomework;
using EduUz.Application.Mediatr.Teachers.Homeworks.DeleteHomework;
using EduUz.Application.Mediatr.Teachers.Homeworks.UpdateHomework;
using EduUz.Application.Mediatr.Teachers.Homeworks.GetAllHomeworks;
using EduUz.Application.Mediatr.Teachers.Homeworks.GetHomeworkById;
using EduUz.Application.Mediatr.Teachers.Homeworks.UploadHomeworkMaterial;
using EduUz.Application.Mediatr.Teachers.Grades.CreateGrade;
using EduUz.Application.Mediatr.Teachers.Grades.UpdateGrade;
using EduUz.Application.Mediatr.Teachers.Grades.GetGradesByStudent;
using EduUz.Application.Mediatr.Teachers.Grades.GetClassGrades;
using EduUz.Application.Mediatr.Teachers.Grades.GetGradesBySubject;
using EduUz.Application.Mediatr.Teachers.Attendances.CreateAttendance;
using EduUz.Application.Mediatr.Teachers.Attendances.UpdateAttendance;
using EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceByClass;
using EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceByStudent;
using EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceReports;
using EduUz.Application.Mediatr.Teachers.Tyutor.CreateParent;
using EduUz.Application.Mediatr.Teachers.Tyutor.CreateStudent;
using EduUz.Application.Mediatr.Teachers.Tyutor.LinkParentStudent;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/teacher")]
public class TeacherController(IMediator mediator) : ControllerBase
{
    // Homeworks
    [HttpGet("homeworks")]
    public async Task<ActionResult<List<HomeworkResponseDto>>> GetAllHomeworks()
    {
        var result = await mediator.Send(new GetAllHomeworksQuery());
        return Ok(result);
    }

    [HttpGet("homeworks/{id:int}")]
    public async Task<ActionResult<HomeworkResponseDto>> GetHomeworkById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetHomeworkByIdQuery(id));
        return Ok(result);
    }

    [HttpPost("homeworks")]
    public async Task<ActionResult<HomeworkResponseDto>> CreateHomework([FromBody] HomeworkCreateDto dto)
    {
        var result = await mediator.Send(new CreateHomeworkCommand(dto));
        return Ok(result);
    }

    [HttpPut("homeworks/{id:int}")]
    public async Task<ActionResult<HomeworkResponseDto>> UpdateHomework([FromBody] HomeworkUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateHomeworkCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("homeworks/{id:int}")]
    public async Task<IActionResult> DeleteHomework([FromRoute] int id)
    {
        await mediator.Send(new DeleteHomeworkCommand(id));
        return NoContent();
    }

    public class UploadMaterialRequest { public string FilePath { get; set; } = string.Empty; }
    [HttpPost("homeworks/{id:int}/materials")]
    public async Task<IActionResult> UploadHomeworkMaterial([FromRoute] int id, [FromBody] UploadMaterialRequest file)
    {
        await mediator.Send(new UploadHomeworkMaterialCommand(id, file.FilePath));
        return NoContent();
    }

    // Grades
    [HttpPost("grades")]
    public async Task<ActionResult<GradeResponseDto>> CreateGrade([FromBody] GradeCreateDto dto)
    {
        var result = await mediator.Send(new CreateGradeCommand(dto));
        return Ok(result);
    }

    [HttpPut("grades/{id:int}")]
    public async Task<ActionResult<GradeResponseDto>> UpdateGrade([FromBody] GradeUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateGradeCommand(id, dto));
        return Ok(result);
    }

    [HttpGet("grades/students/{studentId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetGradesByStudent([FromRoute] int studentId)
    {
        var result = await mediator.Send(new GetGradesByStudentQuery(studentId));
        return Ok(result);
    }

    [HttpGet("grades/classes/{classId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetGradesByClass([FromRoute] int classId)
    {
        var result = await mediator.Send(new GetGradesByClassQuery(classId));
        return Ok(result);
    }

    [HttpGet("grades/subjects/{subjectId:int}")]
    public async Task<ActionResult<List<GradeResponseDto>>> GetGradesBySubject([FromRoute] int subjectId)
    {
        var result = await mediator.Send(new GetGradesBySubjectQuery(subjectId));
        return Ok(result);
    }

    // Attendance
    [HttpPost("attendance")]
    public async Task<ActionResult<AttendanceDto>> CreateAttendance([FromBody] AttendanceCreateDto dto)
    {
        var result = await mediator.Send(new CreateAttendanceCommand(dto));
        return Ok(result);
    }

    [HttpPut("attendance/{id:int}")]
    public async Task<ActionResult<AttendanceDto>> UpdateAttendance([FromBody] AttendanceUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateAttendanceCommand(id, dto));
        return Ok(result);
    }

    [HttpGet("attendance/classes/{classId:int}")]
    public async Task<ActionResult<List<AttendanceResponseDto>>> GetAttendanceByClass([FromRoute] int classId)
    {
        var result = await mediator.Send(new GetAttendanceByClassQuery(classId));
        return Ok(result);
    }

    [HttpGet("attendance/students/{studentId:int}")]
    public async Task<ActionResult<List<AttendanceResponseDto>>> GetAttendanceByStudent([FromRoute] int studentId)
    {
        var result = await mediator.Send(new GetAttendanceByStudentQuery(studentId));
        return Ok(result);
    }

    [HttpGet("attendance/reports")]
    public async Task<ActionResult<List<AttendanceStatisticsDto>>> GetAttendanceReports()
    {
        var result = await mediator.Send(new GetAttendanceReportsQuery());
        return Ok(result);
    }

    // Tutor
    [HttpPost("tutor/parents")]
    public async Task<ActionResult<int>> CreateParent([FromBody] int userId)
    {
        var result = await mediator.Send(new CreateParentCommand(userId));
        return Ok(result);
    }

    [HttpPost("tutor/students")]
    public async Task<ActionResult<StudentResponseDto>> CreateStudent([FromBody] StudentCreateDto dto)
    {
        var result = await mediator.Send(new CreateStudentCommand(dto));
        return Ok(result);
    }

    [HttpPost("tutor/link-parent-student")]
    public async Task<IActionResult> LinkParentStudent([FromBody] ParentStudentCreateDto dto)
    {
        await mediator.Send(new LinkParentStudentCommand(dto.ParentId, dto.StudentId));
        return NoContent();
    }
}

