using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediator.Timetables.DeleteTimetable;

public class DeleteTimetableCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}

public class DeleteTimetableCommandHandler(ITimetableRepository repo) : IRequestHandler<DeleteTimetableCommand>
{
    public async Task Handle(DeleteTimetableCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var Timetable = await repo.GetByIdAsync(request.Id);

            if (Timetable == null)
            {
                throw new Exception("Timetable Not Found");
            }

            repo.Delete(Timetable);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}
