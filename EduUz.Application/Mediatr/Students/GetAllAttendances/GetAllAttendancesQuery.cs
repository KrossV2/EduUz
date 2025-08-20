using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Students.GetAllAttendances;

public class GetAllAttendancesQuery : IRequest<IEnumerable<Attendance>>;


public class GetAllAttendancesQueryHandler(IAttendanceRepository repo) : IRequestHandler<GetAllAttendancesQuery, IEnumerable<Attendance>>
{
    public async Task<IEnumerable<Attendance>> Handle(GetAllAttendancesQuery request, CancellationToken cancellationToken)
    {
        return repo.GetAll();
    }
}
