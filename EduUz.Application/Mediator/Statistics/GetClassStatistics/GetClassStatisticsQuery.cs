using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Models;
using MediatR;

namespace EduUz.Application.Mediator.Statistics.GetClassStatistics;

public class GetClassStatisticsQuery : IRequest<List<ClassStatistics>>
{
}

public class GetClassStatisticsQueryHandler(IStatisticsRepository repo) : IRequestHandler<GetClassStatisticsQuery, List<ClassStatistics>>
{
    public async Task<List<ClassStatistics>> Handle(GetClassStatisticsQuery request, CancellationToken cancellationToken)
    {
        return await repo.GetClassStatisticsAsync();
    }
}