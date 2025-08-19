using EduUz.Application.Repositories.Interfaces;
using EduUz.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EduUz.Application.Mediatr.Director.Classes.DeleteClass;

public class DeleteClassCommand(int id ) : IRequest
{
    public int Id { get; set; } = id;
}

public class DeleteClassCommandHandler(IClassRepository repo, EduUzDbContext context)
    : IRequestHandler<DeleteClassCommand>
{
    public async Task Handle(DeleteClassCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldClass = await context.Classes
                .Include(c => c.Students)
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (oldClass == null)
                throw new Exception("Class Not Found");

            foreach (var student in oldClass.Students)
            {
                student.ClassId = null; 
            }

            context.Classes.Remove(oldClass);
            await context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}

