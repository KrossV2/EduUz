using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Users.GetAllUsers;

public class GetAllUsersQuery :  IRequest<IEnumerable<User>>
{
}

public class GetAllUsersQueryHandler(IUserRepository repo) : IRequestHandler<GetAllUsersQuery, IEnumerable<User>>
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
