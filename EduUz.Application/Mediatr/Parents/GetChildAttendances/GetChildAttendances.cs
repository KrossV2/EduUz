
using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Parents.GetChildAttendances;
public record GetChildAttendanceQuery(int ChildId) : IRequest<List<AttendanceDto>>;

public class GetChildAttendanceQueryHandler : IRequestHandler<GetChildAttendanceQuery, List<AttendanceDto>>
{
    private readonly EduUzDbContext _context;

    public GetChildAttendanceQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<AttendanceDto>> Handle(GetChildAttendanceQuery request, CancellationToken cancellationToken)
    {
        return await _context.Attendances
            .Where(a => a.StudentId == request.ChildId)
            .Select(a => new AttendanceDto
            {
                Id = a.Id,
                TimetableId = a.TimetableId,
                StudentId = a.StudentId,
                Status = a.Status.ToString()
            })
            .ToListAsync(cancellationToken);
    }
}
