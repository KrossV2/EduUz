using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.GetAllTeachers;

public class GetAllTeachersQuery : IRequest<IEnumerable<Teacher>>
{
}

public class GetAllTeachersQueryHandler(ITeacherRepository repo) : IRequestHandler<GetAllTeachersQuery, IEnumerable<Teacher>>
{
    public async Task<IEnumerable<Teacher>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
