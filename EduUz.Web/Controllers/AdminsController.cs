using EduUz.Application.Mediatr.Admin.Cities.CreateCity;
using EduUz.Application.Mediatr.Admin.Cities.DeleteCity;
using EduUz.Application.Mediatr.Admin.Cities.UpdateCity;
using EduUz.Application.Mediatr.Admin.Regions.GetAllRegions;
using EduUz.Application.Mediatr.Admin.Schools.CreateSchool;
using EduUz.Application.Mediatr.Admin.Schools.GetAllSchools;
using EduUz.Application.Mediatr.Admin.Schools.UpdateSchool;
using EduUz.Application.Mediatr.Admin.Schools.DeleteSchool;
using EduUz.Application.Mediatr.Subjects.CreateSubject;
using EduUz.Application.Mediatr.Subjects.DeleteSubject;
using EduUz.Application.Mediatr.Subjects.UpdateSubject;
using EduUz.Application.Mediatr.Subjects.GetAllSubjects;
using EduUz.Application.Mediatr.Users.GetAllUsers;
using EduUz.Application.Mediatr.Users.GetUserById;
using EduUz.Application.Mediatr.Users.UpdateUser;
using EduUz.Application.Mediatr.Users.DeleteUser;
using EduUz.Application.Mediatr.Directors.CreateDirector;
using EduUz.Application.Mediatr.Teachers.CreateTeacher;
using EduUz.Application.Mediatr.Users.SearchUser;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EduUz.Application.Mediatr.Admin.Directors.GetAllDirectors;
using EduUz.Application.Mediatr.Auth.SignIn;
using EduUz.Application.Mediatr.Auth.SignUp;
using EduUz.Infrastructure.Database;
using EduUz.Application.Mediatr.Admin.Regions.DeleteRegion;
using EduUz.Application.Mediatr.Admin.Cities.GetAllCities;

namespace EduUz.Web.Controllers;

[ApiController]
[Route("api/admin")]
public class AdminsController(IMediator mediator, EduUzDbContext context) : ControllerBase
{
    [HttpGet("regions")]
    public async Task<ActionResult<IEnumerable<Region>>> GetAllRegions()
    {
        var result = await mediator.Send(new GetAllRegionQuery());
        return Ok(result);
    }

    [HttpDelete("regions/{id:int}")]
    public async Task<IActionResult> DeleteRegion([FromRoute] int id)
    {
        await mediator.Send(new DeleteRegionCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpGet("cities")]
    public async Task<IActionResult> GetAllCities()
    {
        var result = await mediator.Send(new GetAllCitiesQuery());
        return Ok(result);
    }

    [HttpPost("cities")]
    public async Task<ActionResult<CityResponseDto>> CreateCity([FromBody] CityCreateDto dto)
    {
        var result = await mediator.Send(new CreateCityCommand(dto));
        return Ok(result);
    }

    [HttpPut("cities/{id:int}")]
    public async Task<ActionResult<CityResponseDto>> UpdateCity([FromBody] CityUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateCityCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("cities/{id:int}")]
    public async Task<IActionResult> DeleteCity([FromRoute] int id)
    {
        await mediator.Send(new DeleteCityCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpGet("subjects")]
    public async Task<ActionResult<IEnumerable<Subject>>> GetAllSubjects()
    {
        var result = await mediator.Send(new GetAllSubjectsQuery());
        return Ok(result);
    }

    [HttpPost("subjects")]
    public async Task<ActionResult<SubjectResponseDto>> CreateSubject([FromBody] SubjectCreateDto dto)
    {
        var result = await mediator.Send(new CreateSubjectCommand(dto));
        return Ok(result);
    }

    [HttpPut("subjects/{id:int}")]
    public async Task<ActionResult<SubjectResponseDto>> UpdateSubject([FromBody] SubjectUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateSubjectCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("subjects/{id:int}")]
    public async Task<IActionResult> DeleteSubject([FromRoute] int id)
    {
        await mediator.Send(new DeleteSubjectCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpGet("schools")]
    public async Task<ActionResult<IEnumerable<School>>> GetAllSchools()
    {
        var result = await mediator.Send(new GetAllSchoolsQuery());
        return Ok(result);
    }

    [HttpPost("schools")]
    public async Task<ActionResult<SchoolResponseDto>> CreateSchool([FromBody] SchoolCreateDto dto)
    {
        var result = await mediator.Send(new CreateSchoolCommand(dto));
        return Ok(result);
    }

    [HttpPut("schools/{id:int}")]
    public async Task<ActionResult<SchoolResponseDto>> UpdateSchool([FromBody] SchoolUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateSchoolCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("schools/{id:int}")]
    public async Task<IActionResult> DeleteSchool([FromRoute] int id)
    {
        await mediator.Send(new DeleteSchoolCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpGet("users")]
    public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
    {
        var result = await mediator.Send(new GetAllUsersQuery());
        return Ok(result);
    }

    [HttpGet("users/{id:int}")]
    public async Task<ActionResult<User>> GetUserById([FromRoute] int id)
    {
        var result = await mediator.Send(new GetUserByIdQuery(id));
        return Ok(result);
    }

    [HttpPut("users/{id:int}")]
    public async Task<ActionResult<UserResponseDto>> UpdateUser([FromBody] UserUpdateDto dto, [FromRoute] int id)
    {
        var result = await mediator.Send(new UpdateUserCommand(dto, id));
        return Ok(result);
    }

    [HttpDelete("users/{id:int}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
        await mediator.Send(new DeleteUserCommand(id));
        return Ok("Deleted Successfully!");
    }

    [HttpPost("users/teacher")]
    public async Task<ActionResult<TeacherResponseDto>> CreateTeacher([FromBody] TeacherCreateDto dto)
    {
        var result = await mediator.Send(new CreateTeacherCommand(dto));
        return Ok(result);
    }

    [HttpPost("users/director")]
    public async Task<ActionResult<int>> CreateDirector([FromBody] DirectorCreateDto dto)
    {
        var result = await mediator.Send(new CreateDirectorCommand(dto));
        return Ok(result);
    }

    [HttpGet("directors")]
    public async Task<IActionResult> GetAllDirectors()
    {
        var result = await mediator.Send(new GetAllDirectorsQuery());
        return Ok(result);
    }

    [HttpGet("users/search")]
    public async Task<ActionResult<List<UserDto>>> SearchUsers([FromQuery] string? searchTerm, [FromQuery] int? roleId, [FromQuery] int? schoolId)
    {
        var result = await mediator.Send(new UserSearchQuery(searchTerm, roleId, schoolId));
        return Ok(result);
    }

    [HttpPost("signin")]
    public async Task<ActionResult<SignInResponseDto>> SignIn([FromBody] SignInRequestDto request)
    {
        var result = await mediator.Send(new SignInCommand(request));
        return Ok(result);
    }

    [HttpPost("signup")]
    public async Task<ActionResult<UserResponseDto>> SignUp([FromBody] UserCreateDto request)
    {
        using var transaction = await context.Database.BeginTransactionAsync();

        try
        {
            var result = await mediator.Send(new SignUpCommand(request));
            await transaction.CommitAsync();
            return Ok(result);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return BadRequest(new { message = "Something Went Wrong! : " + ex.Message });
        }
    }
}