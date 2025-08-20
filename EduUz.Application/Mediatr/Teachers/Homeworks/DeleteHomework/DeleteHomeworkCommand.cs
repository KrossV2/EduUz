using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.Homeworks.DeleteHomework;

public record DeleteHomeworkCommand(int id) : IRequest;


public class DeleteHomeworkCommandHandler(IHomeworkRepository repo) : IRequestHandler<DeleteHomeworkCommand>
{
    public async Task Handle(DeleteHomeworkCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var homework = await repo.GetByIdAsync(request.id);

            if (homework == null)
            {
                throw new Exception("homework Not Found");
            }

            repo.Delete(homework);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}
