using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediator.Homeworks.GetHomeworkById;

public class GetHomeworkByIdQuery(int id) : IRequest<Homework?>
{
    public int Id { get; set; } = id;
}

public class GetHomeworkByIdQueryHandler(IHomeworkRepository repo) : IRequestHandler<GetHomeworkByIdQuery, Homework?>
{
    public async Task<Homework?> Handle(GetHomeworkByIdQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll()
            .FirstOrDefault(h => h.Id == request.Id);
    }
}