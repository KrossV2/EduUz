using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Admin.Regions.GetAllRegions;

public record GetAllRegionQuery : IRequest<IEnumerable<Region>>;


public class GetAllRegionQueryHandler(EduUzDbContext context) : IRequestHandler<GetAllRegionQuery, IEnumerable<Region>>
{
    public async Task<IEnumerable<Region>> Handle(GetAllRegionQuery request, CancellationToken cancellationToken)
    {
        return context.Regions
            .Include(r=>r.Cities)
            .ThenInclude(r=>r.Schools)
            .ToList();
    }
}
