using System;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.RequestGrades.ApproveGradeChangeRequest;

public record ApproveGradeChangeRequestCommand(int Id) : IRequest<bool>;

public class ApproveGradeChangeRequestHandler : IRequestHandler<ApproveGradeChangeRequestCommand, bool>
{
    private readonly EduUzDbContext _context;

    public ApproveGradeChangeRequestHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Handle(ApproveGradeChangeRequestCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.GradeChangeRequests
            .Include(x => x.Grade)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (entity == null || entity.Status != "Pending") return false;

        // Update grade value
        entity.Grade.Value = entity.NewValue;
        entity.Status = "Approved";

        await _context.SaveChangesAsync(cancellationToken);
        return true;
    }
}
