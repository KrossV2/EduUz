using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Statistics.GetAttendanceStatistics;

public class GetAttendanceStatisticsQuery : IRequest<List<AttendanceStatistics>>
{
}

public class GetAttendanceStatisticsQueryHandler(IStatisticsRepository repo) : IRequestHandler<GetAttendanceStatisticsQuery, List<AttendanceStatistics>>
{
    public async Task<List<AttendanceStatistics>> Handle(GetAttendanceStatisticsQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetAttendanceStatisticsAsync();
    }
}