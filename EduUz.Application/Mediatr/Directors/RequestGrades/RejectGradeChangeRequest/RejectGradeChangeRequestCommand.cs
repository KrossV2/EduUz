using System;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.RequestGrades.RejectGradeChangeRequest;
public record RejectGradeChangeRequestCommand(int Id) : IRequest<bool>;

public class RejectGradeChangeRequestHandler : IRequestHandler<RejectGradeChangeRequestCommand, bool>
{
    private readonly EduUzDbContext _context;

    public RejectGradeChangeRequestHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(RejectGradeChangeRequestCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GradeChangeRequests
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null || entity.Status != "Pending") return false;

        entity.Status = "Rejected";
        await _context.SaveChangesAsync(cancellationToken);

        return true;
    }
}
