namespace EduUz.Application.Mediatr.Teacher.Homeworks.GetAllHomeworks;


public record GetAllHomeworksQuery() : IRequest<List<HomeworkResponseDto>>;

public class GetAllHomeworksQueryHandler(IHomeworkRepository repo, IMapper mapper)
    : IRequestHandler<GetAllHomeworksQuery, List<HomeworkResponseDto>>
{
    public async Task<List<HomeworkResponseDto>> Handle(GetAllHomeworksQuery request, CancellationToken cancellationToken)
    {
        var homeworks = await repo.GetAllAsync();

        return mapper.Map<List<HomeworkResponseDto>>(homeworks);
    }
}
