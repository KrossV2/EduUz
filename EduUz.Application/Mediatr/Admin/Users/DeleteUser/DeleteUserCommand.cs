using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Users.DeleteUser;

public class DeleteUserCommand(int id):IRequest
{
    public int Id { get; set; } = id;
}

public class DeleteUserCommandHanler(IUserRepository repo) : IRequestHandler<DeleteUserCommand>
{
    public async  Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await repo.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new Exception("User Not Found");
            }

            repo.Delete(user);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}
