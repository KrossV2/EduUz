using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Schools.GetAllSchools;

public class GetAllSchoolsQuery : IRequest<IEnumerable<School>>
{
}

public class GetAllSchoolsQueryHandler(ISchoolRepository repo) : IRequestHandler<GetAllSchoolsQuery, IEnumerable<School>>
{
    public async Task<IEnumerable<School>> Handle(GetAllSchoolsQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
