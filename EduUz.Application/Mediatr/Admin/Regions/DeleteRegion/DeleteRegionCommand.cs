using EduUz.Application.Repositories.Interfaces;
using EduUz.Infrastructure.Database;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Regions.DeleteRegion;

public record DeleteRegionCommand(int id) : IRequest;


public class DeleteRegionCommandHandler(IRegionRepository repo, EduUzDbContext context) : IRequestHandler<DeleteRegionCommand>
{
    public async Task Handle(DeleteRegionCommand request, CancellationToken cancellationToken)
    {
        var region = await context.Regions.FindAsync(request.id);

        if (region == null)
            throw new Exception("Region Not Found!");

        repo.Delete(region);
        await repo.SaveChangesAsync();
    }
}
