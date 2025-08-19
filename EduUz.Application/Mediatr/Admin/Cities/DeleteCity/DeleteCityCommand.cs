using EduUz.Application.Repositories.Interfaces;
using MediatR;

namespace EduUz.Application.Mediatr.Admin.Cities.DeleteCity;

public class DeleteCityCommand(int id) : IRequest
{
    public int Id { get; set; } = id;
}


public class DeleteCityCommandHanler(ICityRepository repo) : IRequestHandler<DeleteCityCommand>
{
    public async Task Handle(DeleteCityCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var city = await repo.GetByIdAsync(request.Id);

            if (city == null)
            {
                throw new Exception("City Not Found");
            }

            repo.Delete(city);
            await repo.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new ApplicationException("Error!", ex);
        }
    }
}