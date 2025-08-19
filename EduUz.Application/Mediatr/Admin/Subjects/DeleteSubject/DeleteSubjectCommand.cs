using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Subjects.DeleteSubject;

public class DeleteSubjectCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}


public class DeleteSubjectCommandHandler(ISubjectRepository repo) : IRequestHandler<DeleteSubjectCommand>
{
    public async Task Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var subject = await repo.GetByIdAsync(request.Id);

            if (subject == null)
            {
                throw new Exception("Subject Not Found");
            }

            repo.Delete(subject);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}
