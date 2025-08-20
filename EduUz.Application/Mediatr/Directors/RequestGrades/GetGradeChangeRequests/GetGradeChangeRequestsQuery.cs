using System;
using EduUz.Core.Dtos;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Directors.RequestGrades.GetGradeChangeRequests;

public record GetAllGradeChangeRequestsQuery() : IRequest<List<GradeChangeRequest>>;

public class GetAllGradeChangeRequestsHandler : IRequestHandler<GetAllGradeChangeRequestsQuery, List<GradeChangeRequest>>
{
    private readonly EduUzDbContext _context;

    public GetAllGradeChangeRequestsHandler(EduUzDbContext context)
    {
        _context = context;
    }

    public async Task<List<GradeChangeRequest>> Handle(GetAllGradeChangeRequestsQuery request, CancellationToken cancellationToken)
    {
        return await _context.GradeChangeRequests
            .Include(x => x.Grade)
            .ToListAsync(cancellationToken);
    }
}
