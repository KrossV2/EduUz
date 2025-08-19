using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Schools.DeleteSchool;


public class DeleteSchoolCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}

public class DeleteSchoolCommandHandler(ISchoolRepository repo) : IRequestHandler<DeleteSchoolCommand>
{
    public async Task Handle(DeleteSchoolCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var school = await repo.GetByIdAsync(request.Id);

            if (school == null)
            {
                throw new Exception("School Not Found");
            }

            repo.Delete(school);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}