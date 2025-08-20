using System;
using AutoMapper;
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceByClass;

public record GetAttendanceByClassQuery(int ClassId) : IRequest<List<AttendanceResponseDto>>;

public class GetAttendanceByClassQueryHandler : IRequestHandler<GetAttendanceByClassQuery, List<AttendanceResponseDto>>
{
    private readonly EduUzDbContext _context;

    public GetAttendanceByClassQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<AttendanceResponseDto>> Handle(GetAttendanceByClassQuery request, CancellationToken cancellationToken)
    {
        var result = await _context.Attendances
            .Include(a => a.Student).ThenInclude(s => s.User)
            .Include(a => a.Student).ThenInclude(s => s.Class)
            .Include(a => a.Timetable).ThenInclude(t => t.LessonSchedule).ThenInclude(ls => ls.TeacherSubject).ThenInclude(ts => ts.Subject)
            .Where(a => a.Student.ClassId == request.ClassId)
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