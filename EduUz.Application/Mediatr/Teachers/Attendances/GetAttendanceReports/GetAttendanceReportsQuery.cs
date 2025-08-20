using EduUz.Core.Dtos;
using EduUz.Core.Enums;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Teachers.Attendances.GetAttendanceReports;

public record GetAttendanceReportsQuery : IRequest<List<AttendanceStatisticsDto>>;

public class GetAttendanceReportsQueryHandler : IRequestHandler<GetAttendanceReportsQuery, List<AttendanceStatisticsDto>>
{
    private readonly EduUzDbContext _context;

    public GetAttendanceReportsQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<AttendanceStatisticsDto>> Handle(GetAttendanceReportsQuery request, CancellationToken cancellationToken)
    {
        var stats = await _context.Classes
            .Include(c => c.Students)
                .ThenInclude(s => s.Attendances)
            .Select(c => new AttendanceStatisticsDto
            {
                ClassName = c.Name,
                PresentCount = c.Students.SelectMany(s => s.Attendances).Count(a => a.Status == AttendanceStatus.Present),
                AbsentCount = c.Students.SelectMany(s => s.Attendances).Count(a => a.Status == AttendanceStatus.Absent),
                LateCount = c.Students.SelectMany(s => s.Attendances).Count(a => a.Status == AttendanceStatus.Late),
                AttendanceRate = c.Students.SelectMany(s => s.Attendances).Any()
                    ? (double)c.Students.SelectMany(s => s.Attendances).Count(a => a.Status == AttendanceStatus.Present)
                      / c.Students.SelectMany(s => s.Attendances).Count() * 100
                    : 0
            })
            .ToListAsync(cancellationToken);

        return stats;
    }
}