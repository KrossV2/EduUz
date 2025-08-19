using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.DeleteTeacher;

public class DeleteTeacherCommand(int id) :  IRequest
{
    public int Id { get; set; } = id;
}

public class DeleteTeacherCommandHandler(ITeacherRepository repo) : IRequestHandler<DeleteTeacherCommand>
{
    public async Task Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var teacher = await repo.GetByIdAsync(request.Id);

            if (teacher == null)
            {
                throw new Exception("Teacher Not Found");
            }

            repo.Delete(teacher);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}
