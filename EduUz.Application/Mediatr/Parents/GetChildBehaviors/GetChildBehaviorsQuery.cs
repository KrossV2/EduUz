using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;

namespace EduUz.Application.Mediatr.Parents.GetChildBehaviors;


public record GetChildBehaviorQuery(int ChildId) : IRequest<List<BehaviorRecordDto>>;

public class GetChildBehaviorQueryHandler : IRequestHandler<GetChildBehaviorQuery, List<BehaviorRecordDto>>
{
    private readonly EduUzDbContext _context;

    public GetChildBehaviorQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<BehaviorRecordDto>> Handle(GetChildBehaviorQuery request, CancellationToken cancellationToken)
    {
        return await _context.BehaviorRecords
            .Where(b => b.StudentId == request.ChildId)
            .Select(b => new BehaviorRecordDto
            {
                Id = b.Id,
                StudentId = b.StudentId,
                TeacherId = b.TeacherId,
                Description = b.Description,
                Points = b.Points,
                RecordDate = b.RecordDate
            })
            .ToListAsync(cancellationToken);
    }
}