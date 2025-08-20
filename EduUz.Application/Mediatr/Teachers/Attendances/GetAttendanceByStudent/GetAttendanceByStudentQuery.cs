using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceByStudent;

public record GetAttendanceByStudentQuery(int StudentId) : IRequest<List<AttendanceResponseDto>>;

public class GetAttendanceByStudentQueryHandler : IRequestHandler<GetAttendanceByStudentQuery, List<AttendanceResponseDto>>
{
    private readonly EduUzDbContext _context;

    public GetAttendanceByStudentQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<AttendanceResponseDto>> Handle(GetAttendanceByStudentQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Attendances
            .Include(a => a.Student).ThenInclude(s => s.User)
            .Include(a => a.Student).ThenInclude(s => s.Class)
            .Include(a => a.Timetable).ThenInclude(t => t.LessonSchedule).ThenInclude(ls => ls.TeacherSubject).ThenInclude(ts => ts.Subject)
            .Where(a => a.StudentId == request.StudentId)
            .Select(a => new AttendanceResponseDto(
                a.Id,
                a.Student.User.FirstName + " " + a.Student.User.LastName,
                a.Student.Class.Name,
                a.Timetable.LessonSchedule.TeacherSubject.Subject.Name,
                a.Timetable.LessonDate,
                a.Status.ToString(),
                $"{a.Timetable.StartTime:hh\\:mm} - {a.Timetable.EndTime:hh\\:mm}"
            ))
            .ToListAsync(cancellationToken);

        return result;
    }
}