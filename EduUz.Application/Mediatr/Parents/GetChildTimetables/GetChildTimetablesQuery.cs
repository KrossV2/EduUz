using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Parents.GetChildTimetables;

public record GetChildTimetableQuery(int ChildId) : IRequest<List<TimetableDto>>;

public class GetChildTimetableQueryHandler : IRequestHandler<GetChildTimetableQuery, List<TimetableDto>>
{
    private readonly EduUzDbContext _context;

    public GetChildTimetableQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<TimetableDto>> Handle(GetChildTimetableQuery request, CancellationToken cancellationToken)
    {
        var student = await _context.Students
            .Include(s => s.Class)
            .FirstOrDefaultAsync(s => s.Id == request.ChildId, cancellationToken);

        if (student?.ClassId == null)
            return new List<TimetableDto>();

        return await _context.Timetables
            .Include(t => t.LessonSchedule)
            .Where(t => t.LessonSchedule.ClassId == student.ClassId) 
            .Select(t => new TimetableDto
            {
                Id = t.Id,
                LessonScheduleId = t.LessonScheduleId,
                LessonDate = t.LessonDate,
                StartTime = t.StartTime,
                EndTime = t.EndTime
            })
            .ToListAsync(cancellationToken);
    }
}