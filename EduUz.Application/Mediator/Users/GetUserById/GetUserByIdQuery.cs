using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Users.GetUserById;

public class GetUserByIdQuery(int id) : IRequest<User>
{
    public int Id { get; set; } = id;
}

public class GetUserByIdQueryHandler(IUserRepository repo) : IRequestHandler<GetUserByIdQuery, User>
{
    public async  Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetByIdAsync(request.Id);
    }
}
