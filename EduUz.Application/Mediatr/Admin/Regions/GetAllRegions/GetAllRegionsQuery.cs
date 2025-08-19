using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Regions.GetAllRegions;

public record GetAllRegionQuery : IRequest<IEnumerable<Region>>;


public class GetAllRegionQueryHandler(IRegionRepository repo) : IRequestHandler<GetAllRegionQuery, IEnumerable<Region>>
{
    public async Task<IEnumerable<Region>> Handle(GetAllRegionQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
