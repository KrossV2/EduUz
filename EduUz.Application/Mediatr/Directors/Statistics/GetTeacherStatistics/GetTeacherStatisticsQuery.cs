using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediatr.Statistics.GetTeacherStatistics;

public class GetTeacherStatisticsQuery : IRequest<List<TeacherStatistics>>
{
}

public class GetTeacherStatisticsQueryHandler(IStatisticsRepository repo) : IRequestHandler<GetTeacherStatisticsQuery, List<TeacherStatistics>>
{
    public async Task<List<TeacherStatistics>> Handle(GetTeacherStatisticsQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetTeacherStatisticsAsync();
    }
}