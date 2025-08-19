using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Cities.GetAllCities;

public class GetAllCitiesQuery : IRequest<IEnumerable<City>>;


public class GetAllCitiesQueryHanler(ICityRepository repo) : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
{
    public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
