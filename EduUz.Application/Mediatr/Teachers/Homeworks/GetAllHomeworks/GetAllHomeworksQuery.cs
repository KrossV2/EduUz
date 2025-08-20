using AutoMapper;
using EduUz.Application.Repositories.Interfaces;
using EduUz.Core.Dtos;
using MediatR;

namespace EduUz.Application.Mediatr.Teachers.Homeworks.GetAllHomeworks;


public record GetAllHomeworksQuery() : IRequest<List<HomeworkResponseDto>>;

public class GetAllHomeworksQueryHandler(IHomeworkRepository repo, IMapper mapper)
    : IRequestHandler<GetAllHomeworksQuery, List<HomeworkResponseDto>>
{
    public async Task<List<HomeworkResponseDto>> Handle(GetAllHomeworksQuery request, CancellationToken cancellationToken)
    {
        var homeworks = repo.GetAll();

        return mapper.Map<List<HomeworkResponseDto>>(homeworks);
    }
}
