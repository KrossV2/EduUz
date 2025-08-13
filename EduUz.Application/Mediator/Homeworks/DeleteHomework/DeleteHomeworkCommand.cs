using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediator.Homeworks.DeleteHomework;

public class DeleteHomeworkCommand(int id) : IRequest<bool>
{
    public int Id { get; set; } = id;
}

public class DeleteHomeworkCommandHandler(IHomeworkRepository repo) : IRequestHandler<DeleteHomeworkCommand, bool>
{
    public async Task<bool> Handle(DeleteHomeworkCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var homework = await repo.GetByIdAsync(request.Id);
            if (homework == null)
            {
                return false;
            }

            repo.Delete(homework);
            await repo.SaveChangesAsync();

            return true;
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error deleting homework", ex);
        }
    }
}