using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Directors.Classes.GetAllClasses;

public class GetAllClassesQuery : IRequest<IEnumerable<Class>>
{
}

public class GetAllClassesQueryHandler(IClassRepository repo) : IRequestHandler<GetAllClassesQuery, IEnumerable<Class>>
{
    public async Task<IEnumerable<Class>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
