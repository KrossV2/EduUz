using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Admin.Cities.GetAllCities;

public class GetAllCitiesQuery : IRequest<IEnumerable<City>>;


public class GetAllCitiesQueryHanler(ICityRepository repo , EduUzDbContext context) : IRequestHandler<GetAllCitiesQuery, IEnumerable<City>>
{
    public async Task<IEnumerable<City>> Handle(GetAllCitiesQuery request, CancellationToken cancellationToken)
    {
        return context.Cities.Include(r => r.Schools).ToList() ;
    }
}
