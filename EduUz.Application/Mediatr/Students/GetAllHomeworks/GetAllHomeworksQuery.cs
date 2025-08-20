
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Students.GetAllHomeworks;

public class GetAllHomeworksQuery : IRequest<IEnumerable<Homework>>;



public class GetAllHomeworksQueryHandler(IHomeworkRepository repo) : IRequestHandler<GetAllHomeworksQuery, IEnumerable<Homework>>
{
    public async Task<IEnumerable<Homework>> Handle(GetAllHomeworksQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
