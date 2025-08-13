using EduUz.Core.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EduUz.Web.Controllers.Director;

[ApiController]
[Route("api/timetables")]
[Authorize(Roles = "Director")]
public class TimetablesController : ControllerBase
{
    // GET /api/timetables
    [HttpGet]
    public async Task<IActionResult> GetTimetables([FromQuery] int? classId, [FromQuery] string? dayOfWeek)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service
        var timetables = new List<TimetableDto>
        {
            new() 
            { 
                Id = 1, 
                ClassId = 1, 
                ClassName = "7-A", 
                DayOfWeek = "Dushanba", 
                Period = 1, 
                StartTime = "08:00", 
                EndTime = "08:45", 
                SubjectId = 1, 
                SubjectName = "Matematika", 
                TeacherId = 1, 
                TeacherName = "Malika Karimova",
                Room = "101"
            },
            new() 
            { 
                Id = 2, 
                ClassId = 1, 
                ClassName = "7-A", 
                DayOfWeek = "Dushanba", 
                Period = 2, 
                StartTime = "08:55", 
                EndTime = "09:40", 
                SubjectId = 2, 
                SubjectName = "Ona tili", 
                TeacherId = 2, 
                TeacherName = "Akmal Akhmedov",
                Room = "102"
            }
        };
        
        if (classId.HasValue)
        {
            timetables = timetables.Where(t => t.ClassId == classId.Value).ToList();
        }
        
        if (!string.IsNullOrEmpty(dayOfWeek))
        {
            timetables = timetables.Where(t => t.DayOfWeek == dayOfWeek).ToList();
        }
        
        return Ok(timetables);
    }

    // POST /api/timetables
    [HttpPost]
    public async Task<IActionResult> CreateTimetable([FromBody] CreateTimetableRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify class belongs to school
        var timetable = new TimetableDto
        {
            Id = new Random().Next(1, 1000),
            ClassId = request.ClassId,
            DayOfWeek = request.DayOfWeek,
            Period = request.Period,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            SubjectId = request.SubjectId,
            TeacherId = request.TeacherId,
            Room = request.Room
        };
        
        return CreatedAtAction(nameof(GetTimetable), new { id = timetable.Id }, timetable);
    }

    // GET /api/timetables/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTimetable(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify timetable belongs to school
        var timetable = new TimetableDto
        {
            Id = id,
            ClassId = 1,
            ClassName = "7-A",
            DayOfWeek = "Dushanba",
            Period = 1,
            StartTime = "08:00",
            EndTime = "08:45",
            SubjectName = "Matematika",
            TeacherName = "Malika Karimova",
            Room = "101"
        };
        
        return Ok(timetable);
    }

    // PUT /api/timetables/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTimetable(int id, [FromBody] UpdateTimetableRequest request)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify timetable belongs to school
        return Ok(new { message = "Timetable updated successfully" });
    }

    // DELETE /api/timetables/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTimetable(int id)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify timetable belongs to school
        return Ok(new { message = "Timetable deleted successfully" });
    }

    // GET /api/timetables/class/{classId}/week
    [HttpGet("class/{classId}/week")]
    public async Task<IActionResult> GetWeeklyTimetable(int classId)
    {
        var schoolId = int.Parse(User.FindFirstValue("SchoolId")!);
        
        // TODO: Implement with service and verify class belongs to school
        var weeklySchedule = new Dictionary<string, List<TimetableDto>>
        {
            ["Dushanba"] = new List<TimetableDto>
            {
                new() { Period = 1, StartTime = "08:00", EndTime = "08:45", SubjectName = "Matematika", TeacherName = "Malika Karimova", Room = "101" },
                new() { Period = 2, StartTime = "08:55", EndTime = "09:40", SubjectName = "Ona tili", TeacherName = "Akmal Akhmedov", Room = "102" }
            },
            ["Seshanba"] = new List<TimetableDto>
            {
                new() { Period = 1, StartTime = "08:00", EndTime = "08:45", SubjectName = "Fizika", TeacherName = "Malika Karimova", Room = "201" }
            }
        };
        
        return Ok(weeklySchedule);
    }
}