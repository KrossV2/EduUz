using EduUz.Core.Dtos;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Students.GetMyBehavior;
public record GetMyBehaviorQuery(int StudentId) : IRequest<List<BehaviorRecordDto>>;

public class GetMyBehaviorQueryHandler : IRequestHandler<GetMyBehaviorQuery, List<BehaviorRecordDto>>
{
    private readonly EduUzDbContext _context;

    public GetMyBehaviorQueryHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<BehaviorRecordDto>> Handle(GetMyBehaviorQuery request, CancellationToken cancellationToken)
    {
        return await _context.BehaviorRecords
            .Where(b => b.StudentId == request.StudentId)
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
